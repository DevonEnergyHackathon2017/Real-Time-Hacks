namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Threshold")]
    public partial class Threshold
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Threshold()
        {
            Jobs = new HashSet<Job>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int StageAttributeId { get; set; }

        [Required]
        [StringLength(8)]
        public string Type { get; set; }

        public double Value { get; set; }

        public virtual StageAttribute StageAttribute { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
