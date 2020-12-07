using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class Minimum
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public double Value { get; set; }//minimum расстояние
        public DateTime session { get; set; }

        public int IdSubstation { get; set; }//подстанция
        public TransformerSubstation Substation { get; set; }

        public virtual ICollection<Consumer> Consumers { get; set; }//множество потребителей
        public Minimum()
        {
            Consumers = new HashSet<Consumer>();
        }
    }
}
