using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using NailWarehouseAutomation.Models.ClassesOfModels;

namespace NailWarehouseAutomation.Models
{
    public class Nail : ICloneable
    {
        /// <summary>
        ///  Минимальное значение для поля  <see cref="Quantity"/>
        /// </summary>
        private const int minQuantity = 1;
        /// <summary>
        /// Максимальное количесво символов в  поле <see cref="Name"/>
        /// </summary>
        private const int maxStringLength = 70;
        /// <summary>
        /// Минимальное количесво символов в поле  <see cref="Name"/>
        /// </summary>
        private const int minStringLength = 1;
        /// <summary>
        /// Первичный ключ для БД
        /// </summary>
        public Guid id { get; }
        /// <summary>
        /// Наименование гвоздей
        /// </summary>
        [Required(ErrorMessage = "Не указанно имя товара")]
        [StringLength(maxStringLength,
            MinimumLength = minStringLength,
            ErrorMessage = "Имя должно иметь длину от 1 и до 70 символов")]
        public string Name { get; set; }
        /// <summary>
        /// Диаметр гвоздя
        /// </summary>
        [Required(ErrorMessage = "Не указан диаметр товара")]
        [Range(0.0000001, double.MaxValue, ErrorMessage = "Недопустимый диаметр товара")]
        public double Diameter { get; set; }
        /// <summary>
        /// Высота гвоздя
        /// </summary>
        [Required(ErrorMessage = "Не указана длина товара")]
        [Range(0.0000001, double.MaxValue, ErrorMessage = "Недопустимая длина товара")]
        public double Length { get; set; }
        ///// <summary>
        ///// <see cref="NailWarehouseAutomation.Models.ClassesOfModels.NailSize"/>
        ///// </summary>
        //[Required(ErrorMessage = "Не указан размер товара")]
        //public ClassesOfModels.NailSize Size { get; set; }
        /// <summary>
        /// <see cref="Models.ClassEnums.NailMaterials"/>
        /// </summary>
        [Required(ErrorMessage = "Не указан материал из которого изготовлен товар")]
        public ClassEnums.NailMaterials Material { get; set; }
        /// <summary>
        /// Количество данных гвоздей
        /// </summary>
        [Required(ErrorMessage = "Не указано количество товара")]
        [Range(minQuantity, int.MaxValue, ErrorMessage = "Недопустимое количество товара")]
        public int Quantity { get; set; }
        /// <summary>
        /// Цена без НДС
        /// </summary>
        [Required(ErrorMessage = "Не указана цена одного экземпляра товара без учёта НДС")]
        [Range(0, double.MaxValue, ErrorMessage = "Недопустимая цена товара(без учёта НДС)")]
        public double PriceExcludingVAT { get; set; }
        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Nail()
        {
            id = Guid.NewGuid();
        }
        /// <summary>
        /// реализация метода интерфейса <see cref="ICloneable"/>
        /// </summary>
        /// <returns>копия экземпляра класса <see cref="Nail"/></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
} 
