using MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }

        public void UrunEkle(Urun urun,int adet)
        {
            var yeni = _cartLines.FirstOrDefault(i=>i.Urun.Id==urun.Id);
            if(yeni==null)
            {
                _cartLines.Add(new CartLine() { Urun = urun , Adet=adet});
            }
            else
            {
                yeni.Adet+=adet;
            }
        }

        public void UrunSil(Urun urun)
        {
            _cartLines.RemoveAll(i => i.Urun.Id == urun.Id);
        }
        public double TotalUcret()
        {
            return _cartLines.Sum(i => i.Urun.Fiyat * i.Adet);
        }

        public void Clear()
        {
            _cartLines.Clear();
        }
    }
    public class CartLine
    {
        public Urun Urun { get; set; }
        public int Adet { get; set; }
    }
}