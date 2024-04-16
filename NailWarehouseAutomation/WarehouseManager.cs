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

namespace NailWarehouseAutomation
{
    public partial class WarehouseManager : Form
    {
        private readonly Nail nail;
        public WarehouseManager(Nail sourse)
        {
            nail = (Nail)sourse?.Clone() ?? new Nail();
            InitializeComponent();
            NameTextBox.AddBindings(x => x.Text, nail, x => x.Name, errorProvider);
            LengthNumericUpDown.DataBindings.Add("Value", nail, nameof(Nail.Size.Length));
            LengthNumericUpDown.AddBindings(x => x.Value, nail, x => x.Size.Length, errorProvider);
            //DiameterNumericUpDown.AddBindings(x => x.Value, nail, x => x.Size.Diameter, errorProvider);
            //MaterialComboBox.AddBindings(x => x., nail, x => x.Name, errorProvider);
            //QuantityNnumericUpDown.AddBindings(x => x.Text, nail, x => x.Name, errorProvider);
            //PriceExcludingVATTextBox.AddBindings(x => x.Text, nail, x => x.Name, errorProvider);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameLabel.Text = nail.Name;
        }
    }
}
