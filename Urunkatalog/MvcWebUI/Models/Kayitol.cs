using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class Kayitol
    {
        [Required]
        [DisplayName("Adınız")]
        public string Ad { get; set; }
        
        [Required]
        [DisplayName("Soyadınız")]
        public string Soyad { get; set; }
        
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        
        [Required]
        [DisplayName("E-posta")]
        [EmailAddress(ErrorMessage ="Lütfen doğru bir adres paylaşınız!")]
        public string Email { get; set; }
        
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifrelerin uyuşması lazım!")]
        public string RePassword { get; set; }
    }
}