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
  [DataManager(typeof(PaymentCredentials))] 
  public partial class PaymentCredentialsManager : MobiChat.Data.Sql.SqlManagerBase<PaymentCredentials>, IPaymentCredentialsManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override PaymentCredentials LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							PaymentCredentialsTable.GetColumnNames("[pc]") + 
					" FROM [core].[PaymentCredentials] AS [pc] ";
				sqlCmdText += "WHERE [pc].[PaymentCredentialsID] = @PaymentCredentialsID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@PaymentCredentialsID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "loadinternal", "notfound"), "PaymentCredentials could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				PaymentCredentialsTable pcTable = new PaymentCredentialsTable(query);

        
				PaymentCredentials pcObject = pcTable.CreateInstance();
				sqlReader.Close();

				return pcObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "loadinternal", "exception"), "PaymentCredentials could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "PaymentCredentials", "Exception while loading PaymentCredentials object from database. See inner exception for details.", ex);
      }
    }

    public PaymentCredentials Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							PaymentCredentialsTable.GetColumnNames("[pc]")  + 
					" FROM [core].[PaymentCredentials] AS [pc] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customload", "notfound"), "PaymentCredentials could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				PaymentCredentialsTable pcTable = new PaymentCredentialsTable(query);

        
				PaymentCredentials pcObject = pcTable.CreateInstance();
				sqlReader.Close();

				return pcObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customload", "exception"), "PaymentCredentials could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "PaymentCredentials", "Exception while loading (custom/single) PaymentCredentials object from database. See inner exception for details.", ex);
      }
    }

    public List<PaymentCredentials> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							PaymentCredentialsTable.GetColumnNames("[pc]")  + 
					" FROM [core].[PaymentCredentials] AS [pc] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customloadmany", "notfound"), "PaymentCredentials list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<PaymentCredentials>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				PaymentCredentialsTable pcTable = new PaymentCredentialsTable(query);

        List<PaymentCredentials> result = new List<PaymentCredentials>();
        do
        {
          
					PaymentCredentials pcObject = (this.Depth > -1) ? pcTable.CreateInstance() : null;
					result.Add(pcObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "customloadmany", "exception"), "PaymentCredentials list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "PaymentCredentials", "Exception while loading (custom/many) PaymentCredentials object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, PaymentCredentials data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[PaymentCredentials] ([Username],[Password]) VALUES(@Username,@Password); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@Username", data.Username).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Password", data.Password).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "insert", "noprimarykey"), "PaymentCredentials could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "PaymentCredentials", "Exception while inserting PaymentCredentials object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "insert", "exception"), "PaymentCredentials could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "PaymentCredentials", "Exception while inserting PaymentCredentials object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, PaymentCredentials data)
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
        sqlCmdText = "UPDATE [core].[PaymentCredentials] SET " +
												"[Username] = @Username, " + 
												"[Password] = @Password, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [PaymentCredentialsID] = @PaymentCredentialsID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@Username", data.Username).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Password", data.Password).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@PaymentCredentialsID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "update", "norecord"), "PaymentCredentials could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "PaymentCredentials", "Exception while updating PaymentCredentials object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "update", "morerecords"), "PaymentCredentials was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "PaymentCredentials", "Exception while updating PaymentCredentials object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "update", "exception"), "PaymentCredentials could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "PaymentCredentials", "Exception while updating PaymentCredentials object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, PaymentCredentials data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[PaymentCredentials] WHERE PaymentCredentialsID = @PaymentCredentialsID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@PaymentCredentialsID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "delete", "norecord"), "PaymentCredentials could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "PaymentCredentials", "Exception while deleting PaymentCredentials object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pc", "delete", "exception"), "PaymentCredentials could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "PaymentCredentials", "Exception while deleting PaymentCredentials object from database. See inner exception for details.", ex);
      }
    }
  }
}

