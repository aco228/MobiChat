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
  [DataManager(typeof(TranslationValue))] 
  public partial class TranslationValueManager : MobiChat.Data.Sql.SqlManagerBase<TranslationValue>, ITranslationValueManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override TranslationValue LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							TranslationValueTable.GetColumnNames("[tv]") + 
							(this.Depth > 0 ? "," + TranslationKeyTable.GetColumnNames("[tv_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationKeyTable.GetColumnNames("[tv_tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tv_tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tv_tk_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[tv_tk_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationGroupKeyTable.GetColumnNames("[tv_tgk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationGroupTable.GetColumnNames("[tv_tgk_tg]") : string.Empty) + 
					" FROM [core].[TranslationValue] AS [tv] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationKey] AS [tv_tk] ON [tv].[TranslationKeyID] = [tv_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tv_tk_tk] ON [tv_tk].[FallbackTranslationKeyID] = [tv_tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tv_tk_t] ON [tv_tk].[TranslationID] = [tv_tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tv_tk_l] ON [tv_tk].[LanguageID] = [tv_tk_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tv_tk_s] ON [tv_tk].[ServiceID] = [tv_tk_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroupKey] AS [tv_tgk] ON [tv].[TranslationGroupKeyID] = [tv_tgk].[TranslationGroupKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroup] AS [tv_tgk_tg] ON [tv_tgk].[TranslationGroupID] = [tv_tgk_tg].[TranslationGroupID] ";
				sqlCmdText += "WHERE [tv].[TranslationValueID] = @TranslationValueID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationValueID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "loadinternal", "notfound"), "TranslationValue could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationValueTable tvTable = new TranslationValueTable(query);
				TranslationKeyTable tv_tkTable = (this.Depth > 0) ? new TranslationKeyTable(query) : null;
				TranslationKeyTable tv_tk_tkTable = (this.Depth > 1) ? new TranslationKeyTable(query) : null;
				TranslationTable tv_tk_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;
				LanguageTable tv_tk_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceTable tv_tk_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				TranslationGroupKeyTable tv_tgkTable = (this.Depth > 0) ? new TranslationGroupKeyTable(query) : null;
				TranslationGroupTable tv_tgk_tgTable = (this.Depth > 1) ? new TranslationGroupTable(query) : null;

        
				TranslationKey tv_tk_tkObject = (this.Depth > 1) ? tv_tk_tkTable.CreateInstance() : null;
				Translation tv_tk_tObject = (this.Depth > 1) ? tv_tk_tTable.CreateInstance() : null;
				Language tv_tk_lObject = (this.Depth > 1) ? tv_tk_lTable.CreateInstance() : null;
				Service tv_tk_sObject = (this.Depth > 1) ? tv_tk_sTable.CreateInstance() : null;
				TranslationKey tv_tkObject = (this.Depth > 0) ? tv_tkTable.CreateInstance(tv_tk_tkObject, tv_tk_tObject, tv_tk_lObject, tv_tk_sObject) : null;
				TranslationGroup tv_tgk_tgObject = (this.Depth > 1) ? tv_tgk_tgTable.CreateInstance() : null;
				TranslationGroupKey tv_tgkObject = (this.Depth > 0) ? tv_tgkTable.CreateInstance(tv_tgk_tgObject) : null;
				TranslationValue tvObject = tvTable.CreateInstance(tv_tkObject, tv_tgkObject);
				sqlReader.Close();

				return tvObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "loadinternal", "exception"), "TranslationValue could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationValue", "Exception while loading TranslationValue object from database. See inner exception for details.", ex);
      }
    }

    public TranslationValue Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationValueTable.GetColumnNames("[tv]") + 
							(this.Depth > 0 ? "," + TranslationKeyTable.GetColumnNames("[tv_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationKeyTable.GetColumnNames("[tv_tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tv_tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tv_tk_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[tv_tk_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationGroupKeyTable.GetColumnNames("[tv_tgk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationGroupTable.GetColumnNames("[tv_tgk_tg]") : string.Empty) +  
					" FROM [core].[TranslationValue] AS [tv] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationKey] AS [tv_tk] ON [tv].[TranslationKeyID] = [tv_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tv_tk_tk] ON [tv_tk].[FallbackTranslationKeyID] = [tv_tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tv_tk_t] ON [tv_tk].[TranslationID] = [tv_tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tv_tk_l] ON [tv_tk].[LanguageID] = [tv_tk_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tv_tk_s] ON [tv_tk].[ServiceID] = [tv_tk_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroupKey] AS [tv_tgk] ON [tv].[TranslationGroupKeyID] = [tv_tgk].[TranslationGroupKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroup] AS [tv_tgk_tg] ON [tv_tgk].[TranslationGroupID] = [tv_tgk_tg].[TranslationGroupID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "customload", "notfound"), "TranslationValue could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationValueTable tvTable = new TranslationValueTable(query);
				TranslationKeyTable tv_tkTable = (this.Depth > 0) ? new TranslationKeyTable(query) : null;
				TranslationKeyTable tv_tk_tkTable = (this.Depth > 1) ? new TranslationKeyTable(query) : null;
				TranslationTable tv_tk_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;
				LanguageTable tv_tk_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceTable tv_tk_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				TranslationGroupKeyTable tv_tgkTable = (this.Depth > 0) ? new TranslationGroupKeyTable(query) : null;
				TranslationGroupTable tv_tgk_tgTable = (this.Depth > 1) ? new TranslationGroupTable(query) : null;

        
				TranslationKey tv_tk_tkObject = (this.Depth > 1) ? tv_tk_tkTable.CreateInstance() : null;
				Translation tv_tk_tObject = (this.Depth > 1) ? tv_tk_tTable.CreateInstance() : null;
				Language tv_tk_lObject = (this.Depth > 1) ? tv_tk_lTable.CreateInstance() : null;
				Service tv_tk_sObject = (this.Depth > 1) ? tv_tk_sTable.CreateInstance() : null;
				TranslationKey tv_tkObject = (this.Depth > 0) ? tv_tkTable.CreateInstance(tv_tk_tkObject, tv_tk_tObject, tv_tk_lObject, tv_tk_sObject) : null;
				TranslationGroup tv_tgk_tgObject = (this.Depth > 1) ? tv_tgk_tgTable.CreateInstance() : null;
				TranslationGroupKey tv_tgkObject = (this.Depth > 0) ? tv_tgkTable.CreateInstance(tv_tgk_tgObject) : null;
				TranslationValue tvObject = tvTable.CreateInstance(tv_tkObject, tv_tgkObject);
				sqlReader.Close();

				return tvObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "customload", "exception"), "TranslationValue could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationValue", "Exception while loading (custom/single) TranslationValue object from database. See inner exception for details.", ex);
      }
    }

    public List<TranslationValue> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationValueTable.GetColumnNames("[tv]") + 
							(this.Depth > 0 ? "," + TranslationKeyTable.GetColumnNames("[tv_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationKeyTable.GetColumnNames("[tv_tk_tk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTable.GetColumnNames("[tv_tk_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[tv_tk_l]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[tv_tk_s]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationGroupKeyTable.GetColumnNames("[tv_tgk]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationGroupTable.GetColumnNames("[tv_tgk_tg]") : string.Empty) +  
					" FROM [core].[TranslationValue] AS [tv] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationKey] AS [tv_tk] ON [tv].[TranslationKeyID] = [tv_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[TranslationKey] AS [tv_tk_tk] ON [tv_tk].[FallbackTranslationKeyID] = [tv_tk_tk].[TranslationKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [tv_tk_t] ON [tv_tk].[TranslationID] = [tv_tk_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [tv_tk_l] ON [tv_tk].[LanguageID] = [tv_tk_l].[LanguageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Service] AS [tv_tk_s] ON [tv_tk].[ServiceID] = [tv_tk_s].[ServiceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroupKey] AS [tv_tgk] ON [tv].[TranslationGroupKeyID] = [tv_tgk].[TranslationGroupKeyID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationGroup] AS [tv_tgk_tg] ON [tv_tgk].[TranslationGroupID] = [tv_tgk_tg].[TranslationGroupID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "customloadmany", "notfound"), "TranslationValue list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<TranslationValue>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationValueTable tvTable = new TranslationValueTable(query);
				TranslationKeyTable tv_tkTable = (this.Depth > 0) ? new TranslationKeyTable(query) : null;
				TranslationKeyTable tv_tk_tkTable = (this.Depth > 1) ? new TranslationKeyTable(query) : null;
				TranslationTable tv_tk_tTable = (this.Depth > 1) ? new TranslationTable(query) : null;
				LanguageTable tv_tk_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;
				ServiceTable tv_tk_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				TranslationGroupKeyTable tv_tgkTable = (this.Depth > 0) ? new TranslationGroupKeyTable(query) : null;
				TranslationGroupTable tv_tgk_tgTable = (this.Depth > 1) ? new TranslationGroupTable(query) : null;

        List<TranslationValue> result = new List<TranslationValue>();
        do
        {
          
					TranslationKey tv_tk_tkObject = (this.Depth > 1) ? tv_tk_tkTable.CreateInstance() : null;
					Translation tv_tk_tObject = (this.Depth > 1) ? tv_tk_tTable.CreateInstance() : null;
					Language tv_tk_lObject = (this.Depth > 1) ? tv_tk_lTable.CreateInstance() : null;
					Service tv_tk_sObject = (this.Depth > 1) ? tv_tk_sTable.CreateInstance() : null;
					TranslationKey tv_tkObject = (this.Depth > 0) ? tv_tkTable.CreateInstance(tv_tk_tkObject, tv_tk_tObject, tv_tk_lObject, tv_tk_sObject) : null;
					TranslationGroup tv_tgk_tgObject = (this.Depth > 1) ? tv_tgk_tgTable.CreateInstance() : null;
					TranslationGroupKey tv_tgkObject = (this.Depth > 0) ? tv_tgkTable.CreateInstance(tv_tgk_tgObject) : null;
					TranslationValue tvObject = (this.Depth > -1) ? tvTable.CreateInstance(tv_tkObject, tv_tgkObject) : null;
					result.Add(tvObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "customloadmany", "exception"), "TranslationValue list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "TranslationValue", "Exception while loading (custom/many) TranslationValue object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, TranslationValue data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[TranslationValue] ([TranslationKeyID],[TranslationGroupKeyID],[Value]) VALUES(@TranslationKeyID,@TranslationGroupKeyID,@Value); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationKeyID", data.TranslationKey.ID);
				sqlCmd.Parameters.AddWithValue("@TranslationGroupKeyID", data.TranslationGroupKey.ID);
				sqlCmd.Parameters.AddWithValue("@Value", data.Value).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "insert", "noprimarykey"), "TranslationValue could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "TranslationValue", "Exception while inserting TranslationValue object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "insert", "exception"), "TranslationValue could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "TranslationValue", "Exception while inserting TranslationValue object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, TranslationValue data)
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
        sqlCmdText = "UPDATE [core].[TranslationValue] SET " +
												"[TranslationKeyID] = @TranslationKeyID, " + 
												"[TranslationGroupKeyID] = @TranslationGroupKeyID, " + 
												"[Value] = @Value, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [TranslationValueID] = @TranslationValueID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationKeyID", data.TranslationKey.ID);
				sqlCmd.Parameters.AddWithValue("@TranslationGroupKeyID", data.TranslationGroupKey.ID);
				sqlCmd.Parameters.AddWithValue("@Value", data.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@TranslationValueID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "update", "norecord"), "TranslationValue could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationValue", "Exception while updating TranslationValue object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "update", "morerecords"), "TranslationValue was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "TranslationValue", "Exception while updating TranslationValue object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "update", "exception"), "TranslationValue could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "TranslationValue", "Exception while updating TranslationValue object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, TranslationValue data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[TranslationValue] WHERE TranslationValueID = @TranslationValueID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationValueID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "delete", "norecord"), "TranslationValue could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "TranslationValue", "Exception while deleting TranslationValue object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("tv", "delete", "exception"), "TranslationValue could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "TranslationValue", "Exception while deleting TranslationValue object from database. See inner exception for details.", ex);
      }
    }
  }
}

