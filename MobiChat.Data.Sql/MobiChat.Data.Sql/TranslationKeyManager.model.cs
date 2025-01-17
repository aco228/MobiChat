using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Diagnostics.Log;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;
using MobiChat.Data.Sql;



namespace MobiChat.Data.Sql
{
  [DataManager(typeof(TranslationKey))] 
  public partial class TranslationKeyManager : MobiChat.Data.Sql.SqlManagerBase<TranslationKey>, ITranslationKeyManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override TranslationKey LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							TranslationKeyTable.GetColumnNames("[tk]") + 
							(this.Depth > 0 ? "," + TranslationKeyTable.GetColumnNames("[tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationKeyTable.GetColumnNames("[tk_tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tk_tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tk_tk_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[tk_tk_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[tk_t_tt]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[tk_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[tk_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[tk_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[tk_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[tk_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[tk_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[tk_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[tk_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tk_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[tk_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[tk_s_t]") : string.Empty) + 
					" FROM [core].[TranslationKey] AS [tk] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tk_tk] ON [tk].[FallbackTranslationKeyID] = [tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tk_tk_tk] ON [tk_tk].[FallbackTranslationKeyID] = [tk_tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Translation] AS [tk_tk_t] ON [tk_tk].[TranslationID] = [tk_tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_tk_l] ON [tk_tk].[LanguageID] = [tk_tk_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tk_tk_s] ON [tk_tk].[ServiceID] = [tk_tk_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tk_t] ON [tk].[TranslationID] = [tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [tk_t_tt] ON [tk_t].[TranslationTypeID] = [tk_t_tt].[TranslationTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_l] ON [tk].[LanguageID] = [tk_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tk_s] ON [tk].[ServiceID] = [tk_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [tk_s_a] ON [tk_s].[ApplicationID] = [tk_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [tk_s_p] ON [tk_s].[ProductID] = [tk_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [tk_s_m] ON [tk_s].[MerchantID] = [tk_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [tk_s_st] ON [tk_s].[ServiceTypeID] = [tk_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [tk_s_ust] ON [tk_s].[UserSessionTypeID] = [tk_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [tk_s_c] ON [tk_s].[FallbackCountryID] = [tk_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_s_l] ON [tk_s].[FallbackLanguageID] = [tk_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [tk_s_sc] ON [tk_s].[ServiceConfigurationID] = [tk_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [tk_s_t] ON [tk_s].[TemplateID] = [tk_s_t].[TemplateID] ";
				sqlCmdText += "WHERE [tk].[TranslationKeyID] = @TranslationKeyID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationKeyID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "loadinternal", "notfound"), "TranslationKey could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationKeyTable tkTable = new TranslationKeyTable(query);
				TranslationKeyTable tk_tkTable = (this.Depth > 0) ? new TranslationKeyTable(query) : null;
				TranslationKeyTable tk_tk_tkTable = (this.Depth > 1) ? new TranslationKeyTable(query) : null;
				TranslationTable tk_tk_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;
				LanguageTable tk_tk_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceTable tk_tk_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				TranslationTable tk_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable tk_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;
				LanguageTable tk_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				ServiceTable tk_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable tk_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable tk_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable tk_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable tk_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable tk_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable tk_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable tk_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable tk_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable tk_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        
				TranslationKey tk_tk_tkObject = (this.Depth > 1) ? tk_tk_tkTable.CreateInstance() : null;
				Translation tk_tk_tObject = (this.Depth > 1) ? tk_tk_tTable.CreateInstance() : null;
				Language tk_tk_lObject = (this.Depth > 1) ? tk_tk_lTable.CreateInstance() : null;
				Service tk_tk_sObject = (this.Depth > 1) ? tk_tk_sTable.CreateInstance() : null;
				TranslationKey tk_tkObject = (this.Depth > 0) ? tk_tkTable.CreateInstance(tk_tk_tkObject, tk_tk_tObject, tk_tk_lObject, tk_tk_sObject) : null;
				TranslationType tk_t_ttObject = (this.Depth > 1) ? tk_t_ttTable.CreateInstance() : null;
				Translation tk_tObject = (this.Depth > 0) ? tk_tTable.CreateInstance(tk_t_ttObject) : null;
				Language tk_lObject = (this.Depth > 0) ? tk_lTable.CreateInstance() : null;
				Application tk_s_aObject = (this.Depth > 1) ? tk_s_aTable.CreateInstance() : null;
				Product tk_s_pObject = (this.Depth > 1) ? tk_s_pTable.CreateInstance() : null;
				Merchant tk_s_mObject = (this.Depth > 1) ? tk_s_mTable.CreateInstance() : null;
				ServiceType tk_s_stObject = (this.Depth > 1) ? tk_s_stTable.CreateInstance() : null;
				UserSessionType tk_s_ustObject = (this.Depth > 1) ? tk_s_ustTable.CreateInstance() : null;
				Country tk_s_cObject = (this.Depth > 1) ? tk_s_cTable.CreateInstance() : null;
				Language tk_s_lObject = (this.Depth > 1) ? tk_s_lTable.CreateInstance() : null;
				ServiceConfiguration tk_s_scObject = (this.Depth > 1) ? tk_s_scTable.CreateInstance() : null;
				Template tk_s_tObject = (this.Depth > 1) ? tk_s_tTable.CreateInstance() : null;
				Service tk_sObject = (this.Depth > 0) ? tk_sTable.CreateInstance(tk_s_aObject, tk_s_pObject, tk_s_mObject, tk_s_stObject, tk_s_ustObject, tk_s_cObject, tk_s_lObject, tk_s_scObject, tk_s_tObject) : null;
				TranslationKey tkObject = tkTable.CreateInstance(tk_tkObject, tk_tObject, tk_lObject, tk_sObject);
				sqlReader.Close();

				return tkObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "loadinternal", "exception"), "TranslationKey could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationKey", "Exception while loading TranslationKey object from database. See inner exception for details.", ex);
      }
    }

    public TranslationKey Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (parameters == null)
        throw new ArgumentNullException("parameters");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT {0} " + 
							TranslationKeyTable.GetColumnNames("[tk]") + 
							(this.Depth > 0 ? "," + TranslationKeyTable.GetColumnNames("[tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationKeyTable.GetColumnNames("[tk_tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tk_tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tk_tk_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[tk_tk_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[tk_t_tt]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[tk_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[tk_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[tk_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[tk_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[tk_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[tk_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[tk_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[tk_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tk_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[tk_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[tk_s_t]") : string.Empty) +  
					" FROM [core].[TranslationKey] AS [tk] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tk_tk] ON [tk].[FallbackTranslationKeyID] = [tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tk_tk_tk] ON [tk_tk].[FallbackTranslationKeyID] = [tk_tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Translation] AS [tk_tk_t] ON [tk_tk].[TranslationID] = [tk_tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_tk_l] ON [tk_tk].[LanguageID] = [tk_tk_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tk_tk_s] ON [tk_tk].[ServiceID] = [tk_tk_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tk_t] ON [tk].[TranslationID] = [tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [tk_t_tt] ON [tk_t].[TranslationTypeID] = [tk_t_tt].[TranslationTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_l] ON [tk].[LanguageID] = [tk_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tk_s] ON [tk].[ServiceID] = [tk_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [tk_s_a] ON [tk_s].[ApplicationID] = [tk_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [tk_s_p] ON [tk_s].[ProductID] = [tk_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [tk_s_m] ON [tk_s].[MerchantID] = [tk_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [tk_s_st] ON [tk_s].[ServiceTypeID] = [tk_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [tk_s_ust] ON [tk_s].[UserSessionTypeID] = [tk_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [tk_s_c] ON [tk_s].[FallbackCountryID] = [tk_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_s_l] ON [tk_s].[FallbackLanguageID] = [tk_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [tk_s_sc] ON [tk_s].[ServiceConfigurationID] = [tk_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [tk_s_t] ON [tk_s].[TemplateID] = [tk_s_t].[TemplateID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "customload", "notfound"), "TranslationKey could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationKeyTable tkTable = new TranslationKeyTable(query);
				TranslationKeyTable tk_tkTable = (this.Depth > 0) ? new TranslationKeyTable(query) : null;
				TranslationKeyTable tk_tk_tkTable = (this.Depth > 1) ? new TranslationKeyTable(query) : null;
				TranslationTable tk_tk_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;
				LanguageTable tk_tk_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceTable tk_tk_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				TranslationTable tk_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable tk_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;
				LanguageTable tk_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				ServiceTable tk_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable tk_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable tk_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable tk_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable tk_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable tk_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable tk_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable tk_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable tk_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable tk_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        
				TranslationKey tk_tk_tkObject = (this.Depth > 1) ? tk_tk_tkTable.CreateInstance() : null;
				Translation tk_tk_tObject = (this.Depth > 1) ? tk_tk_tTable.CreateInstance() : null;
				Language tk_tk_lObject = (this.Depth > 1) ? tk_tk_lTable.CreateInstance() : null;
				Service tk_tk_sObject = (this.Depth > 1) ? tk_tk_sTable.CreateInstance() : null;
				TranslationKey tk_tkObject = (this.Depth > 0) ? tk_tkTable.CreateInstance(tk_tk_tkObject, tk_tk_tObject, tk_tk_lObject, tk_tk_sObject) : null;
				TranslationType tk_t_ttObject = (this.Depth > 1) ? tk_t_ttTable.CreateInstance() : null;
				Translation tk_tObject = (this.Depth > 0) ? tk_tTable.CreateInstance(tk_t_ttObject) : null;
				Language tk_lObject = (this.Depth > 0) ? tk_lTable.CreateInstance() : null;
				Application tk_s_aObject = (this.Depth > 1) ? tk_s_aTable.CreateInstance() : null;
				Product tk_s_pObject = (this.Depth > 1) ? tk_s_pTable.CreateInstance() : null;
				Merchant tk_s_mObject = (this.Depth > 1) ? tk_s_mTable.CreateInstance() : null;
				ServiceType tk_s_stObject = (this.Depth > 1) ? tk_s_stTable.CreateInstance() : null;
				UserSessionType tk_s_ustObject = (this.Depth > 1) ? tk_s_ustTable.CreateInstance() : null;
				Country tk_s_cObject = (this.Depth > 1) ? tk_s_cTable.CreateInstance() : null;
				Language tk_s_lObject = (this.Depth > 1) ? tk_s_lTable.CreateInstance() : null;
				ServiceConfiguration tk_s_scObject = (this.Depth > 1) ? tk_s_scTable.CreateInstance() : null;
				Template tk_s_tObject = (this.Depth > 1) ? tk_s_tTable.CreateInstance() : null;
				Service tk_sObject = (this.Depth > 0) ? tk_sTable.CreateInstance(tk_s_aObject, tk_s_pObject, tk_s_mObject, tk_s_stObject, tk_s_ustObject, tk_s_cObject, tk_s_lObject, tk_s_scObject, tk_s_tObject) : null;
				TranslationKey tkObject = tkTable.CreateInstance(tk_tkObject, tk_tObject, tk_lObject, tk_sObject);
				sqlReader.Close();

				return tkObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "customload", "exception"), "TranslationKey could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationKey", "Exception while loading (custom/single) TranslationKey object from database. See inner exception for details.", ex);
      }
    }

    public List<TranslationKey> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (parameters == null)
        throw new ArgumentNullException("parameters");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT {0} " + 
							TranslationKeyTable.GetColumnNames("[tk]") + 
							(this.Depth > 0 ? "," + TranslationKeyTable.GetColumnNames("[tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationKeyTable.GetColumnNames("[tk_tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tk_tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tk_tk_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[tk_tk_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[tk_t_tt]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[tk_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[tk_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[tk_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[tk_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[tk_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[tk_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[tk_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[tk_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tk_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[tk_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[tk_s_t]") : string.Empty) +  
					" FROM [core].[TranslationKey] AS [tk] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tk_tk] ON [tk].[FallbackTranslationKeyID] = [tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tk_tk_tk] ON [tk_tk].[FallbackTranslationKeyID] = [tk_tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Translation] AS [tk_tk_t] ON [tk_tk].[TranslationID] = [tk_tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_tk_l] ON [tk_tk].[LanguageID] = [tk_tk_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tk_tk_s] ON [tk_tk].[ServiceID] = [tk_tk_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tk_t] ON [tk].[TranslationID] = [tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [tk_t_tt] ON [tk_t].[TranslationTypeID] = [tk_t_tt].[TranslationTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_l] ON [tk].[LanguageID] = [tk_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tk_s] ON [tk].[ServiceID] = [tk_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [tk_s_a] ON [tk_s].[ApplicationID] = [tk_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [tk_s_p] ON [tk_s].[ProductID] = [tk_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [tk_s_m] ON [tk_s].[MerchantID] = [tk_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [tk_s_st] ON [tk_s].[ServiceTypeID] = [tk_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [tk_s_ust] ON [tk_s].[UserSessionTypeID] = [tk_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [tk_s_c] ON [tk_s].[FallbackCountryID] = [tk_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tk_s_l] ON [tk_s].[FallbackLanguageID] = [tk_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [tk_s_sc] ON [tk_s].[ServiceConfigurationID] = [tk_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [tk_s_t] ON [tk_s].[TemplateID] = [tk_s_t].[TemplateID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "customloadmany", "notfound"), "TranslationKey list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<TranslationKey>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationKeyTable tkTable = new TranslationKeyTable(query);
				TranslationKeyTable tk_tkTable = (this.Depth > 0) ? new TranslationKeyTable(query) : null;
				TranslationKeyTable tk_tk_tkTable = (this.Depth > 1) ? new TranslationKeyTable(query) : null;
				TranslationTable tk_tk_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;
				LanguageTable tk_tk_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceTable tk_tk_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				TranslationTable tk_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable tk_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;
				LanguageTable tk_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				ServiceTable tk_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable tk_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable tk_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable tk_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable tk_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable tk_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable tk_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable tk_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable tk_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable tk_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        List<TranslationKey> result = new List<TranslationKey>();
        do
        {
          
					TranslationKey tk_tk_tkObject = (this.Depth > 1) ? tk_tk_tkTable.CreateInstance() : null;
					Translation tk_tk_tObject = (this.Depth > 1) ? tk_tk_tTable.CreateInstance() : null;
					Language tk_tk_lObject = (this.Depth > 1) ? tk_tk_lTable.CreateInstance() : null;
					Service tk_tk_sObject = (this.Depth > 1) ? tk_tk_sTable.CreateInstance() : null;
					TranslationKey tk_tkObject = (this.Depth > 0) ? tk_tkTable.CreateInstance(tk_tk_tkObject, tk_tk_tObject, tk_tk_lObject, tk_tk_sObject) : null;
					TranslationType tk_t_ttObject = (this.Depth > 1) ? tk_t_ttTable.CreateInstance() : null;
					Translation tk_tObject = (this.Depth > 0) ? tk_tTable.CreateInstance(tk_t_ttObject) : null;
					Language tk_lObject = (this.Depth > 0) ? tk_lTable.CreateInstance() : null;
					Application tk_s_aObject = (this.Depth > 1) ? tk_s_aTable.CreateInstance() : null;
					Product tk_s_pObject = (this.Depth > 1) ? tk_s_pTable.CreateInstance() : null;
					Merchant tk_s_mObject = (this.Depth > 1) ? tk_s_mTable.CreateInstance() : null;
					ServiceType tk_s_stObject = (this.Depth > 1) ? tk_s_stTable.CreateInstance() : null;
					UserSessionType tk_s_ustObject = (this.Depth > 1) ? tk_s_ustTable.CreateInstance() : null;
					Country tk_s_cObject = (this.Depth > 1) ? tk_s_cTable.CreateInstance() : null;
					Language tk_s_lObject = (this.Depth > 1) ? tk_s_lTable.CreateInstance() : null;
					ServiceConfiguration tk_s_scObject = (this.Depth > 1) ? tk_s_scTable.CreateInstance() : null;
					Template tk_s_tObject = (this.Depth > 1) ? tk_s_tTable.CreateInstance() : null;
					Service tk_sObject = (this.Depth > 0) ? tk_sTable.CreateInstance(tk_s_aObject, tk_s_pObject, tk_s_mObject, tk_s_stObject, tk_s_ustObject, tk_s_cObject, tk_s_lObject, tk_s_scObject, tk_s_tObject) : null;
					TranslationKey tkObject = (this.Depth > -1) ? tkTable.CreateInstance(tk_tkObject, tk_tObject, tk_lObject, tk_sObject) : null;
					result.Add(tkObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "customloadmany", "exception"), "TranslationKey list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationKey", "Exception while loading (custom/many) TranslationKey object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, TranslationKey data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[TranslationKey] ([FallbackTranslationKeyID],[TranslationID],[LanguageID],[ServiceID],[Name]) VALUES(@FallbackTranslationKeyID,@TranslationID,@LanguageID,@ServiceID,@Name); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@FallbackTranslationKeyID", data.FallbackTranslationKey == null ? DBNull.Value : (object)data.FallbackTranslationKey.ID);
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.Translation.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language == null ? DBNull.Value : (object)data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "insert", "noprimarykey"), "TranslationKey could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "TranslationKey", "Exception while inserting TranslationKey object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "insert", "exception"), "TranslationKey could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "TranslationKey", "Exception while inserting TranslationKey object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, TranslationKey data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        data.Updated = DateTime.Now;
        sqlCmdText = "UPDATE [core].[TranslationKey] SET " +
												"[FallbackTranslationKeyID] = @FallbackTranslationKeyID, " + 
												"[TranslationID] = @TranslationID, " + 
												"[LanguageID] = @LanguageID, " + 
												"[ServiceID] = @ServiceID, " + 
												"[Name] = @Name, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [TranslationKeyID] = @TranslationKeyID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@FallbackTranslationKeyID", data.FallbackTranslationKey == null ? DBNull.Value : (object)data.FallbackTranslationKey.ID);
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.Translation.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language == null ? DBNull.Value : (object)data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@TranslationKeyID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "update", "norecord"), "TranslationKey could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationKey", "Exception while updating TranslationKey object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "update", "morerecords"), "TranslationKey was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationKey", "Exception while updating TranslationKey object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "update", "exception"), "TranslationKey could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "TranslationKey", "Exception while updating TranslationKey object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, TranslationKey data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[TranslationKey] WHERE TranslationKeyID = @TranslationKeyID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationKeyID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "delete", "norecord"), "TranslationKey could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "TranslationKey", "Exception while deleting TranslationKey object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tk", "delete", "exception"), "TranslationKey could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "TranslationKey", "Exception while deleting TranslationKey object from database. See inner exception for details.", ex);
      }
    }
  }
}

