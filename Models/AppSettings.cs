using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenantBookingAPI.Models
{
    public class AppSettings
    {
        public int MaxBookingHours { get; set; }
        public bool EnableNotifications { get; set; }
        public bool EnableAdvancedReports { get; set; }
    }
}