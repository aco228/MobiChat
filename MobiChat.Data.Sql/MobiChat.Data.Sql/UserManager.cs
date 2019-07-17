using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
using Senti.Security;



namespace MobiChat.Data.Sql
{
  public partial class UserManager : IUserManager
  {




    public List<User> Load()
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection);
    }

    public List<User> Load(IConnectionInfo connection)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection);
    }

    public List<User> Load(ISqlConnectionInfo connection)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      return this.LoadMany(connection, parameters);
    }


    public User Load(Guid UserGuid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, UserGuid);
    }

    public User Load(IConnectionInfo connection, Guid UserGuid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, UserGuid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, UserGuid);
    }

    public User Load(ISqlConnectionInfo connection, Guid UserGuid)
    {  
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[u].UserGuid=@UserGuid";
      parameters.Arguments.Add("UserGuid", UserGuid);
      return this.Load(connection, parameters);
    }  

    public User Load(string username)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, username);
    }

    public User Load(IConnectionInfo connection, string username)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, username);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, username);
    }

    public User Load(ISqlConnectionInfo connection, string username)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[u].Username=@username";
      parameters.Arguments.Add("username", username);
      return this.Load(connection, parameters);
    }

    public User Load(User user)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, user);
    }

    public User Load(IConnectionInfo connection, User user)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, user);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, user);
    }

    public User Load(ISqlConnectionInfo connection, User user)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[u].UserID = @UserID";
      parameters.Arguments.Add("UserID", user);
      return this.Load(connection, parameters);
    }

    public List<User> Load(UserStatus userStatus)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, userStatus);
    }

    public List<User> Load(IConnectionInfo connection, UserStatus userStatus)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, userStatus);
        using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, userStatus);
    }
     
    public List<User> Load(ISqlConnectionInfo connection, UserStatus userStatus)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[u].UserStatusID = @UserStatusID";
      parameters.Arguments.Add("UserStatusID", (int)userStatus);
      return this.LoadMany(connection, parameters);
    }


    public User Load(string username, string password)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, username, password);
    }

    public User Load(IConnectionInfo connection, string username, string password)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, username, password);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, username, password);
    }

    public User Load(ISqlConnectionInfo connection, string username, string password)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = string.Format("[u].Username = @Username");
      parameters.Arguments.Add("Username", username);

      User user = Load(connection, parameters);
      if (user == null)
        return null;

      int SALT_LENGTH = 8;
      byte[] salt = new byte[SALT_LENGTH];
      for (int i = 0; i < SALT_LENGTH;
        salt[i] = user.Password[user.Password.Length - SALT_LENGTH + i++]) ;

      byte[] encryptedUnckeckedPassword = PasswordEncryption.Create(password, salt).EncryptedPasswordAndSalt;

      if (encryptedUnckeckedPassword.SequenceEqual(user.Password))
        return user;

      return null;
    }


  }
}

