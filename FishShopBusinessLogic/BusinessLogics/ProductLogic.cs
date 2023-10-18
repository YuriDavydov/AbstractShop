using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessLogics
{
    public class ProductLogic
    {
        private readonly IProductStorage _productStorage;
        public ProductLogic(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return _productStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _productStorage.GetElement(model) };
            }
            return _productStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ProductBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _productStorage.Update(model);
            }
            else
            {
                _productStorage.Insert(model);
            }
        }
        /// <summary> Удаляем строку из базы данных ComponentStorage </summary>
        public void Delete(ProductBindingModel model)
        {
            var element = _productStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _productStorage.Delete(model);
        }

    }
}
