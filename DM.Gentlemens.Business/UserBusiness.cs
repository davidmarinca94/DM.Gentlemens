using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Gentlemens.Business
{
    public class UserBusiness
    {
        public List<User> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.UserRepository.ReadAll();
        }
        
        public void Create(User user)
        {
            BusinessContext.Current.RepositoryContext.UserRepository.Create(user);
        }

        public User ReadById(Guid userID)
        {
            return BusinessContext.Current.RepositoryContext.UserRepository.ReadById(userID);
        }

        public void Update(User user)
        {
            BusinessContext.Current.RepositoryContext.UserRepository.Update(user);
        }

        public void Delete(Guid userID)
        {
            BusinessContext.Current.RepositoryContext.UserRepository.Delete(userID);
        }
    }
}
