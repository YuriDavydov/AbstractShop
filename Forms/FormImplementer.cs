using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace Forms
{
    public partial class FormImplementer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IImplementerStorage logic;
        public FormImplementer(IImplementerStorage logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        public int? Id { get; set; }

        private void ButtonAddImplementer_Click(object sender, EventArgs e)
        {
            var FIO = textBoxFIO.Text;
            var workingTime = textBoxWorkTime.Text;
            var Rest = textBoxRest.Text;
            if (string.IsNullOrEmpty(FIO))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(workingTime))
            {
                MessageBox.Show("Заполните рабочее время", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(Rest))
            {
                MessageBox.Show("Заполните время отдыха", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new ImplementerBindingModel
                {
                    ImplementerFIO = FIO,
                    WorkingTime = int.Parse(workingTime),
                    PauseTime = int.Parse(Rest)
                };
                if (Id == null)
                {
                    logic.Insert(model);
                }
                else
                {
                    model.Id = Id.Value;
                    logic.Update(model);
                }
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

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (Id == null) 
            {
                return;
            }
            ImplementerBindingModel model = new ImplementerBindingModel {Id = Id.Value};
            var implementer = logic.GetElement(model);
            if (implementer == null) 
            {
                return;
            }
            textBoxFIO.Text = implementer.ImplementerFIO;
            textBoxWorkTime.Text = implementer.WorkingTime.ToString();
            textBoxRest.Text = implementer.PauseTime.ToString();
        }
    }
}
