using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using OptimizelyDemo.Models.Pages;

namespace OptimizelyDemo.Controllers;

/// <summary>
/// Minimal Phase 1 render — full templates come in Phase 3.
/// </summary>
public class HomePageController : PageController<HomePage>
{
    [HttpGet]
    public IActionResult Index(HomePage currentPage) => View(currentPage);
}
