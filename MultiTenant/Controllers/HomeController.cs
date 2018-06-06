using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Models;

namespace MultiTenant.Controllers
{
    public class HomeController : Controller
    {
        private AppTenant tenant;

        public HomeController(AppTenant tenant)
        {
            this.tenant = tenant;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
