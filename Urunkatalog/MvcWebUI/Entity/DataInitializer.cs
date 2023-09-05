using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori() { Ad = "Kamera", Aciklama="Kamera ürünleri" },
                new Kategori() { Ad = "Bilgisayar", Aciklama="Bilgisayar ürünleri" },
                new Kategori() { Ad = "Elektronik cihazlar", Aciklama="Elektronik ürünleri" },
                new Kategori() { Ad = "Telefon", Aciklama="Telefon ürünleri" },
                new Kategori() { Ad = "Beyaz Eşya", Aciklama="Beyaz Eşya ürünleri" }
            };
            foreach (var kategori in kategoriler)
            {
                context.Kategoriler.Add(kategori);
            }
            context.SaveChanges();
            List<Urun> yeniurun = new List<Urun>()
            {
                
                new Urun() { Ad="Apple IPhone 10 64GB",Aciklama="IPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone TelefonIPhone Telefon",Fiyat=20000,Stok=51,Onaylimi=true,KategoriId=4,Anasayfa=true,Fotograf="telefon.jpg"},
                new Urun() { Ad="Apple IPhone 10 64GB",Aciklama="IPhone Telefon",Fiyat=20000,Stok=51,Onaylimi=true,KategoriId=4,Anasayfa=true,Fotograf="telefon.jpg"},
                new Urun() { Ad="Apple IPhone 11 64GB",Aciklama="IPhone Telefon",Fiyat=22000,Stok=53,Onaylimi=false,KategoriId=4,Fotograf="telefon.jpg"},
                new Urun() { Ad="Apple IPhone 10 128GB",Aciklama="IPhone Telefon",Fiyat=25000,Stok=76,Onaylimi=true,KategoriId=4,Anasayfa=true,Fotograf="telefon.jpg"},
                new Urun() { Ad="Apple IPhone 11 128GB",Aciklama="IPhone Telefon",Fiyat=30000,Stok=120,Onaylimi=true,KategoriId=4,Fotograf="telefon.jpg"},
                new Urun() { Ad="Monster Abra A5 V19.2.1 15,6 Oyun Bilgisayarı",Aciklama="Oyun Bilgisayarı",Fiyat=21000,Stok=25,Onaylimi=true,KategoriId=2,Anasayfa=true,Fotograf="pc.jpg"},
                new Urun() { Ad="Monster Abra A5 V19.3.4 15,6 Oyun Bilgisayarı",Aciklama="Oyun Bilgisayarı",Fiyat=25000,Stok=25,Onaylimi=true,KategoriId=2, Anasayfa = true,Fotograf="pc.jpg"},
                new Urun() { Ad="Monster Abra A5 V19.4.5 15,6 Oyun Bilgisayarı",Aciklama="Oyun Bilgisayarı",Fiyat=29000,Stok=25,Onaylimi=true,KategoriId=2,Fotograf="pc.jpg"},
                new Urun() { Ad="Vestel c275 Çamaşır Makinesi",Aciklama="Çamaşır Makinesi",Fiyat=18000,Stok=250,Onaylimi=true,KategoriId=5,Fotograf="camasir.jpg"},
                new Urun() { Ad="Vestfrost VF 1268 300 lt Statik Buzdolabı",Aciklama="Buzdolabı",Fiyat=8000,Stok=39,Onaylimi=true,KategoriId=5, Anasayfa = true,Fotograf="buzdolabi.jpg"},
                new Urun() { Ad="Altus AL 403 MP Bulaşık Makinesi",Aciklama="Bulaşık Makinesi",Fiyat=7000,Stok=374,Onaylimi=true,KategoriId=5, Anasayfa = true,Fotograf="bulasik.jpg"},
                new Urun() { Ad="Canon XA55 UHD 4K30 Video Kamera",Aciklama="Kamera",Fiyat=50000,Stok=374,Onaylimi=true,KategoriId=1,Fotograf="camera.jpg"},
                new Urun() { Ad="Canon Battery Charger LC-E17E",Aciklama="Kamera için sarj aleti",Fiyat=1000,Stok=2952,Onaylimi=true,KategoriId=1, Anasayfa = true,Fotograf="camera.jpg"}

            };
            foreach (var urun in yeniurun)
            {
                context.Urunler.Add(urun);
            }
            context.SaveChanges();



            base.Seed(context);
        }
    }
}