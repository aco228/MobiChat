using MobiChat.Data;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobiChat.Core
{
  public interface ISendNumber
  {
    void Initialize(IService service, HttpContext context, string msisnd);
    bool CheckNumber();
    bool TryParseMobileOperator();
    bool TryGetServiceConfiguration();
    bool Send();
    object GetRespone(string message); //  get cashflow SendSmsResponse

    bool Status { get; }
    string Message { get; }
    bool HasError { get; }
    void SetSuccessMessage(string message);
    void SetErrorMessage(string message);
    void SetMessageAllreadySent(string message);
    void SetCustomMessage(string message);

  }
}
