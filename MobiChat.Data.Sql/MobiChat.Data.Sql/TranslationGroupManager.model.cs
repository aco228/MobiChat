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
  [DataManager(typeof(TranslationGroup))] 
  public partial class TranslationGroupManager : MobiChat.Data.Sql.SqlManagerBase<TranslationGroup>, ITranslationGroupManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override TranslationGroup LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							TranslationGroupTable.GetColumnNames("[tg]") + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[tg_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[tg_t_tt]") : string.Empty) + 
					" FROM [core].[TranslationGroup] AS [tg] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tg_t] ON [tg].[TranslationID] = [tg_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [tg_t_tt] ON [tg_t].[TranslationTypeID] = [tg_t_tt].[TranslationTypeID] ";
				sqlCmdText += "WHERE [tg].[TranslationGroupID] = @TranslationGroupID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationGroupID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "loadinternal", "notfound"), "TranslationGroup could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationGroupTable tgTable = new TranslationGroupTable(query);
				TranslationTable tg_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable tg_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;

        
				TranslationType tg_t_ttObject = (this.Depth > 1) ? tg_t_ttTable.CreateInstance() : null;
				Translation tg_tObject = (this.Depth > 0) ? tg_tTable.CreateInstance(tg_t_ttObject) : null;
				TranslationGroup tgObject = tgTable.CreateInstance(tg_tObject);
				sqlReader.Close();

				return tgObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "loadinternal", "exception"), "TranslationGroup could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationGroup", "Exception while loading TranslationGroup object from database. See inner exception for details.", ex);
      }
    }

    public TranslationGroup Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationGroupTable.GetColumnNames("[tg]") + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[tg_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[tg_t_tt]") : string.Empty) +  
					" FROM [core].[TranslationGroup] AS [tg] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tg_t] ON [tg].[TranslationID] = [tg_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [tg_t_tt] ON [tg_t].[TranslationTypeID] = [tg_t_tt].[TranslationTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "customload", "notfound"), "TranslationGroup could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationGroupTable tgTable = new TranslationGroupTable(query);
				TranslationTable tg_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable tg_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;

        
				TranslationType tg_t_ttObject = (this.Depth > 1) ? tg_t_ttTable.CreateInstance() : null;
				Translation tg_tObject = (this.Depth > 0) ? tg_tTable.CreateInstance(tg_t_ttObject) : null;
				TranslationGroup tgObject = tgTable.CreateInstance(tg_tObject);
				sqlReader.Close();

				return tgObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "customload", "exception"), "TranslationGroup could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationGroup", "Exception while loading (custom/single) TranslationGroup object from database. See inner exception for details.", ex);
      }
    }

    public List<TranslationGroup> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationGroupTable.GetColumnNames("[tg]") + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[tg_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[tg_t_tt]") : string.Empty) +  
					" FROM [core].[TranslationGroup] AS [tg] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tg_t] ON [tg].[TranslationID] = [tg_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [tg_t_tt] ON [tg_t].[TranslationTypeID] = [tg_t_tt].[TranslationTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "customloadmany", "notfound"), "TranslationGroup list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<TranslationGroup>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationGroupTable tgTable = new TranslationGroupTable(query);
				TranslationTable tg_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable tg_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;

        List<TranslationGroup> result = new List<TranslationGroup>();
        do
        {
          
					TranslationType tg_t_ttObject = (this.Depth > 1) ? tg_t_ttTable.CreateInstance() : null;
					Translation tg_tObject = (this.Depth > 0) ? tg_tTable.CreateInstance(tg_t_ttObject) : null;
					TranslationGroup tgObject = (this.Depth > -1) ? tgTable.CreateInstance(tg_tObject) : null;
					result.Add(tgObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "customloadmany", "exception"), "TranslationGroup list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationGroup", "Exception while loading (custom/many) TranslationGroup object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, TranslationGroup data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[TranslationGroup] ([TranslationID],[Name],[Comment]) VALUES(@TranslationID,@Name,@Comment); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.Translation.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Comment", !string.IsNullOrEmpty(data.Comment) ? (object)data.Comment : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "insert", "noprimarykey"), "TranslationGroup could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "TranslationGroup", "Exception while inserting TranslationGroup object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "insert", "exception"), "TranslationGroup could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "TranslationGroup", "Exception while inserting TranslationGroup object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, TranslationGroup data)
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
        sqlCmdText = "UPDATE [core].[TranslationGroup] SET " +
												"[TranslationID] = @TranslationID, " + 
												"[Name] = @Name, " + 
												"[Comment] = @Comment, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [TranslationGroupID] = @TranslationGroupID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.Translation.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Comment", !string.IsNullOrEmpty(data.Comment) ? (object)data.Comment : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@TranslationGroupID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "update", "norecord"), "TranslationGroup could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationGroup", "Exception while updating TranslationGroup object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "update", "morerecords"), "TranslationGroup was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationGroup", "Exception while updating TranslationGroup object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "update", "exception"), "TranslationGroup could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "TranslationGroup", "Exception while updating TranslationGroup object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, TranslationGroup data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[TranslationGroup] WHERE TranslationGroupID = @TranslationGroupID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationGroupID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "delete", "norecord"), "TranslationGroup could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "TranslationGroup", "Exception while deleting TranslationGroup object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tg", "delete", "exception"), "TranslationGroup could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "TranslationGroup", "Exception while deleting TranslationGroup object from database. See inner exception for details.", ex);
      }
    }
  }
}

