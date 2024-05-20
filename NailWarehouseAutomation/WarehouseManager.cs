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
using System.Runtime.CompilerServices;

namespace NailWarehouseAutomation
{
    public partial class WarehouseManager : Form
    {
        public readonly Nail nail;
        public WarehouseManager(Nail sourse = null)
        {
            InitializeComponent();
            if (sourse is null)
            {
                nail = new Nail();
            }
            else
            {
                nail = (Nail)sourse.Clone();
                MainText.Text = "Изменение товара";
            }
            MaterialComboBox.DataSource = Enum.GetValues(typeof(NailMaterials));

            NameTextBox.AddBindings(x => x.Text, nail, x => x.Name, errorProvider);
            LengthNumericUpDown.AddBindings(x => x.Value, nail, x => x.Length, errorProvider);
            DiameterNumericUpDown.AddBindings(x => x.Value, nail, x => x.Diameter, errorProvider);
            MaterialComboBox.AddBindings(x => x.SelectedItem, nail, x => x.Material, errorProvider);
            QuantityNnumericUpDown.AddBindings(x => x.Value, nail, x => x.Quantity, errorProvider);
            PriceExcludingVATNumericUpDown.AddBindings(x => x.Value, nail, x => x.PriceExcludingVAT, errorProvider);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var context = new ValidationContext(nail);
            var resualts = new List<ValidationResult>();
            if (Validator.TryValidateObject(nail, context, resualts, true))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели некорректные данные",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MaterialComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                var brush = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? new SolidBrush(Color.White)
                    : new SolidBrush(MaterialComboBox.ForeColor);
                e.Graphics.DrawString(((NailMaterials)MaterialComboBox.Items[e.Index]).DisplayName(), MaterialComboBox.Font, brush, e.Bounds);
            }
        }
    }
}
