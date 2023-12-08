using ChartMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ChartMVC.Controllers
{
    public class ChartController : Controller
    {
        private readonly string apiUrl;
        public ChartController(IConfiguration configuration)
        {
            apiUrl = configuration.GetValue<string>("ApiUrl");
        }

        // Call API
        public async Task<List<FeatureDto>> GetChartData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsoncontent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<FeatureDto>>(jsoncontent);
                    }
                    else
                    {
                       response.EnsureSuccessStatusCode();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                 Console.WriteLine($"HttpRequestException: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonException: {ex.Message}");
            }
            catch (Exception ex)
            {
               Console.WriteLine($"Exception: {ex.Message}");
            }

            return new List<FeatureDto>();
        }

        // For BarChart
        public async Task<IActionResult> BarChart()
        {
            try
            {
                List<FeatureDto> chartdata = await GetChartData();

                string serializedata = Newtonsoft.Json.JsonConvert.SerializeObject(chartdata);

                ViewBag.ChartData = serializedata;

                return View();
            }
            catch (Exception ex)
            {
               Console.WriteLine($"BarChart Exception: {ex.Message}");
                
                return View("Error");
            }
        }
    }
}
