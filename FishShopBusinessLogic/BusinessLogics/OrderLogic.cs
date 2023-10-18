using BusinessLogic.BindingModels;
using BusinessLogic.Enums;
using BusinessLogic.HelperModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BusinessLogic.BusinessLogics
{    /// <summary> Темный лес </summary>
    public class OrderLogic
    {
        private readonly object locker = new object();
        private readonly IOrderStorage _orderStorage;
        private MailLogic logic;
        public OrderLogic(IOrderStorage orderStorage, MailLogic logic)
        {
            _orderStorage = orderStorage;
//            this.logic = logic; 
        }
        /// <summary> Если модель не существует, то возвращается полный лист заказов, если заказ имеет id возвращается
        ///  конкретный заказ, если ни то, ни другое отфильтрованный лист(Если заказ не найден по id, то выдается список 
        ///  отфильтрофанный по другим полям этого заказа (Количетсво, сумма, id продукта))</summary>
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        /// <summary>Создание заказа</summary>
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                ProductId = model.ProductId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Created
            });
        }

        public void TakeOrderInAccept(ChangeStatusBindingModel model) 
        {
            ChangeStatus(model, OrderStatus.Accepted);
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                ChangeStatus(model, OrderStatus.InProgress);
            }
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            ChangeStatus(model, OrderStatus.Finish);
            MailSendInfo info = new MailSendInfo { MailAddress = "test@mail.ru", Subject = "Заголовок", Text = "Текст" };
            MailLogic.MailSendAsync(info);
        }
        /// <summary>Смена статуса заказа. Передаем модель, и статус заказа на который хотим сменить.</summary>
        public void ChangeStatus(ChangeStatusBindingModel model, OrderStatus status, bool finished = false)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel
            {
                Id =
           model.OrderId
            });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            /// Сюда попадем, если хотим поменять статус на InProgress, он должен быть в принятых, и статус из параметров должен быть InProgress
            if (order.Status != OrderStatus.Accepted && status == OrderStatus.InProgress)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            /// Сюда попадем, если хотим поменять статус на Finish, он должен быть в процессе, и статус из параметров должен быть Finish
            if (order.Status != OrderStatus.InProgress && status == OrderStatus.Finish)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            var dateImplement = finished ? DateTime.Now : order.DateImplement;
                _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = dateImplement,
                Status = status
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            ChangeStatus(model, OrderStatus.Paid, true);
            MailSendInfo info = new MailSendInfo{ MailAddress = "test@mail.ru", Subject = "Заголовок", Text = "Текст" };
            MailLogic.MailSendAsync(info);
        }

    }
}
