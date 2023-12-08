using ChartDAL.DataModels;
using ChartDAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        IRepository<Feature> repository;
        public CommonController(IRepository<Feature> repository)
        {
            this.repository = repository;
        }


        //GetAllData
        [HttpGet]
        public IActionResult GetAllFeatures()
        {
            try
            {
                var features = repository.GetAll();
                return Ok(features);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetAllFeatures: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }

        //UserID
        [HttpGet("UserId")]
        public IActionResult GetDataUserId(string userid)
        {
            try
            {
                var data = repository.GetById(userid);

                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound($"Data not found for UserId: {userid}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetDataUserId: {ex.Message}");

                return StatusCode(500, "Internal Server Error");
            }
        }




    }
}