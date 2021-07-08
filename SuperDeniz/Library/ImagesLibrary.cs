using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class ImagesLibrary
{
    DatabaseLibrary dbl;
    CorrectLibrary cl;

    public ImagesLibrary()
    {
        dbl = new DatabaseLibrary();
        cl = new CorrectLibrary();
    }

    public DataTable getProductImages(string _productSystemCode)
    {
        string sqlCommandQuery = @"SELECT * FROM " + dbl.tblImage + @" WHERE relatedRecordCode=@relatedRecordCode ";
        dbl.addParameter("@relatedRecordCode", _productSystemCode);
        return dbl.executeCommand(sqlCommandQuery, false);
    }
}