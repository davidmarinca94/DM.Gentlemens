using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DM.Gentlemens.API.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        #region Methods
        //GET api/orders
        [HttpGet]
        [Route("")]
        public IEnumerable<Order> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.OrderBusiness.ReadAll();
            }
        }

        //GET api/orders/{Guid}
        [HttpGet]
        [Route("{orderId:Guid}")]
        public Order ReadById(Guid orderId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.OrderBusiness.ReadById(orderId);
            }
        }

        //POST api/orders
        [HttpPost]
        [Route("")]
        public void Create([FromBody] Order order)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.OrderBusiness.Create(order);
            }
        }

        //PUT api/orders
        [HttpPut]
        [Route("")]
        public void Update([FromBody] Order order)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.OrderBusiness.Update(order);
            }
        }

        //DELETE api/orders/{Guid}
        [HttpDelete]
        [Route("{orderId:Guid}")]
        public void Delete(Guid orderId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.OrderBusiness.Delete(orderId);
            }
        }
        #endregion
    }
}