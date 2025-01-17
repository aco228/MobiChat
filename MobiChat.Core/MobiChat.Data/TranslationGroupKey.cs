using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MobiChat.Data
{
  public partial interface ITranslationGroupKeyManager
  {
    TranslationGroupKey Load(Translation translation, string translationGroupName, string translationGroupKeyName);
    TranslationGroupKey Load(IConnectionInfo connectio, Translation translation, string translationGroupName, string translationGroupKeyName);
    List<TranslationGroupKey> Load(TranslationGroup translationGroup);
    List<TranslationGroupKey> Load(IConnectionInfo connection, TranslationGroup translationGroup);
    /// <summary>
    /// Obfuscated!!!
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    List<TranslationGroupKey> Load(Product product);
    List<TranslationGroupKey> Load(IConnectionInfo connection, Product product);
    List<TranslationGroupKey> Load(Translation translation);
    List<TranslationGroupKey> Load(IConnectionInfo connection, Translation translation);
  }

  public partial class TranslationGroupKey
  {
  }
}

