using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Kategori
    {
        public int Id { get; set; }

        //Data annotations olarak geçiyor..Araştır!!
        [DisplayName("Kategorinin Adı")]
        [StringLength(maximumLength: 20, ErrorMessage = "en fazla 20 karakter girebilirsiniz.")]
        [Required(ErrorMessage ="Doldurulması gerek")]
        public string Ad { get; set; }
        
        [DisplayName("Kategorinin Açıklaması")]
        [Required(ErrorMessage = "Doldurulması gerek")]
        public string Aciklama { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}