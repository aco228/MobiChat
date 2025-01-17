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
  public partial class TranslationManager : ITranslationManager
  {
    public List<Translation> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<Translation> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<Translation> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

    public T Load<T>(Product product)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load<T>(connection, product);
    }

    public T Load<T>(IConnectionInfo connection, Product product)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load<T>(sqlConnection, product);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load<T>(sqlConnection, product);
    }

    public T Load<T>(ISqlConnectionInfo connection, Product product)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[t].ProductID= @ProductID";
      parameters.Arguments.Add("ProductID", product.ID);
      if (typeof(T).Equals(typeof(List<Translation>)))
        return (T)Convert.ChangeType(this.LoadMany(connection, parameters), typeof(T));
      else
        return (T)Convert.ChangeType(this.Load(connection, parameters), typeof(T));
    }
    public T Load<T>(Application application, Product product)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load<T>(connection, application, product);
    }

    public T Load<T>(IConnectionInfo connection, Application application, Product product)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load<T>(sqlConnection, application, product);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load<T>(sqlConnection, application, product);
    }

    public T Load<T>(ISqlConnectionInfo connection, Application application, Product product)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[t].ApplicationID= @ApplicationID AND [t].ProductID=@ProductID";
      parameters.Arguments.Add("ApplicationID", application.ID);
      parameters.Arguments.Add("ProductID", product.ID);
      if (typeof(T).Equals(typeof(List<Translation>)))
        return (T)Convert.ChangeType(this.LoadMany(connection, parameters), typeof(T));
      else
        return (T)Convert.ChangeType(this.Load(connection, parameters), typeof(T));
    }
  }
}

