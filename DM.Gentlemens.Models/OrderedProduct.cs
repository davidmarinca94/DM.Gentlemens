using System;

namespace DavidCompany.Gentlemens.Models
{
    public class OrderedProduct
    {
        public Guid SoldItemID { get; set; }
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
