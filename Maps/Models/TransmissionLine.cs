using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public class TransmissionLine
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Coordinates { get; set; }//координаты для Яндекс-карт
        public string Bandwidth { get; set; }//пропускная спрособность
        public int Length { get; set; }//длина ЛЭП
        public string Voltage { get; set; }//напряжение
        public int nParallelCircuits { get; set; }//количество параллельных цепей
        public string CurrentLoad { get; set; }//токовая нагрузка
        [Required]
        [ForeignKey("RatedVoltage")]
        public int RatedVoltageId { get; set; }//справочник номинальное напряжение
        public virtual RatedVoltage RatedVoltage { get; set; }//справочник номинальное напряжение
        [Required]
        [ForeignKey("TypeOfCurrent")]
        public int TypeOfCurrentId { get; set; }//справочник род тока
        public virtual TypeOfCurrent TypeOfCurrent { get; set; }//справочник род тока
        [Required]
        [ForeignKey("ParallelCircuits")]
        public int ParallelCircuitsId { get; set; }//справочник классификация по количеству параллельных цепей
        public virtual ParallelCircuits ParallelCircuits { get; set; }//справочник классификация по количеству параллельных цепей
        [Required]
        [ForeignKey("Topology")]
        public int TopologyId { get; set; }//справочник топологические характеристики
        public virtual Topology Topology { get; set; }//справочник топологические характеристики
        [Required]
        [ForeignKey("FunctionalPurpose")]
        public int FunctionalPurposeId { get; set; }//справочник функциональное назначение
        public virtual FunctionalPurpose FunctionalPurpose { get; set; }//справочник функциональное назначение

        public virtual ICollection<SubstationLines> SubstationLines { get; set; }//множество ЛЭП
        public TransmissionLine()
        {
            SubstationLines = new HashSet<SubstationLines>();
        }
    }
}
