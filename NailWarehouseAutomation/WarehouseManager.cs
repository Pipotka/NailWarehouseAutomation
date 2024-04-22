using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NailWarehouseAutomation.Models;
using NailWarehouseAutomation.Helpers;
using NailWarehouseAutomation.Models.ClassesOfModels;
using NailWarehouseAutomation.Models.ClassEnums;

namespace NailWarehouseAutomation
{
    public partial class WarehouseManager : Form
    {
        private Material[] materials;
        public readonly Nail nail;
        public WarehouseManager(Nail sourse)
        {
            nail = (Nail)sourse?.Clone() ?? new Nail();
            nail.SetGuid();
            InitializeComponent();
            materials = new Material[4]
            {
                new Material("Медь", NailMaterials.Copper),
                new Material("Сталь", NailMaterials.Steel),
                new Material("Железо", NailMaterials.Iron),
                new Material("Хром", NailMaterials.Chrome)
            };
            NameTextBox.AddBindings(x => x.Text, nail, x => x.Name, errorProvider);
            LengthNumericUpDown.AddBindings(x => x.Value, nail, x => x.Length, errorProvider);
            DiameterNumericUpDown.AddBindings(x => x.Value, nail, x => x.Diameter, errorProvider);
            MaterialComboBox.DataSource = materials;
            MaterialComboBox.DisplayMember = nameof(Material.Name);
            MaterialComboBox.ValueMember = nameof(Material.M);
            MaterialComboBox.AddBindings(x => x.SelectedValue, nail, x => x.Material, errorProvider);
            QuantityNnumericUpDown.AddBindings(x => x.Value, nail, x => x.Quantity, errorProvider);
            PriceExcludingVATNumericUpDown.AddBindings(x => x.Value, nail, x => x.PriceExcludingVAT, errorProvider);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
