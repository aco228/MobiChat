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
  public partial class TranslationGroupKeyManager : ITranslationGroupKeyManager
  {
    public TranslationGroupKey Load(Translation translation, string translationGroupName, string translationGroupKeyName)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation, translationGroupName, translationGroupKeyName);
    }

    public TranslationGroupKey Load(IConnectionInfo connection, Translation translation, string translationGroupName, string translationGroupKeyName)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation, translationGroupName, translationGroupKeyName);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation, translationGroupName, translationGroupKeyName);
    }

    public TranslationGroupKey Load(ISqlConnectionInfo connection, Translation translation, string translationGroupName, string translationGroupKeyName)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tgk_tg_t].TranslationID = @TranslationID AND [tgk_tg].Name = @TranslationGroupName AND [tgk].Name = @TranslationGroupKeyName";
      parameters.Arguments.Add("TranslationID", translation.ID);
      parameters.Arguments.Add("TranslationGroupName", translationGroupName);
      parameters.Arguments.Add("TranslationGroupKeyName", translationGroupKeyName);
      return this.Load(connection, parameters);
    }

    public List<TranslationGroupKey> Load(TranslationGroup translationGroup)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translationGroup);
    }

    public List<TranslationGroupKey> Load(IConnectionInfo connection, TranslationGroup translationGroup)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translationGroup);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translationGroup);
    }

    public List<TranslationGroupKey> Load(ISqlConnectionInfo connection, TranslationGroup translationGroup)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tgk_tg].TranslationGroupID = @TranslationGroupID";
      parameters.Arguments.Add("TranslationGroupID", translationGroup.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationGroupKey> Load(Product product)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, product);
    }

    public List<TranslationGroupKey> Load(IConnectionInfo connection, Product product)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, product);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, product);
    }

    public List<TranslationGroupKey> Load(ISqlConnectionInfo connection, Product product)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tgk_tg_t].ProductID = @ProductID";
      parameters.Arguments.Add("ProductID", product.ID);
      return this.LoadMany(connection, parameters);
    }


    public List<TranslationGroupKey> Load(Translation translation)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation);
    }

    public List<TranslationGroupKey> Load(IConnectionInfo connection, Translation translation)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation);
    }

    public List<TranslationGroupKey> Load(ISqlConnectionInfo connection, Translation translation)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tgk_tg_t].TranslationID = @TranslationID";
      parameters.Arguments.Add("TranslationID", translation.ID);
      return this.LoadMany(connection, parameters);
    }
  }
}

