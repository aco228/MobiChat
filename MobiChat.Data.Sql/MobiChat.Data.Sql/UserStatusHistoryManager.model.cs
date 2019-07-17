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
  [DataManager(typeof(UserStatusHistory))] 
  public partial class UserStatusHistoryManager : MobiChat.Data.Sql.SqlManagerBase<UserStatusHistory>, IUserStatusHistoryManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override UserStatusHistory LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							UserStatusHistoryTable.GetColumnNames("[ush]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[ush_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[ush_u_ut]") : string.Empty) + 
					" FROM [core].[UserStatusHistory] AS [ush] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [ush_u] ON [ush].[UserID] = [ush_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [ush_u_ut] ON [ush_u].[UserTypeID] = [ush_u_ut].[UserTypeID] ";
				sqlCmdText += "WHERE [ush].[UserStatusHistoryID] = @UserStatusHistoryID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserStatusHistoryID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "loadinternal", "notfound"), "UserStatusHistory could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserStatusHistoryTable ushTable = new UserStatusHistoryTable(query);
				UserTable ush_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable ush_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        
				UserType ush_u_utObject = (this.Depth > 1) ? ush_u_utTable.CreateInstance() : null;
				User ush_uObject = (this.Depth > 0) ? ush_uTable.CreateInstance(ush_u_utObject) : null;
				UserStatusHistory ushObject = ushTable.CreateInstance(ush_uObject);
				sqlReader.Close();

				return ushObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "loadinternal", "exception"), "UserStatusHistory could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserStatusHistory", "Exception while loading UserStatusHistory object from database. See inner exception for details.", ex);
      }
    }

    public UserStatusHistory Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserStatusHistoryTable.GetColumnNames("[ush]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[ush_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[ush_u_ut]") : string.Empty) +  
					" FROM [core].[UserStatusHistory] AS [ush] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [ush_u] ON [ush].[UserID] = [ush_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [ush_u_ut] ON [ush_u].[UserTypeID] = [ush_u_ut].[UserTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "customload", "notfound"), "UserStatusHistory could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserStatusHistoryTable ushTable = new UserStatusHistoryTable(query);
				UserTable ush_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable ush_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        
				UserType ush_u_utObject = (this.Depth > 1) ? ush_u_utTable.CreateInstance() : null;
				User ush_uObject = (this.Depth > 0) ? ush_uTable.CreateInstance(ush_u_utObject) : null;
				UserStatusHistory ushObject = ushTable.CreateInstance(ush_uObject);
				sqlReader.Close();

				return ushObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "customload", "exception"), "UserStatusHistory could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserStatusHistory", "Exception while loading (custom/single) UserStatusHistory object from database. See inner exception for details.", ex);
      }
    }

    public List<UserStatusHistory> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserStatusHistoryTable.GetColumnNames("[ush]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[ush_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[ush_u_ut]") : string.Empty) +  
					" FROM [core].[UserStatusHistory] AS [ush] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [ush_u] ON [ush].[UserID] = [ush_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [ush_u_ut] ON [ush_u].[UserTypeID] = [ush_u_ut].[UserTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "customloadmany", "notfound"), "UserStatusHistory list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<UserStatusHistory>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserStatusHistoryTable ushTable = new UserStatusHistoryTable(query);
				UserTable ush_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable ush_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        List<UserStatusHistory> result = new List<UserStatusHistory>();
        do
        {
          
					UserType ush_u_utObject = (this.Depth > 1) ? ush_u_utTable.CreateInstance() : null;
					User ush_uObject = (this.Depth > 0) ? ush_uTable.CreateInstance(ush_u_utObject) : null;
					UserStatusHistory ushObject = (this.Depth > -1) ? ushTable.CreateInstance(ush_uObject) : null;
					result.Add(ushObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "customloadmany", "exception"), "UserStatusHistory list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserStatusHistory", "Exception while loading (custom/many) UserStatusHistory object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, UserStatusHistory data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[UserStatusHistory] ([UserID],[UserStatusID],[Note]) VALUES(@UserID,@UserStatusID,@Note); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				sqlCmd.Parameters.AddWithValue("@UserStatusID", (int)data.UserStatus);
				sqlCmd.Parameters.AddWithValue("@Note", !string.IsNullOrEmpty(data.Note) ? (object)data.Note : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "insert", "noprimarykey"), "UserStatusHistory could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "UserStatusHistory", "Exception while inserting UserStatusHistory object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "insert", "exception"), "UserStatusHistory could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "UserStatusHistory", "Exception while inserting UserStatusHistory object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, UserStatusHistory data)
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
        sqlCmdText = "UPDATE [core].[UserStatusHistory] SET " +
												"[UserID] = @UserID, " + 
												"[UserStatusID] = @UserStatusID, " + 
												"[Note] = @Note, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [UserStatusHistoryID] = @UserStatusHistoryID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				sqlCmd.Parameters.AddWithValue("@UserStatusID", (int)data.UserStatus);
				sqlCmd.Parameters.AddWithValue("@Note", !string.IsNullOrEmpty(data.Note) ? (object)data.Note : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@UserStatusHistoryID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "update", "norecord"), "UserStatusHistory could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserStatusHistory", "Exception while updating UserStatusHistory object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "update", "morerecords"), "UserStatusHistory was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserStatusHistory", "Exception while updating UserStatusHistory object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "update", "exception"), "UserStatusHistory could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "UserStatusHistory", "Exception while updating UserStatusHistory object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, UserStatusHistory data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[UserStatusHistory] WHERE UserStatusHistoryID = @UserStatusHistoryID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserStatusHistoryID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "delete", "norecord"), "UserStatusHistory could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "UserStatusHistory", "Exception while deleting UserStatusHistory object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ush", "delete", "exception"), "UserStatusHistory could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "UserStatusHistory", "Exception while deleting UserStatusHistory object from database. See inner exception for details.", ex);
      }
    }
  }
}

