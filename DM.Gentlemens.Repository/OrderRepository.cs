using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        #region Methods
        public List<Order> ReadAll()
        {
            return ReadAll("dbo.Orders_ReadAll");
        }

        protected override Order GetModelFromReader(SqlDataReader reader)
        {
            Order order = new Order();
            order.OrderID = reader.GetGuid(reader.GetOrdinal("OrderID"));
            order.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            order.BuyerName = reader.GetString(reader.GetOrdinal("BuyerName"));
            order.BuyerEmail = reader.GetString(reader.GetOrdinal("BuyerEmail"));
            order.BuyerAddress = reader.GetString(reader.GetOrdinal("BuyerAddress"));
            order.OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
            return order;
        }

        protected override Order GetSimpleModelFromReader(SqlDataReader reader)
        {
            Order order = new Order();
            order.OrderID = reader.GetGuid(reader.GetOrdinal("OrderID"));
            order.BuyerName = reader.GetString(reader.GetOrdinal("BuyerName"));
            order.BuyerAddress = reader.GetString(reader.GetOrdinal("BuyerAddress"));
            order.OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
            return order;
        }

        public Order ReadById(Guid orderID)
        {
            var orderIdParam = new SqlParameter("@OrderID", SqlDbType.UniqueIdentifier);
            orderIdParam.Value = orderID;
            var parameters = new SqlParameter[1];
            parameters[0] = orderIdParam;
            return ReadById("dbo.Orders_ReadByID", parameters);
        }

        public void Create(Order order)
        {
            var createProcedureName = "dbo.Orders_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@OrderID", order.OrderID));
            sqlParameters.Add(new SqlParameter("@UserID", order.UserID));
            sqlParameters.Add(new SqlParameter("@BuyerName", order.BuyerName));
            sqlParameters.Add(new SqlParameter("@BuyerEmail", order.BuyerEmail));
            sqlParameters.Add(new SqlParameter("@BuyerAddress", order.BuyerAddress));
            sqlParameters.Add(new SqlParameter("@OrderDate", order.OrderDate));
            Create(createProcedureName, sqlParameters.ToArray());
        }

        public void Update(Order order)
        {
            var updateProcedureName = "dbo.Orders_Update";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@OrderID", order.OrderID));
            sqlParameters.Add(new SqlParameter("@UserID", order.UserID));
            sqlParameters.Add(new SqlParameter("@BuyerName", order.BuyerName));
            sqlParameters.Add(new SqlParameter("@BuyerEmail", order.BuyerEmail));
            sqlParameters.Add(new SqlParameter("@BuyerAddress", order.BuyerAddress));
            sqlParameters.Add(new SqlParameter("@OrderDate", order.OrderDate));
            Update(updateProcedureName, sqlParameters.ToArray());
        }

        public void Delete(Guid orderID)
        {
            var orderIdParam = new SqlParameter("@OrderID", SqlDbType.UniqueIdentifier);
            orderIdParam.Value = orderID;
            var parameters = new SqlParameter[1];
            parameters[0] = orderIdParam;
            Delete("dbo.Orders_Delete", parameters);
        }
        #endregion
    }
}
