using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace clx.libplctag.NET.Tests
{
    public static class Configuration
    {
        //public static string ipAddress = "192.168.5.3";
        //public static int slot = 1;
        public static string ipAddress { get; set; }
        public static int slot { get; set; }

        static Configuration()
        {
            try
            {
                string filePath = "config.json";

                // Read the JSON file content
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize JSON into your class
                AppConfig config = JsonSerializer.Deserialize<AppConfig>(jsonContent);
                ipAddress = config.ipAddress;
                slot = config.slot;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
