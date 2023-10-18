using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using Unity;

namespace Forms;

public partial class FormComponents : Form
{
    [Dependency]
    public new IUnityContainer Container { get; set; }
    private readonly ComponentLogic logic;
    public FormComponents(ComponentLogic logic)
    {
        InitializeComponent();
        this.logic = logic;
    }
    private void FormComponents_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        var form = Container.Resolve<FormComponent>();
        if (form.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }

    }
    /// <summary>
    ///  Если мы выделили одну строку, то конвертируем в число id взятое из базы данных
    /// </summary>
    private void ChangeButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 1)
        {
            var form = Container.Resolve<FormComponent>();
            form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }

    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UpdateButton_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void DeleteButton_Click(object sender, EventArgs e)
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
                    logic.Delete(new ComponentBindingModel { Id = id });
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

    private void LoadData()
    {
        try
        {
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
           MessageBoxIcon.Error);
        }
    }

}
