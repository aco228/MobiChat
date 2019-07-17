using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models.Template
{
  public class TemplateModelBase : MobiViewModelBase
  {
    private bool _extendedAccess = false;
    private List<TranslationGroup> _translationGroups = null;

    public bool ExtendedAccess { get { return this._extendedAccess; } }
    public List<TranslationGroup> TranslationGroups
    {
      get
      {
        if (this._translationGroups != null)
          return this._translationGroups;

        this._translationGroups = new List<TranslationGroup>();
        List<MobiChat.Data.Localization> localizations = MobiChat.Data.Localization.CreateManager().Load(this.MobiContext.Service.ServiceData.Application);
        if (localizations == null)
          return this._translationGroups;

        ITranslationGroupManager tgManager = TranslationGroup.CreateManager();
        foreach (MobiChat.Data.Localization l in localizations)
          this._translationGroups.AddRange(tgManager.Load(l.Translation));

        return this._translationGroups;
      }
    }

    public TemplateModelBase(MobiContext context)
      : base(context)
    {
      this._extendedAccess = true;
    }

    public TemplateModelBase(MobiContext context, bool extendedAccess)
      :base(context)
    {
      this._extendedAccess = extendedAccess;
    }

  }
}
