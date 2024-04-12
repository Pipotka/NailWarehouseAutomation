using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailWarehouseAutomation.Models
{
    public class Nail
    {
        private const int minQuantity = 0;
        public Guid Id { get; }
        public string Name
        {
            get => Name;
            
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Name = value;
                }
            }
        }
        public ClassesOfModels.NailSize Size { get; }
        public ClassEnums.NailMaterials Material { get; }
        private int quantity;
        private double priceExcludingVAT;


        public void ChangeQuantity(int change)
        {
            if (quantity + change >= 0)
            {
                quantity += change;
            }
        }

        public int GetQuantity() => quantity;

        public void ChangePriceExcludingVAT(double change)
        {
            if (priceExcludingVAT + change >= 0)
            {
                priceExcludingVAT += change;
            }
        }

        public double TotalCostExcludingVAT() => priceExcludingVAT * quantity;

        public double TotalCostWithVAT(double VAT) => (((VAT / 100) * priceExcludingVAT) + priceExcludingVAT) * quantity;
    }
}
