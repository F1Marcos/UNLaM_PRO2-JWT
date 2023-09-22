using Jwt.Models;

namespace Jwt.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "mquispe", Password = "admin123", Rol = "Administrador", EmailAddress = "mquispe@gmail.com", FirstName = "Juan", LastName = "Perez"},
            new UserModel() { Username = "gzurita", Password = "admin123", Rol = "Administrador", EmailAddress = "gzurita@gmail.com", FirstName = "Juan", LastName = "Perez"},
            new UserModel() { Username = "nlopiano", Password = "admin123", Rol = "Administrador", EmailAddress = "nlopiano@gmail.com", FirstName = "Juan", LastName = "Perez"},
            new UserModel() { Username = "vparra", Password = "admin123", Rol = "Administrador", EmailAddress = "vparra@gmail.com", FirstName = "Juan", LastName = "Perez"},
            new UserModel() { Username = "jperez", Password = "admin123", Rol = "Administrador", EmailAddress = "jperez@gmail.com", FirstName = "Juan", LastName = "Perez"},
            new UserModel() { Username = "mgonzalez", Password = "admin123", Rol = "Vendedor", EmailAddress = "mgonzalez@gmail.com", FirstName = "Maria", LastName = "Gonzalez"},
        };
    }
}
