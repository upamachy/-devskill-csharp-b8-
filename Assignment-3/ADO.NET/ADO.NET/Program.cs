using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server = .\\SQLEXPRESS; Database = ADO.NET; User Id = sa; Password = upama1234;";
            var productsQuery = "select * from products";
            var products = GetProducts(connectionString, productsQuery);
            foreach (var product in products)
            {
                Console.WriteLine($"product Number-{product.Id}  Name - {product.Title} is available - {product.IsAvailable} creating Date - {product.CreatedOn} and Quantity - {product.AvailableQuantity}");

            }
        }
            public static List<Product> GetProducts(string connectionString, string sql)
            {
                using SqlCommand command = new SqlCommand();
                command.Connection = BuildConnection(connectionString);
                command.CommandText = sql;
                var reader = command.ExecuteReader();

                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    var id = (int)reader[0];
                    var title = (string)reader[1];
                    var price = (decimal)reader[2];
                    var isAvailable = (bool)reader[3];
                    var createdOn = (DateTime)reader[4];
                    var availableQuantity = (int)reader[5];

                    products.Add(new Product
                    {
                        Id = id,
                        Title = title,
                        IsAvailable = isAvailable,
                        CreatedOn = createdOn,
                        AvailableQuantity = availableQuantity
                    });

                }
                return products;
            }
            public static SqlConnection BuildConnection(string sqlConnection)
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = sqlConnection;
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return connection;
            }

        
    }

    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
