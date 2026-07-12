namespace OptimizelyDemo.Models.Pages;

[ContentType(
    DisplayName = "Standard Page",
    GUID = "b8d5f3a2-0c4e-5f9b-9a3d-2e6f7b8c9d0e",
    Description = "Generic content page",
    GroupName = SystemTabNames.Content)]
[AvailableContentTypes(
    Availability.Specific,
    Include = [typeof(StandardPage)],
    IncludeOn = [typeof(HomePage), typeof(StandardPage)])]
public class StandardPage : SitePageData
{
}
