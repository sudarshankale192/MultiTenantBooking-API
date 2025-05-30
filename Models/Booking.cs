using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MultiTenantBookingAPI.Models
{
    public class Booking
    {
        public Guid BookingID { get; set; }

        public string TenantID { get; set; }

        [Required]
        public int FacilityID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [HiddenInput]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}