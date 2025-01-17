﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MobiChat.Web.Core
{

  public class MobiViewEngine : RazorViewEngine
  {

    //View locations
    //	~/Views/{Template}/_Specific/{Country}/{Service}/{MobileOperator}/{View}.cshtml
    //	~/Views/{Template}/_Specific/{Country}/{Service}/{View}.cshtml
    //	~/Views/{Template}/_Specific/{Country}/{View}.cshtml
    //	~/Views/{Template}/{View}.cshtml

    //Partial View Locations
    //	~/Views/{Template}/_Specific/{Country}/{Service}/{MobileOperator}/_Partial/{View}.cshtml
    //	~/Views/{Template}/_Specific/{Country}/{Service}/_Partial/{View}.cshtml
    //	~/Views/{Template}/_Specific/{Country}/_Partial/{View}.cshtml
    //	~/Views/{Template}/Partial/{View}.cshtml

    //Master View Location
    //	~/Views/{Template}/Layout/{View}.cshtml

    //Cache Key format
    //	:PaywallViewEntry:{Prefix+ViewName}:{Template}:{TwoLetterIsoCode}:{ServiceID}:{MobileOperatorID}

    //TODO: Think about folder structure for services which support two or more payment providers! For future!

    private const string CacheKeyFormat = ":MobiViewEntry:{0}:{1}:{2}:{3}:{4}:";

    public MobiViewEngine()
      : base()
    {
      this.ViewLocationFormats = new string[] {
				"~/Views/{0}/_Specific/{1}/{2}/{3}/{4}.cshtml",
				"~/Views/{0}/_Specific/{1}/{2}/{3}.cshtml",
				"~/Views/{0}/_Specific/{1}/{2}.cshtml",
				"~/Views/{0}/{1}.cshtml"
			};

      this.PartialViewLocationFormats = new string[] {
				"~/Views/{0}/_Specific/{1}/{2}/{3}/_Partial/{4}.cshtml",
				"~/Views/{0}/_Specific/{1}/{2}/_Partial/{3}.cshtml",
				"~/Views/{0}/_Specific/{1}/_Partial/{2}.cshtml",
				"~/Views/{0}/_Partial/{1}.cshtml"
			};

      this.MasterLocationFormats = new string[] {
				"~/Views/{0}/_Layout/{1}.cshtml",
			};

      //SUMMARY: This line enables cache in debug mode!
      this.ViewLocationCache = new DefaultViewLocationCache();
    }

    public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
    {
      if (controllerContext == null)
        throw new InvalidOperationException("ControllerContext must not be null!");
      if (string.IsNullOrEmpty(viewName))
        throw new InvalidOperationException("View name must be provided!");

      string viewPath = string.Empty;
      string masterPath = string.Empty;

      List<string> searchedViewLocations = null;
      List<string> searchedMasterLocations = null;

      //SUMMARY:	If full path provided for viewName with trailing ~ or / it would try to find view on that location.
      if (!string.IsNullOrEmpty(viewName) && this.IsFullPath(viewName))
        viewPath = viewName;
      else
        viewPath = this.FindPath(controllerContext, ViewType.View, viewName, useCache, out searchedViewLocations);

      //SUMMARY:	If full path provided for masterName with trailing ~ or / it would try to find view on that location.
      if (!string.IsNullOrEmpty(masterName))
        if (this.IsFullPath(masterName))
          masterPath = masterName;
        else
          masterPath = this.FindPath(controllerContext, ViewType.Master, masterName, useCache, out searchedMasterLocations);

      if (string.IsNullOrEmpty(viewPath))
        return new ViewEngineResult(searchedViewLocations);

      if (!string.IsNullOrEmpty(masterName) && string.IsNullOrEmpty(masterPath))
        return new ViewEngineResult(searchedMasterLocations);

      return new ViewEngineResult(this.CreateView(controllerContext, viewPath, masterPath), this);
    }

    public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
    {
      if (controllerContext == null)
        throw new InvalidOperationException("ControllerContext must not be null!");
      if (string.IsNullOrEmpty(partialViewName))
        throw new InvalidOperationException("View name must be provided!");

      string partialViewPath = string.Empty;
      List<string> searchedPartialViewLocations = null;

      //SUMMARY:	If full path provided for viewName with trailing ~ or / it would try to find view on that location.
      if (!string.IsNullOrEmpty(partialViewName) && this.IsFullPath(partialViewName))
        partialViewPath = partialViewName;
      else
        partialViewPath = this.FindPath(controllerContext, ViewType.PartialView, partialViewName, useCache, out searchedPartialViewLocations);

      if (string.IsNullOrEmpty(partialViewName))
        return new ViewEngineResult(searchedPartialViewLocations);

      return new ViewEngineResult(this.CreatePartialView(controllerContext, partialViewPath), this);
    }

    private string FindPath(ControllerContext controllerContext, ViewType viewType, string name, bool useCache, out List<string> searchedLocations)
    {
      searchedLocations = new List<string>();
      string[] searchLocations = null;
      object[] parameters = null;
      string cacheKey = useCache ? this.GenerateCacheKey(viewType.ToString(), name) : string.Empty;
      string path = useCache ? this.GetPathFromCache(controllerContext, cacheKey) : string.Empty;

      if (!string.IsNullOrEmpty(path))
        return path;

      switch (viewType)
      {
        case ViewType.Master:
          searchLocations = this.MasterLocationFormats;
          parameters = new[] { this.GetParameters(null).First(), name };
          break;
        case ViewType.View:
          searchLocations = this.ViewLocationFormats;
          parameters = this.GetParameters(null);
          break;
        case ViewType.PartialView:
          searchLocations = this.PartialViewLocationFormats;
          parameters = this.GetParameters(null);
          break;
        default:
          return null;
      }


      Regex regex = new Regex("{(\\d+)}", RegexOptions.None);
      foreach (string location in searchLocations)
      {
        MatchCollection matchCollection = regex.Matches(location);
        path = string.Format(location, parameters.Take(matchCollection.Count - 1).ToArray().Concat(new[] { name }).ToArray());
        if (this.VirtualPathProvider.FileExists(path))
          break;
        else
        {
          if (matchCollection.Count > 3 && MobiContext.Current.Service.ServiceData.FallbackCountry != null)
          {
            parameters[1] = MobiContext.Current.Service.ServiceData.FallbackCountry.TwoLetterIsoCode.ToLower();
            path = string.Format(location, parameters.Take(matchCollection.Count - 1).ToArray().Concat(new[] { name }).ToArray());
            if (this.VirtualPathProvider.FileExists(path))
              break;
          }
          searchedLocations.Add(path);
          path = string.Empty;
        }
      }

      if (string.IsNullOrEmpty(path))
        return null;

      if (useCache)
        lock (this.ViewLocationCache)
          if (string.IsNullOrEmpty(this.GetPathFromCache(controllerContext, cacheKey)))
            this.ViewLocationCache.InsertViewLocation(controllerContext.HttpContext, cacheKey, path);

      return this.VirtualPathProvider.GetFile(path).VirtualPath;
    }

    private string GetPathFromCache(ControllerContext controllerContext, string cacheKey)
    {
      if (string.IsNullOrEmpty(cacheKey))
        return null;

      return this.ViewLocationCache.GetViewLocation(controllerContext.HttpContext, cacheKey);
    }

    private object[] GetParameters(int? size)
    {
      string template = string.Empty;
      string twoLetterIsoCode = string.Empty;
      int? serviceID = null;
      int? mobileOperatorID = null;

      if (MobiContext.Current != null)
      {
        template = MobiContext.Current.Service != null && MobiContext.Current.Service.ServiceData != null ?
          MobiContext.Current.Service.ServiceData.Template.Name : string.Empty;
        serviceID = MobiContext.Current.Service != null && MobiContext.Current.Service.ServiceData != null ?
          MobiContext.Current.Service.ServiceData.ID : (int?)null;
        twoLetterIsoCode = MobiContext.Current.Session != null && MobiContext.Current.Session.Country != null ?
          MobiContext.Current.Session.Country.TwoLetterIsoCode.ToLower() : string.Empty;
        mobileOperatorID = MobiContext.Current.Session != null && MobiContext.Current.Session.SessionData != null && MobiContext.Current.Session.SessionData.MobileOperator != null ?
            MobiContext.Current.Session.SessionData.MobileOperator.ID : (int?)null;
      }

      object[] objects = new object[] { template, twoLetterIsoCode, serviceID, mobileOperatorID };


      if (size.HasValue)
        if (size.Value == objects.Length)
          return objects;
        else
          return objects.Take(size.Value).ToArray();
      else
        return objects;
    }

    private string GenerateCacheKey(string prefix, string name)
    {
      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("Name must be provided as we are not able to generate cache key without it.");

      string template = string.Empty;
      string twoLetterIsoCode = string.Empty;
      int? serviceID = null;
      int? mobileOperatorID = null;

      if (MobiContext.Current != null)
      {
        template = MobiContext.Current.Service != null && MobiContext.Current.Service.ServiceData != null ?
          MobiContext.Current.Service.ServiceData.Template.Name : string.Empty;
        serviceID = MobiContext.Current.Service != null && MobiContext.Current.Service.ServiceData != null ?
          MobiContext.Current.Service.ServiceData.ID : (int?)null;
        twoLetterIsoCode = MobiContext.Current.Session != null && MobiContext.Current.Session.Country != null ?
          MobiContext.Current.Session.Country.TwoLetterIsoCode.ToLower() : string.Empty;
        mobileOperatorID = MobiContext.Current.Session != null && MobiContext.Current.Session.SessionData != null && MobiContext.Current.Session.SessionData.MobileOperator != null ?
            MobiContext.Current.Session.SessionData.MobileOperator.ID : (int?)null;
      }

      return string.Format(CacheKeyFormat, prefix + name, template, twoLetterIsoCode, serviceID, mobileOperatorID);
    }

    private bool IsFullPath(string viewName)
    {
      if (viewName.Length == 0)
        return false;

      string leadingCharacter = viewName.Substring(0, 1);
      if (leadingCharacter.Equals("~") || leadingCharacter.Equals("/"))
        return true;
      return false;
    }
  }

  public enum ViewType
  {
    Master = 1,
    View = 2,
    PartialView = 3
  }
}
