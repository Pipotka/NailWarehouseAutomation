using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NailWarehouseAutomation.Models.ClassesOfModels
{
    /// <summary>
    /// Размер гвоздей
    /// </summary>
    public struct NailSize
    {
        /// <summary>
        /// Диаметр гвоздя
        /// </summary>
        [Required( ErrorMessage = "Не указан диаметр товара")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Недопустимый диаметр товара")]
        public double Diameter { get; set; }
        /// <summary>
        /// Высота гвоздя
        /// </summary>
        [Required(ErrorMessage = "Не указана длина товара")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Недопустимая длина товара")]
        public double Length { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="diameter">Диаметр гвоздя</param>
        /// <param name="length">Высота гвоздя</param>
        public NailSize(double diameter, double length)
        {
            Diameter = diameter;
            Length = length;
        }
    }
}
