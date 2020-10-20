using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class TransformerSubstation
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public double CoordinatesX { get; set; }//координаты для Яндекс-карт
        public double CoordinatesY { get; set; }//координаты для Яндекс-карт
        public string Address { get; set; }//адрес
        
        //nullable
        public int YearStart { get; set; }//год когда начали строить
        public int YearFinish { get; set; }//год когда закончили строить
        public int YearDone { get; set; }//год когда вывели из эксплуатации
        public string Name { get; set; }//Название

        public int Floors { get; set; }//Этажность
        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }//Проект
        public virtual Project Project { get; set; }//Проект
        [Required]
        [ForeignKey("Builder")]
        public int BuilderId { get; set; }//Застройщик
        public virtual Builder Builder { get; set; }//Застройщик
        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; } //Текущий статус - используется ли   
        public virtual State State { get; set; } //Текущий статус - используется ли

        public virtual ICollection<SubstationLines> SubstationLines { get; set; }//множество ЛЭП
        public TransformerSubstation()
        {
            SubstationLines = new HashSet<SubstationLines>();
        }
    }
}
