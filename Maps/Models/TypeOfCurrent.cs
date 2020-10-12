using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class TypeOfCurrent
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }//тип ЛЭП по роду тока
        public virtual ICollection<TransmissionLine> TransmissionLines { get; set; }
    }
}
