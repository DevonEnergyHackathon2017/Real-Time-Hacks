namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CostStructureItem")]
    public partial class CostStructureItem
    {
        public int Id { get; set; }

        public int CostStructureId { get; set; }

        public double? ThresholdMin { get; set; }

        public double? ThresholdMax { get; set; }

        public double Cost { get; set; }

        public int RateUnitOfMeasureId { get; set; }

        [ForeignKey("CostStructureId")]
        public virtual CostStructure CostStructure { get; set; }

        [ForeignKey("RateUnitOfMeasureId")]
        public virtual RateUnitOfMeasure RateUnitOfMeasure { get; set; }
    }
}
