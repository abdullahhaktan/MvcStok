using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // Validation için gerekli

namespace MvcStok.Models.Entity
{
    public partial class Tblmusteriler
    {
        public int MUSTERIID { get; set; }

        [Required(ErrorMessage = "Müşteri adı boş olamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Müşteri adı 2 ile 50 karakter arasında olmalıdır.")]
        public string? MUSTERIAD { get; set; }

        [Required(ErrorMessage = "Müşteri soyadı boş olamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Müşteri soyadı 2 ile 50 karakter arasında olmalıdır.")]
        public string? MUSTERISOYAD { get; set; }

        public virtual ICollection<Tblsatislar> Tblsatislars { get; set; } = new List<Tblsatislar>();
    }
}
