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
  [DataManager(typeof(RouteParameter))] 
  public partial class RouteParameterManager : MobiChat.Data.Sql.SqlManagerBase<RouteParameter>, IRouteParameterManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override RouteParameter LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							RouteParameterTable.GetColumnNames("[rp]") + 
							(this.Depth > 0 ? "," + RouteTable.GetColumnNames("[rp_r]") : string.Empty) + 
							(this.Depth > 1 ? "," + RouteSetTable.GetColumnNames("[rp_r_rs]") : string.Empty) + 
					" FROM [core].[RouteParameter] AS [rp] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Route] AS [rp_r] ON [rp].[RouteID] = [rp_r].[RouteID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [rp_r_rs] ON [rp_r].[RouteSetID] = [rp_r_rs].[RouteSetID] ";
				sqlCmdText += "WHERE [rp].[RouteParameterID] = @RouteParameterID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@RouteParameterID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "loadinternal", "notfound"), "RouteParameter could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteParameterTable rpTable = new RouteParameterTable(query);
				RouteTable rp_rTable = (this.Depth > 0) ? new RouteTable(query) : null;
				RouteSetTable rp_r_rsTable = (this.Depth > 1) ? new RouteSetTable(query) : null;

        
				RouteSet rp_r_rsObject = (this.Depth > 1) ? rp_r_rsTable.CreateInstance() : null;
				Route rp_rObject = (this.Depth > 0) ? rp_rTable.CreateInstance(rp_r_rsObject) : null;
				RouteParameter rpObject = rpTable.CreateInstance(rp_rObject);
				sqlReader.Close();

				return rpObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "loadinternal", "exception"), "RouteParameter could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "RouteParameter", "Exception while loading RouteParameter object from database. See inner exception for details.", ex);
      }
    }

    public RouteParameter Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							RouteParameterTable.GetColumnNames("[rp]") + 
							(this.Depth > 0 ? "," + RouteTable.GetColumnNames("[rp_r]") : string.Empty) + 
							(this.Depth > 1 ? "," + RouteSetTable.GetColumnNames("[rp_r_rs]") : string.Empty) +  
					" FROM [core].[RouteParameter] AS [rp] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Route] AS [rp_r] ON [rp].[RouteID] = [rp_r].[RouteID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [rp_r_rs] ON [rp_r].[RouteSetID] = [rp_r_rs].[RouteSetID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "customload", "notfound"), "RouteParameter could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteParameterTable rpTable = new RouteParameterTable(query);
				RouteTable rp_rTable = (this.Depth > 0) ? new RouteTable(query) : null;
				RouteSetTable rp_r_rsTable = (this.Depth > 1) ? new RouteSetTable(query) : null;

        
				RouteSet rp_r_rsObject = (this.Depth > 1) ? rp_r_rsTable.CreateInstance() : null;
				Route rp_rObject = (this.Depth > 0) ? rp_rTable.CreateInstance(rp_r_rsObject) : null;
				RouteParameter rpObject = rpTable.CreateInstance(rp_rObject);
				sqlReader.Close();

				return rpObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "customload", "exception"), "RouteParameter could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "RouteParameter", "Exception while loading (custom/single) RouteParameter object from database. See inner exception for details.", ex);
      }
    }

    public List<RouteParameter> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							RouteParameterTable.GetColumnNames("[rp]") + 
							(this.Depth > 0 ? "," + RouteTable.GetColumnNames("[rp_r]") : string.Empty) + 
							(this.Depth > 1 ? "," + RouteSetTable.GetColumnNames("[rp_r_rs]") : string.Empty) +  
					" FROM [core].[RouteParameter] AS [rp] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Route] AS [rp_r] ON [rp].[RouteID] = [rp_r].[RouteID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RouteSet] AS [rp_r_rs] ON [rp_r].[RouteSetID] = [rp_r_rs].[RouteSetID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "customloadmany", "notfound"), "RouteParameter list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<RouteParameter>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteParameterTable rpTable = new RouteParameterTable(query);
				RouteTable rp_rTable = (this.Depth > 0) ? new RouteTable(query) : null;
				RouteSetTable rp_r_rsTable = (this.Depth > 1) ? new RouteSetTable(query) : null;

        List<RouteParameter> result = new List<RouteParameter>();
        do
        {
          
					RouteSet rp_r_rsObject = (this.Depth > 1) ? rp_r_rsTable.CreateInstance() : null;
					Route rp_rObject = (this.Depth > 0) ? rp_rTable.CreateInstance(rp_r_rsObject) : null;
					RouteParameter rpObject = (this.Depth > -1) ? rpTable.CreateInstance(rp_rObject) : null;
					result.Add(rpObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "customloadmany", "exception"), "RouteParameter list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "RouteParameter", "Exception while loading (custom/many) RouteParameter object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, RouteParameter data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[RouteParameter] ([RouteID],[Key],[Value],[Constraint],[IsOptional]) VALUES(@RouteID,@Key,@Value,@Constraint,@IsOptional); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@RouteID", data.Route.ID);
				sqlCmd.Parameters.AddWithValue("@Key", data.Key).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Value", !string.IsNullOrEmpty(data.Value) ? (object)data.Value : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Constraint", !string.IsNullOrEmpty(data.Constraint) ? (object)data.Constraint : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsOptional", data.IsOptional).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "insert", "noprimarykey"), "RouteParameter could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "RouteParameter", "Exception while inserting RouteParameter object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "insert", "exception"), "RouteParameter could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "RouteParameter", "Exception while inserting RouteParameter object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, RouteParameter data)
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
        sqlCmdText = "UPDATE [core].[RouteParameter] SET " +
												"[RouteID] = @RouteID, " + 
												"[Key] = @Key, " + 
												"[Value] = @Value, " + 
												"[Constraint] = @Constraint, " + 
												"[IsOptional] = @IsOptional, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [RouteParameterID] = @RouteParameterID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@RouteID", data.Route.ID);
				sqlCmd.Parameters.AddWithValue("@Key", data.Key).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Value", !string.IsNullOrEmpty(data.Value) ? (object)data.Value : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Constraint", !string.IsNullOrEmpty(data.Constraint) ? (object)data.Constraint : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsOptional", data.IsOptional).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@RouteParameterID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "update", "norecord"), "RouteParameter could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "RouteParameter", "Exception while updating RouteParameter object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "update", "morerecords"), "RouteParameter was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "RouteParameter", "Exception while updating RouteParameter object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "update", "exception"), "RouteParameter could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "RouteParameter", "Exception while updating RouteParameter object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, RouteParameter data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[RouteParameter] WHERE RouteParameterID = @RouteParameterID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@RouteParameterID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "delete", "norecord"), "RouteParameter could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "RouteParameter", "Exception while deleting RouteParameter object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rp", "delete", "exception"), "RouteParameter could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "RouteParameter", "Exception while deleting RouteParameter object from database. See inner exception for details.", ex);
      }
    }
  }
}

