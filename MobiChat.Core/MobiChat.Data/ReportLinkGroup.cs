using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IReportLinkGroupManager 
  {
    
    ReportLinkGroup Load(string name);
    ReportLinkGroup Load(IConnectionInfo connection, string name);

  }

  public partial class ReportLinkGroup
  {
  }
}

