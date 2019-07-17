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
  [DataManager(typeof(Profile))] 
  public partial class ProfileManager : MobiChat.Data.Sql.SqlManagerBase<Profile>, IProfileManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override Profile LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ProfileTable.GetColumnNames("[p]") + 
							(this.Depth > 0 ? "," + ProfileGroupTable.GetColumnNames("[p_pg]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileCategoryTable.GetColumnNames("[p_pg_pc]") : string.Empty) + 
					" FROM [web].[Profile] AS [p] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [p_pg] ON [p].[ProfileGroupID] = [p_pg].[ProfileGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [p_pg_pc] ON [p_pg].[ProfileCategoryID] = [p_pg_pc].[ProfileCategoryID] ";
				sqlCmdText += "WHERE [p].[ProfileID] = @ProfileID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "loadinternal", "notfound"), "Profile could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileTable pTable = new ProfileTable(query);
				ProfileGroupTable p_pgTable = (this.Depth > 0) ? new ProfileGroupTable(query) : null;
				ProfileCategoryTable p_pg_pcTable = (this.Depth > 1) ? new ProfileCategoryTable(query) : null;

        
				ProfileCategory p_pg_pcObject = (this.Depth > 1) ? p_pg_pcTable.CreateInstance() : null;
				ProfileGroup p_pgObject = (this.Depth > 0) ? p_pgTable.CreateInstance(p_pg_pcObject) : null;
				Profile pObject = pTable.CreateInstance(p_pgObject);
				sqlReader.Close();

				return pObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "loadinternal", "exception"), "Profile could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Profile", "Exception while loading Profile object from database. See inner exception for details.", ex);
      }
    }

    public Profile Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileTable.GetColumnNames("[p]") + 
							(this.Depth > 0 ? "," + ProfileGroupTable.GetColumnNames("[p_pg]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileCategoryTable.GetColumnNames("[p_pg_pc]") : string.Empty) +  
					" FROM [web].[Profile] AS [p] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [p_pg] ON [p].[ProfileGroupID] = [p_pg].[ProfileGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [p_pg_pc] ON [p_pg].[ProfileCategoryID] = [p_pg_pc].[ProfileCategoryID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customload", "notfound"), "Profile could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileTable pTable = new ProfileTable(query);
				ProfileGroupTable p_pgTable = (this.Depth > 0) ? new ProfileGroupTable(query) : null;
				ProfileCategoryTable p_pg_pcTable = (this.Depth > 1) ? new ProfileCategoryTable(query) : null;

        
				ProfileCategory p_pg_pcObject = (this.Depth > 1) ? p_pg_pcTable.CreateInstance() : null;
				ProfileGroup p_pgObject = (this.Depth > 0) ? p_pgTable.CreateInstance(p_pg_pcObject) : null;
				Profile pObject = pTable.CreateInstance(p_pgObject);
				sqlReader.Close();

				return pObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customload", "exception"), "Profile could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Profile", "Exception while loading (custom/single) Profile object from database. See inner exception for details.", ex);
      }
    }

    public List<Profile> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileTable.GetColumnNames("[p]") + 
							(this.Depth > 0 ? "," + ProfileGroupTable.GetColumnNames("[p_pg]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileCategoryTable.GetColumnNames("[p_pg_pc]") : string.Empty) +  
					" FROM [web].[Profile] AS [p] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [p_pg] ON [p].[ProfileGroupID] = [p_pg].[ProfileGroupID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileCategory] AS [p_pg_pc] ON [p_pg].[ProfileCategoryID] = [p_pg_pc].[ProfileCategoryID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customloadmany", "notfound"), "Profile list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<Profile>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileTable pTable = new ProfileTable(query);
				ProfileGroupTable p_pgTable = (this.Depth > 0) ? new ProfileGroupTable(query) : null;
				ProfileCategoryTable p_pg_pcTable = (this.Depth > 1) ? new ProfileCategoryTable(query) : null;

        List<Profile> result = new List<Profile>();
        do
        {
          
					ProfileCategory p_pg_pcObject = (this.Depth > 1) ? p_pg_pcTable.CreateInstance() : null;
					ProfileGroup p_pgObject = (this.Depth > 0) ? p_pgTable.CreateInstance(p_pg_pcObject) : null;
					Profile pObject = (this.Depth > -1) ? pTable.CreateInstance(p_pgObject) : null;
					result.Add(pObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "customloadmany", "exception"), "Profile list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "Profile", "Exception while loading (custom/many) Profile object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, Profile data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [web].[Profile] ([ProfileGroupID]) VALUES(@ProfileGroupID); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileGroupID", data.ProfileGroup.ID);
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "insert", "noprimarykey"), "Profile could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "Profile", "Exception while inserting Profile object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "insert", "exception"), "Profile could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "Profile", "Exception while inserting Profile object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, Profile data)
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
        sqlCmdText = "UPDATE [web].[Profile] SET " +
												"[ProfileGroupID] = @ProfileGroupID, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ProfileID] = @ProfileID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileGroupID", data.ProfileGroup.ID);
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ProfileID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "update", "norecord"), "Profile could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Profile", "Exception while updating Profile object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "update", "morerecords"), "Profile was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "Profile", "Exception while updating Profile object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "update", "exception"), "Profile could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "Profile", "Exception while updating Profile object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, Profile data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [web].[Profile] WHERE ProfileID = @ProfileID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "delete", "norecord"), "Profile could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "Profile", "Exception while deleting Profile object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("p", "delete", "exception"), "Profile could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "Profile", "Exception while deleting Profile object from database. See inner exception for details.", ex);
      }
    }
  }
}

