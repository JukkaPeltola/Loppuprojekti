namespace vessaApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chat")]
    public partial class chat
    {
        [Key]
        public int chat_id { get; set; }

        public int user_id { get; set; }

        [StringLength(300)]
        public string text { get; set; }

        public virtual User User { get; set; }
    }
}
