using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen adres tanımını giriniz!")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen adres bilgisini giriniz!")]

        
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen şehir bilgisini giriniz!")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen ilçeyi giriniz!")] 
        public string İlce { get; set; }
        [Required(ErrorMessage = "Lütfen mahelle bilgisini giriniz!")] 
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

    }
}