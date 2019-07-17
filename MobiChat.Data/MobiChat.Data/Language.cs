using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Senti.Data;


namespace MobiChat.Data
{
  public partial interface ILanguageManager
  {

    List<Language> Load();
    List<Language> Load(IConnectionInfo connection);



    Language Load(string name);
    Language Load(IConnectionInfo connection, string name);
    Language Load(string value, LanguageIdentifier identifier);
    Language Load(IConnectionInfo connection, string value, LanguageIdentifier identifier);


  }

  public partial class Language
  {
  }
}

