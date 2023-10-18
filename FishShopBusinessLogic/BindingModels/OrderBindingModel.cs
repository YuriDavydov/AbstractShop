using BusinessLogic.Enums;

namespace BusinessLogic.BindingModels;

public class OrderBindingModel
{/// <summary> ID заказа </summary>
    public int? Id { get; set; }
    /// <summary> ID консервы </summary>
    public int ProductId { get; set; }
    /// <summary> Количество этой консервы </summary>
    public int Count { get; set; }
    /// <summary> Выручка с заказа </summary>
    public decimal Sum { get; set; }
    /// <summary> Статус готовности заказа </summary>
    public int? ImplementerId { get; set; }
    public OrderStatus Status { get; set; }
    /// <summary> Дата создания заказа </summary>
    public DateTime DateCreate { get; set; }
    /// <summary> Дата когда клиент оплатил и получил товар </summary>
    public DateTime? DateImplement { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public bool? FreeOrders { get; set; }
}
