using Jwt.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    // RUTA privada, solo usuarios autenticados.
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        [Authorize] // -------->>>> Seteamos el controlador para que autentique via token.
        public IActionResult Get()
        {
            var listProduct = ProductConstants.Products;

            return Ok(listProduct);
        }
    }
}
