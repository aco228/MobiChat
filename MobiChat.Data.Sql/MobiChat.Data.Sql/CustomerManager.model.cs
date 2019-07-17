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
  [DataManager(typeof(Customer))] 
  public partial class CustomerManager : MobiChat.Data.Sql.SqlManagerBase<Customer>, ICustomerManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Customer LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							CustomerTable.GetColumnNames("[c]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[c_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[c_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[c_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[c_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[c_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[c_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[c_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[c_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[c_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[c_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[c_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[c_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[c_mo_c]") : string.Empty) + 
					" FROM [core].[Customer] AS [c] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [c_u] ON [c].[UserID] = [c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserType] AS [c_u_ut] ON [c_u].[UserTypeID] = [c_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [c_s] ON [c].[ServiceID] = [c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [c_s_a] ON [c_s].[ApplicationID] = [c_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [c_s_p] ON [c_s].[ProductID] = [c_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [c_s_m] ON [c_s].[MerchantID] = [c_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [c_s_st] ON [c_s].[ServiceTypeID] = [c_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [c_s_ust] ON [c_s].[UserSessionTypeID] = [c_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [c_s_c] ON [c_s].[FallbackCountryID] = [c_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [c_s_l] ON [c_s].[FallbackLanguageID] = [c_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [c_s_sc] ON [c_s].[ServiceConfigurationID] = [c_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [c_s_t] ON [c_s].[TemplateID] = [c_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [c_c] ON [c].[CountryID] = [c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [c_c_l] ON [c_c].[LanguageID] = [c_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [c_l] ON [c].[LanguageID] = [c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [c_mo] ON [c].[MobileOperatorID] = [c_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [c_mo_c] ON [c_mo].[CountryID] = [c_mo_c].[CountryID] ";
				sqlCmdText += "WHERE [c].[CustomerID] = @CustomerID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@CustomerID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "loadinternal", "notfound"), "Customer could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				CustomerTable cTable = new CustomerTable(query);
				UserTable c_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable c_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				ServiceTable c_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable c_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable c_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable c_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable c_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable c_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable c_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable c_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable c_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable c_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				CountryTable c_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable c_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable c_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				MobileOperatorTable c_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable c_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        
				UserType c_u_utObject = (this.Depth > 1) ? c_u_utTable.CreateInstance() : null;
				User c_uObject = (this.Depth > 0) ? c_uTable.CreateInstance(c_u_utObject) : null;
				Application c_s_aObject = (this.Depth > 1) ? c_s_aTable.CreateInstance() : null;
				Product c_s_pObject = (this.Depth > 1) ? c_s_pTable.CreateInstance() : null;
				Merchant c_s_mObject = (this.Depth > 1) ? c_s_mTable.CreateInstance() : null;
				ServiceType c_s_stObject = (this.Depth > 1) ? c_s_stTable.CreateInstance() : null;
				UserSessionType c_s_ustObject = (this.Depth > 1) ? c_s_ustTable.CreateInstance() : null;
				Country c_s_cObject = (this.Depth > 1) ? c_s_cTable.CreateInstance() : null;
				Language c_s_lObject = (this.Depth > 1) ? c_s_lTable.CreateInstance() : null;
				ServiceConfiguration c_s_scObject = (this.Depth > 1) ? c_s_scTable.CreateInstance() : null;
				Template c_s_tObject = (this.Depth > 1) ? c_s_tTable.CreateInstance() : null;
				Service c_sObject = (this.Depth > 0) ? c_sTable.CreateInstance(c_s_aObject, c_s_pObject, c_s_mObject, c_s_stObject, c_s_ustObject, c_s_cObject, c_s_lObject, c_s_scObject, c_s_tObject) : null;
				Language c_c_lObject = (this.Depth > 1) ? c_c_lTable.CreateInstance() : null;
				Country c_cObject = (this.Depth > 0) ? c_cTable.CreateInstance(c_c_lObject) : null;
				Language c_lObject = (this.Depth > 0) ? c_lTable.CreateInstance() : null;
				Country c_mo_cObject = (this.Depth > 1) ? c_mo_cTable.CreateInstance() : null;
				MobileOperator c_moObject = (this.Depth > 0) ? c_moTable.CreateInstance(c_mo_cObject) : null;
				Customer cObject = cTable.CreateInstance(c_uObject, c_sObject, c_cObject, c_lObject, c_moObject);
				sqlReader.Close();

				return cObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "loadinternal", "exception"), "Customer could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Customer", "Exception while loading Customer object from database. See inner exception for details.", ex);
      }
    }

    public Customer Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							CustomerTable.GetColumnNames("[c]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[c_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[c_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[c_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[c_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[c_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[c_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[c_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[c_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[c_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[c_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[c_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[c_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[c_mo_c]") : string.Empty) +  
					" FROM [core].[Customer] AS [c] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [c_u] ON [c].[UserID] = [c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserType] AS [c_u_ut] ON [c_u].[UserTypeID] = [c_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [c_s] ON [c].[ServiceID] = [c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [c_s_a] ON [c_s].[ApplicationID] = [c_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [c_s_p] ON [c_s].[ProductID] = [c_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [c_s_m] ON [c_s].[MerchantID] = [c_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [c_s_st] ON [c_s].[ServiceTypeID] = [c_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [c_s_ust] ON [c_s].[UserSessionTypeID] = [c_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [c_s_c] ON [c_s].[FallbackCountryID] = [c_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [c_s_l] ON [c_s].[FallbackLanguageID] = [c_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [c_s_sc] ON [c_s].[ServiceConfigurationID] = [c_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [c_s_t] ON [c_s].[TemplateID] = [c_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [c_c] ON [c].[CountryID] = [c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [c_c_l] ON [c_c].[LanguageID] = [c_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [c_l] ON [c].[LanguageID] = [c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [c_mo] ON [c].[MobileOperatorID] = [c_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [c_mo_c] ON [c_mo].[CountryID] = [c_mo_c].[CountryID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "customload", "notfound"), "Customer could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				CustomerTable cTable = new CustomerTable(query);
				UserTable c_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable c_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				ServiceTable c_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable c_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable c_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable c_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable c_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable c_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable c_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable c_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable c_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable c_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				CountryTable c_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable c_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable c_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				MobileOperatorTable c_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable c_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        
				UserType c_u_utObject = (this.Depth > 1) ? c_u_utTable.CreateInstance() : null;
				User c_uObject = (this.Depth > 0) ? c_uTable.CreateInstance(c_u_utObject) : null;
				Application c_s_aObject = (this.Depth > 1) ? c_s_aTable.CreateInstance() : null;
				Product c_s_pObject = (this.Depth > 1) ? c_s_pTable.CreateInstance() : null;
				Merchant c_s_mObject = (this.Depth > 1) ? c_s_mTable.CreateInstance() : null;
				ServiceType c_s_stObject = (this.Depth > 1) ? c_s_stTable.CreateInstance() : null;
				UserSessionType c_s_ustObject = (this.Depth > 1) ? c_s_ustTable.CreateInstance() : null;
				Country c_s_cObject = (this.Depth > 1) ? c_s_cTable.CreateInstance() : null;
				Language c_s_lObject = (this.Depth > 1) ? c_s_lTable.CreateInstance() : null;
				ServiceConfiguration c_s_scObject = (this.Depth > 1) ? c_s_scTable.CreateInstance() : null;
				Template c_s_tObject = (this.Depth > 1) ? c_s_tTable.CreateInstance() : null;
				Service c_sObject = (this.Depth > 0) ? c_sTable.CreateInstance(c_s_aObject, c_s_pObject, c_s_mObject, c_s_stObject, c_s_ustObject, c_s_cObject, c_s_lObject, c_s_scObject, c_s_tObject) : null;
				Language c_c_lObject = (this.Depth > 1) ? c_c_lTable.CreateInstance() : null;
				Country c_cObject = (this.Depth > 0) ? c_cTable.CreateInstance(c_c_lObject) : null;
				Language c_lObject = (this.Depth > 0) ? c_lTable.CreateInstance() : null;
				Country c_mo_cObject = (this.Depth > 1) ? c_mo_cTable.CreateInstance() : null;
				MobileOperator c_moObject = (this.Depth > 0) ? c_moTable.CreateInstance(c_mo_cObject) : null;
				Customer cObject = cTable.CreateInstance(c_uObject, c_sObject, c_cObject, c_lObject, c_moObject);
				sqlReader.Close();

				return cObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "customload", "exception"), "Customer could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Customer", "Exception while loading (custom/single) Customer object from database. See inner exception for details.", ex);
      }
    }

    public List<Customer> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							CustomerTable.GetColumnNames("[c]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[c_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[c_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[c_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[c_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[c_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[c_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[c_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[c_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[c_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[c_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[c_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[c_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[c_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[c_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[c_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[c_mo_c]") : string.Empty) +  
					" FROM [core].[Customer] AS [c] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [c_u] ON [c].[UserID] = [c_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserType] AS [c_u_ut] ON [c_u].[UserTypeID] = [c_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [c_s] ON [c].[ServiceID] = [c_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [c_s_a] ON [c_s].[ApplicationID] = [c_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [c_s_p] ON [c_s].[ProductID] = [c_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [c_s_m] ON [c_s].[MerchantID] = [c_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [c_s_st] ON [c_s].[ServiceTypeID] = [c_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [c_s_ust] ON [c_s].[UserSessionTypeID] = [c_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [c_s_c] ON [c_s].[FallbackCountryID] = [c_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [c_s_l] ON [c_s].[FallbackLanguageID] = [c_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [c_s_sc] ON [c_s].[ServiceConfigurationID] = [c_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [c_s_t] ON [c_s].[TemplateID] = [c_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [c_c] ON [c].[CountryID] = [c_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [c_c_l] ON [c_c].[LanguageID] = [c_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [c_l] ON [c].[LanguageID] = [c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [c_mo] ON [c].[MobileOperatorID] = [c_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [c_mo_c] ON [c_mo].[CountryID] = [c_mo_c].[CountryID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "customloadmany", "notfound"), "Customer list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Customer>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				CustomerTable cTable = new CustomerTable(query);
				UserTable c_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable c_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				ServiceTable c_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable c_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable c_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable c_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable c_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable c_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable c_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable c_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable c_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable c_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				CountryTable c_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable c_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable c_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				MobileOperatorTable c_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable c_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        List<Customer> result = new List<Customer>();
        do
        {
          
					UserType c_u_utObject = (this.Depth > 1) ? c_u_utTable.CreateInstance() : null;
					User c_uObject = (this.Depth > 0) ? c_uTable.CreateInstance(c_u_utObject) : null;
					Application c_s_aObject = (this.Depth > 1) ? c_s_aTable.CreateInstance() : null;
					Product c_s_pObject = (this.Depth > 1) ? c_s_pTable.CreateInstance() : null;
					Merchant c_s_mObject = (this.Depth > 1) ? c_s_mTable.CreateInstance() : null;
					ServiceType c_s_stObject = (this.Depth > 1) ? c_s_stTable.CreateInstance() : null;
					UserSessionType c_s_ustObject = (this.Depth > 1) ? c_s_ustTable.CreateInstance() : null;
					Country c_s_cObject = (this.Depth > 1) ? c_s_cTable.CreateInstance() : null;
					Language c_s_lObject = (this.Depth > 1) ? c_s_lTable.CreateInstance() : null;
					ServiceConfiguration c_s_scObject = (this.Depth > 1) ? c_s_scTable.CreateInstance() : null;
					Template c_s_tObject = (this.Depth > 1) ? c_s_tTable.CreateInstance() : null;
					Service c_sObject = (this.Depth > 0) ? c_sTable.CreateInstance(c_s_aObject, c_s_pObject, c_s_mObject, c_s_stObject, c_s_ustObject, c_s_cObject, c_s_lObject, c_s_scObject, c_s_tObject) : null;
					Language c_c_lObject = (this.Depth > 1) ? c_c_lTable.CreateInstance() : null;
					Country c_cObject = (this.Depth > 0) ? c_cTable.CreateInstance(c_c_lObject) : null;
					Language c_lObject = (this.Depth > 0) ? c_lTable.CreateInstance() : null;
					Country c_mo_cObject = (this.Depth > 1) ? c_mo_cTable.CreateInstance() : null;
					MobileOperator c_moObject = (this.Depth > 0) ? c_moTable.CreateInstance(c_mo_cObject) : null;
					Customer cObject = (this.Depth > -1) ? cTable.CreateInstance(c_uObject, c_sObject, c_cObject, c_lObject, c_moObject) : null;
					result.Add(cObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "customloadmany", "exception"), "Customer list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Customer", "Exception while loading (custom/many) Customer object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Customer data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Customer] ([CustomerGuid],[UserID],[ServiceID],[CountryID],[LanguageID],[MobileOperatorID],[Msisdn],[EncryptedMsisdn]) VALUES(@CustomerGuid,@UserID,@ServiceID,@CountryID,@LanguageID,@MobileOperatorID,@Msisdn,@EncryptedMsisdn); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@CustomerGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@UserID", data.User == null ? DBNull.Value : (object)data.User.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.Country.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language == null ? DBNull.Value : (object)data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@Msisdn", !string.IsNullOrEmpty(data.Msisdn) ? (object)data.Msisdn : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@EncryptedMsisdn", !string.IsNullOrEmpty(data.EncryptedMsisdn) ? (object)data.EncryptedMsisdn : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "insert", "noprimarykey"), "Customer could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Customer", "Exception while inserting Customer object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "insert", "exception"), "Customer could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Customer", "Exception while inserting Customer object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Customer data)
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
        sqlCmdText = "UPDATE [core].[Customer] SET " +
												"[CustomerGuid] = @CustomerGuid, " + 
												"[UserID] = @UserID, " + 
												"[ServiceID] = @ServiceID, " + 
												"[CountryID] = @CountryID, " + 
												"[LanguageID] = @LanguageID, " + 
												"[MobileOperatorID] = @MobileOperatorID, " + 
												"[Msisdn] = @Msisdn, " + 
												"[EncryptedMsisdn] = @EncryptedMsisdn, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [CustomerID] = @CustomerID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@CustomerGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@UserID", data.User == null ? DBNull.Value : (object)data.User.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.Country.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language == null ? DBNull.Value : (object)data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@Msisdn", !string.IsNullOrEmpty(data.Msisdn) ? (object)data.Msisdn : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@EncryptedMsisdn", !string.IsNullOrEmpty(data.EncryptedMsisdn) ? (object)data.EncryptedMsisdn : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@CustomerID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "update", "norecord"), "Customer could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Customer", "Exception while updating Customer object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "update", "morerecords"), "Customer was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Customer", "Exception while updating Customer object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "update", "exception"), "Customer could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Customer", "Exception while updating Customer object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Customer data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Customer] WHERE CustomerID = @CustomerID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@CustomerID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "delete", "norecord"), "Customer could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Customer", "Exception while deleting Customer object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("c", "delete", "exception"), "Customer could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Customer", "Exception while deleting Customer object from database. See inner exception for details.", ex);
      }
    }
  }
}

