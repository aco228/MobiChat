using Senti.Data;
using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationKeyManager 
  {
    TranslationKey Load(Service service);
    TranslationKey Load(IConnectionInfo connection, Service service);
    TranslationKey Load(Language language, Service service);
    TranslationKey Load(IConnectionInfo connection, Language language, Service service);
    TranslationKey Load(Language language);
    TranslationKey Load(IConnectionInfo connection, Language language);
    List<TranslationKey> Load();
    List<TranslationKey> Load(IConnectionInfo connection);
    List<TranslationKey> Load(Translation translation);
    List<TranslationKey> Load(IConnectionInfo connection, Translation translation);
    List<TranslationKey> Load(Product product);
    List<TranslationKey> Load(IConnectionInfo connection, Product product);
    List<TranslationKey> Load(TranslationKey translationKey);
    List<TranslationKey> Load(IConnectionInfo connection, TranslationKey translationKey);

  }

  public partial class TranslationKey
  {
  }
}

