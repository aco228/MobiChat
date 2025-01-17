using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace MobiChat.Data 
{
  public partial interface IIPCountryMapManager 
  {

    List<IPCountryMap> Insert(List<IPCountryMap> items);
    List<IPCountryMap> Insert(IConnectionInfo connection, List<IPCountryMap> items);

    IPCountryMap Load(string ipAddress);
    IPCountryMap Load(IConnectionInfo connection, string ipAddress);
  }

  public partial class IPCountryMap
  {
    //public static List<IPCountryMap> Convert(GeolocationCollection collection)
    //{
    //  ICountryManager cManager = Country.CreateManager();
    //  List<Country> listCountry = cManager.Load();
    //  Dictionary<string, Country> twoLetterISOCodeDictionary = CreateTwoLetterISOCodeDictionary(listCountry);
    //  List<IPCountryMap> ipCountryMapList = ResolveCountryIDForCollection(collection, twoLetterISOCodeDictionary);
    //  return ipCountryMapList;
    //}

    //private static Dictionary<string, Country> CreateTwoLetterISOCodeDictionary(List<Country> listCountry)
    //{
    //  Dictionary<string, Country> d = new Dictionary<string, Country>();

    //  foreach (Country c in listCountry)
    //    d.Add(c.TwoLetterIsoCode, c);

    //  return d;
    //}

    //private static List<IPCountryMap> ResolveCountryIDForCollection(GeolocationCollection collection, Dictionary<string, Country> twoLetterISOCodeDictionary)
    //{
    //  List<IPCountryMap> ipCountryMapList = new List<IPCountryMap>();

    //  int counter = 0;
    //  foreach (GeolocationRecord gr in collection)
    //  {
    //    counter++;
    //    IPCountryMap item;

    //    Array.Reverse(gr.FromAddress);
    //    long fromAddress = BitConverter.ToUInt32(gr.FromAddress, 0);
    //    Array.Reverse(gr.ToAddress);
    //    long toAddress = BitConverter.ToUInt32(gr.ToAddress, 0);

    //    if (twoLetterISOCodeDictionary.ContainsKey(gr.TwoLetterIsoCode))
    //    {
    //      item = new IPCountryMap(counter, fromAddress, toAddress,
    //                              gr.TwoLetterIsoCode, twoLetterISOCodeDictionary[gr.TwoLetterIsoCode], DateTime.Now, DateTime.Now);
    //    }
    //    else
    //    {
    //      twoLetterISOCodeDictionary.Add(gr.TwoLetterIsoCode, null);
    //      item = new IPCountryMap(counter, fromAddress, toAddress,
    //                              gr.TwoLetterIsoCode, null, DateTime.Now, DateTime.Now);
    //    }
    //    ipCountryMapList.Add(item);
    //  }
    //  return ipCountryMapList;
    //}
  }
}

