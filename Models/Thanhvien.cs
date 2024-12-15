using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Thanhvien
{
    public string Matv { get; set; } = null!;

    public string Tendangnhap { get; set; } = null!;

    public string Hoten { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? Sonha { get; set; }

    public string? Duong { get; set; }

    public string? Quan { get; set; }

    public string? ThanhPho { get; set; }

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual Nguoidung TendangnhapNavigation { get; set; } = null!;
}
