using Jwt.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    // RUTA PUBLICA, no se autentica.
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var listCountry = CountryConstants.Countrys;

            return Ok(listCountry);
        }
    }
}
