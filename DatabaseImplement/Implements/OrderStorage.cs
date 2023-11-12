using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplement.Models;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Orders
                .Include(rec => rec.Product)
                .Include(rec1 => rec1.Implementer)
            .Select(rec => new OrderViewModel
            {
                /*
                 * public int? Id { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Изделие")]
        public string ProductName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
                 */
                Id = rec.Id,
                ProductId = rec.ProductId,
                ProductName = rec.Product.ProductName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                IdImplementer = rec.ImplementerId.HasValue ? rec.ImplementerId.Value : 0,
                Implementer = rec.Implementer.ImplementerFIO
                
                
            })
    .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                return context.Orders
                    .Include(rec => rec.Product)
                .Where(rec => rec.ProductId == model.ProductId || rec.Status == model.Status || rec.DateImplement == model.DateImplement)
               .Select(rec => new OrderViewModel
               {
                   Id = rec.Id,
                   ProductId = rec.ProductId,
                   ProductName = rec.Product.ProductName,
                   Count = rec.Count,
                   Sum = rec.Sum,
                   Status = rec.Status,
                   DateCreate = rec.DateCreate,
                   DateImplement = rec.DateImplement,
                   IdImplementer = rec.ImplementerId.HasValue ? rec.ImplementerId.Value : 0,
                   Implementer = rec.Implementer.ImplementerFIO
               })
                .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                var order = context.Orders
                    .Include(order => order.Product)
                    .Select(order => new OrderViewModel
                    {
                        Id = order.Id,
                        ProductId = order.ProductId,
                        ProductName = order.Product.ProductName,
                        Count = order.Count,
                        Sum = order.Sum,
                        Status = order.Status,
                        DateCreate = order.DateCreate,
                        DateImplement = order.DateImplement,
                        IdImplementer = order.ImplementerId.HasValue ? order.ImplementerId.Value : 0,
                        Implementer = order.Implementer.ImplementerFIO
                    })
                .FirstOrDefault(rec => rec.ProductId == model.ProductId ||
               rec.Id == model.Id);
                return order;
                    }
        }
        public void Insert(OrderBindingModel model)
        {

            var options = new DbContextOptionsBuilder<Database>().LogTo(Log).EnableSensitiveDataLogging().Options;
            using (var context = new Database(options))
            {
                
                Order res = CreateModel(model, new Order());
                context.Orders.Add(res);
                try
                {
                    
                    context.SaveChanges();
                }
                catch (Exception e) 
                {
                    throw e;
                }
            }
        }
        public void Log(string massage) 
        {
            StreamWriter log = new StreamWriter("D:\\CLogs\\Log.txt", true);
            log.WriteLine(massage);
            log.Close();
            log.Dispose();


 
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new Database())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new Database())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            /*
             * public int Id { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
    public decimal Sum { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime? DateImplement { get; set; }
    public virtual Product Product { get; set; } 
             */
            order.ProductId = model.ProductId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ImplementerId = model.ImplementerId.HasValue ? model.ImplementerId.Value : null;

            
            return order;
        }
    }
}
