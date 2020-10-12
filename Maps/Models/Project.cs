using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class Project
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }//название проекта
        public virtual ICollection<TransformerSubstation> TransformerSubstations { get; set; }
    }
}
