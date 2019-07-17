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
  [DataManager(typeof(PaymentConfiguration))] 
  public partial class PaymentConfigurationManager : MobiChat.Data.Sql.SqlManagerBase<PaymentConfiguration>, IPaymentConfigurationManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override PaymentConfiguration LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							PaymentConfigurationTable.GetColumnNames("[pc]") + 
							(this.Depth > 0 ? "," + PaymentCredentialsTable.GetColumnNames("[pc_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + PaymentInterfaceTable.GetColumnNames("[pc_pi]") : string.Empty) + 
							(this.Depth > 0 ? "," + PaymentProviderTable.GetColumnNames("[pc_pp]") : string.Empty) + 
							(this.Depth > 0 ? "," + BehaviorModelTable.GetColumnNames("[pc_bm]") : string.Empty) + 
					" FROM [core].[PaymentConfiguration] AS [pc] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentCredentials] AS [pc_pc] ON [pc].[PaymentCredentialsID] = [pc_pc].[PaymentCredentialsID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentInterface] AS [pc_pi] ON [pc].[PaymentInterfaceID] = [pc_pi].[PaymentInterfaceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentProvider] AS [pc_pp] ON [pc].[PaymentProviderID] = [pc_pp].[PaymentProviderID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[BehaviorModel] AS [pc_bm] ON [pc].[BehaviorModelID] = [pc_bm].[BehaviorModelID] ";
				sqlCmdText += "WHERE [pc].[PaymentConfigurationID] = @PaymentConfigurationID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@PaymentConfigurationID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "loadinternal", "notfound"), "PaymentConfiguration could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				PaymentConfigurationTable pcTable = new PaymentConfigurationTable(query);
				PaymentCredentialsTable pc_pcTable = (this.Depth > 0) ? new PaymentCredentialsTable(query) : null;
				PaymentInterfaceTable pc_piTable = (this.Depth > 0) ? new PaymentInterfaceTable(query) : null;
				PaymentProviderTable pc_ppTable = (this.Depth > 0) ? new PaymentProviderTable(query) : null;
				BehaviorModelTable pc_bmTable = (this.Depth > 0) ? new BehaviorModelTable(query) : null;

        
				PaymentCredentials pc_pcObject = (this.Depth > 0) ? pc_pcTable.CreateInstance() : null;
				PaymentInterface pc_piObject = (this.Depth > 0) ? pc_piTable.CreateInstance() : null;
				PaymentProvider pc_ppObject = (this.Depth > 0) ? pc_ppTable.CreateInstance() : null;
				BehaviorModel pc_bmObject = (this.Depth > 0) ? pc_bmTable.CreateInstance() : null;
				PaymentConfiguration pcObject = pcTable.CreateInstance(pc_pcObject, pc_piObject, pc_ppObject, pc_bmObject);
				sqlReader.Close();

				return pcObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "loadinternal", "exception"), "PaymentConfiguration could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "PaymentConfiguration", "Exception while loading PaymentConfiguration object from database. See inner exception for details.", ex);
      }
    }

    public PaymentConfiguration Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							PaymentConfigurationTable.GetColumnNames("[pc]") + 
							(this.Depth > 0 ? "," + PaymentCredentialsTable.GetColumnNames("[pc_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + PaymentInterfaceTable.GetColumnNames("[pc_pi]") : string.Empty) + 
							(this.Depth > 0 ? "," + PaymentProviderTable.GetColumnNames("[pc_pp]") : string.Empty) + 
							(this.Depth > 0 ? "," + BehaviorModelTable.GetColumnNames("[pc_bm]") : string.Empty) +  
					" FROM [core].[PaymentConfiguration] AS [pc] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentCredentials] AS [pc_pc] ON [pc].[PaymentCredentialsID] = [pc_pc].[PaymentCredentialsID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentInterface] AS [pc_pi] ON [pc].[PaymentInterfaceID] = [pc_pi].[PaymentInterfaceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentProvider] AS [pc_pp] ON [pc].[PaymentProviderID] = [pc_pp].[PaymentProviderID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[BehaviorModel] AS [pc_bm] ON [pc].[BehaviorModelID] = [pc_bm].[BehaviorModelID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customload", "notfound"), "PaymentConfiguration could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				PaymentConfigurationTable pcTable = new PaymentConfigurationTable(query);
				PaymentCredentialsTable pc_pcTable = (this.Depth > 0) ? new PaymentCredentialsTable(query) : null;
				PaymentInterfaceTable pc_piTable = (this.Depth > 0) ? new PaymentInterfaceTable(query) : null;
				PaymentProviderTable pc_ppTable = (this.Depth > 0) ? new PaymentProviderTable(query) : null;
				BehaviorModelTable pc_bmTable = (this.Depth > 0) ? new BehaviorModelTable(query) : null;

        
				PaymentCredentials pc_pcObject = (this.Depth > 0) ? pc_pcTable.CreateInstance() : null;
				PaymentInterface pc_piObject = (this.Depth > 0) ? pc_piTable.CreateInstance() : null;
				PaymentProvider pc_ppObject = (this.Depth > 0) ? pc_ppTable.CreateInstance() : null;
				BehaviorModel pc_bmObject = (this.Depth > 0) ? pc_bmTable.CreateInstance() : null;
				PaymentConfiguration pcObject = pcTable.CreateInstance(pc_pcObject, pc_piObject, pc_ppObject, pc_bmObject);
				sqlReader.Close();

				return pcObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customload", "exception"), "PaymentConfiguration could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "PaymentConfiguration", "Exception while loading (custom/single) PaymentConfiguration object from database. See inner exception for details.", ex);
      }
    }

    public List<PaymentConfiguration> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							PaymentConfigurationTable.GetColumnNames("[pc]") + 
							(this.Depth > 0 ? "," + PaymentCredentialsTable.GetColumnNames("[pc_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + PaymentInterfaceTable.GetColumnNames("[pc_pi]") : string.Empty) + 
							(this.Depth > 0 ? "," + PaymentProviderTable.GetColumnNames("[pc_pp]") : string.Empty) + 
							(this.Depth > 0 ? "," + BehaviorModelTable.GetColumnNames("[pc_bm]") : string.Empty) +  
					" FROM [core].[PaymentConfiguration] AS [pc] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentCredentials] AS [pc_pc] ON [pc].[PaymentCredentialsID] = [pc_pc].[PaymentCredentialsID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentInterface] AS [pc_pi] ON [pc].[PaymentInterfaceID] = [pc_pi].[PaymentInterfaceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[PaymentProvider] AS [pc_pp] ON [pc].[PaymentProviderID] = [pc_pp].[PaymentProviderID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[BehaviorModel] AS [pc_bm] ON [pc].[BehaviorModelID] = [pc_bm].[BehaviorModelID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customloadmany", "notfound"), "PaymentConfiguration list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<PaymentConfiguration>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				PaymentConfigurationTable pcTable = new PaymentConfigurationTable(query);
				PaymentCredentialsTable pc_pcTable = (this.Depth > 0) ? new PaymentCredentialsTable(query) : null;
				PaymentInterfaceTable pc_piTable = (this.Depth > 0) ? new PaymentInterfaceTable(query) : null;
				PaymentProviderTable pc_ppTable = (this.Depth > 0) ? new PaymentProviderTable(query) : null;
				BehaviorModelTable pc_bmTable = (this.Depth > 0) ? new BehaviorModelTable(query) : null;

        List<PaymentConfiguration> result = new List<PaymentConfiguration>();
        do
        {
          
					PaymentCredentials pc_pcObject = (this.Depth > 0) ? pc_pcTable.CreateInstance() : null;
					PaymentInterface pc_piObject = (this.Depth > 0) ? pc_piTable.CreateInstance() : null;
					PaymentProvider pc_ppObject = (this.Depth > 0) ? pc_ppTable.CreateInstance() : null;
					BehaviorModel pc_bmObject = (this.Depth > 0) ? pc_bmTable.CreateInstance() : null;
					PaymentConfiguration pcObject = (this.Depth > -1) ? pcTable.CreateInstance(pc_pcObject, pc_piObject, pc_ppObject, pc_bmObject) : null;
					result.Add(pcObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customloadmany", "exception"), "PaymentConfiguration list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "PaymentConfiguration", "Exception while loading (custom/many) PaymentConfiguration object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, PaymentConfiguration data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[PaymentConfiguration] ([PaymentCredentialsID],[PaymentInterfaceID],[PaymentProviderID],[BehaviorModelID],[Name]) VALUES(@PaymentCredentialsID,@PaymentInterfaceID,@PaymentProviderID,@BehaviorModelID,@Name); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@PaymentCredentialsID", data.PaymentCredentials.ID);
				sqlCmd.Parameters.AddWithValue("@PaymentInterfaceID", data.PaymentInterface.ID);
				sqlCmd.Parameters.AddWithValue("@PaymentProviderID", data.PaymentProvider.ID);
				sqlCmd.Parameters.AddWithValue("@BehaviorModelID", data.BehaviorModel.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "insert", "noprimarykey"), "PaymentConfiguration could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "PaymentConfiguration", "Exception while inserting PaymentConfiguration object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "insert", "exception"), "PaymentConfiguration could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "PaymentConfiguration", "Exception while inserting PaymentConfiguration object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, PaymentConfiguration data)
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
        sqlCmdText = "UPDATE [core].[PaymentConfiguration] SET " +
												"[PaymentCredentialsID] = @PaymentCredentialsID, " + 
												"[PaymentInterfaceID] = @PaymentInterfaceID, " + 
												"[PaymentProviderID] = @PaymentProviderID, " + 
												"[BehaviorModelID] = @BehaviorModelID, " + 
												"[Name] = @Name, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [PaymentConfigurationID] = @PaymentConfigurationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@PaymentCredentialsID", data.PaymentCredentials.ID);
				sqlCmd.Parameters.AddWithValue("@PaymentInterfaceID", data.PaymentInterface.ID);
				sqlCmd.Parameters.AddWithValue("@PaymentProviderID", data.PaymentProvider.ID);
				sqlCmd.Parameters.AddWithValue("@BehaviorModelID", data.BehaviorModel.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@PaymentConfigurationID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "update", "norecord"), "PaymentConfiguration could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "PaymentConfiguration", "Exception while updating PaymentConfiguration object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "update", "morerecords"), "PaymentConfiguration was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "PaymentConfiguration", "Exception while updating PaymentConfiguration object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "update", "exception"), "PaymentConfiguration could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "PaymentConfiguration", "Exception while updating PaymentConfiguration object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, PaymentConfiguration data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[PaymentConfiguration] WHERE PaymentConfigurationID = @PaymentConfigurationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@PaymentConfigurationID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "delete", "norecord"), "PaymentConfiguration could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "PaymentConfiguration", "Exception while deleting PaymentConfiguration object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "delete", "exception"), "PaymentConfiguration could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "PaymentConfiguration", "Exception while deleting PaymentConfiguration object from database. See inner exception for details.", ex);
      }
    }
  }
}

