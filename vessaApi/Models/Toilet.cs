namespace vessaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Toilet")]
    public partial class Toilet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Toilet()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int toilet_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string zip { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        public bool? inva { get; set; }

        [StringLength(300)]
        public string information { get; set; }

        [StringLength(50)]
        public string latitude { get; set; }

        [StringLength(50)]
        public string longitude { get; set; }

        public byte[] picture { get; set; }

        public TimeSpan? opening { get; set; }

        public TimeSpan? closing { get; set; }

        public double? pricing { get; set; }

        public double? rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
