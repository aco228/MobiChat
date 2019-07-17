using MobiChat.Core;
using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public interface IService
  {
    Data.Service ServiceData { get; }
    IRuntime Runtime { get; }
    List<Data.Domain> Domains { get; }
    Data.ServiceLogo ServiceLogo { get; }
    Data.Template Template { get; }
    PaymentProvider PaymentProvider { get; }
    ICache Cache { get; }
    ISendNumber SendNumberManager { get; }
    string HomeView { get; }
    string PartialHomeView { get; }
    string Shortcode { get; }

    void Init();
    void OnSentMessageNotification(Guid shortMessageRequestGuid);
    void OnReceivedMessageNotification(Guid shorMessageGuid);
    void OnChargedNotification(Guid transactionGuid);

    Data.ServiceConfigurationEntry GetConfiguration(Data.Country country);
    Data.ServiceConfigurationEntry GetConfiguration(Data.Country country, Data.MobileOperator mobileOperator);

  }
}
