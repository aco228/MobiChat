using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models.Template
{
  public class TemplateServiceUpdateLogoModel : TemplateModelBase
  {
    private string _message = string.Empty;

    public string Message { get { return this._message; } }

    public TemplateServiceUpdateLogoModel(MobiContext context, string message)
      : base(context)
    {
      this._message = message;
    }
  }
}
