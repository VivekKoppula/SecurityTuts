using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebApp.Models;

namespace WebApp.Pages
{
    // [Authorize(Policy = "ConfirmedEnggOnly")]
    public class EnggModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty]
        public List<WeatherForecastDTO> WeatherForecastItems { get; set; } = new List<WeatherForecastDTO>();

        public EnggModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.HttpApiLogicalName);

            if (httpClient == null)
                throw new Exception($"Http Client created is null. Cannot continue." +
                    $"Possibly {Constants.HttpApiLogicalName} did not match with the configuration if httpClientFactory.");

            var res = await httpClient.PostAsJsonAsync("auth", new User { UserName = "admin", Password = "123" });
            res.EnsureSuccessStatusCode();
            var strJwt = await res.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<JwtToken>(strJwt);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token!.AccessToken);

            var weatherForecastDTOs = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("WeatherForecast");

            if (weatherForecastDTOs == null)
                throw new Exception("Data return is null!! Cannot continue..");

            WeatherForecastItems = weatherForecastDTOs!;
        }
    }
}
