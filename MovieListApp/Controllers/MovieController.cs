using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieListApp.Data;
using MovieListApp.Models;

namespace MovieListApp.Controllers
{
    public class MovieController:Controller
    {
        private readonly AppDbContext _context;
        public MovieController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Movie.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi" };
            return View ();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if ((ModelState.IsValid))
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi" };
            return View(movie);
        }
        // GET: /Movie/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi" };
            return View(movie);
        }

        // POST: /Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movie.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi" };
            return View(movie);
        }
        // GET: /Movie/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movie.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
