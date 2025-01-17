using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;



namespace MobiChat.Data.Sql
{
  public partial class MobileOperatorManager : IMobileOperatorManager
  {

    public List<MobileOperator> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<MobileOperator> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<MobileOperator> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

    public MobileOperator Load(Country country, string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, country, name);
    }

    public MobileOperator Load(IConnectionInfo connection, Country country, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, country, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, country, name);
    }

    public MobileOperator Load(ISqlConnectionInfo connection, Country country, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[mo].CountryID = @CountryID AND [mo].Name = @Name";
      parameters.Arguments.Add("CountryID", country.ID);
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    }

    public MobileOperator Load(int id, IDType idType)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, id, idType);
    }

    public MobileOperator Load(IConnectionInfo connection, int id, IDType idType)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, id, idType);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, id, idType);
    }

    public MobileOperator Load(ISqlConnectionInfo connection, int id, IDType idType)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      string parameter = idType == IDType.Internal ? "MobileOperatorID" : "ExternalMobileOperatorID";
      parameters.Where = string.Format("[mo].{0} = @{0}", parameter);
      parameters.Arguments.Add(parameter, id);
      return this.Load(connection, parameters);
    }

    public List<MobileOperator> Load(Country country)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, country);
    }

    public List<MobileOperator> Load(IConnectionInfo connection, Country country)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, country);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, country);
    }

    public List<MobileOperator> Load(ISqlConnectionInfo connection, Country country)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[mo].CountryID = @CountryID";
      parameters.Arguments.Add("CountryID", country.ID);
      return this.LoadMany(connection, parameters);
    }

  }
}

