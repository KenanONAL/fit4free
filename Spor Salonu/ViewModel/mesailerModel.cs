using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spor_Salonu.ViewModel
{
    public class mesailerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ay Bilgisi Giriniz!")]
        [Display(Name = "Ay")]
        [StringLength(2, ErrorMessage = "Ay Bilgisi Maksimum 2 karekter olmalıdır!")]
        public string Ay { get; set; }
        [Required(ErrorMessage = "Gün Bilgisi Giriniz!")]
        [Display(Name = "Gün Bilgisi")]
        [StringLength(2, ErrorMessage = "Gün Bilgisi En Fazla 2 Karekter Olmalıdır!")]
        public string Gun { get; set; }
        [Required(ErrorMessage = "Saat Bilgisi Giriniz!")]
        [Display(Name = "Saat Bilgisi")]
        [StringLength(2, ErrorMessage = "Saat Bilgisi En Fazla 2 Karekter Olmalıdır!")]
        public string Saat { get; set; }
        
    }
}