using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Models
{
    public partial class TransmissionContext : DbContext
    {
        #region Constructor
        public TransmissionContext(DbContextOptions<TransmissionContext>
        options)
        : base(options)
        { }
        #endregion
        public virtual DbSet<TransformerSubstation> TransformerSubstation { get; set; }
        public virtual DbSet<TransmissionLine> TransmissionLine { get; set; }
        public virtual DbSet<Builder> Builder { get; set; }
        public virtual DbSet<FunctionalPurpose> FunctionalPurpose { get; set; }
        public virtual DbSet<ParallelCircuits> ParallelCircuits { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<RatedVoltage> RatedVoltage { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Topology> Topology { get; set; }
        public virtual DbSet<SubstationLines> SubstationLines { get; set; }
        public virtual DbSet<TypeOfCurrent> TypeOfCurrent { get; set; }

        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TransformerSubstation>(entity =>
            {
                entity.HasMany(a => a.SubstationLines).WithOne(a => a.TransformerSubstation).HasForeignKey(a => a.TransformerSubstationId);
                entity.HasOne(a => a.Project).WithMany(a => a.TransformerSubstations).HasForeignKey(a => a.ProjectId);
                entity.HasOne(a => a.State).WithMany(a => a.TransformerSubstations).HasForeignKey(a => a.StateId);
                entity.HasOne(a => a.Builder).WithMany(a => a.TransformerSubstations).HasForeignKey(a => a.BuilderId);
            });
            modelBuilder.Entity<TransmissionLine>(entity =>
            {
                entity.HasMany(a => a.SubstationLines).WithOne(a => a.TransmissionLine).HasForeignKey(a => a.TransmissionLineId);
                entity.HasOne(a => a.RatedVoltage).WithMany(a => a.TransmissionLines).HasForeignKey(a => a.RatedVoltageId);
                entity.HasOne(a => a.Topology).WithMany(a => a.TransmissionLines).HasForeignKey(a => a.TopologyId);
                entity.HasOne(a => a.TypeOfCurrent).WithMany(a => a.TransmissionLines).HasForeignKey(a => a.TypeOfCurrentId);
                entity.HasOne(a => a.ParallelCircuits).WithMany(a => a.TransmissionLines).HasForeignKey(a => a.ParallelCircuitsId);
                entity.HasOne(a => a.FunctionalPurpose).WithMany(a => a.TransmissionLines).HasForeignKey(a => a.FunctionalPurposeId);
            });
            //modelBuilder.Entity<SubstationLines>(entity =>
            //{
            //    entity.HasOne(a => a.TransmissionLine).WithMany(a => a.SubstationLines).HasForeignKey(a => a.TransmissionLineId);
            //    entity.HasOne(a => a.TransformerSubstation).WithMany(a => a.SubstationLines).HasForeignKey(a => a.TransformerSubstationId);
            //});
        }
}
}
