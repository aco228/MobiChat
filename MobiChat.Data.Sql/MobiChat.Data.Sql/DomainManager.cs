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
  public partial class DomainManager : IDomainManager
  {

    	public List<Domain> Load(Service service)
		{
			using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
				return this.Load(connection, service);
		}

		public List<Domain> Load(IConnectionInfo connection, Service service)
		{
			ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
			if (sqlConnection != null)
				return this.Load(sqlConnection, service);
			using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
				return this.Load(sqlConnection, service);
		}

		public List<Domain> Load(ISqlConnectionInfo connection, Service service)
		{
			SqlQueryParameters parameters = new SqlQueryParameters();
			parameters.Where = "[d].ServiceID = @ServiceID";
			parameters.OrderBy = "[d].DomainName DESC";
			parameters.Arguments.Add("ServiceID", service.ID);
			return this.LoadMany(connection, parameters);
		}

    	public List<Domain> Load(Application application)
		{
			using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
				return this.Load(connection, application);
		}

		public List<Domain> Load(IConnectionInfo connection, Application application)
		{
			ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
			if (sqlConnection != null)
				return this.Load(sqlConnection, application);
			using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
				return this.Load(sqlConnection, application);
		}

		public List<Domain> Load(ISqlConnectionInfo connection, Application application)
		{
			if (this.Depth < 1)
				this.Depth = 1;
			SqlQueryParameters parameters = new SqlQueryParameters();
			parameters.Where = "[d_s].ApplicationID = @ApplicationID";
			parameters.Arguments.Add("ApplicationID", application.ID);
			return this.LoadMany(connection, parameters);
		}


     public Domain Load(string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, name);
    }
     
    public Domain Load(IConnectionInfo connection, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, name);
    }

    public Domain Load(ISqlConnectionInfo connection, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[i].Name = @Name";
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    
    }


      public List<Domain> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Domain> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Domain> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

  }
}

