using products_api.Dtos;
using products_api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace products_api_tests
{
    public class JsonPhoneLoadTests
    {
        private readonly string _dataFolderName = "SeedData";

        private readonly string phonesFile = "default-phone.json";

        [Fact]
        public async void FullWorkflow()
        {
            // Load phones from json
            string jsonData = File.ReadAllText(Path.Combine(DataFolder, phonesFile));
            IEnumerable<PhoneSeedModel>? defaultPhones = JsonSerializer
                .Deserialize<IEnumerable<PhoneSeedModel>>(jsonData);

            // Nothing found
            if (defaultPhones == null) return;

            // Read all phones
            foreach (var phone in defaultPhones)
            {
                Console.WriteLine(phone);
            }
        }

        public string DataFolder
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), _dataFolderName);
            }
        }
    }
}