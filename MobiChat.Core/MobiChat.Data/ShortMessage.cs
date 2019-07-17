using log4net;
using Senti.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

 

namespace MobiChat.Data 
{

  public partial interface IShortMessageManager 
  {
    
    ShortMessage Load(Guid guid);
    ShortMessage Load(IConnectionInfo connection, Guid guid);




  }

  public partial class ShortMessage
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ShortMessage._log == null)
          ShortMessage._log = LogManager.GetLogger(typeof(ShortMessage));
        return ShortMessage._log;
      }
    }

    #endregion #logging#

    private string _requestUrl = string.Empty;

    public static ShortMessage Send(string text, Customer customer, User user)
    {
      ServiceConfigurationEntry sce = ServiceConfigurationEntry.CreateManager().Load(customer.Service, customer.Country);
      ShortMessage shortMessage = new ShortMessage(-1,
        Guid.NewGuid(),
        null,
        customer.Service,
        customer.MobileOperator,
        customer,
        ShortMessageDirection.Outcoming,
        ShortMessageStatus.Requested,
        text,
        sce.Shortcode,
        sce.Keyword,
        DateTime.Now, DateTime.Now);
      shortMessage.Send(user);

      return shortMessage;
    }

    public void Send(User user)
    {
      if (this.ID != -1)
        return;

      this.Insert();

      ShortMessageRequest request = new ShortMessageRequest(-1,
        Guid.NewGuid(),
        this,
        user,
        DateTime.Now, DateTime.Now);
      request.Insert();

      // TODO: change loading by id to something different ( loading 'ServiceCallbackApplication' )
      Application application = Application.CreateManager().Load(3);

      this._requestUrl = string.Format("http://{0}/request/{1}", application.Name, request.Guid.ToString());
      Log.Info(string.Format("ShortMessage:{0} requested:{1} on {2}", this.Guid.ToString(), request.Guid.ToString(), this._requestUrl));

      Task.Factory.StartNew(this.SendRequest);
      return;
    }

    private void SendRequest()
    {
      try
      {
        WebRequest wssRequest = WebRequest.Create(this._requestUrl);
        wssRequest.Method = "GET";
        WebResponse wssResponse = wssRequest.GetResponse();
        StreamReader ssReader = new StreamReader(wssResponse.GetResponseStream());
        wssResponse.Close();
        ssReader.Close();
      }
      catch(Exception e)
      {
        Log.Error("Fatal error on ShortMessage:SendRequest", e);
      }
    }

  }
}

