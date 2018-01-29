using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        #region Methods
        public List<ShoppingCart> ReadAll()
        {
            return ReadAll("dbo.ShoppingCart_ReadAll");
                
        }

        public ShoppingCart ReadById(Guid cartID)
        {
            var cartIdParam = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier);
            cartIdParam.Value = cartID;
            var parameters = new SqlParameter[1];
            parameters[0] = cartIdParam;
            return ReadById("dbo.ShoppingCart_ReadByID", parameters);
        }

        protected override ShoppingCart GetModelFromReader(SqlDataReader reader)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.CartID = reader.GetGuid(reader.GetOrdinal("CartID"));
            shoppingCart.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            shoppingCart.ProductID = reader.GetGuid(reader.GetOrdinal("ProductID"));
            shoppingCart.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            return shoppingCart;
        }

        protected override ShoppingCart GetSimpleModelFromReader(SqlDataReader reader)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.CartID = reader.GetGuid(reader.GetOrdinal("CartID"));
            shoppingCart.UserID = reader.GetGuid(reader.GetOrdinal("UserID"));
            shoppingCart.ProductID = reader.GetGuid(reader.GetOrdinal("ProductID"));
            shoppingCart.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            return shoppingCart;
        }

        public void Create(ShoppingCart shoppingCart)
        {
            var createProcedureName = "dbo.ShoppingCart_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@CartID", shoppingCart.CartID));
            sqlParameters.Add(new SqlParameter("@UserID", shoppingCart.UserID));
            sqlParameters.Add(new SqlParameter("@ProductID", shoppingCart.ProductID));
            sqlParameters.Add(new SqlParameter("@Quantity", shoppingCart.Quantity));
            Create(createProcedureName, sqlParameters.ToArray());
        }

        public void Update(ShoppingCart shoppingCart)
        {
            var updateProcedureName = "dbo.ShoppingCart_Update";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@CartID", shoppingCart.CartID));
            sqlParameters.Add(new SqlParameter("@UserID", shoppingCart.UserID));
            sqlParameters.Add(new SqlParameter("@ProductID", shoppingCart.ProductID));
            sqlParameters.Add(new SqlParameter("@Quantity", shoppingCart.Quantity));
            Update(updateProcedureName, sqlParameters.ToArray());
        }

        public void Delete(Guid cartID)
        {
            var cartIdParam = new SqlParameter("@CartID", SqlDbType.UniqueIdentifier);
            cartIdParam.Value = cartID;
            var parameters = new SqlParameter[1];
            parameters[0] = cartIdParam;
            Delete("dbo.ShoppingCart_Delete", parameters);
        }
        #endregion
    }
}
