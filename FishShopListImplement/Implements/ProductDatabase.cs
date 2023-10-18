using FishShop.BindingModels;
using FishShop.Interfaces;
using FishShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopListImplement.Implements
{
    public class ProductDatabase : IProductStorage
    {
        public ProductDatabase()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=database;Integrated Security=True;";
        }
        String connectionString;

        public List<ProductViewModel> GetFullList()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM Product";
                ProductViewModel res = new ProductViewModel();
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        res.Id = reader.GetInt32(0);
                        res.ProductName = reader.GetString(1);
                        res.Price = reader.GetInt32(2);
                        result.Add(res);
                    }
                    reader.Close();
                }
                foreach (var resultItem in result) { 
                String queryProductComponent = $"SELECT * FROM ProductComponent WHERE product_id = {resultItem.Id}";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            res.ProductComponents.Add(reader.GetInt32(1), (reader.GetString(2), reader.GetInt32(3)));
                        }
                        reader.Close();
                    }
                }
                connection.Close();

            }
            return result;
        }

        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ProductViewModel> result = new List<ProductViewModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"SELECT * FROM Product WHERE product_name LIKE N'%{model.ProductName}%'";
                ProductViewModel res = new ProductViewModel();
                res.ProductComponents = new Dictionary<int, (string, int)>();
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        res.Id = reader.GetInt32(0);
                        res.ProductName = reader.GetString(1);
                        res.Price = reader.GetInt32(2);
                    }
                    reader.Close();
                }
                foreach (var productItem in result)
                {
                    String queryProductComponent = $"SELECT * FROM ProductComponent WHERE product_id = {productItem.Id}";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            res.ProductComponents.Add(reader.GetInt32(1), (reader.GetString(2), reader.GetInt32(3)));
                        }
                        reader.Close();
                    }
                }
                result.Add(res);

                connection.Close();
            }
            return result;
        }

        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            ProductViewModel result = new ProductViewModel();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"SELECT TOP(1) * FROM Product WHERE Id = {model.Id} OR product_name LIKE N'%{model.ProductName}%'";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.ProductName = reader.GetString(1);
                        result.Price = reader.GetInt32(2); 
                    }
                    reader.Close();
                }
                String queryProductComponent = $"SELECT * FROM ProductComponent WHERE product_id = {result.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.ProductComponents.Add(reader.GetInt32(1), (reader.GetString(2), reader.GetInt32(3)));
                    }
                    reader.Close();
                }
                connection.Close();

            }
            return result;
        }

        public void Insert(ProductBindingModel model)
        /*
         *  {
        product.ProductName = model.ProductName;
        product.Price = model.Price;
        // удаляем убранные
        foreach (var key in product.ProductComponents.Keys.ToList())
        {
            if (!model.ProductComponents.ContainsKey(key))
            {
                product.ProductComponents.Remove(key);
            }
        }
        // обновляем существуюущие и добавляем новые
        foreach (var component in model.ProductComponents)
        {
            if (product.ProductComponents.ContainsKey(component.Key))
            {
                product.ProductComponents[component.Key] =
                model.ProductComponents[component.Key].Item2;
            }
            else
            {
                product.ProductComponents.Add(component.Key,
                model.ProductComponents[component.Key].Item2);
            }
        }
        return product;
    }
         */
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"INSERT INTO Product (product_name, price) values (N'{model.ProductName}', {model.Price})";
                // 	   query	"INSERT INTO Product (product_name, price) values (N'тест', 1)"	string

                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                //String queryProductComponent = $"INSERT INTO ProductComponent WHERE Id = {model.Id}')";
                String queryMaxId = $"SELECT MAX(Id) FROM Product";
                // 	   queryMaxId	"SELECT MAX(Id) FROM Product"	string

                int id = 0;
                using (var command = new SqlCommand(queryMaxId, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);   
                    }
                    reader.Close();
                }
                    String queryProductComponents = $" INSERT INTO ProductComponent ([component_id], [quantity], [product_id]) values ";
                //	queryProductComponents	" INSERT INTO ProductComponent (key,count, product_id) values (2, 1,1002),"	string

                foreach (var itemProductComponents in model.ProductComponents)
                {
                    queryProductComponents += $"({itemProductComponents.Key},{itemProductComponents.Value.Item2},{id}),";
                }
                queryProductComponents = queryProductComponents.Remove(queryProductComponents.Length - 1, 1);
                using (var command = new SqlCommand(queryProductComponents, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(ProductBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"UPDATE Product SET product_name = N'{model.ProductName}' WHERE Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Delete(ProductBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"DELETE FROM Product WHERE Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
