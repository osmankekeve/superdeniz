using System;
using System.Configuration;
using System.Net;
using System.Web;
using System.Web.UI;

public class CoreLibrary
{
    public CoreLibrary()
    {

    }

    public string getConfigKey(string _configKey)
    {
        if (!string.IsNullOrEmpty(_configKey))
        {
            return ConfigurationManager.AppSettings[_configKey];
        }
        return "";
    }

    public string getRandomString()
    {
        Random rn = new Random();
        return rn.Next(100, 1000).ToString();
    }

    public string getConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }

    public string getIPAddress()
    {
        return HttpContext.Current.Request.Params["HTTP_CLIENT_IP"] ?? HttpContext.Current.Request.UserHostAddress;
    }

    public string GetVisitorIPAddress(bool GetLan = false)
    {
        string visitorIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (String.IsNullOrEmpty(visitorIPAddress))
            visitorIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        if (string.IsNullOrEmpty(visitorIPAddress))
            visitorIPAddress = HttpContext.Current.Request.UserHostAddress;

        if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
        {
            GetLan = true;
            visitorIPAddress = string.Empty;
        }

        if (GetLan && string.IsNullOrEmpty(visitorIPAddress))
        {
            //This is for Local(LAN) Connected ID Address
            string stringHostName = Dns.GetHostName();
            //Get Ip Host Entry
            IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
            //Get Ip Address From The Ip Host Entry Address List
            IPAddress[] arrIpAddress = ipHostEntries.AddressList;

            try
            {
                visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
            }
            catch
            {
                try
                {
                    visitorIPAddress = arrIpAddress[0].ToString();
                }
                catch
                {
                    try
                    {
                        arrIpAddress = Dns.GetHostAddresses(stringHostName);
                        visitorIPAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        visitorIPAddress = "127.0.0.1";
                    }
                }
            }

        }


        return visitorIPAddress;
    }

    public void runJavaScript(Control _control, string _script)
    {
        ScriptManager.RegisterClientScriptBlock(_control, typeof(Control), "runJavaScript" + getRandomString(),
            _script, true);
    }
}