using DavidCompany.Gentlemens.Models;
using System;
using System.Collections.Generic;
using DM.Gentlemens.Business.Core;

namespace DM.Gentlemens
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                ShowUsersByID(businessContext);
            }
            Console.ReadKey();
        }

        private static void ShowUsers(BusinessContext businessContext)
        {
            List<User> users = businessContext.UserBusiness.ReadAll();
            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                Console.WriteLine("{0} - {1} {2}", user.UserID, user.LastName, user.FirstName);
            }
        }
                
        private static void ShowUsersByID(BusinessContext businessContext)
        {
            User user = businessContext.UserBusiness.ReadById(new Guid("5D1FC4D4-87C1-478A-9F86-4177F1C05654"));
            Console.WriteLine("{0} - {1} {2}", user.UserID, user.LastName, user.FirstName);
        }

        private static void CreateUser(BusinessContext businessContext)
        {
            User user1 = new User();
            user1.UserID = Guid.NewGuid();
            user1.Username = "AAAAAA";
            user1.UserPassword = "1234asdf";
            user1.FirstName = "John";
            user1.LastName = "Smith";
            user1.Address = "121 ploiestiului";
            user1.City = "Cluj-Napoca";
            user1.Country = "Romania";
            user1.PhoneNumber = "0758342734";
            user1.EmailAddress = "johnsmith@gmail.com";
            user1.UserRole = "user";
            businessContext.UserBusiness.Create(user1);
        }

        private static void UpdateUser(BusinessContext businessContext)
        {
            User user1 = new User();
            user1.UserID = new Guid("00000000-0000-0000-0000-000000000000");
            user1.Username = "DDDJohnSmith";
            user1.UserPassword = "1234asdf";
            user1.FirstName = "John";
            user1.LastName = "Smith";
            user1.Address = "121 ploiestiului";
            user1.City = "Cluj-Napoca";
            user1.Country = "Romania";
            user1.PhoneNumber = "0758342734";
            user1.EmailAddress = "johnsmith@gmail.com";
            user1.UserRole = "user";
            businessContext.UserBusiness.Update(user1);
        }

        private static void DeleteUser(BusinessContext businessContext)
        {
            businessContext.UserBusiness.Delete(new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
