using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
using System.Reflection;
using System.IO;
using System.Net;



namespace MobiChat.Data.Sql
{
  public partial class IPCountryMapManager : IIPCountryMapManager
  {
    private const int MIN_NUMBER_OF_ITEMS = 60000;

    public List<IPCountryMap> Insert(List<IPCountryMap> items)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Insert(connection, items);
    }

    public List<IPCountryMap> Insert(IConnectionInfo connection, List<IPCountryMap> items)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Insert(sqlConnection, items);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Insert(sqlConnection, items);
    }

    public List<IPCountryMap> Insert(ISqlConnectionInfo connection, List<IPCountryMap> items)
    {
      string tempTableName = string.Format("IPCountryMap_{0:yyyyMMddHHmmss}", DateTime.Now);
      string tableName = "IPCountryMap";

      if (items.Count < MIN_NUMBER_OF_ITEMS)
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "insert", "minitems"),
          //																									string.Format("Not enough items in IPCountryMap-list (Count: {0} // Minimum: {1})",
          //																																items.Count, MIN_NUMBER_OF_ITEMS));
          //Log.Error(builder.ToString());
        return null;
      }

      // if the next statement returns false logging was done already so no need to log it twice.
      if (!this.DropAndCreateTable(tempTableName))
        return null;

      if (!this.BatchInsert(tempTableName, items))
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "batchinsert", "failed"),
          //																									string.Format("Inserting entries in the temporary table failed."));
          //Log.Error(builder.ToString());
        return null;
      }

      if (!this.MoveTempTableToExistingTable(tempTableName, tableName))
        return null;

      return items;
    }



    private bool DropAndCreateTable(string tableName)
    {
      try
      {
        using (Database database = Database.Create(true, this.Type))
        {
          List<string> sqlCommands = this.GetScripts("MobilePaywall.Data.Resources.Sql.IPCountryMapDropAndCreateTable.sql");
          foreach (string sqlCmdText in sqlCommands)
          {
            string temp = sqlCmdText;
            temp = string.Format(sqlCmdText, tableName);
            SqlCommand sqlCmd = database.Add(temp);
            sqlCmd.ExecuteNonQuery();
          }
          return true;
        }
      }
      catch (Exception ex)
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "createtemptable", "exception"),
          //																									string.Format("Creating the temporary table failed due to an exception."),
          //																									ex, tableName);
          //Log.Error(builder.ToString(), ex);
        return false;
      }
    }

    private List<string> GetScripts(string resourceName)
    {
      Assembly Assembly = Assembly.GetAssembly(typeof(IPCountryMapManager));
      Stream stream = Assembly.GetManifestResourceStream(resourceName);
      if (stream == null)
      {
        throw (new Exception(string.Format("Sql-script \'{0}\' could not be loaded.", resourceName)));
      }
      StreamReader reader = new StreamReader(stream);

      return this.GetScripts(reader);
    }

    private List<string> GetScripts(StreamReader reader)
    {
      List<string> scripts = new List<string>();
      string script = string.Empty;
      string line = string.Empty;
      while (reader.Peek() > -1)
      {
        while ((string.IsNullOrEmpty(line) && reader.Peek() != -1) ||
               !"GO".Equals(line.Trim().ToUpper()))
        {
          line = (string)(reader.ReadLine());
          if (!string.IsNullOrEmpty(line) && !"GO".Equals(line.Trim().ToUpper()))
          {
            script += line + Environment.NewLine;
          }
        }
        if (!string.IsNullOrEmpty(script))
        {
          scripts.Add(script);
        }
        script = string.Empty;
        line = string.Empty;
      }
      reader.Close();
      reader.Dispose();
      return scripts;
    }

    private bool MoveTempTableToExistingTable(string tempTable, string existingTable)
    {
      try
      {
        using (Database database = Database.Create(true, this.Type))
        {
          using (SqlTransaction transaction = database.Connection.BeginTransaction())
          {
            try
            {
              if (!this.DropTable(database, transaction, existingTable))
                return false;
              if (!this.RenameTable(database, transaction, tempTable, existingTable))
                return false;
            }
            catch (Exception ex)
            {
              transaction.Rollback();
              return false;
            }
            transaction.Commit();
            return true;
          }
        }
      }
      catch (Exception outerEx)
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "movetemptable", "exception"),
          //																									string.Format("Moving the temporary table to existing table failed."),
          //																									outerEx, tempTable, existingTable);
          //Log.Error(builder.ToString(), outerEx);
        return false;
      }
    }

    private bool DropTable(Database database, SqlTransaction transaction, string tableName)
    {
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N\'[core].[{0}]\') AND type in (N\'U\')) DROP TABLE [core].[{0}];", tableName);
        SqlCommand sqlCmd = database.Add(sqlCmdText);
        sqlCmd.Transaction = transaction;
        sqlCmd.ExecuteNonQuery();
        return true;
      }
      catch (Exception ex)
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "droptemptable", "exception"),
          //																									string.Format("Dropping the existing table failed due to an exception."),
          //																									ex, tableName);
          //Log.Error(builder.ToString(), ex);
        return false;
      }
    }

    private bool RenameTable(Database database, SqlTransaction transaction, string oldTableName, string newTableName)
    {
      string sqlCmdText = string.Empty;
      try
      {
        sqlCmdText = string.Format("EXEC sp_rename \'[core].[{0}]\', \'{1}\'", oldTableName, newTableName);
        SqlCommand sqlCmd = database.Add(sqlCmdText);
        sqlCmd.Transaction = transaction;
        sqlCmd.ExecuteNonQuery();
        return true;
      }
      catch (Exception ex)
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "renametemptable", "exception"),
          //																									string.Format("Renaming the temp table to production table failed due to an exception."),
          //																									ex, oldTableName, newTableName);
          //Log.Error(builder.ToString(), ex);
        return false;
      }
    }



    private bool BatchInsert(string tempTableName, List<IPCountryMap> items)
    {
      try
      {
        // REVIEW ILIJA: Put a string builder here
        //StringBuilder commandBuilder = new StringBuilder(16000);
        //commandBuilder.Append("my single sql command");
        //sqlCmdText = commandBuilder.ToString();
        using (Database database = Database.Create(true, this.Type))
        {
          string sqlCmdText = string.Empty;

          foreach (IPCountryMap item in items)
          {
            sqlCmdText += string.Format("INSERT INTO [core].[{0}] (FromAddress, ToAddress, TwoLetterIsoCode, CountryID) "
                                  + "VALUES ({1}, {2}, \'{3}\', {4});" + Environment.NewLine, tempTableName, "@FromAddress", "@ToAddress",
                                  Database.Escape(item.TwoLetterIsoCode), (item.Country != null ? (item.Country.ID.ToString()) : "NULL"));

            SqlCommand sqlCmd = database.Add(sqlCmdText);
            sqlCmd.Parameters.AddWithValue("@FromAddress", item.FromAddress);
            sqlCmd.Parameters.AddWithValue("@ToAddress", item.ToAddress);

            sqlCmd.CommandTimeout = 600;
            int result = System.Convert.ToInt32(sqlCmd.ExecuteNonQuery());
            if (result < 1)
            {
                //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "batchinsert", "failed"),
                //																									string.Format("Inserting an entry in temporary table failed due to the record not being inserted."));
                //Log.Error(builder.ToString());
              return false;
            }
            sqlCmdText = string.Empty;
          }
        }
        return true;
      }
      catch (Exception ex)
      {
          //LogMessageBuilder builder = new LogMessageBuilder(new LogErrorCode("ipcmm", "batchinsert", "exception"),
          //																									string.Format("Inserting entries in temporary table failed due to an exception."),
          //																									ex);
          //Log.Error(builder.ToString(), ex);
        
        return false;
      }
    }





    public IPCountryMap Load(string ipAddress)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, ipAddress);
    }

    public IPCountryMap Load(IConnectionInfo connection, string ipAddress)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, ipAddress);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, ipAddress);
    }

    public IPCountryMap Load(ISqlConnectionInfo connection, string ipAddress)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[ipcm].FromAddress <= @IpAddress AND [ipcm].ToAddress >= @IpAddress";
      parameters.Top = 1;
      parameters.OrderBy = "[ipcm].FromAddress ASC";
      parameters.Arguments.Add("IpAddress", this.ToInt(ipAddress));
      return this.Load(connection, parameters);
    }

    private long ToInt(string addressText)
    {
      IPAddress address = IPAddress.None;
      if (!IPAddress.TryParse(addressText, out address))
        throw new InvalidOperationException();
      byte[] addressBytes = address.GetAddressBytes();
      long ipnum = 0;
      for (int i = 0; i < 4; ++i)
      {
        long y = addressBytes[i];
        if (y < 0)
        {
          y += 256;
        }
        ipnum += y << ((3 - i) * 8);
      }
      return ipnum;
    }
  }
}

