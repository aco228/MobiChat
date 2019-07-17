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



namespace MobiChat.Web.Data.Sql
{
  [DataManager(typeof(MTMessage))] 
  public partial class MTMessageManager : MobiChat.Data.Sql.SqlManagerBase<MTMessage>, IMTMessageManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override MTMessage LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							MTMessageTable.GetColumnNames("[mtm]") + 
							(this.Depth > 0 ? "," + MessageTable.GetColumnNames("[mtm_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[mtm_m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[mtm_m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[mtm_m_mo]") : string.Empty) + 
					" FROM [stats].[MTMessage] AS [mtm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [stats].[Message] AS [mtm_m] ON [mtm].[MessageID] = [mtm_m].[MessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [mtm_m_s] ON [mtm_m].[ServiceID] = [mtm_m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [mtm_m_c] ON [mtm_m].[CustomerID] = [mtm_m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [mtm_m_mo] ON [mtm_m].[MobileOperatorID] = [mtm_m_mo].[MobileOperatorID] ";
				sqlCmdText += "WHERE [mtm].[MTMessageID] = @MTMessageID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MTMessageID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "loadinternal", "notfound"), "MTMessage could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MTMessageTable mtmTable = new MTMessageTable(query);
				MessageTable mtm_mTable = (this.Depth > 0) ? new MessageTable(query) : null;
				ServiceTable mtm_m_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CustomerTable mtm_m_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				MobileOperatorTable mtm_m_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        
				Service mtm_m_sObject = (this.Depth > 1) ? mtm_m_sTable.CreateInstance() : null;
				Customer mtm_m_cObject = (this.Depth > 1) ? mtm_m_cTable.CreateInstance() : null;
				MobileOperator mtm_m_moObject = (this.Depth > 1) ? mtm_m_moTable.CreateInstance() : null;
				Message mtm_mObject = (this.Depth > 0) ? mtm_mTable.CreateInstance(mtm_m_sObject, mtm_m_cObject, mtm_m_moObject) : null;
				MTMessage mtmObject = mtmTable.CreateInstance(mtm_mObject);
				sqlReader.Close();

				return mtmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "loadinternal", "exception"), "MTMessage could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "MTMessage", "Exception while loading MTMessage object from database. See inner exception for details.", ex);
      }
    }

    public MTMessage Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MTMessageTable.GetColumnNames("[mtm]") + 
							(this.Depth > 0 ? "," + MessageTable.GetColumnNames("[mtm_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[mtm_m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[mtm_m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[mtm_m_mo]") : string.Empty) +  
					" FROM [stats].[MTMessage] AS [mtm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [stats].[Message] AS [mtm_m] ON [mtm].[MessageID] = [mtm_m].[MessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [mtm_m_s] ON [mtm_m].[ServiceID] = [mtm_m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [mtm_m_c] ON [mtm_m].[CustomerID] = [mtm_m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [mtm_m_mo] ON [mtm_m].[MobileOperatorID] = [mtm_m_mo].[MobileOperatorID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "customload", "notfound"), "MTMessage could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MTMessageTable mtmTable = new MTMessageTable(query);
				MessageTable mtm_mTable = (this.Depth > 0) ? new MessageTable(query) : null;
				ServiceTable mtm_m_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CustomerTable mtm_m_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				MobileOperatorTable mtm_m_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        
				Service mtm_m_sObject = (this.Depth > 1) ? mtm_m_sTable.CreateInstance() : null;
				Customer mtm_m_cObject = (this.Depth > 1) ? mtm_m_cTable.CreateInstance() : null;
				MobileOperator mtm_m_moObject = (this.Depth > 1) ? mtm_m_moTable.CreateInstance() : null;
				Message mtm_mObject = (this.Depth > 0) ? mtm_mTable.CreateInstance(mtm_m_sObject, mtm_m_cObject, mtm_m_moObject) : null;
				MTMessage mtmObject = mtmTable.CreateInstance(mtm_mObject);
				sqlReader.Close();

				return mtmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "customload", "exception"), "MTMessage could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "MTMessage", "Exception while loading (custom/single) MTMessage object from database. See inner exception for details.", ex);
      }
    }

    public List<MTMessage> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MTMessageTable.GetColumnNames("[mtm]") + 
							(this.Depth > 0 ? "," + MessageTable.GetColumnNames("[mtm_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[mtm_m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[mtm_m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[mtm_m_mo]") : string.Empty) +  
					" FROM [stats].[MTMessage] AS [mtm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [stats].[Message] AS [mtm_m] ON [mtm].[MessageID] = [mtm_m].[MessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [mtm_m_s] ON [mtm_m].[ServiceID] = [mtm_m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [mtm_m_c] ON [mtm_m].[CustomerID] = [mtm_m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [mtm_m_mo] ON [mtm_m].[MobileOperatorID] = [mtm_m_mo].[MobileOperatorID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "customloadmany", "notfound"), "MTMessage list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<MTMessage>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MTMessageTable mtmTable = new MTMessageTable(query);
				MessageTable mtm_mTable = (this.Depth > 0) ? new MessageTable(query) : null;
				ServiceTable mtm_m_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CustomerTable mtm_m_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				MobileOperatorTable mtm_m_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        List<MTMessage> result = new List<MTMessage>();
        do
        {
          
					Service mtm_m_sObject = (this.Depth > 1) ? mtm_m_sTable.CreateInstance() : null;
					Customer mtm_m_cObject = (this.Depth > 1) ? mtm_m_cTable.CreateInstance() : null;
					MobileOperator mtm_m_moObject = (this.Depth > 1) ? mtm_m_moTable.CreateInstance() : null;
					Message mtm_mObject = (this.Depth > 0) ? mtm_mTable.CreateInstance(mtm_m_sObject, mtm_m_cObject, mtm_m_moObject) : null;
					MTMessage mtmObject = (this.Depth > -1) ? mtmTable.CreateInstance(mtm_mObject) : null;
					result.Add(mtmObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "customloadmany", "exception"), "MTMessage list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "MTMessage", "Exception while loading (custom/many) MTMessage object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, MTMessage data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [stats].[MTMessage] ([MessageID],[AppID],[To],[MsgID],[Time],[State],[Error],[ReasonCode],[Retry],[AppMsgID]) VALUES(@MessageID,@AppID,@To,@MsgID,@Time,@State,@Error,@ReasonCode,@Retry,@AppMsgID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@MessageID", data.Message.ID);
				sqlCmd.Parameters.AddWithValue("@AppID", !string.IsNullOrEmpty(data.AppID) ? (object)data.AppID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@To", !string.IsNullOrEmpty(data.To) ? (object)data.To : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@MsgID", !string.IsNullOrEmpty(data.MsgID) ? (object)data.MsgID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Time", !string.IsNullOrEmpty(data.Time) ? (object)data.Time : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@State", !string.IsNullOrEmpty(data.State) ? (object)data.State : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Error", !string.IsNullOrEmpty(data.Error) ? (object)data.Error : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@ReasonCode", !string.IsNullOrEmpty(data.ReasonCode) ? (object)data.ReasonCode : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Retry", !string.IsNullOrEmpty(data.Retry) ? (object)data.Retry : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@AppMsgID", !string.IsNullOrEmpty(data.AppMsgID) ? (object)data.AppMsgID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "insert", "noprimarykey"), "MTMessage could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "MTMessage", "Exception while inserting MTMessage object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "insert", "exception"), "MTMessage could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "MTMessage", "Exception while inserting MTMessage object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, MTMessage data)
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
        sqlCmdText = "UPDATE [stats].[MTMessage] SET " +
												"[MessageID] = @MessageID, " + 
												"[AppID] = @AppID, " + 
												"[To] = @To, " + 
												"[MsgID] = @MsgID, " + 
												"[Time] = @Time, " + 
												"[State] = @State, " + 
												"[Error] = @Error, " + 
												"[ReasonCode] = @ReasonCode, " + 
												"[Retry] = @Retry, " + 
												"[AppMsgID] = @AppMsgID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [MTMessageID] = @MTMessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@MessageID", data.Message.ID);
				sqlCmd.Parameters.AddWithValue("@AppID", !string.IsNullOrEmpty(data.AppID) ? (object)data.AppID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@To", !string.IsNullOrEmpty(data.To) ? (object)data.To : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@MsgID", !string.IsNullOrEmpty(data.MsgID) ? (object)data.MsgID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Time", !string.IsNullOrEmpty(data.Time) ? (object)data.Time : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@State", !string.IsNullOrEmpty(data.State) ? (object)data.State : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Error", !string.IsNullOrEmpty(data.Error) ? (object)data.Error : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@ReasonCode", !string.IsNullOrEmpty(data.ReasonCode) ? (object)data.ReasonCode : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Retry", !string.IsNullOrEmpty(data.Retry) ? (object)data.Retry : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@AppMsgID", !string.IsNullOrEmpty(data.AppMsgID) ? (object)data.AppMsgID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@MTMessageID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "update", "norecord"), "MTMessage could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "MTMessage", "Exception while updating MTMessage object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "update", "morerecords"), "MTMessage was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "MTMessage", "Exception while updating MTMessage object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "update", "exception"), "MTMessage could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "MTMessage", "Exception while updating MTMessage object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, MTMessage data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [stats].[MTMessage] WHERE MTMessageID = @MTMessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MTMessageID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "delete", "norecord"), "MTMessage could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "MTMessage", "Exception while deleting MTMessage object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mtm", "delete", "exception"), "MTMessage could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "MTMessage", "Exception while deleting MTMessage object from database. See inner exception for details.", ex);
      }
    }
  }
}

