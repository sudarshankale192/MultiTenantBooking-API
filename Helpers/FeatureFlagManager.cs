using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MultiTenantBookingAPI.Helpers
{
    public static class FeatureFlagManager
    {
        private class TenantConfig
        {
            public bool EnableNotifications { get; set; }
            public string SenderEmail { get; set; }
        }

        public static bool IsNotificationEnabled(string tenant = "tenant-pool.json")
        {
            string path = HostingEnvironment.MapPath($"~/App_Data/{tenant}");
            if (!File.Exists(path)) return false;

            var json = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<TenantConfig>(json);

            return config != null && config.EnableNotifications;
        }

        public static string GetSenderEmail(string tenant = "tenant-pool.json")
        {
            string path = HostingEnvironment.MapPath($"~/App_Data/{tenant}");
            if (!File.Exists(path)) return null;

            var json = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<TenantConfig>(json);

            return config?.SenderEmail;
        }
    }
}