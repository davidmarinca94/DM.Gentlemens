using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface ICategoryRepository
    {
        List<Category> ReadAll();
        void Create(Category category);
        Category ReadById(Guid categoryID);
        void Update(Category category);
        void Delete(Guid categoryID);
    }
}
