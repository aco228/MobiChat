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
  public partial class TranslationKeyManager : ITranslationKeyManager
  {
    public TranslationKey Load(Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service);
    }

    public TranslationKey Load(IConnectionInfo connection, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service);
    }

    public TranslationKey Load(ISqlConnectionInfo connection, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tk].ServiceID = @ServiceID";
      parameters.Arguments.Add("ServiceID", service.ID);
      return this.Load(connection, parameters);
    }


    public TranslationKey Load(Language language)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, language);
    }

    public TranslationKey Load(IConnectionInfo connection, Language language)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, language);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, language);
    }

    public TranslationKey Load(ISqlConnectionInfo connection, Language language)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tk].LanguageID = @LanguageID AND ( [tk].FallbackTranslationKeyID=1 OR [tk].ServiceID IS NULL )";
      parameters.Arguments.Add("LanguageID", language.ID);
      return this.Load(connection, parameters);
    }

    public List<TranslationKey> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<TranslationKey> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<TranslationKey> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationKey> Load(Product product)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, product);
    }

    public List<TranslationKey> Load(IConnectionInfo connection, Product product)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, product);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, product);
    }

    public List<TranslationKey> Load(ISqlConnectionInfo connection, Product product)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tk_t_p].ProductID = @ProductID";
      parameters.Arguments.Add("ProductID", product.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationKey> Load(Translation translation)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation);
    }

    public List<TranslationKey> Load(IConnectionInfo connection, Translation translation)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation);
    }

    public List<TranslationKey> Load(ISqlConnectionInfo connection, Translation translation)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tk_t].TranslationID = @TranslationID";
      parameters.Arguments.Add("TranslationID", translation.ID);
      parameters.OrderBy = "[tk].Name";
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationKey> Load(TranslationKey translationKey)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translationKey);
    }

    public List<TranslationKey> Load(IConnectionInfo connection, TranslationKey translationKey)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translationKey);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translationKey);
    }

    public List<TranslationKey> Load(ISqlConnectionInfo connection, TranslationKey translationKey)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tk].FallbackTranslationKeyID=@TranslationKeyID";
      parameters.Arguments.Add("TranslationKeyID", translationKey.ID);
      return this.LoadMany(connection, parameters);
    }

    public TranslationKey Load(Language language, Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, language, service);
    }

    public TranslationKey Load(IConnectionInfo connection, Language language, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, language, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, language, service);
    }

    public TranslationKey Load(ISqlConnectionInfo connection, Language language, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      string where = "[tk].LanguageID = @LanguageID AND ";

      if (service != null)
      {
        where += "[tk].ServiceID = @ServiceID";
        parameters.Arguments.Add("ServiceID", service.ID);
      }
      else
        where += "[tk].ServiceID IS NULL";

      parameters.Where = where;
      parameters.Arguments.Add("LanguageID", language.ID);
      return this.Load(connection, parameters);
    }


  }
}

