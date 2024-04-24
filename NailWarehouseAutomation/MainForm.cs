using NailWarehouseAutomation.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NailWarehouseAutomation
{
    public partial class MainForm : Form
    {
        private readonly BindingSource bindingSource;
        private readonly BindingList<Nail> nails;
        private double VAT;
        public MainForm()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            nails = new BindingList<Nail>();
            nails.AllowNew = false;// Кастыль
            nails.AllowRemove = false;// Кастыль
            nails.AllowEdit = false;// Кастыль
            nails.RaiseListChangedEvents = false;// Кастыль
            bindingSource.DataSource = nails;
            WarehouseDataGridView.DataSource = bindingSource;
            WarehouseDataGridView.AutoGenerateColumns = true;
            WarehouseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var managerForm = new WarehouseManager(null);
            if (managerForm.ShowDialog() == DialogResult.OK)
            {
                nails.Add(managerForm.nail);
                nails.RaiseListChangedEvents = true;// Кастыль
                nails.ResetBindings();// Кастыль
            }
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormattingHeaders()
        {
            WarehouseDataGridView.Columns["PriceExcludingVAT"].HeaderText = "Цена без НДС";
            WarehouseDataGridView.Columns["PriceExcludingVAT"].Width = 112;
        }
    }
}
