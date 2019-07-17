using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti.Data;
using MobiChat.Data;

 

namespace MobiChat.Data 
{
  public partial interface IUserDetailManager : IDataManager<UserDetail> 
  {
	

  }

  public partial class UserDetail : MobiChatObject<IUserDetailManager> 
  {
		private User _user;
		private int _countryID = -1;
		private Gender _gender;
		private string _firstName = String.Empty;
		private string _lastName = String.Empty;
		private string _address = String.Empty;
		private string _mail = String.Empty;
		private string _contact = String.Empty;
		private DateTime? _birthDate = DateTime.MinValue;
		

		public User User 
		{
			get
			{
				if (this._user != null &&
						this._user.IsEmpty)
					if (this.ConnectionContext != null)
						this._user = User.CreateManager().LazyLoad(this.ConnectionContext, this._user.ID) as User;
					else
						this._user = User.CreateManager().LazyLoad(this._user.ID) as User;
				return this._user;
			}
			set { _user = value; }
		}

		public int CountryID{ get {return this._countryID; } set { this._countryID = value;} }
		public Gender Gender 
		{
			get
			{
				if (this._gender != null &&
						this._gender.IsEmpty)
					if (this.ConnectionContext != null)
						this._gender = Gender.CreateManager().LazyLoad(this.ConnectionContext, this._gender.ID) as Gender;
					else
						this._gender = Gender.CreateManager().LazyLoad(this._gender.ID) as Gender;
				return this._gender;
			}
			set { _gender = value; }
		}

		public string FirstName{ get {return this._firstName; } set { this._firstName = value;} }
		public string LastName{ get {return this._lastName; } set { this._lastName = value;} }
		public string Address{ get {return this._address; } set { this._address = value;} }
		public string Mail{ get {return this._mail; } set { this._mail = value;} }
		public string Contact{ get {return this._contact; } set { this._contact = value;} }
		public DateTime? BirthDate { get { return this._birthDate; } set { this._birthDate = value;} }
		

    public override bool IsInsertable { get { return true;} }

    public override bool IsDeletable { get { return false;} }

    public override bool IsUpdatable { get { return true;} }

    public UserDetail()
    { 
    }

    public UserDetail(int id): base(id, DateTime.Now, DateTime.Now, true)
    {
    }

    public UserDetail(int id,  User user, int countryID, Gender gender, string firstName, string lastName, string address, string mail, string contact, DateTime? birthDate, DateTime updated, DateTime created): base(id, updated, created, false)
    {
			this._user = user;
			this._countryID = countryID;
			this._gender = gender;
			this._firstName = firstName;
			this._lastName = lastName;
			this._address = address;
			this._mail = mail;
			this._contact = contact;
			this._birthDate = birthDate;
			
    }

    public override object Clone(bool deepClone)
    {
      return new UserDetail(-1,  this.User,this.CountryID, this.Gender,this.FirstName,this.LastName,this.Address,this.Mail,this.Contact,this.BirthDate, DateTime.Now, DateTime.Now);
    }
  }
}

