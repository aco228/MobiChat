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
  [DataManager(typeof(UserSessionType))] 
  public partial class UserSessionTypeManager : MobiChat.Data.Sql.SqlManagerBase<UserSessionType>, IUserSessionTypeManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override UserSessionType LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							UserSessionTypeTable.GetColumnNames("[ust]") + 
					" FROM [core].[UserSessionType] AS [ust] ";
				sqlCmdText += "WHERE [ust].[UserSessionTypeID] = @UserSessionTypeID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "loadinternal", "notfound"), "UserSessionType could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserSessionTypeTable ustTable = new UserSessionTypeTable(query);

        
				UserSessionType ustObject = ustTable.CreateInstance();
				sqlReader.Close();

				return ustObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "loadinternal", "exception"), "UserSessionType could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserSessionType", "Exception while loading UserSessionType object from database. See inner exception for details.", ex);
      }
    }

    public UserSessionType Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserSessionTypeTable.GetColumnNames("[ust]")  + 
					" FROM [core].[UserSessionType] AS [ust] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "customload", "notfound"), "UserSessionType could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserSessionTypeTable ustTable = new UserSessionTypeTable(query);

        
				UserSessionType ustObject = ustTable.CreateInstance();
				sqlReader.Close();

				return ustObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "customload", "exception"), "UserSessionType could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserSessionType", "Exception while loading (custom/single) UserSessionType object from database. See inner exception for details.", ex);
      }
    }

    public List<UserSessionType> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							UserSessionTypeTable.GetColumnNames("[ust]")  + 
					" FROM [core].[UserSessionType] AS [ust] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "customloadmany", "notfound"), "UserSessionType list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<UserSessionType>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				UserSessionTypeTable ustTable = new UserSessionTypeTable(query);

        List<UserSessionType> result = new List<UserSessionType>();
        do
        {
          
					UserSessionType ustObject = (this.Depth > -1) ? ustTable.CreateInstance() : null;
					result.Add(ustObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "customloadmany", "exception"), "UserSessionType list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "UserSessionType", "Exception while loading (custom/many) UserSessionType object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, UserSessionType data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[UserSessionType] ([Name],[TypeName]) VALUES(@Name,@TypeName); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@TypeName", data.TypeName).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "insert", "noprimarykey"), "UserSessionType could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "UserSessionType", "Exception while inserting UserSessionType object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "insert", "exception"), "UserSessionType could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "UserSessionType", "Exception while inserting UserSessionType object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, UserSessionType data)
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
        sqlCmdText = "UPDATE [core].[UserSessionType] SET " +
												"[Name] = @Name, " + 
												"[TypeName] = @TypeName, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [UserSessionTypeID] = @UserSessionTypeID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@TypeName", data.TypeName).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "update", "norecord"), "UserSessionType could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserSessionType", "Exception while updating UserSessionType object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "update", "morerecords"), "UserSessionType was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "UserSessionType", "Exception while updating UserSessionType object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "update", "exception"), "UserSessionType could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "UserSessionType", "Exception while updating UserSessionType object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, UserSessionType data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[UserSessionType] WHERE UserSessionTypeID = @UserSessionTypeID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@UserSessionTypeID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "delete", "norecord"), "UserSessionType could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "UserSessionType", "Exception while deleting UserSessionType object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ust", "delete", "exception"), "UserSessionType could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "UserSessionType", "Exception while deleting UserSessionType object from database. See inner exception for details.", ex);
      }
    }
  }
}

