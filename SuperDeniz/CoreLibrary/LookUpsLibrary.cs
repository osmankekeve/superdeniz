using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class LookUpsLibrary
{
    DatabaseLibrary dbl;

    string lookUpID;
    string value;
    string valueEN;
    string valueTR;
    string typeKey;
    string isActive;
    string custom1;
    string custom2;
    string customWide;

    public LookUpsLibrary()
    {
        dbl = new DatabaseLibrary();
    }

    public string getValueOfSetting(string _key)
    {
        string customWide = "";
        string sqlCommandQuery = "SELECT customWide FROM " + dbl.tblLookUps + @" WHERE typeKey='setting' AND value=@value";
        dbl.addParameter("@value", _key);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count == 1)
        {
            DataRow dr = dt.Rows[0];
            customWide = dr["customWide"].ToString();
        }
        return customWide;
    }
}