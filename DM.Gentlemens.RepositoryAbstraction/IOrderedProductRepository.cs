using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface IOrderedProductRepository
    {
        List<OrderedProduct> ReadAll();
        void Create(OrderedProduct orderedProduct);
        OrderedProduct ReadById(Guid orderedProductID);
        void Update(OrderedProduct orderedProduct);
        void Delete(Guid orderedProductID);
    }
}
