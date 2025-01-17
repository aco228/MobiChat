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
  public class ApplicationRouteSetMapTable : TableBase<ApplicationRouteSetMap>
  {
    public static string GetColumnNames()
    {
      return TableBase<ApplicationRouteSetMap>.GetColumnNames(string.Empty, ApplicationRouteSetMapTable.Columns.Item);
    }

    public static string GetColumnNames(string tablePrefix)
    {
      return TableBase<ApplicationRouteSetMap>.GetColumnNames(tablePrefix, ApplicationRouteSetMapTable.Columns.Item);
    }

    public class Columns
    {
		
			public static readonly ColumnDescription ApplicationRouteSetMapID = new ColumnDescription("ApplicationRouteSetMapID", 0, typeof(int));
			public static readonly ColumnDescription ApplicationID = new ColumnDescription("ApplicationID", 1, typeof(int));
			public static readonly ColumnDescription ServiceID = new ColumnDescription("ServiceID", 2, typeof(int));
			public static readonly ColumnDescription RouteSetID = new ColumnDescription("RouteSetID", 3, typeof(int));
			public static readonly ColumnDescription Updated = new ColumnDescription("Updated", 4, typeof(DateTime));
			public static readonly ColumnDescription Created = new ColumnDescription("Created", 5, typeof(DateTime));
			

			public static readonly ColumnDescription[] Item = new ColumnDescription[] 
			{
				ApplicationRouteSetMapID,
				ApplicationID,
				ServiceID,
				RouteSetID,
				Updated,
				Created
			};
    }

    public override int ColumnCount
    {
      get { return Columns.Item.Length; }
    }

    public ApplicationRouteSetMapTable(SqlQuery query) : base(query) { }
    public ApplicationRouteSetMapTable(SqlQuery query, ColumnSelectMode selectMode,
                           params ColumnDescription[] columns)
      : base(query, selectMode, columns) { }

    public ColumnDescription this[int index] { get { return Columns.Item[index]; } }

		public int ApplicationRouteSetMapID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ApplicationRouteSetMapID)); } }
		public int ApplicationID { get { return this.Reader.GetInt32(this.GetIndex(Columns.ApplicationID)); } }
		
		public int? ServiceID 
		{
			get
			{
				int index = this.GetIndex(Columns.ServiceID);
				if (this.Reader.IsDBNull(index)) return null;
				return this.Reader.GetInt32(index);
			}
		}

		public int RouteSetID { get { return this.Reader.GetInt32(this.GetIndex(Columns.RouteSetID)); } }
		public DateTime Updated { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Updated)); } }
		public DateTime Created { get { return this.Reader.GetDateTime(this.GetIndex(Columns.Created)); } }
		

	  public ApplicationRouteSetMap CreateInstance()  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,new Application(this.ApplicationID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(Application application)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,application ?? new Application(this.ApplicationID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(RouteSet routeSet)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,new Application(this.ApplicationID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), routeSet ?? new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(Service service)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,new Application(this.ApplicationID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(Application application, RouteSet routeSet)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,application ?? new Application(this.ApplicationID), (ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), routeSet ?? new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(Application application, Service service)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,application ?? new Application(this.ApplicationID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(Service service, RouteSet routeSet)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,new Application(this.ApplicationID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), routeSet ?? new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		public ApplicationRouteSetMap CreateInstance(Application application, Service service, RouteSet routeSet)  
		{ 
			if (!this.HasData) return null;
			return new ApplicationRouteSetMap(this.ApplicationRouteSetMapID,application ?? new Application(this.ApplicationID), service ?? (this.ServiceID.HasValue ? new Service(this.ServiceID.Value) : null), routeSet ?? new RouteSet(this.RouteSetID), this.Updated,this.Created); 
		}
		

  }
}

