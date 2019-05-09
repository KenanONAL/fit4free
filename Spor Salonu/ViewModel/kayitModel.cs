using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spor_Salonu.ViewModel
{
    public class kayitModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Soyad Giriniz!")]
        [Display(Name = "Ad Soyad")]
        [StringLength(50, ErrorMessage = "Ad Soyad En Fazla 50 Karekter Olmalıdır!")]
        public string adsoyad { get; set; }
        [Required(ErrorMessage = "Mail Giriniz!")]
        [Display(Name = "Mail")]
        [StringLength(50, ErrorMessage = "Mail Adresi En Fazla 50 Karekter Olmalıdır!")]
        public string mail { get; set; }
        [Required(ErrorMessage = "Telefon Giriniz!")]
        [Display(Name = "Telefon")]
        [StringLength(50, ErrorMessage = "Telefon En Fazla 50 Karekter Olmalıdır!")]
        public string telefon { get; set; }
        [Required(ErrorMessage = "Üyelik Süresi Giriniz!")]
        [Display(Name = "Üyelik Süresi")]
        [StringLength(50, ErrorMessage = "Üyelik Süresi En Fazla 50 Karekter Olmalıdır!")]
        public string uyelik_suresi { get; set; }
        public System.DateTime tarih { get; set; }
    }
}