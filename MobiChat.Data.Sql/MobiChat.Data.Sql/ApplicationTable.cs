using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Senti;
using Senti.Data;
using Senti.Data.Sql;

using MobiChat.Data;


namespace MobiChat.Data.Sql
{
  public class ApplicationTable : TableBase<Application>
  {
    public static string GetColumnNames()
    {
      return TableBase<Application>.GetColumnNames(string.Empty, ApplicationTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<Application>.GetColumnNames(tablePrefix, ApplicationTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ApplicationID = new ColumnDescription("ApplicationID", 0, typeof(int));
			public static readonly ColumnDescription InstanceID = new ColumnDescription("InstanceID", 1, typeof(int));
			public static readonly ColumnDescription ApplicationTypeID = new ColumnDescription("ApplicationTypeID", 2, typeof(int));
			public static readonly ColumnDescription RuntimeTypeID = new ColumnDescription("RuntimeTypeID", 3, typeof(int));
			public static readonly ColumnDescription Name = new ColumnDescription("Name", 4, typeof(string));
			public static readonly ColumnDescription Description = new ColumnDescription("Description", 5, typeof(string));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 6, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 7, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ApplicationID,
				InstanceID,
				ApplicationTypeID,
				RuntimeTypeID,
				Name,
				Description,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ApplicationTable(SqlQuery query) : base(query) { }
    public ApplicationTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ApplicationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ApplicationID)); } }
		public int InstanceID { get { return this.Reader.GetInt32(this.GetIndex(Columns.InstanceID)); } }
		public int ApplicationTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ApplicationTypeID)); } }
		public int RuntimeTypeID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RuntimeTypeID)); } }
		public string Name { get { return this.Reader.GetString(this.GetIndex(Columns.Name)); } }
		
		public string Description 
		{
			get
			{
				int index = this.GetIndex(Columns.Description);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetString(index);
			}
		}

		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public Application CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,new Instance(this.InstanceID), new ApplicationType(this.ApplicationTypeID), new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(ApplicationType applicationType)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,new Instance(this.InstanceID), applicationType ?? new ApplicationType(this.ApplicationTypeID), new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(Instance instance)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,instance ?? new Instance(this.InstanceID), new ApplicationType(this.ApplicationTypeID), new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(RuntimeType runtimeType)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,new Instance(this.InstanceID), new ApplicationType(this.ApplicationTypeID), runtimeType ?? new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(Instance instance, ApplicationType applicationType)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,instance ?? new Instance(this.InstanceID), applicationType ?? new ApplicationType(this.ApplicationTypeID), new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(ApplicationType applicationType, RuntimeType runtimeType)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,new Instance(this.InstanceID), applicationType ?? new ApplicationType(this.ApplicationTypeID), runtimeType ?? new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(Instance instance, RuntimeType runtimeType)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,instance ?? new Instance(this.InstanceID), new ApplicationType(this.ApplicationTypeID), runtimeType ?? new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		public Application CreateInstance(Instance instance, ApplicationType applicationType, RuntimeType runtimeType)  
		{ 
			if (!this.HasData) return null;
			return new Application(this.ApplicationID,instance ?? new Instance(this.InstanceID), applicationType ?? new ApplicationType(this.ApplicationTypeID), runtimeType ?? new RuntimeType(this.RuntimeTypeID), this.Name,this.Description,this.Updated,this.Created); 
		}
		

  }
}

