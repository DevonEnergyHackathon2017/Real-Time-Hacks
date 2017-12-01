namespace FracViz.WebApi.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnitOfMeasure")]
    public partial class UnitOfMeasure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnitOfMeasure()
        { }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(32)]
        public string Abbreviation { get; set; }
    }
}
