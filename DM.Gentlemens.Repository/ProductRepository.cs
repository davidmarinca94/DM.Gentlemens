using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Methods
        public List<Product> ReadAll()
        {
            return ReadAll("dbo.Products_ReadAll");
        }

        public Product ReadById(Guid productID)
        {
            var productIdParam = new SqlParameter("@ProductID", SqlDbType.UniqueIdentifier);
            productIdParam.Value = productID;
            var parameters = new SqlParameter[1];
            parameters[0] = productIdParam;
            return ReadById("dbo.Products_ReadByID", parameters);
        }

        protected override Product GetModelFromReader(SqlDataReader reader)
        {
            Product product = new Product();
            product.ProductID = reader.GetGuid(reader.GetOrdinal("ProductID"));
            product.CategoryID = reader.GetGuid(reader.GetOrdinal("CategoryID"));
            product.ProductName = reader.GetString(reader.GetOrdinal("Productname"));
            product.ProductDescription = reader.GetString(reader.GetOrdinal("ProductDescription"));
            product.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            return product;
        }

        protected override Product GetSimpleModelFromReader(SqlDataReader reader)
        {
            Product product = new Product();
            product.ProductID = reader.GetGuid(reader.GetOrdinal("ProductID"));
            product.ProductName = reader.GetString(reader.GetOrdinal("Productname"));
            product.ProductDescription = reader.GetString(reader.GetOrdinal("ProductDescription"));
            product.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            return product;
        }

        public void Create(Product product)
        {
            var createProcedureName = "dbo.Products_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ProductID", product.ProductID));
            sqlParameters.Add(new SqlParameter("@CategoryID", product.CategoryID));
            sqlParameters.Add(new SqlParameter("@ProductName", product.ProductName));
            sqlParameters.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            sqlParameters.Add(new SqlParameter("@ImageID", product.ImageID));
            sqlParameters.Add(new SqlParameter("@Price", product.Price));
            Create(createProcedureName, sqlParameters.ToArray());
        }

        public void Update(Product product)
        {
            var updateProcedureName = "dbo.Products_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ProductID", product.ProductID));
            sqlParameters.Add(new SqlParameter("@CategoryID", product.CategoryID));
            sqlParameters.Add(new SqlParameter("@ProductName", product.ProductName));
            sqlParameters.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            sqlParameters.Add(new SqlParameter("@ImageID", product.ImageID));
            sqlParameters.Add(new SqlParameter("@Price", product.Price));
            Update(updateProcedureName, sqlParameters.ToArray());
        }

        public void Delete(Guid productID)
        {
            var productIdParam = new SqlParameter("@ProductID", SqlDbType.UniqueIdentifier);
            productIdParam.Value = productID;
            var parameters = new SqlParameter[1];
            parameters[0] = productIdParam;
            Delete("dbo.Products_Delete", parameters);
        }
        #endregion
    }
}
