using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface IImageRepository
    {
        List<Image> ReadAll();
        void Create(Image image);
        Image ReadById(Guid imageID);
        void Update(Image image);
        void Delete(Guid imageID);
    }
}
