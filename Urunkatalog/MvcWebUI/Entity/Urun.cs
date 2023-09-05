using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Urun
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Ad { get; set; }

        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }

        [DisplayName("Fiyat")]
        public double Fiyat { get; set; }
        
        [DisplayName("Stok Sayısı")]
        public int Stok { get; set; }
        public string Fotograf { get; set; }
        public bool Anasayfa { get; set; }
        public bool Onaylimi { get; set; }


        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}