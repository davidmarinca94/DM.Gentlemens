using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface IShoppingCartRepository
    {
        List<ShoppingCart> ReadAll();
        void Create(ShoppingCart shoppingCart);
        ShoppingCart ReadById(Guid shoppingCartID);
        void Update(ShoppingCart shoppingCart);
        void Delete(Guid shoppingCartID);
    }
}
