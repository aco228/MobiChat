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
  [DataManager(typeof(ServiceSendNumberMap))] 
  public partial class ServiceSendNumberMapManager : MobiChat.Data.Sql.SqlManagerBase<ServiceSendNumberMap>, IServiceSendNumberMapManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ServiceSendNumberMap LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ServiceSendNumberMapTable.GetColumnNames("[ssnm]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[ssnm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[ssnm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[ssnm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[ssnm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[ssnm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[ssnm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[ssnm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[ssnm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[ssnm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[ssnm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + SendNumberTypeTable.GetColumnNames("[ssnm_snt]") : string.Empty) + 
					" FROM [core].[ServiceSendNumberMap] AS [ssnm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [ssnm_s] ON [ssnm].[ServiceID] = [ssnm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [ssnm_s_a] ON [ssnm_s].[ApplicationID] = [ssnm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [ssnm_s_p] ON [ssnm_s].[ProductID] = [ssnm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [ssnm_s_m] ON [ssnm_s].[MerchantID] = [ssnm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [ssnm_s_st] ON [ssnm_s].[ServiceTypeID] = [ssnm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [ssnm_s_ust] ON [ssnm_s].[UserSessionTypeID] = [ssnm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [ssnm_s_c] ON [ssnm_s].[FallbackCountryID] = [ssnm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [ssnm_s_l] ON [ssnm_s].[FallbackLanguageID] = [ssnm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [ssnm_s_sc] ON [ssnm_s].[ServiceConfigurationID] = [ssnm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [ssnm_s_t] ON [ssnm_s].[TemplateID] = [ssnm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[SendNumberType] AS [ssnm_snt] ON [ssnm].[SendNumberTypeID] = [ssnm_snt].[SendNumberTypeID] ";
				sqlCmdText += "WHERE [ssnm].[ServiceSendNumberMapID] = @ServiceSendNumberMapID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceSendNumberMapID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "loadinternal", "notfound"), "ServiceSendNumberMap could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceSendNumberMapTable ssnmTable = new ServiceSendNumberMapTable(query);
				ServiceTable ssnm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable ssnm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable ssnm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable ssnm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable ssnm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable ssnm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable ssnm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable ssnm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable ssnm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable ssnm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				SendNumberTypeTable ssnm_sntTable = (this.Depth > 0) ? new SendNumberTypeTable(query) : null;

        
				Application ssnm_s_aObject = (this.Depth > 1) ? ssnm_s_aTable.CreateInstance() : null;
				Product ssnm_s_pObject = (this.Depth > 1) ? ssnm_s_pTable.CreateInstance() : null;
				Merchant ssnm_s_mObject = (this.Depth > 1) ? ssnm_s_mTable.CreateInstance() : null;
				ServiceType ssnm_s_stObject = (this.Depth > 1) ? ssnm_s_stTable.CreateInstance() : null;
				UserSessionType ssnm_s_ustObject = (this.Depth > 1) ? ssnm_s_ustTable.CreateInstance() : null;
				Country ssnm_s_cObject = (this.Depth > 1) ? ssnm_s_cTable.CreateInstance() : null;
				Language ssnm_s_lObject = (this.Depth > 1) ? ssnm_s_lTable.CreateInstance() : null;
				ServiceConfiguration ssnm_s_scObject = (this.Depth > 1) ? ssnm_s_scTable.CreateInstance() : null;
				Template ssnm_s_tObject = (this.Depth > 1) ? ssnm_s_tTable.CreateInstance() : null;
				Service ssnm_sObject = (this.Depth > 0) ? ssnm_sTable.CreateInstance(ssnm_s_aObject, ssnm_s_pObject, ssnm_s_mObject, ssnm_s_stObject, ssnm_s_ustObject, ssnm_s_cObject, ssnm_s_lObject, ssnm_s_scObject, ssnm_s_tObject) : null;
				SendNumberType ssnm_sntObject = (this.Depth > 0) ? ssnm_sntTable.CreateInstance() : null;
				ServiceSendNumberMap ssnmObject = ssnmTable.CreateInstance(ssnm_sObject, ssnm_sntObject);
				sqlReader.Close();

				return ssnmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "loadinternal", "exception"), "ServiceSendNumberMap could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceSendNumberMap", "Exception while loading ServiceSendNumberMap object from database. See inner exception for details.", ex);
      }
    }

    public ServiceSendNumberMap Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceSendNumberMapTable.GetColumnNames("[ssnm]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[ssnm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[ssnm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[ssnm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[ssnm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[ssnm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[ssnm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[ssnm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[ssnm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[ssnm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[ssnm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + SendNumberTypeTable.GetColumnNames("[ssnm_snt]") : string.Empty) +  
					" FROM [core].[ServiceSendNumberMap] AS [ssnm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [ssnm_s] ON [ssnm].[ServiceID] = [ssnm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [ssnm_s_a] ON [ssnm_s].[ApplicationID] = [ssnm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [ssnm_s_p] ON [ssnm_s].[ProductID] = [ssnm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [ssnm_s_m] ON [ssnm_s].[MerchantID] = [ssnm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [ssnm_s_st] ON [ssnm_s].[ServiceTypeID] = [ssnm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [ssnm_s_ust] ON [ssnm_s].[UserSessionTypeID] = [ssnm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [ssnm_s_c] ON [ssnm_s].[FallbackCountryID] = [ssnm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [ssnm_s_l] ON [ssnm_s].[FallbackLanguageID] = [ssnm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [ssnm_s_sc] ON [ssnm_s].[ServiceConfigurationID] = [ssnm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [ssnm_s_t] ON [ssnm_s].[TemplateID] = [ssnm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[SendNumberType] AS [ssnm_snt] ON [ssnm].[SendNumberTypeID] = [ssnm_snt].[SendNumberTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "customload", "notfound"), "ServiceSendNumberMap could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceSendNumberMapTable ssnmTable = new ServiceSendNumberMapTable(query);
				ServiceTable ssnm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable ssnm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable ssnm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable ssnm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable ssnm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable ssnm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable ssnm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable ssnm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable ssnm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable ssnm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				SendNumberTypeTable ssnm_sntTable = (this.Depth > 0) ? new SendNumberTypeTable(query) : null;

        
				Application ssnm_s_aObject = (this.Depth > 1) ? ssnm_s_aTable.CreateInstance() : null;
				Product ssnm_s_pObject = (this.Depth > 1) ? ssnm_s_pTable.CreateInstance() : null;
				Merchant ssnm_s_mObject = (this.Depth > 1) ? ssnm_s_mTable.CreateInstance() : null;
				ServiceType ssnm_s_stObject = (this.Depth > 1) ? ssnm_s_stTable.CreateInstance() : null;
				UserSessionType ssnm_s_ustObject = (this.Depth > 1) ? ssnm_s_ustTable.CreateInstance() : null;
				Country ssnm_s_cObject = (this.Depth > 1) ? ssnm_s_cTable.CreateInstance() : null;
				Language ssnm_s_lObject = (this.Depth > 1) ? ssnm_s_lTable.CreateInstance() : null;
				ServiceConfiguration ssnm_s_scObject = (this.Depth > 1) ? ssnm_s_scTable.CreateInstance() : null;
				Template ssnm_s_tObject = (this.Depth > 1) ? ssnm_s_tTable.CreateInstance() : null;
				Service ssnm_sObject = (this.Depth > 0) ? ssnm_sTable.CreateInstance(ssnm_s_aObject, ssnm_s_pObject, ssnm_s_mObject, ssnm_s_stObject, ssnm_s_ustObject, ssnm_s_cObject, ssnm_s_lObject, ssnm_s_scObject, ssnm_s_tObject) : null;
				SendNumberType ssnm_sntObject = (this.Depth > 0) ? ssnm_sntTable.CreateInstance() : null;
				ServiceSendNumberMap ssnmObject = ssnmTable.CreateInstance(ssnm_sObject, ssnm_sntObject);
				sqlReader.Close();

				return ssnmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "customload", "exception"), "ServiceSendNumberMap could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceSendNumberMap", "Exception while loading (custom/single) ServiceSendNumberMap object from database. See inner exception for details.", ex);
      }
    }

    public List<ServiceSendNumberMap> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceSendNumberMapTable.GetColumnNames("[ssnm]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[ssnm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[ssnm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[ssnm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[ssnm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[ssnm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[ssnm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[ssnm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[ssnm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[ssnm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[ssnm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + SendNumberTypeTable.GetColumnNames("[ssnm_snt]") : string.Empty) +  
					" FROM [core].[ServiceSendNumberMap] AS [ssnm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [ssnm_s] ON [ssnm].[ServiceID] = [ssnm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [ssnm_s_a] ON [ssnm_s].[ApplicationID] = [ssnm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [ssnm_s_p] ON [ssnm_s].[ProductID] = [ssnm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [ssnm_s_m] ON [ssnm_s].[MerchantID] = [ssnm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [ssnm_s_st] ON [ssnm_s].[ServiceTypeID] = [ssnm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [ssnm_s_ust] ON [ssnm_s].[UserSessionTypeID] = [ssnm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [ssnm_s_c] ON [ssnm_s].[FallbackCountryID] = [ssnm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [ssnm_s_l] ON [ssnm_s].[FallbackLanguageID] = [ssnm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [ssnm_s_sc] ON [ssnm_s].[ServiceConfigurationID] = [ssnm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [ssnm_s_t] ON [ssnm_s].[TemplateID] = [ssnm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[SendNumberType] AS [ssnm_snt] ON [ssnm].[SendNumberTypeID] = [ssnm_snt].[SendNumberTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "customloadmany", "notfound"), "ServiceSendNumberMap list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ServiceSendNumberMap>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceSendNumberMapTable ssnmTable = new ServiceSendNumberMapTable(query);
				ServiceTable ssnm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable ssnm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable ssnm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable ssnm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable ssnm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable ssnm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable ssnm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable ssnm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable ssnm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable ssnm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				SendNumberTypeTable ssnm_sntTable = (this.Depth > 0) ? new SendNumberTypeTable(query) : null;

        List<ServiceSendNumberMap> result = new List<ServiceSendNumberMap>();
        do
        {
          
					Application ssnm_s_aObject = (this.Depth > 1) ? ssnm_s_aTable.CreateInstance() : null;
					Product ssnm_s_pObject = (this.Depth > 1) ? ssnm_s_pTable.CreateInstance() : null;
					Merchant ssnm_s_mObject = (this.Depth > 1) ? ssnm_s_mTable.CreateInstance() : null;
					ServiceType ssnm_s_stObject = (this.Depth > 1) ? ssnm_s_stTable.CreateInstance() : null;
					UserSessionType ssnm_s_ustObject = (this.Depth > 1) ? ssnm_s_ustTable.CreateInstance() : null;
					Country ssnm_s_cObject = (this.Depth > 1) ? ssnm_s_cTable.CreateInstance() : null;
					Language ssnm_s_lObject = (this.Depth > 1) ? ssnm_s_lTable.CreateInstance() : null;
					ServiceConfiguration ssnm_s_scObject = (this.Depth > 1) ? ssnm_s_scTable.CreateInstance() : null;
					Template ssnm_s_tObject = (this.Depth > 1) ? ssnm_s_tTable.CreateInstance() : null;
					Service ssnm_sObject = (this.Depth > 0) ? ssnm_sTable.CreateInstance(ssnm_s_aObject, ssnm_s_pObject, ssnm_s_mObject, ssnm_s_stObject, ssnm_s_ustObject, ssnm_s_cObject, ssnm_s_lObject, ssnm_s_scObject, ssnm_s_tObject) : null;
					SendNumberType ssnm_sntObject = (this.Depth > 0) ? ssnm_sntTable.CreateInstance() : null;
					ServiceSendNumberMap ssnmObject = (this.Depth > -1) ? ssnmTable.CreateInstance(ssnm_sObject, ssnm_sntObject) : null;
					result.Add(ssnmObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "customloadmany", "exception"), "ServiceSendNumberMap list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceSendNumberMap", "Exception while loading (custom/many) ServiceSendNumberMap object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ServiceSendNumberMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ServiceSendNumberMap] ([ServiceID],[SendNumberTypeID],[Messages],[IsActive]) VALUES(@ServiceID,@SendNumberTypeID,@Messages,@IsActive); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@SendNumberTypeID", data.SendNumberType.ID);
				sqlCmd.Parameters.AddWithValue("@Messages", !string.IsNullOrEmpty(data.Messages) ? (object)data.Messages : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "insert", "noprimarykey"), "ServiceSendNumberMap could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ServiceSendNumberMap", "Exception while inserting ServiceSendNumberMap object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "insert", "exception"), "ServiceSendNumberMap could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ServiceSendNumberMap", "Exception while inserting ServiceSendNumberMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ServiceSendNumberMap data)
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
        sqlCmdText = "UPDATE [core].[ServiceSendNumberMap] SET " +
												"[ServiceID] = @ServiceID, " + 
												"[SendNumberTypeID] = @SendNumberTypeID, " + 
												"[Messages] = @Messages, " + 
												"[IsActive] = @IsActive, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ServiceSendNumberMapID] = @ServiceSendNumberMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@SendNumberTypeID", data.SendNumberType.ID);
				sqlCmd.Parameters.AddWithValue("@Messages", !string.IsNullOrEmpty(data.Messages) ? (object)data.Messages : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ServiceSendNumberMapID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "update", "norecord"), "ServiceSendNumberMap could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceSendNumberMap", "Exception while updating ServiceSendNumberMap object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "update", "morerecords"), "ServiceSendNumberMap was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceSendNumberMap", "Exception while updating ServiceSendNumberMap object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "update", "exception"), "ServiceSendNumberMap could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ServiceSendNumberMap", "Exception while updating ServiceSendNumberMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ServiceSendNumberMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ServiceSendNumberMap] WHERE ServiceSendNumberMapID = @ServiceSendNumberMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceSendNumberMapID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "delete", "norecord"), "ServiceSendNumberMap could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ServiceSendNumberMap", "Exception while deleting ServiceSendNumberMap object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ssnm", "delete", "exception"), "ServiceSendNumberMap could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ServiceSendNumberMap", "Exception while deleting ServiceSendNumberMap object from database. See inner exception for details.", ex);
      }
    }
  }
}

