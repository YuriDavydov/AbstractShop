using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using FileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImplement.Implements
{
    internal class ImplementerXML : IImplementerStorage
    {
        private readonly FileDataListSingleton source;

        public ImplementerXML()
        {
            source = FileDataListSingleton.GetInstance();
        }
        void IImplementerStorage.Delete(ImplementerBindingModel model)
        {
            Implementer? element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

            if (element is null)
            {
                throw new Exception("Элемент не найден");
            }

            source.Implementers.Remove(element);
        }

        ImplementerViewModel IImplementerStorage.GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var implemeneter = source.Implementers.Select(create => CreateModel(create))
            .FirstOrDefault(rec => rec.Id == model.Id || rec.ImplementerFIO == model.ImplementerFIO);
            return implemeneter;
        }

        List<ImplementerViewModel> IImplementerStorage.GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Implementers
            .Where(rec => rec.ImplementerFIO.Contains(model.ImplementerFIO))
           .Select(create => CreateModel(create))
            .ToList();
        }

        List<ImplementerViewModel> IImplementerStorage.GetFullList()
        {
            return source.Implementers.Select(implementer => CreateModel(implementer)).ToList();
        }

        void IImplementerStorage.Insert(ImplementerBindingModel model)
        {
            int maxId = source.Implementers.Count > 0 ? source.Implementers.Max(rec => rec.Id) : 0;
            var element = new Implementer { Id = maxId + 1 };
            source.Implementers.Add(CreateModel(model, element));
        }

        void IImplementerStorage.Update(ImplementerBindingModel model)
        {
            var element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

            if (element is null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        private static Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            return implementer;
        }

        private static ImplementerViewModel CreateModel(Implementer implementer)
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
