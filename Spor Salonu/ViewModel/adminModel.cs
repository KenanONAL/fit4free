using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spor_Salonu.ViewModel
{
    public class adminModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz!")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50, ErrorMessage = "Kullanıcı En Fazla 50 Karekter Olmalıdır!")]
        public string kullanici_adi { get; set; }
        [Required(ErrorMessage = "Şifre Giriniz!")]
        [Display(Name = "Şifre")]
        [StringLength(50, ErrorMessage = "Şifre En Fazla 50 Karekter Olmalıdır!")]
        public string sifre { get; set; }
    }
}