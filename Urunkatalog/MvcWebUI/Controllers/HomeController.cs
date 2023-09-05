using MvcWebUI.Entity;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext context= new DataContext();
        public ActionResult Index()
        {
            var urunler = context.Urunler.Where(i => i.Anasayfa && i.Onaylimi)
                .Select(i => new Urunmodel()
                {
                    Id = i.Id,
                    Ad = i.Ad,
                    Aciklama = i.Aciklama.Length>50? i.Aciklama.Substring(0,47)+"...":i.Aciklama,
                    Fiyat = i.Fiyat,
                    Stok = i.Stok,
                    Fotograf = i.Fotograf,
                    KategoriId = i.KategoriId
                    
                }).ToList();
            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(context.Urunler.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = context.Urunler.Where(i =>  i.Onaylimi)
                .Select(i => new Urunmodel()
                {
                    Id = i.Id,
                    Ad = i.Ad,
                    Aciklama = i.Aciklama.Length > 50 ? i.Aciklama.Substring(0, 47) + "..." : i.Aciklama,
                    Fiyat = i.Fiyat,
                    Stok = i.Stok,
                    Fotograf = i.Fotograf,
                    KategoriId = i.KategoriId

                }).AsQueryable();
            if(id !=null)
            {
                urunler = urunler.Where(i => i.KategoriId==id);
            }
            return View(urunler.ToList());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(context.Kategoriler.ToList());
        }
    }
}