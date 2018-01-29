using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class ShoppingCartBusiness
    {
        public List<ShoppingCart> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ShoppingCartRepository.ReadAll();
        }

        public void Create(ShoppingCart shoppingCart)
        {
            BusinessContext.Current.RepositoryContext.ShoppingCartRepository.Create(shoppingCart);
        }

        public ShoppingCart ReadById(Guid shoppingCartID)
        {
            return BusinessContext.Current.RepositoryContext.ShoppingCartRepository.ReadById(shoppingCartID);
        }

        public void Update(ShoppingCart shoppingCart)
        {
            BusinessContext.Current.RepositoryContext.ShoppingCartRepository.Update(shoppingCart);
        }

        public void Delete(Guid shoppingCartID)
        {
            BusinessContext.Current.RepositoryContext.ShoppingCartRepository.Delete(shoppingCartID);
        }
    }
}
