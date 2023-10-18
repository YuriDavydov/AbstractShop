using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public void Delete(int id)
        {
            using (var context = new Database())
            {
                Implementer? element = context.Implementers.Find(id);
                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Database())
            {
                var implementer = context.Implementers
                .FirstOrDefault(rec => rec.ImplementerFIO == model.ImplementerFIO ||
               rec.Id == model.Id);
                return implementer != null ?
                new ImplementerViewModel
                {
                    Id = implementer.Id,
                    ImplementerFIO = implementer.ImplementerFIO,
                    WorkingTime = implementer.WorkingTime,
                    PauseTime = implementer.PauseTime
                } :
               null;
            }
        }

        public List<ImplementerViewModel> GetFilteredList(string fio)
        {
            if (string.IsNullOrEmpty(fio))
            {
                return new List<ImplementerViewModel>();
            }
            using (var context = new Database())
            {
                return context.Implementers
                .Where(rec => rec.ImplementerFIO.Contains(fio))
               .Select(rec => new ImplementerViewModel
               {
                   Id = rec.Id,
                   ImplementerFIO = rec.ImplementerFIO,
                   WorkingTime = rec.WorkingTime,
                   PauseTime = rec.PauseTime
               })
                .ToList();
            }
        }

        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Implementers
            .Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO,
                WorkingTime = rec.WorkingTime,
                PauseTime = rec.PauseTime
            })
    .ToList();
        }

        public void Insert(ImplementerBindingModel model)
        {
            using (var context = new Database())
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
            }
        }

        public void Update(ImplementerBindingModel model)
        {
            using (var context = new Database())
            {
                var element = context.Implementers.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private static Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }
    }
}
