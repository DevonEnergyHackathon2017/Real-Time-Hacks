namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CostStructure")]
    public partial class CostStructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CostStructure()
        {
            CostStructureItems = new HashSet<CostStructureItem>();
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostStructureItem> CostStructureItems { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
