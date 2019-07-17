using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;
using MobiChat.Data;
using MobiChat.Data.Sql;



namespace MobiChat.Web.Data.Sql
{
  public partial class MessageManager : IMessageManager
  {

    public List<Message> Load(Customer customer)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, customer);
    }

    public List<Message> Load(IConnectionInfo connection, Customer customer)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, customer);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, customer);
    }

    public List<Message> Load(ISqlConnectionInfo connection, Customer customer)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[m].CustomerID=@CustomerID";
      parameters.Arguments.Add("CustomerID", customer.ID);
      parameters.OrderBy = "[m].Created DESC";
      return this.LoadMany(connection, parameters);
    }


    public List<Message> Load(Customer customer, MessageType messageType)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, customer, messageType);
    }

    public List<Message> Load(IConnectionInfo connection, Customer customer, MessageType messageType)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, customer, messageType);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, customer, messageType);
    }

    public List<Message> Load(ISqlConnectionInfo connection, Customer customer, MessageType messageType)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[m].CustomerID=@CustomerID AND [m].MessageTypeID=@MessageTypeID AND [m].CustomerID IS NOT NULL";
      parameters.Arguments.Add("CustomerID", customer.ID);
      parameters.Arguments.Add("MessageTypeID", (int)messageType);
      parameters.OrderBy = "[m].Created DESC";
      return this.LoadMany(connection, parameters);
    }


    public Message Load(Guid messageGuid)
    {
      using (SqlConnectionInfo connection = new SqlConnectionInfo(this.Type))
        return this.Load(connection, messageGuid);
    }

    public Message Load(IConnectionInfo connection, Guid messageGuid)
    {
      ISqlConnectionInfo sqlConnection = connection as ISqlConnectionInfo;
      if (sqlConnection != null)
        return this.Load(sqlConnection, messageGuid);
      using (sqlConnection = new SqlConnectionInfo(connection, this.Type))
        return this.Load(sqlConnection, messageGuid);
    }

    public Message Load(ISqlConnectionInfo connection, Guid messageGuid)
    {
      SqlQueryParameters parameters = new SqlQueryParameters();
      parameters.Where = "[m].MessageGuid=@Guid";
      parameters.Arguments.Add("Guid", messageGuid);
      return this.Load(connection, parameters);
    }

  }
}

