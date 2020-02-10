using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.h1 = "Startsida för Hemsidan";
            ViewData["Message"] = "Hej och välkommen till hemsidan! Här kan du lägga till kurser. De dyker upp på Data-sidan.";

            string textData = "Lite sessionstext från startsidan! Skapad: " + DateTime.Today.ToString("g");
            HttpContext.Session.SetString("testSession", textData);

            return View();
        }

        [HttpPost]
        public IActionResult Index(CourseModel model)
        {
            ViewBag.h1 = "Startsida för Hemsidan";
            ViewData["Message"] = "Hej och välkommen till hemsidan! Här kan du lägga till kurser. De dyker upp på Data-sidan.";

            if (ModelState.IsValid)
            {
                var jsonStr = System.IO.File.ReadAllText("courses.json");
                var jsonObj = JsonConvert.DeserializeObject<List<CourseModel>>(jsonStr);
                jsonObj.Add(model);

                System.IO.File.WriteAllText("courses.json", JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
                ModelState.Clear();
            }
            return View();
        }

        [HttpGet("/data")]
        public IActionResult Session()
        {
            ViewBag.h1 = "Data";
            ViewData["Message"] = "Hej, här kan du se lite sessionsdata och json data.";

            // Läs JSON-fil och parsa den
            var jsonStr = System.IO.File.ReadAllText("courses.json");
            var jsonObj = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonStr);

            string textDataSession = HttpContext.Session.GetString("testSession");
            ViewBag.sessionText = textDataSession;

            return View(jsonObj);
        }

        [HttpGet("/om")]
        public IActionResult About()
        {
            AboutModel pageData = new AboutModel();
            return View(pageData);
        }
    }
}
