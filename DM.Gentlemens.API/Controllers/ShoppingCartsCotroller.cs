using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DM.Gentlemens.API.Controllers
{
    [RoutePrefix("api/shoppingCarts")]
    public class ShoppingCartsController : ApiController
    {
        #region Methods
        //GET api/shoppingCarts
        [HttpGet]
        [Route("")]
        public IEnumerable<ShoppingCart> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ShoppingCartBusiness.ReadAll();
            }
        }

        //GET api/shoppingCarts/{Guid}
        [HttpGet]
        [Route("{shoppingCartId:Guid}")]
        public ShoppingCart ReadById(Guid shoppingCartId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ShoppingCartBusiness.ReadById(shoppingCartId);
            }
        }

        //POST api/shoppingCarts
        [HttpPost]
        [Route("")]
        public void Create([FromBody] ShoppingCart shoppingCart)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ShoppingCartBusiness.Create(shoppingCart);
            }
        }

        //PUT api/shoppingCarts
        [HttpPut]
        [Route("")]
        public void Update([FromBody] ShoppingCart shoppingCart)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ShoppingCartBusiness.Update(shoppingCart);
            }
        }

        //DELETE api/shoppingCarts/{Guid}
        [HttpDelete]
        [Route("{shoppingCartId:Guid}")]
        public void Delete(Guid shoppingCartId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ShoppingCartBusiness.Delete(shoppingCartId);
            }
        }
        #endregion
    }
}