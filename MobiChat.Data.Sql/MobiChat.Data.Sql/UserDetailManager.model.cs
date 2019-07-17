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
  [DataManager(typeof(UserDetail))] 
  public partial class UserDetailManager : MobiChat.Data.Sql.SqlManagerBase<UserDetail>, IUserDetailManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override UserDetail LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							UserDetailTable.GetColumnNames("[ud]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[ud_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[ud_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + GenderTable.GetColumnNames("[ud_g]") : string.Empty) + 
					" FROM [core].[UserDetail] AS [ud] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [ud_u] ON [ud].[UserID] = [ud_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [ud_u_ut] ON [ud_u].[UserTypeID] = [ud_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Gender] AS [ud_g] ON [ud].[GenderID] = [ud_g].[GenderID] ";
				sqlCmdText += "WHERE [ud].[UserDetailID] = @UserDetailID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserDetailID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "loadinternal", "notfound"), "UserDetail could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserDetailTable udTable = new UserDetailTable(query);
				UserTable ud_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable ud_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				GenderTable ud_gTable = (this.Depth > 0) ? new GenderTable(query) : null;

        
				UserType ud_u_utObject = (this.Depth > 1) ? ud_u_utTable.CreateInstance() : null;
				User ud_uObject = (this.Depth > 0) ? ud_uTable.CreateInstance(ud_u_utObject) : null;
				Gender ud_gObject = (this.Depth > 0) ? ud_gTable.CreateInstance() : null;
				UserDetail udObject = udTable.CreateInstance(ud_uObject, ud_gObject);
				sqlReader.Close();

				return udObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "loadinternal", "exception"), "UserDetail could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserDetail", "Exception while loading UserDetail object from database. See inner exception for details.", ex);
      }
    }

    public UserDetail Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserDetailTable.GetColumnNames("[ud]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[ud_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[ud_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + GenderTable.GetColumnNames("[ud_g]") : string.Empty) +  
					" FROM [core].[UserDetail] AS [ud] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [ud_u] ON [ud].[UserID] = [ud_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [ud_u_ut] ON [ud_u].[UserTypeID] = [ud_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Gender] AS [ud_g] ON [ud].[GenderID] = [ud_g].[GenderID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "customload", "notfound"), "UserDetail could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserDetailTable udTable = new UserDetailTable(query);
				UserTable ud_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable ud_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				GenderTable ud_gTable = (this.Depth > 0) ? new GenderTable(query) : null;

        
				UserType ud_u_utObject = (this.Depth > 1) ? ud_u_utTable.CreateInstance() : null;
				User ud_uObject = (this.Depth > 0) ? ud_uTable.CreateInstance(ud_u_utObject) : null;
				Gender ud_gObject = (this.Depth > 0) ? ud_gTable.CreateInstance() : null;
				UserDetail udObject = udTable.CreateInstance(ud_uObject, ud_gObject);
				sqlReader.Close();

				return udObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "customload", "exception"), "UserDetail could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserDetail", "Exception while loading (custom/single) UserDetail object from database. See inner exception for details.", ex);
      }
    }

    public List<UserDetail> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserDetailTable.GetColumnNames("[ud]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[ud_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[ud_u_ut]") : string.Empty) + 
							(this.Depth > 0 ? "," + GenderTable.GetColumnNames("[ud_g]") : string.Empty) +  
					" FROM [core].[UserDetail] AS [ud] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [ud_u] ON [ud].[UserID] = [ud_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [ud_u_ut] ON [ud_u].[UserTypeID] = [ud_u_ut].[UserTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Gender] AS [ud_g] ON [ud].[GenderID] = [ud_g].[GenderID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "customloadmany", "notfound"), "UserDetail list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<UserDetail>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserDetailTable udTable = new UserDetailTable(query);
				UserTable ud_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable ud_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;
				GenderTable ud_gTable = (this.Depth > 0) ? new GenderTable(query) : null;

        List<UserDetail> result = new List<UserDetail>();
        do
        {
          
					UserType ud_u_utObject = (this.Depth > 1) ? ud_u_utTable.CreateInstance() : null;
					User ud_uObject = (this.Depth > 0) ? ud_uTable.CreateInstance(ud_u_utObject) : null;
					Gender ud_gObject = (this.Depth > 0) ? ud_gTable.CreateInstance() : null;
					UserDetail udObject = (this.Depth > -1) ? udTable.CreateInstance(ud_uObject, ud_gObject) : null;
					result.Add(udObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "customloadmany", "exception"), "UserDetail list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserDetail", "Exception while loading (custom/many) UserDetail object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, UserDetail data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[UserDetail] ([UserID],[CountryID],[GenderID],[FirstName],[LastName],[Address],[Mail],[Contact],[BirthDate]) VALUES(@UserID,@CountryID,@GenderID,@FirstName,@LastName,@Address,@Mail,@Contact,@BirthDate); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.CountryID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@GenderID", data.Gender.ID);
				sqlCmd.Parameters.AddWithValue("@FirstName", data.FirstName).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@LastName", data.LastName).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Address", !string.IsNullOrEmpty(data.Address) ? (object)data.Address : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Mail", data.Mail).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Contact", data.Contact).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@BirthDate", data.BirthDate.HasValue ? (object)data.BirthDate.Value : DBNull.Value).SqlDbType = SqlDbType.DateTime2;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "insert", "noprimarykey"), "UserDetail could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "UserDetail", "Exception while inserting UserDetail object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "insert", "exception"), "UserDetail could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "UserDetail", "Exception while inserting UserDetail object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, UserDetail data)
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
        sqlCmdText = "UPDATE [core].[UserDetail] SET " +
												"[UserID] = @UserID, " + 
												"[CountryID] = @CountryID, " + 
												"[GenderID] = @GenderID, " + 
												"[FirstName] = @FirstName, " + 
												"[LastName] = @LastName, " + 
												"[Address] = @Address, " + 
												"[Mail] = @Mail, " + 
												"[Contact] = @Contact, " + 
												"[BirthDate] = @BirthDate, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [UserDetailID] = @UserDetailID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				sqlCmd.Parameters.AddWithValue("@CountryID", data.CountryID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@GenderID", data.Gender.ID);
				sqlCmd.Parameters.AddWithValue("@FirstName", data.FirstName).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@LastName", data.LastName).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Address", !string.IsNullOrEmpty(data.Address) ? (object)data.Address : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Mail", data.Mail).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Contact", data.Contact).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@BirthDate", data.BirthDate.HasValue ? (object)data.BirthDate.Value : DBNull.Value).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@UserDetailID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "update", "norecord"), "UserDetail could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserDetail", "Exception while updating UserDetail object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "update", "morerecords"), "UserDetail was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserDetail", "Exception while updating UserDetail object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "update", "exception"), "UserDetail could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "UserDetail", "Exception while updating UserDetail object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, UserDetail data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[UserDetail] WHERE UserDetailID = @UserDetailID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserDetailID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "delete", "norecord"), "UserDetail could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "UserDetail", "Exception while deleting UserDetail object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ud", "delete", "exception"), "UserDetail could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "UserDetail", "Exception while deleting UserDetail object from database. See inner exception for details.", ex);
      }
    }
  }
}

