using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebUI.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roller
            if(!context.Roles.Any(i=>i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="admin",Aciklama="admin rolü"};
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="user",Aciklama="user rolü"};
                manager.Create(role);
            }
            //User
            if (!context.Users.Any(i => i.Ad == "zekikalyon"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser()
                {
                    Ad = "Zeki",
                    Soyad = "Kalyon",
                    Email = "mzk72k@gmail.com",
                    UserName = "zekaly",
                    

                };
                manager.Create(user,"mzkhb12345.");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
                
            }
            if (!context.Users.Any(i => i.Ad == "burakkalyon"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser()
                {
                    Ad = "Burak",
                    Soyad = "Kalyon",
                    Email = "zeki_4261@hotmail.com",
                    UserName = "mzkhb1234",


                };
                manager.Create(user, "patron6754");
                
                manager.AddToRole(user.Id, "user");

            }


            

            base.Seed(context);
        }
    }
}