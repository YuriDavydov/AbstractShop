using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IProductStorage
    {
        /// <summary> Получить лист всех консервов  </summary>
        List<ProductViewModel> GetFullList();
        /// <summary> Получить отфильтрованный лист всех консервов  </summary>
        List<ProductViewModel> GetFilteredList(ProductBindingModel model);
        /// <summary> Получить конкретную консерву  </summary>
        ProductViewModel GetElement(ProductBindingModel model);
        /// <summary> Добавить консерву  </summary>
        void Insert(ProductBindingModel model);
        /// <summary> Обновить информацию о консерве </summary>
        void Update(ProductBindingModel model);
        /// <summary> Удалить консерву (перестали выпускать)  </summary>
        void Delete(ProductBindingModel model);
    }
}
