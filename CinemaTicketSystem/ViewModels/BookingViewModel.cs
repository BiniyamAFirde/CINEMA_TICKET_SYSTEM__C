using System.ComponentModel.DataAnnotations;

namespace CinemaTicketSystem.ViewModels
{
    public class BookingViewModel
    {
        public int ScreeningId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You can book between 1 and 10 tickets.")]
        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets { get; set; }

        public string? MovieTitle { get; set; }
        public DateTime ScreeningTime { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
