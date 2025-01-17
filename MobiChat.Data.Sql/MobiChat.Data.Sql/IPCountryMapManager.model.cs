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
  [DataManager(typeof(IPCountryMap))] 
  public partial class IPCountryMapManager : MobiChat.Data.Sql.SqlManagerBase<IPCountryMap>, IIPCountryMapManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override IPCountryMap LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							IPCountryMapTable.GetColumnNames("[ipcm]") + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[ipcm_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[ipcm_c_l]") : string.Empty) + 
					" FROM [core].[IPCountryMap] AS [ipcm] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [ipcm_c] ON [ipcm].[CountryID] = [ipcm_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [ipcm_c_l] ON [ipcm_c].[LanguageID] = [ipcm_c_l].[LanguageID] ";
				sqlCmdText += "WHERE [ipcm].[IPCountryMapID] = @IPCountryMapID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@IPCountryMapID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "loadinternal", "notfound"), "IPCountryMap could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				IPCountryMapTable ipcmTable = new IPCountryMapTable(query);
				CountryTable ipcm_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable ipcm_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;

        
				Language ipcm_c_lObject = (this.Depth > 1) ? ipcm_c_lTable.CreateInstance() : null;
				Country ipcm_cObject = (this.Depth > 0) ? ipcm_cTable.CreateInstance(ipcm_c_lObject) : null;
				IPCountryMap ipcmObject = ipcmTable.CreateInstance(ipcm_cObject);
				sqlReader.Close();

				return ipcmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "loadinternal", "exception"), "IPCountryMap could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "IPCountryMap", "Exception while loading IPCountryMap object from database. See inner exception for details.", ex);
      }
    }

    public IPCountryMap Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							IPCountryMapTable.GetColumnNames("[ipcm]") + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[ipcm_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[ipcm_c_l]") : string.Empty) +  
					" FROM [core].[IPCountryMap] AS [ipcm] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [ipcm_c] ON [ipcm].[CountryID] = [ipcm_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [ipcm_c_l] ON [ipcm_c].[LanguageID] = [ipcm_c_l].[LanguageID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "customload", "notfound"), "IPCountryMap could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				IPCountryMapTable ipcmTable = new IPCountryMapTable(query);
				CountryTable ipcm_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable ipcm_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;

        
				Language ipcm_c_lObject = (this.Depth > 1) ? ipcm_c_lTable.CreateInstance() : null;
				Country ipcm_cObject = (this.Depth > 0) ? ipcm_cTable.CreateInstance(ipcm_c_lObject) : null;
				IPCountryMap ipcmObject = ipcmTable.CreateInstance(ipcm_cObject);
				sqlReader.Close();

				return ipcmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "customload", "exception"), "IPCountryMap could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "IPCountryMap", "Exception while loading (custom/single) IPCountryMap object from database. See inner exception for details.", ex);
      }
    }

    public List<IPCountryMap> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							IPCountryMapTable.GetColumnNames("[ipcm]") + 
							(this.Depth > 0 ? "," + CountryTable.GetColumnNames("[ipcm_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + LanguageTable.GetColumnNames("[ipcm_c_l]") : string.Empty) +  
					" FROM [core].[IPCountryMap] AS [ipcm] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Country] AS [ipcm_c] ON [ipcm].[CountryID] = [ipcm_c].[CountryID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Language] AS [ipcm_c_l] ON [ipcm_c].[LanguageID] = [ipcm_c_l].[LanguageID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "customloadmany", "notfound"), "IPCountryMap list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<IPCountryMap>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				IPCountryMapTable ipcmTable = new IPCountryMapTable(query);
				CountryTable ipcm_cTable = (this.Depth > 0) ? new CountryTable(query) : null;
				LanguageTable ipcm_c_lTable = (this.Depth > 1) ? new LanguageTable(query) : null;

        List<IPCountryMap> result = new List<IPCountryMap>();
        do
        {
          
					Language ipcm_c_lObject = (this.Depth > 1) ? ipcm_c_lTable.CreateInstance() : null;
					Country ipcm_cObject = (this.Depth > 0) ? ipcm_cTable.CreateInstance(ipcm_c_lObject) : null;
					IPCountryMap ipcmObject = (this.Depth > -1) ? ipcmTable.CreateInstance(ipcm_cObject) : null;
					result.Add(ipcmObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "customloadmany", "exception"), "IPCountryMap list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "IPCountryMap", "Exception while loading (custom/many) IPCountryMap object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, IPCountryMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[IPCountryMap] ([FromAddress],[ToAddress],[TwoLetterIsoCode],[CountryID]) VALUES(@FromAddress,@ToAddress,@TwoLetterIsoCode,@CountryID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@FromAddress", data.FromAddress).SqlDbType = SqlDbType.BigInt;
				sqlCmd.Parameters.AddWithValue("@ToAddress", data.ToAddress).SqlDbType = SqlDbType.BigInt;
				sqlCmd.Parameters.AddWithValue("@TwoLetterIsoCode", data.TwoLetterIsoCode).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@CountryID", data.Country == null ? DBNull.Value : (object)data.Country.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "insert", "noprimarykey"), "IPCountryMap could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "IPCountryMap", "Exception while inserting IPCountryMap object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "insert", "exception"), "IPCountryMap could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "IPCountryMap", "Exception while inserting IPCountryMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, IPCountryMap data)
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
        sqlCmdText = "UPDATE [core].[IPCountryMap] SET " +
												"[FromAddress] = @FromAddress, " + 
												"[ToAddress] = @ToAddress, " + 
												"[TwoLetterIsoCode] = @TwoLetterIsoCode, " + 
												"[CountryID] = @CountryID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [IPCountryMapID] = @IPCountryMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@FromAddress", data.FromAddress).SqlDbType = SqlDbType.BigInt;
				sqlCmd.Parameters.AddWithValue("@ToAddress", data.ToAddress).SqlDbType = SqlDbType.BigInt;
				sqlCmd.Parameters.AddWithValue("@TwoLetterIsoCode", data.TwoLetterIsoCode).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@CountryID", data.Country == null ? DBNull.Value : (object)data.Country.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@IPCountryMapID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "update", "norecord"), "IPCountryMap could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "IPCountryMap", "Exception while updating IPCountryMap object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "update", "morerecords"), "IPCountryMap was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "IPCountryMap", "Exception while updating IPCountryMap object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "update", "exception"), "IPCountryMap could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "IPCountryMap", "Exception while updating IPCountryMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, IPCountryMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[IPCountryMap] WHERE IPCountryMapID = @IPCountryMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@IPCountryMapID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "delete", "norecord"), "IPCountryMap could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "IPCountryMap", "Exception while deleting IPCountryMap object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ipcm", "delete", "exception"), "IPCountryMap could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "IPCountryMap", "Exception while deleting IPCountryMap object from database. See inner exception for details.", ex);
      }
    }
  }
}

