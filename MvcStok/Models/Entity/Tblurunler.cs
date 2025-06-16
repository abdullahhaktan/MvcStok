using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // Validation için gerekli

namespace MvcStok.Models.Entity
{
    public partial class Tblurunler
    {
        public int URUNID { get; set; }

        [Required(ErrorMessage = "Ürün adı boş olamaz.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ürün adı 2 ile 100 karakter arasında olmalıdır.")]
        public string? URUNAD { get; set; }

        [StringLength(50, ErrorMessage = "Marka adı en fazla 50 karakter olabilir.")]
        public string? MARKA { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public short? URUNKATEGORI { get; set; }

        [Required(ErrorMessage = "Fiyat bilgisi zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal? FIYAT { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stok negatif olamaz.")]
        public byte? STOK { get; set; }

        public bool URUNDURUM { get; set; }

        public virtual ICollection<Tblsatislar> Tblsatislars { get; set; } = new List<Tblsatislar>();

        public virtual Tblkategoriler? UrunkategoriNavigation { get; set; }
    }
}
