using System;
using System.Web;

namespace MultiTenantBookingAPI.Helpers
{
    public static class TenantResolver
    {
        public static string GetTenantName(HttpRequest request)
        {
            // Try to get tenant from header
            var tenantId = request.Headers["X-Tenant-ID"];
            if (!string.IsNullOrEmpty(tenantId))
            {
                return tenantId;
            }

            // Fallback to subdomain from host (e.g., tenant1.example.com)
            var host = request.Url.Host;
            var parts = host.Split('.');
            if (parts.Length > 0)
            {
                return parts[0];
            }
            throw new Exception("Unable to resolve tenant.");
        }
    }
}