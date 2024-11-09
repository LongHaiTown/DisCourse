namespace BuenosDias.DALL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            HinhAnhs = new HashSet<HinhAnh>();
            ChuDes = new HashSet<ChuDe>();
        }

        [Key]
        [StringLength(100)]
        public string IDBaiViet { get; set; }

        [StringLength(200)]
        public string TIeuDe { get; set; }

        [StringLength(100)]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(100)]
        public string UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKhoaHoc { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual User_ User_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuDe> ChuDes { get; set; }
    }
}
