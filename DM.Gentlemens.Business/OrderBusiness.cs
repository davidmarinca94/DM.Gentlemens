using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class OrderBusiness
    {
        public List<Order> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.OrderRepository.ReadAll();
        }

        public void Create(Order order)
        {
            BusinessContext.Current.RepositoryContext.OrderRepository.Create(order);
        }

        public Order ReadById(Guid orderID)
        {
            return BusinessContext.Current.RepositoryContext.OrderRepository.ReadById(orderID);
        }

        public void Update(Order order)
        {
            BusinessContext.Current.RepositoryContext.OrderRepository.Update(order);
        }

        public void Delete(Guid orderID)
        {
            BusinessContext.Current.RepositoryContext.OrderRepository.Delete(orderID);
        }
    }
}
