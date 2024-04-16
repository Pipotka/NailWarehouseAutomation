using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NailWarehouseAutomation.Models.ClassesOfModels
{
    internal class Material
    {
        /// <summary>
        /// Название материала
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// <see cref="ClassEnums.NailMaterials"/>
        /// </summary>
        public ClassEnums.NailMaterials M { get;}

        public Material(string name, ClassEnums.NailMaterials materials)
        {
            Name = name;
            M = materials;
        }
    }
}
