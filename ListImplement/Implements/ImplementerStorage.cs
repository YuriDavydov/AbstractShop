using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using ListImplement.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        private readonly DataListSingleton source;


        public ImplementerStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        void IImplementerStorage.Delete(int id)
        {
            for (int i = 0; i < source.Implementers.Count; ++i)
            {
                if (source.Implementers[i].Id == id)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        ImplementerViewModel IImplementerStorage.GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == model.Id || implementer.ImplementerFIO ==
               model.ImplementerFIO)
                {
                    return CreateModel(implementer);
                }
            }
            return null;
        }

        List<ImplementerViewModel> IImplementerStorage.GetFilteredList(string FIO)
        {
            if (string.IsNullOrWhiteSpace(FIO))
            {
                return null;
            }
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in source.Implementers)
            {
                if (implementer.ImplementerFIO.Contains(FIO))
                {
                    result.Add(CreateModel(implementer));
                }
            }
            return result;
        }

        List<ImplementerViewModel> IImplementerStorage.GetFullList()
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in source.Implementers)
            {
                result.Add(CreateModel(implementer));
            }
            return result;
        }

        void IImplementerStorage.Insert(ImplementerBindingModel model)
        {
            Implementer tempImplementer= new Implementer { Id = 1 };
            foreach (var implementer in source.Components)
            {
                if (implementer.Id >= tempImplementer.Id)
                {
                    tempImplementer.Id = implementer.Id + 1;
                }
            }
            source.Implementers.Add(CreateModel(model, tempImplementer));
        }

        void IImplementerStorage.Update(ImplementerBindingModel model)
        {
            Implementer tempImplementer = null;
            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == model.Id)
                {
                    tempImplementer = implementer;
                }
            }
            if (tempImplementer == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempImplementer);
        }
        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            return implementer;
        }

        private ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerFIO = implementer.ImplementerFIO,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
