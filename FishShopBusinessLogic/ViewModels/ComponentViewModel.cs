using System;
using System.ComponentModel;
namespace BusinessLogic.ViewModels
{
    /// <summary>
    /// Информация о компоненте (рыба, соус) для пользователя (графическое отображение)
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
