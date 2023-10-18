using BusinessLogic.Enums;
using FileImplement.Models;
using System.Xml.Linq;

namespace FileImplement;

class FileDataListSingleton
{
    private static FileDataListSingleton instance;
    private readonly string ComponentFileName = "Component.xml";
    private readonly string OrderFileName = "Order.xml";
    private readonly string ProductFileName = "Product.xml";
    private readonly string ImplementerFileName = "Implamenter.xml";
    public List<Component> Components { get; set; }
    public List<Order> Orders { get; set; }
    public List<Product> Products { get; set; }
    public List<Implementer> Implementers { get; set; }
    private FileDataListSingleton()
    {
        Components = LoadComponents();
        Orders = LoadOrders();
        Products = LoadProducts();
    }
    public static FileDataListSingleton GetInstance()
    {
        if (instance == null)
        {
            instance = new FileDataListSingleton();
        }
        return instance;
    }
    ~FileDataListSingleton()
    {
        SaveComponents();
        SaveOrders();
        SaveProducts();
    }
    /// <summary>
    /// Если файл существует, то создаем xDocument, который предназначен для работы с xml-файлами
    /// </summary>
    /// <returns></returns>
    private List<Component> LoadComponents()
    {
        var list = new List<Component>();
        if (File.Exists(ComponentFileName))
        {
            XDocument xDocument = XDocument.Load(ComponentFileName);
            var xElements = xDocument.Root.Elements("Component").ToList();
            foreach (var elem in xElements)
            {
                list.Add(new Component
                {
                    Id = Convert.ToInt32(elem.Attribute("Id").Value),
                    ComponentName = elem.Element("ComponentName").Value
                });
            }
        }
        return list;
    }
    private List<Order> LoadOrders()
    {
        var list = new List<Order>();
        if (File.Exists(OrderFileName))
        {
            XDocument xDocument = XDocument.Load(OrderFileName);
            var xElements = xDocument.Root.Elements("Order").ToList();
            foreach (var elem in xElements)
            {
                list.Add(new Order
                {
                    Id = Convert.ToInt32(elem.Attribute("Id").Value),
                    ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                    Count = Convert.ToInt32(elem.Element("Count").Value),
                    Sum = Convert.ToInt32(elem.Element("Sum").Value),
                    Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                    DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                    DateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value)
                });
            }
        }
        return list;
    }
    private List<Product> LoadProducts()
    {
        var list = new List<Product>();
        if (File.Exists(ProductFileName))
        {
            XDocument xDocument = XDocument.Load(ProductFileName);
            var xElements = xDocument.Root.Elements("Product").ToList();
            foreach (var elem in xElements)
            {
                var prodComp = new Dictionary<int, int>();
                foreach (var component in
               elem.Element("ProductComponents").Elements("ProductComponent").ToList())
                {
                    prodComp.Add(Convert.ToInt32(component.Element("Key").Value),
                   Convert.ToInt32(component.Element("Value").Value));
                }
                list.Add(new Product
                {
                    Id = Convert.ToInt32(elem.Attribute("Id").Value),
                    ProductName = elem.Element("ProductName").Value,
                    Price = Convert.ToDecimal(elem.Element("Price").Value),
                    ProductComponents = prodComp
                });
            }
        }
        return list;
    }
    private void SaveComponents()
    {
        if (Components != null)
        {
            var xElement = new XElement("Components");
            foreach (var component in Components)
            {
                xElement.Add(new XElement("Component",
                new XAttribute("Id", component.Id),
                new XElement("ComponentName", component.ComponentName)));
            }
            XDocument xDocument = new XDocument(xElement);
            xDocument.Save(ComponentFileName);
        }
    }
    private void SaveOrders()
    {
        if (Orders != null)
        {
            var xElement = new XElement("Orders");
            foreach (var order in Orders)
            {
                xElement.Add(new XElement("Order",
                new XAttribute(nameof(order.Id), order.Id),
                new XElement(nameof(order.ProductId), order.ProductId),
                new XElement(nameof(order.Count), order.Count),
                new XElement(nameof(order.Sum), order.Sum),
                new XElement(nameof(order.Status), order.Status),
                new XElement(nameof(order.DateCreate), order.DateCreate),
                new XElement(nameof(order.DateImplement), order.DateImplement)));
            }
            XDocument xDocument = new XDocument(xElement);
            xDocument.Save(ComponentFileName);
        }
    }
    private void SaveProducts()
    {
        if (Products != null)
        {
            var xElement = new XElement("Products");
            foreach (var product in Products)
            {
                var compElement = new XElement("ProductComponents");
                foreach (var component in product.ProductComponents)
                {
                    compElement.Add(new XElement("ProductComponent",
                    new XElement("Key", component.Key),
                    new XElement("Value", component.Value)));
                }
                xElement.Add(new XElement("Product",
                 new XAttribute("Id", product.Id),
                 new XElement("ProductName", product.ProductName),
                 new XElement("Price", product.Price),
                 compElement));
            }
            XDocument xDocument = new XDocument(xElement);
            xDocument.Save(ProductFileName);
        }
    }
    private void SaveImplementers()
    {
        if (Implementers != null)
        {
            var xElement = new XElement("Implementers");
            foreach (var implemener in Implementers)
            {
                xElement.Add(new XElement("Implementer",
                new XAttribute("Id", implemener.Id),
                new XElement("FIO", implemener.ImplementerFIO),
                new XElement("WorkingTime", implemener.WorkingTime),
                new XElement("PauseTime", implemener.PauseTime)));
            }
            XDocument xDocument = new XDocument(xElement);
            xDocument.Save(ImplementerFileName);
        }
    }
    private List<Implementer> LoadImplementers()
    {
        var list = new List<Implementer>();
        if (File.Exists(ImplementerFileName))
        {
            XDocument xDocument = XDocument.Load(ImplementerFileName);
            var xElements = xDocument.Root.Elements("Implementers").ToList();
            foreach (var elem in xElements)
            {
                list.Add(new Implementer
                {
                    Id = Convert.ToInt32(elem.Attribute("Id").Value),
                    ImplementerFIO = elem.Element("FIO").Value,
                    WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                    PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                });
            }
        }
        return list;
    }
}
