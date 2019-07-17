using MobiChat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobiChat.Statistics.Core.Model;
using log4net;
using Senti.Security;

namespace MobiChat.Statistics.Controllers
{
  public class UsersController : Controller
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (UsersController._log == null)
          UsersController._log = LogManager.GetLogger(typeof(UsersController));
        return UsersController._log;
      }
    }

    #endregion #logging#

    
    public ActionResult Index()
    {
      List<Data.User> model = Data.User.CreateManager().Load();
      return View(model);
    } 

    
    [HttpGet]
    public ActionResult CreateUser()
    {
      UserModel model = new UserModel();
      return View(model);
    }

    [HttpPost]
    public ActionResult CreateUser(string name, string status, string type, string password)
    {

      MobiChat.Data.User user = new MobiChat.Data.User();
      UserStatus userStatus = UserStatus.Active;
      UserType userType = UserType.CreateManager().Load(int.Parse(type));
      Enum.TryParse(status, out userStatus);

      user.Username = name;
      user.Guid = Guid.NewGuid();
      user.UserStatus = userStatus;
      user.UserType = userType;
      user.Password = PasswordEncryption.Create(password).EncryptedPasswordAndSalt;
   //   user.Insert();

      return this.Json(new
      {
        status = true
      });
    }

    public ActionResult EditUser(string id)
    {
      MobiChat.Data.User user = MobiChat.Data.User.CreateManager().Load(int.Parse(id));
      var selected = user.UserStatus.ToString();
      UserModel userModel = new UserModel(user,selected);
       
      return View(userModel);
    }
     
     
    [HttpPost]
    public ActionResult EditUser(string id, string name, string status, string type)
    {
      //add code so user can change password
      MobiChat.Data.User user = MobiChat.Data.User.CreateManager().Load(int.Parse(id));
      UserStatus userStatus = UserStatus.Active;
      Enum.TryParse(status, out userStatus);
      
      user.Username = name;
      user.UserStatus = userStatus;
      user.UserType = UserType.CreateManager().Load(int.Parse(type));
     // user.Update();

      return this.Json(new
      {
        status = true
      });

    }

    
  }
}