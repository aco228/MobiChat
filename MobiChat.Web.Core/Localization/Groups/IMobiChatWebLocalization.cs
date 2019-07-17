using Senti.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Localization
{
  public interface IMobiChatWebLocalization : ILocalization
  {
    AVSLocalizationGroup AVS { get; }
    HomeLocalizationGroup Home { get; }
    ProfileDetailLocalizationGroup ProfileDetail { get; }
    TermsLocalizationGroup Terms { get; }
    HelpdeskLocalizationGroup Helpdesk { get; }
    ImprintLocalizationGroup Imprint { get; }
    ErrorLocalizationGroup Error { get; }
    ControlsLocalizationGroup Controls { get; }
    SEOLocalizationGroup SEO { get; }
  }
}
