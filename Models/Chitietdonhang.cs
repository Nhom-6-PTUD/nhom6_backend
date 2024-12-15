using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Chitietdonhang
{
    public string Madonhang { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public int Soluong { get; set; }

    public virtual Donhang MadonhangNavigation { get; set; } = null!;

    public virtual Sanpham MaspNavigation { get; set; } = null!;
}
