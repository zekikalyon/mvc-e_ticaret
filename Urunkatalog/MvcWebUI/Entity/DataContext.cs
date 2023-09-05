using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            
        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Order> Siparisler { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }
    }
}