using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat
{
  public class ApplicationBase : IApplication
  {
    private Data.Application _applicationData = null;

    public Data.Application ApplicationData { get { return this._applicationData; } }

    public ApplicationBase(Data.Application application)
    {
      this._applicationData = application;
    }


  }
}
