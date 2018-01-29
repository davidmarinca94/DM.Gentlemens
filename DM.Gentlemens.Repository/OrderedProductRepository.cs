using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class OrderedProductRepository : BaseRepository<OrderedProduct>, IOrderedProductRepository
    {
        #region Methods
        public List<OrderedProduct> ReadAll()
        {
            return ReadAll("dbo.OrderedProducts_ReadAll");
        }

        public OrderedProduct ReadById(Guid orderedProductID)
        {
            var userIdParam = new SqlParameter("@SoldItemID", SqlDbType.UniqueIdentifier);
            userIdParam.Value = orderedProductID;
            var parameters = new SqlParameter[1];
            parameters[0] = userIdParam;
            return ReadById("dbo.Users_ReadByID", parameters);
        }

        protected override OrderedProduct GetModelFromReader(SqlDataReader reader)
        {
            OrderedProduct orderedProduct = new OrderedProduct();
            orderedProduct.SoldItemID = reader.GetGuid(reader.GetOrdinal("SoldItemID"));
            orderedProduct.OrderID = reader.GetGuid(reader.GetOrdinal("OrderID"));
            orderedProduct.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            orderedProduct.ProductID = reader.GetGuid(reader.GetOrdinal("ProductID"));
            orderedProduct.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            return orderedProduct;
        }

        protected override OrderedProduct GetSimpleModelFromReader(SqlDataReader reader)
        {
            OrderedProduct orderedProduct = new OrderedProduct();
            orderedProduct.SoldItemID = reader.GetGuid(reader.GetOrdinal("SoldItemID"));
            orderedProduct.OrderID = reader.GetGuid(reader.GetOrdinal("OrderID"));
            orderedProduct.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            orderedProduct.ProductID = reader.GetGuid(reader.GetOrdinal("ProductID"));
            orderedProduct.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            return orderedProduct;
        }

        public void Create(OrderedProduct orderedProduct)
        {
            var createProcedureName = "dbo.Images_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@SoldItemID", orderedProduct.SoldItemID));
            sqlParameters.Add(new SqlParameter("@OrderID", orderedProduct.OrderID));
            sqlParameters.Add(new SqlParameter("@UserID", orderedProduct.UserID));
            sqlParameters.Add(new SqlParameter("@ProductID", orderedProduct.ProductID));
            sqlParameters.Add(new SqlParameter("@Quantity", orderedProduct.Quantity));
            Create(createProcedureName, sqlParameters.ToArray());
        }

        public void Update(OrderedProduct orderedProduct)
        {
            var updateProcedureName = "dbo.Images_Update";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@SoldItemID", orderedProduct.SoldItemID));
            sqlParameters.Add(new SqlParameter("@OrderID", orderedProduct.OrderID));
            sqlParameters.Add(new SqlParameter("@UserID", orderedProduct.UserID));
            sqlParameters.Add(new SqlParameter("@ProductID", orderedProduct.ProductID));
            sqlParameters.Add(new SqlParameter("@Quantity", orderedProduct.Quantity));
            Update(updateProcedureName, sqlParameters.ToArray());
        }

        public void Delete(Guid orderedProductID)
        {
            var orderedProductIdParam = new SqlParameter("@SoldItemID", SqlDbType.UniqueIdentifier);
            orderedProductIdParam.Value = orderedProductID;
            var parameters = new SqlParameter[1];
            parameters[0] = orderedProductIdParam;

            Delete("dbo.OrderedProducts_Delete", parameters);
        }
        #endregion
    }
}

