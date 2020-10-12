using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class State
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }//Текущее состояние
        public virtual ICollection<TransformerSubstation> TransformerSubstations { get; set; }
    }
}
