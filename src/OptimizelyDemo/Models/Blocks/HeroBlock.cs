using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace OptimizelyDemo.Models.Blocks;

[ContentType(
    DisplayName = "Hero Block",
    GUID = "c9e6a4b3-1d5f-6a0c-0b4e-3f7a8c9d0e1f",
    Description = "Hero banner with title, image and CTA",
    GroupName = SystemTabNames.Content)]
public class HeroBlock : BlockData
{
    [CultureSpecific]
    [Display(
        Name = "Title",
        Description = "Main hero heading",
        GroupName = SystemTabNames.Content,
        Order = 10)]
    public virtual string? Title { get; set; }

    [CultureSpecific]
    [Display(
        Name = "Subtitle",
        Description = "Supporting text under the title",
        GroupName = SystemTabNames.Content,
        Order = 20)]
    public virtual string? Subtitle { get; set; }

    [Display(
        Name = "Image",
        Description = "Hero image",
        GroupName = SystemTabNames.Content,
        Order = 30)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? Image { get; set; }

    [CultureSpecific]
    [Display(
        Name = "CTA text",
        Description = "Call-to-action button label",
        GroupName = SystemTabNames.Content,
        Order = 40)]
    public virtual string? CtaText { get; set; }

    [Display(
        Name = "CTA link",
        Description = "Call-to-action URL",
        GroupName = SystemTabNames.Content,
        Order = 50)]
    public virtual Url? CtaLink { get; set; }
}
