using MobiChat.Core.Implementations;
using MobiChat.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Web.Core.Models
{
  public class ProfileDetailsViewModel : MobiViewModelBase
  {
    private ProfileCache _profile = null;
    private List<ProfileThumbnail> _additionalImages = null;
    private List<ProfileDetailValue> _descriptionValues = null;

    public int ID { get { return this._profile.ProfileData.ID; } }
    public Profile Profile { get { return this._profile.ProfileData; } }
    public ProfileDetail ProfileDetails { get { return this._profile.GetDetails(this.MobiContext.Service.ServiceData.FallbackLanguage); } }
    public List<ProfileThumbnail> AdditionalThumbnails { get { return this._additionalImages; } }
    public List<ProfileDetailValue> DescriptionValues { get { return this._descriptionValues; } }
    
    public ProfileDetailsViewModel(MobiContext context, ProfileCache profile)
      :base(context)
    {
      this._profile = profile;
      this._additionalImages = ProfileThumbnail.CreateManager().Load(this.Profile, MobiChat.Data.ThumbnailIdentifier.NotDefault);
      this._descriptionValues = ProfileDetailValue.Generate(this.ProfileDetails);
    }


  }

  public class ProfileDetailValue
  {
    private string _title = string.Empty;
    private string _value = string.Empty;

    public string Title { get { return this._title; } }
    public string Value { get { return this._value; } }

    public ProfileDetailValue(string title, string value)
    {
      this._title = title;
      this._value = value;
    }

    public static List<ProfileDetailValue> Generate(ProfileDetail details)
    {
      List<ProfileDetailValue> result = new List<ProfileDetailValue>();
      string[] newLines = details.Description.Split('\n');
      foreach (string newLine in newLines)
      {
        string[] data = newLine.Split(':');
        if (data.Length == 2)
          result.Add(new ProfileDetailValue(data[0], data[1]));
      }

      return result;
    }
  }

}
