using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models.Template
{
  public class TemplateConfigurationModel : TemplateModelBase
  {
    //private ServiceContentGroupMap _serviceContentGroupMap = null;
    //private List<ContentGroup> _contentGroup = null;
    //private List<ContentGroupType> _contentGroupType = null;
    //private List<Template> _templates = null;
    //private List<ServiceType> _serviceType = null;

    //public int ServiceContentGroupID { get { return this._serviceContentGroupMap == null ? -1 : this._serviceContentGroupMap.ID; } }
    //public int ContentGroupID { get { return this._serviceContentGroupMap != null && this._serviceContentGroupMap.ContentGroup != null ? this._serviceContentGroupMap.ContentGroup.ID : -1; } }
    //public int ContentGroupTypeID { get { return this._serviceContentGroupMap != null ? this._serviceContentGroupMap.ContentGroup.ContentGroupType.ID : -1; } }
    public int TempalteID { get { return MobiContext.Current.Service.ServiceData.Template.ID; } }
    public int ServiceTypeID { get { return MobiContext.Current.Service.ServiceData.ServiceType.ID; } }

    //public List<ContentGroup> ContentGroups { get { return this._contentGroup; } }
    //public List<ContentGroupType> ContentGroupType { get { return this._contentGroupType; } }
    //public List<Template> Templates { get { return this._templates; } }
    //public List<ServiceType> ServiceType { get { return this._serviceType; } }

    public TemplateConfigurationModel(MobiContext context, bool extendedAccess)
      :base(context, extendedAccess)
    {

    }

  }
}
