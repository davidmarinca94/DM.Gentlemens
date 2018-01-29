using System;

namespace DavidCompany.Gentlemens.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public Guid CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Guid ImageID { get; set; }
        public decimal Price { get; set; }
    }
}
