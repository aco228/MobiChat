using Cashflow.Message;
using Cashflow.Message.Mobile;
using log4net;
using MobiChat.Core;
using MobiChat.Core.Implementations;
using MobiChat.Data;
using MobiChat.Web.Core;
using MobiChat.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MobiChat.Web.Controllers
{
  public class ChatProfileController : MobiController
  {

    #region #logging#

    private static ILog _log = null;

    protected static ILog Log
    {
      get
      {
        if (ChatProfileController._log == null)
          ChatProfileController._log = LogManager.GetLogger(typeof(ChatProfileController));
        return ChatProfileController._log;
      }
    }

    #endregion #logging#


    public ActionResult Index(string id)
    {
      ProfileCache profileCacheObj = (this.MobiContext.Service.Cache as ChatCache).GetProfileByID(id);
      if (profileCacheObj == null)
      {
        Log.Error("Could not load profile with iD:{0} from cache");
        return this.InternalError();
      }

      ProfileDetailsViewModel model = new ProfileDetailsViewModel(this.MobiContext, profileCacheObj);
      return View("ChatProfileDetails", model);
    }

    public ActionResult InsertNumber(string id)
    {
      ProfileCache profileCacheObj = (this.MobiContext.Service.Cache as ChatCache).GetProfileByID(id);
      if (profileCacheObj == null)
      {
        Log.Error("Could not load profile with iD:{0} from cache");
        return this.InternalError();
      }

      InsertNumberModel model = new InsertNumberModel(this.MobiContext, profileCacheObj);
      return View("InsertNumber", model);
    }

    // TODO: Dummy function.. make this more dynamic
    public ActionResult SendNumber(string number)
    {
      if (string.IsNullOrEmpty(number))
        return this.Json(new { status = false, message = "There is no input" }, JsonRequestBehavior.AllowGet);

      // DELETE THIS AFTER TESTING
      if(number == "33228")
      {
        Report.TryReportPxid(this.MobiContext.HttpContext.Request);
        return this.Json(new { status = true, message = "Vaše žádost byla úspěšně odeslána" }, JsonRequestBehavior.AllowGet);
      }

      MobileOperator mobileOperator = null;
      number = number.Replace(" ", string.Empty).Replace("+", string.Empty);

      // check if number is correct
      for (int i = 0; i < number.Length; i++ )
        if (!Char.IsNumber(number[i]))
        {
          Log.Error("Number is not in correct format (" + number + ")");
          return this.Json(new { status=false, message="Incorrect format" }, JsonRequestBehavior.AllowGet);
        }
       
      if (!number.StartsWith("420"))
        number = "420" + number;

      // TMOBILE
      if (number.StartsWith("42073"))
        mobileOperator = MobileOperator.CreateManager().Load(50);
      // O2
      else if (number.StartsWith("42072") || number.StartsWith("42070"))
        mobileOperator = MobileOperator.CreateManager().Load(49);
      // VODAFONE
      else if (number.StartsWith("42077"))
        mobileOperator = MobileOperator.CreateManager().Load(53);
      // Ufone
      else if (number.StartsWith("42079"))
        mobileOperator = MobileOperator.CreateManager().Load(52);

      if(mobileOperator == null)
      {
        Log.Error("MobileOperator is not loaded for some reason (" + number + ")");
        return this.Json(new { status = false, message = "Error" }, JsonRequestBehavior.AllowGet);
      }

      ServiceConfiguration serviceConfiguration = ServiceConfiguration.CreateManager().Load(this.MobiContext.Service.ServiceData.ServiceConfiguration.ID);
      Log.Info("SendNumber::Before sent number is " + number);

      // TODO: remove url to config
      Cashflow.Client.MobileExtensionClient client = new Cashflow.Client.MobileExtensionClient("http://v10.api.cashflow-payment.com/mobile.svc/soap12");

      try
      {
        SendSmsRequest smsRequest = new SendSmsRequest(RequestMode.Default,
                                                       string.Empty,
                                                       serviceConfiguration.PaymentConfiguration.PaymentCredentials.Username,  // username
                                                       serviceConfiguration.PaymentConfiguration.PaymentCredentials.Password,  // password
                                                       serviceConfiguration.PaymentConfiguration.BehaviorModel.Guid, //bm
                                                       MobiContext.Service.ServiceData.Product.ExternalProductGuid, //product
                                                       serviceConfiguration.PaymentConfiguration.PaymentInterface.ExternalPaymentInterfaceGuid, //interface
                                                       MobiContext.Service.ServiceData.FallbackCountry.TwoLetterIsoCode,
                                                       serviceConfiguration.PaymentConfiguration.PaymentProvider.ExternalPaymentProviderGuid.Value, //provider
                                                       mobileOperator.ExternalMobileOperatorID.ToString(),
                                                       number,
                                                       "DOBRY DEN,VITAME VAS V SMS CHATU,VASE SMS ZPRAVA BYLA DORUCENA A BYLA PREDANA VASEMU KONTAKTU.OD 18 LET.CENA ZA SMS/60 KC VC.DPH,INFOLINKA 844444484",
                                                       //"Vítejte na dívky",
                                                       Guid.NewGuid().ToString(), // "send sms ref."
                                                       string.Empty,
                                                       null);
        SendSmsResponse response = client.SendSms(smsRequest);

        // Report.TryReportPxid(this.MobiContext.HttpContext.Request);

        if (response.Status.Code == MessageStatusCode.Success)
        {
          Log.Info("SendNumber::First message is successfully processed and sent to cashflow: " + number);

          SmsChatArguments dummyArguments = new SmsChatArguments() { Content  = "bla" };
          SendSmsRequest smsRequest2 = new SendSmsRequest(RequestMode.Default,
                                                       string.Empty,
                                                       serviceConfiguration.PaymentConfiguration.PaymentCredentials.Username,  // username
                                                       serviceConfiguration.PaymentConfiguration.PaymentCredentials.Password,  // password
                                                       serviceConfiguration.PaymentConfiguration.BehaviorModel.Guid, //bm
                                                       MobiContext.Service.ServiceData.Product.ExternalProductGuid, //product
                                                       serviceConfiguration.PaymentConfiguration.PaymentInterface.ExternalPaymentInterfaceGuid, //interface
                                                       MobiContext.Service.ServiceData.FallbackCountry.TwoLetterIsoCode,
                                                       serviceConfiguration.PaymentConfiguration.PaymentProvider.ExternalPaymentProviderGuid.Value, //provider
                                                       mobileOperator.ExternalMobileOperatorID.ToString(),
                                                       number,
                                                       "Ahojky,jestli hledas vzajemne porozumeni a prijemne chvilky travene ve dvou,tak to pises spravne:)Nechci uz byt na vsechno sama,jak jsi na tom ty?",
                                                       Guid.NewGuid().ToString(), // "send sms ref."
                                                       string.Empty,
                                                       dummyArguments.ToMessageArguments());
          SendSmsResponse response2 = client.SendSms(smsRequest2);

          if (response2.Status.Code == MessageStatusCode.Success)
            return this.Json(new { status = true, message = "Vaše žádost byla úspěšně odeslána" }, JsonRequestBehavior.AllowGet);
          else
          {
            Log.Error(string.Format("SendNumber::Cashflow returned us error on second message (SubCode='{0}', Message='{1}'",
              response.Status.SubCode.ToString(),
              response.Status.Message));
            return this.Json(new { status = false, message = Translations.Web.Error.ErrInternal }, JsonRequestBehavior.AllowGet);
          }

        }
        else
        {
          Log.Error(string.Format("SendNumber::Cashflow returned us error on first message (SubCode='{0}', Message='{1}'",
            response.Status.SubCode.ToString(),
            response.Status.Message));
          return this.Json(new { status = false, message = Translations.Web.Error.ErrInternal }, JsonRequestBehavior.AllowGet);
        }
      }
      catch(Exception e)
      {
        Log.Error("SendNumber::Cashflow returned us fatal error", e);
        return this.Json(new { status = false, message = Translations.Web.Error.ErrInternal }, JsonRequestBehavior.AllowGet);
      }

    }

  }
}