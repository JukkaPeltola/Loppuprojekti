namespace vessaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [Key]
        public int review_id { get; set; }

        public int user_id { get; set; }

        public int toilet_id { get; set; }

        public int? rating { get; set; }

        [StringLength(300)]
        public string review_text { get; set; }

        public virtual Toilet Toilet { get; set; }

        public virtual User User { get; set; }
    }
}
