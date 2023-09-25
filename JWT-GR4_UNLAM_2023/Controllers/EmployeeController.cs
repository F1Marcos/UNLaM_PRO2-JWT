using Jwt.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    // RUTA privada, solo usuarios autenticados y con Rol de Administrador.
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = ("Administrador"))]  // -------->>>> Seteamos el controlador para que autentique via token.
        public IActionResult Get()
        {
            // var listEmployee = EmployeeConstants.Employees;
            var listEmployee = UserConstants.Users;

            return Ok(listEmployee);
        }
    }
}
