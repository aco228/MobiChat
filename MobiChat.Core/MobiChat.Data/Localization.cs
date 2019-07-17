using Senti.Data;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ILocalizationManager 
  {
    
    List<Localization> Load();
    List<Localization> Load(IConnectionInfo connection );
    
    List<Localization> Load(Application application);
    List<Localization> Load(IConnectionInfo connection, Application application);


  }

  public partial class Localization
  {

    public ILocalizationProvider InstantiateProvider()
    {
      return this.Translation.TranslationType.Instantiate(this.Translation);
    }
  }
}

