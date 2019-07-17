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
  public partial class ServiceConfigurationEntryManager : IServiceConfigurationEntryManager
  {

    public List<ServiceConfigurationEntry> Load(Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service);
    }

    public List<ServiceConfigurationEntry> Load(IConnectionInfo connection, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service);
    }

    public List<ServiceConfigurationEntry> Load(ISqlConnectionInfo connection, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[sce].ServiceConfigurationID = @ServiceConfigurationID";
      parameters.Arguments.Add("ServiceConfigurationID", service.ServiceConfiguration.ID);
      return this.LoadMany(connection, parameters);
    }
    
    public ServiceConfigurationEntry Load(Service service, Country country)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service, country);
    }

    public ServiceConfigurationEntry Load(IConnectionInfo connection, Service service, Country country)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service, country);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service, country);
    }

    public ServiceConfigurationEntry Load(ISqlConnectionInfo connection, Service service, Country country)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[sce].ServiceConfigurationID = @ServiceConfigurationID AND [sce].CountryID = @CountryID";
      parameters.Arguments.Add("ServiceConfigurationID", service.ServiceConfiguration.ID);
      parameters.Arguments.Add("CountryID", country.ID);
      return this.Load(connection, parameters);
    }


    public ServiceConfigurationEntry Load(Service service, Country country, MobileOperator mobileOperator)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service, country, mobileOperator);
    }

    public ServiceConfigurationEntry Load(IConnectionInfo connection, Service service, Country country, MobileOperator mobileOperator)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service, country, mobileOperator);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service, country, mobileOperator);
    }

    public ServiceConfigurationEntry Load(ISqlConnectionInfo connection, Service service, Country country, MobileOperator mobileOperator)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[sce].ServiceConfigurationID = @ServiceConfigurationID AND [sce].CountryID = @CountryID AND [sce].MobileOperatorID = @MobileOperatorID";
      parameters.Arguments.Add("ServiceConfigurationID", service.ServiceConfiguration.ID);
      parameters.Arguments.Add("CountryID", country.ID);
      parameters.Arguments.Add("MobileOperatorID", mobileOperator.ID);
      return this.Load(connection, parameters);
    }


    public ServiceConfigurationEntry Load(string keyword, int shortcode, Country country)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, keyword, shortcode, country);
    }

    public ServiceConfigurationEntry Load(IConnectionInfo connection, string keyword, int shortcode, Country country)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, keyword, shortcode, country);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, keyword, shortcode, country);
    }

    public ServiceConfigurationEntry Load(ISqlConnectionInfo connection, string keyword, int shortcode, Country country)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[sce].Shortcode = @Shortcode AND [sce].Keyword = @Keyword";
      parameters.Arguments.Add("Shortcode", shortcode);
      parameters.Arguments.Add("Keyword", keyword);

      if(country != null)
      {
        parameters.Where += " AND [sce].CountryID = @CountryID";
        parameters.Arguments.Add("CountryID", country.ID);
      }

      return this.Load(connection, parameters);
    }


  }
}

