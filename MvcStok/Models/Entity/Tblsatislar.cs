using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // Validation için gerekli

namespace MvcStok.Models.Entity
{
    public partial class Tblsatislar
    {
        public int SATISID { get; set; }

        [Required(ErrorMessage = "Ürün seçimi zorunludur.")]
        public int? URUN { get; set; }

        [Required(ErrorMessage = "Müşteri seçimi zorunludur.")]
        public int? MUSTERI { get; set; }

        [Required(ErrorMessage = "Adet bilgisi zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Adet 1 veya daha fazla olmalıdır.")]
        public byte? ADET { get; set; }

        [Required(ErrorMessage = "Fiyat bilgisi zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal? FIYAT { get; set; }

        public virtual Tblmusteriler? MusteriNavigation { get; set; }

        public virtual Tblurunler? UrunNavigation { get; set; }
    }
}
