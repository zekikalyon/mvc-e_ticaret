using MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }

        public string Username { get; set; }
        public string SiparisNo { get; set; }

        public double OdemeTutarı { get; set; }
        public DateTime SiparisTarihi { get; set; }

        public EnumOrderState OrderState { get; set; }

        
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string İlce { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }


        public List<OrderLineModel> Orderlines { get; set; }
    }
    public class OrderLineModel
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string Fotograf { get; set; }
        public int Adet { get; set; }
        public double Fiyat { get; set; }
    }
}
