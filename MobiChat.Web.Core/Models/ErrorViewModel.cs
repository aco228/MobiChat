using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models
{
  public class ErrorViewModel : MobiViewModelBase
  {
    private string _title = string.Empty;
    private string _text = string.Empty;

    public string Title { get { return this._title; } set { this._title = value; } }
    public string Text { get { return this._text; } set { this._text = value; } }

    public ErrorViewModel(MobiContext context)
      : base(context)
    {

    }

    public ErrorViewModel(MobiContext context, string title, string text)
      : base(context)
    {
      this._title = title;
      this._text = text;
    }

  }
}
