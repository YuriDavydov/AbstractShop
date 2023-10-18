using FishShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopListImplement
{
    class DataListSingleton
    {
        /// <summary>
        /// Синглтон позволяет убедиться, что экземпляр класса будет только один. 
        /// Внутри наша база данных(она должна быть одна, поэтому синглтон)листы компонентов, 
        /// заказов и продуктов
        /// </summary>
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Products = new List<Product>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
