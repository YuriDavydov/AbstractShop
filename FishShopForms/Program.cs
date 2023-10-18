using FishShop.BusinessLogics;
using FishShop.Interfaces;
using FishShopFileImplement.Implements;
using FishShopListImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace FishShopForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentXML>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderXML>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductXML>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
