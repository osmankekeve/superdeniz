using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DatabaseLibrary
{
    CoreLibrary coreLib;
    protected SqlConnection conn;
    protected SqlCommand cmd;

    public string tblCategory = "";
    public string tblProduct = "";
    public string tblLookUps = "";
    public string tblProductMapping = "";
    public string tblView = "";
    public string tblOffer = "";
    public string tblOfferDetail = "";
    public string tblUser = "";
    public string tblUsingArea = "";
    public string tblImage = "";
    public string tblCompany = "";
    public string tblMails = "";
    public string tblVisitor = "";

    public DatabaseLibrary()
    {
        coreLib = new CoreLibrary();
        conn = new SqlConnection(coreLib.getConnectionString());
        cmd = new SqlCommand();
        cmd.Connection = conn;
        setNames();
    }

    private void setNames()
    {
        string dbNamePrefix = coreLib.getConfigKey("dbNamePrefix");
        tblCategory = dbNamePrefix + ".dbo" + ".tblCategory";
        tblProduct = dbNamePrefix + ".dbo" + ".tblProduct";
        tblLookUps = dbNamePrefix + ".dbo" + ".tblLookUps";
        tblProductMapping = dbNamePrefix + ".dbo" + ".tblProductMapping";
        tblView = dbNamePrefix + ".dbo" + ".tblView";
        tblOffer = dbNamePrefix + ".dbo" + ".tblOffer";
        tblOfferDetail = dbNamePrefix + ".dbo" + ".tblOfferDetail";
        tblUser = dbNamePrefix + ".dbo" + ".tblUser";
        tblUsingArea = dbNamePrefix + ".dbo" + ".tblUsingArea";
        tblImage = dbNamePrefix + ".dbo" + ".tblImage";
        tblCompany = dbNamePrefix + ".dbo" + ".tblCompany";
        tblMails = dbNamePrefix + ".dbo" + ".tblMails";
        tblVisitor = dbNamePrefix + ".dbo" + ".tblVisitor";
    }

    public DataTable executeCommand(string query, bool isproc)
    {
        if (isproc)
        {
            cmd.CommandType = CommandType.StoredProcedure;
        }
        else
            cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        DataTable dt = new DataTable();
        ConnOpen();
        SqlDataReader dr = cmd.ExecuteReader();
        dt.Load(dr);
        ConnClose();
        return dt;
    }

    public int executeNonQuery(string query)
    {
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        ConnOpen();
        int i = cmd.ExecuteNonQuery();
        ConnClose();
        return i;
    }

    protected void ConnClose()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }

    protected void ConnOpen()
    {
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
    }

    public void addParameter(string parameter, object value)
    {
        cmd.Parameters.AddWithValue(parameter, value);
    }

    public void clearParameters()
    {
        cmd.Parameters.Clear();
    }
}