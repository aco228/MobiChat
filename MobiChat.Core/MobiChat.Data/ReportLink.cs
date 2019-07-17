using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IReportLinkManager 
  {

    
    List<ReportLink> Load();
    List<ReportLink> Load(IConnectionInfo connection);

    
    List<ReportLink> Load(ReportLinkGroup group);
    List<ReportLink> Load(IConnectionInfo connection, ReportLinkGroup group);










  }

  public partial class ReportLink
  {
  }
}

