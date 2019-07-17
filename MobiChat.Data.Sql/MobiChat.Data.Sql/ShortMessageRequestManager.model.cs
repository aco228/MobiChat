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
  [DataManager(typeof(ShortMessageRequest))] 
  public partial class ShortMessageRequestManager : MobiChat.Data.Sql.SqlManagerBase<ShortMessageRequest>, IShortMessageRequestManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ShortMessageRequest LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ShortMessageRequestTable.GetColumnNames("[smr]") + 
							(this.Depth > 0 ? "," + ShortMessageTable.GetColumnNames("[smr_sm]") : string.Empty) + 
							(this.Depth > 1 ? "," + ActionContextTable.GetColumnNames("[smr_sm_ac]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[smr_sm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[smr_sm_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[smr_sm_c]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[smr_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[smr_u_ut]") : string.Empty) + 
					" FROM [core].[ShortMessageRequest] AS [smr] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ShortMessage] AS [smr_sm] ON [smr].[ShortMessageID] = [smr_sm].[ShortMessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContext] AS [smr_sm_ac] ON [smr_sm].[ActionContextID] = [smr_sm_ac].[ActionContextID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [smr_sm_s] ON [smr_sm].[ServiceID] = [smr_sm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [smr_sm_mo] ON [smr_sm].[MobileOperatorID] = [smr_sm_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Customer] AS [smr_sm_c] ON [smr_sm].[CustomerID] = [smr_sm_c].[CustomerID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [smr_u] ON [smr].[UserID] = [smr_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [smr_u_ut] ON [smr_u].[UserTypeID] = [smr_u_ut].[UserTypeID] ";
				sqlCmdText += "WHERE [smr].[ShortMessageRequestID] = @ShortMessageRequestID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ShortMessageRequestID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "loadinternal", "notfound"), "ShortMessageRequest could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ShortMessageRequestTable smrTable = new ShortMessageRequestTable(query);
				ShortMessageTable smr_smTable = (this.Depth > 0) ? new ShortMessageTable(query) : null;
				ActionContextTable smr_sm_acTable = (this.Depth > 1) ? new ActionContextTable(query) : null;
				ServiceTable smr_sm_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				MobileOperatorTable smr_sm_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;
				CustomerTable smr_sm_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				UserTable smr_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable smr_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        
				ActionContext smr_sm_acObject = (this.Depth > 1) ? smr_sm_acTable.CreateInstance() : null;
				Service smr_sm_sObject = (this.Depth > 1) ? smr_sm_sTable.CreateInstance() : null;
				MobileOperator smr_sm_moObject = (this.Depth > 1) ? smr_sm_moTable.CreateInstance() : null;
				Customer smr_sm_cObject = (this.Depth > 1) ? smr_sm_cTable.CreateInstance() : null;
				ShortMessage smr_smObject = (this.Depth > 0) ? smr_smTable.CreateInstance(smr_sm_acObject, smr_sm_sObject, smr_sm_moObject, smr_sm_cObject) : null;
				UserType smr_u_utObject = (this.Depth > 1) ? smr_u_utTable.CreateInstance() : null;
				User smr_uObject = (this.Depth > 0) ? smr_uTable.CreateInstance(smr_u_utObject) : null;
				ShortMessageRequest smrObject = smrTable.CreateInstance(smr_smObject, smr_uObject);
				sqlReader.Close();

				return smrObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "loadinternal", "exception"), "ShortMessageRequest could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ShortMessageRequest", "Exception while loading ShortMessageRequest object from database. See inner exception for details.", ex);
      }
    }

    public ShortMessageRequest Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ShortMessageRequestTable.GetColumnNames("[smr]") + 
							(this.Depth > 0 ? "," + ShortMessageTable.GetColumnNames("[smr_sm]") : string.Empty) + 
							(this.Depth > 1 ? "," + ActionContextTable.GetColumnNames("[smr_sm_ac]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[smr_sm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[smr_sm_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[smr_sm_c]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[smr_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[smr_u_ut]") : string.Empty) +  
					" FROM [core].[ShortMessageRequest] AS [smr] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ShortMessage] AS [smr_sm] ON [smr].[ShortMessageID] = [smr_sm].[ShortMessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContext] AS [smr_sm_ac] ON [smr_sm].[ActionContextID] = [smr_sm_ac].[ActionContextID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [smr_sm_s] ON [smr_sm].[ServiceID] = [smr_sm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [smr_sm_mo] ON [smr_sm].[MobileOperatorID] = [smr_sm_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Customer] AS [smr_sm_c] ON [smr_sm].[CustomerID] = [smr_sm_c].[CustomerID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [smr_u] ON [smr].[UserID] = [smr_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [smr_u_ut] ON [smr_u].[UserTypeID] = [smr_u_ut].[UserTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "customload", "notfound"), "ShortMessageRequest could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ShortMessageRequestTable smrTable = new ShortMessageRequestTable(query);
				ShortMessageTable smr_smTable = (this.Depth > 0) ? new ShortMessageTable(query) : null;
				ActionContextTable smr_sm_acTable = (this.Depth > 1) ? new ActionContextTable(query) : null;
				ServiceTable smr_sm_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				MobileOperatorTable smr_sm_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;
				CustomerTable smr_sm_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				UserTable smr_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable smr_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        
				ActionContext smr_sm_acObject = (this.Depth > 1) ? smr_sm_acTable.CreateInstance() : null;
				Service smr_sm_sObject = (this.Depth > 1) ? smr_sm_sTable.CreateInstance() : null;
				MobileOperator smr_sm_moObject = (this.Depth > 1) ? smr_sm_moTable.CreateInstance() : null;
				Customer smr_sm_cObject = (this.Depth > 1) ? smr_sm_cTable.CreateInstance() : null;
				ShortMessage smr_smObject = (this.Depth > 0) ? smr_smTable.CreateInstance(smr_sm_acObject, smr_sm_sObject, smr_sm_moObject, smr_sm_cObject) : null;
				UserType smr_u_utObject = (this.Depth > 1) ? smr_u_utTable.CreateInstance() : null;
				User smr_uObject = (this.Depth > 0) ? smr_uTable.CreateInstance(smr_u_utObject) : null;
				ShortMessageRequest smrObject = smrTable.CreateInstance(smr_smObject, smr_uObject);
				sqlReader.Close();

				return smrObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "customload", "exception"), "ShortMessageRequest could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ShortMessageRequest", "Exception while loading (custom/single) ShortMessageRequest object from database. See inner exception for details.", ex);
      }
    }

    public List<ShortMessageRequest> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ShortMessageRequestTable.GetColumnNames("[smr]") + 
							(this.Depth > 0 ? "," + ShortMessageTable.GetColumnNames("[smr_sm]") : string.Empty) + 
							(this.Depth > 1 ? "," + ActionContextTable.GetColumnNames("[smr_sm_ac]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[smr_sm_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[smr_sm_mo]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[smr_sm_c]") : string.Empty) + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[smr_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[smr_u_ut]") : string.Empty) +  
					" FROM [core].[ShortMessageRequest] AS [smr] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ShortMessage] AS [smr_sm] ON [smr].[ShortMessageID] = [smr_sm].[ShortMessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[ActionContext] AS [smr_sm_ac] ON [smr_sm].[ActionContextID] = [smr_sm_ac].[ActionContextID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [smr_sm_s] ON [smr_sm].[ServiceID] = [smr_sm_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [smr_sm_mo] ON [smr_sm].[MobileOperatorID] = [smr_sm_mo].[MobileOperatorID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Customer] AS [smr_sm_c] ON [smr_sm].[CustomerID] = [smr_sm_c].[CustomerID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [smr_u] ON [smr].[UserID] = [smr_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [smr_u_ut] ON [smr_u].[UserTypeID] = [smr_u_ut].[UserTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "customloadmany", "notfound"), "ShortMessageRequest list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ShortMessageRequest>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ShortMessageRequestTable smrTable = new ShortMessageRequestTable(query);
				ShortMessageTable smr_smTable = (this.Depth > 0) ? new ShortMessageTable(query) : null;
				ActionContextTable smr_sm_acTable = (this.Depth > 1) ? new ActionContextTable(query) : null;
				ServiceTable smr_sm_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				MobileOperatorTable smr_sm_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;
				CustomerTable smr_sm_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				UserTable smr_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable smr_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        List<ShortMessageRequest> result = new List<ShortMessageRequest>();
        do
        {
          
					ActionContext smr_sm_acObject = (this.Depth > 1) ? smr_sm_acTable.CreateInstance() : null;
					Service smr_sm_sObject = (this.Depth > 1) ? smr_sm_sTable.CreateInstance() : null;
					MobileOperator smr_sm_moObject = (this.Depth > 1) ? smr_sm_moTable.CreateInstance() : null;
					Customer smr_sm_cObject = (this.Depth > 1) ? smr_sm_cTable.CreateInstance() : null;
					ShortMessage smr_smObject = (this.Depth > 0) ? smr_smTable.CreateInstance(smr_sm_acObject, smr_sm_sObject, smr_sm_moObject, smr_sm_cObject) : null;
					UserType smr_u_utObject = (this.Depth > 1) ? smr_u_utTable.CreateInstance() : null;
					User smr_uObject = (this.Depth > 0) ? smr_uTable.CreateInstance(smr_u_utObject) : null;
					ShortMessageRequest smrObject = (this.Depth > -1) ? smrTable.CreateInstance(smr_smObject, smr_uObject) : null;
					result.Add(smrObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "customloadmany", "exception"), "ShortMessageRequest list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ShortMessageRequest", "Exception while loading (custom/many) ShortMessageRequest object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ShortMessageRequest data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ShortMessageRequest] ([ShortMessageRequestGuid],[ShortMessageID],[UserID]) VALUES(@ShortMessageRequestGuid,@ShortMessageID,@UserID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ShortMessageRequestGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ShortMessageID", data.ShortMessage.ID);
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "insert", "noprimarykey"), "ShortMessageRequest could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ShortMessageRequest", "Exception while inserting ShortMessageRequest object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "insert", "exception"), "ShortMessageRequest could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ShortMessageRequest", "Exception while inserting ShortMessageRequest object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ShortMessageRequest data)
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
        sqlCmdText = "UPDATE [core].[ShortMessageRequest] SET " +
												"[ShortMessageRequestGuid] = @ShortMessageRequestGuid, " + 
												"[ShortMessageID] = @ShortMessageID, " + 
												"[UserID] = @UserID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ShortMessageRequestID] = @ShortMessageRequestID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ShortMessageRequestGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ShortMessageID", data.ShortMessage.ID);
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ShortMessageRequestID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "update", "norecord"), "ShortMessageRequest could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ShortMessageRequest", "Exception while updating ShortMessageRequest object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "update", "morerecords"), "ShortMessageRequest was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ShortMessageRequest", "Exception while updating ShortMessageRequest object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "update", "exception"), "ShortMessageRequest could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ShortMessageRequest", "Exception while updating ShortMessageRequest object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ShortMessageRequest data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ShortMessageRequest] WHERE ShortMessageRequestID = @ShortMessageRequestID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ShortMessageRequestID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "delete", "norecord"), "ShortMessageRequest could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ShortMessageRequest", "Exception while deleting ShortMessageRequest object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("smr", "delete", "exception"), "ShortMessageRequest could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ShortMessageRequest", "Exception while deleting ShortMessageRequest object from database. See inner exception for details.", ex);
      }
    }
  }
}

