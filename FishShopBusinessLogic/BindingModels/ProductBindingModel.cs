namespace BusinessLogic.BindingModels;

public class ProductBindingModel
{   /// <summary> ID консервы </summary>
    public int? Id { get; set; }
    /// <summary> Название консервы </summary>
    public string ProductName { get; set; }
    /// <summary> Цена консервы </summary>
    public decimal Price { get; set; }
    /// <summary> Состав (id ссылающиеся на конкретный состав консервы, (продукт используемый в консерве, его количество)) </summary>
    public Dictionary<int, (string, int)> ProductComponents { get; set; }
}
