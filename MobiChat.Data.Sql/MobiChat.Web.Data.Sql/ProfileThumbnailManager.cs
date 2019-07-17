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
  public partial class ProfileThumbnailManager : IProfileThumbnailManager
  {

    public List<ProfileThumbnail> Load(Profile profile, MobiChat.Data.ThumbnailIdentifier identifier)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection,profile, identifier);
    }

    public List<ProfileThumbnail> Load(IConnectionInfo connection, Profile profile, MobiChat.Data.ThumbnailIdentifier identifier)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection,profile, identifier);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, profile, identifier);
    }

    public List<ProfileThumbnail> Load(ISqlConnectionInfo connection, Profile profile, MobiChat.Data.ThumbnailIdentifier identifier)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pt].ProfileID = @ProfileID " + 
        ((identifier == MobiChat.Data.ThumbnailIdentifier.Default) ? " AND [pt].IsDefault = 1 " :
        (identifier == MobiChat.Data.ThumbnailIdentifier.NotDefault) ? " AND [pt].IsDefault = 0 " : "" );
      parameters.Arguments.Add("ProfileID", profile.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<ProfileThumbnail> Load(Profile profile)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, profile);
    }

    public List<ProfileThumbnail> Load(IConnectionInfo connection, Profile profile)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, profile);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, profile);
    }

    public List<ProfileThumbnail> Load(ISqlConnectionInfo connection, Profile profile)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pt].ProfileID = @ProfileID"; 
      parameters.Arguments.Add("ProfileID", profile.ID);

      return this.LoadMany(connection, parameters);
    }

  }
}

