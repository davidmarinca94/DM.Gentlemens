using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        #region Methods
        public List<Category> ReadAll()
        {
            return ReadAll("dbo.Categories_ReadAll");
        }

        public Category ReadById(Guid categoryID)
        {
            var userIdParam = new SqlParameter("@CategoryID", SqlDbType.UniqueIdentifier);
            userIdParam.Value = categoryID;
            var parameters = new SqlParameter[1];
            parameters[0] = userIdParam;
            return ReadById("dbo.Categories_ReadByID", parameters);
        }

        protected override Category GetModelFromReader(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            category.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
            category.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            return category;
        }

        protected override Category GetSimpleModelFromReader(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            category.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
            return category;
        }

        public void Create(Category category)
        {
            var createProcedureName = "dbo.Categories_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@CategoryID", category.CategoryID));
            sqlParameters.Add(new SqlParameter("@CategoryName", category.CategoryName));
            sqlParameters.Add(new SqlParameter("@ImageID", category.ImageID));
            sqlParameters.Add(new SqlParameter("@ParentID", category.ParentID));
            Create(createProcedureName, sqlParameters.ToArray());
        }

        public void Update(Category category)
        {
            var updateProcedureName = "dbo.Categories_Update";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@CategoryID", category.CategoryID));
            sqlParameters.Add(new SqlParameter("@CategoryName", category.CategoryName));
            sqlParameters.Add(new SqlParameter("@ImageID", category.ImageID));
            sqlParameters.Add(new SqlParameter("@ParentID", category.ParentID));
            Update(updateProcedureName, sqlParameters.ToArray());
        }

        public void Delete(Guid categoryID)
        {
            var categoryIdParam = new SqlParameter("@CategoryID", SqlDbType.UniqueIdentifier);
            categoryIdParam.Value = categoryID;
            var parameters = new SqlParameter[1];
            parameters[0] = categoryIdParam;
            Delete("dbo.Categories_Delete", parameters);
        }
        #endregion
    }
}