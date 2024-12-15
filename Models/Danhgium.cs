using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Danhgium
{
    public string Madanhgia { get; set; } = null!;

    public string Matv { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public string? Noidung { get; set; }

    public int? Xepsao { get; set; }

    public virtual Sanpham MaspNavigation { get; set; } = null!;

    public virtual Thanhvien MatvNavigation { get; set; } = null!;
}
