using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class ParallelCircuits
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }//тип по количеству параллельных цепей
        public virtual ICollection<TransmissionLine> TransmissionLines { get; set; }
    }
}
