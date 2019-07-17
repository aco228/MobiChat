using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Statistics.Core.Model
{
  public class TableModel : MobiViewModelBase
  {
    private string _direction = String.Empty;
    private string _status = String.Empty;
    private string _type = String.Empty;
    private int _all = 0;

    private int _total = 0;
    
    private int _received = 0;

    private int _moderated = 0;
    private int _delmoderated = 0;
    private int _notdelmoderated = 0; 

    private int _free = 0;
    private int _delfree = 0;
    private int _notdelfree = 0;

    public int All { get { return this._all; } set { this._all = value; } }
    public string Direction { get { return this._direction; } set { this._direction = value; } }
    public string Status { get { return this._status; } set { this._status = value; } }
    public string Type { get { return this._type; } set { this._type = value; } }

    public int Total { get { return this._total; } set { this._total = value; } }
    public int Received { get { return this._received; } set { this._received = value; } }
    public int Moderated { get { return this._moderated; } set { this._moderated = value; } }
    public int DelModerated { get { return this._delmoderated; } set { this._delmoderated = value; } }
    public int NotDelModerated { get { return this._notdelmoderated; } set { this._notdelmoderated = value; } }
    public int Free { get { return this._free; } set { this._free = value; } }
    public int DelFree { get { return this._delfree; } set { this._delfree = value; } }
    public int NotDelFree { get { return this._notdelfree; } set { this._notdelfree = value; } }
    

    public TableModel(MobiContext context)
      : base(context)
    {

    }

  }
}
