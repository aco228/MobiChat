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
  [DataManager(typeof(RouteSet))] 
  public partial class RouteSetManager : MobiChat.Data.Sql.SqlManagerBase<RouteSet>, IRouteSetManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override RouteSet LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							RouteSetTable.GetColumnNames("[rs]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[rs_i]") : string.Empty) + 
					" FROM [core].[RouteSet] AS [rs] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [rs_i] ON [rs].[InstanceID] = [rs_i].[InstanceID] ";
				sqlCmdText += "WHERE [rs].[RouteSetID] = @RouteSetID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@RouteSetID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "loadinternal", "notfound"), "RouteSet could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteSetTable rsTable = new RouteSetTable(query);
				InstanceTable rs_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        
				Instance rs_iObject = (this.Depth > 0) ? rs_iTable.CreateInstance() : null;
				RouteSet rsObject = rsTable.CreateInstance(rs_iObject);
				sqlReader.Close();

				return rsObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "loadinternal", "exception"), "RouteSet could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "RouteSet", "Exception while loading RouteSet object from database. See inner exception for details.", ex);
      }
    }

    public RouteSet Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							RouteSetTable.GetColumnNames("[rs]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[rs_i]") : string.Empty) +  
					" FROM [core].[RouteSet] AS [rs] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [rs_i] ON [rs].[InstanceID] = [rs_i].[InstanceID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "customload", "notfound"), "RouteSet could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteSetTable rsTable = new RouteSetTable(query);
				InstanceTable rs_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        
				Instance rs_iObject = (this.Depth > 0) ? rs_iTable.CreateInstance() : null;
				RouteSet rsObject = rsTable.CreateInstance(rs_iObject);
				sqlReader.Close();

				return rsObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "customload", "exception"), "RouteSet could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "RouteSet", "Exception while loading (custom/single) RouteSet object from database. See inner exception for details.", ex);
      }
    }

    public List<RouteSet> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							RouteSetTable.GetColumnNames("[rs]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[rs_i]") : string.Empty) +  
					" FROM [core].[RouteSet] AS [rs] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [rs_i] ON [rs].[InstanceID] = [rs_i].[InstanceID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "customloadmany", "notfound"), "RouteSet list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<RouteSet>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				RouteSetTable rsTable = new RouteSetTable(query);
				InstanceTable rs_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        List<RouteSet> result = new List<RouteSet>();
        do
        {
          
					Instance rs_iObject = (this.Depth > 0) ? rs_iTable.CreateInstance() : null;
					RouteSet rsObject = (this.Depth > -1) ? rsTable.CreateInstance(rs_iObject) : null;
					result.Add(rsObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "customloadmany", "exception"), "RouteSet list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "RouteSet", "Exception while loading (custom/many) RouteSet object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, RouteSet data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[RouteSet] ([InstanceID],[Name]) VALUES(@InstanceID,@Name); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "insert", "noprimarykey"), "RouteSet could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "RouteSet", "Exception while inserting RouteSet object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "insert", "exception"), "RouteSet could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "RouteSet", "Exception while inserting RouteSet object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, RouteSet data)
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
        sqlCmdText = "UPDATE [core].[RouteSet] SET " +
												"[InstanceID] = @InstanceID, " + 
												"[Name] = @Name, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [RouteSetID] = @RouteSetID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@RouteSetID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "update", "norecord"), "RouteSet could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "RouteSet", "Exception while updating RouteSet object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "update", "morerecords"), "RouteSet was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "RouteSet", "Exception while updating RouteSet object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "update", "exception"), "RouteSet could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "RouteSet", "Exception while updating RouteSet object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, RouteSet data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[RouteSet] WHERE RouteSetID = @RouteSetID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@RouteSetID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "delete", "norecord"), "RouteSet could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "RouteSet", "Exception while deleting RouteSet object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rs", "delete", "exception"), "RouteSet could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "RouteSet", "Exception while deleting RouteSet object from database. See inner exception for details.", ex);
      }
    }
  }
}

