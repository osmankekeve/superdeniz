using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class UserLibrary
{
    DatabaseLibrary dbl;
    CorrectLibrary cl;

    public string userID;
    public string userCode;
    public string userName;
    public string userType;
    public string userTypeTR;
    public string password;
    public string firstName;
    public string lastName;
    public string companyName;
    public string mailAddress;
    public string phoneNumber;
    public string activeStatus;
    public string insertDate;

    public UserLibrary()
    {
        dbl = new DatabaseLibrary();
        cl = new CorrectLibrary();
    }

    public void get(string _userCode)
    {
        clear();
        userCode = _userCode;
        select();
    }

    public void getByMailAddress(string _mailAddress)
    {
        clear();
        mailAddress = _mailAddress;
        selectByMailAddress();
    }

    public string save()
    {
        if (userName == "")
        {
            return "Lütfen kullanıcı ismi giriniz";
        }
        if (password == "")
        {
            return "Lütfen şifre giriniz";
        }
        if (firstName == "")
        {
            return "Lütfen isim giriniz";
        }
        if (lastName == "")
        {
            return "Lütfen soy isim giriniz";
        }
        if (companyName == "")
        {
            return "Lütfen firma adı giriniz";
        }
        if (mailAddress == "")
        {
            return "Lütfen mail adresi giriniz";
        }
        if (phoneNumber == "")
        {
            return "Lütfen telefon numarası giriniz";
        }
        if (isUserNameExist())
        {
            return "Kullanıcı ismi kullanımda, lütfen başka kullanıcı ismi giriniz";
        }
        if (isMailAddressExist())
        {
            return "Mail adresi kullanımda, lütfen başka mail adresi giriniz";
        }
        if (userID=="")
        {
            insert();
        }
        else
        {
            update();
        }
        return null;
    }

    protected void clear()
    {
        userID = "";
        userCode = "";
        userName = "";
        userType = "";
        password = "";
        firstName = "";
        lastName = "";
        companyName = "";
        mailAddress = "";
        phoneNumber = "";
        activeStatus = "";
        insertDate = "";
    }

    protected void insert()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "INSERT INTO " + dbl.tblUser + @" (userCode, userName, userType, password, firstName, lastName, companyName, mailAddress, phoneNumber, activeStatus, insertDate) VALUES (@userCode, @userName, @userType, @password, @firstName, @lastName, @companyName, @mailAddress, @phoneNumber, @activeStatus, @insertDate)";
        dbl.addParameter("@userCode", userCode);
        dbl.addParameter("@userName", userName);
        dbl.addParameter("@userType", userType);
        dbl.addParameter("@password", password);
        dbl.addParameter("@firstName", firstName);
        dbl.addParameter("@lastName", lastName);
        dbl.addParameter("@companyName", companyName);
        dbl.addParameter("@mailAddress", mailAddress);
        dbl.addParameter("@phoneNumber", phoneNumber);
        dbl.addParameter("@activeStatus", activeStatus);
        dbl.addParameter("@insertDate", cl.getDateTime(insertDate));
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    protected void update()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "UPDATE " + dbl.tblUser + @" SET password=@password, firstName=@firstName, lastName=@lastName, companyName=@companyName, mailAddress=@mailAddress, phoneNumber=@phoneNumber WHERE userCode=@userCode";
        dbl.addParameter("@userCode", userCode);
        dbl.addParameter("@password", password);
        dbl.addParameter("@firstName", firstName);
        dbl.addParameter("@lastName", lastName);
        dbl.addParameter("@companyName", companyName);
        dbl.addParameter("@mailAddress", mailAddress);
        dbl.addParameter("@phoneNumber", phoneNumber);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    protected void select()
    {
        dbl.clearParameters();
        string sqlCommandQuery = @"SELECT u.*, u.firstName + ' ' + u.lastName AS 'longName', convert(varchar, u.insertDate, 105) AS 'recordDate', l.valueTR AS 'userTypeTR'
FROM 
" + dbl.tblUser + @" u
LEFT JOIN " + dbl.tblLookUps + @" l ON l.value=u.userType AND l.typeKey='userType'
WHERE userCode=@userCode";
        dbl.addParameter("@userCode", userCode);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count==1)
        {
            DataRow dr = dt.Rows[0];
            userID = dr["userID"].ToString();
            userCode = dr["userCode"].ToString();
            userName = dr["userName"].ToString();
            userType = dr["userType"].ToString();
            password = dr["password"].ToString();
            firstName = dr["firstName"].ToString();
            lastName = dr["lastName"].ToString();
            companyName = dr["companyName"].ToString();
            mailAddress = dr["mailAddress"].ToString();
            phoneNumber = dr["phoneNumber"].ToString();
            activeStatus = dr["activeStatus"].ToString();
            insertDate = dr["insertDate"].ToString();
            userTypeTR = dr["userTypeTR"].ToString();
        }
    }

    protected void selectByMailAddress()
    {
        dbl.clearParameters();
        string sqlCommandQuery = @"SELECT u.*, u.firstName + ' ' + u.lastName AS 'longName', convert(varchar, u.insertDate, 105) AS 'recordDate', l.valueTR AS 'userTypeTR'
FROM 
" + dbl.tblUser + @" u
LEFT JOIN " + dbl.tblLookUps + @" l ON l.value=u.userType AND l.typeKey='userType'
WHERE mailAddress=@mailAddress";
        dbl.addParameter("@mailAddress", mailAddress);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count == 1)
        {
            DataRow dr = dt.Rows[0];
            userID = dr["userID"].ToString();
            userCode = dr["userCode"].ToString();
            userName = dr["userName"].ToString();
            userType = dr["userType"].ToString();
            password = dr["password"].ToString();
            firstName = dr["firstName"].ToString();
            lastName = dr["lastName"].ToString();
            companyName = dr["companyName"].ToString();
            mailAddress = dr["mailAddress"].ToString();
            phoneNumber = dr["phoneNumber"].ToString();
            activeStatus = dr["activeStatus"].ToString();
            insertDate = dr["insertDate"].ToString();
            userTypeTR = dr["userTypeTR"].ToString();
        }
    }

    protected bool isUserNameExist()
    {
        dbl.clearParameters();
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblUser + @" WHERE userName=@userName AND userID<>@userID AND userType='customer'";
        dbl.addParameter("@userName", userName);
        dbl.addParameter("@userID", cl.getInteger(userID));
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count>0)
        {
            return true;
        }
        return false;
    }

    protected bool isMailAddressExist()
    {
        dbl.clearParameters();
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblUser + @" WHERE mailAddress=@mailAddress AND userID<>@userID AND userType='customer'";
        dbl.addParameter("@mailAddress", mailAddress);
        dbl.addParameter("@userID", cl.getInteger(userID));
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    protected bool isCustomerCodeExist(string _userCode)
    {
        dbl.clearParameters();
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblUser + @" WHERE userCode=@userCode";
        dbl.addParameter("@userCode", _userCode);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    public string getAutoCustomerCode()
    {
        int customerCode = 0;
        do
        {
            customerCode = new Random().Next(100000, 999999);
        } while (isCustomerCodeExist(customerCode.ToString()));
        return customerCode.ToString();
    }

    public bool isCustomerExistInSystem(string _mailAddress, string _password)
    {
        dbl.clearParameters();
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblUser + @" WHERE mailAddress=@mailAddress AND password=@password";
        dbl.addParameter("@mailAddress", _mailAddress);
        dbl.addParameter("@password", _password);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    public DataTable getAllCustomers()
    {
        string sqlCommandQuery = @"SELECT u.*, u.firstName + ' ' + u.lastName AS 'longName', convert(varchar, u.insertDate, 105) AS 'recordDate', l.valueTR AS 'userTypeTR'
FROM 
" + dbl.tblUser + @" u
LEFT JOIN " + dbl.tblLookUps + @" l ON l.value=u.userType AND l.typeKey='userType' ";
        return dbl.executeCommand(sqlCommandQuery, false);
    }
}