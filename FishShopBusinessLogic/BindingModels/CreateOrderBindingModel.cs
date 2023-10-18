namespace BusinessLogic.BindingModels;

public class CreateOrderBindingModel
{
    /// <summary> ID продукта которое указывает клиент </summary>
    public int ProductId { get; set; }
    /// <summary> количество этого продукта , что указывает клиент </summary>
    public int Count { get; set; }
    /// <summary>Сумма заказа</summary>
    public decimal Sum { get; set; }
}
