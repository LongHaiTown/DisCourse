namespace BuenosDias.DALL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinCaNhan")]
    public partial class ThongTinCaNhan
    {
        public long? SDT { get; set; }

        [StringLength(20)]
        public string eMAIL { get; set; }

        [Key]
        [StringLength(100)]
        public string UserID { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
