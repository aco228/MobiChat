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



namespace MobiChat.Web.Data.Sql
{
  [DataManager(typeof(Message))] 
  public partial class MessageManager : MobiChat.Data.Sql.SqlManagerBase<Message>, IMessageManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Message LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							MessageTable.GetColumnNames("[m]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[m_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[m_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[m_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[m_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[m_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[m_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[m_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[m_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + CustomerTable.GetColumnNames("[m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[m_c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[m_c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[m_c_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[m_c_mo]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[m_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_mo_c]") : string.Empty) + 
					" FROM [stats].[Message] AS [m] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [m_s] ON [m].[ServiceID] = [m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [m_s_a] ON [m_s].[ApplicationID] = [m_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [m_s_p] ON [m_s].[ProductID] = [m_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [m_s_m] ON [m_s].[MerchantID] = [m_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [m_s_st] ON [m_s].[ServiceTypeID] = [m_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [m_s_ust] ON [m_s].[UserSessionTypeID] = [m_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [m_s_c] ON [m_s].[FallbackCountryID] = [m_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [m_s_l] ON [m_s].[FallbackLanguageID] = [m_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [m_s_sc] ON [m_s].[ServiceConfigurationID] = [m_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [m_s_t] ON [m_s].[TemplateID] = [m_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [m_c] ON [m].[CustomerID] = [m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [m_c_u] ON [m_c].[UserID] = [m_c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [m_c_s] ON [m_c].[ServiceID] = [m_c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [m_c_c] ON [m_c].[CountryID] = [m_c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [m_c_l] ON [m_c].[LanguageID] = [m_c_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [m_c_mo] ON [m_c].[MobileOperatorID] = [m_c_mo].[MobileOperatorID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [m_mo] ON [m].[MobileOperatorID] = [m_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [m_mo_c] ON [m_mo].[CountryID] = [m_mo_c].[CountryID] ";
				sqlCmdText += "WHERE [m].[MessageID] = @MessageID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MessageID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "loadinternal", "notfound"), "Message could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MessageTable mTable = new MessageTable(query);
				ServiceTable m_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable m_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable m_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable m_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable m_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable m_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable m_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable m_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable m_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable m_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				CustomerTable m_cTable = (this.Depth > 0) ? new CustomerTable(query) : null;
				UserTable m_c_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				ServiceTable m_c_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CountryTable m_c_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable m_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				MobileOperatorTable m_c_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;
				MobileOperatorTable m_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable m_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        
				Application m_s_aObject = (this.Depth > 1) ? m_s_aTable.CreateInstance() : null;
				Product m_s_pObject = (this.Depth > 1) ? m_s_pTable.CreateInstance() : null;
				Merchant m_s_mObject = (this.Depth > 1) ? m_s_mTable.CreateInstance() : null;
				ServiceType m_s_stObject = (this.Depth > 1) ? m_s_stTable.CreateInstance() : null;
				UserSessionType m_s_ustObject = (this.Depth > 1) ? m_s_ustTable.CreateInstance() : null;
				Country m_s_cObject = (this.Depth > 1) ? m_s_cTable.CreateInstance() : null;
				Language m_s_lObject = (this.Depth > 1) ? m_s_lTable.CreateInstance() : null;
				ServiceConfiguration m_s_scObject = (this.Depth > 1) ? m_s_scTable.CreateInstance() : null;
				Template m_s_tObject = (this.Depth > 1) ? m_s_tTable.CreateInstance() : null;
				Service m_sObject = (this.Depth > 0) ? m_sTable.CreateInstance(m_s_aObject, m_s_pObject, m_s_mObject, m_s_stObject, m_s_ustObject, m_s_cObject, m_s_lObject, m_s_scObject, m_s_tObject) : null;
				User m_c_uObject = (this.Depth > 1) ? m_c_uTable.CreateInstance() : null;
				Service m_c_sObject = (this.Depth > 1) ? m_c_sTable.CreateInstance() : null;
				Country m_c_cObject = (this.Depth > 1) ? m_c_cTable.CreateInstance() : null;
				Language m_c_lObject = (this.Depth > 1) ? m_c_lTable.CreateInstance() : null;
				MobileOperator m_c_moObject = (this.Depth > 1) ? m_c_moTable.CreateInstance() : null;
				Customer m_cObject = (this.Depth > 0) ? m_cTable.CreateInstance(m_c_uObject, m_c_sObject, m_c_cObject, m_c_lObject, m_c_moObject) : null;
				Country m_mo_cObject = (this.Depth > 1) ? m_mo_cTable.CreateInstance() : null;
				MobileOperator m_moObject = (this.Depth > 0) ? m_moTable.CreateInstance(m_mo_cObject) : null;
				Message mObject = mTable.CreateInstance(m_sObject, m_cObject, m_moObject);
				sqlReader.Close();

				return mObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "loadinternal", "exception"), "Message could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Message", "Exception while loading Message object from database. See inner exception for details.", ex);
      }
    }

    public Message Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MessageTable.GetColumnNames("[m]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[m_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[m_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[m_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[m_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[m_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[m_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[m_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[m_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + CustomerTable.GetColumnNames("[m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[m_c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[m_c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[m_c_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[m_c_mo]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[m_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_mo_c]") : string.Empty) +  
					" FROM [stats].[Message] AS [m] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [m_s] ON [m].[ServiceID] = [m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [m_s_a] ON [m_s].[ApplicationID] = [m_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [m_s_p] ON [m_s].[ProductID] = [m_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [m_s_m] ON [m_s].[MerchantID] = [m_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [m_s_st] ON [m_s].[ServiceTypeID] = [m_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [m_s_ust] ON [m_s].[UserSessionTypeID] = [m_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [m_s_c] ON [m_s].[FallbackCountryID] = [m_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [m_s_l] ON [m_s].[FallbackLanguageID] = [m_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [m_s_sc] ON [m_s].[ServiceConfigurationID] = [m_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [m_s_t] ON [m_s].[TemplateID] = [m_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [m_c] ON [m].[CustomerID] = [m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [m_c_u] ON [m_c].[UserID] = [m_c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [m_c_s] ON [m_c].[ServiceID] = [m_c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [m_c_c] ON [m_c].[CountryID] = [m_c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [m_c_l] ON [m_c].[LanguageID] = [m_c_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [m_c_mo] ON [m_c].[MobileOperatorID] = [m_c_mo].[MobileOperatorID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [m_mo] ON [m].[MobileOperatorID] = [m_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [m_mo_c] ON [m_mo].[CountryID] = [m_mo_c].[CountryID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customload", "notfound"), "Message could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MessageTable mTable = new MessageTable(query);
				ServiceTable m_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable m_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable m_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable m_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable m_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable m_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable m_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable m_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable m_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable m_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				CustomerTable m_cTable = (this.Depth > 0) ? new CustomerTable(query) : null;
				UserTable m_c_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				ServiceTable m_c_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CountryTable m_c_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable m_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				MobileOperatorTable m_c_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;
				MobileOperatorTable m_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable m_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        
				Application m_s_aObject = (this.Depth > 1) ? m_s_aTable.CreateInstance() : null;
				Product m_s_pObject = (this.Depth > 1) ? m_s_pTable.CreateInstance() : null;
				Merchant m_s_mObject = (this.Depth > 1) ? m_s_mTable.CreateInstance() : null;
				ServiceType m_s_stObject = (this.Depth > 1) ? m_s_stTable.CreateInstance() : null;
				UserSessionType m_s_ustObject = (this.Depth > 1) ? m_s_ustTable.CreateInstance() : null;
				Country m_s_cObject = (this.Depth > 1) ? m_s_cTable.CreateInstance() : null;
				Language m_s_lObject = (this.Depth > 1) ? m_s_lTable.CreateInstance() : null;
				ServiceConfiguration m_s_scObject = (this.Depth > 1) ? m_s_scTable.CreateInstance() : null;
				Template m_s_tObject = (this.Depth > 1) ? m_s_tTable.CreateInstance() : null;
				Service m_sObject = (this.Depth > 0) ? m_sTable.CreateInstance(m_s_aObject, m_s_pObject, m_s_mObject, m_s_stObject, m_s_ustObject, m_s_cObject, m_s_lObject, m_s_scObject, m_s_tObject) : null;
				User m_c_uObject = (this.Depth > 1) ? m_c_uTable.CreateInstance() : null;
				Service m_c_sObject = (this.Depth > 1) ? m_c_sTable.CreateInstance() : null;
				Country m_c_cObject = (this.Depth > 1) ? m_c_cTable.CreateInstance() : null;
				Language m_c_lObject = (this.Depth > 1) ? m_c_lTable.CreateInstance() : null;
				MobileOperator m_c_moObject = (this.Depth > 1) ? m_c_moTable.CreateInstance() : null;
				Customer m_cObject = (this.Depth > 0) ? m_cTable.CreateInstance(m_c_uObject, m_c_sObject, m_c_cObject, m_c_lObject, m_c_moObject) : null;
				Country m_mo_cObject = (this.Depth > 1) ? m_mo_cTable.CreateInstance() : null;
				MobileOperator m_moObject = (this.Depth > 0) ? m_moTable.CreateInstance(m_mo_cObject) : null;
				Message mObject = mTable.CreateInstance(m_sObject, m_cObject, m_moObject);
				sqlReader.Close();

				return mObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customload", "exception"), "Message could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Message", "Exception while loading (custom/single) Message object from database. See inner exception for details.", ex);
      }
    }

    public List<Message> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MessageTable.GetColumnNames("[m]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[m_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[m_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[m_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[m_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[m_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[m_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[m_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[m_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + CustomerTable.GetColumnNames("[m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[m_c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[m_c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[m_c_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[m_c_mo]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[m_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[m_mo_c]") : string.Empty) +  
					" FROM [stats].[Message] AS [m] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [m_s] ON [m].[ServiceID] = [m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [m_s_a] ON [m_s].[ApplicationID] = [m_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [m_s_p] ON [m_s].[ProductID] = [m_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [m_s_m] ON [m_s].[MerchantID] = [m_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [m_s_st] ON [m_s].[ServiceTypeID] = [m_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [m_s_ust] ON [m_s].[UserSessionTypeID] = [m_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [m_s_c] ON [m_s].[FallbackCountryID] = [m_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [m_s_l] ON [m_s].[FallbackLanguageID] = [m_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [m_s_sc] ON [m_s].[ServiceConfigurationID] = [m_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [m_s_t] ON [m_s].[TemplateID] = [m_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [m_c] ON [m].[CustomerID] = [m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [m_c_u] ON [m_c].[UserID] = [m_c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [m_c_s] ON [m_c].[ServiceID] = [m_c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [m_c_c] ON [m_c].[CountryID] = [m_c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [m_c_l] ON [m_c].[LanguageID] = [m_c_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [m_c_mo] ON [m_c].[MobileOperatorID] = [m_c_mo].[MobileOperatorID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [m_mo] ON [m].[MobileOperatorID] = [m_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [m_mo_c] ON [m_mo].[CountryID] = [m_mo_c].[CountryID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customloadmany", "notfound"), "Message list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Message>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MessageTable mTable = new MessageTable(query);
				ServiceTable m_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable m_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable m_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable m_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable m_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable m_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable m_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable m_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable m_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable m_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				CustomerTable m_cTable = (this.Depth > 0) ? new CustomerTable(query) : null;
				UserTable m_c_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				ServiceTable m_c_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CountryTable m_c_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable m_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				MobileOperatorTable m_c_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;
				MobileOperatorTable m_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable m_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        List<Message> result = new List<Message>();
        do
        {
          
					Application m_s_aObject = (this.Depth > 1) ? m_s_aTable.CreateInstance() : null;
					Product m_s_pObject = (this.Depth > 1) ? m_s_pTable.CreateInstance() : null;
					Merchant m_s_mObject = (this.Depth > 1) ? m_s_mTable.CreateInstance() : null;
					ServiceType m_s_stObject = (this.Depth > 1) ? m_s_stTable.CreateInstance() : null;
					UserSessionType m_s_ustObject = (this.Depth > 1) ? m_s_ustTable.CreateInstance() : null;
					Country m_s_cObject = (this.Depth > 1) ? m_s_cTable.CreateInstance() : null;
					Language m_s_lObject = (this.Depth > 1) ? m_s_lTable.CreateInstance() : null;
					ServiceConfiguration m_s_scObject = (this.Depth > 1) ? m_s_scTable.CreateInstance() : null;
					Template m_s_tObject = (this.Depth > 1) ? m_s_tTable.CreateInstance() : null;
					Service m_sObject = (this.Depth > 0) ? m_sTable.CreateInstance(m_s_aObject, m_s_pObject, m_s_mObject, m_s_stObject, m_s_ustObject, m_s_cObject, m_s_lObject, m_s_scObject, m_s_tObject) : null;
					User m_c_uObject = (this.Depth > 1) ? m_c_uTable.CreateInstance() : null;
					Service m_c_sObject = (this.Depth > 1) ? m_c_sTable.CreateInstance() : null;
					Country m_c_cObject = (this.Depth > 1) ? m_c_cTable.CreateInstance() : null;
					Language m_c_lObject = (this.Depth > 1) ? m_c_lTable.CreateInstance() : null;
					MobileOperator m_c_moObject = (this.Depth > 1) ? m_c_moTable.CreateInstance() : null;
					Customer m_cObject = (this.Depth > 0) ? m_cTable.CreateInstance(m_c_uObject, m_c_sObject, m_c_cObject, m_c_lObject, m_c_moObject) : null;
					Country m_mo_cObject = (this.Depth > 1) ? m_mo_cTable.CreateInstance() : null;
					MobileOperator m_moObject = (this.Depth > 0) ? m_moTable.CreateInstance(m_mo_cObject) : null;
					Message mObject = (this.Depth > -1) ? mTable.CreateInstance(m_sObject, m_cObject, m_moObject) : null;
					result.Add(mObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customloadmany", "exception"), "Message list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Message", "Exception while loading (custom/many) Message object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Message data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [stats].[Message] ([MessageGuid],[ExternalID],[ServiceID],[CustomerID],[MobileOperatorName],[MobileOperatorID],[MessageDirectionID],[MessageTypeID],[MessageStatusID],[Text],[Shorcode],[Keyword],[TrackingID]) VALUES(@MessageGuid,@ExternalID,@ServiceID,@CustomerID,@MobileOperatorName,@MobileOperatorID,@MessageDirectionID,@MessageTypeID,@MessageStatusID,@Text,@Shorcode,@Keyword,@TrackingID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@MessageGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ExternalID", data.ExternalID.HasValue ? (object)data.ExternalID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@CustomerID", data.Customer == null ? DBNull.Value : (object)data.Customer.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorName", !string.IsNullOrEmpty(data.MobileOperatorName) ? (object)data.MobileOperatorName : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@MessageDirectionID", (int)data.MessageDirection);
				sqlCmd.Parameters.AddWithValue("@MessageTypeID", (int)data.MessageType);
				sqlCmd.Parameters.AddWithValue("@MessageStatusID", (int)data.MessageStatus);
				sqlCmd.Parameters.AddWithValue("@Text", !string.IsNullOrEmpty(data.Text) ? (object)data.Text : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Shorcode", data.Shorcode.HasValue ? (object)data.Shorcode.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Keyword", !string.IsNullOrEmpty(data.Keyword) ? (object)data.Keyword : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@TrackingID", data.TrackingID.HasValue ? (object)data.TrackingID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "insert", "noprimarykey"), "Message could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Message", "Exception while inserting Message object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "insert", "exception"), "Message could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Message", "Exception while inserting Message object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Message data)
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
        sqlCmdText = "UPDATE [stats].[Message] SET " +
												"[MessageGuid] = @MessageGuid, " + 
												"[ExternalID] = @ExternalID, " + 
												"[ServiceID] = @ServiceID, " + 
												"[CustomerID] = @CustomerID, " + 
												"[MobileOperatorName] = @MobileOperatorName, " + 
												"[MobileOperatorID] = @MobileOperatorID, " + 
												"[MessageDirectionID] = @MessageDirectionID, " + 
												"[MessageTypeID] = @MessageTypeID, " + 
												"[MessageStatusID] = @MessageStatusID, " + 
												"[Text] = @Text, " + 
												"[Shorcode] = @Shorcode, " + 
												"[Keyword] = @Keyword, " + 
												"[TrackingID] = @TrackingID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [MessageID] = @MessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@MessageGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ExternalID", data.ExternalID.HasValue ? (object)data.ExternalID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@CustomerID", data.Customer == null ? DBNull.Value : (object)data.Customer.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorName", !string.IsNullOrEmpty(data.MobileOperatorName) ? (object)data.MobileOperatorName : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@MessageDirectionID", (int)data.MessageDirection);
				sqlCmd.Parameters.AddWithValue("@MessageTypeID", (int)data.MessageType);
				sqlCmd.Parameters.AddWithValue("@MessageStatusID", (int)data.MessageStatus);
				sqlCmd.Parameters.AddWithValue("@Text", !string.IsNullOrEmpty(data.Text) ? (object)data.Text : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Shorcode", data.Shorcode.HasValue ? (object)data.Shorcode.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Keyword", !string.IsNullOrEmpty(data.Keyword) ? (object)data.Keyword : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@TrackingID", data.TrackingID.HasValue ? (object)data.TrackingID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@MessageID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "update", "norecord"), "Message could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Message", "Exception while updating Message object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "update", "morerecords"), "Message was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Message", "Exception while updating Message object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "update", "exception"), "Message could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Message", "Exception while updating Message object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Message data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [stats].[Message] WHERE MessageID = @MessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MessageID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "delete", "norecord"), "Message could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Message", "Exception while deleting Message object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "delete", "exception"), "Message could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Message", "Exception while deleting Message object from database. See inner exception for details.", ex);
      }
    }
  }
}

