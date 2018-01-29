using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class ImageBusiness
    {
        public List<Image> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.ReadAll();
        }

        public void Create(Image image)
        {
            BusinessContext.Current.RepositoryContext.ImageRepository.Create(image);
        }

        public Image ReadById(Guid imageID)
        {
            return BusinessContext.Current.RepositoryContext.ImageRepository.ReadById(imageID);
        }

        public void Update(Image image)
        {
            BusinessContext.Current.RepositoryContext.ImageRepository.Update(image);
        }

        public void Delete(Guid imageID)
        {
            BusinessContext.Current.RepositoryContext.ImageRepository.Delete(imageID);
        }
    }
}
