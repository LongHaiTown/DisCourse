namespace BuenosDias.DALL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CacLoaiQuyen")]
    public partial class CacLoaiQuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CacLoaiQuyen()
        {
            User_ = new HashSet<User_>();
        }

        [Key]
        [StringLength(10)]
        public string MaLoaiQuyen { get; set; }

        [StringLength(20)]
        public string TenQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_> User_ { get; set; }
    }
}
