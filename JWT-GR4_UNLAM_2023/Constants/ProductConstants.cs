using Jwt.Models;

namespace Jwt.Constants
{
    public class ProductConstants
    {

        // No usamos base de datos, en su lugar hardcodeamos constantes de productos.
        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() { Name = "Coca Cola", Description = "Bebida con gas" },
            new ProductModel() { Name = "Agua Villavicencio", Description = "Agua mineral de 2L" },
        };
    }
}
