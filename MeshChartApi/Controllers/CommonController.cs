using ChartLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

//https://localhost:7229/api/Common/token
namespace MeshChart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly IChartRepository _chartRepository;

        public CommonController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpPost("token")]
        public IActionResult ReceiveToken([FromBody] TokenModel tokenModel)
        {
            try
            {
                string decodedUserId = DecodeTokenAndGetUserId(tokenModel.Token);

                var userData = _chartRepository.GetUserDataByUserId(decodedUserId);

                return Ok(new { UserData = userData });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to process the token", Error = ex.Message });
            }
        }



        private string DecodeTokenAndGetUserId(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                var userId = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;

                if (userId != null)
                {
                    return userId;
                }
                else
                {
                    throw new Exception("User id not found in the token.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to decode token.", ex);
            }
        }



    }
}



