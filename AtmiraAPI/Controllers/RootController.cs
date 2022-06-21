using Microsoft.AspNetCore.Mvc;

namespace AtmiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootController : Controller
    {
        private readonly IConfiguration _configuration;
        public RootController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/planetName{planetName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetListAsteroid(string planetName)
        {
            try
            {
                var baseUrl = _configuration.GetSection("ApiSettings:baseUrl").Value;
                var token = _configuration.GetSection("ApiSettings:token").Value;
                var dataPath = baseUrl.Replace("DEMO_KEY", token);

                var asteroids = await DataHelper.DataHelper.GetDangerousAsteroid(dataPath, planetName);
                if (asteroids?.Count == 0 || asteroids == null)
                {
                    return NotFound("No dangerous asteroids near '" + planetName + "'");
                }
                else
                {
                    return Ok(asteroids);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error. Problem querying asteroids (" + ex.Message + ")");
            }
        }
    }
}
