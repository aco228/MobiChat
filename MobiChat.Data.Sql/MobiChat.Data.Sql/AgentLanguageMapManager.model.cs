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
  [DataManager(typeof(AgentLanguageMap))] 
  public partial class AgentLanguageMapManager : MobiChat.Data.Sql.SqlManagerBase<AgentLanguageMap>, IAgentLanguageMapManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override AgentLanguageMap LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							AgentLanguageMapTable.GetColumnNames("[alm]") + 
							(this.Depth > 0 ? "," + AgentTable.GetColumnNames("[alm_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[alm_a_u]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[alm_l]") : string.Empty) + 
					" FROM [core].[AgentLanguageMap] AS [alm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Agent] AS [alm_a] ON [alm].[AgentID] = [alm_a].[AgentID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [alm_a_u] ON [alm_a].[UserID] = [alm_a_u].[UserID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [alm_l] ON [alm].[LanguageID] = [alm_l].[LanguageID] ";
				sqlCmdText += "WHERE [alm].[AgentLanguageMapID] = @AgentLanguageMapID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@AgentLanguageMapID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "loadinternal", "notfound"), "AgentLanguageMap could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				AgentLanguageMapTable almTable = new AgentLanguageMapTable(query);
				AgentTable alm_aTable = (this.Depth > 0) ? new AgentTable(query) : null;
				UserTable alm_a_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				LanguageTable alm_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;

        
				User alm_a_uObject = (this.Depth > 1) ? alm_a_uTable.CreateInstance() : null;
				Agent alm_aObject = (this.Depth > 0) ? alm_aTable.CreateInstance(alm_a_uObject) : null;
				Language alm_lObject = (this.Depth > 0) ? alm_lTable.CreateInstance() : null;
				AgentLanguageMap almObject = almTable.CreateInstance(alm_aObject, alm_lObject);
				sqlReader.Close();

				return almObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "loadinternal", "exception"), "AgentLanguageMap could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "AgentLanguageMap", "Exception while loading AgentLanguageMap object from database. See inner exception for details.", ex);
      }
    }

    public AgentLanguageMap Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							AgentLanguageMapTable.GetColumnNames("[alm]") + 
							(this.Depth > 0 ? "," + AgentTable.GetColumnNames("[alm_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[alm_a_u]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[alm_l]") : string.Empty) +  
					" FROM [core].[AgentLanguageMap] AS [alm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Agent] AS [alm_a] ON [alm].[AgentID] = [alm_a].[AgentID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [alm_a_u] ON [alm_a].[UserID] = [alm_a_u].[UserID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [alm_l] ON [alm].[LanguageID] = [alm_l].[LanguageID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "customload", "notfound"), "AgentLanguageMap could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				AgentLanguageMapTable almTable = new AgentLanguageMapTable(query);
				AgentTable alm_aTable = (this.Depth > 0) ? new AgentTable(query) : null;
				UserTable alm_a_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				LanguageTable alm_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;

        
				User alm_a_uObject = (this.Depth > 1) ? alm_a_uTable.CreateInstance() : null;
				Agent alm_aObject = (this.Depth > 0) ? alm_aTable.CreateInstance(alm_a_uObject) : null;
				Language alm_lObject = (this.Depth > 0) ? alm_lTable.CreateInstance() : null;
				AgentLanguageMap almObject = almTable.CreateInstance(alm_aObject, alm_lObject);
				sqlReader.Close();

				return almObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "customload", "exception"), "AgentLanguageMap could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "AgentLanguageMap", "Exception while loading (custom/single) AgentLanguageMap object from database. See inner exception for details.", ex);
      }
    }

    public List<AgentLanguageMap> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							AgentLanguageMapTable.GetColumnNames("[alm]") + 
							(this.Depth > 0 ? "," + AgentTable.GetColumnNames("[alm_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + UserTable.GetColumnNames("[alm_a_u]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[alm_l]") : string.Empty) +  
					" FROM [core].[AgentLanguageMap] AS [alm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Agent] AS [alm_a] ON [alm].[AgentID] = [alm_a].[AgentID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[User] AS [alm_a_u] ON [alm_a].[UserID] = [alm_a_u].[UserID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [alm_l] ON [alm].[LanguageID] = [alm_l].[LanguageID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "customloadmany", "notfound"), "AgentLanguageMap list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<AgentLanguageMap>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				AgentLanguageMapTable almTable = new AgentLanguageMapTable(query);
				AgentTable alm_aTable = (this.Depth > 0) ? new AgentTable(query) : null;
				UserTable alm_a_uTable = (this.Depth > 1) ? new UserTable(query) : null;
				LanguageTable alm_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;

        List<AgentLanguageMap> result = new List<AgentLanguageMap>();
        do
        {
          
					User alm_a_uObject = (this.Depth > 1) ? alm_a_uTable.CreateInstance() : null;
					Agent alm_aObject = (this.Depth > 0) ? alm_aTable.CreateInstance(alm_a_uObject) : null;
					Language alm_lObject = (this.Depth > 0) ? alm_lTable.CreateInstance() : null;
					AgentLanguageMap almObject = (this.Depth > -1) ? almTable.CreateInstance(alm_aObject, alm_lObject) : null;
					result.Add(almObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "customloadmany", "exception"), "AgentLanguageMap list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "AgentLanguageMap", "Exception while loading (custom/many) AgentLanguageMap object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, AgentLanguageMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[AgentLanguageMap] ([AgentID],[LanguageID],[IsActive]) VALUES(@AgentID,@LanguageID,@IsActive); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@AgentID", data.Agent.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "insert", "noprimarykey"), "AgentLanguageMap could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "AgentLanguageMap", "Exception while inserting AgentLanguageMap object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "insert", "exception"), "AgentLanguageMap could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "AgentLanguageMap", "Exception while inserting AgentLanguageMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, AgentLanguageMap data)
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
        sqlCmdText = "UPDATE [core].[AgentLanguageMap] SET " +
												"[AgentID] = @AgentID, " + 
												"[LanguageID] = @LanguageID, " + 
												"[IsActive] = @IsActive, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [AgentLanguageMapID] = @AgentLanguageMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@AgentID", data.Agent.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@AgentLanguageMapID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "update", "norecord"), "AgentLanguageMap could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "AgentLanguageMap", "Exception while updating AgentLanguageMap object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "update", "morerecords"), "AgentLanguageMap was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "AgentLanguageMap", "Exception while updating AgentLanguageMap object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "update", "exception"), "AgentLanguageMap could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "AgentLanguageMap", "Exception while updating AgentLanguageMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, AgentLanguageMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[AgentLanguageMap] WHERE AgentLanguageMapID = @AgentLanguageMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@AgentLanguageMapID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "delete", "norecord"), "AgentLanguageMap could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "AgentLanguageMap", "Exception while deleting AgentLanguageMap object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("alm", "delete", "exception"), "AgentLanguageMap could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "AgentLanguageMap", "Exception while deleting AgentLanguageMap object from database. See inner exception for details.", ex);
      }
    }
  }
}

