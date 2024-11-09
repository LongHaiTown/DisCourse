namespace BuenosDias.DALL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnh")]
    public partial class HinhAnh
    {
        [Key]
        [StringLength(50)]
        public string MaHinhAnh { get; set; }

        [StringLength(150)]
        public string TenHinhAnh { get; set; }

        [StringLength(10)]
        public string LoaiHinhAnh { get; set; }

        [Required]
        [StringLength(100)]
        public string UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string IDBaiViet { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKhoaHoc { get; set; }

        public virtual BaiViet BaiViet { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        public virtual User_ User_ { get; set; }
    }
}
