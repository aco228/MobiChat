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
  [DataManager(typeof(ShortMessage))] 
  public partial class ShortMessageManager : MobiChat.Data.Sql.SqlManagerBase<ShortMessage>, IShortMessageManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ShortMessage LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ShortMessageTable.GetColumnNames("[sm]") + 
							(this.Depth > 0 ? "," + ActionContextTable.GetColumnNames("[sm_ac]") : string.Empty) + 
							(this.Depth > 1 ? "," + ActionContextGroupTable.GetColumnNames("[sm_ac_acg]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[sm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[sm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[sm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[sm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[sm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[sm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[sm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[sm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[sm_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_mo_c]") : string.Empty) + 
							(this.Depth > 0 ? "," + CustomerTable.GetColumnNames("[sm_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[sm_c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[sm_c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sm_c_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[sm_c_mo]") : string.Empty) + 
					" FROM [core].[ShortMessage] AS [sm] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContext] AS [sm_ac] ON [sm].[ActionContextID] = [sm_ac].[ActionContextID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContextGroup] AS [sm_ac_acg] ON [sm_ac].[ActionContextGroupID] = [sm_ac_acg].[ActionContextGroupID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [sm_s] ON [sm].[ServiceID] = [sm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [sm_s_a] ON [sm_s].[ApplicationID] = [sm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [sm_s_p] ON [sm_s].[ProductID] = [sm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [sm_s_m] ON [sm_s].[MerchantID] = [sm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [sm_s_st] ON [sm_s].[ServiceTypeID] = [sm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [sm_s_ust] ON [sm_s].[UserSessionTypeID] = [sm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [sm_s_c] ON [sm_s].[FallbackCountryID] = [sm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [sm_s_l] ON [sm_s].[FallbackLanguageID] = [sm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [sm_s_sc] ON [sm_s].[ServiceConfigurationID] = [sm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [sm_s_t] ON [sm_s].[TemplateID] = [sm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [sm_mo] ON [sm].[MobileOperatorID] = [sm_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [sm_mo_c] ON [sm_mo].[CountryID] = [sm_mo_c].[CountryID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Customer] AS [sm_c] ON [sm].[CustomerID] = [sm_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [sm_c_u] ON [sm_c].[UserID] = [sm_c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [sm_c_s] ON [sm_c].[ServiceID] = [sm_c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [sm_c_c] ON [sm_c].[CountryID] = [sm_c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [sm_c_l] ON [sm_c].[LanguageID] = [sm_c_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[MobileOperator] AS [sm_c_mo] ON [sm_c].[MobileOperatorID] = [sm_c_mo].[MobileOperatorID] ";
				sqlCmdText += "WHERE [sm].[ShortMessageID] = @ShortMessageID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ShortMessageID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "loadinternal", "notfound"), "ShortMessage could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ShortMessageTable smTable = new ShortMessageTable(query);
				ActionContextTable sm_acTable = (this.Depth > 0) ? new ActionContextTable(query) : null;
				ActionContextGroupTable sm_ac_acgTable = (this.Depth > 1) ? new ActionContextGroupTable(query) : null;
				ServiceTable sm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable sm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable sm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable sm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable sm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable sm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable sm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable sm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable sm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				MobileOperatorTable sm_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable sm_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				CustomerTable sm_cTable = (this.Depth > 0) ? new CustomerTable(query) : null;
				UserTable sm_c_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				ServiceTable sm_c_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CountryTable sm_c_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sm_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				MobileOperatorTable sm_c_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        
				ActionContextGroup sm_ac_acgObject = (this.Depth > 1) ? sm_ac_acgTable.CreateInstance() : null;
				ActionContext sm_acObject = (this.Depth > 0) ? sm_acTable.CreateInstance(sm_ac_acgObject) : null;
				Application sm_s_aObject = (this.Depth > 1) ? sm_s_aTable.CreateInstance() : null;
				Product sm_s_pObject = (this.Depth > 1) ? sm_s_pTable.CreateInstance() : null;
				Merchant sm_s_mObject = (this.Depth > 1) ? sm_s_mTable.CreateInstance() : null;
				ServiceType sm_s_stObject = (this.Depth > 1) ? sm_s_stTable.CreateInstance() : null;
				UserSessionType sm_s_ustObject = (this.Depth > 1) ? sm_s_ustTable.CreateInstance() : null;
				Country sm_s_cObject = (this.Depth > 1) ? sm_s_cTable.CreateInstance() : null;
				Language sm_s_lObject = (this.Depth > 1) ? sm_s_lTable.CreateInstance() : null;
				ServiceConfiguration sm_s_scObject = (this.Depth > 1) ? sm_s_scTable.CreateInstance() : null;
				Template sm_s_tObject = (this.Depth > 1) ? sm_s_tTable.CreateInstance() : null;
				Service sm_sObject = (this.Depth > 0) ? sm_sTable.CreateInstance(sm_s_aObject, sm_s_pObject, sm_s_mObject, sm_s_stObject, sm_s_ustObject, sm_s_cObject, sm_s_lObject, sm_s_scObject, sm_s_tObject) : null;
				Country sm_mo_cObject = (this.Depth > 1) ? sm_mo_cTable.CreateInstance() : null;
				MobileOperator sm_moObject = (this.Depth > 0) ? sm_moTable.CreateInstance(sm_mo_cObject) : null;
				User sm_c_uObject = (this.Depth > 1) ? sm_c_uTable.CreateInstance() : null;
				Service sm_c_sObject = (this.Depth > 1) ? sm_c_sTable.CreateInstance() : null;
				Country sm_c_cObject = (this.Depth > 1) ? sm_c_cTable.CreateInstance() : null;
				Language sm_c_lObject = (this.Depth > 1) ? sm_c_lTable.CreateInstance() : null;
				MobileOperator sm_c_moObject = (this.Depth > 1) ? sm_c_moTable.CreateInstance() : null;
				Customer sm_cObject = (this.Depth > 0) ? sm_cTable.CreateInstance(sm_c_uObject, sm_c_sObject, sm_c_cObject, sm_c_lObject, sm_c_moObject) : null;
				ShortMessage smObject = smTable.CreateInstance(sm_acObject, sm_sObject, sm_moObject, sm_cObject);
				sqlReader.Close();

				return smObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "loadinternal", "exception"), "ShortMessage could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ShortMessage", "Exception while loading ShortMessage object from database. See inner exception for details.", ex);
      }
    }

    public ShortMessage Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ShortMessageTable.GetColumnNames("[sm]") + 
							(this.Depth > 0 ? "," + ActionContextTable.GetColumnNames("[sm_ac]") : string.Empty) + 
							(this.Depth > 1 ? "," + ActionContextGroupTable.GetColumnNames("[sm_ac_acg]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[sm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[sm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[sm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[sm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[sm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[sm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[sm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[sm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[sm_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_mo_c]") : string.Empty) + 
							(this.Depth > 0 ? "," + CustomerTable.GetColumnNames("[sm_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[sm_c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[sm_c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sm_c_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[sm_c_mo]") : string.Empty) +  
					" FROM [core].[ShortMessage] AS [sm] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContext] AS [sm_ac] ON [sm].[ActionContextID] = [sm_ac].[ActionContextID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContextGroup] AS [sm_ac_acg] ON [sm_ac].[ActionContextGroupID] = [sm_ac_acg].[ActionContextGroupID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [sm_s] ON [sm].[ServiceID] = [sm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [sm_s_a] ON [sm_s].[ApplicationID] = [sm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [sm_s_p] ON [sm_s].[ProductID] = [sm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [sm_s_m] ON [sm_s].[MerchantID] = [sm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [sm_s_st] ON [sm_s].[ServiceTypeID] = [sm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [sm_s_ust] ON [sm_s].[UserSessionTypeID] = [sm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [sm_s_c] ON [sm_s].[FallbackCountryID] = [sm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [sm_s_l] ON [sm_s].[FallbackLanguageID] = [sm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [sm_s_sc] ON [sm_s].[ServiceConfigurationID] = [sm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [sm_s_t] ON [sm_s].[TemplateID] = [sm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [sm_mo] ON [sm].[MobileOperatorID] = [sm_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [sm_mo_c] ON [sm_mo].[CountryID] = [sm_mo_c].[CountryID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Customer] AS [sm_c] ON [sm].[CustomerID] = [sm_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [sm_c_u] ON [sm_c].[UserID] = [sm_c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [sm_c_s] ON [sm_c].[ServiceID] = [sm_c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [sm_c_c] ON [sm_c].[CountryID] = [sm_c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [sm_c_l] ON [sm_c].[LanguageID] = [sm_c_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[MobileOperator] AS [sm_c_mo] ON [sm_c].[MobileOperatorID] = [sm_c_mo].[MobileOperatorID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "customload", "notfound"), "ShortMessage could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ShortMessageTable smTable = new ShortMessageTable(query);
				ActionContextTable sm_acTable = (this.Depth > 0) ? new ActionContextTable(query) : null;
				ActionContextGroupTable sm_ac_acgTable = (this.Depth > 1) ? new ActionContextGroupTable(query) : null;
				ServiceTable sm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable sm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable sm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable sm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable sm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable sm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable sm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable sm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable sm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				MobileOperatorTable sm_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable sm_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				CustomerTable sm_cTable = (this.Depth > 0) ? new CustomerTable(query) : null;
				UserTable sm_c_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				ServiceTable sm_c_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CountryTable sm_c_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sm_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				MobileOperatorTable sm_c_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        
				ActionContextGroup sm_ac_acgObject = (this.Depth > 1) ? sm_ac_acgTable.CreateInstance() : null;
				ActionContext sm_acObject = (this.Depth > 0) ? sm_acTable.CreateInstance(sm_ac_acgObject) : null;
				Application sm_s_aObject = (this.Depth > 1) ? sm_s_aTable.CreateInstance() : null;
				Product sm_s_pObject = (this.Depth > 1) ? sm_s_pTable.CreateInstance() : null;
				Merchant sm_s_mObject = (this.Depth > 1) ? sm_s_mTable.CreateInstance() : null;
				ServiceType sm_s_stObject = (this.Depth > 1) ? sm_s_stTable.CreateInstance() : null;
				UserSessionType sm_s_ustObject = (this.Depth > 1) ? sm_s_ustTable.CreateInstance() : null;
				Country sm_s_cObject = (this.Depth > 1) ? sm_s_cTable.CreateInstance() : null;
				Language sm_s_lObject = (this.Depth > 1) ? sm_s_lTable.CreateInstance() : null;
				ServiceConfiguration sm_s_scObject = (this.Depth > 1) ? sm_s_scTable.CreateInstance() : null;
				Template sm_s_tObject = (this.Depth > 1) ? sm_s_tTable.CreateInstance() : null;
				Service sm_sObject = (this.Depth > 0) ? sm_sTable.CreateInstance(sm_s_aObject, sm_s_pObject, sm_s_mObject, sm_s_stObject, sm_s_ustObject, sm_s_cObject, sm_s_lObject, sm_s_scObject, sm_s_tObject) : null;
				Country sm_mo_cObject = (this.Depth > 1) ? sm_mo_cTable.CreateInstance() : null;
				MobileOperator sm_moObject = (this.Depth > 0) ? sm_moTable.CreateInstance(sm_mo_cObject) : null;
				User sm_c_uObject = (this.Depth > 1) ? sm_c_uTable.CreateInstance() : null;
				Service sm_c_sObject = (this.Depth > 1) ? sm_c_sTable.CreateInstance() : null;
				Country sm_c_cObject = (this.Depth > 1) ? sm_c_cTable.CreateInstance() : null;
				Language sm_c_lObject = (this.Depth > 1) ? sm_c_lTable.CreateInstance() : null;
				MobileOperator sm_c_moObject = (this.Depth > 1) ? sm_c_moTable.CreateInstance() : null;
				Customer sm_cObject = (this.Depth > 0) ? sm_cTable.CreateInstance(sm_c_uObject, sm_c_sObject, sm_c_cObject, sm_c_lObject, sm_c_moObject) : null;
				ShortMessage smObject = smTable.CreateInstance(sm_acObject, sm_sObject, sm_moObject, sm_cObject);
				sqlReader.Close();

				return smObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "customload", "exception"), "ShortMessage could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ShortMessage", "Exception while loading (custom/single) ShortMessage object from database. See inner exception for details.", ex);
      }
    }

    public List<ShortMessage> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ShortMessageTable.GetColumnNames("[sm]") + 
							(this.Depth > 0 ? "," + ActionContextTable.GetColumnNames("[sm_ac]") : string.Empty) + 
							(this.Depth > 1 ? "," + ActionContextGroupTable.GetColumnNames("[sm_ac_acg]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[sm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[sm_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[sm_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[sm_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[sm_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[sm_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sm_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[sm_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[sm_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[sm_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_mo_c]") : string.Empty) + 
							(this.Depth > 0 ? "," + CustomerTable.GetColumnNames("[sm_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[sm_c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[sm_c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sm_c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sm_c_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[sm_c_mo]") : string.Empty) +  
					" FROM [core].[ShortMessage] AS [sm] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContext] AS [sm_ac] ON [sm].[ActionContextID] = [sm_ac].[ActionContextID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContextGroup] AS [sm_ac_acg] ON [sm_ac].[ActionContextGroupID] = [sm_ac_acg].[ActionContextGroupID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [sm_s] ON [sm].[ServiceID] = [sm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [sm_s_a] ON [sm_s].[ApplicationID] = [sm_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [sm_s_p] ON [sm_s].[ProductID] = [sm_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [sm_s_m] ON [sm_s].[MerchantID] = [sm_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [sm_s_st] ON [sm_s].[ServiceTypeID] = [sm_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [sm_s_ust] ON [sm_s].[UserSessionTypeID] = [sm_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [sm_s_c] ON [sm_s].[FallbackCountryID] = [sm_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [sm_s_l] ON [sm_s].[FallbackLanguageID] = [sm_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [sm_s_sc] ON [sm_s].[ServiceConfigurationID] = [sm_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [sm_s_t] ON [sm_s].[TemplateID] = [sm_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [sm_mo] ON [sm].[MobileOperatorID] = [sm_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [sm_mo_c] ON [sm_mo].[CountryID] = [sm_mo_c].[CountryID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Customer] AS [sm_c] ON [sm].[CustomerID] = [sm_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [sm_c_u] ON [sm_c].[UserID] = [sm_c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [sm_c_s] ON [sm_c].[ServiceID] = [sm_c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [sm_c_c] ON [sm_c].[CountryID] = [sm_c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [sm_c_l] ON [sm_c].[LanguageID] = [sm_c_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[MobileOperator] AS [sm_c_mo] ON [sm_c].[MobileOperatorID] = [sm_c_mo].[MobileOperatorID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "customloadmany", "notfound"), "ShortMessage list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ShortMessage>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ShortMessageTable smTable = new ShortMessageTable(query);
				ActionContextTable sm_acTable = (this.Depth > 0) ? new ActionContextTable(query) : null;
				ActionContextGroupTable sm_ac_acgTable = (this.Depth > 1) ? new ActionContextGroupTable(query) : null;
				ServiceTable sm_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable sm_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable sm_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable sm_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable sm_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable sm_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable sm_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sm_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable sm_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable sm_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				MobileOperatorTable sm_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable sm_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				CustomerTable sm_cTable = (this.Depth > 0) ? new CustomerTable(query) : null;
				UserTable sm_c_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				ServiceTable sm_c_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CountryTable sm_c_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sm_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				MobileOperatorTable sm_c_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        List<ShortMessage> result = new List<ShortMessage>();
        do
        {
          
					ActionContextGroup sm_ac_acgObject = (this.Depth > 1) ? sm_ac_acgTable.CreateInstance() : null;
					ActionContext sm_acObject = (this.Depth > 0) ? sm_acTable.CreateInstance(sm_ac_acgObject) : null;
					Application sm_s_aObject = (this.Depth > 1) ? sm_s_aTable.CreateInstance() : null;
					Product sm_s_pObject = (this.Depth > 1) ? sm_s_pTable.CreateInstance() : null;
					Merchant sm_s_mObject = (this.Depth > 1) ? sm_s_mTable.CreateInstance() : null;
					ServiceType sm_s_stObject = (this.Depth > 1) ? sm_s_stTable.CreateInstance() : null;
					UserSessionType sm_s_ustObject = (this.Depth > 1) ? sm_s_ustTable.CreateInstance() : null;
					Country sm_s_cObject = (this.Depth > 1) ? sm_s_cTable.CreateInstance() : null;
					Language sm_s_lObject = (this.Depth > 1) ? sm_s_lTable.CreateInstance() : null;
					ServiceConfiguration sm_s_scObject = (this.Depth > 1) ? sm_s_scTable.CreateInstance() : null;
					Template sm_s_tObject = (this.Depth > 1) ? sm_s_tTable.CreateInstance() : null;
					Service sm_sObject = (this.Depth > 0) ? sm_sTable.CreateInstance(sm_s_aObject, sm_s_pObject, sm_s_mObject, sm_s_stObject, sm_s_ustObject, sm_s_cObject, sm_s_lObject, sm_s_scObject, sm_s_tObject) : null;
					Country sm_mo_cObject = (this.Depth > 1) ? sm_mo_cTable.CreateInstance() : null;
					MobileOperator sm_moObject = (this.Depth > 0) ? sm_moTable.CreateInstance(sm_mo_cObject) : null;
					User sm_c_uObject = (this.Depth > 1) ? sm_c_uTable.CreateInstance() : null;
					Service sm_c_sObject = (this.Depth > 1) ? sm_c_sTable.CreateInstance() : null;
					Country sm_c_cObject = (this.Depth > 1) ? sm_c_cTable.CreateInstance() : null;
					Language sm_c_lObject = (this.Depth > 1) ? sm_c_lTable.CreateInstance() : null;
					MobileOperator sm_c_moObject = (this.Depth > 1) ? sm_c_moTable.CreateInstance() : null;
					Customer sm_cObject = (this.Depth > 0) ? sm_cTable.CreateInstance(sm_c_uObject, sm_c_sObject, sm_c_cObject, sm_c_lObject, sm_c_moObject) : null;
					ShortMessage smObject = (this.Depth > -1) ? smTable.CreateInstance(sm_acObject, sm_sObject, sm_moObject, sm_cObject) : null;
					result.Add(smObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "customloadmany", "exception"), "ShortMessage list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ShortMessage", "Exception while loading (custom/many) ShortMessage object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ShortMessage data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ShortMessage] ([ShortMessageGuid],[ActionContextID],[ServiceID],[MobileOperatorID],[CustomerID],[ShortMessageDirectionID],[ShortMessageStatusID],[Text],[Shortcode],[Keyword]) VALUES(@ShortMessageGuid,@ActionContextID,@ServiceID,@MobileOperatorID,@CustomerID,@ShortMessageDirectionID,@ShortMessageStatusID,@Text,@Shortcode,@Keyword); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ShortMessageGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ActionContextID", data.ActionContext == null ? DBNull.Value : (object)data.ActionContext.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@CustomerID", data.Customer.ID);
				sqlCmd.Parameters.AddWithValue("@ShortMessageDirectionID", (int)data.ShortMessageDirection);
				sqlCmd.Parameters.AddWithValue("@ShortMessageStatusID", (int)data.ShortMessageStatus);
				sqlCmd.Parameters.AddWithValue("@Text", data.Text).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Shortcode", data.Shortcode).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Keyword", data.Keyword).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "insert", "noprimarykey"), "ShortMessage could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ShortMessage", "Exception while inserting ShortMessage object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "insert", "exception"), "ShortMessage could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ShortMessage", "Exception while inserting ShortMessage object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ShortMessage data)
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
        sqlCmdText = "UPDATE [core].[ShortMessage] SET " +
												"[ShortMessageGuid] = @ShortMessageGuid, " + 
												"[ActionContextID] = @ActionContextID, " + 
												"[ServiceID] = @ServiceID, " + 
												"[MobileOperatorID] = @MobileOperatorID, " + 
												"[CustomerID] = @CustomerID, " + 
												"[ShortMessageDirectionID] = @ShortMessageDirectionID, " + 
												"[ShortMessageStatusID] = @ShortMessageStatusID, " + 
												"[Text] = @Text, " + 
												"[Shortcode] = @Shortcode, " + 
												"[Keyword] = @Keyword, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ShortMessageID] = @ShortMessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ShortMessageGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ActionContextID", data.ActionContext == null ? DBNull.Value : (object)data.ActionContext.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@CustomerID", data.Customer.ID);
				sqlCmd.Parameters.AddWithValue("@ShortMessageDirectionID", (int)data.ShortMessageDirection);
				sqlCmd.Parameters.AddWithValue("@ShortMessageStatusID", (int)data.ShortMessageStatus);
				sqlCmd.Parameters.AddWithValue("@Text", data.Text).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Shortcode", data.Shortcode).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Keyword", data.Keyword).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ShortMessageID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "update", "norecord"), "ShortMessage could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ShortMessage", "Exception while updating ShortMessage object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "update", "morerecords"), "ShortMessage was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ShortMessage", "Exception while updating ShortMessage object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "update", "exception"), "ShortMessage could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ShortMessage", "Exception while updating ShortMessage object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ShortMessage data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ShortMessage] WHERE ShortMessageID = @ShortMessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ShortMessageID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "delete", "norecord"), "ShortMessage could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ShortMessage", "Exception while deleting ShortMessage object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sm", "delete", "exception"), "ShortMessage could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ShortMessage", "Exception while deleting ShortMessage object from database. See inner exception for details.", ex);
      }
    }
  }
}

