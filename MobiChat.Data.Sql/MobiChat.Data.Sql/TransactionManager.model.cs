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
  [DataManager(typeof(Transaction))] 
  public partial class TransactionManager : MobiChat.Data.Sql.SqlManagerBase<Transaction>, ITransactionManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Transaction LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							TransactionTable.GetColumnNames("[t]") + 
					" FROM [core].[Transaction] AS [t] ";
				sqlCmdText += "WHERE [t].[TransactionID] = @TransactionID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TransactionID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "loadinternal", "notfound"), "Transaction could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TransactionTable tTable = new TransactionTable(query);

        
				Transaction tObject = tTable.CreateInstance();
				sqlReader.Close();

				return tObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "loadinternal", "exception"), "Transaction could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Transaction", "Exception while loading Transaction object from database. See inner exception for details.", ex);
      }
    }

    public Transaction Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TransactionTable.GetColumnNames("[t]")  + 
					" FROM [core].[Transaction] AS [t] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customload", "notfound"), "Transaction could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TransactionTable tTable = new TransactionTable(query);

        
				Transaction tObject = tTable.CreateInstance();
				sqlReader.Close();

				return tObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customload", "exception"), "Transaction could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Transaction", "Exception while loading (custom/single) Transaction object from database. See inner exception for details.", ex);
      }
    }

    public List<Transaction> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							TransactionTable.GetColumnNames("[t]")  + 
					" FROM [core].[Transaction] AS [t] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customloadmany", "notfound"), "Transaction list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Transaction>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				TransactionTable tTable = new TransactionTable(query);

        List<Transaction> result = new List<Transaction>();
        do
        {
          
					Transaction tObject = (this.Depth > -1) ? tTable.CreateInstance() : null;
					result.Add(tObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "customloadmany", "exception"), "Transaction list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Transaction", "Exception while loading (custom/many) Transaction object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Transaction data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Transaction] ([TransactionGuid],[ExternalTransactionGuid],[ExternalPurchaseGuid],[ExternalTransactionGroupGuid],[TransactionStatusID],[TransactionTypeID]) VALUES(@TransactionGuid,@ExternalTransactionGuid,@ExternalPurchaseGuid,@ExternalTransactionGroupGuid,@TransactionStatusID,@TransactionTypeID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TransactionGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ExternalTransactionGuid", data.ExternalTransactionGuid);
				sqlCmd.Parameters.AddWithValue("@ExternalPurchaseGuid", data.ExternalPurchaseGuid);
				sqlCmd.Parameters.AddWithValue("@ExternalTransactionGroupGuid", data.ExternalTransactionGroupGuid);
				sqlCmd.Parameters.AddWithValue("@TransactionStatusID", (int)data.TransactionStatus);
				sqlCmd.Parameters.AddWithValue("@TransactionTypeID", (int)data.TransactionType);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "insert", "noprimarykey"), "Transaction could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Transaction", "Exception while inserting Transaction object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "insert", "exception"), "Transaction could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Transaction", "Exception while inserting Transaction object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Transaction data)
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
        sqlCmdText = "UPDATE [core].[Transaction] SET " +
												"[TransactionGuid] = @TransactionGuid, " + 
												"[ExternalTransactionGuid] = @ExternalTransactionGuid, " + 
												"[ExternalPurchaseGuid] = @ExternalPurchaseGuid, " + 
												"[ExternalTransactionGroupGuid] = @ExternalTransactionGroupGuid, " + 
												"[TransactionStatusID] = @TransactionStatusID, " + 
												"[TransactionTypeID] = @TransactionTypeID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [TransactionID] = @TransactionID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@TransactionGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ExternalTransactionGuid", data.ExternalTransactionGuid);
				sqlCmd.Parameters.AddWithValue("@ExternalPurchaseGuid", data.ExternalPurchaseGuid);
				sqlCmd.Parameters.AddWithValue("@ExternalTransactionGroupGuid", data.ExternalTransactionGroupGuid);
				sqlCmd.Parameters.AddWithValue("@TransactionStatusID", (int)data.TransactionStatus);
				sqlCmd.Parameters.AddWithValue("@TransactionTypeID", (int)data.TransactionType);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@TransactionID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "update", "norecord"), "Transaction could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Transaction", "Exception while updating Transaction object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "update", "morerecords"), "Transaction was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Transaction", "Exception while updating Transaction object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "update", "exception"), "Transaction could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Transaction", "Exception while updating Transaction object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Transaction data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Transaction] WHERE TransactionID = @TransactionID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@TransactionID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "delete", "norecord"), "Transaction could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Transaction", "Exception while deleting Transaction object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("t", "delete", "exception"), "Transaction could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Transaction", "Exception while deleting Transaction object from database. See inner exception for details.", ex);
      }
    }
  }
}

