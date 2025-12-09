using Projekt.DataHandling;
using System.Net.Http.Json;
namespace Projekt.Services
{
    public static class SupplementApiService
    {
        private static readonly HttpClient client = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(10)
        };


        private const string API_URL =
    "https://world.openfoodfacts.net/cgi/search.pl?json=1&search_terms=";



        public static async Task<List<Suplement>> SearchAsync(string query)
        {
            try
            {
                string url = API_URL + Uri.EscapeDataString(query);
                var result = await client.GetFromJsonAsync<List<Suplement>>(url);

                return result ?? new List<Suplement>();
            }
            catch
            {
                return new List<Suplement>();
            }
        }
    }
}
