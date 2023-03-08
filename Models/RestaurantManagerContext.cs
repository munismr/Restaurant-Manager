using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RestaurantManager.Modes
{
    public partial class RestaurantManagerContext : DbContext
    {
        public RestaurantManagerContext()
        {
        }

        public RestaurantManagerContext(DbContextOptions<RestaurantManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<BoPhan> BoPhans { get; set; }
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual DbSet<ChiTietHoaDonXuat> ChiTietHoaDonXuats { get; set; }
        public virtual DbSet<DinhLuong> DinhLuongs { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<HoaDonXuat> HoaDonXuats { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomMonAn> NhomMonAns { get; set; }
        public virtual DbSet<NhomNguyenLieu> NhomNguyenLieus { get; set; }
        public virtual DbSet<QuyenForm> QuyenForms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AT;Initial Catalog=RestaurantManager;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ban>(entity =>
            {
                entity.HasKey(e => e.MaBan)
                    .HasName("PK__Ban__3520ED6C4CCA90B9");

                entity.ToTable("Ban");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenBan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BoPhan>(entity =>
            {
                entity.HasKey(e => e.MaBoPhan)
                    .HasName("PK__BoPhan__8CEC11BCC3DFB200");

                entity.ToTable("BoPhan");

                entity.Property(e => e.TenBoPhan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaChiTietHoaDonNhap)
                    .HasName("PK__ChiTietH__7801869ACB06A5EC");

                entity.ToTable("ChiTietHoaDonNhap");

                entity.HasOne(d => d.MaHoaDonNhapNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaHoaDonNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonNhap_HoaDonNhap");

                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonNhap_NguyenLieu");
            });

            modelBuilder.Entity<ChiTietHoaDonXuat>(entity =>
            {
                entity.HasKey(e => e.MaChiTietHoaDonXuat)
                    .HasName("PK__ChiTietH__0742A74E95FF1BD0");

                entity.ToTable("ChiTietHoaDonXuat");

                entity.HasOne(d => d.MaHoaDonXuatNavigation)
                    .WithMany(p => p.ChiTietHoaDonXuats)
                    .HasForeignKey(d => d.MaHoaDonXuat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonXuat_HoaDonXuat");

                entity.HasOne(d => d.MaMonAnNavigation)
                    .WithMany(p => p.ChiTietHoaDonXuats)
                    .HasForeignKey(d => d.MaMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonXuat_MonAn");
            });

            modelBuilder.Entity<DinhLuong>(entity =>
            {
                entity.HasKey(e => e.MaDinhLuong)
                    .HasName("PK__DinhLuon__D58BD6DF08D113C9");

                entity.ToTable("DinhLuong");

                entity.HasOne(d => d.MaMonAnNavigation)
                    .WithMany(p => p.DinhLuongs)
                    .HasForeignKey(d => d.MaMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DinhLuong_MonAn");

                entity.HasOne(d => d.MaMonAn1)
                    .WithMany(p => p.DinhLuongs)
                    .HasForeignKey(d => d.MaMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DinhLuong_NguyenLieu");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.HasKey(e => e.TenForm)
                    .HasName("PK__Form__EF8E70D1044239FD");

                entity.ToTable("Form");

                entity.Property(e => e.TenForm).HasMaxLength(50);
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonNhap)
                    .HasName("PK__HoaDonNh__448838B54EFD5F0D");

                entity.ToTable("HoaDonNhap");

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonNhap_NhaCungCap");

                entity.HasOne(d => d.MaNhanVien1)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonNhap_NhanVien");
            });

            modelBuilder.Entity<HoaDonXuat>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonXuat)
                    .HasName("PK__HoaDonXu__FCBAF59BAAA7DA44");

                entity.ToTable("HoaDonXuat");

                entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDonXuats)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonXuat_KhachHang");

                entity.HasOne(d => d.MaKhachHang1)
                    .WithMany(p => p.HoaDonXuats)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonXuat_NhanVien");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDonXuats)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonXuat_Ban");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__88D2F0E59172FA8E");

                entity.ToTable("KhachHang");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MonAn>(entity =>
            {
                entity.HasKey(e => e.MaMonAn)
                    .HasName("PK__MonAn__B1171625B22CDF0C");

                entity.ToTable("MonAn");

                entity.Property(e => e.DonViTinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenMonAn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNhomMonAnNavigation)
                    .WithMany(p => p.MonAns)
                    .HasForeignKey(d => d.MaNhomMonAn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MonAn_NhomMonAn");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung)
                    .HasName("PK__NguoiDun__C539D762FEBF097E");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenNguoiDung)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.HasKey(e => e.MaNguyenLieu)
                    .HasName("PK__NguyenLi__C7519355C71E3CF4");

                entity.ToTable("NguyenLieu");

                entity.Property(e => e.DonViTinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenNguyenLieu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNhomNguyenLieuNavigation)
                    .WithMany(p => p.NguyenLieus)
                    .HasForeignKey(d => d.MaNhomNguyenLieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NguyenLieu_NhomNguyenLieu");
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap)
                    .HasName("PK__NhaCungC__53DA9205E7AFA95E");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenNhaCungCap)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA475A76634F");

                entity.ToTable("NhanVien");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenNhanVien)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaBoPhanNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaBoPhan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhanVien_BoPhan");
            });

            modelBuilder.Entity<NhomMonAn>(entity =>
            {
                entity.HasKey(e => e.MaNhomMonAn)
                    .HasName("PK__NhomMonA__BABD51383E741471");

                entity.ToTable("NhomMonAn");

                entity.Property(e => e.TenNhomMonAn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NhomNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.MaNhomNguyenLieu)
                    .HasName("PK__NhomNguy__F2E10C6F9B8EA5DA");

                entity.ToTable("NhomNguyenLieu");

                entity.Property(e => e.TenNhomNguyenLieu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QuyenForm>(entity =>
            {
                entity.HasKey(e => e.MaQuyenForm)
                    .HasName("PK__QuyenFor__F0E8C8A3C061DDEC");

                entity.ToTable("QuyenForm");

                entity.Property(e => e.TenForm)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.QuyenForms)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuyenForm_NguoiDung");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.QuyenForms)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuyenForm_NhanVien");

                entity.HasOne(d => d.TenFormNavigation)
                    .WithMany(p => p.QuyenForms)
                    .HasForeignKey(d => d.TenForm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuyenForm_Form");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
