using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class UsingAreaLibrary
{
    DatabaseLibrary dbl;

    public string usingAreaID;
    public string code;
    public string description;

    public UsingAreaLibrary()
    {
        dbl = new DatabaseLibrary();
    }

    public void get(string _usingAreaID)
    {
        clear();
        usingAreaID = _usingAreaID;
        select();
    }

    protected void clear()
    {
        usingAreaID = "";
        code = "";
        description = "";
    }

    public string save()
    {
        if (usingAreaID == "")
        {
            insert();
        }
        else
        {
            update();
        }
        return null;
    }

    protected void select()
    {
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblUsingArea + @" WHERE usingAreaID=@usingAreaID";
        dbl.addParameter("@usingAreaID", usingAreaID);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count == 1)
        {
            DataRow dr = dt.Rows[0];
            usingAreaID = dr["usingAreaID"].ToString();
            code = dr["code"].ToString();
            description = dr["description"].ToString();
        }
    }

    protected void insert()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "INSERT INTO " + dbl.tblUsingArea + @" (code, description) VALUES (@code, @description)";
        dbl.addParameter("@code", code);
        dbl.addParameter("@description", description);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    protected void update()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "UPDATE " + dbl.tblUsingArea + @" SET description=@description WHERE usingAreaID=@usingAreaID";
        dbl.addParameter("@usingAreaID", usingAreaID);
        dbl.addParameter("@description", description);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    public DataTable getProductUsingArea(string _productCode)
    {
        string sqlCommandQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY (SUM(usingAreaID)) ASC) AS 'rowNumber', * 
FROM " + dbl.tblUsingArea + @" 
WHERE code=@code GROUP BY usingAreaID, Code, description";
        dbl.addParameter("@code", _productCode);
        return dbl.executeCommand(sqlCommandQuery, false);
    }
}