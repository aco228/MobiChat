using MobiChat.Core;
using MobiChat.Data;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public interface IRuntime
  {
    Data.RuntimeType RuntimeType { get; }
    Dictionary<ServiceType, ICache> Cache { get; }

    Data.Application ApplicationData { get; }
    bool Initialize(string siteName);
    Data.Domain GetDomain(string domainName);
    IService GetService(string domainName);
    Dictionary<Data.Localization, ILocalizationProvider> LocalizationProviders { get; }

    IService GetServiceByName(string name);
    Data.Merchant GetMerchantByID(int id);
    Data.Country GetCountryByID(int id);
  }
}
