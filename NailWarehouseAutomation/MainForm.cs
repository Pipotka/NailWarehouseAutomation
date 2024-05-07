using NailWarehouseAutomation.Helpers;
using NailWarehouseAutomation.Models;
using NailWarehouseAutomation.Models.ClassEnums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace NailWarehouseAutomation
{
    public partial class MainForm : Form
    {
        private readonly BindingSource bindingSource;
        private readonly BindingList<Nail> nails;
        private double VAT = 20;
        public MainForm()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            nails = new BindingList<Nail>();
            WarehouseDataGridView.AutoGenerateColumns = false;
            bindingSource.DataSource = nails;
            WarehouseDataGridView.DataSource = bindingSource;
            WarehouseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WarehouseDataGridView.ReadOnly = true;
            WarehouseDataGridView.MultiSelect = false;
            FormattingHeaders(typeof(Nail));
            CalculateStatus();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var managerForm = new WarehouseManager();
            if (managerForm.ShowDialog() == DialogResult.OK)
            {
                nails.Add(managerForm.nail);
            }
            CalculateStatus();
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WarehouseDataGridView.Rows.Count != 0 && WarehouseDataGridView.SelectedRows.Count != 0)
            {
                var nail = (Nail)WarehouseDataGridView.SelectedRows[0].DataBoundItem;
                var managerForm = new WarehouseManager(nail);
                if (managerForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < nails.Count; i++)
                    {
                        if (nails[i].GetId() == nail.GetId())
                        {
                            nails[i] = (Nail)managerForm.nail.Clone();
                        }
                    }
                }
                CalculateStatus();
            }
        }

        private void FormattingHeaders(Type type)
        {
            Type soursType = type;
            int numberOfColumns = 0;
            foreach (PropertyInfo property in soursType.GetProperties())
            {
                numberOfColumns++;
            }
            foreach (PropertyInfo property in soursType.GetProperties())
            {
                foreach (DisplayAttribute attr in property.GetCustomAttributes(typeof(DisplayAttribute)))
                {
                    WarehouseDataGridView.Columns.Add(property.Name.ToString(), attr.GetName());
                    WarehouseDataGridView.Columns[property.Name.ToString()].Width = WarehouseDataGridView.Width / numberOfColumns;
                    WarehouseDataGridView.Columns[property.Name.ToString()].DataPropertyName = property.Name;
                }
            }
        }

        private void WarehouseDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (WarehouseDataGridView.Columns[e.ColumnIndex].Name == nameof(Nail.Quantity))
            {
                if ((int)e.Value < Nail.minQuantity)
                {
                    for (int i = 0; i < WarehouseDataGridView.ColumnCount; i++)
                    {
                        WarehouseDataGridView.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(190, 47, 51);
                    }
                }
            }

            if (WarehouseDataGridView.Columns[e.ColumnIndex].Name == nameof(Nail.Material))
            {
                e.Value = ((Enum)e.Value).DisplayName();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WarehouseDataGridView.SelectedRows.Count != 0)
            {
                var nail = (Nail)WarehouseDataGridView.SelectedRows[0].DataBoundItem;
                bindingSource.Remove(nail);
                CalculateStatus();
            }
        }

        private void CalculateStatus()
        {
            int totalNumberOfNails = 0;
            int count = 0;
            double AVGPrice = 0.0;
            double totalCostIncludingVAT = 0.0;
            double TotalCostWithVAT = 0.0;

            foreach (Nail nail in nails)
            {
                count++;
                totalNumberOfNails += nail.Quantity;
                AVGPrice += nail.PriceExcludingVAT;
                totalCostIncludingVAT += nail.PriceExcludingVAT * nail.Quantity;
                TotalCostWithVAT += nail.PriceIncludingVAT(VAT) * nail.Quantity;
            }
            if (count > 0)
            {
                AVGPrice /= count;
            }
            TotalNumberOfNailsToolStripStatusLabel.Text = $"Общее количество гвоздей на складе: {totalNumberOfNails} шт.";
            TotalCostIncludingVATOfGoodsToolStripStatusLabel.Text = $"Общая стоимость без НДС: {totalCostIncludingVAT:C2} руб.";
            NumberOfProductLinesToolStripStatusLabel.Text = $"Количество товарных позиций: {count}";
            TotalCostWithVATToolStripStatusLabel.Text = $"Общая стоимость с НДС: {TotalCostWithVAT:C2}";
        }
    }
}
