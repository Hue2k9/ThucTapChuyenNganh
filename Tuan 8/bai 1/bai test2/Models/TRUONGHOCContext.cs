using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace bai_test2.Models
{
    public partial class TRUONGHOCContext : DbContext
    {
        public TRUONGHOCContext()
        {
        }

        public TRUONGHOCContext(DbContextOptions<TRUONGHOCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Giaovien> Giaoviens { get; set; }
        public virtual DbSet<Hocsinh> Hocsinhs { get; set; }
        public virtual DbSet<Lophoc> Lophocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RAK8B1P;Initial Catalog=TRUONGHOC;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Giaovien>(entity =>
            {
                entity.HasKey(e => e.Magv)
                    .HasName("PK__GIAOVIEN__603F38B1BB593934");

                entity.ToTable("GIAOVIEN");

                entity.Property(e => e.Magv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAGV")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Luong)
                    .HasColumnType("money")
                    .HasColumnName("LUONG");

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Ten)
                    .HasMaxLength(30)
                    .HasColumnName("TEN");
            });

            modelBuilder.Entity<Hocsinh>(entity =>
            {
                entity.HasKey(e => e.Mahs)
                    .HasName("PK__HOCSINH__603F20DD7CDCB3A3");

                entity.ToTable("HOCSINH");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAHS")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Diemtb).HasColumnName("DIEMTB");

                entity.Property(e => e.Nam)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("NAM")
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Ten)
                    .HasMaxLength(30)
                    .HasColumnName("TEN");
            });

            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LOPHOC");

                entity.Property(e => e.Malop)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MALOP")
                    .IsFixedLength(true);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tenlop)
                    .HasMaxLength(30)
                    .HasColumnName("TENLOP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
