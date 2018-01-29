using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
        void Create(Product product);
        Product ReadById(Guid productID);
        void Update(Product product);
        void Delete(Guid productID);
    }
}
