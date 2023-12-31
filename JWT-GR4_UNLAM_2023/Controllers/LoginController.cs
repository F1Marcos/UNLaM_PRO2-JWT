﻿using Jwt.Constants;
using Jwt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Variable de configuracion para JWT: "_config"
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            // Con este metodo accedemos a la configuracion de JWT en "appsettings.json" y la importamos localmente.
            _config = config;
        }

        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);

            if(user != null)
            {
                // Si el usuario existe entonces crear el token:

                var token = Generate(user);

                return Ok(token);
            } 

            return NotFound("Usuario no encontrado");
        }

        /*
        // Metodo para probar que el backend puede desencriptar el token y acceder a los claims:
        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hola {currentUser.FirstName}, tu tiene rol es de {currentUser.Rol}.");
        }
        */
        
        private UserModel Authenticate(LoginUser userLogin)
        {
            // Buscamos al usuario recibido en las constantes de la carpeta "Constants/UserConstants.cs".
            // Con FirsOrDefault busca elemento por elemnto dentro de la lista "Users" y si hay considencia se carga la variable.
            var currentUser = UserConstants.Users.FirstOrDefault(user => user.Username.ToLower() == userLogin.UserName.ToLower()
                   && user.Password == userLogin.Password);

            if(currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        private string Generate(UserModel user)
        {
            // En este pungo tenemos que tener instalado los paquetes de JWT y importamos:
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // Algoritmo de encriptacion Sha256

            // Crear los claims (reclamaciones), estos son los parametros que se insertan en el PAYLOAD del token:
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
            };


            // Finalmente configuramos el token:

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60), // Expiracion del token.
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); // Creamos y devolvemos el token.
        }

        /*
        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClamis = identity.Claims;
                return new UserModel
                {
                    Username = userClamis.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClamis.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClamis.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClamis.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Rol = userClamis.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
        */
    }
}
