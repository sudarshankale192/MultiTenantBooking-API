using System.Collections.Generic;
using System;
using System.IO;
using System.Web;
using MultiTenantBookingAPI.Models;
using Newtonsoft.Json;

namespace MultiTenantBookingAPI.Helpers
{
    public static class ConfigManager
    {
        public static AppSettings LoadTenantConfig(string tenant)
        {
            string path = HttpContext.Current.Server.MapPath($"~/App_Data/tenant-{tenant}.json");

            //modify your method to print the path being used
            System.Diagnostics.Debug.WriteLine("Loading config from: " + path);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Configuration file for tenant '{tenant}' not found at {path}.");
            }

            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<AppSettings>(json);

        }
    }
}