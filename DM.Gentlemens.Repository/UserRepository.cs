using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Methods
        public List<User> ReadAll()
        {
            return ReadAll("dbo.Users_ReadAll");
        }

        public User ReadById(Guid userID)
        {
            var userIdParam = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
            userIdParam.Value = userID;
            var parameters = new SqlParameter[1];
            parameters[0] = userIdParam;
            return ReadById("dbo.Users_ReadByID", parameters);
        }

        protected override User GetModelFromReader(SqlDataReader reader)
        {
            User user = new User();
            user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            user.Username = reader.GetString(reader.GetOrdinal("Username"));
            user.UserPassword = reader.GetString(reader.GetOrdinal("UserPassword"));
            user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
            user.Address = reader.GetString(reader.GetOrdinal("Address"));
            user.City = reader.GetString(reader.GetOrdinal("City"));
            user.Country = reader.GetString(reader.GetOrdinal("Country"));
            user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            user.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
            user.UserRole = reader.GetString(reader.GetOrdinal("UserRole"));
            return user;
        }

        protected override User GetSimpleModelFromReader(SqlDataReader reader)
        {
            User user = new User();
            user.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
            user.UserRole = reader.GetString(reader.GetOrdinal("UserRole"));
            return user;
        }

        public void Create(User user)
        {
            var createProcedureName = "dbo.Users_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@UserID", user.UserID));
            sqlParameters.Add(new SqlParameter("@Username", user.Username));
            sqlParameters.Add(new SqlParameter("@UserPassword", user.UserPassword));
            sqlParameters.Add(new SqlParameter("@FirstName", user.FirstName));
            sqlParameters.Add(new SqlParameter("@LastName", user.LastName));
            sqlParameters.Add(new SqlParameter("@Address", user.Address));
            sqlParameters.Add(new SqlParameter("@City", user.City));
            sqlParameters.Add(new SqlParameter("@Country", user.Country));
            sqlParameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
            sqlParameters.Add(new SqlParameter("@EmailAddress", user.EmailAddress));
            sqlParameters.Add(new SqlParameter("@UserRole", user.UserRole));
            Create(createProcedureName, sqlParameters.ToArray());
        }


        public void Update(User user)
        {
            var updateProcedureName = "dbo.Users_Update";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@UserID", user.UserID));
            sqlParameters.Add(new SqlParameter("@Username", user.Username));
            sqlParameters.Add(new SqlParameter("@UserPassword", user.UserPassword));
            sqlParameters.Add(new SqlParameter("@FirstName", user.FirstName));
            sqlParameters.Add(new SqlParameter("@LastName", user.LastName));
            sqlParameters.Add(new SqlParameter("@Address", user.Address));
            sqlParameters.Add(new SqlParameter("@City", user.City));
            sqlParameters.Add(new SqlParameter("@Country", user.Country));
            sqlParameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
            sqlParameters.Add(new SqlParameter("@EmailAddress", user.EmailAddress));
            sqlParameters.Add(new SqlParameter("@UserRole", user.UserRole));
            Update(updateProcedureName, sqlParameters.ToArray());
        }
        
        public void Delete(Guid userID)
        {
            var userIdParam = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
            userIdParam.Value = userID;
            var parameters = new SqlParameter[1];
            parameters[0] = userIdParam;
            Delete("dbo.Users_Delete", parameters);
        }
        #endregion
    }
}