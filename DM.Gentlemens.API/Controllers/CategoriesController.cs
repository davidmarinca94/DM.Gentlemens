using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DM.Gentlemens.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/categories")]
    public class CategoriesController :ApiController
    {
        #region Methods
        //GET api/categories
        [HttpGet]
        [Route("")]
        public IEnumerable<Category> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.CategoryBusiness.ReadAll();
            }
        }

        //GET api/categories/{Guid}
        [HttpGet]
        [Route("{categoryId:Guid}")]
        public Category ReadById(Guid categoryId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.CategoryBusiness.ReadById(categoryId);
            }
        }

        //POST api/categories
        [HttpPost]
        [Route("")]
        public void Create([FromBody] Category category)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoryBusiness.Create(category);
            }
        }

        //PUT api/categories
        [HttpPut]
        [Route("")]
        public void Update([FromBody] Category category)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoryBusiness.Update(category);
            }
        }

        //DELETE api/categories/{Guid}
        [HttpDelete]
        [Route("{categoryId:Guid}")]
        public void Delete(Guid categoryId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.CategoryBusiness.Delete(categoryId);
            }
        }
        #endregion
    }
}