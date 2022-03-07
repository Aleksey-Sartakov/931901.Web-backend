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

        public IActionResult Result()
        {
            CulcData culcData = CulcData.Instance;
            

            return View(culcData);
        }

        [HttpGet]
        public IActionResult Quiz()
        {
            CulcData culcData = CulcData.Instance;
            culcData.Reset();
            culcData.CreateQuestion();

            return View(culcData);
        }

        [HttpPost]
        public IActionResult Quiz(CulcData culcData, string Action)
        {
            culcData = CulcData.Instance;

            if (Request.Form["result"] == "")
            {
                culcData.result = 0;
            }
            else culcData.result = Convert.ToInt32(Request.Form["result"]);

            culcData.QuestionsData.Add($"{culcData.a} {culcData.operation} {culcData.b} = {culcData.result}");

            if (culcData.result == culcData.Culc())
            {
                culcData.CountOfRightAnswers++;
            }

            if (Action == "Next")
            {
                CulcData culcData1 = CulcData.Instance;
                culcData1.CreateQuestion();

                return View(culcData1);
            }
            return RedirectToAction("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}