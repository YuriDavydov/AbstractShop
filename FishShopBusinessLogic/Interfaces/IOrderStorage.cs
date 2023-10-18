using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IOrderStorage
    {
        /// <summary> Получить лист всех заказов  </summary>
        List<OrderViewModel> GetFullList();
        /// <summary> Получить отфильтрованный лист всех заказов  </summary>
        List<OrderViewModel> GetFilteredList(OrderBindingModel model);
        /// <summary> Получить конкретный заказ  </summary>
        OrderViewModel GetElement(OrderBindingModel model);
        /// <summary> Добавить заказ  </summary>
        void Insert(OrderBindingModel model);
        /// <summary> Обновить информацию в заказе  </summary>
        void Update(OrderBindingModel model);
        /// <summary> Удалить заказ (при его выполнении)  </summary>
        void Delete(OrderBindingModel model);
    }
}
