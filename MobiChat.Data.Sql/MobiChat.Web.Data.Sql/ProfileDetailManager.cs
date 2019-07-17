using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
using MobiChat.Data.Sql;
using MobiChat.Data;



namespace MobiChat.Web.Data.Sql
{
  public partial class ProfileDetailManager : IProfileDetailManager
  {

 

    public List<ProfileDetail> Load(Language language)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection,language);
    }

    public List<ProfileDetail> Load(IConnectionInfo connection, Language language)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, language);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, language);
    }

    public List<ProfileDetail> Load(ISqlConnectionInfo connection, MobiChat.Data.Language language)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pd].LanguageID = @LanguageID";
      parameters.Arguments.Add("LanguageID", language.ID);
      return this.LoadMany(connection, parameters);

    }


    public List<ProfileDetail> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<ProfileDetail> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<ProfileDetail> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }



    public ProfileDetail Load(Profile profile, MobiChat.Data.Language language)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, profile, language);
    }

    public ProfileDetail Load(IConnectionInfo connection, Profile profile, MobiChat.Data.Language language)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, profile, language);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, profile, language);
    }

    public ProfileDetail Load(ISqlConnectionInfo connection, Profile profile, MobiChat.Data.Language language)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pd].LanguageID = @LanguageID AND [pd].ProfileID = @ProfileID";
      parameters.Arguments.Add("LanguageID", language.ID);
      parameters.Arguments.Add("ProfileID", profile.ID);
      return this.Load(connection, parameters);
    }


    public List<ProfileDetail> Load(Profile profile)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, profile);
    }

    public List<ProfileDetail> Load(IConnectionInfo connection, Profile profile)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, profile);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, profile);
    }

    public List<ProfileDetail> Load(ISqlConnectionInfo connection, Profile profile)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[pd].ProfileID = @ProfileID";
      parameters.Arguments.Add("ProfileID", profile.ID);
      return this.LoadMany(connection, parameters);
    }

  }
}

