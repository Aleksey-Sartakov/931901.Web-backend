using Microsoft.AspNetCore.Mvc;
using Solution.Models;
using System.Diagnostics;

namespace Solution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult ViewBagCalc()
        {
            Random random = new Random();
            int a = random.Next(0, 10);
            int b = random.Next(0, 10);
            ViewBag.a = a;
            ViewBag.b = b; 
            return View();
        }

        public IActionResult ViewDataCalc()
        {
            Random random = new Random();
            int a = random.Next(0, 10);
            int b = random.Next(0, 10);
            ViewData["a"] = a;
            ViewData["b"] = b;
            return View();
        }

        public IActionResult ModelCalc()
        {
            Random random = new Random();
            var CalcData = new TwoNumbers()
            {
              a = random.Next(0, 10),
              b = random.Next(0, 10)
            };
            return View(CalcData);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}