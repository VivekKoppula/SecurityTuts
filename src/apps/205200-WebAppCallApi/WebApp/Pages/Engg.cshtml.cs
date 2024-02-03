using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages
{
    [Authorize(Policy = "ConfirmedEnggOnly")]
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

            List<WeatherForecastDTO>? weatherForecastDTOs = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("WeatherForecast");

            if (weatherForecastDTOs == null)
                throw new Exception("Data return is null!! Cannot continue..");

            WeatherForecastItems = weatherForecastDTOs!;
        }
    }
}
