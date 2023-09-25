namespace Jwt.Models
{
    // Clase tipo DTO (data transfers object) para acceder a los datos en la carpeta Constants.
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Rol { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
