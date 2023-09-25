using Jwt.Models;

namespace Jwt.Constants
{
    public class EmployeeConstants
    {
        // No usamos base de datos, en su lugar hardcodeamos constantes de empleados.
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
            new EmployeeModel() {FirstName = "Marcos", LastName = "Quispe", Email = "mquispe@gmail.com" },
            new EmployeeModel() {FirstName = "Gustavo", LastName = "Zurita", Email = "gzurita@gmail.com" },
            new EmployeeModel() {FirstName = "Nicolas", LastName = "Lopiano", Email = "nlopiano@gmail.com" },
            new EmployeeModel() {FirstName = "Veronica", LastName = "Parra", Email = "vparra@gmail.com" },
        };
    }
}
