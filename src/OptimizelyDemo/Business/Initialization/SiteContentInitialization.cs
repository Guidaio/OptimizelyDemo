using EPiServer.Applications;
using EPiServer.DataAccess;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using Microsoft.Extensions.DependencyInjection;
using OptimizelyDemo.Models.Pages;

namespace OptimizelyDemo.Business.Initialization;

/// <summary>
/// Ensures a HomePage exists under Root and is configured as the default in-process application entry point.
/// </summary>
[InitializableModule]
[ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
public class SiteContentInitialization : IInitializableModule
{
    public const string ApplicationName = "optimizelydemo";

    public void Initialize(InitializationEngine context)
    {
        var contentRepository = context.Services.GetRequiredService<IContentRepository>();
        var applicationRepository = context.Services.GetRequiredService<IApplicationRepository>();

        var homeReference = EnsureHomePage(contentRepository);
        EnsureApplication(applicationRepository, homeReference);
    }

    public void Uninitialize(InitializationEngine context)
    {
    }

    private static ContentReference EnsureHomePage(IContentRepository contentRepository)
    {
        var existing = contentRepository
            .GetChildren<HomePage>(ContentReference.RootPage)
            .FirstOrDefault();

        if (existing is not null)
        {
            return existing.ContentLink;
        }

        var home = contentRepository.GetDefault<HomePage>(ContentReference.RootPage);
        home.Name = "Home";
        home.Title = "Welcome";
        home.MainBody = new XhtmlString("<p>OptimizelyDemo start page (Phase 1).</p>");
        home.MetaTitle = "OptimizelyDemo";
        home.MetaDescription = "Demo Optimizely CMS — Fase 1";

        return contentRepository.Save(home, SaveAction.Publish, AccessLevel.NoAccess);
    }

    private static void EnsureApplication(
        IApplicationRepository applicationRepository,
        ContentReference homeReference)
    {
        var websites = applicationRepository.List<InProcessWebsite>().ToList();
        var website = websites.FirstOrDefault(w =>
                string.Equals(w.Name, ApplicationName, StringComparison.OrdinalIgnoreCase))
            ?? websites.FirstOrDefault(w => w.IsDefault)
            ?? websites.FirstOrDefault();

        if (website is null)
        {
            website = new InProcessWebsite(ApplicationName, homeReference)
            {
                DisplayName = "Optimizely Demo"
            };
            EnsureHosts(website);
            applicationRepository.SaveAsync(website).GetAwaiter().GetResult();
            applicationRepository.MakeDefaultAsync(website, true).GetAwaiter().GetResult();
            return;
        }

        var writable = (InProcessWebsite)website.CreateWritableClone();
        var changed = false;

        if (ContentReference.IsNullOrEmpty(writable.EntryPoint)
            || writable.EntryPoint.ToReferenceWithoutVersion() != homeReference.ToReferenceWithoutVersion())
        {
            writable.EntryPoint = homeReference;
            changed = true;
        }

        if (EnsureHosts(writable))
        {
            changed = true;
        }

        if (changed)
        {
            applicationRepository.SaveAsync(writable).GetAwaiter().GetResult();
        }

        if (!writable.IsDefault)
        {
            applicationRepository.MakeDefaultAsync(writable, true).GetAwaiter().GetResult();
        }
    }

    private static bool EnsureHosts(InProcessWebsite website)
    {
        // Dev uses HTTP on :5001 for site + admin. An Edit host on :5000 forces
        // CMS post-login redirects to that authority and breaks the :5001 flow.
        const string httpDevHost = "localhost:5001";

        var desired = new ApplicationHost(httpDevHost)
        {
            Type = ApplicationHostType.Primary,
            PreferredUrlScheme = UrlScheme.Http
        };

        var alreadyOk = website.Hosts.Count == 1
            && string.Equals(website.Hosts[0].Authority, httpDevHost, StringComparison.OrdinalIgnoreCase)
            && website.Hosts[0].Type == ApplicationHostType.Primary
            && website.Hosts[0].PreferredUrlScheme == UrlScheme.Http;

        if (alreadyOk)
        {
            return false;
        }

        website.Hosts.Clear();
        website.Hosts.Add(desired);
        return true;
    }
}
