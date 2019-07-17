using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models
{
  public class AgeVerificationViewModel : MobiViewModelBase
  {

    private string _originalUrl = string.Empty;

    public string OriginalUrl { get { return this._originalUrl; } set { this._originalUrl = value; } }

    public AgeVerificationViewModel(MobiContext context)
      : base(context)
    {

    }

  }
}
