using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class Urunmodel
    {
        public int Id { get; set; }

        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public double Fiyat { get; set; }
        public int Stok { get; set; }
        public string Fotograf { get; set; }
        public bool Anasayfa { get; set; }
        public bool Onaylimi { get; set; }

        public int KategoriId { get; set; }
    }
}