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
  [DataManager(typeof(Application))] 
  public partial class ApplicationManager : MobiChat.Data.Sql.SqlManagerBase<Application>, IApplicationManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Application LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ApplicationTable.GetColumnNames("[a]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[a_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + ApplicationTypeTable.GetColumnNames("[a_at]") : string.Empty) + 
							(this.Depth > 0 ? "," + RuntimeTypeTable.GetColumnNames("[a_rt]") : string.Empty) + 
					" FROM [core].[Application] AS [a] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [a_i] ON [a].[InstanceID] = [a_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [a_at] ON [a].[ApplicationTypeID] = [a_at].[ApplicationTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [a_rt] ON [a].[RuntimeTypeID] = [a_rt].[RuntimeTypeID] ";
				sqlCmdText += "WHERE [a].[ApplicationID] = @ApplicationID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ApplicationID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "loadinternal", "notfound"), "Application could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ApplicationTable aTable = new ApplicationTable(query);
				InstanceTable a_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;
				ApplicationTypeTable a_atTable = (this.Depth > 0) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable a_rtTable = (this.Depth > 0) ? new RuntimeTypeTable(query) : null;

        
				Instance a_iObject = (this.Depth > 0) ? a_iTable.CreateInstance() : null;
				ApplicationType a_atObject = (this.Depth > 0) ? a_atTable.CreateInstance() : null;
				RuntimeType a_rtObject = (this.Depth > 0) ? a_rtTable.CreateInstance() : null;
				Application aObject = aTable.CreateInstance(a_iObject, a_atObject, a_rtObject);
				sqlReader.Close();

				return aObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "loadinternal", "exception"), "Application could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Application", "Exception while loading Application object from database. See inner exception for details.", ex);
      }
    }

    public Application Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ApplicationTable.GetColumnNames("[a]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[a_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + ApplicationTypeTable.GetColumnNames("[a_at]") : string.Empty) + 
							(this.Depth > 0 ? "," + RuntimeTypeTable.GetColumnNames("[a_rt]") : string.Empty) +  
					" FROM [core].[Application] AS [a] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [a_i] ON [a].[InstanceID] = [a_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [a_at] ON [a].[ApplicationTypeID] = [a_at].[ApplicationTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [a_rt] ON [a].[RuntimeTypeID] = [a_rt].[RuntimeTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customload", "notfound"), "Application could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ApplicationTable aTable = new ApplicationTable(query);
				InstanceTable a_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;
				ApplicationTypeTable a_atTable = (this.Depth > 0) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable a_rtTable = (this.Depth > 0) ? new RuntimeTypeTable(query) : null;

        
				Instance a_iObject = (this.Depth > 0) ? a_iTable.CreateInstance() : null;
				ApplicationType a_atObject = (this.Depth > 0) ? a_atTable.CreateInstance() : null;
				RuntimeType a_rtObject = (this.Depth > 0) ? a_rtTable.CreateInstance() : null;
				Application aObject = aTable.CreateInstance(a_iObject, a_atObject, a_rtObject);
				sqlReader.Close();

				return aObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customload", "exception"), "Application could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Application", "Exception while loading (custom/single) Application object from database. See inner exception for details.", ex);
      }
    }

    public List<Application> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ApplicationTable.GetColumnNames("[a]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[a_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + ApplicationTypeTable.GetColumnNames("[a_at]") : string.Empty) + 
							(this.Depth > 0 ? "," + RuntimeTypeTable.GetColumnNames("[a_rt]") : string.Empty) +  
					" FROM [core].[Application] AS [a] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [a_i] ON [a].[InstanceID] = [a_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [a_at] ON [a].[ApplicationTypeID] = [a_at].[ApplicationTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [a_rt] ON [a].[RuntimeTypeID] = [a_rt].[RuntimeTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customloadmany", "notfound"), "Application list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Application>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ApplicationTable aTable = new ApplicationTable(query);
				InstanceTable a_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;
				ApplicationTypeTable a_atTable = (this.Depth > 0) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable a_rtTable = (this.Depth > 0) ? new RuntimeTypeTable(query) : null;

        List<Application> result = new List<Application>();
        do
        {
          
					Instance a_iObject = (this.Depth > 0) ? a_iTable.CreateInstance() : null;
					ApplicationType a_atObject = (this.Depth > 0) ? a_atTable.CreateInstance() : null;
					RuntimeType a_rtObject = (this.Depth > 0) ? a_rtTable.CreateInstance() : null;
					Application aObject = (this.Depth > -1) ? aTable.CreateInstance(a_iObject, a_atObject, a_rtObject) : null;
					result.Add(aObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "customloadmany", "exception"), "Application list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Application", "Exception while loading (custom/many) Application object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Application data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Application] ([InstanceID],[ApplicationTypeID],[RuntimeTypeID],[Name],[Description]) VALUES(@InstanceID,@ApplicationTypeID,@RuntimeTypeID,@Name,@Description); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@ApplicationTypeID", data.ApplicationType.ID);
				sqlCmd.Parameters.AddWithValue("@RuntimeTypeID", data.RuntimeType.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "insert", "noprimarykey"), "Application could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Application", "Exception while inserting Application object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "insert", "exception"), "Application could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Application", "Exception while inserting Application object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Application data)
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
        sqlCmdText = "UPDATE [core].[Application] SET " +
												"[InstanceID] = @InstanceID, " + 
												"[ApplicationTypeID] = @ApplicationTypeID, " + 
												"[RuntimeTypeID] = @RuntimeTypeID, " + 
												"[Name] = @Name, " + 
												"[Description] = @Description, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ApplicationID] = @ApplicationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@ApplicationTypeID", data.ApplicationType.ID);
				sqlCmd.Parameters.AddWithValue("@RuntimeTypeID", data.RuntimeType.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "update", "norecord"), "Application could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Application", "Exception while updating Application object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "update", "morerecords"), "Application was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Application", "Exception while updating Application object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "update", "exception"), "Application could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Application", "Exception while updating Application object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Application data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Application] WHERE ApplicationID = @ApplicationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ApplicationID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "delete", "norecord"), "Application could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Application", "Exception while deleting Application object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("a", "delete", "exception"), "Application could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Application", "Exception while deleting Application object from database. See inner exception for details.", ex);
      }
    }
  }
}

