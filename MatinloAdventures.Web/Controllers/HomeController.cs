using System.Diagnostics;
using System.Threading.Tasks;
using MatinloAdventures.Data.Models;
using MatinloAdventures.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using MatinloAdventures.Web.Models;

namespace MatinloAdventures.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericDataService<Faq> _faqs;

        public HomeController(IGenericDataService<Faq> faqs)
        {
            _faqs = faqs;
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

        public IActionResult Weather()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BasicGrid()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
