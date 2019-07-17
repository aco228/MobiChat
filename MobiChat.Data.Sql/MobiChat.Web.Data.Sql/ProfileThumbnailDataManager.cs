using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
using MobiChat.Data.Sql;



namespace MobiChat.Web.Data.Sql
{
  public partial class ProfileThumbnailDataManager : IProfileThumbnailDataManager
  {

    public List<ProfileThumbnailData> Load(ProfileThumbnail profileThumbnail)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, profileThumbnail);
    }

    public List<ProfileThumbnailData> Load(IConnectionInfo connection, ProfileThumbnail profileThumbnail)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, profileThumbnail);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, profileThumbnail);
    }

    public List<ProfileThumbnailData> Load(ISqlConnectionInfo connection, ProfileThumbnail profileThumbnail)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[ptd].ProfileThumbnailID = @ProfileThumbnailID";
      parameters.Arguments.Add("ProfileThumbnailID", profileThumbnail.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

