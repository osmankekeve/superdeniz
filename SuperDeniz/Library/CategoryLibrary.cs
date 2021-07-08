using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class CategoryLibrary
{
    DatabaseLibrary dbl;

    public string categoryID;
    public string categoryCode;
    public string categoryName;

    public CategoryLibrary()
    {
        dbl = new DatabaseLibrary();
    }

    public void get(string _categoryCode)
    {
        clear();
        categoryCode = _categoryCode;
        select();
    }

    protected void clear()
    {
        categoryID = "";
        categoryName = "";
        categoryCode = "";
    }

    protected void select()
    {
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblCategory + @" WHERE categoryCode=@categoryCode";
        dbl.addParameter("@categoryCode", categoryCode);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count == 1)
        {
            DataRow dr = dt.Rows[0];
            categoryID = dr["categoryID"].ToString();
            categoryCode = dr["categoryCode"].ToString();
            categoryName = dr["categoryName"].ToString();
        }
    }

    public DataTable getCategories()
    {
        string sqlCommandQuery = "SELECT * FROM " + dbl.tblCategory + @" ORDER BY categoryCode ASC";
        return dbl.executeCommand(sqlCommandQuery, false);
    }
}