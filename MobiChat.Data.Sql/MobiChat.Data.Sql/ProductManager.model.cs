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
  [DataManager(typeof(Product))] 
  public partial class ProductManager : MobiChat.Data.Sql.SqlManagerBase<Product>, IProductManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Product LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ProductTable.GetColumnNames("[p]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[p_i]") : string.Empty) + 
					" FROM [core].[Product] AS [p] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [p_i] ON [p].[InstanceID] = [p_i].[InstanceID] ";
				sqlCmdText += "WHERE [p].[ProductID] = @ProductID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProductID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "loadinternal", "notfound"), "Product could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProductTable pTable = new ProductTable(query);
				InstanceTable p_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        
				Instance p_iObject = (this.Depth > 0) ? p_iTable.CreateInstance() : null;
				Product pObject = pTable.CreateInstance(p_iObject);
				sqlReader.Close();

				return pObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "loadinternal", "exception"), "Product could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Product", "Exception while loading Product object from database. See inner exception for details.", ex);
      }
    }

    public Product Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProductTable.GetColumnNames("[p]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[p_i]") : string.Empty) +  
					" FROM [core].[Product] AS [p] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [p_i] ON [p].[InstanceID] = [p_i].[InstanceID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customload", "notfound"), "Product could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProductTable pTable = new ProductTable(query);
				InstanceTable p_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        
				Instance p_iObject = (this.Depth > 0) ? p_iTable.CreateInstance() : null;
				Product pObject = pTable.CreateInstance(p_iObject);
				sqlReader.Close();

				return pObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customload", "exception"), "Product could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Product", "Exception while loading (custom/single) Product object from database. See inner exception for details.", ex);
      }
    }

    public List<Product> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProductTable.GetColumnNames("[p]") + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[p_i]") : string.Empty) +  
					" FROM [core].[Product] AS [p] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [p_i] ON [p].[InstanceID] = [p_i].[InstanceID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customloadmany", "notfound"), "Product list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Product>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProductTable pTable = new ProductTable(query);
				InstanceTable p_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        List<Product> result = new List<Product>();
        do
        {
          
					Instance p_iObject = (this.Depth > 0) ? p_iTable.CreateInstance() : null;
					Product pObject = (this.Depth > -1) ? pTable.CreateInstance(p_iObject) : null;
					result.Add(pObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customloadmany", "exception"), "Product list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Product", "Exception while loading (custom/many) Product object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Product data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [core].[Product] ([InstanceID],[ProductGuid],[ExternalProductGuid],[Name],[Description]) VALUES(@InstanceID,@ProductGuid,@ExternalProductGuid,@Name,@Description); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@ProductGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ExternalProductGuid", data.ExternalProductGuid);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "insert", "noprimarykey"), "Product could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Product", "Exception while inserting Product object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "insert", "exception"), "Product could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Product", "Exception while inserting Product object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Product data)
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
        sqlCmdText = "UPDATE [core].[Product] SET " +
												"[InstanceID] = @InstanceID, " + 
												"[ProductGuid] = @ProductGuid, " + 
												"[ExternalProductGuid] = @ExternalProductGuid, " + 
												"[Name] = @Name, " + 
												"[Description] = @Description, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ProductID] = @ProductID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@ProductGuid", data.Guid);
				sqlCmd.Parameters.AddWithValue("@ExternalProductGuid", data.ExternalProductGuid);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ProductID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "update", "norecord"), "Product could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Product", "Exception while updating Product object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "update", "morerecords"), "Product was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Product", "Exception while updating Product object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "update", "exception"), "Product could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Product", "Exception while updating Product object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Product data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [core].[Product] WHERE ProductID = @ProductID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProductID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "delete", "norecord"), "Product could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Product", "Exception while deleting Product object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "delete", "exception"), "Product could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Product", "Exception while deleting Product object from database. See inner exception for details.", ex);
      }
    }
  }
}

