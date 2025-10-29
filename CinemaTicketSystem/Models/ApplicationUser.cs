using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        // Helper property to get full name without storing it in the database
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}