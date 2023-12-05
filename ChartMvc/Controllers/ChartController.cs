using ChartMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChartMvc.Controllers
{
    public class ChartController : Controller
    {

        public ActionResult Index(List<DTOChart> userData)
        {
            string jsonChartData = System.Text.Json.JsonSerializer.Serialize(userData);
            ViewBag.JsonChartData = jsonChartData;

            return View(userData);
        }
    }

}
