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
  [DataManager(typeof(ProfileGroup))] 
  public partial class ProfileGroupManager : MobiChat.Data.Sql.SqlManagerBase<ProfileGroup>, IProfileGroupManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ProfileGroup LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ProfileGroupTable.GetColumnNames("[pg]") + 
							(this.Depth > 0 ? "," + ProfileCategoryTable.GetColumnNames("[pg_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[pg_i]") : string.Empty) + 
					" FROM [web].[ProfileGroup] AS [pg] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [pg_pc] ON [pg].[ProfileCategoryID] = [pg_pc].[ProfileCategoryID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [pg_i] ON [pg].[InstanceID] = [pg_i].[InstanceID] ";
				sqlCmdText += "WHERE [pg].[ProfileGroupID] = @ProfileGroupID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileGroupID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "loadinternal", "notfound"), "ProfileGroup could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileGroupTable pgTable = new ProfileGroupTable(query);
				ProfileCategoryTable pg_pcTable = (this.Depth > 0) ? new ProfileCategoryTable(query) : null;
				InstanceTable pg_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        
				ProfileCategory pg_pcObject = (this.Depth > 0) ? pg_pcTable.CreateInstance() : null;
				Instance pg_iObject = (this.Depth > 0) ? pg_iTable.CreateInstance() : null;
				ProfileGroup pgObject = pgTable.CreateInstance(pg_pcObject, pg_iObject);
				sqlReader.Close();

				return pgObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "loadinternal", "exception"), "ProfileGroup could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileGroup", "Exception while loading ProfileGroup object from database. See inner exception for details.", ex);
      }
    }

    public ProfileGroup Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileGroupTable.GetColumnNames("[pg]") + 
							(this.Depth > 0 ? "," + ProfileCategoryTable.GetColumnNames("[pg_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[pg_i]") : string.Empty) +  
					" FROM [web].[ProfileGroup] AS [pg] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [pg_pc] ON [pg].[ProfileCategoryID] = [pg_pc].[ProfileCategoryID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [pg_i] ON [pg].[InstanceID] = [pg_i].[InstanceID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "customload", "notfound"), "ProfileGroup could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileGroupTable pgTable = new ProfileGroupTable(query);
				ProfileCategoryTable pg_pcTable = (this.Depth > 0) ? new ProfileCategoryTable(query) : null;
				InstanceTable pg_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        
				ProfileCategory pg_pcObject = (this.Depth > 0) ? pg_pcTable.CreateInstance() : null;
				Instance pg_iObject = (this.Depth > 0) ? pg_iTable.CreateInstance() : null;
				ProfileGroup pgObject = pgTable.CreateInstance(pg_pcObject, pg_iObject);
				sqlReader.Close();

				return pgObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "customload", "exception"), "ProfileGroup could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileGroup", "Exception while loading (custom/single) ProfileGroup object from database. See inner exception for details.", ex);
      }
    }

    public List<ProfileGroup> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileGroupTable.GetColumnNames("[pg]") + 
							(this.Depth > 0 ? "," + ProfileCategoryTable.GetColumnNames("[pg_pc]") : string.Empty) + 
							(this.Depth > 0 ? "," + InstanceTable.GetColumnNames("[pg_i]") : string.Empty) +  
					" FROM [web].[ProfileGroup] AS [pg] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [pg_pc] ON [pg].[ProfileCategoryID] = [pg_pc].[ProfileCategoryID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Instance] AS [pg_i] ON [pg].[InstanceID] = [pg_i].[InstanceID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "customloadmany", "notfound"), "ProfileGroup list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ProfileGroup>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileGroupTable pgTable = new ProfileGroupTable(query);
				ProfileCategoryTable pg_pcTable = (this.Depth > 0) ? new ProfileCategoryTable(query) : null;
				InstanceTable pg_iTable = (this.Depth > 0) ? new InstanceTable(query) : null;

        List<ProfileGroup> result = new List<ProfileGroup>();
        do
        {
          
					ProfileCategory pg_pcObject = (this.Depth > 0) ? pg_pcTable.CreateInstance() : null;
					Instance pg_iObject = (this.Depth > 0) ? pg_iTable.CreateInstance() : null;
					ProfileGroup pgObject = (this.Depth > -1) ? pgTable.CreateInstance(pg_pcObject, pg_iObject) : null;
					result.Add(pgObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "customloadmany", "exception"), "ProfileGroup list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileGroup", "Exception while loading (custom/many) ProfileGroup object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ProfileGroup data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [web].[ProfileGroup] ([ProfileCategoryID],[InstanceID],[Name],[Description]) VALUES(@ProfileCategoryID,@InstanceID,@Name,@Description); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileCategoryID", data.ProfileCategory.ID);
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "insert", "noprimarykey"), "ProfileGroup could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ProfileGroup", "Exception while inserting ProfileGroup object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "insert", "exception"), "ProfileGroup could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ProfileGroup", "Exception while inserting ProfileGroup object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ProfileGroup data)
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
        sqlCmdText = "UPDATE [web].[ProfileGroup] SET " +
												"[ProfileCategoryID] = @ProfileCategoryID, " + 
												"[InstanceID] = @InstanceID, " + 
												"[Name] = @Name, " + 
												"[Description] = @Description, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ProfileGroupID] = @ProfileGroupID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileCategoryID", data.ProfileCategory.ID);
				sqlCmd.Parameters.AddWithValue("@InstanceID", data.Instance.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ProfileGroupID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "update", "norecord"), "ProfileGroup could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileGroup", "Exception while updating ProfileGroup object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "update", "morerecords"), "ProfileGroup was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileGroup", "Exception while updating ProfileGroup object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "update", "exception"), "ProfileGroup could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ProfileGroup", "Exception while updating ProfileGroup object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ProfileGroup data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [web].[ProfileGroup] WHERE ProfileGroupID = @ProfileGroupID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileGroupID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "delete", "norecord"), "ProfileGroup could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ProfileGroup", "Exception while deleting ProfileGroup object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pg", "delete", "exception"), "ProfileGroup could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ProfileGroup", "Exception while deleting ProfileGroup object from database. See inner exception for details.", ex);
      }
    }
  }
}

