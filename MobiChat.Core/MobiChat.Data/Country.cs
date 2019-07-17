using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;
 

namespace MobiChat.Data 
{
  public partial interface ICountryManager 
  {
    List<Country> Load();
    List<Country> Load(IConnectionInfo connection);
    Country Load(string value, CountryIdentifier identifier);
    Country Load(IConnectionInfo connection, string value, CountryIdentifier identifier);
  }

  public partial class Country
  {
  }
}

