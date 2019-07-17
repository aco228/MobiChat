using Senti.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IRuntimeTypeManager 
  {
  }

  public partial class RuntimeType
  {

    public IRuntime Instantiate(Application application)
    {
      return TypeFactory.Instantiate<IRuntime, Application>(this.TypeName, application);
    }
  }
}

