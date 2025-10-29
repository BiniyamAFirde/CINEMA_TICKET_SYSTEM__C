using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;
using CinemaTicketSystem.ViewModels;

namespace CinemaTicketSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScreeningController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScreeningController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? movieId)
        {
            var screeningsQuery = _context.Screenings
                .Include(s => s.Movie)
                .OrderBy(s => s.ScreeningDateTime).AsQueryable();

            if (movieId.HasValue)
            {
                screeningsQuery = screeningsQuery.Where(s => s.MovieId == movieId.Value);
            }

            var screenings = await screeningsQuery.ToListAsync();

            return View(screenings);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movies = await _context.Movies.ToListAsync();
            var model = new ScreeningCreateViewModel { Movies = movies };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScreeningCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Movies = await _context.Movies.ToListAsync();
                return View(model);
            }

            var screening = new Screening
            {
                MovieId = model.MovieId,
                ScreeningDateTime = model.ScreeningDateTime,
                Theater = model.Theater,
                TotalSeats = model.TotalSeats,
                AvailableSeats = model.TotalSeats,
                TicketPrice = model.TicketPrice
            };

            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Screening created successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var screening = await _context.Screenings
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (screening == null)
                return NotFound();

            return View(screening);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);

            if (screening == null)
                return NotFound();

            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Screening deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}