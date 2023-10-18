using ListImplement.Models;

namespace ListImplement;

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
    public List<Implementer> Implementers { get; set; }
    
    private DataListSingleton()
    {
        Components = new List<Component>();
        Orders = new List<Order>();
        Products = new List<Product>();
        Implementers = new List<Implementer>();
    }

    public static DataListSingleton GetInstance()
    {
        instance ??= new DataListSingleton();

        return instance;
    }
}
