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

  public partial class TranslationKey : IComparable<TranslationKey>, ILocalizationKey
  {
    private Data.Localization _localization = null;

    public Data.Localization Localization { get { return this._localization; } }
    public ILocalizationKey FallbackKey { get { return this.FallbackTranslationKey; } }

    public TranslationKey(Translation translation, Language language, Service service)
      : this(-1, null, translation, language, service, "Search key", DateTime.Now, DateTime.Now)
    {
    }

    public TranslationKey(Localization localization, Language language, Service service)
      : this(-1, null, localization.Translation, language, service, "Search Key", DateTime.Now, DateTime.Now)
    {
      this._localization = localization;
    }


    public int CompareTo(object obj)
    {
      return this.CompareTo(obj as TranslationKey);
    }

    public int CompareTo(TranslationKey other)
    {
      if (other == null) return 1;
      int compare2 = other.Language == null ? this.Language == null ? 0 : 1 : this.Language == null ? -1 : this.Language.ID.CompareTo(other.Language.ID);
      if (compare2 != 0) return compare2;
      int compare3 = other.Service == null ? this.Service == null ? 0 : 1 : this.Service == null ? -1 : this.Service.ID.CompareTo(other.Service.ID);
      if (compare3 != 0) return compare3;
      return 0;
    }

    public int GetMatchValue(ILocalizationKey key)
    {
      TranslationKey other = key as TranslationKey;
      if (other == null) return int.MaxValue;

      int matchValue = 4;

      if (other.Language == null)
      {
        if (this.Language != null)
          return int.MaxValue;
        matchValue -= 2;
      }
      else
      {
        if (this.Language != null)
        {
          int compare2 = this.Language.ID.CompareTo(other.Language.ID);
          if (compare2 != 0)
            return int.MaxValue;
          matchValue -= 2;
        }
        else
          matchValue -= 1;
      }

      if (other.Service == null)
      {
        if (this.Service != null)
          return int.MaxValue;
        matchValue -= 2;
      }
      else
      {
        if (this.Service != null)
        {
          int compare3 = this.Service.ID.CompareTo(other.Service.ID);
          if (compare3 != 0)
            return int.MaxValue;
          matchValue -= 2;
        }
        else
          matchValue -= 1;
      }

      return matchValue;
    }
  }
}

