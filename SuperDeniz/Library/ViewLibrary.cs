using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class ViewLibrary
{
    DatabaseLibrary dbl;

    public string viewID;
    public string code;
    public string IP;
    public DateTime insertDate;

    public ViewLibrary()
    {
        dbl = new DatabaseLibrary();
    }

    public string save()
    {
        if (!isIPViewProduct())
        {
        }
        insert();
        return null;
    }

    protected void insert()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "INSERT INTO " + dbl.tblView + @" (code, IP, insertDate) VALUES (@code, @IP, @insertDate)";
        dbl.addParameter("@code", code);
        dbl.addParameter("@IP", IP);
        dbl.addParameter("@insertDate", insertDate);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    protected bool isIPViewProduct()
    {
        string sqlCommandQuery = "SELECT * FROM " + dbl.tblView + @" WHERE code=@code AND IP=@IP";
        dbl.addParameter("@code", code);
        dbl.addParameter("@IP", IP);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count>0)
        {
            return true;
        }
        return false;
    }
}