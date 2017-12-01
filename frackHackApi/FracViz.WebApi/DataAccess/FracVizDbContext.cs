namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FracVizDbContext : DbContext
    {
        public FracVizDbContext()
            : base("name=FracVizDbContext")
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<CostStructure> CostStructures { get; set; }
        public virtual DbSet<CostStructureItem> CostStructureItems { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<RateUnitOfMeasure> RateUnitOfMeasures { get; set; }
        public virtual DbSet<Stage> Stages { get; set; }
        public virtual DbSet<StageAttribute> StageAttributes { get; set; }
        public virtual DbSet<Threshold> Thresholds { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostStructure>()
                .HasMany(e => e.CostStructureItems)
                .WithRequired(e => e.CostStructure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.Stages)
                .WithRequired(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.CostStructures)
                .WithMany(e => e.Jobs)
                .Map(m =>
                {
                    m.ToTable("JobCostStructureXRef");
                    m.MapLeftKey("JobId");
                    m.MapRightKey("CostStructureId");
                });

            modelBuilder.Entity<Job>()
                .HasMany(e => e.Thresholds)
                .WithMany(e => e.Jobs)
                .Map(m =>
                {
                    m.ToTable("JobThresholdXRef");
                    m.MapLeftKey("JobId");
                    m.MapRightKey("ThresholdId");
                });

            modelBuilder.Entity<Threshold>()
                .HasMany(e => e.Jobs)
                .WithMany(e => e.Thresholds)
                .Map(m =>
                {
                    m.ToTable("JobThresholdXRef");
                    m.MapLeftKey("JobId");
                    m.MapRightKey("ThresholdId");
                });

            modelBuilder.Entity<Job>()
                .HasMany(e => e.Thresholds);

            modelBuilder.Entity<RateUnitOfMeasure>()
                .HasMany(e => e.CostStructureItems)
                .WithRequired(e => e.RateUnitOfMeasure)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stage>()
                .HasMany(e => e.StageAttributes)
                .WithRequired(e => e.Stage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StageAttribute>()
                .HasMany(e => e.Thresholds)
                .WithRequired(e => e.StageAttribute)
                .WillCascadeOnDelete(false);
        }
    }
}
