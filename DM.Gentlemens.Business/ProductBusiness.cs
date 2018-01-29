using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class ProductBusiness
    {
        public List<Product> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ProductRepository.ReadAll();
        }

        public void Create(Product product)
        {
            BusinessContext.Current.RepositoryContext.ProductRepository.Create(product);
        }

        public Product ReadById(Guid productID)
        {
            return BusinessContext.Current.RepositoryContext.ProductRepository.ReadById(productID);
        }

        public void Update(Product product)
        {
            BusinessContext.Current.RepositoryContext.ProductRepository.Update(product);
        }

        public void Delete(Guid productID)
        {
            BusinessContext.Current.RepositoryContext.ProductRepository.Delete(productID);
        }
    }
}
