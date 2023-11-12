using BusinessLogic.BindingModels;
using BusinessLogic.BusinessLogics;
using BusinessLogic.ViewModels;
using Unity;

namespace Forms;

public partial class FormMain : Form
{
    [Dependency]
    public new IUnityContainer Container { get; set; }
    private readonly OrderLogic _orderLogic;
    public FormMain(OrderLogic orderLogic)
    {
        InitializeComponent();
        this._orderLogic = orderLogic;
    }


    private void КомпонентыToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = Container.Resolve<FormComponents>();
        form.ShowDialog();
    }

    private void ИзделияToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = Container.Resolve<FormProduct>();
        form.ShowDialog();
    }

    private void CreateOrderButton_Click(object sender, EventArgs e)
    {
        var form = Container.Resolve<FormCreateOrder>();
        form.ShowDialog();
        LoadData();
    }

    private void GiveInProgressButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 1)
        {
            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            try
            {
                _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                {
                    OrderId = id
                });
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }

    private void OrderIsFinishedButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 1)
        {
            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            try
            {
                _orderLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = id
                });
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }

    private async void OrderIsPaidButton_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 1)
        {
            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            try
            {
                await _orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LoadData()
    {
        try
        {

            List<OrderViewModel> list = _orderLogic.Read(null);
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

    private void buttonImplementers_Click(object sender, EventArgs e)
    {
        var form = Container.Resolve<FormImplementers>();
        form.ShowDialog();
    }

    private void buttonAccepted_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count == 1)
        {
            int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            try
            {
                _orderLogic.TakeOrderInAccept(new ChangeStatusBindingModel { OrderId = id });
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

    }
}
