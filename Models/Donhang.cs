using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Donhang
{
    public string Madonhang { get; set; } = null!;

    public DateTime Ngaydat { get; set; }

    public string Trangthai { get; set; } = null!;

    public int Tongtien { get; set; }

    public string Matv { get; set; } = null!;

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Thanhvien MatvNavigation { get; set; } = null!;
}
