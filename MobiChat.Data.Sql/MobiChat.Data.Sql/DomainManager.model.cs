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
  [DataManager(typeof(Domain))] 
  public partial class DomainManager : MobiChat.Data.Sql.SqlManagerBase<Domain>, IDomainManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Domain LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							DomainTable.GetColumnNames("[d]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[d_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[d_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[d_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[d_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[d_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[d_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[d_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[d_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[d_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[d_s_t]") : string.Empty) + 
					" FROM [core].[Domain] AS [d] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [d_s] ON [d].[ServiceID] = [d_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [d_s_a] ON [d_s].[ApplicationID] = [d_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [d_s_p] ON [d_s].[ProductID] = [d_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [d_s_m] ON [d_s].[MerchantID] = [d_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [d_s_st] ON [d_s].[ServiceTypeID] = [d_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [d_s_ust] ON [d_s].[UserSessionTypeID] = [d_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [d_s_c] ON [d_s].[FallbackCountryID] = [d_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [d_s_l] ON [d_s].[FallbackLanguageID] = [d_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [d_s_sc] ON [d_s].[ServiceConfigurationID] = [d_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [d_s_t] ON [d_s].[TemplateID] = [d_s_t].[TemplateID] ";
				sqlCmdText += "WHERE [d].[DomainID] = @DomainID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@DomainID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "loadinternal", "notfound"), "Domain could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				DomainTable dTable = new DomainTable(query);
				ServiceTable d_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable d_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable d_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable d_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable d_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable d_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable d_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable d_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable d_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable d_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        
				Application d_s_aObject = (this.Depth > 1) ? d_s_aTable.CreateInstance() : null;
				Product d_s_pObject = (this.Depth > 1) ? d_s_pTable.CreateInstance() : null;
				Merchant d_s_mObject = (this.Depth > 1) ? d_s_mTable.CreateInstance() : null;
				ServiceType d_s_stObject = (this.Depth > 1) ? d_s_stTable.CreateInstance() : null;
				UserSessionType d_s_ustObject = (this.Depth > 1) ? d_s_ustTable.CreateInstance() : null;
				Country d_s_cObject = (this.Depth > 1) ? d_s_cTable.CreateInstance() : null;
				Language d_s_lObject = (this.Depth > 1) ? d_s_lTable.CreateInstance() : null;
				ServiceConfiguration d_s_scObject = (this.Depth > 1) ? d_s_scTable.CreateInstance() : null;
				Template d_s_tObject = (this.Depth > 1) ? d_s_tTable.CreateInstance() : null;
				Service d_sObject = (this.Depth > 0) ? d_sTable.CreateInstance(d_s_aObject, d_s_pObject, d_s_mObject, d_s_stObject, d_s_ustObject, d_s_cObject, d_s_lObject, d_s_scObject, d_s_tObject) : null;
				Domain dObject = dTable.CreateInstance(d_sObject);
				sqlReader.Close();

				return dObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "loadinternal", "exception"), "Domain could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Domain", "Exception while loading Domain object from database. See inner exception for details.", ex);
      }
    }

    public Domain Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							DomainTable.GetColumnNames("[d]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[d_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[d_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[d_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[d_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[d_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[d_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[d_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[d_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[d_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[d_s_t]") : string.Empty) +  
					" FROM [core].[Domain] AS [d] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [d_s] ON [d].[ServiceID] = [d_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [d_s_a] ON [d_s].[ApplicationID] = [d_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [d_s_p] ON [d_s].[ProductID] = [d_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [d_s_m] ON [d_s].[MerchantID] = [d_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [d_s_st] ON [d_s].[ServiceTypeID] = [d_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [d_s_ust] ON [d_s].[UserSessionTypeID] = [d_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [d_s_c] ON [d_s].[FallbackCountryID] = [d_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [d_s_l] ON [d_s].[FallbackLanguageID] = [d_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [d_s_sc] ON [d_s].[ServiceConfigurationID] = [d_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [d_s_t] ON [d_s].[TemplateID] = [d_s_t].[TemplateID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "customload", "notfound"), "Domain could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				DomainTable dTable = new DomainTable(query);
				ServiceTable d_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable d_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable d_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable d_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable d_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable d_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable d_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable d_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable d_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable d_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        
				Application d_s_aObject = (this.Depth > 1) ? d_s_aTable.CreateInstance() : null;
				Product d_s_pObject = (this.Depth > 1) ? d_s_pTable.CreateInstance() : null;
				Merchant d_s_mObject = (this.Depth > 1) ? d_s_mTable.CreateInstance() : null;
				ServiceType d_s_stObject = (this.Depth > 1) ? d_s_stTable.CreateInstance() : null;
				UserSessionType d_s_ustObject = (this.Depth > 1) ? d_s_ustTable.CreateInstance() : null;
				Country d_s_cObject = (this.Depth > 1) ? d_s_cTable.CreateInstance() : null;
				Language d_s_lObject = (this.Depth > 1) ? d_s_lTable.CreateInstance() : null;
				ServiceConfiguration d_s_scObject = (this.Depth > 1) ? d_s_scTable.CreateInstance() : null;
				Template d_s_tObject = (this.Depth > 1) ? d_s_tTable.CreateInstance() : null;
				Service d_sObject = (this.Depth > 0) ? d_sTable.CreateInstance(d_s_aObject, d_s_pObject, d_s_mObject, d_s_stObject, d_s_ustObject, d_s_cObject, d_s_lObject, d_s_scObject, d_s_tObject) : null;
				Domain dObject = dTable.CreateInstance(d_sObject);
				sqlReader.Close();

				return dObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "customload", "exception"), "Domain could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Domain", "Exception while loading (custom/single) Domain object from database. See inner exception for details.", ex);
      }
    }

    public List<Domain> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							DomainTable.GetColumnNames("[d]") + 
							(this.Depth > 0 ? "," + ServiceTable.GetColumnNames("[d_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTable.GetColumnNames("[d_s_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProductTable.GetColumnNames("[d_s_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + MerchantTable.GetColumnNames("[d_s_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTypeTable.GetColumnNames("[d_s_st]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserSessionTypeTable.GetColumnNames("[d_s_ust]") : string.Empty) + 
							(this.Depth > 1 ? "," + CountryTable.GetColumnNames("[d_s_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[d_s_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceConfigurationTable.GetColumnNames("[d_s_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + TemplateTable.GetColumnNames("[d_s_t]") : string.Empty) +  
					" FROM [core].[Domain] AS [d] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [d_s] ON [d].[ServiceID] = [d_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [d_s_a] ON [d_s].[ApplicationID] = [d_s_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Product] AS [d_s_p] ON [d_s].[ProductID] = [d_s_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Merchant] AS [d_s_m] ON [d_s].[MerchantID] = [d_s_m].[MerchantID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceType] AS [d_s_st] ON [d_s].[ServiceTypeID] = [d_s_st].[ServiceTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserSessionType] AS [d_s_ust] ON [d_s].[UserSessionTypeID] = [d_s_ust].[UserSessionTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Country] AS [d_s_c] ON [d_s].[FallbackCountryID] = [d_s_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [d_s_l] ON [d_s].[FallbackLanguageID] = [d_s_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [d_s_sc] ON [d_s].[ServiceConfigurationID] = [d_s_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Template] AS [d_s_t] ON [d_s].[TemplateID] = [d_s_t].[TemplateID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "customloadmany", "notfound"), "Domain list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Domain>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				DomainTable dTable = new DomainTable(query);
				ServiceTable d_sTable = (this.Depth > 0) ? new ServiceTable(query) : null;
				ApplicationTable d_s_aTable = (this.Depth > 1) ? new ApplicationTable(query) : null;
				ProductTable d_s_pTable = (this.Depth > 1) ? new ProductTable(query) : null;
				MerchantTable d_s_mTable = (this.Depth > 1) ? new MerchantTable(query) : null;
				ServiceTypeTable d_s_stTable = (this.Depth > 1) ? new ServiceTypeTable(query) : null;
				UserSessionTypeTable d_s_ustTable = (this.Depth > 1) ? new UserSessionTypeTable(query) : null;
				CountryTable d_s_cTable = (this.Depth > 1) ? new CountryTable(query) : null;
				LanguageTable d_s_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceConfigurationTable d_s_scTable = (this.Depth > 1) ? new ServiceConfigurationTable(query) : null;
				TemplateTable d_s_tTable = (this.Depth > 1) ? new TemplateTable(query) : null;

        List<Domain> result = new List<Domain>();
        do
        {
          
					Application d_s_aObject = (this.Depth > 1) ? d_s_aTable.CreateInstance() : null;
					Product d_s_pObject = (this.Depth > 1) ? d_s_pTable.CreateInstance() : null;
					Merchant d_s_mObject = (this.Depth > 1) ? d_s_mTable.CreateInstance() : null;
					ServiceType d_s_stObject = (this.Depth > 1) ? d_s_stTable.CreateInstance() : null;
					UserSessionType d_s_ustObject = (this.Depth > 1) ? d_s_ustTable.CreateInstance() : null;
					Country d_s_cObject = (this.Depth > 1) ? d_s_cTable.CreateInstance() : null;
					Language d_s_lObject = (this.Depth > 1) ? d_s_lTable.CreateInstance() : null;
					ServiceConfiguration d_s_scObject = (this.Depth > 1) ? d_s_scTable.CreateInstance() : null;
					Template d_s_tObject = (this.Depth > 1) ? d_s_tTable.CreateInstance() : null;
					Service d_sObject = (this.Depth > 0) ? d_sTable.CreateInstance(d_s_aObject, d_s_pObject, d_s_mObject, d_s_stObject, d_s_ustObject, d_s_cObject, d_s_lObject, d_s_scObject, d_s_tObject) : null;
					Domain dObject = (this.Depth > -1) ? dTable.CreateInstance(d_sObject) : null;
					result.Add(dObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "customloadmany", "exception"), "Domain list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Domain", "Exception while loading (custom/many) Domain object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Domain data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Domain] ([ServiceID],[DomainName]) VALUES(@ServiceID,@DomainName); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@DomainName", data.DomainName).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "insert", "noprimarykey"), "Domain could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Domain", "Exception while inserting Domain object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "insert", "exception"), "Domain could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Domain", "Exception while inserting Domain object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Domain data)
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
        sqlCmdText = "UPDATE [core].[Domain] SET " +
												"[ServiceID] = @ServiceID, " + 
												"[DomainName] = @DomainName, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [DomainID] = @DomainID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.Service.ID);
				sqlCmd.Parameters.AddWithValue("@DomainName", data.DomainName).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@DomainID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "update", "norecord"), "Domain could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Domain", "Exception while updating Domain object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "update", "morerecords"), "Domain was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Domain", "Exception while updating Domain object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "update", "exception"), "Domain could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Domain", "Exception while updating Domain object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Domain data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Domain] WHERE DomainID = @DomainID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@DomainID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "delete", "norecord"), "Domain could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Domain", "Exception while deleting Domain object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("d", "delete", "exception"), "Domain could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Domain", "Exception while deleting Domain object from database. See inner exception for details.", ex);
      }
    }
  }
}

