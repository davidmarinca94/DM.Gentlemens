using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class CategoryBusiness
    {
        public List<Category> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.CategoryRepository.ReadAll();
        }

        public void Create(Category category)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Create(category);
        }

        public Category ReadById(Guid categoryID)
        {
            return BusinessContext.Current.RepositoryContext.CategoryRepository.ReadById(categoryID);
        }

        public void Update(Category category)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Update(category);
        }

        public void Delete(Guid categoryID)
        {
            BusinessContext.Current.RepositoryContext.CategoryRepository.Delete(categoryID);
        }
    }
}
