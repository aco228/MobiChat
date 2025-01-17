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
  [DataManager(typeof(UserSession))] 
  public partial class UserSessionManager : MobiChat.Data.Sql.SqlManagerBase<UserSession>, IUserSessionManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override UserSession LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							UserSessionTable.GetColumnNames("[us]") + 
							(this.Depth > 0 ? "," + UserSessionTypeTable.GetColumnNames("[us_ust]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[us_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[us_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[us_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[us_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[us_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[us_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[us_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[us_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[us_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[us_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[us_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[us_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[us_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[us_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + DomainTable.GetColumnNames("[us_d]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[us_d_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[us_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[us_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[us_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[us_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[us_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[us_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[us_mo_c]") : string.Empty) + 
					" FROM [core].[UserSession] AS [us] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [us_ust] ON [us].[UserSessionTypeID] = [us_ust].[UserSessionTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [us_s] ON [us].[ServiceID] = [us_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [us_s_a] ON [us_s].[ApplicationID] = [us_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [us_s_p] ON [us_s].[ProductID] = [us_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [us_s_m] ON [us_s].[MerchantID] = [us_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [us_s_st] ON [us_s].[ServiceTypeID] = [us_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [us_s_ust] ON [us_s].[UserSessionTypeID] = [us_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [us_s_c] ON [us_s].[FallbackCountryID] = [us_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [us_s_l] ON [us_s].[FallbackLanguageID] = [us_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [us_s_sc] ON [us_s].[ServiceConfigurationID] = [us_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [us_s_t] ON [us_s].[TemplateID] = [us_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [us_a] ON [us].[ApplicationID] = [us_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Instance] AS [us_a_i] ON [us_a].[InstanceID] = [us_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ApplicationType] AS [us_a_at] ON [us_a].[ApplicationTypeID] = [us_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[RuntimeType] AS [us_a_rt] ON [us_a].[RuntimeTypeID] = [us_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Domain] AS [us_d] ON [us].[DomainID] = [us_d].[DomainID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [us_d_s] ON [us_d].[ServiceID] = [us_d_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [us_u] ON [us].[UserID] = [us_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserType] AS [us_u_ut] ON [us_u].[UserTypeID] = [us_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [us_c] ON [us].[CountryID] = [us_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [us_c_l] ON [us_c].[LanguageID] = [us_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [us_l] ON [us].[LanguageID] = [us_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [us_mo] ON [us].[MobileOperatorID] = [us_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [us_mo_c] ON [us_mo].[CountryID] = [us_mo_c].[CountryID] ";
				sqlCmdText += "WHERE [us].[UserSessionID] = @UserSessionID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserSessionID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "loadinternal", "notfound"), "UserSession could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserSessionTable usTable = new UserSessionTable(query);
				UserSessionTypeTable us_ustTable = (this.Depth > 0) ? new UserSessionTypeTable(query) : null;
				ServiceTable us_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable us_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable us_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable us_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable us_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable us_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable us_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable us_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable us_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable us_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				ApplicationTable us_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable us_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable us_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable us_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				DomainTable us_dTable = (this.Depth > 0) ? new DomainTable(query) : null;
				ServiceTable us_d_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				UserTable us_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable us_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				CountryTable us_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable us_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable us_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				MobileOperatorTable us_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable us_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        
				UserSessionType us_ustObject = (this.Depth > 0) ? us_ustTable.CreateInstance() : null;
				Application us_s_aObject = (this.Depth > 1) ? us_s_aTable.CreateInstance() : null;
				Product us_s_pObject = (this.Depth > 1) ? us_s_pTable.CreateInstance() : null;
				Merchant us_s_mObject = (this.Depth > 1) ? us_s_mTable.CreateInstance() : null;
				ServiceType us_s_stObject = (this.Depth > 1) ? us_s_stTable.CreateInstance() : null;
				UserSessionType us_s_ustObject = (this.Depth > 1) ? us_s_ustTable.CreateInstance() : null;
				Country us_s_cObject = (this.Depth > 1) ? us_s_cTable.CreateInstance() : null;
				Language us_s_lObject = (this.Depth > 1) ? us_s_lTable.CreateInstance() : null;
				ServiceConfiguration us_s_scObject = (this.Depth > 1) ? us_s_scTable.CreateInstance() : null;
				Template us_s_tObject = (this.Depth > 1) ? us_s_tTable.CreateInstance() : null;
				Service us_sObject = (this.Depth > 0) ? us_sTable.CreateInstance(us_s_aObject, us_s_pObject, us_s_mObject, us_s_stObject, us_s_ustObject, us_s_cObject, us_s_lObject, us_s_scObject, us_s_tObject) : null;
				Instance us_a_iObject = (this.Depth > 1) ? us_a_iTable.CreateInstance() : null;
				ApplicationType us_a_atObject = (this.Depth > 1) ? us_a_atTable.CreateInstance() : null;
				RuntimeType us_a_rtObject = (this.Depth > 1) ? us_a_rtTable.CreateInstance() : null;
				Application us_aObject = (this.Depth > 0) ? us_aTable.CreateInstance(us_a_iObject, us_a_atObject, us_a_rtObject) : null;
				Service us_d_sObject = (this.Depth > 1) ? us_d_sTable.CreateInstance() : null;
				Domain us_dObject = (this.Depth > 0) ? us_dTable.CreateInstance(us_d_sObject) : null;
				UserType us_u_utObject = (this.Depth > 1) ? us_u_utTable.CreateInstance() : null;
				User us_uObject = (this.Depth > 0) ? us_uTable.CreateInstance(us_u_utObject) : null;
				Language us_c_lObject = (this.Depth > 1) ? us_c_lTable.CreateInstance() : null;
				Country us_cObject = (this.Depth > 0) ? us_cTable.CreateInstance(us_c_lObject) : null;
				Language us_lObject = (this.Depth > 0) ? us_lTable.CreateInstance() : null;
				Country us_mo_cObject = (this.Depth > 1) ? us_mo_cTable.CreateInstance() : null;
				MobileOperator us_moObject = (this.Depth > 0) ? us_moTable.CreateInstance(us_mo_cObject) : null;
				UserSession usObject = usTable.CreateInstance(us_ustObject, us_sObject, us_aObject, us_dObject, us_uObject, us_cObject, us_lObject, us_moObject);
				sqlReader.Close();

				return usObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "loadinternal", "exception"), "UserSession could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserSession", "Exception while loading UserSession object from database. See inner exception for details.", ex);
      }
    }

    public UserSession Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserSessionTable.GetColumnNames("[us]") + 
							(this.Depth > 0 ? "," + UserSessionTypeTable.GetColumnNames("[us_ust]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[us_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[us_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[us_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[us_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[us_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[us_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[us_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[us_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[us_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[us_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[us_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[us_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[us_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[us_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + DomainTable.GetColumnNames("[us_d]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[us_d_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[us_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[us_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[us_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[us_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[us_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[us_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[us_mo_c]") : string.Empty) +  
					" FROM [core].[UserSession] AS [us] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [us_ust] ON [us].[UserSessionTypeID] = [us_ust].[UserSessionTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [us_s] ON [us].[ServiceID] = [us_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [us_s_a] ON [us_s].[ApplicationID] = [us_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [us_s_p] ON [us_s].[ProductID] = [us_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [us_s_m] ON [us_s].[MerchantID] = [us_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [us_s_st] ON [us_s].[ServiceTypeID] = [us_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [us_s_ust] ON [us_s].[UserSessionTypeID] = [us_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [us_s_c] ON [us_s].[FallbackCountryID] = [us_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [us_s_l] ON [us_s].[FallbackLanguageID] = [us_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [us_s_sc] ON [us_s].[ServiceConfigurationID] = [us_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [us_s_t] ON [us_s].[TemplateID] = [us_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [us_a] ON [us].[ApplicationID] = [us_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Instance] AS [us_a_i] ON [us_a].[InstanceID] = [us_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ApplicationType] AS [us_a_at] ON [us_a].[ApplicationTypeID] = [us_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[RuntimeType] AS [us_a_rt] ON [us_a].[RuntimeTypeID] = [us_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Domain] AS [us_d] ON [us].[DomainID] = [us_d].[DomainID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [us_d_s] ON [us_d].[ServiceID] = [us_d_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [us_u] ON [us].[UserID] = [us_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserType] AS [us_u_ut] ON [us_u].[UserTypeID] = [us_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [us_c] ON [us].[CountryID] = [us_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [us_c_l] ON [us_c].[LanguageID] = [us_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [us_l] ON [us].[LanguageID] = [us_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [us_mo] ON [us].[MobileOperatorID] = [us_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [us_mo_c] ON [us_mo].[CountryID] = [us_mo_c].[CountryID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "customload", "notfound"), "UserSession could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserSessionTable usTable = new UserSessionTable(query);
				UserSessionTypeTable us_ustTable = (this.Depth > 0) ? new UserSessionTypeTable(query) : null;
				ServiceTable us_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable us_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable us_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable us_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable us_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable us_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable us_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable us_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable us_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable us_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				ApplicationTable us_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable us_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable us_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable us_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				DomainTable us_dTable = (this.Depth > 0) ? new DomainTable(query) : null;
				ServiceTable us_d_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				UserTable us_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable us_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				CountryTable us_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable us_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable us_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				MobileOperatorTable us_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable us_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        
				UserSessionType us_ustObject = (this.Depth > 0) ? us_ustTable.CreateInstance() : null;
				Application us_s_aObject = (this.Depth > 1) ? us_s_aTable.CreateInstance() : null;
				Product us_s_pObject = (this.Depth > 1) ? us_s_pTable.CreateInstance() : null;
				Merchant us_s_mObject = (this.Depth > 1) ? us_s_mTable.CreateInstance() : null;
				ServiceType us_s_stObject = (this.Depth > 1) ? us_s_stTable.CreateInstance() : null;
				UserSessionType us_s_ustObject = (this.Depth > 1) ? us_s_ustTable.CreateInstance() : null;
				Country us_s_cObject = (this.Depth > 1) ? us_s_cTable.CreateInstance() : null;
				Language us_s_lObject = (this.Depth > 1) ? us_s_lTable.CreateInstance() : null;
				ServiceConfiguration us_s_scObject = (this.Depth > 1) ? us_s_scTable.CreateInstance() : null;
				Template us_s_tObject = (this.Depth > 1) ? us_s_tTable.CreateInstance() : null;
				Service us_sObject = (this.Depth > 0) ? us_sTable.CreateInstance(us_s_aObject, us_s_pObject, us_s_mObject, us_s_stObject, us_s_ustObject, us_s_cObject, us_s_lObject, us_s_scObject, us_s_tObject) : null;
				Instance us_a_iObject = (this.Depth > 1) ? us_a_iTable.CreateInstance() : null;
				ApplicationType us_a_atObject = (this.Depth > 1) ? us_a_atTable.CreateInstance() : null;
				RuntimeType us_a_rtObject = (this.Depth > 1) ? us_a_rtTable.CreateInstance() : null;
				Application us_aObject = (this.Depth > 0) ? us_aTable.CreateInstance(us_a_iObject, us_a_atObject, us_a_rtObject) : null;
				Service us_d_sObject = (this.Depth > 1) ? us_d_sTable.CreateInstance() : null;
				Domain us_dObject = (this.Depth > 0) ? us_dTable.CreateInstance(us_d_sObject) : null;
				UserType us_u_utObject = (this.Depth > 1) ? us_u_utTable.CreateInstance() : null;
				User us_uObject = (this.Depth > 0) ? us_uTable.CreateInstance(us_u_utObject) : null;
				Language us_c_lObject = (this.Depth > 1) ? us_c_lTable.CreateInstance() : null;
				Country us_cObject = (this.Depth > 0) ? us_cTable.CreateInstance(us_c_lObject) : null;
				Language us_lObject = (this.Depth > 0) ? us_lTable.CreateInstance() : null;
				Country us_mo_cObject = (this.Depth > 1) ? us_mo_cTable.CreateInstance() : null;
				MobileOperator us_moObject = (this.Depth > 0) ? us_moTable.CreateInstance(us_mo_cObject) : null;
				UserSession usObject = usTable.CreateInstance(us_ustObject, us_sObject, us_aObject, us_dObject, us_uObject, us_cObject, us_lObject, us_moObject);
				sqlReader.Close();

				return usObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "customload", "exception"), "UserSession could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserSession", "Exception while loading (custom/single) UserSession object from database. See inner exception for details.", ex);
      }
    }

    public List<UserSession> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserSessionTable.GetColumnNames("[us]") + 
							(this.Depth > 0 ? "," + UserSessionTypeTable.GetColumnNames("[us_ust]") : string.Empty) + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[us_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[us_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[us_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[us_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[us_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[us_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[us_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[us_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[us_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[us_s_t]") : string.Empty) + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[us_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[us_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[us_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[us_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + DomainTable.GetColumnNames("[us_d]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[us_d_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[us_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[us_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[us_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[us_c_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[us_l]") : string.Empty) + 
							(this.Depth > 0 ? "," + MobileOperatorTable.GetColumnNames("[us_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[us_mo_c]") : string.Empty) +  
					" FROM [core].[UserSession] AS [us] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [us_ust] ON [us].[UserSessionTypeID] = [us_ust].[UserSessionTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [us_s] ON [us].[ServiceID] = [us_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [us_s_a] ON [us_s].[ApplicationID] = [us_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [us_s_p] ON [us_s].[ProductID] = [us_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Merchant] AS [us_s_m] ON [us_s].[MerchantID] = [us_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceType] AS [us_s_st] ON [us_s].[ServiceTypeID] = [us_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserSessionType] AS [us_s_ust] ON [us_s].[UserSessionTypeID] = [us_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [us_s_c] ON [us_s].[FallbackCountryID] = [us_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [us_s_l] ON [us_s].[FallbackLanguageID] = [us_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ServiceConfiguration] AS [us_s_sc] ON [us_s].[ServiceConfigurationID] = [us_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [us_s_t] ON [us_s].[TemplateID] = [us_s_t].[TemplateID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Application] AS [us_a] ON [us].[ApplicationID] = [us_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Instance] AS [us_a_i] ON [us_a].[InstanceID] = [us_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ApplicationType] AS [us_a_at] ON [us_a].[ApplicationTypeID] = [us_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[RuntimeType] AS [us_a_rt] ON [us_a].[RuntimeTypeID] = [us_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Domain] AS [us_d] ON [us].[DomainID] = [us_d].[DomainID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [us_d_s] ON [us_d].[ServiceID] = [us_d_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[User] AS [us_u] ON [us].[UserID] = [us_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[UserType] AS [us_u_ut] ON [us_u].[UserTypeID] = [us_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [us_c] ON [us].[CountryID] = [us_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [us_c_l] ON [us_c].[LanguageID] = [us_c_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [us_l] ON [us].[LanguageID] = [us_l].[LanguageID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [us_mo] ON [us].[MobileOperatorID] = [us_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [us_mo_c] ON [us_mo].[CountryID] = [us_mo_c].[CountryID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "customloadmany", "notfound"), "UserSession list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<UserSession>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserSessionTable usTable = new UserSessionTable(query);
				UserSessionTypeTable us_ustTable = (this.Depth > 0) ? new UserSessionTypeTable(query) : null;
				ServiceTable us_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable us_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable us_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable us_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable us_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable us_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable us_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable us_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable us_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable us_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;
				ApplicationTable us_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable us_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable us_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable us_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				DomainTable us_dTable = (this.Depth > 0) ? new DomainTable(query) : null;
				ServiceTable us_d_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				UserTable us_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable us_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				CountryTable us_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable us_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				LanguageTable us_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;
				MobileOperatorTable us_moTable = (this.Depth > 0) ? new MobileOperatorTable(query) : null;
				CountryTable us_mo_cTable = (this.Depth > 1) ? new CountryTable(query) : null;

        List<UserSession> result = new List<UserSession>();
        do
        {
          
					UserSessionType us_ustObject = (this.Depth > 0) ? us_ustTable.CreateInstance() : null;
					Application us_s_aObject = (this.Depth > 1) ? us_s_aTable.CreateInstance() : null;
					Product us_s_pObject = (this.Depth > 1) ? us_s_pTable.CreateInstance() : null;
					Merchant us_s_mObject = (this.Depth > 1) ? us_s_mTable.CreateInstance() : null;
					ServiceType us_s_stObject = (this.Depth > 1) ? us_s_stTable.CreateInstance() : null;
					UserSessionType us_s_ustObject = (this.Depth > 1) ? us_s_ustTable.CreateInstance() : null;
					Country us_s_cObject = (this.Depth > 1) ? us_s_cTable.CreateInstance() : null;
					Language us_s_lObject = (this.Depth > 1) ? us_s_lTable.CreateInstance() : null;
					ServiceConfiguration us_s_scObject = (this.Depth > 1) ? us_s_scTable.CreateInstance() : null;
					Template us_s_tObject = (this.Depth > 1) ? us_s_tTable.CreateInstance() : null;
					Service us_sObject = (this.Depth > 0) ? us_sTable.CreateInstance(us_s_aObject, us_s_pObject, us_s_mObject, us_s_stObject, us_s_ustObject, us_s_cObject, us_s_lObject, us_s_scObject, us_s_tObject) : null;
					Instance us_a_iObject = (this.Depth > 1) ? us_a_iTable.CreateInstance() : null;
					ApplicationType us_a_atObject = (this.Depth > 1) ? us_a_atTable.CreateInstance() : null;
					RuntimeType us_a_rtObject = (this.Depth > 1) ? us_a_rtTable.CreateInstance() : null;
					Application us_aObject = (this.Depth > 0) ? us_aTable.CreateInstance(us_a_iObject, us_a_atObject, us_a_rtObject) : null;
					Service us_d_sObject = (this.Depth > 1) ? us_d_sTable.CreateInstance() : null;
					Domain us_dObject = (this.Depth > 0) ? us_dTable.CreateInstance(us_d_sObject) : null;
					UserType us_u_utObject = (this.Depth > 1) ? us_u_utTable.CreateInstance() : null;
					User us_uObject = (this.Depth > 0) ? us_uTable.CreateInstance(us_u_utObject) : null;
					Language us_c_lObject = (this.Depth > 1) ? us_c_lTable.CreateInstance() : null;
					Country us_cObject = (this.Depth > 0) ? us_cTable.CreateInstance(us_c_lObject) : null;
					Language us_lObject = (this.Depth > 0) ? us_lTable.CreateInstance() : null;
					Country us_mo_cObject = (this.Depth > 1) ? us_mo_cTable.CreateInstance() : null;
					MobileOperator us_moObject = (this.Depth > 0) ? us_moTable.CreateInstance(us_mo_cObject) : null;
					UserSession usObject = (this.Depth > -1) ? usTable.CreateInstance(us_ustObject, us_sObject, us_aObject, us_dObject, us_uObject, us_cObject, us_lObject, us_moObject) : null;
					result.Add(usObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "customloadmany", "exception"), "UserSession list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserSession", "Exception while loading (custom/many) UserSession object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, UserSession data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[UserSession] ([UserSessionGuid],[UserSessionTypeID],[ServiceID],[ApplicationID],[DomainID],[UserID],[CountryID],[LanguageID],[MobileOperatorID],[TrackingID],[IPAddress],[UserAgent],[EntranceUrl],[Refferer],[HasVerifiedAge],[ValidUntil]) VALUES(@UserSessionGuid,@UserSessionTypeID,@ServiceID,@ApplicationID,@DomainID,@UserID,@CountryID,@LanguageID,@MobileOperatorID,@TrackingID,@IPAddress,@UserAgent,@EntranceUrl,@Refferer,@HasVerifiedAge,@ValidUntil); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserSessionGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", data.UserSessionType.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application == null ? DBNull.Value : (object)data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@DomainID", data.Domain == null ? DBNull.Value : (object)data.Domain.ID);
				sqlCmd.Parameters.AddWithValue("@UserID", data.User == null ? DBNull.Value : (object)data.User.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.Country.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@TrackingID", data.TrackingID.HasValue ? (object)data.TrackingID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@IPAddress", data.IPAddress).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@UserAgent", !string.IsNullOrEmpty(data.UserAgent) ? (object)data.UserAgent : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@EntranceUrl", data.EntranceUrl).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Refferer", !string.IsNullOrEmpty(data.Refferer) ? (object)data.Refferer : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@HasVerifiedAge", data.HasVerifiedAge).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@ValidUntil", data.ValidUntil).SqlDbType = SqlDbType.DateTime2;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "insert", "noprimarykey"), "UserSession could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "UserSession", "Exception while inserting UserSession object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "insert", "exception"), "UserSession could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "UserSession", "Exception while inserting UserSession object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, UserSession data)
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
        sqlCmdText = "UPDATE [core].[UserSession] SET " +
												"[UserSessionGuid] = @UserSessionGuid, " + 
												"[UserSessionTypeID] = @UserSessionTypeID, " + 
												"[ServiceID] = @ServiceID, " + 
												"[ApplicationID] = @ApplicationID, " + 
												"[DomainID] = @DomainID, " + 
												"[UserID] = @UserID, " + 
												"[CountryID] = @CountryID, " + 
												"[LanguageID] = @LanguageID, " + 
												"[MobileOperatorID] = @MobileOperatorID, " + 
												"[TrackingID] = @TrackingID, " + 
												"[IPAddress] = @IPAddress, " + 
												"[UserAgent] = @UserAgent, " + 
												"[EntranceUrl] = @EntranceUrl, " + 
												"[Refferer] = @Refferer, " + 
												"[HasVerifiedAge] = @HasVerifiedAge, " + 
												"[ValidUntil] = @ValidUntil, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [UserSessionID] = @UserSessionID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserSessionGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", data.UserSessionType.ID);
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service == null ? DBNull.Value : (object)data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application == null ? DBNull.Value : (object)data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@DomainID", data.Domain == null ? DBNull.Value : (object)data.Domain.ID);
				sqlCmd.Parameters.AddWithValue("@UserID", data.User == null ? DBNull.Value : (object)data.User.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.Country.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperator == null ? DBNull.Value : (object)data.MobileOperator.ID);
				sqlCmd.Parameters.AddWithValue("@TrackingID", data.TrackingID.HasValue ? (object)data.TrackingID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@IPAddress", data.IPAddress).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@UserAgent", !string.IsNullOrEmpty(data.UserAgent) ? (object)data.UserAgent : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@EntranceUrl", data.EntranceUrl).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Refferer", !string.IsNullOrEmpty(data.Refferer) ? (object)data.Refferer : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@HasVerifiedAge", data.HasVerifiedAge).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@ValidUntil", data.ValidUntil).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@UserSessionID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "update", "norecord"), "UserSession could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserSession", "Exception while updating UserSession object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "update", "morerecords"), "UserSession was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserSession", "Exception while updating UserSession object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "update", "exception"), "UserSession could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "UserSession", "Exception while updating UserSession object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, UserSession data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[UserSession] WHERE UserSessionID = @UserSessionID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserSessionID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "delete", "norecord"), "UserSession could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "UserSession", "Exception while deleting UserSession object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("us", "delete", "exception"), "UserSession could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "UserSession", "Exception while deleting UserSession object from database. See inner exception for details.", ex);
      }
    }
  }
}

