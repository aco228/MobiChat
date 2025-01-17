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
  [DataManager(typeof(Localization))] 
  public partial class LocalizationManager : MobiChat.Data.Sql.SqlManagerBase<Localization>, ILocalizationManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Localization LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							LocalizationTable.GetColumnNames("[l]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[l_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[l_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[l_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[l_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ProductTable.GetColumnNames("[l_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[l_p_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[l_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[l_t_tt]") : string.Empty) + 
					" FROM [core].[Localization] AS [l] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [l_a] ON [l].[ApplicationID] = [l_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [l_a_i] ON [l_a].[InstanceID] = [l_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [l_a_at] ON [l_a].[ApplicationTypeID] = [l_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [l_a_rt] ON [l_a].[RuntimeTypeID] = [l_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [l_p] ON [l].[ProductID] = [l_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Instance] AS [l_p_i] ON [l_p].[InstanceID] = [l_p_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [l_t] ON [l].[TranslationID] = [l_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [l_t_tt] ON [l_t].[TranslationTypeID] = [l_t_tt].[TranslationTypeID] ";
				sqlCmdText += "WHERE [l].[LocalizationID] = @LocalizationID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@LocalizationID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "loadinternal", "notfound"), "Localization could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				LocalizationTable lTable = new LocalizationTable(query);
				ApplicationTable l_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable l_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable l_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable l_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ProductTable l_pTable = (this.Depth > 0) ? new ProductTable(query) : null;
				InstanceTable l_p_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				TranslationTable l_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable l_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;

        
				Instance l_a_iObject = (this.Depth > 1) ? l_a_iTable.CreateInstance() : null;
				ApplicationType l_a_atObject = (this.Depth > 1) ? l_a_atTable.CreateInstance() : null;
				RuntimeType l_a_rtObject = (this.Depth > 1) ? l_a_rtTable.CreateInstance() : null;
				Application l_aObject = (this.Depth > 0) ? l_aTable.CreateInstance(l_a_iObject, l_a_atObject, l_a_rtObject) : null;
				Instance l_p_iObject = (this.Depth > 1) ? l_p_iTable.CreateInstance() : null;
				Product l_pObject = (this.Depth > 0) ? l_pTable.CreateInstance(l_p_iObject) : null;
				TranslationType l_t_ttObject = (this.Depth > 1) ? l_t_ttTable.CreateInstance() : null;
				Translation l_tObject = (this.Depth > 0) ? l_tTable.CreateInstance(l_t_ttObject) : null;
				Localization lObject = lTable.CreateInstance(l_aObject, l_pObject, l_tObject);
				sqlReader.Close();

				return lObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "loadinternal", "exception"), "Localization could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Localization", "Exception while loading Localization object from database. See inner exception for details.", ex);
      }
    }

    public Localization Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							LocalizationTable.GetColumnNames("[l]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[l_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[l_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[l_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[l_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ProductTable.GetColumnNames("[l_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[l_p_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[l_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[l_t_tt]") : string.Empty) +  
					" FROM [core].[Localization] AS [l] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [l_a] ON [l].[ApplicationID] = [l_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [l_a_i] ON [l_a].[InstanceID] = [l_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [l_a_at] ON [l_a].[ApplicationTypeID] = [l_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [l_a_rt] ON [l_a].[RuntimeTypeID] = [l_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [l_p] ON [l].[ProductID] = [l_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Instance] AS [l_p_i] ON [l_p].[InstanceID] = [l_p_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [l_t] ON [l].[TranslationID] = [l_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [l_t_tt] ON [l_t].[TranslationTypeID] = [l_t_tt].[TranslationTypeID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "customload", "notfound"), "Localization could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				LocalizationTable lTable = new LocalizationTable(query);
				ApplicationTable l_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable l_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable l_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable l_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ProductTable l_pTable = (this.Depth > 0) ? new ProductTable(query) : null;
				InstanceTable l_p_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				TranslationTable l_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable l_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;

        
				Instance l_a_iObject = (this.Depth > 1) ? l_a_iTable.CreateInstance() : null;
				ApplicationType l_a_atObject = (this.Depth > 1) ? l_a_atTable.CreateInstance() : null;
				RuntimeType l_a_rtObject = (this.Depth > 1) ? l_a_rtTable.CreateInstance() : null;
				Application l_aObject = (this.Depth > 0) ? l_aTable.CreateInstance(l_a_iObject, l_a_atObject, l_a_rtObject) : null;
				Instance l_p_iObject = (this.Depth > 1) ? l_p_iTable.CreateInstance() : null;
				Product l_pObject = (this.Depth > 0) ? l_pTable.CreateInstance(l_p_iObject) : null;
				TranslationType l_t_ttObject = (this.Depth > 1) ? l_t_ttTable.CreateInstance() : null;
				Translation l_tObject = (this.Depth > 0) ? l_tTable.CreateInstance(l_t_ttObject) : null;
				Localization lObject = lTable.CreateInstance(l_aObject, l_pObject, l_tObject);
				sqlReader.Close();

				return lObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "customload", "exception"), "Localization could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Localization", "Exception while loading (custom/single) Localization object from database. See inner exception for details.", ex);
      }
    }

    public List<Localization> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							LocalizationTable.GetColumnNames("[l]") + 
							(this.Depth > 0 ? "," + ApplicationTable.GetColumnNames("[l_a]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[l_a_i]") : string.Empty) + 
							(this.Depth > 1 ? "," + ApplicationTypeTable.GetColumnNames("[l_a_at]") : string.Empty) + 
							(this.Depth > 1 ? "," + RuntimeTypeTable.GetColumnNames("[l_a_rt]") : string.Empty) + 
							(this.Depth > 0 ? "," + ProductTable.GetColumnNames("[l_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + InstanceTable.GetColumnNames("[l_p_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + TranslationTable.GetColumnNames("[l_t]") : string.Empty) + 
							(this.Depth > 1 ? "," + TranslationTypeTable.GetColumnNames("[l_t_tt]") : string.Empty) +  
					" FROM [core].[Localization] AS [l] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Application] AS [l_a] ON [l].[ApplicationID] = [l_a].[ApplicationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [l_a_i] ON [l_a].[InstanceID] = [l_a_i].[InstanceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ApplicationType] AS [l_a_at] ON [l_a].[ApplicationTypeID] = [l_a_at].[ApplicationTypeID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[RuntimeType] AS [l_a_rt] ON [l_a].[RuntimeTypeID] = [l_a_rt].[RuntimeTypeID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Product] AS [l_p] ON [l].[ProductID] = [l_p].[ProductID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Instance] AS [l_p_i] ON [l_p].[InstanceID] = [l_p_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Translation] AS [l_t] ON [l].[TranslationID] = [l_t].[TranslationID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[TranslationType] AS [l_t_tt] ON [l_t].[TranslationTypeID] = [l_t_tt].[TranslationTypeID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "customloadmany", "notfound"), "Localization list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Localization>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				LocalizationTable lTable = new LocalizationTable(query);
				ApplicationTable l_aTable = (this.Depth > 0) ? new ApplicationTable(query) : null;
				InstanceTable l_a_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				ApplicationTypeTable l_a_atTable = (this.Depth > 1) ? new ApplicationTypeTable(query) : null;
				RuntimeTypeTable l_a_rtTable = (this.Depth > 1) ? new RuntimeTypeTable(query) : null;
				ProductTable l_pTable = (this.Depth > 0) ? new ProductTable(query) : null;
				InstanceTable l_p_iTable = (this.Depth > 1) ? new InstanceTable(query) : null;
				TranslationTable l_tTable = (this.Depth > 0) ? new TranslationTable(query) : null;
				TranslationTypeTable l_t_ttTable = (this.Depth > 1) ? new TranslationTypeTable(query) : null;

        List<Localization> result = new List<Localization>();
        do
        {
          
					Instance l_a_iObject = (this.Depth > 1) ? l_a_iTable.CreateInstance() : null;
					ApplicationType l_a_atObject = (this.Depth > 1) ? l_a_atTable.CreateInstance() : null;
					RuntimeType l_a_rtObject = (this.Depth > 1) ? l_a_rtTable.CreateInstance() : null;
					Application l_aObject = (this.Depth > 0) ? l_aTable.CreateInstance(l_a_iObject, l_a_atObject, l_a_rtObject) : null;
					Instance l_p_iObject = (this.Depth > 1) ? l_p_iTable.CreateInstance() : null;
					Product l_pObject = (this.Depth > 0) ? l_pTable.CreateInstance(l_p_iObject) : null;
					TranslationType l_t_ttObject = (this.Depth > 1) ? l_t_ttTable.CreateInstance() : null;
					Translation l_tObject = (this.Depth > 0) ? l_tTable.CreateInstance(l_t_ttObject) : null;
					Localization lObject = (this.Depth > -1) ? lTable.CreateInstance(l_aObject, l_pObject, l_tObject) : null;
					result.Add(lObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "customloadmany", "exception"), "Localization list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Localization", "Exception while loading (custom/many) Localization object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Localization data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Localization] ([ApplicationID],[ProductID],[TranslationID]) VALUES(@ApplicationID,@ProductID,@TranslationID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@ProductID", data.Product == null ? DBNull.Value : (object)data.Product.ID);
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.Translation.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "insert", "noprimarykey"), "Localization could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Localization", "Exception while inserting Localization object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "insert", "exception"), "Localization could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Localization", "Exception while inserting Localization object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Localization data)
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
        sqlCmdText = "UPDATE [core].[Localization] SET " +
												"[ApplicationID] = @ApplicationID, " + 
												"[ProductID] = @ProductID, " + 
												"[TranslationID] = @TranslationID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [LocalizationID] = @LocalizationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ApplicationID", data.Application.ID);
				sqlCmd.Parameters.AddWithValue("@ProductID", data.Product == null ? DBNull.Value : (object)data.Product.ID);
				sqlCmd.Parameters.AddWithValue("@TranslationID", data.Translation.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@LocalizationID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "update", "norecord"), "Localization could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Localization", "Exception while updating Localization object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "update", "morerecords"), "Localization was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Localization", "Exception while updating Localization object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "update", "exception"), "Localization could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Localization", "Exception while updating Localization object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Localization data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Localization] WHERE LocalizationID = @LocalizationID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@LocalizationID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "delete", "norecord"), "Localization could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Localization", "Exception while deleting Localization object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("l", "delete", "exception"), "Localization could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Localization", "Exception while deleting Localization object from database. See inner exception for details.", ex);
      }
    }
  }
}

