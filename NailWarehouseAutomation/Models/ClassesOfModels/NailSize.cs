using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailWarehouseAutomation.Models.ClassesOfModels
{
    public struct NailSize
    {
        public float diameter { get; }
        public float length { get; }

        public NailSize(float diameter, float length)
        {
            this.diameter = diameter;
            this.length = length;
        }
    }
}
