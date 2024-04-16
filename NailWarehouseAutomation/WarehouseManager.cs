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
        private readonly Nail nail;
        public WarehouseManager(Nail sourse)
        {
            nail = (Nail)sourse?.Clone() ?? new Nail();
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

        private void button1_Click(object sender, EventArgs e)
        {
            NameLabel.Text = nail.Name;
            LengthLabel.Text = nail.Length.ToString();
            DiameterLabel.Text = nail.Diameter.ToString();
            QuantityLabel.Text = nail.Quantity.ToString();
            PriceExcludingVATLabel.Text = nail?.PriceExcludingVAT.ToString();
            MaterialLabel.Text = nail?.Material.ToString();
        }
    }
}
