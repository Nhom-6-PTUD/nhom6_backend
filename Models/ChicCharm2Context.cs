using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CHIC_CHARM2.Models;

public partial class ChicCharm2Context : DbContext
{
    public ChicCharm2Context()
    {
    }

    public ChicCharm2Context(DbContextOptions<ChicCharm2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }

    public virtual DbSet<Chitietgiohang> Chitietgiohangs { get; set; }

    public virtual DbSet<Danhgium> Danhgia { get; set; }

    public virtual DbSet<Danhmucsp> Danhmucsps { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Thanhvien> Thanhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\PHG;Initial Catalog=CHIC_CHARM2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietdonhang>(entity =>
        {
            entity.HasKey(e => new { e.Madonhang, e.Masp }).HasName("PK__CHITIETD__43D03D388C28D7BA");

            entity.ToTable("CHITIETDONHANG");

            entity.Property(e => e.Madonhang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madonhang");
            entity.Property(e => e.Masp)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masp");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MadonhangNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.Madonhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDO__madon__49C3F6B7");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Chitietdonhangs)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHITIETDON__masp__4AB81AF0");
        });

        modelBuilder.Entity<Chitietgiohang>(entity =>
        {
            entity.HasKey(e => new { e.Magh, e.Masp }).HasName("PK__CHITIETG__4D830FA4B3E52941");

            entity.ToTable("CHITIETGIOHANG");

            entity.Property(e => e.Magh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("magh");
            entity.Property(e => e.Masp)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masp");
            entity.Property(e => e.Hinhanhsp)
                .HasColumnType("text")
                .HasColumnName("hinhanhsp");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MaghNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.Magh)
                .HasConstraintName("FK__CHITIETGIO__magh__4F7CD00D");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.Masp)
                .HasConstraintName("FK__CHITIETGIO__masp__5070F446");
        });

        modelBuilder.Entity<Danhgium>(entity =>
        {
            entity.HasKey(e => e.Madanhgia).HasName("PK__DANHGIA__7E089258C8F5E918");

            entity.ToTable("DANHGIA");

            entity.Property(e => e.Madanhgia)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madanhgia");
            entity.Property(e => e.Masp)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masp");
            entity.Property(e => e.Matv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("matv");
            entity.Property(e => e.Noidung)
                .HasMaxLength(1000)
                .HasColumnName("noidung");
            entity.Property(e => e.Xepsao).HasColumnName("xepsao");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DANHGIA__masp__5535A963");

            entity.HasOne(d => d.MatvNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Matv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DANHGIA__matv__5441852A");
        });

        modelBuilder.Entity<Danhmucsp>(entity =>
        {
            entity.HasKey(e => e.Madm).HasName("PK__DANHMUCS__7A21E020F6F79DFC");

            entity.ToTable("DANHMUCSP");

            entity.Property(e => e.Madm)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madm");
            entity.Property(e => e.Mota)
                .HasMaxLength(1000)
                .HasColumnName("mota");
            entity.Property(e => e.Tendanhmuc).HasMaxLength(255);
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.Madonhang).HasName("PK__DONHANG__74722A5F2E719EAB");

            entity.ToTable("DONHANG");

            entity.Property(e => e.Madonhang)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madonhang");
            entity.Property(e => e.Matv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("matv");
            entity.Property(e => e.Ngaydat)
                .HasColumnType("date")
                .HasColumnName("ngaydat");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(30)
                .HasColumnName("trangthai");

            entity.HasOne(d => d.MatvNavigation).WithMany(p => p.Donhangs)
                .HasForeignKey(d => d.Matv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DONHANG__matv__46E78A0C");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.Magh).HasName("PK__GIOHANG__7A2118C38335FE8B");

            entity.ToTable("GIOHANG");

            entity.Property(e => e.Magh)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("magh");
            entity.Property(e => e.Ngaythem)
                .HasColumnType("date")
                .HasColumnName("ngaythem");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.Tendangnhap).HasName("PK__NGUOIDUN__CE900A1F51051B1E");

            entity.ToTable("NGUOIDUNG");

            entity.Property(e => e.Tendangnhap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tendangnhap");
            entity.Property(e => e.Loainguoidung)
                .HasMaxLength(50)
                .HasColumnName("loainguoidung");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(255)
                .HasColumnName("matkhau");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manv).HasName("PK__NHANVIEN__7A21B37D21EE9B29");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Manv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("manv");
            entity.Property(e => e.Anhdaidien).HasColumnType("text");
            entity.Property(e => e.Chucvu).HasMaxLength(100);
            entity.Property(e => e.Duong).HasMaxLength(100);
            entity.Property(e => e.Hoten).HasMaxLength(100);
            entity.Property(e => e.Quan).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Sonha).HasMaxLength(50);
            entity.Property(e => e.Tendangnhap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tendangnhap");
            entity.Property(e => e.Thanhpho).HasMaxLength(100);

            entity.HasOne(d => d.TendangnhapNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Tendangnhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHANVIEN_NGUOIDUNG");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masp).HasName("PK__SANPHAM__7A2176721C32B264");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masp)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masp");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Hinhchinh)
                .HasColumnType("text")
                .HasColumnName("hinhchinh");
            entity.Property(e => e.Madm)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("madm");
            entity.Property(e => e.Mota)
                .HasMaxLength(1000)
                .HasColumnName("mota");
            entity.Property(e => e.Tensp)
                .HasMaxLength(255)
                .HasColumnName("tensp");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(30)
                .HasColumnName("tinhtrang");

            entity.HasOne(d => d.MadmNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Madm)
                .HasConstraintName("FK__SANPHAM__madm__4316F928");
        });

        modelBuilder.Entity<Thanhvien>(entity =>
        {
            entity.HasKey(e => e.Matv).HasName("PK__THANHVIE__7A217E1DF74C034E");

            entity.ToTable("THANHVIEN");

            entity.Property(e => e.Matv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("matv");
            entity.Property(e => e.Duong).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Hoten).HasMaxLength(100);
            entity.Property(e => e.Quan).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Sonha).HasMaxLength(100);
            entity.Property(e => e.Tendangnhap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tendangnhap");
            entity.Property(e => e.ThanhPho).HasMaxLength(100);

            entity.HasOne(d => d.TendangnhapNavigation).WithMany(p => p.Thanhviens)
                .HasForeignKey(d => d.Tendangnhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_THANHVIEN_NGUOIDUNG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
