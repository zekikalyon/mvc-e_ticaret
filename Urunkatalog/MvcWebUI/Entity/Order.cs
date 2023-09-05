using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }

        public double OdemeTutarı { get; set; }
        public DateTime SiparisTarihi { get; set; }

        public EnumOrderState OrderState { get; set; }

        public string Username { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }  
        public string Sehir { get; set; }
        public string İlce { get; set; }   
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }


        public List<OrderLine> Orderlines { get; set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int SiparisId { get; set; }
        public virtual Order Siparis { get; set; }

        public int Adet { get; set; }
        public double Fiyat { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
    }
}