using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DM.Gentlemens.API.Controllers
{
    [RoutePrefix("api/orderedProducts")]
    public class OrderedProductsController : ApiController
    {
        #region Methods
        //GET api/orderedProducts
        [HttpGet]
        [Route("")]
        public IEnumerable<OrderedProduct> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.OrderedProductBusiness.ReadAll();
            }
        }

        //GET api/orderedProducts/{Guid}
        [HttpGet]
        [Route("{orderedProductId:Guid}")]
        public OrderedProduct ReadById(Guid orderedProductId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.OrderedProductBusiness.ReadById(orderedProductId);
            }
        }

        //POST api/orderedProducts
        [HttpPost]
        [Route("")]
        public void Create([FromBody] OrderedProduct orderedProduct)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.OrderedProductBusiness.Create(orderedProduct);
            }
        }

        //PUT api/orderedProducts
        [HttpPut]
        [Route("")]
        public void Update([FromBody] OrderedProduct orderedProduct)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.OrderedProductBusiness.Update(orderedProduct);
            }
        }

        //DELETE api/orderedProducts/{Guid}
        [HttpDelete]
        [Route("{orderedProductId:Guid}")]
        public void Delete(Guid orderedProductId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.OrderedProductBusiness.Delete(orderedProductId);
            }
        }
        #endregion
    }
}
