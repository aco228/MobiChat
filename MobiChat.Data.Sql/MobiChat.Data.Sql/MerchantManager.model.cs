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
  [DataManager(typeof(Merchant))] 
  public partial class MerchantManager : MobiChat.Data.Sql.SqlManagerBase<Merchant>, IMerchantManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Merchant LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							MerchantTable.GetColumnNames("[m]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[m_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + TemplateTable.GetColumnNames("[m_t]") : string.Empty) + 
					" FROM [core].[Merchant] AS [m] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [m_i] ON [m].[InstanceID] = [m_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [m_t] ON [m].[TemplateID] = [m_t].[TemplateID] ";
				sqlCmdText += "WHERE [m].[MerchantID] = @MerchantID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MerchantID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "loadinternal", "notfound"), "Merchant could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MerchantTable mTable = new MerchantTable(query);
				InstanceTable m_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;
				TemplateTable m_tTable = (this.Depth > 0) ? new TemplateTable(query) : null;

        
				Instance m_iObject = (this.Depth > 0) ? m_iTable.CreateInstance() : null;
				Template m_tObject = (this.Depth > 0) ? m_tTable.CreateInstance() : null;
				Merchant mObject = mTable.CreateInstance(m_iObject, m_tObject);
				sqlReader.Close();

				return mObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "loadinternal", "exception"), "Merchant could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Merchant", "Exception while loading Merchant object from database. See inner exception for details.", ex);
      }
    }

    public Merchant Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MerchantTable.GetColumnNames("[m]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[m_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + TemplateTable.GetColumnNames("[m_t]") : string.Empty) +  
					" FROM [core].[Merchant] AS [m] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [m_i] ON [m].[InstanceID] = [m_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [m_t] ON [m].[TemplateID] = [m_t].[TemplateID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customload", "notfound"), "Merchant could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MerchantTable mTable = new MerchantTable(query);
				InstanceTable m_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;
				TemplateTable m_tTable = (this.Depth > 0) ? new TemplateTable(query) : null;

        
				Instance m_iObject = (this.Depth > 0) ? m_iTable.CreateInstance() : null;
				Template m_tObject = (this.Depth > 0) ? m_tTable.CreateInstance() : null;
				Merchant mObject = mTable.CreateInstance(m_iObject, m_tObject);
				sqlReader.Close();

				return mObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customload", "exception"), "Merchant could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Merchant", "Exception while loading (custom/single) Merchant object from database. See inner exception for details.", ex);
      }
    }

    public List<Merchant> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							MerchantTable.GetColumnNames("[m]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[m_i]") : string.Empty) + 
							(this.Depth > 0 ? "," + TemplateTable.GetColumnNames("[m_t]") : string.Empty) +  
					" FROM [core].[Merchant] AS [m] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [m_i] ON [m].[InstanceID] = [m_i].[InstanceID] ";
				if (this.Depth > 0)
				  sqlCmdText += "LEFT OUTER  JOIN [core].[Template] AS [m_t] ON [m].[TemplateID] = [m_t].[TemplateID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customloadmany", "notfound"), "Merchant list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Merchant>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				MerchantTable mTable = new MerchantTable(query);
				InstanceTable m_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;
				TemplateTable m_tTable = (this.Depth > 0) ? new TemplateTable(query) : null;

        List<Merchant> result = new List<Merchant>();
        do
        {
          
					Instance m_iObject = (this.Depth > 0) ? m_iTable.CreateInstance() : null;
					Template m_tObject = (this.Depth > 0) ? m_tTable.CreateInstance() : null;
					Merchant mObject = (this.Depth > -1) ? mTable.CreateInstance(m_iObject, m_tObject) : null;
					result.Add(mObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "customloadmany", "exception"), "Merchant list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Merchant", "Exception while loading (custom/many) Merchant object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Merchant data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Merchant] ([InstanceID],[TemplateID],[Name],[Address],[Phone],[Email],[RegistrationNo],[VatNo]) VALUES(@InstanceID,@TemplateID,@Name,@Address,@Phone,@Email,@RegistrationNo,@VatNo); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@TemplateID", data.Template == null ? DBNull.Value : (object)data.Template.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Address", !string.IsNullOrEmpty(data.Address) ? (object)data.Address : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Phone", !string.IsNullOrEmpty(data.Phone) ? (object)data.Phone : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(data.Email) ? (object)data.Email : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@RegistrationNo", !string.IsNullOrEmpty(data.RegistrationNo) ? (object)data.RegistrationNo : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@VatNo", !string.IsNullOrEmpty(data.VatNo) ? (object)data.VatNo : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "insert", "noprimarykey"), "Merchant could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Merchant", "Exception while inserting Merchant object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "insert", "exception"), "Merchant could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Merchant", "Exception while inserting Merchant object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Merchant data)
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
        sqlCmdText = "UPDATE [core].[Merchant] SET " +
												"[InstanceID] = @InstanceID, " + 
												"[TemplateID] = @TemplateID, " + 
												"[Name] = @Name, " + 
												"[Address] = @Address, " + 
												"[Phone] = @Phone, " + 
												"[Email] = @Email, " + 
												"[RegistrationNo] = @RegistrationNo, " + 
												"[VatNo] = @VatNo, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [MerchantID] = @MerchantID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@TemplateID", data.Template == null ? DBNull.Value : (object)data.Template.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Address", !string.IsNullOrEmpty(data.Address) ? (object)data.Address : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Phone", !string.IsNullOrEmpty(data.Phone) ? (object)data.Phone : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(data.Email) ? (object)data.Email : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@RegistrationNo", !string.IsNullOrEmpty(data.RegistrationNo) ? (object)data.RegistrationNo : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@VatNo", !string.IsNullOrEmpty(data.VatNo) ? (object)data.VatNo : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@MerchantID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "update", "norecord"), "Merchant could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Merchant", "Exception while updating Merchant object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "update", "morerecords"), "Merchant was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Merchant", "Exception while updating Merchant object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "update", "exception"), "Merchant could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Merchant", "Exception while updating Merchant object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Merchant data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Merchant] WHERE MerchantID = @MerchantID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@MerchantID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "delete", "norecord"), "Merchant could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Merchant", "Exception while deleting Merchant object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("m", "delete", "exception"), "Merchant could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Merchant", "Exception while deleting Merchant object from database. See inner exception for details.", ex);
      }
    }
  }
}

