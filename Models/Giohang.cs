using System;
using System.Collections.Generic;

namespace CHIC_CHARM2.Models;

public partial class Giohang
{
    public string Magh { get; set; } = null!;

    public DateTime Ngaythem { get; set; }

    public virtual ICollection<Chitietgiohang> Chitietgiohangs { get; set; } = new List<Chitietgiohang>();
}
