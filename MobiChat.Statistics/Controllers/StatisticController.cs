using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using MobiChat.Statistics.Core.Model;
using MobiChat.Statistics.Core;

namespace MobiChat.Statistics.Controllers
{
  public class StatisticController : MobiController
  {
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Dapper"].ToString());

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult SideBar()
    {
      return View("~/Views/Shared/_Menu.cshtml");
    }

    
    public ActionResult SplitFunction(string datefrom, string dateto, string split)
    {
      TableModel model = new TableModel(this.MobiContext);
      string query = String.Empty;
      DateTime refFrom;
      DateTime refTo;
      refFrom = DateTime.Parse(datefrom);
      refTo = DateTime.Parse(dateto);
        query = QuerySplitHelper(split);
      
      //WHERE m.Created >= DATEADD(d, 0, CONVERT(DATE, GETDATE()-10))

      var lista = new List<dynamic>(); 
      using (conn)
      {
        conn.Open();
        IEnumerable<dynamic> all = conn.Query(query,new {@from = refFrom, @to = refTo});

        foreach (var ii in all)
        {
          lista.Add(ii);
        }

        conn.Close();
      }


      ViewBag.Query = "From: " + refFrom + " To : " + refTo;

      return PartialView("~/Views/_Partial/_TableFilter.cshtml", lista);
    }
     
    //When page is loaded
    public ActionResult Main()
    {

      TableModel model = new TableModel(this.MobiContext);
      DateTimeRef dateTime = GetDate("hour");

      string query = QueryHelp();

      var lista = new List<dynamic>();
      using (conn)
      {
        conn.Open();
        IEnumerable<dynamic> all = conn.Query(query, new { @first = dateTime.From, @second = dateTime.To });
         
        foreach (var ii in all)
        {
          lista.Add(ii);
        }
        
        conn.Close();
      }
      
      ViewBag.Query = "From: " + dateTime.From + " To : " + dateTime.To;

      return PartialView("_Table", lista);
    }

    //When we press filter button
    public ActionResult Filter(string dateFrom, string dateTo)
    {
      TableModel model = new TableModel(this.MobiContext);

      DateTime refFrom;
      DateTime refTo;
      refFrom = DateTime.Parse(dateFrom);
      refTo = DateTime.Parse(dateTo);

      string query = QueryHelp();

      var lista = new List<dynamic>();
      using (conn)
      {
        conn.Open();
        IEnumerable<dynamic> all = conn.Query(query, new { @first = refFrom, @second = refTo });

        foreach (var ii in all)
        {
          lista.Add(ii);
        }
        
        conn.Close();
      }

      
      ViewBag.Query = "From: " + refFrom + " To : " + refTo;

      return PartialView("_Table", lista);
    }

    //When we press select button
    public ActionResult Table(string time)
    {
     
      TableModel model = new TableModel(this.MobiContext);
      DateTimeRef dateTime = GetDate(time);

      string query = QueryHelp();

      var lista = new List<dynamic>();
      using (conn)
      {
        conn.Open();
        IEnumerable<dynamic> all = conn.Query(query, new { @first = dateTime.From, @second = dateTime.To });

        foreach (var ii in all) {
          lista.Add(ii);
        }
        
        conn.Close();
      }
      
      ViewBag.Query = "From: " + dateTime.From + " To : " + dateTime.To;
      
      return PartialView("_Table", lista);
    }

   

    public string QuerySplitHelper(string split)
    {
      string query = String.Empty;

      string q = @"
                       COUNT(m.MessageID) as Messages,
		                   COUNT(case when m.MessageDirectionID = 1 AND m.MessageStatusID = 5 AND m.MessageTypeID = 1 then 1 else null end) as 'Incomming',
	                     COUNT(case when m.MessageDirectionID = 2 AND m.MessageStatusID = 7 AND m.MessageTypeID = 2 then 1 else null end) as 'DeliveredMT',
		                   COUNT(case when m.MessageDirectionID = 2 AND m.MessageStatusID = 7 AND m.MessageTypeID = 3 then 1 else null end) as 'DeliverdMTFree',
		                   COUNT(case when m.MessageDirectionID = 2 AND m.MessageStatusID = 8 AND m.MessageTypeID = 3 then 1 else null end) as 'NotDeliverdMTFree',
		                   COUNT(case when m.MessageDirectionID = 2 AND m.MessageStatusID = 6 AND m.MessageTypeID = 3 then 1 else null end) as 'SentFree'
                       
		                   FROM [MobiChat].[stats].[Message] AS m 
                INNER JOIN [MobiChat].[stats].[MessageDirection] AS md ON m.MessageDirectionID = md.MessageDirectionID
                INNER JOIN [MobiChat].[stats].[MessageStatus] AS ms ON m.MessageStatusID = ms.MessageStatusID
                INNER JOIN [MobiChat].[stats].[MessageType] AS mt ON m.MessageTypeID = mt.MessageTypeID
                       WHERE m.Created >= @from AND m.Created <= @to
		                   ";

      switch (split)
      {
        //TODO: not working
        case "hour":
        {
          query = "SELECT  CONVERT(hour, m.Created) as 'Created'  , " + q + " GROUP BY CONVERT(hour, m.Created), DATEPART(hour, m.Created) ";
          break;
        }       

        case "day":
        {
          query = "SELECT DATEADD(DAY,0, DATEDIFF(day,0, m.Created)) as 'Created' , " + q + " GROUP BY DATEADD(DAY,0, DATEDIFF(day,0, m.Created)) ";
          break;
        }
        case "week":
        {
          query = "SELECT DATEPART(wk, m.Created) as 'Created' , " + q + " GROUP BY DATEPART(wk, m.Created) ";
          break;
        }
        default:
        {
          query = "SELECT DATEADD(DAY,0, DATEDIFF(day,0, m.Created)) as 'Created' , " + q + " GROUP BY DATEADD(DAY,0, DATEDIFF(day,0, m.Created)) ";
          break;
        }
      }

    
      return query;
    }



    public string QueryHelp()
    {

      string query = @"SELECT md.Name AS 'Direction', ms.Name AS 'Status', mt.Name AS 'Type', COUNT(*) as 'All' 
                       FROM [MobiChat].[stats].[Message] AS m 
                       INNER JOIN [MobiChat].[stats].[MessageDirection] AS md ON m.MessageDirectionID = md.MessageDirectionID
                       INNER JOIN [MobiChat].[stats].[MessageStatus] AS ms ON m.MessageStatusID = ms.MessageStatusID
                       INNER JOIN [MobiChat].[stats].[MessageType] AS mt ON m.MessageTypeID = mt.MessageTypeID
                       WHERE m.Created >= @first AND m.Created <= @second
                       GROUP BY md.Name, ms.Name, mt.Name";

      return query;
    }


    //public string SplitHelper(string time)
    //{
    //  var select = String.Empty;
    //  var groupBy = String.Empty;
    //  if (time == "hour")
    //    //select = " DATEADD(WK,DATEDIFF(wk, 0, m.Created),0) as 'Created' ";
    //    //groupBy = " DATEADD(WK,DATEDIFF(wk, 0, m.Created  ),0) ";
    //    select = " DATEPART(wk, m.Created) as 'Created' ";
    //  groupBy = " DATEPART(wk, m.Created) ";
    //  if (time == "day")
    //    select = " DATEPART(wk, m.Created) as 'Created' ";
    //  groupBy = " DATEPART(wk, m.Created) ";
    //  if (time == "week")
    //    select = " DATEPART(wk, m.Created) as 'Created' ";
    //    groupBy = " DATEPART(wk, m.Created) ";
    //  return select + "+" + groupBy;
    //}

    public DateTimeRef GetDate(string time)
    {
      DateTimeRef result = new DateTimeRef();
      DateTime refFrom;
      DateTime refTo;    

      switch (time)
      {
        case "hour":
        refFrom = DateTime.Now.AddHours(-1);
        refTo = DateTime.Now;
        break;
        case "day":
        refFrom = DateTime.Today;
        refTo = DateTime.Now;
        break;
        case "yesterday":
        refFrom = DateTime.Today.AddDays(-1);
        refTo = DateTime.Today;
        break;
        case "week":
        refFrom = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        refTo = DateTime.Now;
        break;
        case "month":
        DateTime now = DateTime.Now;
        refFrom = new DateTime(now.Year,now.Month,1);
        refTo = DateTime.Now;
        break;
        case "year":
        refFrom = DateTime.Now.AddYears(-1);
        refTo = DateTime.Now;
        break;
        default:
        refFrom = DateTime.Now;
        refTo = DateTime.Now;
        break;
        
      }
         
      result.From = new DateTime(refFrom.Year, refFrom.Month, refFrom.Day, refFrom.Hour, refFrom.Minute, 0);
      result.To = new DateTime(refTo.Year, refTo.Month, refTo.Day, refTo.Hour, refTo.Minute, 0);
      return result;
    }
     
  }

  
  public class DateTimeRef
  {
    public DateTime From;
    public DateTime To;
     
    public string Date(DateTime date)
    {
      return date.ToString("yyyy-MM-dd HH:mm:ss");
    }
  }

  public static class DateTimeExtensions
  {
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
      int diff = dt.DayOfWeek - startOfWeek;
      if (diff < 0)
      {
        diff += 7;
      }
      return dt.AddDays(-1 * diff).Date;
    }
  }



}