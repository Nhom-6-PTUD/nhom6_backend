using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Nhanvien
{
    public string Manv { get; set; } = null!;

    public string Tendangnhap { get; set; } = null!;

    public string Hoten { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Chucvu { get; set; }

    public string? Anhdaidien { get; set; }

    public string? Sonha { get; set; }

    public string? Duong { get; set; }

    public string? Quan { get; set; }

    public string? Thanhpho { get; set; }

    public virtual Nguoidung TendangnhapNavigation { get; set; } = null!;
}
