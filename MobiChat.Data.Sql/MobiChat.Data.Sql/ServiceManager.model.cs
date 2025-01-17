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
  [DataManager(typeof(Service))] 
  public partial class ServiceManager : MobiChat.Data.Sql.SqlManagerBase<Service>, IServiceManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Service LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ServiceTable.GetColumnNames("[s]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[s_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[s_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ProductTable.GetColumnNames("[s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_p_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + MerchantTable.GetColumnNames("[s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_m_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[s_m_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTypeTable.GetColumnNames("[s_st]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserSessionTypeTable.GetColumnNames("[s_ust]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[s_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[s_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceConfigurationTable.GetColumnNames("[s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentConfigurationTable.GetColumnNames("[s_sc_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + TemplateTable.GetColumnNames("[s_t]") : string.Empty) + 
					" FROM [core].[Service] AS [s] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [s_a] ON [s].[ApplicationID] = [s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_a_i] ON [s_a].[InstanceID] = [s_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [s_a_at] ON [s_a].[ApplicationTypeID] = [s_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [s_a_rt] ON [s_a].[RuntimeTypeID] = [s_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [s_p] ON [s].[ProductID] = [s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_p_i] ON [s_p].[InstanceID] = [s_p_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [s_m] ON [s].[MerchantID] = [s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_m_i] ON [s_m].[InstanceID] = [s_m_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [s_m_t] ON [s_m].[TemplateID] = [s_m_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [s_st] ON [s].[ServiceTypeID] = [s_st].[ServiceTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [s_ust] ON [s].[UserSessionTypeID] = [s_ust].[UserSessionTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [s_c] ON [s].[FallbackCountryID] = [s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [s_c_l] ON [s_c].[LanguageID] = [s_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [s_l] ON [s].[FallbackLanguageID] = [s_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [s_sc] ON [s].[ServiceConfigurationID] = [s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [s_sc_pc] ON [s_sc].[PaymentConfigurationID] = [s_sc_pc].[PaymentConfigurationID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [s_t] ON [s].[TemplateID] = [s_t].[TemplateID] ";
				sqlCmdText += "WHERE [s].[ServiceID] = @ServiceID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "loadinternal", "notfound"), "Service could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceTable sTable = new ServiceTable(query);
				ApplicationTable s_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable s_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable s_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable s_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ProductTable s_pTable = (this.Depth > 0) ? new ProductTable(query) : null;
				InstanceTable s_p_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				MerchantTable s_mTable = (this.Depth > 0) ? new MerchantTable(query) : null;
				InstanceTable s_m_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				TemplateTable s_m_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				ServiceTypeTable s_stTable = (this.Depth > 0) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable s_ustTable = (this.Depth > 0) ? new UserSessionTypeTable(query) : null;
				CountryTable s_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable s_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable s_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				ServiceConfigurationTable s_scTable = (this.Depth > 0) ? new ServiceConfigurationTable(query) : null;
				PaymentConfigurationTable s_sc_pcTable = (this.Depth > 1) ? new PaymentConfigurationTable(query) : null;
				TemplateTable s_tTable = (this.Depth > 0) ? new TemplateTable(query) : null;

        
				Instance s_a_iObject = (this.Depth > 1) ? s_a_iTable.CreateInstance() : null;
				ApplicationType s_a_atObject = (this.Depth > 1) ? s_a_atTable.CreateInstance() : null;
				RuntimeType s_a_rtObject = (this.Depth > 1) ? s_a_rtTable.CreateInstance() : null;
				Application s_aObject = (this.Depth > 0) ? s_aTable.CreateInstance(s_a_iObject, s_a_atObject, s_a_rtObject) : null;
				Instance s_p_iObject = (this.Depth > 1) ? s_p_iTable.CreateInstance() : null;
				Product s_pObject = (this.Depth > 0) ? s_pTable.CreateInstance(s_p_iObject) : null;
				Instance s_m_iObject = (this.Depth > 1) ? s_m_iTable.CreateInstance() : null;
				Template s_m_tObject = (this.Depth > 1) ? s_m_tTable.CreateInstance() : null;
				Merchant s_mObject = (this.Depth > 0) ? s_mTable.CreateInstance(s_m_iObject, s_m_tObject) : null;
				ServiceType s_stObject = (this.Depth > 0) ? s_stTable.CreateInstance() : null;
				UserSessionType s_ustObject = (this.Depth > 0) ? s_ustTable.CreateInstance() : null;
				Language s_c_lObject = (this.Depth > 1) ? s_c_lTable.CreateInstance() : null;
				Country s_cObject = (this.Depth > 0) ? s_cTable.CreateInstance(s_c_lObject) : null;
				Language s_lObject = (this.Depth > 0) ? s_lTable.CreateInstance() : null;
				PaymentConfiguration s_sc_pcObject = (this.Depth > 1) ? s_sc_pcTable.CreateInstance() : null;
				ServiceConfiguration s_scObject = (this.Depth > 0) ? s_scTable.CreateInstance(s_sc_pcObject) : null;
				Template s_tObject = (this.Depth > 0) ? s_tTable.CreateInstance() : null;
				Service sObject = sTable.CreateInstance(s_aObject, s_pObject, s_mObject, s_stObject, s_ustObject, s_cObject, s_lObject, s_scObject, s_tObject);
				sqlReader.Close();

				return sObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "loadinternal", "exception"), "Service could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Service", "Exception while loading Service object from database. See inner exception for details.", ex);
      }
    }

    public Service Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceTable.GetColumnNames("[s]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[s_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[s_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ProductTable.GetColumnNames("[s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_p_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + MerchantTable.GetColumnNames("[s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_m_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[s_m_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTypeTable.GetColumnNames("[s_st]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserSessionTypeTable.GetColumnNames("[s_ust]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[s_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[s_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceConfigurationTable.GetColumnNames("[s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentConfigurationTable.GetColumnNames("[s_sc_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + TemplateTable.GetColumnNames("[s_t]") : string.Empty) +  
					" FROM [core].[Service] AS [s] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [s_a] ON [s].[ApplicationID] = [s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_a_i] ON [s_a].[InstanceID] = [s_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [s_a_at] ON [s_a].[ApplicationTypeID] = [s_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [s_a_rt] ON [s_a].[RuntimeTypeID] = [s_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [s_p] ON [s].[ProductID] = [s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_p_i] ON [s_p].[InstanceID] = [s_p_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [s_m] ON [s].[MerchantID] = [s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_m_i] ON [s_m].[InstanceID] = [s_m_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [s_m_t] ON [s_m].[TemplateID] = [s_m_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [s_st] ON [s].[ServiceTypeID] = [s_st].[ServiceTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [s_ust] ON [s].[UserSessionTypeID] = [s_ust].[UserSessionTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [s_c] ON [s].[FallbackCountryID] = [s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [s_c_l] ON [s_c].[LanguageID] = [s_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [s_l] ON [s].[FallbackLanguageID] = [s_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [s_sc] ON [s].[ServiceConfigurationID] = [s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [s_sc_pc] ON [s_sc].[PaymentConfigurationID] = [s_sc_pc].[PaymentConfigurationID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [s_t] ON [s].[TemplateID] = [s_t].[TemplateID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "customload", "notfound"), "Service could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceTable sTable = new ServiceTable(query);
				ApplicationTable s_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable s_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable s_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable s_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ProductTable s_pTable = (this.Depth > 0) ? new ProductTable(query) : null;
				InstanceTable s_p_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				MerchantTable s_mTable = (this.Depth > 0) ? new MerchantTable(query) : null;
				InstanceTable s_m_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				TemplateTable s_m_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				ServiceTypeTable s_stTable = (this.Depth > 0) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable s_ustTable = (this.Depth > 0) ? new UserSessionTypeTable(query) : null;
				CountryTable s_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable s_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable s_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				ServiceConfigurationTable s_scTable = (this.Depth > 0) ? new ServiceConfigurationTable(query) : null;
				PaymentConfigurationTable s_sc_pcTable = (this.Depth > 1) ? new PaymentConfigurationTable(query) : null;
				TemplateTable s_tTable = (this.Depth > 0) ? new TemplateTable(query) : null;

        
				Instance s_a_iObject = (this.Depth > 1) ? s_a_iTable.CreateInstance() : null;
				ApplicationType s_a_atObject = (this.Depth > 1) ? s_a_atTable.CreateInstance() : null;
				RuntimeType s_a_rtObject = (this.Depth > 1) ? s_a_rtTable.CreateInstance() : null;
				Application s_aObject = (this.Depth > 0) ? s_aTable.CreateInstance(s_a_iObject, s_a_atObject, s_a_rtObject) : null;
				Instance s_p_iObject = (this.Depth > 1) ? s_p_iTable.CreateInstance() : null;
				Product s_pObject = (this.Depth > 0) ? s_pTable.CreateInstance(s_p_iObject) : null;
				Instance s_m_iObject = (this.Depth > 1) ? s_m_iTable.CreateInstance() : null;
				Template s_m_tObject = (this.Depth > 1) ? s_m_tTable.CreateInstance() : null;
				Merchant s_mObject = (this.Depth > 0) ? s_mTable.CreateInstance(s_m_iObject, s_m_tObject) : null;
				ServiceType s_stObject = (this.Depth > 0) ? s_stTable.CreateInstance() : null;
				UserSessionType s_ustObject = (this.Depth > 0) ? s_ustTable.CreateInstance() : null;
				Language s_c_lObject = (this.Depth > 1) ? s_c_lTable.CreateInstance() : null;
				Country s_cObject = (this.Depth > 0) ? s_cTable.CreateInstance(s_c_lObject) : null;
				Language s_lObject = (this.Depth > 0) ? s_lTable.CreateInstance() : null;
				PaymentConfiguration s_sc_pcObject = (this.Depth > 1) ? s_sc_pcTable.CreateInstance() : null;
				ServiceConfiguration s_scObject = (this.Depth > 0) ? s_scTable.CreateInstance(s_sc_pcObject) : null;
				Template s_tObject = (this.Depth > 0) ? s_tTable.CreateInstance() : null;
				Service sObject = sTable.CreateInstance(s_aObject, s_pObject, s_mObject, s_stObject, s_ustObject, s_cObject, s_lObject, s_scObject, s_tObject);
				sqlReader.Close();

				return sObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "customload", "exception"), "Service could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Service", "Exception while loading (custom/single) Service object from database. See inner exception for details.", ex);
      }
    }

    public List<Service> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceTable.GetColumnNames("[s]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[s_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[s_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ProductTable.GetColumnNames("[s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_p_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + MerchantTable.GetColumnNames("[s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[s_m_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[s_m_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTypeTable.GetColumnNames("[s_st]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserSessionTypeTable.GetColumnNames("[s_ust]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[s_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[s_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceConfigurationTable.GetColumnNames("[s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentConfigurationTable.GetColumnNames("[s_sc_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + TemplateTable.GetColumnNames("[s_t]") : string.Empty) +  
					" FROM [core].[Service] AS [s] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [s_a] ON [s].[ApplicationID] = [s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_a_i] ON [s_a].[InstanceID] = [s_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [s_a_at] ON [s_a].[ApplicationTypeID] = [s_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [s_a_rt] ON [s_a].[RuntimeTypeID] = [s_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [s_p] ON [s].[ProductID] = [s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_p_i] ON [s_p].[InstanceID] = [s_p_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [s_m] ON [s].[MerchantID] = [s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [s_m_i] ON [s_m].[InstanceID] = [s_m_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [s_m_t] ON [s_m].[TemplateID] = [s_m_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [s_st] ON [s].[ServiceTypeID] = [s_st].[ServiceTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [s_ust] ON [s].[UserSessionTypeID] = [s_ust].[UserSessionTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [s_c] ON [s].[FallbackCountryID] = [s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [s_c_l] ON [s_c].[LanguageID] = [s_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [s_l] ON [s].[FallbackLanguageID] = [s_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [s_sc] ON [s].[ServiceConfigurationID] = [s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [s_sc_pc] ON [s_sc].[PaymentConfigurationID] = [s_sc_pc].[PaymentConfigurationID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [s_t] ON [s].[TemplateID] = [s_t].[TemplateID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "customloadmany", "notfound"), "Service list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Service>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceTable sTable = new ServiceTable(query);
				ApplicationTable s_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable s_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable s_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable s_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ProductTable s_pTable = (this.Depth > 0) ? new ProductTable(query) : null;
				InstanceTable s_p_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				MerchantTable s_mTable = (this.Depth > 0) ? new MerchantTable(query) : null;
				InstanceTable s_m_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				TemplateTable s_m_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				ServiceTypeTable s_stTable = (this.Depth > 0) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable s_ustTable = (this.Depth > 0) ? new UserSessionTypeTable(query) : null;
				CountryTable s_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable s_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable s_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				ServiceConfigurationTable s_scTable = (this.Depth > 0) ? new ServiceConfigurationTable(query) : null;
				PaymentConfigurationTable s_sc_pcTable = (this.Depth > 1) ? new PaymentConfigurationTable(query) : null;
				TemplateTable s_tTable = (this.Depth > 0) ? new TemplateTable(query) : null;

        List<Service> result = new List<Service>();
        do
        {
          
					Instance s_a_iObject = (this.Depth > 1) ? s_a_iTable.CreateInstance() : null;
					ApplicationType s_a_atObject = (this.Depth > 1) ? s_a_atTable.CreateInstance() : null;
					RuntimeType s_a_rtObject = (this.Depth > 1) ? s_a_rtTable.CreateInstance() : null;
					Application s_aObject = (this.Depth > 0) ? s_aTable.CreateInstance(s_a_iObject, s_a_atObject, s_a_rtObject) : null;
					Instance s_p_iObject = (this.Depth > 1) ? s_p_iTable.CreateInstance() : null;
					Product s_pObject = (this.Depth > 0) ? s_pTable.CreateInstance(s_p_iObject) : null;
					Instance s_m_iObject = (this.Depth > 1) ? s_m_iTable.CreateInstance() : null;
					Template s_m_tObject = (this.Depth > 1) ? s_m_tTable.CreateInstance() : null;
					Merchant s_mObject = (this.Depth > 0) ? s_mTable.CreateInstance(s_m_iObject, s_m_tObject) : null;
					ServiceType s_stObject = (this.Depth > 0) ? s_stTable.CreateInstance() : null;
					UserSessionType s_ustObject = (this.Depth > 0) ? s_ustTable.CreateInstance() : null;
					Language s_c_lObject = (this.Depth > 1) ? s_c_lTable.CreateInstance() : null;
					Country s_cObject = (this.Depth > 0) ? s_cTable.CreateInstance(s_c_lObject) : null;
					Language s_lObject = (this.Depth > 0) ? s_lTable.CreateInstance() : null;
					PaymentConfiguration s_sc_pcObject = (this.Depth > 1) ? s_sc_pcTable.CreateInstance() : null;
					ServiceConfiguration s_scObject = (this.Depth > 0) ? s_scTable.CreateInstance(s_sc_pcObject) : null;
					Template s_tObject = (this.Depth > 0) ? s_tTable.CreateInstance() : null;
					Service sObject = (this.Depth > -1) ? sTable.CreateInstance(s_aObject, s_pObject, s_mObject, s_stObject, s_ustObject, s_cObject, s_lObject, s_scObject, s_tObject) : null;
					result.Add(sObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "customloadmany", "exception"), "Service list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Service", "Exception while loading (custom/many) Service object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Service data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Service] ([ServiceGuid],[ApplicationID],[ProductID],[MerchantID],[ServiceStatusID],[ServiceTypeID],[UserSessionTypeID],[FallbackCountryID],[FallbackLanguageID],[ServiceConfigurationID],[TemplateID],[Name],[Description]) VALUES(@ServiceGuid,@ApplicationID,@ProductID,@MerchantID,@ServiceStatusID,@ServiceTypeID,@UserSessionTypeID,@FallbackCountryID,@FallbackLanguageID,@ServiceConfigurationID,@TemplateID,@Name,@Description); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@ProductID", data.Product.ID);
				sqlCmd.Parameters.AddWithValue("@MerchantID", data.Merchant.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceStatusID", (int)data.ServiceStatus);
				sqlCmd.Parameters.AddWithValue("@ServiceTypeID", data.ServiceType.ID);
				sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", data.UserSessionType.ID);
				sqlCmd.Parameters.AddWithValue("@FallbackCountryID", data.FallbackCountry.ID);
				sqlCmd.Parameters.AddWithValue("@FallbackLanguageID", data.FallbackLanguage.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", data.ServiceConfiguration.ID);
				sqlCmd.Parameters.AddWithValue("@TemplateID", data.Template.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", data.Description).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "insert", "noprimarykey"), "Service could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Service", "Exception while inserting Service object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "insert", "exception"), "Service could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Service", "Exception while inserting Service object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Service data)
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
        sqlCmdText = "UPDATE [core].[Service] SET " +
												"[ServiceGuid] = @ServiceGuid, " + 
												"[ApplicationID] = @ApplicationID, " + 
												"[ProductID] = @ProductID, " + 
												"[MerchantID] = @MerchantID, " + 
												"[ServiceStatusID] = @ServiceStatusID, " + 
												"[ServiceTypeID] = @ServiceTypeID, " + 
												"[UserSessionTypeID] = @UserSessionTypeID, " + 
												"[FallbackCountryID] = @FallbackCountryID, " + 
												"[FallbackLanguageID] = @FallbackLanguageID, " + 
												"[ServiceConfigurationID] = @ServiceConfigurationID, " + 
												"[TemplateID] = @TemplateID, " + 
												"[Name] = @Name, " + 
												"[Description] = @Description, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ServiceID] = @ServiceID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@ProductID", data.Product.ID);
				sqlCmd.Parameters.AddWithValue("@MerchantID", data.Merchant.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceStatusID", (int)data.ServiceStatus);
				sqlCmd.Parameters.AddWithValue("@ServiceTypeID", data.ServiceType.ID);
				sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", data.UserSessionType.ID);
				sqlCmd.Parameters.AddWithValue("@FallbackCountryID", data.FallbackCountry.ID);
				sqlCmd.Parameters.AddWithValue("@FallbackLanguageID", data.FallbackLanguage.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", data.ServiceConfiguration.ID);
				sqlCmd.Parameters.AddWithValue("@TemplateID", data.Template.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", data.Description).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "update", "norecord"), "Service could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Service", "Exception while updating Service object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "update", "morerecords"), "Service was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Service", "Exception while updating Service object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "update", "exception"), "Service could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Service", "Exception while updating Service object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Service data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Service] WHERE ServiceID = @ServiceID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "delete", "norecord"), "Service could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Service", "Exception while deleting Service object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("s", "delete", "exception"), "Service could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Service", "Exception while deleting Service object from database. See inner exception for details.", ex);
      }
    }
  }
}

