using FishShop;
using FishShop.BindingModels;
using FishShop.Enums;
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
    public class OrderDatabase : IOrderStorage
    {
        String connectionString;
        public OrderDatabase()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=database;Integrated Security=True;";
        }
        public void Delete(OrderBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"DELETE FROM Order WHERE Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            OrderViewModel result = new OrderViewModel();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"SELECT TOP(1) * FROM Order WHERE product_Id = {model.ProductId}%' OR Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.Count = reader.GetInt32(1);
                        result.Sum = reader.GetInt32(2);
                        OrderStatus status;
                        Enum.TryParse(reader.GetString(3), out status);
                        result.Status = status;
                        result.DateCreate = reader.GetDateTime(4);
                        result.DateImplement = reader.GetDateTime(5);
                        result.ProductId = reader.GetInt32(6);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"SELECT * FROM Order WHERE product_Id = %{model.ProductId}%'";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderViewModel res = new OrderViewModel();
                        res.Id = reader.GetInt32(0);
                        res.Count = reader.GetInt32(1);
                        res.Sum = reader.GetInt32(2);
                        OrderStatus status;
                        Enum.TryParse(reader.GetString(3), out status);
                        res.Status = status;
                        res.DateCreate = reader.GetDateTime(4);
                        res.DateImplement = reader.GetDateTime(5);
                        res.ProductId = reader.GetInt32(6);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return result;
        }

        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM Order";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderViewModel res = new OrderViewModel();
                        res.Id = reader.GetInt32(0);
                        res.Count = reader.GetInt32(1);
                        res.Sum = reader.GetInt32(2);
                        OrderStatus status;
                        Enum.TryParse(reader.GetString(3), out status);
                        res.Status = status;
                        res.DateCreate = reader.GetDateTime(4);
                        res.DateImplement = reader.GetDateTime(5);
                        res.ProductId = reader.GetInt32(6);
                        result.Add(res);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return result;
        }
        //
        public void Insert(OrderBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"INSERT INTO Order (product_Id) values (N'{model.ProductId}')";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"UPDATE Order SET product_Id = '{model.ProductId}' WHERE Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
