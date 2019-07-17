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
  [DataManager(typeof(ServiceConfigurationEntry))] 
  public partial class ServiceConfigurationEntryManager : MobiChat.Data.Sql.SqlManagerBase<ServiceConfigurationEntry>, IServiceConfigurationEntryManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ServiceConfigurationEntry LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ServiceConfigurationEntryTable.GetColumnNames("[sce]") + 
							(this.Depth > 0 ? "," + ServiceConfigurationTable.GetColumnNames("[sce_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentConfigurationTable.GetColumnNames("[sce_sc_pc]") : string.Empty) + 
					" FROM [core].[ServiceConfigurationEntry] AS [sce] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [sce_sc] ON [sce].[ServiceConfigurationID] = [sce_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [sce_sc_pc] ON [sce_sc].[PaymentConfigurationID] = [sce_sc_pc].[PaymentConfigurationID] ";
				sqlCmdText += "WHERE [sce].[ServiceConfigurationEntryID] = @ServiceConfigurationEntryID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceConfigurationEntryID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "loadinternal", "notfound"), "ServiceConfigurationEntry could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceConfigurationEntryTable sceTable = new ServiceConfigurationEntryTable(query);
				ServiceConfigurationTable sce_scTable = (this.Depth > 0) ? new ServiceConfigurationTable(query) : null;
				PaymentConfigurationTable sce_sc_pcTable = (this.Depth > 1) ? new PaymentConfigurationTable(query) : null;

        
				PaymentConfiguration sce_sc_pcObject = (this.Depth > 1) ? sce_sc_pcTable.CreateInstance() : null;
				ServiceConfiguration sce_scObject = (this.Depth > 0) ? sce_scTable.CreateInstance(sce_sc_pcObject) : null;
				ServiceConfigurationEntry sceObject = sceTable.CreateInstance(sce_scObject);
				sqlReader.Close();

				return sceObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "loadinternal", "exception"), "ServiceConfigurationEntry could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceConfigurationEntry", "Exception while loading ServiceConfigurationEntry object from database. See inner exception for details.", ex);
      }
    }

    public ServiceConfigurationEntry Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceConfigurationEntryTable.GetColumnNames("[sce]") + 
							(this.Depth > 0 ? "," + ServiceConfigurationTable.GetColumnNames("[sce_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentConfigurationTable.GetColumnNames("[sce_sc_pc]") : string.Empty) +  
					" FROM [core].[ServiceConfigurationEntry] AS [sce] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [sce_sc] ON [sce].[ServiceConfigurationID] = [sce_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [sce_sc_pc] ON [sce_sc].[PaymentConfigurationID] = [sce_sc_pc].[PaymentConfigurationID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "customload", "notfound"), "ServiceConfigurationEntry could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceConfigurationEntryTable sceTable = new ServiceConfigurationEntryTable(query);
				ServiceConfigurationTable sce_scTable = (this.Depth > 0) ? new ServiceConfigurationTable(query) : null;
				PaymentConfigurationTable sce_sc_pcTable = (this.Depth > 1) ? new PaymentConfigurationTable(query) : null;

        
				PaymentConfiguration sce_sc_pcObject = (this.Depth > 1) ? sce_sc_pcTable.CreateInstance() : null;
				ServiceConfiguration sce_scObject = (this.Depth > 0) ? sce_scTable.CreateInstance(sce_sc_pcObject) : null;
				ServiceConfigurationEntry sceObject = sceTable.CreateInstance(sce_scObject);
				sqlReader.Close();

				return sceObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "customload", "exception"), "ServiceConfigurationEntry could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceConfigurationEntry", "Exception while loading (custom/single) ServiceConfigurationEntry object from database. See inner exception for details.", ex);
      }
    }

    public List<ServiceConfigurationEntry> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceConfigurationEntryTable.GetColumnNames("[sce]") + 
							(this.Depth > 0 ? "," + ServiceConfigurationTable.GetColumnNames("[sce_sc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentConfigurationTable.GetColumnNames("[sce_sc_pc]") : string.Empty) +  
					" FROM [core].[ServiceConfigurationEntry] AS [sce] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ServiceConfiguration] AS [sce_sc] ON [sce].[ServiceConfigurationID] = [sce_sc].[ServiceConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [sce_sc_pc] ON [sce_sc].[PaymentConfigurationID] = [sce_sc_pc].[PaymentConfigurationID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "customloadmany", "notfound"), "ServiceConfigurationEntry list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ServiceConfigurationEntry>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceConfigurationEntryTable sceTable = new ServiceConfigurationEntryTable(query);
				ServiceConfigurationTable sce_scTable = (this.Depth > 0) ? new ServiceConfigurationTable(query) : null;
				PaymentConfigurationTable sce_sc_pcTable = (this.Depth > 1) ? new PaymentConfigurationTable(query) : null;

        List<ServiceConfigurationEntry> result = new List<ServiceConfigurationEntry>();
        do
        {
          
					PaymentConfiguration sce_sc_pcObject = (this.Depth > 1) ? sce_sc_pcTable.CreateInstance() : null;
					ServiceConfiguration sce_scObject = (this.Depth > 0) ? sce_scTable.CreateInstance(sce_sc_pcObject) : null;
					ServiceConfigurationEntry sceObject = (this.Depth > -1) ? sceTable.CreateInstance(sce_scObject) : null;
					result.Add(sceObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "customloadmany", "exception"), "ServiceConfigurationEntry list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceConfigurationEntry", "Exception while loading (custom/many) ServiceConfigurationEntry object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ServiceConfigurationEntry data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ServiceConfigurationEntry] ([ServiceConfigurationID],[CountryID],[MobileOperatorID],[Shortcode],[Keyword],[IsAgeVerificationRequired],[IsActive]) VALUES(@ServiceConfigurationID,@CountryID,@MobileOperatorID,@Shortcode,@Keyword,@IsAgeVerificationRequired,@IsActive); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", data.ServiceConfiguration.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.CountryID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperatorID.HasValue ? (object)data.MobileOperatorID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Shortcode", data.Shortcode).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Keyword", data.Keyword).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsAgeVerificationRequired", data.IsAgeVerificationRequired).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "insert", "noprimarykey"), "ServiceConfigurationEntry could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ServiceConfigurationEntry", "Exception while inserting ServiceConfigurationEntry object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "insert", "exception"), "ServiceConfigurationEntry could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ServiceConfigurationEntry", "Exception while inserting ServiceConfigurationEntry object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ServiceConfigurationEntry data)
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
        sqlCmdText = "UPDATE [core].[ServiceConfigurationEntry] SET " +
												"[ServiceConfigurationID] = @ServiceConfigurationID, " + 
												"[CountryID] = @CountryID, " + 
												"[MobileOperatorID] = @MobileOperatorID, " + 
												"[Shortcode] = @Shortcode, " + 
												"[Keyword] = @Keyword, " + 
												"[IsAgeVerificationRequired] = @IsAgeVerificationRequired, " + 
												"[IsActive] = @IsActive, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ServiceConfigurationEntryID] = @ServiceConfigurationEntryID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", data.ServiceConfiguration.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.CountryID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@MobileOperatorID", data.MobileOperatorID.HasValue ? (object)data.MobileOperatorID.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Shortcode", data.Shortcode).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@Keyword", data.Keyword).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsAgeVerificationRequired", data.IsAgeVerificationRequired).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ServiceConfigurationEntryID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "update", "norecord"), "ServiceConfigurationEntry could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceConfigurationEntry", "Exception while updating ServiceConfigurationEntry object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "update", "morerecords"), "ServiceConfigurationEntry was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceConfigurationEntry", "Exception while updating ServiceConfigurationEntry object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "update", "exception"), "ServiceConfigurationEntry could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ServiceConfigurationEntry", "Exception while updating ServiceConfigurationEntry object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ServiceConfigurationEntry data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ServiceConfigurationEntry] WHERE ServiceConfigurationEntryID = @ServiceConfigurationEntryID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceConfigurationEntryID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "delete", "norecord"), "ServiceConfigurationEntry could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ServiceConfigurationEntry", "Exception while deleting ServiceConfigurationEntry object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sce", "delete", "exception"), "ServiceConfigurationEntry could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ServiceConfigurationEntry", "Exception while deleting ServiceConfigurationEntry object from database. See inner exception for details.", ex);
      }
    }
  }
}

