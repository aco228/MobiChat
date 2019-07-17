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
  [DataManager(typeof(ReportLink))] 
  public partial class ReportLinkManager : MobiChat.Data.Sql.SqlManagerBase<ReportLink>, IReportLinkManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ReportLink LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ReportLinkTable.GetColumnNames("[rl]") + 
							(this.Depth > 0 ? "," + ReportLinkGroupTable.GetColumnNames("[rl_rlg]") : string.Empty) + 
					" FROM [core].[ReportLink] AS [rl] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ReportLinkGroup] AS [rl_rlg] ON [rl].[ReportLinkGroupID] = [rl_rlg].[ReportLinkGroupID] ";
				sqlCmdText += "WHERE [rl].[ReportLinkID] = @ReportLinkID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ReportLinkID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "loadinternal", "notfound"), "ReportLink could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ReportLinkTable rlTable = new ReportLinkTable(query);
				ReportLinkGroupTable rl_rlgTable = (this.Depth > 0) ? new ReportLinkGroupTable(query) : null;

        
				ReportLinkGroup rl_rlgObject = (this.Depth > 0) ? rl_rlgTable.CreateInstance() : null;
				ReportLink rlObject = rlTable.CreateInstance(rl_rlgObject);
				sqlReader.Close();

				return rlObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "loadinternal", "exception"), "ReportLink could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ReportLink", "Exception while loading ReportLink object from database. See inner exception for details.", ex);
      }
    }

    public ReportLink Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ReportLinkTable.GetColumnNames("[rl]") + 
							(this.Depth > 0 ? "," + ReportLinkGroupTable.GetColumnNames("[rl_rlg]") : string.Empty) +  
					" FROM [core].[ReportLink] AS [rl] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ReportLinkGroup] AS [rl_rlg] ON [rl].[ReportLinkGroupID] = [rl_rlg].[ReportLinkGroupID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "customload", "notfound"), "ReportLink could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ReportLinkTable rlTable = new ReportLinkTable(query);
				ReportLinkGroupTable rl_rlgTable = (this.Depth > 0) ? new ReportLinkGroupTable(query) : null;

        
				ReportLinkGroup rl_rlgObject = (this.Depth > 0) ? rl_rlgTable.CreateInstance() : null;
				ReportLink rlObject = rlTable.CreateInstance(rl_rlgObject);
				sqlReader.Close();

				return rlObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "customload", "exception"), "ReportLink could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ReportLink", "Exception while loading (custom/single) ReportLink object from database. See inner exception for details.", ex);
      }
    }

    public List<ReportLink> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ReportLinkTable.GetColumnNames("[rl]") + 
							(this.Depth > 0 ? "," + ReportLinkGroupTable.GetColumnNames("[rl_rlg]") : string.Empty) +  
					" FROM [core].[ReportLink] AS [rl] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ReportLinkGroup] AS [rl_rlg] ON [rl].[ReportLinkGroupID] = [rl_rlg].[ReportLinkGroupID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "customloadmany", "notfound"), "ReportLink list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ReportLink>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ReportLinkTable rlTable = new ReportLinkTable(query);
				ReportLinkGroupTable rl_rlgTable = (this.Depth > 0) ? new ReportLinkGroupTable(query) : null;

        List<ReportLink> result = new List<ReportLink>();
        do
        {
          
					ReportLinkGroup rl_rlgObject = (this.Depth > 0) ? rl_rlgTable.CreateInstance() : null;
					ReportLink rlObject = (this.Depth > -1) ? rlTable.CreateInstance(rl_rlgObject) : null;
					result.Add(rlObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "customloadmany", "exception"), "ReportLink list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ReportLink", "Exception while loading (custom/many) ReportLink object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ReportLink data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[ReportLink] ([ReportLinkGroupID],[Url],[IsActive]) VALUES(@ReportLinkGroupID,@Url,@IsActive); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ReportLinkGroupID", data.ReportLinkGroup.ID);
				sqlCmd.Parameters.AddWithValue("@Url", data.Url).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "insert", "noprimarykey"), "ReportLink could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ReportLink", "Exception while inserting ReportLink object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "insert", "exception"), "ReportLink could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ReportLink", "Exception while inserting ReportLink object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ReportLink data)
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
        sqlCmdText = "UPDATE [core].[ReportLink] SET " +
												"[ReportLinkGroupID] = @ReportLinkGroupID, " + 
												"[Url] = @Url, " + 
												"[IsActive] = @IsActive, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ReportLinkID] = @ReportLinkID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ReportLinkGroupID", data.ReportLinkGroup.ID);
				sqlCmd.Parameters.AddWithValue("@Url", data.Url).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ReportLinkID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "update", "norecord"), "ReportLink could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ReportLink", "Exception while updating ReportLink object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "update", "morerecords"), "ReportLink was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ReportLink", "Exception while updating ReportLink object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "update", "exception"), "ReportLink could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ReportLink", "Exception while updating ReportLink object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ReportLink data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[ReportLink] WHERE ReportLinkID = @ReportLinkID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ReportLinkID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "delete", "norecord"), "ReportLink could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ReportLink", "Exception while deleting ReportLink object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("rl", "delete", "exception"), "ReportLink could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ReportLink", "Exception while deleting ReportLink object from database. See inner exception for details.", ex);
      }
    }
  }
}

