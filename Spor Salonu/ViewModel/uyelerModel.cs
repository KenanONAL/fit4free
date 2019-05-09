using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spor_Salonu.ViewModel
{
    public class uyelerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Üye Adı Soyadı Giriniz!")]
        [Display(Name = "Üye Adı Soyadı")]
        [StringLength(50, ErrorMessage = "Üye Adı Soyadı En Fazla 50 Karekter Olmalıdır!")]
        public string uye_adisoyadi { get; set; }
        [Required(ErrorMessage = "Telefon Numarası Giriniz!")]
        [Display(Name = "Telefon Numarası")]
        [StringLength(15, ErrorMessage = "Telefon Numarası En Fazla 15 Karekter Olmalıdır!")]
        public string telefon { get; set; }
        [Required(ErrorMessage = "Mail Adresi Giriniz Giriniz!")]
        [Display(Name = "Mail Adresi")]
        [StringLength(50, ErrorMessage = "Mail Adresi En Fazla 50 Karekter Olmalıdır!")]
        public string mail { get; set; }
        [Required(ErrorMessage = "Üyelik Başlangıç Tarihi Giriniz!")]
        [Display(Name = "Üyelik Başlangıç Tarihi")]
        [StringLength(50, ErrorMessage = "Üyelik Başlangıç Tarihi En Fazla 50 Karekter Olmalıdır!")]
        public System.DateTime uyelik_baslangic_tarihi { get; set; }
        [Required(ErrorMessage = "Üyelik Bitiş Tarihi Giriniz!")]
        [Display(Name = "Üyelik Bitiş Tarihi")]
        public System.DateTime uyelik_bitis_tarihi { get; set; }
        [Required(ErrorMessage = "Üyelik Ücreti Giriniz!")]
        [Display(Name = "Üyelik Ücreti")]
        [StringLength(50, ErrorMessage = "Üyelik Ücreti En Fazla 10 Karekter Olmalıdır!")]
        public int toplam_ucret { get; set; }
        [Required(ErrorMessage = "Ödenen Ücret Giriniz!")]
        [Display(Name = "Ödenen Ücret")]
        [StringLength(50, ErrorMessage = "Ödenen Ücret En Fazla 10 Karekter Olmalıdır!")]
        public int odenen_ucret { get; set; }
        [Required(ErrorMessage = "Kalan Ücret Giriniz!")]
        [Display(Name = "Kalan Ücret")]
        [StringLength(50, ErrorMessage = "Kalan Ücret En Fazla 10 Karekter Olmalıdır!")]
        public int kalan_ucret { get; set; }
    }
}