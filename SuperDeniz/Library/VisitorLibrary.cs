using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class VisitorLibrary
{
    DatabaseLibrary dbl;
    CorrectLibrary cl;

    public string visitorIP;
    public DateTime insertDate;

    public VisitorLibrary()
    {
        dbl = new DatabaseLibrary();
        cl = new CorrectLibrary();
    }

    public string save()
    {
        if (isIPVisitedSite())
        {
        }
        insert();
        return null;
    }

    protected void insert()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "INSERT INTO " + dbl.tblVisitor + @" (visitorIP, insertDate) VALUES (@visitorIP, @insertDate)";
        dbl.addParameter("@visitorIP", visitorIP);
        dbl.addParameter("@insertDate", insertDate);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    protected bool isIPVisitedSite()
    {
        string sqlCommandQuery = "SELECT * FROM " + dbl.tblVisitor + @" WHERE visitorIP=@visitorIP";
        dbl.addParameter("@visitorIP", visitorIP);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count==0)
        {
            return true;
        }
        return false;
    }

    public DataTable showDailyVisitorCount()
    {
        string sqlCommandQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY (CONVERT(DATE, insertDate)) DESC) AS 'rowNumber', CONVERT(DATE, insertDate) AS 'visitingDate', COUNT(visitorIP) AS 'visitorCount' 
FROM " + dbl.tblVisitor + @" 
GROUP BY CONVERT(DATE, insertDate) ";
        return dbl.executeCommand(sqlCommandQuery, false);
    }
}