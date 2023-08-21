using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.WebSockets;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("John's New Department");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var depratment in departments)
            {
                Console.WriteLine(depratment.DepartmentID);
                Console.WriteLine(depratment.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion



            var productRepo = new DapperProductRepository(conn);

            //productRepo.CreateProduct("Surface", 900, 1);


            //var productToUpdate = productRepo.GetProduct(941);

            //productToUpdate.Name = "UPDATED!";
            //productToUpdate.Price = 555;
            //productToUpdate.CategoryID = 2;
            //productToUpdate.OnSale = true;
            //productToUpdate.StockLevel = 72;

            //productRepo.UpdateProduct(productToUpdate);

            //productRepo.DeleteProduct(941);


            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
