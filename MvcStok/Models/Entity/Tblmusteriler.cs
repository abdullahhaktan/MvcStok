using System;
using System.Collections.Generic;

namespace MvcStok.Models.Entity;

public partial class Tblmusteriler
{
    public int Musteriid { get; set; }

    public string? Musteriad { get; set; }

    public string? Musterisoyad { get; set; }

    public virtual ICollection<Tblsatislar> Tblsatislars { get; set; } = new List<Tblsatislar>();
}
