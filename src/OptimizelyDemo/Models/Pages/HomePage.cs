using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using OptimizelyDemo.Models.Blocks;

namespace OptimizelyDemo.Models.Pages;

[ContentType(
    DisplayName = "Home Page",
    GUID = "a7c4e2f1-9b3d-4e8a-8f2c-1d5e6a7b8c9d",
    Description = "Site start page",
    GroupName = SystemTabNames.Content)]
[AvailableContentTypes(
    Availability.Specific,
    Include = [typeof(StandardPage)])]
public class HomePage : SitePageData
{
    [Display(
        Name = "Main content area",
        Description = "Composable blocks (Hero only in Phase 2)",
        GroupName = SystemTabNames.Content,
        Order = 30)]
    [AllowedTypes(typeof(HeroBlock))]
    public virtual ContentArea? MainContentArea { get; set; }
}
