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
  [DataManager(typeof(TranslationGroupKey))] 
  public partial class TranslationGroupKeyManager : MobiChat.Data.Sql.SqlManagerBase<TranslationGroupKey>, ITranslationGroupKeyManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override TranslationGroupKey LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							TranslationGroupKeyTable.GetColumnNames("[tgk]") + 
							(this.Depth > 0 ? "," + TranslationGroupTable.GetColumnNames("[tgk_tg]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tgk_tg_t]") : string.Empty) + 
					" FROM [core].[TranslationGroupKey] AS [tgk] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroup] AS [tgk_tg] ON [tgk].[TranslationGroupID] = [tgk_tg].[TranslationGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tgk_tg_t] ON [tgk_tg].[TranslationID] = [tgk_tg_t].[TranslationID] ";
				sqlCmdText += "WHERE [tgk].[TranslationGroupKeyID] = @TranslationGroupKeyID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationGroupKeyID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "loadinternal", "notfound"), "TranslationGroupKey could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationGroupKeyTable tgkTable = new TranslationGroupKeyTable(query);
				TranslationGroupTable tgk_tgTable = (this.Depth > 0) ? new TranslationGroupTable(query) : null;
				TranslationTable tgk_tg_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;

        
				Translation tgk_tg_tObject = (this.Depth > 1) ? tgk_tg_tTable.CreateInstance() : null;
				TranslationGroup tgk_tgObject = (this.Depth > 0) ? tgk_tgTable.CreateInstance(tgk_tg_tObject) : null;
				TranslationGroupKey tgkObject = tgkTable.CreateInstance(tgk_tgObject);
				sqlReader.Close();

				return tgkObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "loadinternal", "exception"), "TranslationGroupKey could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationGroupKey", "Exception while loading TranslationGroupKey object from database. See inner exception for details.", ex);
      }
    }

    public TranslationGroupKey Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationGroupKeyTable.GetColumnNames("[tgk]") + 
							(this.Depth > 0 ? "," + TranslationGroupTable.GetColumnNames("[tgk_tg]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tgk_tg_t]") : string.Empty) +  
					" FROM [core].[TranslationGroupKey] AS [tgk] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroup] AS [tgk_tg] ON [tgk].[TranslationGroupID] = [tgk_tg].[TranslationGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tgk_tg_t] ON [tgk_tg].[TranslationID] = [tgk_tg_t].[TranslationID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "customload", "notfound"), "TranslationGroupKey could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationGroupKeyTable tgkTable = new TranslationGroupKeyTable(query);
				TranslationGroupTable tgk_tgTable = (this.Depth > 0) ? new TranslationGroupTable(query) : null;
				TranslationTable tgk_tg_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;

        
				Translation tgk_tg_tObject = (this.Depth > 1) ? tgk_tg_tTable.CreateInstance() : null;
				TranslationGroup tgk_tgObject = (this.Depth > 0) ? tgk_tgTable.CreateInstance(tgk_tg_tObject) : null;
				TranslationGroupKey tgkObject = tgkTable.CreateInstance(tgk_tgObject);
				sqlReader.Close();

				return tgkObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "customload", "exception"), "TranslationGroupKey could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationGroupKey", "Exception while loading (custom/single) TranslationGroupKey object from database. See inner exception for details.", ex);
      }
    }

    public List<TranslationGroupKey> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationGroupKeyTable.GetColumnNames("[tgk]") + 
							(this.Depth > 0 ? "," + TranslationGroupTable.GetColumnNames("[tgk_tg]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tgk_tg_t]") : string.Empty) +  
					" FROM [core].[TranslationGroupKey] AS [tgk] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroup] AS [tgk_tg] ON [tgk].[TranslationGroupID] = [tgk_tg].[TranslationGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tgk_tg_t] ON [tgk_tg].[TranslationID] = [tgk_tg_t].[TranslationID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "customloadmany", "notfound"), "TranslationGroupKey list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<TranslationGroupKey>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationGroupKeyTable tgkTable = new TranslationGroupKeyTable(query);
				TranslationGroupTable tgk_tgTable = (this.Depth > 0) ? new TranslationGroupTable(query) : null;
				TranslationTable tgk_tg_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;

        List<TranslationGroupKey> result = new List<TranslationGroupKey>();
        do
        {
          
					Translation tgk_tg_tObject = (this.Depth > 1) ? tgk_tg_tTable.CreateInstance() : null;
					TranslationGroup tgk_tgObject = (this.Depth > 0) ? tgk_tgTable.CreateInstance(tgk_tg_tObject) : null;
					TranslationGroupKey tgkObject = (this.Depth > -1) ? tgkTable.CreateInstance(tgk_tgObject) : null;
					result.Add(tgkObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "customloadmany", "exception"), "TranslationGroupKey list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationGroupKey", "Exception while loading (custom/many) TranslationGroupKey object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, TranslationGroupKey data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[TranslationGroupKey] ([TranslationGroupID],[Name],[Comment]) VALUES(@TranslationGroupID,@Name,@Comment); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationGroupID", data.TranslationGroup.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Comment", !string.IsNullOrEmpty(data.Comment) ? (object)data.Comment : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "insert", "noprimarykey"), "TranslationGroupKey could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "TranslationGroupKey", "Exception while inserting TranslationGroupKey object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "insert", "exception"), "TranslationGroupKey could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "TranslationGroupKey", "Exception while inserting TranslationGroupKey object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, TranslationGroupKey data)
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
        sqlCmdText = "UPDATE [core].[TranslationGroupKey] SET " +
												"[TranslationGroupID] = @TranslationGroupID, " + 
												"[Name] = @Name, " + 
												"[Comment] = @Comment, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [TranslationGroupKeyID] = @TranslationGroupKeyID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationGroupID", data.TranslationGroup.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Comment", !string.IsNullOrEmpty(data.Comment) ? (object)data.Comment : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@TranslationGroupKeyID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "update", "norecord"), "TranslationGroupKey could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationGroupKey", "Exception while updating TranslationGroupKey object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "update", "morerecords"), "TranslationGroupKey was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationGroupKey", "Exception while updating TranslationGroupKey object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "update", "exception"), "TranslationGroupKey could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "TranslationGroupKey", "Exception while updating TranslationGroupKey object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, TranslationGroupKey data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[TranslationGroupKey] WHERE TranslationGroupKeyID = @TranslationGroupKeyID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationGroupKeyID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "delete", "norecord"), "TranslationGroupKey could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "TranslationGroupKey", "Exception while deleting TranslationGroupKey object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tgk", "delete", "exception"), "TranslationGroupKey could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "TranslationGroupKey", "Exception while deleting TranslationGroupKey object from database. See inner exception for details.", ex);
      }
    }
  }
}

