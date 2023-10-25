using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using BusinessLogic.HelperModels;
using BusinessLogic.Interfaces;
using DatabaseImplement.Implements;
using DatabaseImplement.Models;
using FileImplement.Implements;
using System.Configuration;
using Unity;
using Unity.Lifetime;

namespace Forms;

static class Program
{
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var container = BuildUnityContainer();
        MailLogic.MailConfig(new MailConfig
        {
            SmtpClientHost = "smtp.gmail.com",
            SmtpClientPort = 587,
            MailLogin = "labwork15kafis@gmail.com",
            MailPassword = "passlab15",
        });
        /*
          
          <?xml version="1.0" encoding="utf-8" ?>
<configuration>
 <add key="SmtpClientHost" value="smtp.gmail.com" />
 <add key="SmtpClientPort" value="587" />
 <add key="PopHost" value="pop.gmail.com" />
 <add key="PopPort" value="995" />
 <add key="MailLogin" value="labwork15kafis@gmail.com" />
 <add key="MailPassword" value="passlab15" />
</configuration>
        */

        /*// создаем таймер

        var timer = new System.Threading.Timer(new TimerCallback(MailCheck), new
     MailCheckInfo
        {
            PopHost = "pop.gmail.com",
            PopPort = 995,
            Storage = new MessageInfoStorage()
        }, 0, 100000); 
        */


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(container.Resolve<FormMain>());


    }
    private static IUnityContainer BuildUnityContainer()
    {
        var currentContainer = new UnityContainer();
        currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<IImplementerStorage, ImplementerStorage>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<IProductStorage, ProductStorage>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<IMessageInfoStorage, MessageInfoStorage>(new HierarchicalLifetimeManager());
        //currentContainer.RegisterType<ClientLogic>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<IImplementerStorage, ImplementerStorage>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<ProductLogic>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<WorkModeling>(new HierarchicalLifetimeManager());
        currentContainer.RegisterType<MailLogic>(new HierarchicalLifetimeManager());
        return currentContainer;
    }
    private static void MailCheck(object obj)
    {
        MailLogic.MailCheck((MailCheckInfo)obj);
    }
}
