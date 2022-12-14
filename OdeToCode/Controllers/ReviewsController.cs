using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToCode.Data;
using OdeToCode.Models;
using OdeToCode.Models.Review_Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace odetocode.controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // get: ReviewsController
        public async Task<IActionResult> index([Bind(Prefix = "id")]int restaurantId)
        {
            var restaurant = await _context.Restaurants
               .Include(r => r.Reviews)
               .FirstOrDefaultAsync(m => m.Id == restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _context.RestaurantReviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = review.RestaurantId });

            }
            return View(review);


        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.RestaurantReviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, RestaurantReviewEditViewModel review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentReview = await _context.RestaurantReviews.FindAsync
                        (id);
                    currentReview.Body = review.Body;
                    currentReview.Raiting = review.Raiting;
                    _context.Entry(currentReview).State = EntityState.Modified;
                    //_context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.RestaurantReviews.Any(r=>r.Id==id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = review.RestaurantId});
            }
            return View(review);
        }
    }
}
