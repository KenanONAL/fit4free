using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spor_Salonu.ViewModel
{
    public class duyurularModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Duyuru Adı Giriniz!")]
        [Display(Name ="Duyuru Adı")]
        [StringLength(50,ErrorMessage ="Adı Soyadı En Fazla 50 Karekter Olmalıdır!")]
        public string duyuru_adi { get; set; }
        [Required(ErrorMessage = "Duyuru Konusu Giriniz!")]
        [Display(Name = "Duyuru Konusu")]
        [StringLength(500, ErrorMessage = "Duyuru Konusu En Fazla 500 Karekter Olmalıdır!")]
        public string duyuru_konu { get; set; }
        public System.DateTime tarih { get; set; }
    }
}