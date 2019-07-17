using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Management.Core
{
  public class ManagementApplicationRuntime : RuntimeBase
  {
    
    private bool _isInitialized = false;
    private static readonly object MobiRuntimeInitializationLockObject = new object();

    public ManagementApplicationRuntime(Application application)
      :base(application)
    {

    }

    public override bool Initialize(string siteName)
    {
      if (this._isInitialized)
        return true;

      // TODO: Implement this

      return true;
    }
  }
}
