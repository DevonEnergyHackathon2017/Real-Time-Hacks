namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StageAttribute")]
    public partial class StageAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StageAttribute()
        {
            Thresholds = new HashSet<Threshold>();
        }

        public int Id { get; set; }

        public int StageId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual Stage Stage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Threshold> Thresholds { get; set; }
    }
}
