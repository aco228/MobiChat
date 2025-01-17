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
  [DataManager(typeof(ApplicationRouteSetMap))] 
  public partial class ApplicationRouteSetMapManager : MobiChat.Data.Sql.SqlManagerBase<ApplicationRouteSetMap>, IApplicationRouteSetMapManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ApplicationRouteSetMap LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ApplicationRouteSetMapTable.GetColumnNames("[arsm]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[arsm_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[arsm_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[arsm_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[arsm_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[arsm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[arsm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[arsm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[arsm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[arsm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[arsm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[arsm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[arsm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[arsm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[arsm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + RouteSetTable.GetColumnNames("[arsm_rs]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[arsm_rs_i]") : string.Empty) + 
					" FROM [core].[ApplicationRouteSetMap] AS [arsm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [arsm_a] ON [arsm].[ApplicationID] = [arsm_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [arsm_a_i] ON [arsm_a].[InstanceID] = [arsm_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [arsm_a_at] ON [arsm_a].[ApplicationTypeID] = [arsm_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [arsm_a_rt] ON [arsm_a].[RuntimeTypeID] = [arsm_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [arsm_s] ON [arsm].[ServiceID] = [arsm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [arsm_s_a] ON [arsm_s].[ApplicationID] = [arsm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [arsm_s_p] ON [arsm_s].[ProductID] = [arsm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [arsm_s_m] ON [arsm_s].[MerchantID] = [arsm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [arsm_s_st] ON [arsm_s].[ServiceTypeID] = [arsm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [arsm_s_ust] ON [arsm_s].[UserSessionTypeID] = [arsm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [arsm_s_c] ON [arsm_s].[FallbackCountryID] = [arsm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [arsm_s_l] ON [arsm_s].[FallbackLanguageID] = [arsm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [arsm_s_sc] ON [arsm_s].[ServiceConfigurationID] = [arsm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [arsm_s_t] ON [arsm_s].[TemplateID] = [arsm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [arsm_rs] ON [arsm].[RouteSetID] = [arsm_rs].[RouteSetID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [arsm_rs_i] ON [arsm_rs].[InstanceID] = [arsm_rs_i].[InstanceID] ";
				sqlCmdText += "WHERE [arsm].[ApplicationRouteSetMapID] = @ApplicationRouteSetMapID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ApplicationRouteSetMapID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "loadinternal", "notfound"), "ApplicationRouteSetMap could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ApplicationRouteSetMapTable arsmTable = new ApplicationRouteSetMapTable(query);
				ApplicationTable arsm_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable arsm_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable arsm_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable arsm_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ServiceTable arsm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable arsm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable arsm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable arsm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable arsm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable arsm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable arsm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable arsm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable arsm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable arsm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				RouteSetTable arsm_rsTable = (this.Depth > 0) ? new RouteSetTable(query) : null;
				InstanceTable arsm_rs_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;

        
				Instance arsm_a_iObject = (this.Depth > 1) ? arsm_a_iTable.CreateInstance() : null;
				ApplicationType arsm_a_atObject = (this.Depth > 1) ? arsm_a_atTable.CreateInstance() : null;
				RuntimeType arsm_a_rtObject = (this.Depth > 1) ? arsm_a_rtTable.CreateInstance() : null;
				Application arsm_aObject = (this.Depth > 0) ? arsm_aTable.CreateInstance(arsm_a_iObject, arsm_a_atObject, arsm_a_rtObject) : null;
				Application arsm_s_aObject = (this.Depth > 1) ? arsm_s_aTable.CreateInstance() : null;
				Product arsm_s_pObject = (this.Depth > 1) ? arsm_s_pTable.CreateInstance() : null;
				Merchant arsm_s_mObject = (this.Depth > 1) ? arsm_s_mTable.CreateInstance() : null;
				ServiceType arsm_s_stObject = (this.Depth > 1) ? arsm_s_stTable.CreateInstance() : null;
				UserSessionType arsm_s_ustObject = (this.Depth > 1) ? arsm_s_ustTable.CreateInstance() : null;
				Country arsm_s_cObject = (this.Depth > 1) ? arsm_s_cTable.CreateInstance() : null;
				Language arsm_s_lObject = (this.Depth > 1) ? arsm_s_lTable.CreateInstance() : null;
				ServiceConfiguration arsm_s_scObject = (this.Depth > 1) ? arsm_s_scTable.CreateInstance() : null;
				Template arsm_s_tObject = (this.Depth > 1) ? arsm_s_tTable.CreateInstance() : null;
				Service arsm_sObject = (this.Depth > 0) ? arsm_sTable.CreateInstance(arsm_s_aObject, arsm_s_pObject, arsm_s_mObject, arsm_s_stObject, arsm_s_ustObject, arsm_s_cObject, arsm_s_lObject, arsm_s_scObject, arsm_s_tObject) : null;
				Instance arsm_rs_iObject = (this.Depth > 1) ? arsm_rs_iTable.CreateInstance() : null;
				RouteSet arsm_rsObject = (this.Depth > 0) ? arsm_rsTable.CreateInstance(arsm_rs_iObject) : null;
				ApplicationRouteSetMap arsmObject = arsmTable.CreateInstance(arsm_aObject, arsm_sObject, arsm_rsObject);
				sqlReader.Close();

				return arsmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "loadinternal", "exception"), "ApplicationRouteSetMap could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ApplicationRouteSetMap", "Exception while loading ApplicationRouteSetMap object from database. See inner exception for details.", ex);
      }
    }

    public ApplicationRouteSetMap Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ApplicationRouteSetMapTable.GetColumnNames("[arsm]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[arsm_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[arsm_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[arsm_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[arsm_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[arsm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[arsm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[arsm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[arsm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[arsm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[arsm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[arsm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[arsm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[arsm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[arsm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + RouteSetTable.GetColumnNames("[arsm_rs]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[arsm_rs_i]") : string.Empty) +  
					" FROM [core].[ApplicationRouteSetMap] AS [arsm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [arsm_a] ON [arsm].[ApplicationID] = [arsm_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [arsm_a_i] ON [arsm_a].[InstanceID] = [arsm_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [arsm_a_at] ON [arsm_a].[ApplicationTypeID] = [arsm_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [arsm_a_rt] ON [arsm_a].[RuntimeTypeID] = [arsm_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [arsm_s] ON [arsm].[ServiceID] = [arsm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [arsm_s_a] ON [arsm_s].[ApplicationID] = [arsm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [arsm_s_p] ON [arsm_s].[ProductID] = [arsm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [arsm_s_m] ON [arsm_s].[MerchantID] = [arsm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [arsm_s_st] ON [arsm_s].[ServiceTypeID] = [arsm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [arsm_s_ust] ON [arsm_s].[UserSessionTypeID] = [arsm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [arsm_s_c] ON [arsm_s].[FallbackCountryID] = [arsm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [arsm_s_l] ON [arsm_s].[FallbackLanguageID] = [arsm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [arsm_s_sc] ON [arsm_s].[ServiceConfigurationID] = [arsm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [arsm_s_t] ON [arsm_s].[TemplateID] = [arsm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [arsm_rs] ON [arsm].[RouteSetID] = [arsm_rs].[RouteSetID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [arsm_rs_i] ON [arsm_rs].[InstanceID] = [arsm_rs_i].[InstanceID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "customload", "notfound"), "ApplicationRouteSetMap could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ApplicationRouteSetMapTable arsmTable = new ApplicationRouteSetMapTable(query);
				ApplicationTable arsm_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable arsm_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable arsm_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable arsm_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ServiceTable arsm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable arsm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable arsm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable arsm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable arsm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable arsm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable arsm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable arsm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable arsm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable arsm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				RouteSetTable arsm_rsTable = (this.Depth > 0) ? new RouteSetTable(query) : null;
				InstanceTable arsm_rs_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;

        
				Instance arsm_a_iObject = (this.Depth > 1) ? arsm_a_iTable.CreateInstance() : null;
				ApplicationType arsm_a_atObject = (this.Depth > 1) ? arsm_a_atTable.CreateInstance() : null;
				RuntimeType arsm_a_rtObject = (this.Depth > 1) ? arsm_a_rtTable.CreateInstance() : null;
				Application arsm_aObject = (this.Depth > 0) ? arsm_aTable.CreateInstance(arsm_a_iObject, arsm_a_atObject, arsm_a_rtObject) : null;
				Application arsm_s_aObject = (this.Depth > 1) ? arsm_s_aTable.CreateInstance() : null;
				Product arsm_s_pObject = (this.Depth > 1) ? arsm_s_pTable.CreateInstance() : null;
				Merchant arsm_s_mObject = (this.Depth > 1) ? arsm_s_mTable.CreateInstance() : null;
				ServiceType arsm_s_stObject = (this.Depth > 1) ? arsm_s_stTable.CreateInstance() : null;
				UserSessionType arsm_s_ustObject = (this.Depth > 1) ? arsm_s_ustTable.CreateInstance() : null;
				Country arsm_s_cObject = (this.Depth > 1) ? arsm_s_cTable.CreateInstance() : null;
				Language arsm_s_lObject = (this.Depth > 1) ? arsm_s_lTable.CreateInstance() : null;
				ServiceConfiguration arsm_s_scObject = (this.Depth > 1) ? arsm_s_scTable.CreateInstance() : null;
				Template arsm_s_tObject = (this.Depth > 1) ? arsm_s_tTable.CreateInstance() : null;
				Service arsm_sObject = (this.Depth > 0) ? arsm_sTable.CreateInstance(arsm_s_aObject, arsm_s_pObject, arsm_s_mObject, arsm_s_stObject, arsm_s_ustObject, arsm_s_cObject, arsm_s_lObject, arsm_s_scObject, arsm_s_tObject) : null;
				Instance arsm_rs_iObject = (this.Depth > 1) ? arsm_rs_iTable.CreateInstance() : null;
				RouteSet arsm_rsObject = (this.Depth > 0) ? arsm_rsTable.CreateInstance(arsm_rs_iObject) : null;
				ApplicationRouteSetMap arsmObject = arsmTable.CreateInstance(arsm_aObject, arsm_sObject, arsm_rsObject);
				sqlReader.Close();

				return arsmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "customload", "exception"), "ApplicationRouteSetMap could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ApplicationRouteSetMap", "Exception while loading (custom/single) ApplicationRouteSetMap object from database. See inner exception for details.", ex);
      }
    }

    public List<ApplicationRouteSetMap> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ApplicationRouteSetMapTable.GetColumnNames("[arsm]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[arsm_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[arsm_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[arsm_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[arsm_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[arsm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[arsm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[arsm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[arsm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[arsm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[arsm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[arsm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[arsm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[arsm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[arsm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + RouteSetTable.GetColumnNames("[arsm_rs]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[arsm_rs_i]") : string.Empty) +  
					" FROM [core].[ApplicationRouteSetMap] AS [arsm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [arsm_a] ON [arsm].[ApplicationID] = [arsm_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [arsm_a_i] ON [arsm_a].[InstanceID] = [arsm_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [arsm_a_at] ON [arsm_a].[ApplicationTypeID] = [arsm_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [arsm_a_rt] ON [arsm_a].[RuntimeTypeID] = [arsm_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [arsm_s] ON [arsm].[ServiceID] = [arsm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [arsm_s_a] ON [arsm_s].[ApplicationID] = [arsm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [arsm_s_p] ON [arsm_s].[ProductID] = [arsm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [arsm_s_m] ON [arsm_s].[MerchantID] = [arsm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [arsm_s_st] ON [arsm_s].[ServiceTypeID] = [arsm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [arsm_s_ust] ON [arsm_s].[UserSessionTypeID] = [arsm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [arsm_s_c] ON [arsm_s].[FallbackCountryID] = [arsm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [arsm_s_l] ON [arsm_s].[FallbackLanguageID] = [arsm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [arsm_s_sc] ON [arsm_s].[ServiceConfigurationID] = [arsm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [arsm_s_t] ON [arsm_s].[TemplateID] = [arsm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [arsm_rs] ON [arsm].[RouteSetID] = [arsm_rs].[RouteSetID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [arsm_rs_i] ON [arsm_rs].[InstanceID] = [arsm_rs_i].[InstanceID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "customloadmany", "notfound"), "ApplicationRouteSetMap list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ApplicationRouteSetMap>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ApplicationRouteSetMapTable arsmTable = new ApplicationRouteSetMapTable(query);
				ApplicationTable arsm_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable arsm_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable arsm_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable arsm_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ServiceTable arsm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable arsm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable arsm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable arsm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable arsm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable arsm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable arsm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable arsm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable arsm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable arsm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				RouteSetTable arsm_rsTable = (this.Depth > 0) ? new RouteSetTable(query) : null;
				InstanceTable arsm_rs_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;

        List<ApplicationRouteSetMap> result = new List<ApplicationRouteSetMap>();
        do
        {
          
					Instance arsm_a_iObject = (this.Depth > 1) ? arsm_a_iTable.CreateInstance() : null;
					ApplicationType arsm_a_atObject = (this.Depth > 1) ? arsm_a_atTable.CreateInstance() : null;
					RuntimeType arsm_a_rtObject = (this.Depth > 1) ? arsm_a_rtTable.CreateInstance() : null;
					Application arsm_aObject = (this.Depth > 0) ? arsm_aTable.CreateInstance(arsm_a_iObject, arsm_a_atObject, arsm_a_rtObject) : null;
					Application arsm_s_aObject = (this.Depth > 1) ? arsm_s_aTable.CreateInstance() : null;
					Product arsm_s_pObject = (this.Depth > 1) ? arsm_s_pTable.CreateInstance() : null;
					Merchant arsm_s_mObject = (this.Depth > 1) ? arsm_s_mTable.CreateInstance() : null;
					ServiceType arsm_s_stObject = (this.Depth > 1) ? arsm_s_stTable.CreateInstance() : null;
					UserSessionType arsm_s_ustObject = (this.Depth > 1) ? arsm_s_ustTable.CreateInstance() : null;
					Country arsm_s_cObject = (this.Depth > 1) ? arsm_s_cTable.CreateInstance() : null;
					Language arsm_s_lObject = (this.Depth > 1) ? arsm_s_lTable.CreateInstance() : null;
					ServiceConfiguration arsm_s_scObject = (this.Depth > 1) ? arsm_s_scTable.CreateInstance() : null;
					Template arsm_s_tObject = (this.Depth > 1) ? arsm_s_tTable.CreateInstance() : null;
					Service arsm_sObject = (this.Depth > 0) ? arsm_sTable.CreateInstance(arsm_s_aObject, arsm_s_pObject, arsm_s_mObject, arsm_s_stObject, arsm_s_ustObject, arsm_s_cObject, arsm_s_lObject, arsm_s_scObject, arsm_s_tObject) : null;
					Instance arsm_rs_iObject = (this.Depth > 1) ? arsm_rs_iTable.CreateInstance() : null;
					RouteSet arsm_rsObject = (this.Depth > 0) ? arsm_rsTable.CreateInstance(arsm_rs_iObject) : null;
					ApplicationRouteSetMap arsmObject = (this.Depth > -1) ? arsmTable.CreateInstance(arsm_aObject, arsm_sObject, arsm_rsObject) : null;
					result.Add(arsmObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "customloadmany", "exception"), "ApplicationRouteSetMap list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ApplicationRouteSetMap", "Exception while loading (custom/many) ApplicationRouteSetMap object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ApplicationRouteSetMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ApplicationRouteSetMap] ([ApplicationID],[ServiceID],[RouteSetID]) VALUES(@ApplicationID,@ServiceID,@RouteSetID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@RouteSetID", data.RouteSet.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "insert", "noprimarykey"), "ApplicationRouteSetMap could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ApplicationRouteSetMap", "Exception while inserting ApplicationRouteSetMap object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "insert", "exception"), "ApplicationRouteSetMap could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ApplicationRouteSetMap", "Exception while inserting ApplicationRouteSetMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ApplicationRouteSetMap data)
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
        sqlCmdText = "UPDATE [core].[ApplicationRouteSetMap] SET " +
												"[ApplicationID] = @ApplicationID, " + 
												"[ServiceID] = @ServiceID, " + 
												"[RouteSetID] = @RouteSetID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ApplicationRouteSetMapID] = @ApplicationRouteSetMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@RouteSetID", data.RouteSet.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ApplicationRouteSetMapID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "update", "norecord"), "ApplicationRouteSetMap could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ApplicationRouteSetMap", "Exception while updating ApplicationRouteSetMap object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "update", "morerecords"), "ApplicationRouteSetMap was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ApplicationRouteSetMap", "Exception while updating ApplicationRouteSetMap object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "update", "exception"), "ApplicationRouteSetMap could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ApplicationRouteSetMap", "Exception while updating ApplicationRouteSetMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ApplicationRouteSetMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ApplicationRouteSetMap] WHERE ApplicationRouteSetMapID = @ApplicationRouteSetMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ApplicationRouteSetMapID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "delete", "norecord"), "ApplicationRouteSetMap could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ApplicationRouteSetMap", "Exception while deleting ApplicationRouteSetMap object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("arsm", "delete", "exception"), "ApplicationRouteSetMap could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ApplicationRouteSetMap", "Exception while deleting ApplicationRouteSetMap object from database. See inner exception for details.", ex);
      }
    }
  }
}

