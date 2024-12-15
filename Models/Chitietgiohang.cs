using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Chitietgiohang
{
    public string Magh { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public int Soluong { get; set; }

    public string? Hinhanhsp { get; set; }

    public virtual Giohang MaghNavigation { get; set; } = null!;

    public virtual Sanpham MaspNavigation { get; set; } = null!;
}
