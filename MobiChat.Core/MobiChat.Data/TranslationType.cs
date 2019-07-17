using Senti.ComponentModel;
using Senti.Localization;
using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationTypeManager 
  {
    List<TranslationType> Load();
    List<TranslationType> Load(IConnectionInfo connection);
  }

  public partial class TranslationType
  {

    public ILocalizationProvider Instantiate(Translation translation)
    {
      return TypeFactory.Instantiate<ILocalizationProvider, Translation>(this.TypeName, translation);
    }

  }
}

