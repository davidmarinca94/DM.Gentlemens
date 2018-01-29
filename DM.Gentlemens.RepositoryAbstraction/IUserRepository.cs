using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.RepositoryAbstraction
{
    public interface IUserRepository
    {
        List<User> ReadAll();
        void Create(User user);
        User ReadById(Guid userID);
        void Update(User user);
        void Delete(Guid userID);
    }
}
