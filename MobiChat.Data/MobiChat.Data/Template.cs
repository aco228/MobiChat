using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MobiChat.Data
{
  public partial interface ITemplateManager
  {
    List<Template> Load();
    List<Template> Load(IConnectionInfo connection);
  }

  public partial class Template
  {
  }
}

