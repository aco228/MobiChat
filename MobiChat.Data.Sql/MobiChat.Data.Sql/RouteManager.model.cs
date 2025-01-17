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
  [DataManager(typeof(Route))] 
  public partial class RouteManager : MobiChat.Data.Sql.SqlManagerBase<Route>, IRouteManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Route LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							RouteTable.GetColumnNames("[r]") + 
							(this.Depth > 0 ? "," + RouteSetTable.GetColumnNames("[r_rs]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[r_rs_i]") : string.Empty) + 
					" FROM [core].[Route] AS [r] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [r_rs] ON [r].[RouteSetID] = [r_rs].[RouteSetID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [r_rs_i] ON [r_rs].[InstanceID] = [r_rs_i].[InstanceID] ";
				sqlCmdText += "WHERE [r].[RouteID] = @RouteID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@RouteID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "loadinternal", "notfound"), "Route could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteTable rTable = new RouteTable(query);
				RouteSetTable r_rsTable = (this.Depth > 0) ? new RouteSetTable(query) : null;
				InstanceTable r_rs_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;

        
				Instance r_rs_iObject = (this.Depth > 1) ? r_rs_iTable.CreateInstance() : null;
				RouteSet r_rsObject = (this.Depth > 0) ? r_rsTable.CreateInstance(r_rs_iObject) : null;
				Route rObject = rTable.CreateInstance(r_rsObject);
				sqlReader.Close();

				return rObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "loadinternal", "exception"), "Route could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Route", "Exception while loading Route object from database. See inner exception for details.", ex);
      }
    }

    public Route Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							RouteTable.GetColumnNames("[r]") + 
							(this.Depth > 0 ? "," + RouteSetTable.GetColumnNames("[r_rs]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[r_rs_i]") : string.Empty) +  
					" FROM [core].[Route] AS [r] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [r_rs] ON [r].[RouteSetID] = [r_rs].[RouteSetID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [r_rs_i] ON [r_rs].[InstanceID] = [r_rs_i].[InstanceID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customload", "notfound"), "Route could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteTable rTable = new RouteTable(query);
				RouteSetTable r_rsTable = (this.Depth > 0) ? new RouteSetTable(query) : null;
				InstanceTable r_rs_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;

        
				Instance r_rs_iObject = (this.Depth > 1) ? r_rs_iTable.CreateInstance() : null;
				RouteSet r_rsObject = (this.Depth > 0) ? r_rsTable.CreateInstance(r_rs_iObject) : null;
				Route rObject = rTable.CreateInstance(r_rsObject);
				sqlReader.Close();

				return rObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customload", "exception"), "Route could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Route", "Exception while loading (custom/single) Route object from database. See inner exception for details.", ex);
      }
    }

    public List<Route> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							RouteTable.GetColumnNames("[r]") + 
							(this.Depth > 0 ? "," + RouteSetTable.GetColumnNames("[r_rs]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[r_rs_i]") : string.Empty) +  
					" FROM [core].[Route] AS [r] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [r_rs] ON [r].[RouteSetID] = [r_rs].[RouteSetID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [r_rs_i] ON [r_rs].[InstanceID] = [r_rs_i].[InstanceID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customloadmany", "notfound"), "Route list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Route>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteTable rTable = new RouteTable(query);
				RouteSetTable r_rsTable = (this.Depth > 0) ? new RouteSetTable(query) : null;
				InstanceTable r_rs_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;

        List<Route> result = new List<Route>();
        do
        {
          
					Instance r_rs_iObject = (this.Depth > 1) ? r_rs_iTable.CreateInstance() : null;
					RouteSet r_rsObject = (this.Depth > 0) ? r_rsTable.CreateInstance(r_rs_iObject) : null;
					Route rObject = (this.Depth > -1) ? rTable.CreateInstance(r_rsObject) : null;
					result.Add(rObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customloadmany", "exception"), "Route list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Route", "Exception while loading (custom/many) Route object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Route data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Route] ([RouteSetID],[Name],[Action],[Controller],[Pattern],[IsIgnore],[IsEnabled],[Index],[IsSessionRoute]) VALUES(@RouteSetID,@Name,@Action,@Controller,@Pattern,@IsIgnore,@IsEnabled,@Index,@IsSessionRoute); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@RouteSetID", data.RouteSet.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Action", !string.IsNullOrEmpty(data.Action) ? (object)data.Action : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Controller", !string.IsNullOrEmpty(data.Controller) ? (object)data.Controller : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Pattern", data.Pattern).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsIgnore", data.IsIgnore.HasValue ? (object)data.IsIgnore.Value : DBNull.Value).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@IsEnabled", data.IsEnabled.HasValue ? (object)data.IsEnabled.Value : DBNull.Value).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Index", data.Index).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@IsSessionRoute", data.IsSessionRoute).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "insert", "noprimarykey"), "Route could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Route", "Exception while inserting Route object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "insert", "exception"), "Route could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Route", "Exception while inserting Route object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Route data)
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
        sqlCmdText = "UPDATE [core].[Route] SET " +
												"[RouteSetID] = @RouteSetID, " + 
												"[Name] = @Name, " + 
												"[Action] = @Action, " + 
												"[Controller] = @Controller, " + 
												"[Pattern] = @Pattern, " + 
												"[IsIgnore] = @IsIgnore, " + 
												"[IsEnabled] = @IsEnabled, " + 
												"[Index] = @Index, " + 
												"[IsSessionRoute] = @IsSessionRoute, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [RouteID] = @RouteID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@RouteSetID", data.RouteSet.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Action", !string.IsNullOrEmpty(data.Action) ? (object)data.Action : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Controller", !string.IsNullOrEmpty(data.Controller) ? (object)data.Controller : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Pattern", data.Pattern).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsIgnore", data.IsIgnore.HasValue ? (object)data.IsIgnore.Value : DBNull.Value).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@IsEnabled", data.IsEnabled.HasValue ? (object)data.IsEnabled.Value : DBNull.Value).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Index", data.Index).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@IsSessionRoute", data.IsSessionRoute).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@RouteID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "update", "norecord"), "Route could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Route", "Exception while updating Route object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "update", "morerecords"), "Route was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Route", "Exception while updating Route object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "update", "exception"), "Route could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Route", "Exception while updating Route object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Route data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Route] WHERE RouteID = @RouteID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@RouteID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "delete", "norecord"), "Route could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Route", "Exception while deleting Route object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "delete", "exception"), "Route could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Route", "Exception while deleting Route object from database. See inner exception for details.", ex);
      }
    }
  }
}

