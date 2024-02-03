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
        public List<WeatherForecastDTO>? WeatherForecastItems { get; set; } = new List<WeatherForecastDTO>();

        public EnggModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            WeatherForecastItems = await InvokeEndPoint<List<WeatherForecastDTO>>(Constants.HttpApiLogicalName, "WeatherForecast")!;
        }

        private async Task<T?> InvokeEndPoint<T>(string clientName, string url)
        {
            // get token from session
            JwtToken token = null!;

            var strTokenObj = HttpContext.Session.GetString("access_token");
            if (string.IsNullOrWhiteSpace(strTokenObj))
                token = await Authenticate();
            else
                token = JsonConvert.DeserializeObject<JwtToken>(strTokenObj)!;

            if (token == null ||
                string.IsNullOrWhiteSpace(token.AccessToken) ||
                token.ExpiresAt <= DateTime.UtcNow)
                token = await Authenticate();

            var httpClient = _httpClientFactory.CreateClient(clientName);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            return await httpClient.GetFromJsonAsync<T>(url);
        }

        private async Task<JwtToken> Authenticate()
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.HttpApiLogicalName);
            var res = await httpClient.PostAsJsonAsync("auth", new User { UserName = "admin", Password = "123" });
            res.EnsureSuccessStatusCode();
            var strJwt = await res.Content.ReadAsStringAsync();
            HttpContext.Session.SetString("access_token", strJwt);

            return JsonConvert.DeserializeObject<JwtToken>(strJwt)!;
        }
    }
}
