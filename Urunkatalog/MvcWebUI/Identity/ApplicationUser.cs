using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebUI.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}