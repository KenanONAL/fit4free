using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spor_Salonu.ViewModel
{
    public class iletisimModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Adınızı Giriniz!")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Adınız En Fazla 50 Karekter Olmalıdır!")]
        public string ad { get; set; }
        [Required(ErrorMessage = "Soyadınızı Giriniz!")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Soyadınız En Fazla 50 Karekter Olmalıdır!")]
        public string soyad { get; set; }
        [Required(ErrorMessage = "Mail Adresiniz Giriniz!")]
        [Display(Name = "Mail Adresi")]
        [StringLength(50, ErrorMessage = "Mail Adresiniz En Fazla 50 Karekter Olmalıdır!")]
        public string mail { get; set; }
        [Required(ErrorMessage = "Konu Giriniz!")]
        [Display(Name = "Konu")]
        [StringLength(50, ErrorMessage = "Konu En Fazla 50 Karekter Olmalıdır!")]
        public string konu { get; set; }
        [Required(ErrorMessage = "Mesaj Giriniz!")]
        [Display(Name = "Mesaj")]
        [StringLength(500, ErrorMessage = "Mesaj En Fazla 500 Karekter Olmalıdır!")]
        public string mesaj { get; set; }
        public System.DateTime tarih { get; set; }
        public int okundu_bilgisi { get; set; }
    }
}