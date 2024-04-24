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
using NailWarehouseAutomation.Models.ClassEnums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NailWarehouseAutomation
{
    public partial class WarehouseManager : Form
    {
        public readonly Nail nail;
        public WarehouseManager(Nail sourse)
        {
            nail = (Nail)sourse?.Clone() ?? new Nail();
            nail.SetGuid();

            InitializeComponent();
            MaterialComboBox.DataSource = Enum.GetValues(typeof(NailMaterials));
            //MaterialComboBox.DisplayMember = Enum.GetNames<NailMaterials>();//typeof(NailMaterials)
            //.GetCustomAttributes(typeof(DisplayNameAttribute), true)
            //.FirstOrDefault() as string;

            NameTextBox.AddBindings(x => x.Text, nail, x => x.Name, errorProvider);
            LengthNumericUpDown.AddBindings(x => x.Value, nail, x => x.Length, errorProvider);
            DiameterNumericUpDown.AddBindings(x => x.Value, nail, x => x.Diameter, errorProvider);
            //MaterialComboBox.ValueMember = nameof(Material.M);
            MaterialComboBox.AddBindings(x => x.SelectedItem, nail, x => x.Material, errorProvider);
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

        private void MaterialComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {// Остановился здесь
            Type type = sender.GetType();
            MemberInfo member = type.GetMember(sender.ToString())[0];
            DisplayAttribute displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(member, typeof(DisplayAttribute));
            e.Graphics.DrawString(displayAttribute.Name, MaterialComboBox.Font, new SolidBrush(MaterialComboBox.ForeColor), new PointF(0.0f, 0.0f));
        }
    }
}
