namespace Lizards.MvcToolkit.Demo.Features.Vue
{
  using System.Diagnostics;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;

  public sealed class HomeController : Controller
  {
    private readonly IHttpContextAccessor accessor;

    public HomeController(IHttpContextAccessor accessor)
    {
      this.accessor = accessor;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Error()
    {
      ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
      return View();
    }
  }
}
