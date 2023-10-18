using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class ProductStorage : IProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Products
                .Include(rec => rec.ProductComponents)
               .ThenInclude(rec => rec.Component)
               .ToList()
               .Select(rec => new ProductViewModel
               {
                   Id = rec.Id,
                   ProductName = rec.ProductName,
                   Price = rec.Price,
                   ProductComponents = rec.ProductComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                return context.Products
                .Include(rec => rec.ProductComponents)
               .ThenInclude(rec => rec.Component)
               .Where(rec => rec.ProductName.Contains(model.ProductName))
               .ToList()
               .Select(rec => new ProductViewModel
               {
                   Id = rec.Id,
                   ProductName = rec.ProductName,
                   Price = rec.Price,
                   ProductComponents = rec.ProductComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
.ToList();
            }
        }
        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                var product = context.Products
                .Include(rec => rec.ProductComponents)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.ProductName == model.ProductName || rec.Id
               == model.Id);
                return product != null ?
                new ProductViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    ProductComponents = product.ProductComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } :
               null;
            }
        }
        /*
         *  {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.ProductComponents.Where(rec =>
               rec.ProductId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ProductComponents.RemoveRange(productComponents.Where(rec =>
               !model.ProductComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                   model.ProductComponents[updateComponent.ComponentId].Item2;
                    model.ProductComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.ProductComponents)
            {
                context.ProductComponents.Add(new ProductComponent
                {
                    ProductId = product.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return product;
        }
         */
        public void Insert(ProductBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var productComponents = new List<ProductComponent>();
                        foreach (var pc in model.ProductComponents)
                        {
                            productComponents.Add(new ProductComponent
                            {
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                        }
                        var product = new Product();
                        product.ProductName = model.ProductName;
                        product.Price = model.Price;
                        product.ProductComponents = productComponents;
                        context.Products.Add(product);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(ProductBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Products.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ProductBindingModel model)
        {
            using (var context = new Database())
            {
                Product element = context.Products.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Products.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Product CreateModel(ProductBindingModel model, Product product,
       Database context)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.ProductComponents.Where(rec =>
               rec.ProductId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ProductComponents.RemoveRange(productComponents.Where(rec =>
               !model.ProductComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                   model.ProductComponents[updateComponent.ComponentId].Item2;
                    model.ProductComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.ProductComponents)
            {
                context.ProductComponents.Add(new ProductComponent
                {
                    ProductId = product.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return product;
        }

    }
    }
