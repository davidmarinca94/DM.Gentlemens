using DavidCompany.Gentlemens.Models;
using DM.Gentlemens.Repository.Core;
using DM.Gentlemens.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DM.Gentlemens.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        #region Methods
        public List<Image> ReadAll()
        {
            return ReadAll("dbo.Images_ReadAll");
        }

        public Image ReadById(Guid imageID)
        {
            var imageIdParam = new SqlParameter("@ImageID", SqlDbType.UniqueIdentifier);
            imageIdParam.Value = imageID;
            var parameters = new SqlParameter[1];
            parameters[0] = imageIdParam;
            return ReadById("dbo.Images_ReadByID", parameters);
        }

        protected override Image GetModelFromReader(SqlDataReader reader)
        {
            Image image = new Image();
            image.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            image.ImageURL = reader.GetString(reader.GetOrdinal("ImageUrl"));
            return image;
        }
        protected override Image GetSimpleModelFromReader(SqlDataReader reader)
        {
            Image image = new Image();
            image.ImageID = reader.GetGuid(reader.GetOrdinal("ImageID"));
            image.ImageURL = reader.GetString(reader.GetOrdinal("ImageUrl"));
            return image;
        }

        public void Create(Image image)
        {
            var createProcedureName = "dbo.Images_Create";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ImageID", image.ImageID));
            sqlParameters.Add(new SqlParameter("@ImageURL", image.ImageURL));
            Create(createProcedureName, sqlParameters.ToArray());
        }

        public void Update(Image image)
        {
            var updateProcedureName = "dbo.Images_Update";
            var sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ImageID", image.ImageID));
            sqlParameters.Add(new SqlParameter("@ImageURL", image.ImageURL));
            Update(updateProcedureName, sqlParameters.ToArray());
        }

        public void Delete(Guid imageID)
        {
            var imageIdParam = new SqlParameter("@ImageID", SqlDbType.UniqueIdentifier);
            imageIdParam.Value = imageID;
            var parameters = new SqlParameter[1];
            parameters[0] = imageIdParam;
            Delete("dbo.Images_Delete", parameters);
        }
        #endregion
    }
}

