using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface IOrderRepository
    {
        List<Order> ReadAll();
        void Create(Order order);
        Order ReadById(Guid orderID);
        void Update(Order order);
        void Delete(Guid orderID);
    }
}
