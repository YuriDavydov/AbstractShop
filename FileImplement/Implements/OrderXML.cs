using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using FileImplement.Models;

namespace FileImplement.Implements;

public class OrderXML : IOrderStorage
{
    private readonly FileDataListSingleton source;
    public OrderXML()
    {
        source = FileDataListSingleton.GetInstance();
    }
    public List<OrderViewModel> GetFullList()
    {
        var res = source.Orders.Select(order => CreateModel(order)).ToList();
        return res;
    }
    public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return source.Orders
        .Where(rec => rec.Id == model.Id || rec.Status == model.Status || rec.DateImplement == model.DateImplement)
       .Select(create => CreateModel(create))
        .ToList();
    }
    public OrderViewModel GetElement(OrderBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        var order = source.Orders.Select(create => CreateModel(create))
        .FirstOrDefault(rec => rec.Id == model.Id || rec.ProductId == model.ProductId);
        return order;
    }
    public void Insert(OrderBindingModel model)
    {
        int maxId = source.Orders.Count > 0 ? source.Components.Max(rec =>
       rec.Id) : 0;
        var element = new Order { Id = maxId + 1 };
        source.Orders.Add(CreateModel(model, element));
    }
    public void Update(OrderBindingModel model)
    {
        var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
        if (element == null)
        {
            throw new Exception("Элемент не найден");
        }
        CreateModel(model, element);
    }
    public void Delete(OrderBindingModel model)
    {
        Component element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
        if (element != null)
        {
            source.Components.Remove(element);
        }
        else
        {
            throw new Exception("Элемент не найден");
        }
    }
    private static Order CreateModel(OrderBindingModel model, Order order)
    {
        order.Id = model.Id;
        order.ProductId = model.ProductId;
        order.Count = model.Count;
        order.Sum = model.Sum;
        order.Status = model.Status;
        order.DateCreate = model.DateCreate;
        order.DateImplement = model.DateImplement;
        return order;
    }
    private static OrderViewModel CreateModel(Order order)
    {
        return new OrderViewModel
        {
            Id = order.Id,
            ProductId = order.ProductId,
            Count = order.Count,
            Sum = order.Sum,
            Status = order.Status,
            DateCreate = order.DateCreate,
            DateImplement = order.DateImplement
        };
    }
}
