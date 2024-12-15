using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Danhmucsp
{
    public string Madm { get; set; } = null!;

    public string Tendanhmuc { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
