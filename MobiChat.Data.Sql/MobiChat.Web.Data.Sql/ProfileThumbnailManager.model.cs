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
  [DataManager(typeof(ProfileThumbnail))] 
  public partial class ProfileThumbnailManager : MobiChat.Data.Sql.SqlManagerBase<ProfileThumbnail>, IProfileThumbnailManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ProfileThumbnail LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ProfileThumbnailTable.GetColumnNames("[pt]") + 
							(this.Depth > 0 ? "," + ProfileTable.GetColumnNames("[pt_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileGroupTable.GetColumnNames("[pt_p_pg]") : string.Empty) + 
					" FROM [web].[ProfileThumbnail] AS [pt] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [pt_p] ON [pt].[ProfileID] = [pt_p].[ProfileID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [pt_p_pg] ON [pt_p].[ProfileGroupID] = [pt_p_pg].[ProfileGroupID] ";
				sqlCmdText += "WHERE [pt].[ProfileThumbnailID] = @ProfileThumbnailID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileThumbnailID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "loadinternal", "notfound"), "ProfileThumbnail could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileThumbnailTable ptTable = new ProfileThumbnailTable(query);
				ProfileTable pt_pTable = (this.Depth > 0) ? new ProfileTable(query) : null;
				ProfileGroupTable pt_p_pgTable = (this.Depth > 1) ? new ProfileGroupTable(query) : null;

        
				ProfileGroup pt_p_pgObject = (this.Depth > 1) ? pt_p_pgTable.CreateInstance() : null;
				Profile pt_pObject = (this.Depth > 0) ? pt_pTable.CreateInstance(pt_p_pgObject) : null;
				ProfileThumbnail ptObject = ptTable.CreateInstance(pt_pObject);
				sqlReader.Close();

				return ptObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "loadinternal", "exception"), "ProfileThumbnail could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileThumbnail", "Exception while loading ProfileThumbnail object from database. See inner exception for details.", ex);
      }
    }

    public ProfileThumbnail Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileThumbnailTable.GetColumnNames("[pt]") + 
							(this.Depth > 0 ? "," + ProfileTable.GetColumnNames("[pt_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileGroupTable.GetColumnNames("[pt_p_pg]") : string.Empty) +  
					" FROM [web].[ProfileThumbnail] AS [pt] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [pt_p] ON [pt].[ProfileID] = [pt_p].[ProfileID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [pt_p_pg] ON [pt_p].[ProfileGroupID] = [pt_p_pg].[ProfileGroupID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "customload", "notfound"), "ProfileThumbnail could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileThumbnailTable ptTable = new ProfileThumbnailTable(query);
				ProfileTable pt_pTable = (this.Depth > 0) ? new ProfileTable(query) : null;
				ProfileGroupTable pt_p_pgTable = (this.Depth > 1) ? new ProfileGroupTable(query) : null;

        
				ProfileGroup pt_p_pgObject = (this.Depth > 1) ? pt_p_pgTable.CreateInstance() : null;
				Profile pt_pObject = (this.Depth > 0) ? pt_pTable.CreateInstance(pt_p_pgObject) : null;
				ProfileThumbnail ptObject = ptTable.CreateInstance(pt_pObject);
				sqlReader.Close();

				return ptObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "customload", "exception"), "ProfileThumbnail could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileThumbnail", "Exception while loading (custom/single) ProfileThumbnail object from database. See inner exception for details.", ex);
      }
    }

    public List<ProfileThumbnail> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileThumbnailTable.GetColumnNames("[pt]") + 
							(this.Depth > 0 ? "," + ProfileTable.GetColumnNames("[pt_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileGroupTable.GetColumnNames("[pt_p_pg]") : string.Empty) +  
					" FROM [web].[ProfileThumbnail] AS [pt] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [pt_p] ON [pt].[ProfileID] = [pt_p].[ProfileID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [pt_p_pg] ON [pt_p].[ProfileGroupID] = [pt_p_pg].[ProfileGroupID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "customloadmany", "notfound"), "ProfileThumbnail list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ProfileThumbnail>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileThumbnailTable ptTable = new ProfileThumbnailTable(query);
				ProfileTable pt_pTable = (this.Depth > 0) ? new ProfileTable(query) : null;
				ProfileGroupTable pt_p_pgTable = (this.Depth > 1) ? new ProfileGroupTable(query) : null;

        List<ProfileThumbnail> result = new List<ProfileThumbnail>();
        do
        {
          
					ProfileGroup pt_p_pgObject = (this.Depth > 1) ? pt_p_pgTable.CreateInstance() : null;
					Profile pt_pObject = (this.Depth > 0) ? pt_pTable.CreateInstance(pt_p_pgObject) : null;
					ProfileThumbnail ptObject = (this.Depth > -1) ? ptTable.CreateInstance(pt_pObject) : null;
					result.Add(ptObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "customloadmany", "exception"), "ProfileThumbnail list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileThumbnail", "Exception while loading (custom/many) ProfileThumbnail object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ProfileThumbnail data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [web].[ProfileThumbnail] ([ProfileID],[IsDefault]) VALUES(@ProfileID,@IsDefault); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileID", data.Profile.ID);
				sqlCmd.Parameters.AddWithValue("@IsDefault", data.IsDefault.HasValue ? (object)data.IsDefault.Value : DBNull.Value).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "insert", "noprimarykey"), "ProfileThumbnail could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ProfileThumbnail", "Exception while inserting ProfileThumbnail object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "insert", "exception"), "ProfileThumbnail could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ProfileThumbnail", "Exception while inserting ProfileThumbnail object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ProfileThumbnail data)
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
        sqlCmdText = "UPDATE [web].[ProfileThumbnail] SET " +
												"[ProfileID] = @ProfileID, " + 
												"[IsDefault] = @IsDefault, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ProfileThumbnailID] = @ProfileThumbnailID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileID", data.Profile.ID);
				sqlCmd.Parameters.AddWithValue("@IsDefault", data.IsDefault.HasValue ? (object)data.IsDefault.Value : DBNull.Value).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ProfileThumbnailID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "update", "norecord"), "ProfileThumbnail could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileThumbnail", "Exception while updating ProfileThumbnail object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "update", "morerecords"), "ProfileThumbnail was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileThumbnail", "Exception while updating ProfileThumbnail object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "update", "exception"), "ProfileThumbnail could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ProfileThumbnail", "Exception while updating ProfileThumbnail object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ProfileThumbnail data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [web].[ProfileThumbnail] WHERE ProfileThumbnailID = @ProfileThumbnailID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileThumbnailID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "delete", "norecord"), "ProfileThumbnail could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ProfileThumbnail", "Exception while deleting ProfileThumbnail object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pt", "delete", "exception"), "ProfileThumbnail could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ProfileThumbnail", "Exception while deleting ProfileThumbnail object from database. See inner exception for details.", ex);
      }
    }
  }
}

