using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationValueManager 
  {
    TranslationValue Load(Translation translation, string translationGroupName, string translationGroupKeyName);
    TranslationValue Load(IConnectionInfo connection, Translation translation, string translationGroupName, string translationGroupKeyName);
    TranslationValue Load(TranslationKey translationKey, TranslationGroupKey translationGroupKey);
    TranslationValue Load(IConnectionInfo connection, TranslationKey translationKey, TranslationGroupKey translationGroupKey);
    List<TranslationValue> Load(Language language);
    List<TranslationValue> Load(IConnectionInfo connection, Language language);
    List<TranslationValue> Load(Service service);
    List<TranslationValue> Load(IConnectionInfo connection, Service service);
    /// <summary>
    /// Obfuscated!!!
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    List<TranslationValue> Load(Product product);
    List<TranslationValue> Load(IConnectionInfo connection, Product product);
    List<TranslationValue> Load(Translation translation);
    List<TranslationValue> Load(IConnectionInfo connection, Translation translation);
  }

  public partial class TranslationValue
  {
  }
}

