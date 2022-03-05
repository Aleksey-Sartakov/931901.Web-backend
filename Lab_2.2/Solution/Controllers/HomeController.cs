using Microsoft.AspNetCore.Mvc;
using Solution.Models;
using System.Diagnostics;

namespace Solution.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult ParsingInSingleAction()
        {
            if (Request.Method == "POST")
            {
                CulcData culcData = new CulcData
                {
                    a = Convert.ToInt32(Request.Form["a"]),
                    b = Convert.ToInt32(Request.Form["b"]),
                    operation = (Operations)Enum.Parse(typeof(Operations), Request.Form["operation"])
                };

                ViewBag.Result = culcData.Culc();

                return View("Result");
            } 
            return View("CulcForm");
        }

        [HttpGet]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ParsingInSeparateActionsGet()
        {
            return View("CulcForm");
        }

        [HttpPost]
        [ActionName("ManualParsingSeparate")]
        public IActionResult ParsingInSeparateActionsPost()
        {
            CulcData culcData = new CulcData
            {
                a = Convert.ToInt32(Request.Form["a"]),
                b = Convert.ToInt32(Request.Form["b"]),
                operation = (Operations)Enum.Parse(typeof(Operations), Request.Form["operation"])
            };

            ViewBag.Result = culcData.Culc();

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingParameters()
        {
            return View("CulcForm");
        }

        [HttpPost]
        public IActionResult ModelBindingParameters(int a, int b, Operations operation)
        {
            CulcData culcdata = new CulcData
            {
                a = a,
                b = b,
                operation = operation
            };

            ViewBag.Result = culcdata.Culc();

            return View("Result");
        }

        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View("CulcForm");
        }

        [HttpPost]
        public IActionResult ModelBindingSeparate(CulcData culcdata)
        {
            ViewBag.Result = culcdata.Culc();

            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}