using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using FileImplement.Models;

namespace FileImplement.Implements;

public class ComponentXML : IComponentStorage
{
    private readonly FileDataListSingleton source;

    public ComponentXML()
    {
        source = FileDataListSingleton.GetInstance();
    }

    public List<ComponentViewModel> GetFullList()
    {
        return source.Components.Select(component => CreateModel(component)).ToList();
    }

    public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return source.Components
        .Where(rec => rec.ComponentName.Contains(model.Name))
       .Select(create => CreateModel(create))
        .ToList();
    }
    public ComponentViewModel GetElement(ComponentBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        var component = source.Components.Select(create => CreateModel(create))
        .FirstOrDefault(rec => rec.Id == model.Id || rec.ComponentName == model.Name);
        return component;
    }
    public void Insert(ComponentBindingModel model)
    {
        int maxId = source.Components.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
        var element = new Component { Id = maxId + 1 };
        source.Components.Add(CreateModel(model, element));
    }
    public void Update(ComponentBindingModel model)
    {
        var element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);

        if (element is null)
        {
            throw new Exception("Элемент не найден");
        }

        CreateModel(model, element);
    }

    public void Delete(ComponentBindingModel model)
    {
        Component? element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);

        if (element is null)
        {
            throw new Exception("Элемент не найден");
        }

        source.Components.Remove(element);
    }
    // по умолчанию будет id из-за ComponentBindingModel. Он есть источник
    private static Component CreateModel(ComponentBindingModel model, Component component)
    {
        component.ComponentName = model.Name;
        return component;
    }

    private static ComponentViewModel CreateModel(Component component)
    {
        return new ComponentViewModel
        {
            Id = component.Id,
            ComponentName = component.ComponentName
        };
    }
}
