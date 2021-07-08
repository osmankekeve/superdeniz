using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class CompanyLibrary
{
    DatabaseLibrary dbl;
    CorrectLibrary cl;
    LookUpsLibrary lul;

    public string companyID;
    public string companyCode;
    public string companyName;
    public string companyAddress;
    public string companyPhone1;
    public string companyPhone2;
    public string companyFax;
    public string companyMailAddress;
    public string whatsAppNumber;

    public CompanyLibrary()
    {
        dbl = new DatabaseLibrary();
        cl = new CorrectLibrary();
        lul = new LookUpsLibrary();
    }

    public void get(string _companyCode)
    {
        clear();
        companyCode = _companyCode;
        select();
    }

    protected void clear()
    {
        companyID = "";
        companyCode = "";
        companyName = "";
        companyAddress = "";
        companyPhone1 = "";
        companyPhone2 = "";
        companyFax = "";
        companyMailAddress = "";
        whatsAppNumber = "";
    }

    protected void select()
    {
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblCompany + @" WHERE companyCode=@companyCode";
        dbl.addParameter("@companyCode", companyCode);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count==1)
        {
            DataRow dr = dt.Rows[0];
            companyID = dr["companyID"].ToString();
            companyCode = dr["companyCode"].ToString();
            companyName = dr["companyName"].ToString();
            companyAddress = dr["companyAddress"].ToString();
            companyPhone1 = dr["companyPhone1"].ToString();
            companyPhone2 = dr["companyPhone2"].ToString();
            companyFax = dr["companyFax"].ToString();
            companyMailAddress = dr["companyMailAddress"].ToString();
            whatsAppNumber = dr["whatsAppNumber"].ToString();
        }
    }
}