using MobiChat.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models
{
  public class InsertNumberModel : MobiViewModelBase
  {
    private ProfileCache _profile = null;

    public ProfileCache Profile { get { return this._profile; } }

    public InsertNumberModel(MobiContext context, ProfileCache profile)
      :base(context)
    {
      this._profile = profile;
    }
  }
}
