using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Localization
{
  public class MobiChatWebLocalization : LocalizationBase<MobiChatWebLocalization>, IMobiChatWebLocalization
  {
    private AVSLocalizationGroup _aVS = null;
		private HomeLocalizationGroup _home = null;
		private ProfileDetailLocalizationGroup _profileDetail = null;
		private TermsLocalizationGroup _terms = null;
		private HelpdeskLocalizationGroup _helpdesk = null;
		private ImprintLocalizationGroup _imprint = null;
		private ErrorLocalizationGroup _error = null;
		private ControlsLocalizationGroup _controls = null;
		private SEOLocalizationGroup _sEO = null;
		
    public AVSLocalizationGroup AVS { get { return this._aVS ?? (this.HasFallback ? this.Fallback.AVS : AVSLocalizationGroup.Empty); } }
		public HomeLocalizationGroup Home { get { return this._home ?? (this.HasFallback ? this.Fallback.Home : HomeLocalizationGroup.Empty); } }
		public ProfileDetailLocalizationGroup ProfileDetail { get { return this._profileDetail ?? (this.HasFallback ? this.Fallback.ProfileDetail : ProfileDetailLocalizationGroup.Empty); } }
		public TermsLocalizationGroup Terms { get { return this._terms ?? (this.HasFallback ? this.Fallback.Terms : TermsLocalizationGroup.Empty); } }
		public HelpdeskLocalizationGroup Helpdesk { get { return this._helpdesk ?? (this.HasFallback ? this.Fallback.Helpdesk : HelpdeskLocalizationGroup.Empty); } }
		public ImprintLocalizationGroup Imprint { get { return this._imprint ?? (this.HasFallback ? this.Fallback.Imprint : ImprintLocalizationGroup.Empty); } }
		public ErrorLocalizationGroup Error { get { return this._error ?? (this.HasFallback ? this.Fallback.Error : ErrorLocalizationGroup.Empty); } }
		public ControlsLocalizationGroup Controls { get { return this._controls ?? (this.HasFallback ? this.Fallback.Controls : ControlsLocalizationGroup.Empty); } }
		public SEOLocalizationGroup SEO { get { return this._sEO ?? (this.HasFallback ? this.Fallback.SEO : SEOLocalizationGroup.Empty); } }
		
    
    public MobiChatWebLocalization()
      :base(null)
    {
    }

    public MobiChatWebLocalization(MobiChatWebLocalization fallback)
      :base(fallback)
    {
    }

    public override ILocalizationGroup GetGroup(string name)
    {
      switch (name)
      {
        case "AVS":
					if (this._aVS == null) this._aVS = new AVSLocalizationGroup(this);
					return this._aVS;
				case "Home":
					if (this._home == null) this._home = new HomeLocalizationGroup(this);
					return this._home;
				case "ProfileDetail":
					if (this._profileDetail == null) this._profileDetail = new ProfileDetailLocalizationGroup(this);
					return this._profileDetail;
				case "Terms":
					if (this._terms == null) this._terms = new TermsLocalizationGroup(this);
					return this._terms;
				case "Helpdesk":
					if (this._helpdesk == null) this._helpdesk = new HelpdeskLocalizationGroup(this);
					return this._helpdesk;
				case "Imprint":
					if (this._imprint == null) this._imprint = new ImprintLocalizationGroup(this);
					return this._imprint;
				case "Error":
					if (this._error == null) this._error = new ErrorLocalizationGroup(this);
					return this._error;
				case "Controls":
					if (this._controls == null) this._controls = new ControlsLocalizationGroup(this);
					return this._controls;
				case "SEO":
					if (this._sEO == null) this._sEO = new SEOLocalizationGroup(this);
					return this._sEO;
				
        default:
          return null;
      }
    }

  }
}
