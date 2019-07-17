using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobiChat.Data;
using System.Web.Mvc;

namespace MobiChat.Statistics.Core.Model
{
  public class UserModel
  {

    private User _user = null;
    private List<UserType> _userType = null;
    private string _selectedStatus = null;

    public User User { get { return this._user; } set { this._user = value; } }
    public List<UserType> UserType { get { return this._userType;  } set { this._userType = value; } }
    public string SelectedStatus { get { return this._selectedStatus; } set { this._selectedStatus = value; } }

    //constructor with one  argument
    public UserModel(User user, string selected)
    {
      this.User = user;
      this.UserType = MobiChat.Data.UserType.CreateManager().Load();
      this.SelectedStatus = selected;
    }
    //constructor without arguments
    public UserModel()
    {
      this.UserType = MobiChat.Data.UserType.CreateManager().Load();
    }


    
  }
}
