using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace OptimizelyDemo.Models.Pages;

/// <summary>
/// Shared base for site pages (demo Phase 1).
/// </summary>
public abstract class SitePageData : PageData
{
    [CultureSpecific]
    [Display(
        Name = "Title",
        Description = "Editorial heading for the page",
        GroupName = SystemTabNames.Content,
        Order = 10)]
    public virtual string? Title { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Main body",
        Description = "Main rich-text body",
        GroupName = SystemTabNames.Content,
        Order = 20)]
    public virtual XhtmlString? MainBody { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Meta title",
        Description = "SEO title",
        GroupName = SystemTabNames.Settings,
        Order = 100)]
    public virtual string? MetaTitle { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Meta description",
        Description = "SEO description",
        GroupName = SystemTabNames.Settings,
        Order = 110)]
    [UIHint(UIHint.Textarea)]
    public virtual string? MetaDescription { get; set; }
}
