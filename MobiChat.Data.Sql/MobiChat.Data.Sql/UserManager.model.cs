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
  [DataManager(typeof(User))] 
  public partial class UserManager : MobiChat.Data.Sql.SqlManagerBase<User>, IUserManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override User LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							UserTable.GetColumnNames("[u]") + 
							(this.Depth > 0 ? "," + UserTypeTable.GetColumnNames("[u_ut]") : string.Empty) + 
					" FROM [core].[User] AS [u] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [u_ut] ON [u].[UserTypeID] = [u_ut].[UserTypeID] ";
				sqlCmdText += "WHERE [u].[UserID] = @UserID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "loadinternal", "notfound"), "User could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserTable uTable = new UserTable(query);
				UserTypeTable u_utTable = (this.Depth > 0) ? new UserTypeTable(query) : null;

        
				UserType u_utObject = (this.Depth > 0) ? u_utTable.CreateInstance() : null;
				User uObject = uTable.CreateInstance(u_utObject);
				sqlReader.Close();

				return uObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "loadinternal", "exception"), "User could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "User", "Exception while loading User object from database. See inner exception for details.", ex);
      }
    }

    public User Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserTable.GetColumnNames("[u]") + 
							(this.Depth > 0 ? "," + UserTypeTable.GetColumnNames("[u_ut]") : string.Empty) +  
					" FROM [core].[User] AS [u] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [u_ut] ON [u].[UserTypeID] = [u_ut].[UserTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "customload", "notfound"), "User could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserTable uTable = new UserTable(query);
				UserTypeTable u_utTable = (this.Depth > 0) ? new UserTypeTable(query) : null;

        
				UserType u_utObject = (this.Depth > 0) ? u_utTable.CreateInstance() : null;
				User uObject = uTable.CreateInstance(u_utObject);
				sqlReader.Close();

				return uObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "customload", "exception"), "User could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "User", "Exception while loading (custom/single) User object from database. See inner exception for details.", ex);
      }
    }

    public List<User> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserTable.GetColumnNames("[u]") + 
							(this.Depth > 0 ? "," + UserTypeTable.GetColumnNames("[u_ut]") : string.Empty) +  
					" FROM [core].[User] AS [u] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [u_ut] ON [u].[UserTypeID] = [u_ut].[UserTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "customloadmany", "notfound"), "User list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<User>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserTable uTable = new UserTable(query);
				UserTypeTable u_utTable = (this.Depth > 0) ? new UserTypeTable(query) : null;

        List<User> result = new List<User>();
        do
        {
          
					UserType u_utObject = (this.Depth > 0) ? u_utTable.CreateInstance() : null;
					User uObject = (this.Depth > -1) ? uTable.CreateInstance(u_utObject) : null;
					result.Add(uObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "customloadmany", "exception"), "User list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "User", "Exception while loading (custom/many) User object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, User data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[User] ([UserGuid],[UserTypeID],[UserStatusID],[Username],[Password]) VALUES(@UserGuid,@UserTypeID,@UserStatusID,@Username,@Password); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@UserTypeID", data.UserType.ID);
				sqlCmd.Parameters.AddWithValue("@UserStatusID", (int)data.UserStatus);
				sqlCmd.Parameters.AddWithValue("@Username", data.Username).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Password", data.Password).SqlDbType = SqlDbType.VarBinary;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "insert", "noprimarykey"), "User could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "User", "Exception while inserting User object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "insert", "exception"), "User could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "User", "Exception while inserting User object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, User data)
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
        sqlCmdText = "UPDATE [core].[User] SET " +
												"[UserGuid] = @UserGuid, " + 
												"[UserTypeID] = @UserTypeID, " + 
												"[UserStatusID] = @UserStatusID, " + 
												"[Username] = @Username, " + 
												"[Password] = @Password, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [UserID] = @UserID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@UserTypeID", data.UserType.ID);
				sqlCmd.Parameters.AddWithValue("@UserStatusID", (int)data.UserStatus);
				sqlCmd.Parameters.AddWithValue("@Username", data.Username).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Password", data.Password).SqlDbType = SqlDbType.VarBinary;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@UserID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "update", "norecord"), "User could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "User", "Exception while updating User object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "update", "morerecords"), "User was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "User", "Exception while updating User object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "update", "exception"), "User could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "User", "Exception while updating User object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, User data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[User] WHERE UserID = @UserID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "delete", "norecord"), "User could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "User", "Exception while deleting User object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("u", "delete", "exception"), "User could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "User", "Exception while deleting User object from database. See inner exception for details.", ex);
      }
    }
  }
}
