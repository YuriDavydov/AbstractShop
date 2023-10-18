using FishShop;
using FishShop.BindingModels;
using FishShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopListImplement.Implements
{
    public class ComponentDatabase : IComponentStorage
    {
        public ComponentDatabase()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=database;Integrated Security=True;";
        }
        String connectionString;
        public void Delete(ComponentBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"DELETE FROM Component WHERE Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            ComponentViewModel result = new ComponentViewModel();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"SELECT TOP(1) * FROM Component WHERE component_name LIKE N'%{model.Name}%' OR Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt32(0);
                        result.ComponentName = reader.GetString(1);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return result;
        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"SELECT * FROM Component WHERE component_name LIKE N'%{model.Name}%'";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ComponentViewModel res = new ComponentViewModel();
                        res.Id = reader.GetInt32(0);
                        res.ComponentName = reader.GetString(1);
                        result.Add(res);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return result;
        }

        public List<ComponentViewModel> GetFullList()
        {
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = "SELECT * FROM Component";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ComponentViewModel res = new ComponentViewModel();
                        res.Id = reader.GetInt32(0);
                        res.ComponentName = reader.GetString(1);
                        result.Add(res);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return result;
        }

        public void Insert(ComponentBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"INSERT INTO Component (component_name) values (N'{model.Name}')";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(ComponentBindingModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String query = $"UPDATE Component SET component_name = N'{model.Name}' WHERE Id = {model.Id}";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
