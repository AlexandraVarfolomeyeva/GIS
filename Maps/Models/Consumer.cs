using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class Consumer
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public double CoordinatesX { get; set; }//координаты для Яндекс-карт
        public double CoordinatesY { get; set; }//координаты для Яндекс-карт
        public int SubstationId { get; set; }
        public TransformerSubstation TS { get; set; }
        public string Address { get; set; }//адрес
    }
}
