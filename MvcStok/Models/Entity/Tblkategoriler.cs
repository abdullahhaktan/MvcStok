using System;
using System.Collections.Generic;

namespace MvcStok.Models.Entity;

public partial class Tblkategoriler
{
    public short Kategotriid { get; set; }

    public string? Kategoriad { get; set; }
    public bool KATEGORIDURUM { get; set; }

    public virtual ICollection<Tblurunler> Tblurunlers { get; set; } = new List<Tblurunler>();
}
