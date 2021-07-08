using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class MyData
{
    public static bool isSessionActive;

    public static class user
    {
        public static string userCode;
        public static string userType;
        public static string userName;
        public static string mailAddress;
    }

    public static void clear()
    {
        isSessionActive = false;
        user.userCode = "";
        user.userType = "";
        user.userName = "";
        user.mailAddress = "";
    }
}