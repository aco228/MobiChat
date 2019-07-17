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
  [DataManager(typeof(ProfileDetail))] 
  public partial class ProfileDetailManager : MobiChat.Data.Sql.SqlManagerBase<ProfileDetail>, IProfileDetailManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ProfileDetail LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ProfileDetailTable.GetColumnNames("[pd]") + 
							(this.Depth > 0 ? "," + ProfileTable.GetColumnNames("[pd_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileGroupTable.GetColumnNames("[pd_p_pg]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[pd_l]") : string.Empty) + 
					" FROM [web].[ProfileDetail] AS [pd] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [pd_p] ON [pd].[ProfileID] = [pd_p].[ProfileID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [pd_p_pg] ON [pd_p].[ProfileGroupID] = [pd_p_pg].[ProfileGroupID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [pd_l] ON [pd].[LanguageID] = [pd_l].[LanguageID] ";
				sqlCmdText += "WHERE [pd].[ProfileDetailID] = @ProfileDetailID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileDetailID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "loadinternal", "notfound"), "ProfileDetail could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileDetailTable pdTable = new ProfileDetailTable(query);
				ProfileTable pd_pTable = (this.Depth > 0) ? new ProfileTable(query) : null;
				ProfileGroupTable pd_p_pgTable = (this.Depth > 1) ? new ProfileGroupTable(query) : null;
				LanguageTable pd_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;

        
				ProfileGroup pd_p_pgObject = (this.Depth > 1) ? pd_p_pgTable.CreateInstance() : null;
				Profile pd_pObject = (this.Depth > 0) ? pd_pTable.CreateInstance(pd_p_pgObject) : null;
				Language pd_lObject = (this.Depth > 0) ? pd_lTable.CreateInstance() : null;
				ProfileDetail pdObject = pdTable.CreateInstance(pd_pObject, pd_lObject);
				sqlReader.Close();

				return pdObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "loadinternal", "exception"), "ProfileDetail could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileDetail", "Exception while loading ProfileDetail object from database. See inner exception for details.", ex);
      }
    }

    public ProfileDetail Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileDetailTable.GetColumnNames("[pd]") + 
							(this.Depth > 0 ? "," + ProfileTable.GetColumnNames("[pd_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileGroupTable.GetColumnNames("[pd_p_pg]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[pd_l]") : string.Empty) +  
					" FROM [web].[ProfileDetail] AS [pd] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [pd_p] ON [pd].[ProfileID] = [pd_p].[ProfileID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [pd_p_pg] ON [pd_p].[ProfileGroupID] = [pd_p_pg].[ProfileGroupID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [pd_l] ON [pd].[LanguageID] = [pd_l].[LanguageID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "customload", "notfound"), "ProfileDetail could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileDetailTable pdTable = new ProfileDetailTable(query);
				ProfileTable pd_pTable = (this.Depth > 0) ? new ProfileTable(query) : null;
				ProfileGroupTable pd_p_pgTable = (this.Depth > 1) ? new ProfileGroupTable(query) : null;
				LanguageTable pd_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;

        
				ProfileGroup pd_p_pgObject = (this.Depth > 1) ? pd_p_pgTable.CreateInstance() : null;
				Profile pd_pObject = (this.Depth > 0) ? pd_pTable.CreateInstance(pd_p_pgObject) : null;
				Language pd_lObject = (this.Depth > 0) ? pd_lTable.CreateInstance() : null;
				ProfileDetail pdObject = pdTable.CreateInstance(pd_pObject, pd_lObject);
				sqlReader.Close();

				return pdObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "customload", "exception"), "ProfileDetail could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileDetail", "Exception while loading (custom/single) ProfileDetail object from database. See inner exception for details.", ex);
      }
    }

    public List<ProfileDetail> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileDetailTable.GetColumnNames("[pd]") + 
							(this.Depth > 0 ? "," + ProfileTable.GetColumnNames("[pd_p]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileGroupTable.GetColumnNames("[pd_p_pg]") : string.Empty) + 
							(this.Depth > 0 ? "," + LanguageTable.GetColumnNames("[pd_l]") : string.Empty) +  
					" FROM [web].[ProfileDetail] AS [pd] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [pd_p] ON [pd].[ProfileID] = [pd_p].[ProfileID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[ProfileGroup] AS [pd_p_pg] ON [pd_p].[ProfileGroupID] = [pd_p_pg].[ProfileGroupID] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [core].[Language] AS [pd_l] ON [pd].[LanguageID] = [pd_l].[LanguageID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "customloadmany", "notfound"), "ProfileDetail list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ProfileDetail>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileDetailTable pdTable = new ProfileDetailTable(query);
				ProfileTable pd_pTable = (this.Depth > 0) ? new ProfileTable(query) : null;
				ProfileGroupTable pd_p_pgTable = (this.Depth > 1) ? new ProfileGroupTable(query) : null;
				LanguageTable pd_lTable = (this.Depth > 0) ? new LanguageTable(query) : null;

        List<ProfileDetail> result = new List<ProfileDetail>();
        do
        {
          
					ProfileGroup pd_p_pgObject = (this.Depth > 1) ? pd_p_pgTable.CreateInstance() : null;
					Profile pd_pObject = (this.Depth > 0) ? pd_pTable.CreateInstance(pd_p_pgObject) : null;
					Language pd_lObject = (this.Depth > 0) ? pd_lTable.CreateInstance() : null;
					ProfileDetail pdObject = (this.Depth > -1) ? pdTable.CreateInstance(pd_pObject, pd_lObject) : null;
					result.Add(pdObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "customloadmany", "exception"), "ProfileDetail list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileDetail", "Exception while loading (custom/many) ProfileDetail object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ProfileDetail data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [web].[ProfileDetail] ([ProfileID],[LanguageID],[Name],[Keyword],[Description]) VALUES(@ProfileID,@LanguageID,@Name,@Keyword,@Description); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileID", data.Profile.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Keyword", !string.IsNullOrEmpty(data.Keyword) ? (object)data.Keyword : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "insert", "noprimarykey"), "ProfileDetail could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ProfileDetail", "Exception while inserting ProfileDetail object in database.");
        }
        return (int)((decimal)idObj);
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "insert", "exception"), "ProfileDetail could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ProfileDetail", "Exception while inserting ProfileDetail object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ProfileDetail data)
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
        sqlCmdText = "UPDATE [web].[ProfileDetail] SET " +
												"[ProfileID] = @ProfileID, " + 
												"[LanguageID] = @LanguageID, " + 
												"[Name] = @Name, " + 
												"[Keyword] = @Keyword, " + 
												"[Description] = @Description, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ProfileDetailID] = @ProfileDetailID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileID", data.Profile.ID);
				sqlCmd.Parameters.AddWithValue("@LanguageID", data.Language.ID);
				sqlCmd.Parameters.AddWithValue("@Name", data.Name).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Keyword", !string.IsNullOrEmpty(data.Keyword) ? (object)data.Keyword : DBNull.Value).SqlDbType = SqlDbType.NVarChar;
				sqlCmd.Parameters.AddWithValue("@Description", !string.IsNullOrEmpty(data.Description) ? (object)data.Description : DBNull.Value).SqlDbType = SqlDbType.NText;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ProfileDetailID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "update", "norecord"), "ProfileDetail could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileDetail", "Exception while updating ProfileDetail object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "update", "morerecords"), "ProfileDetail was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileDetail", "Exception while updating ProfileDetail object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "update", "exception"), "ProfileDetail could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ProfileDetail", "Exception while updating ProfileDetail object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ProfileDetail data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [web].[ProfileDetail] WHERE ProfileDetailID = @ProfileDetailID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileDetailID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "delete", "norecord"), "ProfileDetail could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ProfileDetail", "Exception while deleting ProfileDetail object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("pd", "delete", "exception"), "ProfileDetail could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ProfileDetail", "Exception while deleting ProfileDetail object from database. See inner exception for details.", ex);
      }
    }
  }
}

