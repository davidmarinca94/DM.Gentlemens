using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;

namespace DM.Gentlemens.API.Controllers
{
    [RoutePrefix("api/images")]
    public class ImagesController : ApiController
    {
        #region Methods
        //GET api/images
        [HttpGet]
        [Route("")]
        public IEnumerable<Image> ReadAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ImageBusiness.ReadAll();
            }
        }

        //GET api/images/{Guid}
        [HttpGet]
        [Route("{imageId:Guid}")]
        public Image ReadById(Guid imageId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                return context.ImageBusiness.ReadById(imageId);
            }
        }

        //POST api/images
        [HttpPost]
        [Route("")]
        public void Create([FromBody] Image image)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ImageBusiness.Create(image);
            }
        }

        //PUT api/images
        [HttpPut]
        [Route("")]
        public void Update([FromBody] Image image)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ImageBusiness.Update(image);
            }
        }

        //DELETE api/imagess/{Guid}
        [HttpDelete]
        [Route("{imageId:Guid}")]
        public void Delete(Guid imageId)
        {
            using (BusinessContext context = new BusinessContext())
            {
                context.ImageBusiness.Delete(imageId);
            }
        }
        #endregion
    }
}