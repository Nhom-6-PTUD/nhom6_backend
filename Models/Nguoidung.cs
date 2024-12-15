using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Nguoidung
{
    public string Tendangnhap { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string Loainguoidung { get; set; } = null!;

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();

    public virtual ICollection<Thanhvien> Thanhviens { get; set; } = new List<Thanhvien>();
}
