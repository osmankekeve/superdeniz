using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

public class MailLibrary
{
    DatabaseLibrary dbl;
    CorrectLibrary cl;

    public int mailID;
    public string mailCode;
    public string senderMail;
    public string parentCode;
    public string parentType;
    public string receiverMail;
    public string mailTitle;
    public string mailContent;
    public string IP;
    public DateTime insertDate;

    public MailLibrary()
    {
        dbl = new DatabaseLibrary();
        cl = new CorrectLibrary();
    }

    public void get(string _mailCode)
    {
        clear();
        mailCode = _mailCode;
        select();
    }

    protected void clear()
    {
        mailID = 0;
        mailCode = "";
        parentCode = "";
        parentType = "";
        senderMail = "";
        receiverMail = "";
        mailTitle = "";
        mailContent = "";
        IP = "";
    }

    public string save()
    {
        insert();
        return null;
    }

    protected void insert()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "INSERT INTO " + dbl.tblMails + @" (mailCode, parentCode, parentType, senderMail, receiverMail, mailTitle, mailContent, IP, insertDate) VALUES (@mailCode, @parentCode, @parentType, @senderMail, @receiverMail, @mailTitle, @mailContent, @IP, @insertDate)";
        dbl.addParameter("@mailCode", mailCode);
        dbl.addParameter("@parentCode", parentCode);
        dbl.addParameter("@parentType", parentType);
        dbl.addParameter("@senderMail", senderMail);
        dbl.addParameter("@receiverMail", receiverMail);
        dbl.addParameter("@mailTitle", mailTitle);
        dbl.addParameter("@mailContent", mailContent);
        dbl.addParameter("@IP", IP);
        dbl.addParameter("@insertDate", insertDate);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    protected void select()
    {
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblMails + @" WHERE mailCode=@mailCode ";
        dbl.addParameter("@mailCode", mailCode);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count == 1)
        {
            DataRow dr = dt.Rows[0];
            mailID = cl.getInteger(dr["mailID"].ToString());
            mailCode = dr["mailCode"].ToString();
            parentCode = dr["parentCode"].ToString();
            parentType = dr["parentType"].ToString();
            senderMail = dr["senderMail"].ToString();
            receiverMail = dr["receiverMail"].ToString();
            mailTitle = dr["mailTitle"].ToString();
            mailContent = dr["mailContent"].ToString();
            IP = dr["IP"].ToString();
            insertDate = cl.getDateTime(dr["insertDate"].ToString());
        }
    }

    public void sendMail()
    {
        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;
        client.Timeout = 10000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("user@gmail.com", "password");

        MailMessage mm = new MailMessage("donotreply@domain.com", "sendtomyemail@domain.co.uk", "test", "test");
        mm.BodyEncoding = UTF8Encoding.UTF8;
        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        client.Send(mm);
    }
}