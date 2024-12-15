using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Sanpham
{
    public string Masp { get; set; } = null!;

    public string Tensp { get; set; } = null!;

    public int Dongia { get; set; }

    public string? Mota { get; set; }

    public string Tinhtrang { get; set; } = null!;

    public string? Hinhchinh { get; set; }

    public string? Madm { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();

    public virtual Danhmucsp? MadmNavigation { get; set; }
}
