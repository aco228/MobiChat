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
  [DataManager(typeof(ServiceLogo))] 
  public partial class ServiceLogoManager : MobiChat.Data.Sql.SqlManagerBase<ServiceLogo>, IServiceLogoManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ServiceLogo LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ServiceLogoTable.GetColumnNames("[sl]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[sl_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[sl_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[sl_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[sl_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[sl_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[sl_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sl_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sl_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[sl_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[sl_s_t]") : string.Empty) + 
					" FROM [core].[ServiceLogo] AS [sl] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [sl_s] ON [sl].[ServiceID] = [sl_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [sl_s_a] ON [sl_s].[ApplicationID] = [sl_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [sl_s_p] ON [sl_s].[ProductID] = [sl_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [sl_s_m] ON [sl_s].[MerchantID] = [sl_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [sl_s_st] ON [sl_s].[ServiceTypeID] = [sl_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [sl_s_ust] ON [sl_s].[UserSessionTypeID] = [sl_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [sl_s_c] ON [sl_s].[FallbackCountryID] = [sl_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [sl_s_l] ON [sl_s].[FallbackLanguageID] = [sl_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [sl_s_sc] ON [sl_s].[ServiceConfigurationID] = [sl_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [sl_s_t] ON [sl_s].[TemplateID] = [sl_s_t].[TemplateID] ";
				sqlCmdText += "WHERE [sl].[ServiceLogoID] = @ServiceLogoID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceLogoID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "loadinternal", "notfound"), "ServiceLogo could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceLogoTable slTable = new ServiceLogoTable(query);
				ServiceTable sl_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable sl_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable sl_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable sl_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable sl_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable sl_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable sl_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sl_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable sl_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable sl_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        
				Application sl_s_aObject = (this.Depth > 1) ? sl_s_aTable.CreateInstance() : null;
				Product sl_s_pObject = (this.Depth > 1) ? sl_s_pTable.CreateInstance() : null;
				Merchant sl_s_mObject = (this.Depth > 1) ? sl_s_mTable.CreateInstance() : null;
				ServiceType sl_s_stObject = (this.Depth > 1) ? sl_s_stTable.CreateInstance() : null;
				UserSessionType sl_s_ustObject = (this.Depth > 1) ? sl_s_ustTable.CreateInstance() : null;
				Country sl_s_cObject = (this.Depth > 1) ? sl_s_cTable.CreateInstance() : null;
				Language sl_s_lObject = (this.Depth > 1) ? sl_s_lTable.CreateInstance() : null;
				ServiceConfiguration sl_s_scObject = (this.Depth > 1) ? sl_s_scTable.CreateInstance() : null;
				Template sl_s_tObject = (this.Depth > 1) ? sl_s_tTable.CreateInstance() : null;
				Service sl_sObject = (this.Depth > 0) ? sl_sTable.CreateInstance(sl_s_aObject, sl_s_pObject, sl_s_mObject, sl_s_stObject, sl_s_ustObject, sl_s_cObject, sl_s_lObject, sl_s_scObject, sl_s_tObject) : null;
				ServiceLogo slObject = slTable.CreateInstance(sl_sObject);
				sqlReader.Close();

				return slObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "loadinternal", "exception"), "ServiceLogo could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceLogo", "Exception while loading ServiceLogo object from database. See inner exception for details.", ex);
      }
    }

    public ServiceLogo Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceLogoTable.GetColumnNames("[sl]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[sl_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[sl_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[sl_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[sl_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[sl_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[sl_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sl_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sl_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[sl_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[sl_s_t]") : string.Empty) +  
					" FROM [core].[ServiceLogo] AS [sl] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [sl_s] ON [sl].[ServiceID] = [sl_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [sl_s_a] ON [sl_s].[ApplicationID] = [sl_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [sl_s_p] ON [sl_s].[ProductID] = [sl_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [sl_s_m] ON [sl_s].[MerchantID] = [sl_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [sl_s_st] ON [sl_s].[ServiceTypeID] = [sl_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [sl_s_ust] ON [sl_s].[UserSessionTypeID] = [sl_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [sl_s_c] ON [sl_s].[FallbackCountryID] = [sl_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [sl_s_l] ON [sl_s].[FallbackLanguageID] = [sl_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [sl_s_sc] ON [sl_s].[ServiceConfigurationID] = [sl_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [sl_s_t] ON [sl_s].[TemplateID] = [sl_s_t].[TemplateID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "customload", "notfound"), "ServiceLogo could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceLogoTable slTable = new ServiceLogoTable(query);
				ServiceTable sl_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable sl_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable sl_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable sl_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable sl_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable sl_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable sl_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sl_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable sl_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable sl_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        
				Application sl_s_aObject = (this.Depth > 1) ? sl_s_aTable.CreateInstance() : null;
				Product sl_s_pObject = (this.Depth > 1) ? sl_s_pTable.CreateInstance() : null;
				Merchant sl_s_mObject = (this.Depth > 1) ? sl_s_mTable.CreateInstance() : null;
				ServiceType sl_s_stObject = (this.Depth > 1) ? sl_s_stTable.CreateInstance() : null;
				UserSessionType sl_s_ustObject = (this.Depth > 1) ? sl_s_ustTable.CreateInstance() : null;
				Country sl_s_cObject = (this.Depth > 1) ? sl_s_cTable.CreateInstance() : null;
				Language sl_s_lObject = (this.Depth > 1) ? sl_s_lTable.CreateInstance() : null;
				ServiceConfiguration sl_s_scObject = (this.Depth > 1) ? sl_s_scTable.CreateInstance() : null;
				Template sl_s_tObject = (this.Depth > 1) ? sl_s_tTable.CreateInstance() : null;
				Service sl_sObject = (this.Depth > 0) ? sl_sTable.CreateInstance(sl_s_aObject, sl_s_pObject, sl_s_mObject, sl_s_stObject, sl_s_ustObject, sl_s_cObject, sl_s_lObject, sl_s_scObject, sl_s_tObject) : null;
				ServiceLogo slObject = slTable.CreateInstance(sl_sObject);
				sqlReader.Close();

				return slObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "customload", "exception"), "ServiceLogo could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceLogo", "Exception while loading (custom/single) ServiceLogo object from database. See inner exception for details.", ex);
      }
    }

    public List<ServiceLogo> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceLogoTable.GetColumnNames("[sl]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[sl_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[sl_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[sl_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[sl_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[sl_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[sl_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[sl_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[sl_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[sl_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[sl_s_t]") : string.Empty) +  
					" FROM [core].[ServiceLogo] AS [sl] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [sl_s] ON [sl].[ServiceID] = [sl_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [sl_s_a] ON [sl_s].[ApplicationID] = [sl_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [sl_s_p] ON [sl_s].[ProductID] = [sl_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [sl_s_m] ON [sl_s].[MerchantID] = [sl_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [sl_s_st] ON [sl_s].[ServiceTypeID] = [sl_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [sl_s_ust] ON [sl_s].[UserSessionTypeID] = [sl_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [sl_s_c] ON [sl_s].[FallbackCountryID] = [sl_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [sl_s_l] ON [sl_s].[FallbackLanguageID] = [sl_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [sl_s_sc] ON [sl_s].[ServiceConfigurationID] = [sl_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [sl_s_t] ON [sl_s].[TemplateID] = [sl_s_t].[TemplateID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "customloadmany", "notfound"), "ServiceLogo list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ServiceLogo>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceLogoTable slTable = new ServiceLogoTable(query);
				ServiceTable sl_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable sl_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable sl_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable sl_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable sl_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable sl_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable sl_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable sl_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable sl_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable sl_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        List<ServiceLogo> result = new List<ServiceLogo>();
        do
        {
          
					Application sl_s_aObject = (this.Depth > 1) ? sl_s_aTable.CreateInstance() : null;
					Product sl_s_pObject = (this.Depth > 1) ? sl_s_pTable.CreateInstance() : null;
					Merchant sl_s_mObject = (this.Depth > 1) ? sl_s_mTable.CreateInstance() : null;
					ServiceType sl_s_stObject = (this.Depth > 1) ? sl_s_stTable.CreateInstance() : null;
					UserSessionType sl_s_ustObject = (this.Depth > 1) ? sl_s_ustTable.CreateInstance() : null;
					Country sl_s_cObject = (this.Depth > 1) ? sl_s_cTable.CreateInstance() : null;
					Language sl_s_lObject = (this.Depth > 1) ? sl_s_lTable.CreateInstance() : null;
					ServiceConfiguration sl_s_scObject = (this.Depth > 1) ? sl_s_scTable.CreateInstance() : null;
					Template sl_s_tObject = (this.Depth > 1) ? sl_s_tTable.CreateInstance() : null;
					Service sl_sObject = (this.Depth > 0) ? sl_sTable.CreateInstance(sl_s_aObject, sl_s_pObject, sl_s_mObject, sl_s_stObject, sl_s_ustObject, sl_s_cObject, sl_s_lObject, sl_s_scObject, sl_s_tObject) : null;
					ServiceLogo slObject = (this.Depth > -1) ? slTable.CreateInstance(sl_sObject) : null;
					result.Add(slObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "customloadmany", "exception"), "ServiceLogo list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceLogo", "Exception while loading (custom/many) ServiceLogo object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ServiceLogo data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ServiceLogo] ([ServiceID],[Data]) VALUES(@ServiceID,@Data); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@Data", data.Data).SqlDbType = SqlDbType.VarBinary;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "insert", "noprimarykey"), "ServiceLogo could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ServiceLogo", "Exception while inserting ServiceLogo object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "insert", "exception"), "ServiceLogo could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ServiceLogo", "Exception while inserting ServiceLogo object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ServiceLogo data)
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
        sqlCmdText = "UPDATE [core].[ServiceLogo] SET " +
												"[ServiceID] = @ServiceID, " + 
												"[Data] = @Data, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ServiceLogoID] = @ServiceLogoID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@Data", data.Data).SqlDbType = SqlDbType.VarBinary;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ServiceLogoID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "update", "norecord"), "ServiceLogo could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceLogo", "Exception while updating ServiceLogo object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "update", "morerecords"), "ServiceLogo was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceLogo", "Exception while updating ServiceLogo object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "update", "exception"), "ServiceLogo could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ServiceLogo", "Exception while updating ServiceLogo object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ServiceLogo data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ServiceLogo] WHERE ServiceLogoID = @ServiceLogoID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceLogoID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "delete", "norecord"), "ServiceLogo could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ServiceLogo", "Exception while deleting ServiceLogo object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sl", "delete", "exception"), "ServiceLogo could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ServiceLogo", "Exception while deleting ServiceLogo object from database. See inner exception for details.", ex);
      }
    }
  }
}

