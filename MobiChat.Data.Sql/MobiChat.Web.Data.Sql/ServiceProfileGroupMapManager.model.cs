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
  [DataManager(typeof(ServiceProfileGroupMap))] 
  public partial class ServiceProfileGroupMapManager : MobiChat.Data.Sql.SqlManagerBase<ServiceProfileGroupMap>, IServiceProfileGroupMapManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ServiceProfileGroupMap LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ServiceProfileGroupMapTable.GetColumnNames("[spgm]") + 
							(this.Depth > 0 ? "," + ProfileGroupTable.GetColumnNames("[spgm_pg]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileCategoryTable.GetColumnNames("[spgm_pg_pc]") : string.Empty) + 
					" FROM [web].[ServiceProfileGroupMap] AS [spgm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [spgm_pg] ON [spgm].[ProfileGroupID] = [spgm_pg].[ProfileGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [spgm_pg_pc] ON [spgm_pg].[ProfileCategoryID] = [spgm_pg_pc].[ProfileCategoryID] ";
				sqlCmdText += "WHERE [spgm].[ServiceProfileGroupMapID] = @ServiceProfileGroupMapID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceProfileGroupMapID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "loadinternal", "notfound"), "ServiceProfileGroupMap could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceProfileGroupMapTable spgmTable = new ServiceProfileGroupMapTable(query);
				ProfileGroupTable spgm_pgTable = (this.Depth > 0) ? new ProfileGroupTable(query) : null;
				ProfileCategoryTable spgm_pg_pcTable = (this.Depth > 1) ? new ProfileCategoryTable(query) : null;

        
				ProfileCategory spgm_pg_pcObject = (this.Depth > 1) ? spgm_pg_pcTable.CreateInstance() : null;
				ProfileGroup spgm_pgObject = (this.Depth > 0) ? spgm_pgTable.CreateInstance(spgm_pg_pcObject) : null;
				ServiceProfileGroupMap spgmObject = spgmTable.CreateInstance(spgm_pgObject);
				sqlReader.Close();

				return spgmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "loadinternal", "exception"), "ServiceProfileGroupMap could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceProfileGroupMap", "Exception while loading ServiceProfileGroupMap object from database. See inner exception for details.", ex);
      }
    }

    public ServiceProfileGroupMap Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceProfileGroupMapTable.GetColumnNames("[spgm]") + 
							(this.Depth > 0 ? "," + ProfileGroupTable.GetColumnNames("[spgm_pg]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileCategoryTable.GetColumnNames("[spgm_pg_pc]") : string.Empty) +  
					" FROM [web].[ServiceProfileGroupMap] AS [spgm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [spgm_pg] ON [spgm].[ProfileGroupID] = [spgm_pg].[ProfileGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [spgm_pg_pc] ON [spgm_pg].[ProfileCategoryID] = [spgm_pg_pc].[ProfileCategoryID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "customload", "notfound"), "ServiceProfileGroupMap could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceProfileGroupMapTable spgmTable = new ServiceProfileGroupMapTable(query);
				ProfileGroupTable spgm_pgTable = (this.Depth > 0) ? new ProfileGroupTable(query) : null;
				ProfileCategoryTable spgm_pg_pcTable = (this.Depth > 1) ? new ProfileCategoryTable(query) : null;

        
				ProfileCategory spgm_pg_pcObject = (this.Depth > 1) ? spgm_pg_pcTable.CreateInstance() : null;
				ProfileGroup spgm_pgObject = (this.Depth > 0) ? spgm_pgTable.CreateInstance(spgm_pg_pcObject) : null;
				ServiceProfileGroupMap spgmObject = spgmTable.CreateInstance(spgm_pgObject);
				sqlReader.Close();

				return spgmObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "customload", "exception"), "ServiceProfileGroupMap could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceProfileGroupMap", "Exception while loading (custom/single) ServiceProfileGroupMap object from database. See inner exception for details.", ex);
      }
    }

    public List<ServiceProfileGroupMap> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ServiceProfileGroupMapTable.GetColumnNames("[spgm]") + 
							(this.Depth > 0 ? "," + ProfileGroupTable.GetColumnNames("[spgm_pg]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileCategoryTable.GetColumnNames("[spgm_pg_pc]") : string.Empty) +  
					" FROM [web].[ServiceProfileGroupMap] AS [spgm] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [spgm_pg] ON [spgm].[ProfileGroupID] = [spgm_pg].[ProfileGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [spgm_pg_pc] ON [spgm_pg].[ProfileCategoryID] = [spgm_pg_pc].[ProfileCategoryID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "customloadmany", "notfound"), "ServiceProfileGroupMap list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ServiceProfileGroupMap>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ServiceProfileGroupMapTable spgmTable = new ServiceProfileGroupMapTable(query);
				ProfileGroupTable spgm_pgTable = (this.Depth > 0) ? new ProfileGroupTable(query) : null;
				ProfileCategoryTable spgm_pg_pcTable = (this.Depth > 1) ? new ProfileCategoryTable(query) : null;

        List<ServiceProfileGroupMap> result = new List<ServiceProfileGroupMap>();
        do
        {
          
					ProfileCategory spgm_pg_pcObject = (this.Depth > 1) ? spgm_pg_pcTable.CreateInstance() : null;
					ProfileGroup spgm_pgObject = (this.Depth > 0) ? spgm_pgTable.CreateInstance(spgm_pg_pcObject) : null;
					ServiceProfileGroupMap spgmObject = (this.Depth > -1) ? spgmTable.CreateInstance(spgm_pgObject) : null;
					result.Add(spgmObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "customloadmany", "exception"), "ServiceProfileGroupMap list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ServiceProfileGroupMap", "Exception while loading (custom/many) ServiceProfileGroupMap object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ServiceProfileGroupMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [web].[ServiceProfileGroupMap] ([ServiceID],[ProfileGroupID],[IsActive]) VALUES(@ServiceID,@ProfileGroupID,@IsActive); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.ServiceID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@ProfileGroupID", data.ProfileGroup.ID);
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "insert", "noprimarykey"), "ServiceProfileGroupMap could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ServiceProfileGroupMap", "Exception while inserting ServiceProfileGroupMap object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "insert", "exception"), "ServiceProfileGroupMap could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ServiceProfileGroupMap", "Exception while inserting ServiceProfileGroupMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ServiceProfileGroupMap data)
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
        sqlCmdText = "UPDATE [web].[ServiceProfileGroupMap] SET " +
												"[ServiceID] = @ServiceID, " + 
												"[ProfileGroupID] = @ProfileGroupID, " + 
												"[IsActive] = @IsActive, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ServiceProfileGroupMapID] = @ServiceProfileGroupMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ServiceID", data.ServiceID).SqlDbType = SqlDbType.Int;
				sqlCmd.Parameters.AddWithValue("@ProfileGroupID", data.ProfileGroup.ID);
				sqlCmd.Parameters.AddWithValue("@IsActive", data.IsActive).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ServiceProfileGroupMapID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "update", "norecord"), "ServiceProfileGroupMap could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceProfileGroupMap", "Exception while updating ServiceProfileGroupMap object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "update", "morerecords"), "ServiceProfileGroupMap was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ServiceProfileGroupMap", "Exception while updating ServiceProfileGroupMap object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "update", "exception"), "ServiceProfileGroupMap could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ServiceProfileGroupMap", "Exception while updating ServiceProfileGroupMap object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ServiceProfileGroupMap data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [web].[ServiceProfileGroupMap] WHERE ServiceProfileGroupMapID = @ServiceProfileGroupMapID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ServiceProfileGroupMapID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "delete", "norecord"), "ServiceProfileGroupMap could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ServiceProfileGroupMap", "Exception while deleting ServiceProfileGroupMap object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("spgm", "delete", "exception"), "ServiceProfileGroupMap could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ServiceProfileGroupMap", "Exception while deleting ServiceProfileGroupMap object from database. See inner exception for details.", ex);
      }
    }
  }
}

