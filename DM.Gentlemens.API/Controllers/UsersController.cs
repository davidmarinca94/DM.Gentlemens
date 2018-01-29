using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DM.Gentlemens.API.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        #region Methods
        //GET api/users
        [HttpGet]
        [Route("")]
        public IEnumerable<User> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserBusiness.ReadAll();
            }
        }

        //GET api/users/{Guid}
        [HttpGet]
        [Route("{userId:Guid}")]
        public User ReadById(Guid userId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.UserBusiness.ReadById(userId);
            }
        }

        //POST api/users
        [HttpPost]
        [Route("")]
        public void Create([FromBody] User user)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserBusiness.Create(user);
            }
        }

        //PUT api/users
        [HttpPut]
        [Route("")]
        public void Update([FromBody] User user)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserBusiness.Update(user);
            }
        }

        //DELETE api/users/{Guid}
        [HttpDelete]
        [Route("{userId:Guid}")]
        public void Delete(Guid userId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.UserBusiness.Delete(userId);
            }
        }
        #endregion
    }
}