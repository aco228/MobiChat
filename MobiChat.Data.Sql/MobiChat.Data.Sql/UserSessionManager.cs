using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
 


namespace MobiChat.Data.Sql
{
  public partial class UserSessionManager : IUserSessionManager
  {
    public UserSession Load(Service service, Guid userSessionGuid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, service, userSessionGuid);
    }

    public UserSession Load(IConnectionInfo connection, Service service, Guid userSessionGuid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, service, userSessionGuid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, service, userSessionGuid);
    }

    public UserSession Load(ISqlConnectionInfo connection, Service service, Guid userSessionGuid)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[us].ServiceID = @ServiceID AND [us].UserSessionGuid = @UserSessionGuid AND [us].ValidUntil >= GETDATE()";
      parameters.OrderBy = "[us].ValidUntil DESC";
      parameters.Arguments.Add("ServiceID", service.ID);
      parameters.Arguments.Add("UserSessionGuid", userSessionGuid);
      return this.Load(connection, parameters);
    }

    public T Load<T>(Customer customer)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load<T>(connection, customer);
    }

    public T Load<T>(IConnectionInfo connection, Customer customer)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load<T>(sqlConnection, customer);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load<T>(sqlConnection, customer);
    }

    public T Load<T>(ISqlConnectionInfo connection, Customer customer)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[us].CustomerID = @CustomerID";
      parameters.Arguments.Add("customerID", customer.ID);
      if (typeof(T).Equals(typeof(List<UserSession>)))
        return (T)Convert.ChangeType(this.LoadMany(connection, parameters), typeof(T));
      else
        return (T)Convert.ChangeType(this.Load(connection, parameters), typeof(T));
    }

    //public UserSession Load(Customer customer)
    //{
    //  using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
    //    return this.Load(connection, customer);
    //}

    //public UserSession Load(IConnectionInfo connection, Customer customer)
    //{
    //  ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
    //  if (sqlConnection != null)
    //    return this.Load(sqlConnection, customer);
    //  using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
    //    return this.Load(sqlConnection, customer);
    //}

    //public UserSession Load(ISqlConnectionInfo connection, Customer customer)
    //{
    //  SqlQueryParameters parameters = new SqlQueryParameters();
    //  parameters.Where = "[us].CustomerID = @CustomerID AND [us].ValidUntil >= GETDATE()";
    //  parameters.OrderBy = "[us].ValidUntil DESC";
    //  parameters.Arguments.Add("CustomerID", customer.ID);
    //  return this.Load(connection, parameters);
    //}


    public List<UserSession> Load(User user, Service service)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, user, service);
    }

    public List<UserSession> Load(IConnectionInfo connection, User user, Service service)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, user, service);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, user, service);
    }

    public List<UserSession> Load(ISqlConnectionInfo connection, User user, Service service)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[us].UserID = @UserID AND [us].ServiceID = @ServiceID";
      parameters.Arguments.Add("UserID", user.ID);
      parameters.Arguments.Add("ServiceID", service.ID);
      return this.LoadMany(connection, parameters);
    }

    public List<UserSession> Load(DateTime? from, DateTime? to)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, from, to);
    }

    public List<UserSession> Load(IConnectionInfo connection, DateTime? from, DateTime? to)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, from, to);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, from, to);
    }

    public List<UserSession> Load(ISqlConnectionInfo connection, DateTime? from, DateTime? to)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      this.Depth = 0;

      //parameters.SetIncludedColumns(new List<ColumnDescription>(new ColumnDescription[] { UserSessionTable.Columns.UserSessionID, UserSessionTable.Columns.UserSessionGuid, UserSessionTable.Columns.IPAddressTypeID, UserSessionTable.Columns.ValidUntil, UserSessionTable.Columns.Updated, UserSessionTable.Columns.Created }));
      parameters.Where = "[us].Created >= ISNULL(CONVERT(DATE, @From), CONVERT(DATE, GETDATE())) AND [us].Created <= ISNULL(@To, GETDATE())";
      parameters.Arguments.Add("From", from == null ? (object)DBNull.Value : from.Value);
      parameters.Arguments.Add("To", to == null ? (object)DBNull.Value : to.Value);
      parameters.OrderBy = "[us].UserSessionID DESC";
      return this.LoadMany(connection, parameters);
    }

    public UserSession Load(string ip, string pxid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, ip, pxid);
    }

    public UserSession Load(IConnectionInfo connection, string ip, string pxid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, ip, pxid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, ip, pxid);
    }

    public UserSession Load(ISqlConnectionInfo connection, string ip, string pxid)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[us].IpAddress LIKE @IP AND [us].Referrer LIKE @PXID";
      parameters.Arguments.Add("IP", ip);
      parameters.Arguments.Add("PXID", "%" + pxid + "%");
      return this.Load(connection, parameters);
      //return this.LoadMany(connection, parameters);
    }


    public UserSession Load(Guid userSessionGuid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, userSessionGuid);
    }

    public UserSession Load(IConnectionInfo connection, Guid userSessionGuid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, userSessionGuid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, userSessionGuid);
    }

    public UserSession Load(ISqlConnectionInfo connection, Guid userSessionGuid)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[us].UserSessionGuid = @UserSessionGuid";
      parameters.Arguments.Add("UserSessionGuid", userSessionGuid);
      return this.Load(connection, parameters);
    }


  }
}

