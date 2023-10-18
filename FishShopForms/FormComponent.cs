using FishShop.BindingModels;
using FishShop.BusinessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FishShopForms
{
    public partial class FormComponent : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int? Id { private get; set; }
        private readonly ComponentLogic logic;

        public FormComponent(ComponentLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ComponentBindingModel { Id = this.Id })?[0];
                    if (view != null)
                    {
                        nameText.Text = view.ComponentName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameText.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ComponentBindingModel
                {
                    Id = this.Id,
                    Name = nameText.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
