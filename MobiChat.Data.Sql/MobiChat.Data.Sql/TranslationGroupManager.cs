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
  public partial class TranslationGroupManager : ITranslationGroupManager
  {
    public List<TranslationGroup> Load(Product product)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, product);
    }

    public List<TranslationGroup> Load(IConnectionInfo connection, Product product)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, product);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, product);
    }

    public List<TranslationGroup> Load(ISqlConnectionInfo connection, Product product)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tg_t].ProductID = @ProductID";
      parameters.Arguments.Add("ProductID", product.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationGroup> Load(Translation translation)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation);
    }

    public List<TranslationGroup> Load(IConnectionInfo connection, Translation translation)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation);
    }

    public List<TranslationGroup> Load(ISqlConnectionInfo connection, Translation translation)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tg].TranslationID = @TranslationID";
      parameters.Arguments.Add("TranslationID", translation.ID);
      return this.LoadMany(connection, parameters);
    }


    public List<TranslationGroup> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<TranslationGroup> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<TranslationGroup> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }



    public TranslationGroup Load(Translation translation, string name)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation, name);
    }

    public TranslationGroup Load(IConnectionInfo connection, Translation translation, string name)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation, name);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation, name);
    }

    public TranslationGroup Load(ISqlConnectionInfo connection, Translation translation, string name)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tg].TranslationID = @TranslationID AND [tg].Name = @Name";
      parameters.Arguments.Add("TranslationID", translation.ID);
      parameters.Arguments.Add("Name", name);
      return this.Load(connection, parameters);
    }
  }
}

