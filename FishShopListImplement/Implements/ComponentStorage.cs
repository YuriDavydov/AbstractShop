﻿using FishShop;
using FishShop.BindingModels;
using FishShop.Interfaces;
using FishShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishShopListImplement.Implements
{
    public class ComponentStorage : IComponentStorage

    {
        private readonly DataListSingleton source;


        public ComponentStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        /// <summary>
        /// Преобразуем лист в тип ComponentViewModel из типа Компонент
        /// </summary>
        /// <returns></returns>
        public List<ComponentViewModel> GetFullList()
        {
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            foreach (var component in source.Components)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            foreach (var component in source.Components)
            {
                if (component.ComponentName.Contains(model.Name))
                {
                    result.Add(CreateModel(component));
                }
            }
            return result;
        }
        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var component in source.Components)
            {
                if (component.Id == model.Id || component.ComponentName ==
               model.Name)
                {
                    return CreateModel(component);
                }
            }
            return null;
        }
        public void Insert(ComponentBindingModel model)
        {
            Component tempComponent = new Component { Id = 1 };
            foreach (var component in source.Components)
            {
                if (component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
            }
            source.Components.Add(CreateModel(model, tempComponent));
        }

        public void Update(ComponentBindingModel model)
        {
            Component tempComponent = null;
            foreach (var component in source.Components)
            {
                if (component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (tempComponent == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempComponent);
        }
        public void Delete(ComponentBindingModel model)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id.Value)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.Name;
            return component;
        }

        private ComponentViewModel CreateModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }

    }
}
