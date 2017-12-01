namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RateUnitOfMeasure")]
    public partial class RateUnitOfMeasure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RateUnitOfMeasure()
        {
            CostStructureItems = new HashSet<CostStructureItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string Abbreviation { get; set; }

        public int NumUnitOfMeasureId { get; set; }

        public int DenomUnitOfMeasureId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostStructureItem> CostStructureItems { get; set; }
    }
}
