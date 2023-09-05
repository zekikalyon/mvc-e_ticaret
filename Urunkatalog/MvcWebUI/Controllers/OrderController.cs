using MvcWebUI.Entity;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Siparisler.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                SiparisNo = i.SiparisNo,
                SiparisTarihi = i.SiparisTarihi,
                OrderState = i.OrderState,
                OdemeTutarı = i.OdemeTutarı,
                Count = i.Orderlines.Count
                
            }).OrderByDescending(i=>i.SiparisTarihi).ToList();
            
            
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Siparisler.Where(i => i.Id == id)
                   .Select(i => new OrderDetailsModel()
                   {
                       OrderId = i.Id,
                       SiparisNo = i.SiparisNo,
                       OdemeTutarı = i.OdemeTutarı,
                       SiparisTarihi = i.SiparisTarihi,
                       OrderState = i.OrderState,
                       AdresBasligi = i.AdresBasligi,
                       Adres = i.Adres,
                       Sehir = i.Sehir,
                       İlce = i.İlce,
                       Mahalle = i.Mahalle,
                       PostaKodu = i.PostaKodu,
                       Orderlines = i.Orderlines.Select(x => new OrderLineModel()
                       {
                           UrunId = x.UrunId,
                           UrunAdi = x.Urun.Ad,
                           Fotograf = x.Urun.Fotograf,
                           Adet = x.Adet,
                           Fiyat = x.Fiyat
                       }).ToList()
                   }).FirstOrDefault();

            return View(entity);

        }


        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Siparisler.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi.";
                return RedirectToAction("Details",new {id= OrderId });
            }

            return RedirectToAction("Index");
        }
    }
}