using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class SubstationLines
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("TransmissionLine")]
        public int TransmissionLineId { get; set; }
        [Required]
        [ForeignKey("TransformerSubstation")]
        public int TransformerSubstationId { get; set; }
        public virtual TransmissionLine TransmissionLine { get; set; }
        public virtual TransformerSubstation TransformerSubstation { get; set; }
    }
}
