using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobiChat.Web.Data;
using Senti.Data; 

namespace MobiChat.Web.Data 
{
  public partial interface IProfileThumbnailDataManager 
  {
    
    List<ProfileThumbnailData> Load(ProfileThumbnail profileThumbnail);
    List<ProfileThumbnailData> Load(IConnectionInfo connection, ProfileThumbnail profileThumbnail);

 
  }

  public partial class ProfileThumbnailData
  {

    private string _dataFilePath;
    public string DataFilePath { get { return this._dataFilePath; } set { this._dataFilePath = value; } }

    public static List<ProfileThumbnailData> LoadByProfileThumbnail(ProfileThumbnail profileThumbnail, IProfileThumbnailDataManager ptdManager = null)
    {
      List<ProfileThumbnailData> result = new List<ProfileThumbnailData>();

      if(ptdManager == null)
        ptdManager = ProfileThumbnailData.CreateManager();

      using(ConnectionInfo connection = new ConnectionInfo(System.Data.IsolationLevel.ReadUncommitted))
      {
        try
        {
          connection.Transaction.Begin();
          result.AddRange(ptdManager.Load(connection, profileThumbnail));
          connection.Transaction.Commit();
        }
        catch
        {
          //throw new ArgumentException("Something went wrong in ProfileThumbnailData loading");
          return result;
        }
      }
      return result;
    }

  }
}

