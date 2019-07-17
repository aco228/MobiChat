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
  [DataManager(typeof(ActionContext))] 
  public partial class ActionContextManager : MobiChat.Data.Sql.SqlManagerBase<ActionContext>, IActionContextManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ActionContext LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ActionContextTable.GetColumnNames("[ac]") + 
							(this.Depth > 0 ? "," + ActionContextGroupTable.GetColumnNames("[ac_acg]") : string.Empty) + 
					" FROM [core].[ActionContext] AS [ac] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ActionContextGroup] AS [ac_acg] ON [ac].[ActionContextGroupID] = [ac_acg].[ActionContextGroupID] ";
				sqlCmdText += "WHERE [ac].[ActionContextID] = @ActionContextID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ActionContextID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "loadinternal", "notfound"), "ActionContext could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ActionContextTable acTable = new ActionContextTable(query);
				ActionContextGroupTable ac_acgTable = (this.Depth > 0) ? new ActionContextGroupTable(query) : null;

        
				ActionContextGroup ac_acgObject = (this.Depth > 0) ? ac_acgTable.CreateInstance() : null;
				ActionContext acObject = acTable.CreateInstance(ac_acgObject);
				sqlReader.Close();

				return acObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "loadinternal", "exception"), "ActionContext could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ActionContext", "Exception while loading ActionContext object from database. See inner exception for details.", ex);
      }
    }

    public ActionContext Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ActionContextTable.GetColumnNames("[ac]") + 
							(this.Depth > 0 ? "," + ActionContextGroupTable.GetColumnNames("[ac_acg]") : string.Empty) +  
					" FROM [core].[ActionContext] AS [ac] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ActionContextGroup] AS [ac_acg] ON [ac].[ActionContextGroupID] = [ac_acg].[ActionContextGroupID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "customload", "notfound"), "ActionContext could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ActionContextTable acTable = new ActionContextTable(query);
				ActionContextGroupTable ac_acgTable = (this.Depth > 0) ? new ActionContextGroupTable(query) : null;

        
				ActionContextGroup ac_acgObject = (this.Depth > 0) ? ac_acgTable.CreateInstance() : null;
				ActionContext acObject = acTable.CreateInstance(ac_acgObject);
				sqlReader.Close();

				return acObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "customload", "exception"), "ActionContext could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ActionContext", "Exception while loading (custom/single) ActionContext object from database. See inner exception for details.", ex);
      }
    }

    public List<ActionContext> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ActionContextTable.GetColumnNames("[ac]") + 
							(this.Depth > 0 ? "," + ActionContextGroupTable.GetColumnNames("[ac_acg]") : string.Empty) +  
					" FROM [core].[ActionContext] AS [ac] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ActionContextGroup] AS [ac_acg] ON [ac].[ActionContextGroupID] = [ac_acg].[ActionContextGroupID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "customloadmany", "notfound"), "ActionContext list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ActionContext>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ActionContextTable acTable = new ActionContextTable(query);
				ActionContextGroupTable ac_acgTable = (this.Depth > 0) ? new ActionContextGroupTable(query) : null;

        List<ActionContext> result = new List<ActionContext>();
        do
        {
          
					ActionContextGroup ac_acgObject = (this.Depth > 0) ? ac_acgTable.CreateInstance() : null;
					ActionContext acObject = (this.Depth > -1) ? acTable.CreateInstance(ac_acgObject) : null;
					result.Add(acObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "customloadmany", "exception"), "ActionContext list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ActionContext", "Exception while loading (custom/many) ActionContext object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ActionContext data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ActionContext] ([ActionContextGroupID]) VALUES(@ActionContextGroupID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ActionContextGroupID", data.ActionContextGroup.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "insert", "noprimarykey"), "ActionContext could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ActionContext", "Exception while inserting ActionContext object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "insert", "exception"), "ActionContext could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ActionContext", "Exception while inserting ActionContext object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ActionContext data)
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
        sqlCmdText = "UPDATE [core].[ActionContext] SET " +
												"[ActionContextGroupID] = @ActionContextGroupID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ActionContextID] = @ActionContextID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ActionContextGroupID", data.ActionContextGroup.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ActionContextID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "update", "norecord"), "ActionContext could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ActionContext", "Exception while updating ActionContext object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "update", "morerecords"), "ActionContext was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ActionContext", "Exception while updating ActionContext object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "update", "exception"), "ActionContext could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ActionContext", "Exception while updating ActionContext object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ActionContext data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ActionContext] WHERE ActionContextID = @ActionContextID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ActionContextID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "delete", "norecord"), "ActionContext could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ActionContext", "Exception while deleting ActionContext object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ac", "delete", "exception"), "ActionContext could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ActionContext", "Exception while deleting ActionContext object from database. See inner exception for details.", ex);
      }
    }
  }
}

