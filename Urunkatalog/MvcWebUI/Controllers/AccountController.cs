using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebUI.Identity;
using MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MvcWebUI.Entity;

namespace MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Siparisler
                .Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    SiparisNo = i.SiparisNo,
                    SiparisTarihi = i.SiparisTarihi,
                    OrderState = i.OrderState,
                    OdemeTutarı = i.OdemeTutarı
                }).OrderByDescending(i => i.SiparisTarihi).ToList();
            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Siparisler.Where(i => i.Id == id)
                   .Select(i => new OrderDetailsModel()
                   {
                        OrderId =i.Id,
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
                        Orderlines = i.Orderlines.Select(x=> new OrderLineModel()
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
        
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Kayitol model)
        {
            if(ModelState.IsValid)
            {
                //Kayıt işlemleri
                var user = new ApplicationUser();
                user.Ad = model.Ad;
                user.Soyad = model.Soyad;
                user.Email = model.Email;
                user.UserName = model.Username;
                
                
                IdentityResult result =  UserManager.Create(user,model.Password);

                if(result.Succeeded)
                {
                    // kullanıcı oluştu ve kullanıcıyı bir role atayabilirsiniz.
                    if(RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }
            }
            
            return View(model);
        }



        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Giris model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Giriş işlemleri
                var user =UserManager.Find(model.Username,model.Password);
                
                if(user != null)
                {
                    //varolan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak

                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties,identityclaims);

                    if(!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulunamadı");
                }
            }

            return View(model);
        }
        public ActionResult Logout(Giris model)
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();


            return RedirectToAction("Index","Home");
        }
    }
}