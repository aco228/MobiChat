using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface ITranslationGroupManager 
  {
    /// <summary>
    /// Obfuscated!!!
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    List<TranslationGroup> Load(Product product);
    List<TranslationGroup> Load(IConnectionInfo connection, Product product);

    List<TranslationGroup> Load(Translation translationKey);
    List<TranslationGroup> Load(IConnectionInfo connection, Translation translationKey);

    List<TranslationGroup> Load();
    List<TranslationGroup> Load(IConnectionInfo connection);


    TranslationGroup Load(Translation translation, string name);
    TranslationGroup Load(IConnectionInfo connection, Translation translation, string name);


  }

  public partial class TranslationGroup
  {
  }
}

