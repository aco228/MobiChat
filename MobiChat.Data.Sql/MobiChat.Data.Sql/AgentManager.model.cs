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
  [DataManager(typeof(Agent))] 
  public partial class AgentManager : MobiChat.Data.Sql.SqlManagerBase<Agent>, IAgentManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Agent LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							AgentTable.GetColumnNames("[a]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[a_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[a_u_ut]") : string.Empty) + 
					" FROM [core].[Agent] AS [a] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [a_u] ON [a].[UserID] = [a_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [a_u_ut] ON [a_u].[UserTypeID] = [a_u_ut].[UserTypeID] ";
				sqlCmdText += "WHERE [a].[AgentID] = @AgentID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@AgentID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "loadinternal", "notfound"), "Agent could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				AgentTable aTable = new AgentTable(query);
				UserTable a_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable a_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        
				UserType a_u_utObject = (this.Depth > 1) ? a_u_utTable.CreateInstance() : null;
				User a_uObject = (this.Depth > 0) ? a_uTable.CreateInstance(a_u_utObject) : null;
				Agent aObject = aTable.CreateInstance(a_uObject);
				sqlReader.Close();

				return aObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "loadinternal", "exception"), "Agent could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Agent", "Exception while loading Agent object from database. See inner exception for details.", ex);
      }
    }

    public Agent Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							AgentTable.GetColumnNames("[a]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[a_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[a_u_ut]") : string.Empty) +  
					" FROM [core].[Agent] AS [a] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [a_u] ON [a].[UserID] = [a_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [a_u_ut] ON [a_u].[UserTypeID] = [a_u_ut].[UserTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customload", "notfound"), "Agent could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				AgentTable aTable = new AgentTable(query);
				UserTable a_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable a_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        
				UserType a_u_utObject = (this.Depth > 1) ? a_u_utTable.CreateInstance() : null;
				User a_uObject = (this.Depth > 0) ? a_uTable.CreateInstance(a_u_utObject) : null;
				Agent aObject = aTable.CreateInstance(a_uObject);
				sqlReader.Close();

				return aObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customload", "exception"), "Agent could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Agent", "Exception while loading (custom/single) Agent object from database. See inner exception for details.", ex);
      }
    }

    public List<Agent> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							AgentTable.GetColumnNames("[a]") + 
							(this.Depth > 0 ? "," + UserTable.GetColumnNames("[a_u]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTypeTable.GetColumnNames("[a_u_ut]") : string.Empty) +  
					" FROM [core].[Agent] AS [a] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [a_u] ON [a].[UserID] = [a_u].[UserID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[UserType] AS [a_u_ut] ON [a_u].[UserTypeID] = [a_u_ut].[UserTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customloadmany", "notfound"), "Agent list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Agent>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				AgentTable aTable = new AgentTable(query);
				UserTable a_uTable = (this.Depth > 0) ? new UserTable(query) : null;
				UserTypeTable a_u_utTable = (this.Depth > 1) ? new UserTypeTable(query) : null;

        List<Agent> result = new List<Agent>();
        do
        {
          
					UserType a_u_utObject = (this.Depth > 1) ? a_u_utTable.CreateInstance() : null;
					User a_uObject = (this.Depth > 0) ? a_uTable.CreateInstance(a_u_utObject) : null;
					Agent aObject = (this.Depth > -1) ? aTable.CreateInstance(a_uObject) : null;
					result.Add(aObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customloadmany", "exception"), "Agent list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Agent", "Exception while loading (custom/many) Agent object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Agent data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Agent] ([UserID]) VALUES(@UserID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "insert", "noprimarykey"), "Agent could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Agent", "Exception while inserting Agent object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "insert", "exception"), "Agent could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Agent", "Exception while inserting Agent object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Agent data)
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
        sqlCmdText = "UPDATE [core].[Agent] SET " +
												"[UserID] = @UserID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [AgentID] = @AgentID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@UserID", data.User.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@AgentID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "update", "norecord"), "Agent could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Agent", "Exception while updating Agent object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "update", "morerecords"), "Agent was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Agent", "Exception while updating Agent object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "update", "exception"), "Agent could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Agent", "Exception while updating Agent object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Agent data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Agent] WHERE AgentID = @AgentID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@AgentID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "delete", "norecord"), "Agent could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Agent", "Exception while deleting Agent object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "delete", "exception"), "Agent could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Agent", "Exception while deleting Agent object from database. See inner exception for details.", ex);
      }
    }
  }
}

