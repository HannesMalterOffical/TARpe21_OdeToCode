using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToCode.Data;
using OdeToCode.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace OdeToCode.Controllers
{
    [Authorize(Roles ="administrators,sales")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        [AllowAnonymous]
        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Restaurants
                    .Where(r => r.Name.StartsWith(term))
                    .Select(r => new
                    {
                        label = r.Name
                    });
            return Json(model);
        }

        //private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _db = dbContext;

            //_logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index(string searchTerm = null, int Page = 1)
        {
            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Raiting))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count
                }
            ).ToPagedList(Page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

                return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Hannes";
            model.Location = "Tallinn, Estonia";
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
