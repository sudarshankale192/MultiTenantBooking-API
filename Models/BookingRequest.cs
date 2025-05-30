using System;
using System.ComponentModel.DataAnnotations;

namespace MultiTenantBookingAPI.Models
{
    public class BookingRequest
    {
        public int FacilityID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string UserEmail { get; set; }
        public bool isEnableNotifications { get; set; }
    }
}