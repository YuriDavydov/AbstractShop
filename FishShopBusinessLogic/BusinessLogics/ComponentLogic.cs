using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogics
{
    public class ComponentLogic
    {   /// <summary> При создании объекта, мы должны напрямую указать необходимые поля для его создания  
        /// это прямая зависимость, то есть при измененении объекта, придется править и класс, в котором объявлен  
        /// объект. Но мы можем, получить значение объекта извне. Для этого используем конструктор, и передаем в него, то, что мы 
        /// ожидаем данный объект. И при запуске программы, при таком подходе, программа увидит, что ей необходимо реализация 
        /// интерфейса. Найдет эту реализацию, и передаст в конструктор. И даже если реализация будет постоянно меняться, это не заденет 
        /// работоспособность нашей программы, в отличие от прямой зависимости. </summary>
        private readonly IComponentStorage _componentStorage;
        public ComponentLogic(IComponentStorage componentStorage)
        {
            _componentStorage = componentStorage;
        }

        /// <summary> Темный лес </summary>
        public List<ComponentViewModel> Read(ComponentBindingModel model)
        {
            if (model == null)
            {
                return _componentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ComponentViewModel> { _componentStorage.GetElement(model)
 };
            }
            return _componentStorage.GetFilteredList(model);


        }
        /// <summary> . Если ID у модели есть, то бы обновляем, иначе добавляем  новую </summary>
        public void CreateOrUpdate(ComponentBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _componentStorage.Update(model);
            }
            else
            {
                _componentStorage.Insert(model);
            }
        }
        /// <summary> Удаляем строку из базы данных ComponentStorage </summary>
        public void Delete(ComponentBindingModel model)
        {
            var element = _componentStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _componentStorage.Delete(model);
        }
    }
}


