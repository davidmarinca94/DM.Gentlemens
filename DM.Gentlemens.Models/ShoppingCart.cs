using System;

namespace DavidCompany.Gentlemens.Models
{
    public class ShoppingCart
    {
        public Guid CartID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
