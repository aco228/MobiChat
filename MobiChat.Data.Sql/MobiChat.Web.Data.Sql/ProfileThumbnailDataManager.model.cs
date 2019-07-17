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
using System.IO;



namespace MobiChat.Web.Data.Sql
{
  [DataManager(typeof(ProfileThumbnailData))] 
  public partial class ProfileThumbnailDataManager : MobiChat.Data.Sql.SqlManagerBase<ProfileThumbnailData>, IProfileThumbnailDataManager
  {
    public override DatabaseType Type
    {
      get { return DatabaseType.MobiChat; }
    }

    protected override ProfileThumbnailData LoadInternal(ISqlConnectionInfo connection, int id)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "SELECT " + 
							ProfileThumbnailDataTable.GetColumnNames("[ptd]") + 
							(this.Depth > 0 ? "," + ProfileThumbnailTable.GetColumnNames("[ptd_pt]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileTable.GetColumnNames("[ptd_pt_p]") : string.Empty) + 
					" FROM [web].[ProfileThumbnailData] AS [ptd] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileThumbnail] AS [ptd_pt] ON [ptd].[ProfileThumbnailID] = [ptd_pt].[ProfileThumbnailID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [ptd_pt_p] ON [ptd_pt].[ProfileID] = [ptd_pt_p].[ProfileID] ";
				sqlCmdText += "WHERE [ptd].[ProfileThumbnailDataID] = @ProfileThumbnailDataID;";

        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileThumbnailDataID", id);
        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "loadinternal", "notfound"), "ProfileThumbnailData could not be loaded by id as it was not found.", sqlCmdText, this, connection, id);
          if (this.Logger.IsWarnEnabled)
            this.Logger.Warn(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileThumbnailDataTable ptdTable = new ProfileThumbnailDataTable(query);
				ProfileThumbnailTable ptd_ptTable = (this.Depth > 0) ? new ProfileThumbnailTable(query) : null;
				ProfileTable ptd_pt_pTable = (this.Depth > 1) ? new ProfileTable(query) : null;

        
				Profile ptd_pt_pObject = (this.Depth > 1) ? ptd_pt_pTable.CreateInstance() : null;
				ProfileThumbnail ptd_ptObject = (this.Depth > 0) ? ptd_ptTable.CreateInstance(ptd_pt_pObject) : null;
				ProfileThumbnailData ptdObject = ptdTable.CreateInstance(ptd_ptObject);
				sqlReader.Close();

				return ptdObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "loadinternal", "exception"), "ProfileThumbnailData could not be loaded by id. See exception for details.", sqlCmdText, ex, this, connection, id);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileThumbnailData", "Exception while loading ProfileThumbnailData object from database. See inner exception for details.", ex);
      }
    }

    public ProfileThumbnailData Load(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileThumbnailDataTable.GetColumnNames("[ptd]") + 
							(this.Depth > 0 ? "," + ProfileThumbnailTable.GetColumnNames("[ptd_pt]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileTable.GetColumnNames("[ptd_pt_p]") : string.Empty) +  
					" FROM [web].[ProfileThumbnailData] AS [ptd] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileThumbnail] AS [ptd_pt] ON [ptd].[ProfileThumbnailID] = [ptd_pt].[ProfileThumbnailID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [ptd_pt_p] ON [ptd_pt].[ProfileID] = [ptd_pt_p].[ProfileID] ";
				

        parameters.Top = 1;
        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "customload", "notfound"), "ProfileThumbnailData could not be loaded using custom logic as it was not found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return null;
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileThumbnailDataTable ptdTable = new ProfileThumbnailDataTable(query);
				ProfileThumbnailTable ptd_ptTable = (this.Depth > 0) ? new ProfileThumbnailTable(query) : null;
				ProfileTable ptd_pt_pTable = (this.Depth > 1) ? new ProfileTable(query) : null;

        
				Profile ptd_pt_pObject = (this.Depth > 1) ? ptd_pt_pTable.CreateInstance() : null;
				ProfileThumbnail ptd_ptObject = (this.Depth > 0) ? ptd_ptTable.CreateInstance(ptd_pt_pObject) : null;
				ProfileThumbnailData ptdObject = ptdTable.CreateInstance(ptd_ptObject);
				sqlReader.Close();

				return ptdObject;

      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "customload", "exception"), "ProfileThumbnailData could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileThumbnailData", "Exception while loading (custom/single) ProfileThumbnailData object from database. See inner exception for details.", ex);
      }
    }

    public List<ProfileThumbnailData> LoadMany(ISqlConnectionInfo connection, SqlQueryParameters parameters)
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
							ProfileThumbnailDataTable.GetColumnNames("[ptd]") + 
							(this.Depth > 0 ? "," + ProfileThumbnailTable.GetColumnNames("[ptd_pt]") : string.Empty) + 
							(this.Depth > 1 ? "," + ProfileTable.GetColumnNames("[ptd_pt_p]") : string.Empty) +  
					" FROM [web].[ProfileThumbnailData] AS [ptd] ";
				if (this.Depth > 0)
				  sqlCmdText += "INNER  JOIN [web].[ProfileThumbnail] AS [ptd_pt] ON [ptd].[ProfileThumbnailID] = [ptd_pt].[ProfileThumbnailID] ";
				if (this.Depth > 1)
				  sqlCmdText += "INNER  JOIN [web].[Profile] AS [ptd_pt_p] ON [ptd_pt].[ProfileID] = [ptd_pt_p].[ProfileID] ";
				

        sqlCmdText = parameters.BuildQuery(sqlCmdText);       
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        foreach (KeyValuePair<string, object> argument in parameters.Arguments)
          sqlCmd.Parameters.AddWithValue("@" + argument.Key, argument.Value);

        SqlDataReader sqlReader = database.Add(sqlCmd) as SqlDataReader;

        if (!sqlReader.HasRows || !sqlReader.Read())
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "customloadmany", "notfound"), "ProfileThumbnailData list could not be loaded using custom logic as no items were found.", sqlCmdText, this, connection, parameters);
          if (this.Logger.IsDebugEnabled)
            this.Logger.Debug(builder.ToString());
          sqlReader.Close();
          return new List<ProfileThumbnailData>();
        }

        SqlQuery query = new SqlQuery(sqlReader);

				ProfileThumbnailDataTable ptdTable = new ProfileThumbnailDataTable(query);
				ProfileThumbnailTable ptd_ptTable = (this.Depth > 0) ? new ProfileThumbnailTable(query) : null;
				ProfileTable ptd_pt_pTable = (this.Depth > 1) ? new ProfileTable(query) : null;

        List<ProfileThumbnailData> result = new List<ProfileThumbnailData>();
        do
        {
          
					Profile ptd_pt_pObject = (this.Depth > 1) ? ptd_pt_pTable.CreateInstance() : null;
					ProfileThumbnail ptd_ptObject = (this.Depth > 0) ? ptd_ptTable.CreateInstance(ptd_pt_pObject) : null;
					ProfileThumbnailData ptdObject = (this.Depth > -1) ? ptdTable.CreateInstance(ptd_ptObject) : null;
					result.Add(ptdObject);

        } while (sqlReader.Read());
        sqlReader.Close();

        return result;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "customloadmany", "exception"), "ProfileThumbnailData list could not be loaded using custom logic. See exception for details.", sqlCmdText, ex, this, connection, parameters);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Load, "ProfileThumbnailData", "Exception while loading (custom/many) ProfileThumbnailData object from database. See inner exception for details.", ex);
      }
    }
    
    public override int? Insert(ISqlConnectionInfo connection, ProfileThumbnailData data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = "INSERT INTO [web].[ProfileThumbnailData] ([ProfileThumbnailID],[Data],[IsOriginal]) VALUES(@ProfileThumbnailID,@Data,@IsOriginal); SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileThumbnailID", data.ProfileThumbnail.ID);
				sqlCmd.Parameters.AddWithValue("@Data", data.Data).SqlDbType = SqlDbType.VarBinary;
				sqlCmd.Parameters.AddWithValue("@IsOriginal", data.IsOriginal).SqlDbType = SqlDbType.Bit;
				
        object idObj = sqlCmd.ExecuteScalar();
        if (idObj == null || DBNull.Value.Equals(idObj))
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "insert", "noprimarykey"), "ProfileThumbnailData could not be inserted or inserted primary key was not returned. Are you missing SELECT SCOPE_IDENTITY();?", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Insert, "ProfileThumbnailData", "Exception while inserting ProfileThumbnailData object in database.");
        }

        int intId = (int)((decimal)idObj);

        if (!String.IsNullOrEmpty(data.DataFilePath))
        {
          string updateQuery = @"UPDATE [web].[ProfileThumbnailData] SET Data.WRITE(@Data, @Offset, @Length) WHERE ProfileThumbnailDataID = @ProfileThumbnailDataID;";
          SqlCommand cmdUpdate = database.Add(updateQuery) as SqlCommand;
          SqlParameter idParameter = new SqlParameter("@ProfileThumbnailDataID", intId);
          SqlParameter dataParameter = new SqlParameter("@Data", SqlDbType.VarBinary);
          SqlParameter offsetParameter = new SqlParameter("@Offset", SqlDbType.BigInt);
          SqlParameter lengthParameter = new SqlParameter("@Length", SqlDbType.BigInt);
          cmdUpdate.Parameters.Add(idParameter);
          cmdUpdate.Parameters.Add(dataParameter);
          cmdUpdate.Parameters.Add(offsetParameter);
          cmdUpdate.Parameters.Add(lengthParameter);

          using (FileStream fs = new FileStream(data.DataFilePath, FileMode.Open, FileAccess.Read))
          {
            byte[] buffer = new byte[2090400];
            int read = 0;
            int offset = 0;

            if (buffer.Length > fs.Length)
              buffer = new byte[fs.Length];

            while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
              dataParameter.Value = buffer;
              offsetParameter.Value = offset;
              lengthParameter.Value = read;

              cmdUpdate.ExecuteNonQuery();

              if (buffer.Length > fs.Length - offset)
                buffer = new byte[fs.Length];

              offset += read;
            }
          }
        }

        return intId;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "insert", "exception"), "ProfileThumbnailData could not be inserted. See exception for details.", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Insert, "ProfileThumbnailData", "Exception while inserting ProfileThumbnailData object in database. See inner exception for details.", ex);
      }
    }

    public override bool Update(ISqlConnectionInfo connection, ProfileThumbnailData data)
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
        sqlCmdText = "UPDATE [web].[ProfileThumbnailData] SET " +
												"[ProfileThumbnailID] = @ProfileThumbnailID, " + 
												"[Data] = @Data, " + 
												"[IsOriginal] = @IsOriginal, " + 
												"[Updated] = GETDATE() " + 
											"WHERE [ProfileThumbnailDataID] = @ProfileThumbnailDataID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
		
				sqlCmd.Parameters.AddWithValue("@ProfileThumbnailID", data.ProfileThumbnail.ID);
				sqlCmd.Parameters.AddWithValue("@Data", data.Data).SqlDbType = SqlDbType.VarBinary;
				sqlCmd.Parameters.AddWithValue("@IsOriginal", data.IsOriginal).SqlDbType = SqlDbType.Bit;
				sqlCmd.Parameters.AddWithValue("@Updated", data.Updated).SqlDbType = SqlDbType.DateTime2;
				sqlCmd.Parameters.AddWithValue("@ProfileThumbnailDataID", data.ID);

        int rowCount = sqlCmd.ExecuteNonQuery();
        if (rowCount < 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "update", "norecord"), "ProfileThumbnailData could not be updated as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileThumbnailData", "Exception while updating ProfileThumbnailData object in database. No record found for this id.");
        }
        else if (rowCount > 1)
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "update", "morerecords"), "ProfileThumbnailData was updated but there was more than one record affected.", sqlCmdText, this, connection, data);
          if (this.Logger.IsFatalEnabled)
            this.Logger.Fatal(builder.ToString());
          throw new DataOperationException(DataOperation.Update, "ProfileThumbnailData", "Exception while updating ProfileThumbnailData object in database. More than one record found for this statement (update statement where clause broken?!).");
        }
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "update", "exception"), "ProfileThumbnailData could not be updated. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Update, "ProfileThumbnailData", "Exception while updating ProfileThumbnailData object in database. See inner exception for details.", ex);
      }
    }

    public override bool Delete(ISqlConnectionInfo connection, ProfileThumbnailData data)
    {
      IDatabase database = connection.Database;
      if (database == null)
        throw new ArgumentNullException("database", "Error initializing database connection.");
      if (data == null)
        throw new ArgumentNullException("data");
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText =  "DELETE FROM [web].[ProfileThumbnailData] WHERE ProfileThumbnailDataID = @ProfileThumbnailDataID;";
        SqlCommand sqlCmd = database.Add(sqlCmdText) as SqlCommand;
        sqlCmd.Parameters.AddWithValue("@ProfileThumbnailDataID", data.ID);

        int success = sqlCmd.ExecuteNonQuery();

        if (success == -1)        
        {
          IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "delete", "norecord"), "ProfileThumbnailData could not be deleted as no matching record was found.", sqlCmdText, this, connection, data);
          if (this.Logger.IsErrorEnabled)
            this.Logger.Error(builder.ToString());
          throw new DataOperationException(DataOperation.Delete, "ProfileThumbnailData", "Exception while deleting ProfileThumbnailData object from database. No such record found.");
        }
        
        return true;
      }
      catch (Exception ex)
      {
        database.HandleException(ex);
        IMessageBuilder builder = new DbLogMessageBuilder(new LogErrorCode("ptd", "delete", "exception"), "ProfileThumbnailData could not be deleted. See exception for details", sqlCmdText, ex, this, connection, data);
        if (this.Logger.IsErrorEnabled)
          this.Logger.Error(builder.ToString(), ex);
        throw new DataOperationException(DataOperation.Delete, "ProfileThumbnailData", "Exception while deleting ProfileThumbnailData object from database. See inner exception for details.", ex);
      }
    }
  }
}

