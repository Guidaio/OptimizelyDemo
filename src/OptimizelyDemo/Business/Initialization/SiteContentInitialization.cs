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
        // One Primary host per locale; Edit host for HTTPS launch profile.
        var changed = false;
        changed |= AddHostIfMissing(website, "localhost:5001", ApplicationHostType.Primary);
        changed |= AddHostIfMissing(website, "localhost:5000", ApplicationHostType.Edit);
        return changed;
    }

    private static bool AddHostIfMissing(
        InProcessWebsite website,
        string authority,
        ApplicationHostType type)
    {
        if (website.Hosts.Any(h =>
                string.Equals(h.Authority, authority, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        website.Hosts.Add(new ApplicationHost(authority) { Type = type });
        return true;
    }
}
