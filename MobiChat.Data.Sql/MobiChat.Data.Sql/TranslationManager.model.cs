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
  [DataManager(typeof(Translation))] 
  public partial class TranslationManager : MobiChat.Data.Sql.SqlManagerBase<Translation>, ITranslationManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Translation LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							TranslationTable.GetColumnNames("[t]") + 
							(this.Depth > 0 ? "," + TranslationTypeTable.GetColumnNames("[t_tt]") : string.Empty) + 
					" FROM [core].[Translation] AS [t] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [t_tt] ON [t].[TranslationTypeID] = [t_tt].[TranslationTypeID] ";
				sqlCmdText += "WHERE [t].[TranslationID] = @TranslationID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "loadinternal", "notfound"), "Translation could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationTable tTable = new TranslationTable(query);
				TranslationTypeTable t_ttTable = (this.Depth > 0) ? new TranslationTypeTable(query) : null;

        
				TranslationType t_ttObject = (this.Depth > 0) ? t_ttTable.CreateInstance() : null;
				Translation tObject = tTable.CreateInstance(t_ttObject);
				sqlReader.Close();

				return tObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "loadinternal", "exception"), "Translation could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Translation", "Exception while loading Translation object from database. See inner exception for details.", ex);
      }
    }

    public Translation Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationTable.GetColumnNames("[t]") + 
							(this.Depth > 0 ? "," + TranslationTypeTable.GetColumnNames("[t_tt]") : string.Empty) +  
					" FROM [core].[Translation] AS [t] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [t_tt] ON [t].[TranslationTypeID] = [t_tt].[TranslationTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customload", "notfound"), "Translation could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationTable tTable = new TranslationTable(query);
				TranslationTypeTable t_ttTable = (this.Depth > 0) ? new TranslationTypeTable(query) : null;

        
				TranslationType t_ttObject = (this.Depth > 0) ? t_ttTable.CreateInstance() : null;
				Translation tObject = tTable.CreateInstance(t_ttObject);
				sqlReader.Close();

				return tObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customload", "exception"), "Translation could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Translation", "Exception while loading (custom/single) Translation object from database. See inner exception for details.", ex);
      }
    }

    public List<Translation> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TranslationTable.GetColumnNames("[t]") + 
							(this.Depth > 0 ? "," + TranslationTypeTable.GetColumnNames("[t_tt]") : string.Empty) +  
					" FROM [core].[Translation] AS [t] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [t_tt] ON [t].[TranslationTypeID] = [t_tt].[TranslationTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customloadmany", "notfound"), "Translation list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Translation>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TranslationTable tTable = new TranslationTable(query);
				TranslationTypeTable t_ttTable = (this.Depth > 0) ? new TranslationTypeTable(query) : null;

        List<Translation> result = new List<Translation>();
        do
        {
          
					TranslationType t_ttObject = (this.Depth > 0) ? t_ttTable.CreateInstance() : null;
					Translation tObject = (this.Depth > -1) ? tTable.CreateInstance(t_ttObject) : null;
					result.Add(tObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customloadmany", "exception"), "Translation list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Translation", "Exception while loading (custom/many) Translation object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Translation data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Translation] ([TranslationTypeID],[Name],[Description]) VALUES(@TranslationTypeID,@Name,@Description); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationTypeID", data.TranslationType.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "insert", "noprimarykey"), "Translation could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Translation", "Exception while inserting Translation object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "insert", "exception"), "Translation could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Translation", "Exception while inserting Translation object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Translation data)
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
        sqlCmdText = "UPDATE [core].[Translation] SET " +
												"[TranslationTypeID] = @TranslationTypeID, " + 
												"[Name] = @Name, " + 
												"[Description] = @Description, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [TranslationID] = @TranslationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TranslationTypeID", data.TranslationType.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "update", "norecord"), "Translation could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Translation", "Exception while updating Translation object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "update", "morerecords"), "Translation was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Translation", "Exception while updating Translation object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "update", "exception"), "Translation could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Translation", "Exception while updating Translation object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Translation data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Translation] WHERE TranslationID = @TranslationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TranslationID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "delete", "norecord"), "Translation could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Translation", "Exception while deleting Translation object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "delete", "exception"), "Translation could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Translation", "Exception while deleting Translation object from database. See inner exception for details.", ex);
      }
    }
  }
}

