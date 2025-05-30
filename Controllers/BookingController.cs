using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MultiTenantBookingAPI.Helpers;
using MultiTenantBookingAPI.Models;

namespace MultiTenantBookingAPI.Controllers
{
    [RoutePrefix("api/bookings")]
    public class BookingController : ApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(BookingRequest request)
        {
            string tenant = TenantResolver.GetTenantName(HttpContext.Current.Request);
            var config = ConfigManager.LoadTenantConfig(tenant);

            if ((request.EndTime - request.StartTime).TotalHours > config.MaxBookingHours)
                return BadRequest("Booking exceeds maximum allowed hours.");

            var booking = new Booking
            {
                BookingID = Guid.NewGuid(),
                TenantID = tenant,
                FacilityID = request.FacilityID,
                Date = request.Date,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                UserName = request.UserName,
                UserEmail = request.UserEmail,
                CreatedDate = DateTime.Now
            };

            using (var db = new BookingDbContext())
            {
                db.Bookings.Add(booking);
                await db.SaveChangesAsync();
            }            

            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("confirm")]
        public async Task<IHttpActionResult> ConfirmBooking([FromBody] EmailRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email))
                return BadRequest("Missing email.");

            string tenant = TenantResolver.GetTenantName(HttpContext.Current.Request);
            if (!FeatureFlagManager.IsNotificationEnabled($"tenant-{tenant}.json"))
            {
                return Ok("Notifications are disabled for this tenant.");
            }

            string subject = "Booking Confirmed";
            string message = $"Hello {request.Email}, your booking has been confirmed.";

            await EmailService.SendConfirmationEmailAsync(request.Email, subject, message);

            return Ok("Confirmation email sent.");
        }
    }
}