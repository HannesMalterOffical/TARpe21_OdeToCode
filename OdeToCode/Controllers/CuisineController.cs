using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToCode.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OdeToCode.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        public IActionResult Search(string name ="unknown")
        {
            var message = HtmlEncoder.Default.Encode(name);
            throw new Exception("Something terrible happened:");

            //return new EmptyResult();
            return Content(message);
            //return File("/css/site.css", "text/css");
            //return Json(HtmlEncoder.Default);
            //return Redirect("https://tthk.ee");
            //return RedirectToRoute("default",new {controller = "cusine", action = "Second", count = 5});
            //return RedirectToAction(nameof(Second), new {count = 5})
            //return View("/home/index");
            //return RedirectToRoute("default", new { controller = "Home", action = "About" });
        }

        public IActionResult Second(int count)
        {
            return Content($"Teine on siin! {count}");
        }
    }
}
