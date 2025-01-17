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
  public partial class TranslationValueManager : ITranslationValueManager
  {

    public TranslationValue Load(TranslationValue translationValue)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translationValue);
    }

    public TranslationValue Load(IConnectionInfo connection, TranslationValue translationValue)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translationValue);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translationValue);
    }

    public TranslationValue Load(ISqlConnectionInfo connection, TranslationValue translationValue)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv].TranslationValueID = @TranslationValueID";
      parameters.Arguments.Add("TranslationValueID", translationValue.ID);
      return this.Load(connection, parameters);
    }



    public TranslationValue Load(Translation translation, string translationGroupName, string translationGroupKeyName)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation, translationGroupName, translationGroupKeyName);
    }

    public TranslationValue Load(IConnectionInfo connection, Translation translation, string translationGroupName, string translationGroupKeyName)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation, translationGroupName, translationGroupKeyName);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation, translationGroupName, translationGroupKeyName);
    }

    public TranslationValue Load(ISqlConnectionInfo connection, Translation translation, string translationGroupName, string translationGroupKeyName)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv_tk_t].TranslationID = @TranslationID AND [tv_tgk_tg].Name = @TranslationGroupName AND [tv_tgk].TranslationGroupKeyName";
      parameters.Arguments.Add("TranslationID", translation.ID);
      parameters.Arguments.Add("TranslationGroupName", translationGroupName);
      parameters.Arguments.Add("TranslationGroupKeyName", translationGroupKeyName);
      return this.Load(connection, parameters);
    }

    public TranslationValue Load(TranslationKey translationKey, TranslationGroupKey translationGroupKey)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translationKey, translationGroupKey);
    }

    public TranslationValue Load(IConnectionInfo connection, TranslationKey translationKey, TranslationGroupKey translationGroupKey)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translationKey, translationGroupKey);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translationKey, translationGroupKey);
    }

    public TranslationValue Load(ISqlConnectionInfo connection, TranslationKey translationKey, TranslationGroupKey translationGroupKey)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv].TranslationGroupKeyID = @TranslationGroupKeyID AND [tv].TranslationKeyID = @TranslationKeyID";
      parameters.Arguments.Add("TranslationGroupKeyID", translationGroupKey.ID);
      parameters.Arguments.Add("TranslationKeyID", translationKey.ID);
      return this.Load(connection, parameters);
    }

    public List<TranslationValue> Load(Language language)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, language);
    }

    public List<TranslationValue> Load(IConnectionInfo connection, Language language)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, language);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, language);
    }

    public List<TranslationValue> Load(ISqlConnectionInfo connection, Language language)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv_tk_l].LanguageID = @LanguageID";
      parameters.Arguments.Add("LanguageID", language.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationValue> Load(Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service);
    }

    public List<TranslationValue> Load(IConnectionInfo connection, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service);
    }

    public List<TranslationValue> Load(ISqlConnectionInfo connection, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv_tk_s].ServiceID = @ServiceID";
      parameters.Arguments.Add("ServiceID", service.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationValue> Load(Product product)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, product);
    }

    public List<TranslationValue> Load(IConnectionInfo connection, Product product)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, product);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, product);
    }

    public List<TranslationValue> Load(ISqlConnectionInfo connection, Product product)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv_tk_t].ProductID = @ProductID";
      parameters.Arguments.Add("ProductID", product.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<TranslationValue> Load(Translation translation)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation);
    }

    public List<TranslationValue> Load(IConnectionInfo connection, Translation translation)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation);
    }

    public List<TranslationValue> Load(ISqlConnectionInfo connection, Translation translation)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv_tk].TranslationID = @TranslationID";
      parameters.Arguments.Add("TranslationID", translation.ID);
      return this.LoadMany(connection, parameters);
    }

    //new
    public List<TranslationValue> Load(Translation translation, TranslationKey translationKey, TranslationGroup translationGroup)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, translation, translationKey, translationGroup);
    }

    public List<TranslationValue> Load(IConnectionInfo connection, Translation translation, TranslationKey translationKey, TranslationGroup translationGroup)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, translation, translationKey, translationGroup);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, translation, translationKey, translationGroup);
    }

    public List<TranslationValue> Load(ISqlConnectionInfo connection, Translation translation, TranslationKey translationKey, TranslationGroup translationGroup)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[tv_tk].TranslationID = @TranslationID AND [tv_tk].TranslationKeyID = @TranslationKeyID AND [tv_tgk].TranslationGroupID = @TranslationGroupID";
      parameters.Arguments.Add("TranslationID", translation.ID);
      parameters.Arguments.Add("TranslationKeyID", translationKey.ID);
      parameters.Arguments.Add("TranslationGroupID", translationGroup.ID);
      return this.LoadMany(connection, parameters);
    }


  }
}

