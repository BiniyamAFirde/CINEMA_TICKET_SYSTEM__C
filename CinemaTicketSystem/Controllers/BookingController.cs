
using CinemaTicketSystem.Data;
using CinemaTicketSystem.Models;
using CinemaTicketSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int screeningId)
        {
            var screening = await _context.Screenings
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.Id == screeningId);

            if (screening == null)
            {
                return NotFound();
            }

            var model = new BookingViewModel
            {
                ScreeningId = screening.Id,
                MovieTitle = screening.Movie?.Title ?? "",
                ScreeningTime = screening.ScreeningDateTime,
                TicketPrice = screening.TicketPrice
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var screening = await _context.Screenings.FindAsync(model.ScreeningId);
            if (screening == null)
            {
                return NotFound();
            }

            if (screening.AvailableSeats < model.NumberOfTickets)
            {
                ModelState.AddModelError(string.Empty, "Not enough available seats.");
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var booking = new Booking
            {
                UserId = user.Id,
                ScreeningId = screening.Id,
                NumberOfSeats = model.NumberOfTickets,
                TotalPrice = model.NumberOfTickets * screening.TicketPrice,
                BookingDate = DateTime.UtcNow
            };

            screening.AvailableSeats -= model.NumberOfTickets;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success", new { id = booking.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Success(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Screening)
                .ThenInclude(s => s.Movie)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
    }
}
