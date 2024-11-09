using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BuenosDias.DALL.Models
{
    using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
    public partial class BuenosDiasModelDB : DbContext
    {
        public BuenosDiasModelDB()
            : base("name=BuenosDiasModelDB2")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<CacLoaiQuyen> CacLoaiQuyens { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<ThongTinCaNhan> ThongTinCaNhans { get; set; }
        public virtual DbSet<User_> User_ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.IDBaiViet)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .Property(e => e.MaKhoaHoc)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .HasMany(e => e.HinhAnhs)
                .WithRequired(e => e.BaiViet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaiViet>()
                .HasMany(e => e.ChuDes)
                .WithMany(e => e.BaiViets)
                .Map(m => m.ToTable("DanhSachChuDe").MapLeftKey("IDBaiViet").MapRightKey("MaChuDe"));

            modelBuilder.Entity<CacLoaiQuyen>()
                .Property(e => e.MaLoaiQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<CacLoaiQuyen>()
                .HasMany(e => e.User_)
                .WithMany(e => e.CacLoaiQuyens)
                .Map(m => m.ToTable("PermittedPermission").MapLeftKey("MaLoaiQuyen").MapRightKey("UserID"));

            modelBuilder.Entity<ChuDe>()
                .Property(e => e.TenChuDe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnh>()
                .Property(e => e.MaHinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnh>()
                .Property(e => e.LoaiHinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnh>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnh>()
                .Property(e => e.IDBaiViet)
                .IsUnicode(false);

            modelBuilder.Entity<HinhAnh>()
                .Property(e => e.MaKhoaHoc)
                .IsUnicode(false);

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.MaKhoaHoc)
                .IsUnicode(false);

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.KhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.HinhAnhs)
                .WithRequired(e => e.KhoaHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoaHoc>()
                .HasMany(e => e.User_1)
                .WithMany(e => e.KhoaHocs1)
                .Map(m => m.ToTable("DanhSachDangKyKhoaHoc").MapLeftKey("MaKhoaHoc").MapRightKey("UserID"));

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.eMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinCaNhan>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.User_)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.HinhAnhs)
                .WithRequired(e => e.User_)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_>()
                .HasMany(e => e.KhoaHocs)
                .WithRequired(e => e.User_)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_>()
                .HasOptional(e => e.ThongTinCaNhan)
                .WithRequired(e => e.User_);
        }
    }
}
