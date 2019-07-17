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
  [DataManager(typeof(ServiceConfiguration))] 
  public partial class ServiceConfigurationManager : MobiChat.Data.Sql.SqlManagerBase<ServiceConfiguration>, IServiceConfigurationManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ServiceConfiguration LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ServiceConfigurationTable.GetColumnNames("[sc]") + 
							(this.Depth > 0 ? "," + PaymentConfigurationTable.GetColumnNames("[sc_pc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentCredentialsTable.GetColumnNames("[sc_pc_pc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentInterfaceTable.GetColumnNames("[sc_pc_pi]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentProviderTable.GetColumnNames("[sc_pc_pp]") : string.Empty) + 
							(this.Depth > 1 ? "," + BehaviorModelTable.GetColumnNames("[sc_pc_bm]") : string.Empty) + 
					" FROM [core].[ServiceConfiguration] AS [sc] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [sc_pc] ON [sc].[PaymentConfigurationID] = [sc_pc].[PaymentConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentCredentials] AS [sc_pc_pc] ON [sc_pc].[PaymentCredentialsID] = [sc_pc_pc].[PaymentCredentialsID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentInterface] AS [sc_pc_pi] ON [sc_pc].[PaymentInterfaceID] = [sc_pc_pi].[PaymentInterfaceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentProvider] AS [sc_pc_pp] ON [sc_pc].[PaymentProviderID] = [sc_pc_pp].[PaymentProviderID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[BehaviorModel] AS [sc_pc_bm] ON [sc_pc].[BehaviorModelID] = [sc_pc_bm].[BehaviorModelID] ";
				sqlCmdText += "WHERE [sc].[ServiceConfigurationID] = @ServiceConfigurationID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "loadinternal", "notfound"), "ServiceConfiguration could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceConfigurationTable scTable = new ServiceConfigurationTable(query);
				PaymentConfigurationTable sc_pcTable = (this.Depth > 0) ? new PaymentConfigurationTable(query) : null;
				PaymentCredentialsTable sc_pc_pcTable = (this.Depth > 1) ? new PaymentCredentialsTable(query) : null;
				PaymentInterfaceTable sc_pc_piTable = (this.Depth > 1) ? new PaymentInterfaceTable(query) : null;
				PaymentProviderTable sc_pc_ppTable = (this.Depth > 1) ? new PaymentProviderTable(query) : null;
				BehaviorModelTable sc_pc_bmTable = (this.Depth > 1) ? new BehaviorModelTable(query) : null;

        
				PaymentCredentials sc_pc_pcObject = (this.Depth > 1) ? sc_pc_pcTable.CreateInstance() : null;
				PaymentInterface sc_pc_piObject = (this.Depth > 1) ? sc_pc_piTable.CreateInstance() : null;
				PaymentProvider sc_pc_ppObject = (this.Depth > 1) ? sc_pc_ppTable.CreateInstance() : null;
				BehaviorModel sc_pc_bmObject = (this.Depth > 1) ? sc_pc_bmTable.CreateInstance() : null;
				PaymentConfiguration sc_pcObject = (this.Depth > 0) ? sc_pcTable.CreateInstance(sc_pc_pcObject, sc_pc_piObject, sc_pc_ppObject, sc_pc_bmObject) : null;
				ServiceConfiguration scObject = scTable.CreateInstance(sc_pcObject);
				sqlReader.Close();

				return scObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "loadinternal", "exception"), "ServiceConfiguration could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceConfiguration", "Exception while loading ServiceConfiguration object from database. See inner exception for details.", ex);
      }
    }

    public ServiceConfiguration Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceConfigurationTable.GetColumnNames("[sc]") + 
							(this.Depth > 0 ? "," + PaymentConfigurationTable.GetColumnNames("[sc_pc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentCredentialsTable.GetColumnNames("[sc_pc_pc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentInterfaceTable.GetColumnNames("[sc_pc_pi]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentProviderTable.GetColumnNames("[sc_pc_pp]") : string.Empty) + 
							(this.Depth > 1 ? "," + BehaviorModelTable.GetColumnNames("[sc_pc_bm]") : string.Empty) +  
					" FROM [core].[ServiceConfiguration] AS [sc] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [sc_pc] ON [sc].[PaymentConfigurationID] = [sc_pc].[PaymentConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentCredentials] AS [sc_pc_pc] ON [sc_pc].[PaymentCredentialsID] = [sc_pc_pc].[PaymentCredentialsID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentInterface] AS [sc_pc_pi] ON [sc_pc].[PaymentInterfaceID] = [sc_pc_pi].[PaymentInterfaceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentProvider] AS [sc_pc_pp] ON [sc_pc].[PaymentProviderID] = [sc_pc_pp].[PaymentProviderID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[BehaviorModel] AS [sc_pc_bm] ON [sc_pc].[BehaviorModelID] = [sc_pc_bm].[BehaviorModelID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "customload", "notfound"), "ServiceConfiguration could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceConfigurationTable scTable = new ServiceConfigurationTable(query);
				PaymentConfigurationTable sc_pcTable = (this.Depth > 0) ? new PaymentConfigurationTable(query) : null;
				PaymentCredentialsTable sc_pc_pcTable = (this.Depth > 1) ? new PaymentCredentialsTable(query) : null;
				PaymentInterfaceTable sc_pc_piTable = (this.Depth > 1) ? new PaymentInterfaceTable(query) : null;
				PaymentProviderTable sc_pc_ppTable = (this.Depth > 1) ? new PaymentProviderTable(query) : null;
				BehaviorModelTable sc_pc_bmTable = (this.Depth > 1) ? new BehaviorModelTable(query) : null;

        
				PaymentCredentials sc_pc_pcObject = (this.Depth > 1) ? sc_pc_pcTable.CreateInstance() : null;
				PaymentInterface sc_pc_piObject = (this.Depth > 1) ? sc_pc_piTable.CreateInstance() : null;
				PaymentProvider sc_pc_ppObject = (this.Depth > 1) ? sc_pc_ppTable.CreateInstance() : null;
				BehaviorModel sc_pc_bmObject = (this.Depth > 1) ? sc_pc_bmTable.CreateInstance() : null;
				PaymentConfiguration sc_pcObject = (this.Depth > 0) ? sc_pcTable.CreateInstance(sc_pc_pcObject, sc_pc_piObject, sc_pc_ppObject, sc_pc_bmObject) : null;
				ServiceConfiguration scObject = scTable.CreateInstance(sc_pcObject);
				sqlReader.Close();

				return scObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "customload", "exception"), "ServiceConfiguration could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceConfiguration", "Exception while loading (custom/single) ServiceConfiguration object from database. See inner exception for details.", ex);
      }
    }

    public List<ServiceConfiguration> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceConfigurationTable.GetColumnNames("[sc]") + 
							(this.Depth > 0 ? "," + PaymentConfigurationTable.GetColumnNames("[sc_pc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentCredentialsTable.GetColumnNames("[sc_pc_pc]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentInterfaceTable.GetColumnNames("[sc_pc_pi]") : string.Empty) + 
							(this.Depth > 1 ? "," + PaymentProviderTable.GetColumnNames("[sc_pc_pp]") : string.Empty) + 
							(this.Depth > 1 ? "," + BehaviorModelTable.GetColumnNames("[sc_pc_bm]") : string.Empty) +  
					" FROM [core].[ServiceConfiguration] AS [sc] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentConfiguration] AS [sc_pc] ON [sc].[PaymentConfigurationID] = [sc_pc].[PaymentConfigurationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentCredentials] AS [sc_pc_pc] ON [sc_pc].[PaymentCredentialsID] = [sc_pc_pc].[PaymentCredentialsID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentInterface] AS [sc_pc_pi] ON [sc_pc].[PaymentInterfaceID] = [sc_pc_pi].[PaymentInterfaceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[PaymentProvider] AS [sc_pc_pp] ON [sc_pc].[PaymentProviderID] = [sc_pc_pp].[PaymentProviderID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[BehaviorModel] AS [sc_pc_bm] ON [sc_pc].[BehaviorModelID] = [sc_pc_bm].[BehaviorModelID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "customloadmany", "notfound"), "ServiceConfiguration list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ServiceConfiguration>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceConfigurationTable scTable = new ServiceConfigurationTable(query);
				PaymentConfigurationTable sc_pcTable = (this.Depth > 0) ? new PaymentConfigurationTable(query) : null;
				PaymentCredentialsTable sc_pc_pcTable = (this.Depth > 1) ? new PaymentCredentialsTable(query) : null;
				PaymentInterfaceTable sc_pc_piTable = (this.Depth > 1) ? new PaymentInterfaceTable(query) : null;
				PaymentProviderTable sc_pc_ppTable = (this.Depth > 1) ? new PaymentProviderTable(query) : null;
				BehaviorModelTable sc_pc_bmTable = (this.Depth > 1) ? new BehaviorModelTable(query) : null;

        List<ServiceConfiguration> result = new List<ServiceConfiguration>();
        do
        {
          
					PaymentCredentials sc_pc_pcObject = (this.Depth > 1) ? sc_pc_pcTable.CreateInstance() : null;
					PaymentInterface sc_pc_piObject = (this.Depth > 1) ? sc_pc_piTable.CreateInstance() : null;
					PaymentProvider sc_pc_ppObject = (this.Depth > 1) ? sc_pc_ppTable.CreateInstance() : null;
					BehaviorModel sc_pc_bmObject = (this.Depth > 1) ? sc_pc_bmTable.CreateInstance() : null;
					PaymentConfiguration sc_pcObject = (this.Depth > 0) ? sc_pcTable.CreateInstance(sc_pc_pcObject, sc_pc_piObject, sc_pc_ppObject, sc_pc_bmObject) : null;
					ServiceConfiguration scObject = (this.Depth > -1) ? scTable.CreateInstance(sc_pcObject) : null;
					result.Add(scObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "customloadmany", "exception"), "ServiceConfiguration list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceConfiguration", "Exception while loading (custom/many) ServiceConfiguration object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ServiceConfiguration data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ServiceConfiguration] ([InstanceID],[PaymentConfigurationID],[ExternalID],[Name]) VALUES(@InstanceID,@PaymentConfigurationID,@ExternalID,@Name); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.InstanceID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@PaymentConfigurationID", data.PaymentConfiguration.ID);
				sqlCmd.Parameters.AddWithValue("@ExternalID", !string.IsNullOrEmpty(data.ExternalID) ? (object)data.ExternalID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "insert", "noprimarykey"), "ServiceConfiguration could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ServiceConfiguration", "Exception while inserting ServiceConfiguration object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "insert", "exception"), "ServiceConfiguration could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ServiceConfiguration", "Exception while inserting ServiceConfiguration object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ServiceConfiguration data)
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
        sqlCmdText = "UPDATE [core].[ServiceConfiguration] SET " +
												"[InstanceID] = @InstanceID, " + 
												"[PaymentConfigurationID] = @PaymentConfigurationID, " + 
												"[ExternalID] = @ExternalID, " + 
												"[Name] = @Name, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ServiceConfigurationID] = @ServiceConfigurationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.InstanceID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@PaymentConfigurationID", data.PaymentConfiguration.ID);
				sqlCmd.Parameters.AddWithValue("@ExternalID", !string.IsNullOrEmpty(data.ExternalID) ? (object)data.ExternalID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "update", "norecord"), "ServiceConfiguration could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceConfiguration", "Exception while updating ServiceConfiguration object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "update", "morerecords"), "ServiceConfiguration was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceConfiguration", "Exception while updating ServiceConfiguration object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "update", "exception"), "ServiceConfiguration could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ServiceConfiguration", "Exception while updating ServiceConfiguration object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ServiceConfiguration data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ServiceConfiguration] WHERE ServiceConfigurationID = @ServiceConfigurationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceConfigurationID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "delete", "norecord"), "ServiceConfiguration could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ServiceConfiguration", "Exception while deleting ServiceConfiguration object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("sc", "delete", "exception"), "ServiceConfiguration could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ServiceConfiguration", "Exception while deleting ServiceConfiguration object from database. See inner exception for details.", ex);
      }
    }
  }
}

