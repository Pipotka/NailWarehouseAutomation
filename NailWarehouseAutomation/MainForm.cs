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
            bindingSource.DataSource = nails;
            WarehouseDataGridView.DataSource = bindingSource;
            WarehouseDataGridView.AutoGenerateColumns = true;
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var managerForm = new WarehouseManager(null);
            if (managerForm.ShowDialog() == DialogResult.OK)
            {
                
                nails.Add(managerForm.nail);
            }
        }
        
        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nail newNail = new Nail
            //{
            //    Name = "vdfb",
            //    Diameter = 1,
            //    Length = 1,
            //    Material = Models.ClassEnums.NailMaterials.Chrome,
            //    PriceExcludingVAT = 1,
            //    Quantity = 1,

            //};
            //newNail.SetGuid();
            //nails.Add(newNail);
            //Person person = new Person()
            //{
            //    description = "wefe",
            //    name = "Name",
            //    age = DateTime.Now.Year
            //};
            //nails.Add(person);
        }
    }
    //public class Person
    //{
        
        
    //    public string name { get; set; }
        
    //    public string description { get; set; }
        
    //    public int age { get; set; }
        
    //}
}
