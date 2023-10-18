namespace BusinessLogic.BindingModels;

public class ChangeStatusBindingModel
{   /// <summary> Изменение статуса заказа </summary>
    public int OrderId { get; set; }
    public int? ImplementerId { get; set; }

}
