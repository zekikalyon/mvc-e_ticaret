using MvcWebUI.Entity;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == Id);

            if (urun != null)
            {
                GetCart().UrunEkle(urun, 1);
            }



            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var urun = db.Urunler.FirstOrDefault(i => i.Id == Id);

            if (urun != null)
            {
                GetCart().UrunSil(urun);
            }



            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shipping)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır!");
            }

            if (ModelState.IsValid)
            {
                //Siparişi veritabanına kaydetmek lazım..
                //Cart'i sıfırla
                SaveOrder(cart, shipping);

                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shipping);
            }
            
        }

        private void SaveOrder(Cart cart, ShippingDetails shipping)
        {
            var order = new Order();

            order.SiparisNo = "A"+(new Random()).Next(111111, 9999999).ToString();
            order.OdemeTutarı = cart.TotalUcret();
            order.SiparisTarihi = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            
            order.Username = User.Identity.Name;
            order.AdresBasligi = shipping.AdresBasligi;
            order.Adres = shipping.Adres;
            order.Sehir = shipping.Sehir;
            order.İlce = shipping.İlce;
            order.Mahalle = shipping.Mahalle;
            order.PostaKodu = shipping.PostaKodu;

            order.Orderlines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                OrderLine orderLine = new OrderLine();
                orderLine.Adet = pr.Adet;
                orderLine.Fiyat = pr.Adet*pr.Urun.Fiyat;
                orderLine.UrunId = pr.Urun.Id;

                order.Orderlines.Add(orderLine);
            }

            db.Siparisler.Add(order);
            db.SaveChanges();


        }
    }
}