using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class OrderedProductBusiness
    {
        public List<OrderedProduct> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.OrderedProductRepository.ReadAll();
        }

        public void Create(OrderedProduct orderedProduct)
        {
            BusinessContext.Current.RepositoryContext.OrderedProductRepository.Create(orderedProduct);
        }

        public OrderedProduct ReadById(Guid orderedProductID)
        {
            return BusinessContext.Current.RepositoryContext.OrderedProductRepository.ReadById(orderedProductID);
        }

        public void Update(OrderedProduct orderedProduct)
        {
            BusinessContext.Current.RepositoryContext.OrderedProductRepository.Update(orderedProduct);
        }

        public void Delete(Guid orderedProductID)
        {
            BusinessContext.Current.RepositoryContext.OrderedProductRepository.Delete(orderedProductID);
        }
    }
}
