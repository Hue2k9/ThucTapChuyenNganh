using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTL_BookStore.Models
{
    public partial class ThucTapChuyenNganhHTTTContext : DbContext
    {
        public ThucTapChuyenNganhHTTTContext()
        {
        }

        public ThucTapChuyenNganhHTTTContext(DbContextOptions<ThucTapChuyenNganhHTTTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-56A5JQ8;Initial Catalog=ThucTapChuyenNganhHTTT;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E046F60DC3");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(10)
                    .HasColumnName("MaHD")
                    .IsFixedLength(true);

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.PtgiaoHang)
                    .HasMaxLength(50)
                    .HasColumnName("PTGiaoHang");

                entity.Property(e => e.PtvanChuyen)
                    .HasMaxLength(50)
                    .HasColumnName("PTVanChuyen");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.Property(e => e.ThoiGianMua).HasMaxLength(30);

                entity.Property(e => e.TrangThaiDon).HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_HD_NV");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_HD_SanPham");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A67C91ED0");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(30);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SoDt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SoDT")
                    .IsFixedLength(true);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(30)
                    .HasColumnName("TenNV");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CBDA08616");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.BaoQuan).HasMaxLength(100);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.Property(e => e.GioiThieu).HasMaxLength(100);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenDn)
                    .HasName("PK__TaiKhoan__4CF96559DCF109E8");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenDn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TenDN")
                    .IsFixedLength(true);

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PhanQuyen).HasMaxLength(10);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_TK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
