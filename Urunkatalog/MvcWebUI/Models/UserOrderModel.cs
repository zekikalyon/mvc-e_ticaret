using MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebUI.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string SiparisNo { get; set; }

        public double OdemeTutarı { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime SiparisTarihi { get; set; }
    }
}