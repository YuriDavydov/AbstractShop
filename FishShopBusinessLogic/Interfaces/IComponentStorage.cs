using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{   /// <summary>
    /// Интерфест для получения компонента из базы данных
    /// </summary>
    public interface IComponentStorage
    {
        /// <summary> Получить лист всех компонентов  </summary>
        List<ComponentViewModel> GetFullList();
        /// <summary> Получить отфильтрованный лист всех компонентов  </summary>
        List<ComponentViewModel> GetFilteredList(ComponentBindingModel model);
        /// <summary> Получить конкретный компонент  </summary>
        ComponentViewModel GetElement(ComponentBindingModel model);
        /// <summary> Добавить компонент  </summary>
        void Insert(ComponentBindingModel model);
        /// <summary> Обновить компонент  </summary>
        void Update(ComponentBindingModel model);
        /// <summary> Удалить компонент  </summary>
        void Delete(ComponentBindingModel model);
    }
}
