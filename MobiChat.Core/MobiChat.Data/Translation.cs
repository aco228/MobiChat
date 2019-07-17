using Senti.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MobiChat.Data
{
  public partial interface ITranslationManager
  {
    List<Translation> Load();
    List<Translation> Load(IConnectionInfo connection);


    T Load<T>(Product product);
    T Load<T>(IConnectionInfo connection, Product product);
    T Load<T>(Application application, Product product);
    T Load<T>(IConnectionInfo connection, Application application, Product product);
  }


  public partial class Translation
  {
  }
}

