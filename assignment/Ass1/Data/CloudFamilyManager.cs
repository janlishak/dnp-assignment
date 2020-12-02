using Ass1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ass1.Data.Impl
{
    public class CloudFamilyManager : IFamilyManager
    {
        private readonly HttpClient client;
        private string uri = "http://localhost:5003";

        public CloudFamilyManager()
        {
            client = new HttpClient();
        }
        public async Task AddAdultToFamilyAsync(Adult adultToAdd)
        {
            string adultAsJson = JsonSerializer.Serialize(adultToAdd);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/adults", content);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
           
            Task<string> stringAsync = client.GetStringAsync(uri + "/adults");
            string message = await stringAsync;
            
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async  Task RemoveAdultAsync(Adult adult)
        {
            await client.DeleteAsync($"{uri}/adults/{adult}");
        }
        public async Task UpdateAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/adults/{adult.Id}", content);
        }
    }
}
