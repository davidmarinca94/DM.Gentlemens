using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DM.Gentlemens.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        #region Methods
        //GET api/products
        [HttpGet]
        [Route("")]
        public IEnumerable<Product> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ProductBusiness.ReadAll();
            }
        }

        //GET api/products/{Guid}
        [HttpGet]
        [Route("{productId:Guid}")]
        public Product ReadById(Guid productId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ProductBusiness.ReadById(productId);
            }
        }

        //POST api/products
        [HttpPost]
        [Route("")]
        public void Create([FromBody] Product product)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ProductBusiness.Create(product);
            }
        }

        //PUT api/products
        [HttpPut]
        [Route("")]
        public void Update([FromBody] Product product)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ProductBusiness.Update(product);
            }
        }

        //DELETE api/products/{Guid}
        [HttpDelete]
        [Route("{productId:Guid}")]
        public void Delete(Guid productId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ProductBusiness.Delete(productId);
            }
        }
        #endregion
    }
}