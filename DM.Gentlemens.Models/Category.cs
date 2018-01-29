using System;

namespace DavidCompany.Gentlemens.Models
{
    public class Category
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Guid ImageID { get; set; }
        public Guid ParentID { get; set; }
    }
}
