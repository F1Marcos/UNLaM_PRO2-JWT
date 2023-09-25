using Jwt.Models;

namespace Jwt.Constants
{
    public class CountryConstants
    {
        // No usamos base de datos, en su lugar hardcodeamos constantes de paises.
        public static List<CountryModel> Countrys = new List<CountryModel>()
        {
            new CountryModel() { Name = "Argentina"},
            new CountryModel() { Name = "Bolivia"},
            new CountryModel() { Name = "Peru"},
            new CountryModel() { Name = "Mexico"},
        };
    }
}
