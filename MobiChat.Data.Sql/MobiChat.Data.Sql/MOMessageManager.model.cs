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
  [DataManager(typeof(MOMessage))] 
  public partial class MOMessageManager : MobiChat.Data.Sql.SqlManagerBase<MOMessage>, IMOMessageManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override MOMessage LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							MOMessageTable.GetColumnNames("[mom]") + 
							(this.Depth > 0 ? "," + MessageTable.GetColumnNames("[mom_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[mom_m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[mom_m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[mom_m_mo]") : string.Empty) + 
					" FROM [stats].[MOMessage] AS [mom] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [stats].[Message] AS [mom_m] ON [mom].[MessageID] = [mom_m].[MessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [mom_m_s] ON [mom_m].[ServiceID] = [mom_m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [mom_m_c] ON [mom_m].[CustomerID] = [mom_m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [mom_m_mo] ON [mom_m].[MobileOperatorID] = [mom_m_mo].[MobileOperatorID] ";
				sqlCmdText += "WHERE [mom].[MOMessageID] = @MOMessageID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MOMessageID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "loadinternal", "notfound"), "MOMessage could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MOMessageTable momTable = new MOMessageTable(query);
				MessageTable mom_mTable = (this.Depth > 0) ? new MessageTable(query) : null;
				ServiceTable mom_m_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CustomerTable mom_m_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				MobileOperatorTable mom_m_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        
				Service mom_m_sObject = (this.Depth > 1) ? mom_m_sTable.CreateInstance() : null;
				Customer mom_m_cObject = (this.Depth > 1) ? mom_m_cTable.CreateInstance() : null;
				MobileOperator mom_m_moObject = (this.Depth > 1) ? mom_m_moTable.CreateInstance() : null;
				Message mom_mObject = (this.Depth > 0) ? mom_mTable.CreateInstance(mom_m_sObject, mom_m_cObject, mom_m_moObject) : null;
				MOMessage momObject = momTable.CreateInstance(mom_mObject);
				sqlReader.Close();

				return momObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "loadinternal", "exception"), "MOMessage could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "MOMessage", "Exception while loading MOMessage object from database. See inner exception for details.", ex);
      }
    }

    public MOMessage Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MOMessageTable.GetColumnNames("[mom]") + 
							(this.Depth > 0 ? "," + MessageTable.GetColumnNames("[mom_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[mom_m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[mom_m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[mom_m_mo]") : string.Empty) +  
					" FROM [stats].[MOMessage] AS [mom] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [stats].[Message] AS [mom_m] ON [mom].[MessageID] = [mom_m].[MessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [mom_m_s] ON [mom_m].[ServiceID] = [mom_m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [mom_m_c] ON [mom_m].[CustomerID] = [mom_m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [mom_m_mo] ON [mom_m].[MobileOperatorID] = [mom_m_mo].[MobileOperatorID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "customload", "notfound"), "MOMessage could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MOMessageTable momTable = new MOMessageTable(query);
				MessageTable mom_mTable = (this.Depth > 0) ? new MessageTable(query) : null;
				ServiceTable mom_m_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CustomerTable mom_m_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				MobileOperatorTable mom_m_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        
				Service mom_m_sObject = (this.Depth > 1) ? mom_m_sTable.CreateInstance() : null;
				Customer mom_m_cObject = (this.Depth > 1) ? mom_m_cTable.CreateInstance() : null;
				MobileOperator mom_m_moObject = (this.Depth > 1) ? mom_m_moTable.CreateInstance() : null;
				Message mom_mObject = (this.Depth > 0) ? mom_mTable.CreateInstance(mom_m_sObject, mom_m_cObject, mom_m_moObject) : null;
				MOMessage momObject = momTable.CreateInstance(mom_mObject);
				sqlReader.Close();

				return momObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "customload", "exception"), "MOMessage could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "MOMessage", "Exception while loading (custom/single) MOMessage object from database. See inner exception for details.", ex);
      }
    }

    public List<MOMessage> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MOMessageTable.GetColumnNames("[mom]") + 
							(this.Depth > 0 ? "," + MessageTable.GetColumnNames("[mom_m]") : string.Empty) + 
							(this.Depth > 1 ? "," + ServiceTable.GetColumnNames("[mom_m_s]") : string.Empty) + 
							(this.Depth > 1 ? "," + CustomerTable.GetColumnNames("[mom_m_c]") : string.Empty) + 
							(this.Depth > 1 ? "," + MobileOperatorTable.GetColumnNames("[mom_m_mo]") : string.Empty) +  
					" FROM [stats].[MOMessage] AS [mom] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [stats].[Message] AS [mom_m] ON [mom].[MessageID] = [mom_m].[MessageID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [core].[Service] AS [mom_m_s] ON [mom_m].[ServiceID] = [mom_m_s].[ServiceID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Customer] AS [mom_m_c] ON [mom_m].[CustomerID] = [mom_m_c].[CustomerID] ";
				if (this.Depth > 1)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[MobileOperator] AS [mom_m_mo] ON [mom_m].[MobileOperatorID] = [mom_m_mo].[MobileOperatorID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "customloadmany", "notfound"), "MOMessage list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<MOMessage>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MOMessageTable momTable = new MOMessageTable(query);
				MessageTable mom_mTable = (this.Depth > 0) ? new MessageTable(query) : null;
				ServiceTable mom_m_sTable = (this.Depth > 1) ? new ServiceTable(query) : null;
				CustomerTable mom_m_cTable = (this.Depth > 1) ? new CustomerTable(query) : null;
				MobileOperatorTable mom_m_moTable = (this.Depth > 1) ? new MobileOperatorTable(query) : null;

        List<MOMessage> result = new List<MOMessage>();
        do
        {
          
					Service mom_m_sObject = (this.Depth > 1) ? mom_m_sTable.CreateInstance() : null;
					Customer mom_m_cObject = (this.Depth > 1) ? mom_m_cTable.CreateInstance() : null;
					MobileOperator mom_m_moObject = (this.Depth > 1) ? mom_m_moTable.CreateInstance() : null;
					Message mom_mObject = (this.Depth > 0) ? mom_mTable.CreateInstance(mom_m_sObject, mom_m_cObject, mom_m_moObject) : null;
					MOMessage momObject = (this.Depth > -1) ? momTable.CreateInstance(mom_mObject) : null;
					result.Add(momObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "customloadmany", "exception"), "MOMessage list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "MOMessage", "Exception while loading (custom/many) MOMessage object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, MOMessage data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [stats].[MOMessage] ([MessageID],[AppID],[From],[Operator],[To],[Keyword],[Tariff],[MessageText],[SmsID]) VALUES(@MessageID,@AppID,@From,@Operator,@To,@Keyword,@Tariff,@MessageText,@SmsID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@MessageID", data.Message.ID);
				sqlCmd.Parameters.AddWithValue("@AppID", !string.IsNullOrEmpty(data.AppID) ? (object)data.AppID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@From", !string.IsNullOrEmpty(data.From) ? (object)data.From : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Operator", !string.IsNullOrEmpty(data.Operator) ? (object)data.Operator : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@To", !string.IsNullOrEmpty(data.To) ? (object)data.To : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Keyword", !string.IsNullOrEmpty(data.Keyword) ? (object)data.Keyword : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Tariff", !string.IsNullOrEmpty(data.Tariff) ? (object)data.Tariff : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@MessageText", !string.IsNullOrEmpty(data.MessageText) ? (object)data.MessageText : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@SmsID", !string.IsNullOrEmpty(data.SmsID) ? (object)data.SmsID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "insert", "noprimarykey"), "MOMessage could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "MOMessage", "Exception while inserting MOMessage object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "insert", "exception"), "MOMessage could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "MOMessage", "Exception while inserting MOMessage object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, MOMessage data)
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
        sqlCmdText = "UPDATE [stats].[MOMessage] SET " +
												"[MessageID] = @MessageID, " + 
												"[AppID] = @AppID, " + 
												"[From] = @From, " + 
												"[Operator] = @Operator, " + 
												"[To] = @To, " + 
												"[Keyword] = @Keyword, " + 
												"[Tariff] = @Tariff, " + 
												"[MessageText] = @MessageText, " + 
												"[SmsID] = @SmsID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [MOMessageID] = @MOMessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@MessageID", data.Message.ID);
				sqlCmd.Parameters.AddWithValue("@AppID", !string.IsNullOrEmpty(data.AppID) ? (object)data.AppID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@From", !string.IsNullOrEmpty(data.From) ? (object)data.From : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Operator", !string.IsNullOrEmpty(data.Operator) ? (object)data.Operator : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@To", !string.IsNullOrEmpty(data.To) ? (object)data.To : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Keyword", !string.IsNullOrEmpty(data.Keyword) ? (object)data.Keyword : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Tariff", !string.IsNullOrEmpty(data.Tariff) ? (object)data.Tariff : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@MessageText", !string.IsNullOrEmpty(data.MessageText) ? (object)data.MessageText : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@SmsID", !string.IsNullOrEmpty(data.SmsID) ? (object)data.SmsID : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@MOMessageID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "update", "norecord"), "MOMessage could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "MOMessage", "Exception while updating MOMessage object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "update", "morerecords"), "MOMessage was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "MOMessage", "Exception while updating MOMessage object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "update", "exception"), "MOMessage could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "MOMessage", "Exception while updating MOMessage object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, MOMessage data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [stats].[MOMessage] WHERE MOMessageID = @MOMessageID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MOMessageID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "delete", "norecord"), "MOMessage could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "MOMessage", "Exception while deleting MOMessage object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("mom", "delete", "exception"), "MOMessage could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "MOMessage", "Exception while deleting MOMessage object from database. See inner exception for details.", ex);
      }
    }
  }
}

