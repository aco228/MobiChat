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
  [DataManager(typeof(Report))] 
  public partial class ReportManager : MobiChat.Data.Sql.SqlManagerBase<Report>, IReportManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Report LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ReportTable.GetColumnNames("[r]") + 
							(this.Depth > 0 ? "," + ReportLinkTable.GetColumnNames("[r_rl]") : string.Empty) + 
							(this.Depth > 1 ? "," + ReportLinkGroupTable.GetColumnNames("[r_rl_rlg]") : string.Empty) + 
					" FROM [core].[Report] AS [r] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ReportLink] AS [r_rl] ON [r].[ReportLinkID] = [r_rl].[ReportLinkID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ReportLinkGroup] AS [r_rl_rlg] ON [r_rl].[ReportLinkGroupID] = [r_rl_rlg].[ReportLinkGroupID] ";
				sqlCmdText += "WHERE [r].[ReportID] = @ReportID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ReportID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "loadinternal", "notfound"), "Report could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ReportTable rTable = new ReportTable(query);
				ReportLinkTable r_rlTable = (this.Depth > 0) ? new ReportLinkTable(query) : null;
				ReportLinkGroupTable r_rl_rlgTable = (this.Depth > 1) ? new ReportLinkGroupTable(query) : null;

        
				ReportLinkGroup r_rl_rlgObject = (this.Depth > 1) ? r_rl_rlgTable.CreateInstance() : null;
				ReportLink r_rlObject = (this.Depth > 0) ? r_rlTable.CreateInstance(r_rl_rlgObject) : null;
				Report rObject = rTable.CreateInstance(r_rlObject);
				sqlReader.Close();

				return rObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "loadinternal", "exception"), "Report could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Report", "Exception while loading Report object from database. See inner exception for details.", ex);
      }
    }

    public Report Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ReportTable.GetColumnNames("[r]") + 
							(this.Depth > 0 ? "," + ReportLinkTable.GetColumnNames("[r_rl]") : string.Empty) + 
							(this.Depth > 1 ? "," + ReportLinkGroupTable.GetColumnNames("[r_rl_rlg]") : string.Empty) +  
					" FROM [core].[Report] AS [r] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ReportLink] AS [r_rl] ON [r].[ReportLinkID] = [r_rl].[ReportLinkID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ReportLinkGroup] AS [r_rl_rlg] ON [r_rl].[ReportLinkGroupID] = [r_rl_rlg].[ReportLinkGroupID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customload", "notfound"), "Report could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ReportTable rTable = new ReportTable(query);
				ReportLinkTable r_rlTable = (this.Depth > 0) ? new ReportLinkTable(query) : null;
				ReportLinkGroupTable r_rl_rlgTable = (this.Depth > 1) ? new ReportLinkGroupTable(query) : null;

        
				ReportLinkGroup r_rl_rlgObject = (this.Depth > 1) ? r_rl_rlgTable.CreateInstance() : null;
				ReportLink r_rlObject = (this.Depth > 0) ? r_rlTable.CreateInstance(r_rl_rlgObject) : null;
				Report rObject = rTable.CreateInstance(r_rlObject);
				sqlReader.Close();

				return rObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customload", "exception"), "Report could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Report", "Exception while loading (custom/single) Report object from database. See inner exception for details.", ex);
      }
    }

    public List<Report> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ReportTable.GetColumnNames("[r]") + 
							(this.Depth > 0 ? "," + ReportLinkTable.GetColumnNames("[r_rl]") : string.Empty) + 
							(this.Depth > 1 ? "," + ReportLinkGroupTable.GetColumnNames("[r_rl_rlg]") : string.Empty) +  
					" FROM [core].[Report] AS [r] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[ReportLink] AS [r_rl] ON [r].[ReportLinkID] = [r_rl].[ReportLinkID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[ReportLinkGroup] AS [r_rl_rlg] ON [r_rl].[ReportLinkGroupID] = [r_rl_rlg].[ReportLinkGroupID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customloadmany", "notfound"), "Report list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Report>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ReportTable rTable = new ReportTable(query);
				ReportLinkTable r_rlTable = (this.Depth > 0) ? new ReportLinkTable(query) : null;
				ReportLinkGroupTable r_rl_rlgTable = (this.Depth > 1) ? new ReportLinkGroupTable(query) : null;

        List<Report> result = new List<Report>();
        do
        {
          
					ReportLinkGroup r_rl_rlgObject = (this.Depth > 1) ? r_rl_rlgTable.CreateInstance() : null;
					ReportLink r_rlObject = (this.Depth > 0) ? r_rlTable.CreateInstance(r_rl_rlgObject) : null;
					Report rObject = (this.Depth > -1) ? rTable.CreateInstance(r_rlObject) : null;
					result.Add(rObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "customloadmany", "exception"), "Report list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Report", "Exception while loading (custom/many) Report object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Report data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Report] ([ReportLinkID],[Pxid],[AdditionalData]) VALUES(@ReportLinkID,@Pxid,@AdditionalData); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ReportLinkID", data.ReportLink.ID);
				sqlCmd.Parameters.AddWithValue("@Pxid", data.Pxid.HasValue ? (object)data.Pxid.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@AdditionalData", !string.IsNullOrEmpty(data.AdditionalData) ? (object)data.AdditionalData : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "insert", "noprimarykey"), "Report could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Report", "Exception while inserting Report object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "insert", "exception"), "Report could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Report", "Exception while inserting Report object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Report data)
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
        sqlCmdText = "UPDATE [core].[Report] SET " +
												"[ReportLinkID] = @ReportLinkID, " + 
												"[Pxid] = @Pxid, " + 
												"[AdditionalData] = @AdditionalData, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ReportID] = @ReportID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ReportLinkID", data.ReportLink.ID);
				sqlCmd.Parameters.AddWithValue("@Pxid", data.Pxid.HasValue ? (object)data.Pxid.Value : DBNull.Value).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@AdditionalData", !string.IsNullOrEmpty(data.AdditionalData) ? (object)data.AdditionalData : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ReportID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "update", "norecord"), "Report could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Report", "Exception while updating Report object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "update", "morerecords"), "Report was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Report", "Exception while updating Report object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "update", "exception"), "Report could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Report", "Exception while updating Report object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Report data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Report] WHERE ReportID = @ReportID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ReportID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "delete", "norecord"), "Report could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Report", "Exception while deleting Report object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("r", "delete", "exception"), "Report could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Report", "Exception while deleting Report object from database. See inner exception for details.", ex);
      }
    }
  }
}

