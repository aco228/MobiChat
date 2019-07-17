using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models.Template
{
  public class TranslationTemplateModel : TemplateModelBase
  {
    private bool _hasTranslation = true;
    private TranslationGroup _translationGroup = null;
    private TranslationKey _translationKey = null;
    private TranslationKey _fallbackKey = null;
    private List<TranslationValueTemplate> _values = null;

    public string Name { get; set; }
    public bool HasTranslation { get { return this._hasTranslation; } }
    public TranslationGroup TranslationGroup { get { return this._translationGroup; } }
    public TranslationKey TranslationKey { get { return this._translationKey; } }
    public TranslationKey FallbackKey { get { return this._fallbackKey; } }
    public List<TranslationValueTemplate> Values { get { return this._values; } }

    public TranslationTemplateModel(MobiContext context, Translation translation, bool extendedAccess, string groupName)
      : base(context, extendedAccess)
    {
      this._translationKey = TranslationKey.CreateManager().Load(context.Service.ServiceData);
      if (this._translationKey == null)
      {
        this._hasTranslation = false;
        return;
      }

      this.Name = groupName;
      this._fallbackKey = this._translationKey.FallbackTranslationKey;
      this._translationGroup = TranslationGroup.CreateManager().Load(translation, groupName);

      this._values = new List<TranslationValueTemplate>();
      List<TranslationGroupKey> groupKeys = TranslationGroupKey.CreateManager().Load(this._translationGroup);
      foreach (TranslationGroupKey groupKey in groupKeys)
        this._values.Add(new TranslationValueTemplate(this._translationKey, this._fallbackKey, groupKey));
    }
  }

  public class TranslationValueTemplate
  {
    private TranslationGroupKey _groupkey = null;
    private TranslationValue _value = null;
    private TranslationValue _fallbackValue = null;
    private TranslationKey _translationKey = null;

    public int ID { get { return this._value != null ? this._value.ID : -1; } }
    public TranslationGroupKey TranslationGroupKey { get { return this._groupkey; } }
    public TranslationKey TranslationKey { get { return this._translationKey; } }
    public int GroupID { get { return this._groupkey.ID; } }
    public string Name { get { return this._groupkey.Name; } }
    public string Comment { get { return this._groupkey.Comment; } }
    public string Text { get { return this._value != null ? this._value.Value : ""; } }
    public string FallbackText { get { return this._fallbackValue != null ? this._fallbackValue.Value : ""; } }
    public DateTime Updated { get { return this._value != null ? this._value.Updated : DateTime.Now; } }

    public TranslationValueTemplate(TranslationKey translationKey, TranslationKey fallbackTranslationKey, TranslationGroupKey groupKey)
    {
      this._groupkey = groupKey;
      this._translationKey = translationKey;
      this._value = TranslationValue.CreateManager().Load(this._translationKey, groupKey);
      if (fallbackTranslationKey != null)
        this._fallbackValue = TranslationValue.CreateManager().Load(fallbackTranslationKey, groupKey);
    }
  }

}
