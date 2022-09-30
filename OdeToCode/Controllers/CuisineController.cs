using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OdeToCode.Controllers
{
    public class CuisineController : Controller
    {
        public IActionResult Search(string name ="unknown")
        {
            var message = HtmlEncoder.Default.Encode(name);

            //return new EmptyResult();
            //return Content(message);
            return File("/css/site.css", "text/css");
        }
    }
}
