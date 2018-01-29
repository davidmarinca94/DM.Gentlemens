using System;

namespace DavidCompany.Gentlemens.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public string BuyerName { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerAddress { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
