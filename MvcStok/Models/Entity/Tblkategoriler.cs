using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // Bunu eklemelisin

namespace MvcStok.Models.Entity
{
    public partial class Tblkategoriler
    {
        public short KATEGORIID { get; set; }

        [Required(ErrorMessage = "Kategori adı boş olamaz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kategori adı 3 ile 50 karakter arasında olmalıdır.")]
        public string? KATEGORIAD { get; set; }

        public bool KATEGORIDURUM { get; set; }

        public virtual ICollection<Tblurunler> Tblurunlers { get; set; } = new List<Tblurunler>();
    }
}
