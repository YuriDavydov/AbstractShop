using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplement.Implements;
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
    public partial class FormImplementers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IImplementerStorage logic;
        public FormImplementers(IImplementerStorage logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonAddImplementers_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementer>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {

                List<ImplementerViewModel> list = logic.GetFullList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void FormComponents_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementer>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }

        }
        /// <summary>
        ///  Если мы выделили одну строку, то конвертируем в число id взятое из базы данных
        /// </summary>

        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void ButtonChangeImplementers_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormImplementer>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonUpdateImplementers_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonDeleteImplementer_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
