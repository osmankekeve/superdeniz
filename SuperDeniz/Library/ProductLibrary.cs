using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class ProductLibrary
{
    DatabaseLibrary dbl;
    CorrectLibrary cl;
    LookUpsLibrary lul;

    public string productID;
    public string productCode;
    public string productName;
    public string body;
    public string reflector;
    public string socket;
    public string paint;
    public string gasket;
    public string glass;
    public string weight;
    public string size;
    public string deep;
    public string categoryID;
    public string imageUrl;
    public string Code;
    public string view;
    public string videoPath;
    public string pdfPath;

    public ProductLibrary()
    {
        dbl = new DatabaseLibrary();
        cl = new CorrectLibrary();
        lul = new LookUpsLibrary();
    }

    public void get(string _productID)
    {
        clear();
        productID = _productID;
        select();
    }

    protected void clear()
    {
        productID = "";
        productCode = "";
        productName = "";
        body = "";
        reflector = "";
        socket = "";
        paint = "";
        gasket = "";
        glass = "";
        weight = "";
        size = "";
        deep = "";
        categoryID = "";
        imageUrl = "";
        Code = "";
        view = "";
        videoPath = "";
        pdfPath = "";
    }

    public string save()
    {
        if (productID == "")
        {

        }
        else
        {
            update();
        }
        return null;
    }

    protected void select()
    {
        string sqlCommandQuery = @"SELECT p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR, p.imageUrl) AS 'imageUrl', p.Code, COUNT(v.code) AS 'view', p.videoPath, p.pdfPath
FROM " + dbl.tblProduct + @" p
LEFT JOIN " + dbl.tblView + @" v ON v.code = p.Code
WHERE p.productID = @productID
GROUP BY p.productID, p.productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR, p.imageUrl), p.Code, p.videoPath, p.pdfPath";
        dbl.addParameter("@productID", productID);
        DataTable dt = dbl.executeCommand(sqlCommandQuery, false);
        if (dt.Rows.Count==1)
        {
            DataRow dr = dt.Rows[0];
            productID = dr["productID"].ToString();
            productCode = dr["productCode"].ToString();
            productName = dr["productName"].ToString();
            body = dr["body"].ToString();
            reflector = dr["reflector"].ToString();
            socket = dr["socket"].ToString();
            paint = dr["paint"].ToString();
            gasket = dr["gasket"].ToString();
            glass = dr["glass"].ToString();
            weight = dr["weight"].ToString();
            size = dr["size"].ToString();
            deep = dr["deep"].ToString();
            imageUrl = dr["imageUrl"].ToString();
            Code = dr["Code"].ToString();
            view = dr["view"].ToString();
            videoPath = cl.getString(dr["videoPath"].ToString());
            pdfPath = cl.getString(dr["pdfPath"].ToString());
        }
    }

    protected void update()
    {
        dbl.clearParameters();
        string sqlCommandQuery = "UPDATE " + dbl.tblProduct + @" SET productName=@productName, body=@body, reflector=@reflector, socket=@socket, paint=@paint, gasket=@gasket, glass=@glass, weight=@weight, size=@size, deep=@deep WHERE productID=@productID";
        dbl.addParameter("@productID", productID);
        dbl.addParameter("@productName", productName);
        dbl.addParameter("@body", body);
        dbl.addParameter("@reflector", reflector);
        dbl.addParameter("@socket", socket);
        dbl.addParameter("@paint", paint);
        dbl.addParameter("@gasket", gasket);
        dbl.addParameter("@glass", glass);
        dbl.addParameter("@weight", weight);
        dbl.addParameter("@size", size);
        dbl.addParameter("@deep", deep);
        int i = dbl.executeNonQuery(sqlCommandQuery);
    }

    public DataTable getProductsByCategoryID(string _categoryCode)
    {
        string sqlCommandQuery = @"SELECT p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl) AS 'imageUrl', p.Code, COUNT(v.code) AS 'view', pm.sort 
FROM " + dbl.tblProductMapping + @" pm
LEFT JOIN " + dbl.tblProduct + @" p ON p.Code = pm.code
LEFT JOIN " + dbl.tblView + @" v ON v.code=p.Code ";
        if (_categoryCode != "")
        {
            sqlCommandQuery += " WHERE pm.categoryCode=@categoryCode ";
            dbl.addParameter("@categoryCode", _categoryCode);
        }
        sqlCommandQuery += @" 
GROUP BY p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl), p.Code, pm.sort 
ORDER BY pm.sort ASC";
        return dbl.executeCommand(sqlCommandQuery, false);
    }

    public DataTable getSearchedProduct(string _searchText)
    {
        string sqlCommandQuery = @"SELECT p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl) AS 'imageUrl', p.Code, COUNT(v.code) AS 'view', pm.sort
FROM " + dbl.tblProductMapping + @" pm
LEFT JOIN " + dbl.tblProduct + @" p ON p.Code = pm.code
LEFT JOIN " + dbl.tblView + @" v ON v.code=p.Code WHERE p.productName LIKE '%"+_searchText+@"%'";
        sqlCommandQuery += @" 
GROUP BY p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl), p.Code, pm.sort  
ORDER BY pm.sort ASC";
        return dbl.executeCommand(sqlCommandQuery, false);
    }

    public DataTable getIndexPageProducts()
    {
        string sqlCommandQuery = @"SELECT p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl) AS 'imageUrl', p.Code, COUNT(v.code) AS 'view', p.sort
FROM " + dbl.tblProduct + @" p  
LEFT JOIN " + dbl.tblView + @" v ON v.code=p.Code
WHERE productID IN (" + lul.getValueOfSetting("indexPageProducts") + @") 
GROUP BY p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl), p.Code, p.sort 
ORDER BY p.sort ASC";
        return dbl.executeCommand(sqlCommandQuery, false);
    }

    public DataTable getAllProducts()
    {
        string sqlCommandQuery = @"SELECT p.productID, p. productCode, p.productName, p.body, p.reflector, p.socket, p.paint, p.gasket, p.glass, p.weight, p.size, p.deep, CONVERT(NVARCHAR,p.imageUrl) AS 'imageUrl', p.Code , p.sort
FROM " + dbl.tblProduct + @" p 
ORDER BY p.sort ASC";
        return dbl.executeCommand(sqlCommandQuery, false);
    }

    public DataTable getProductViewCount()
    {
        string sqlCommandQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY (COUNT(v.viewID)) DESC) AS 'rowNumber', p.productCode, p.productName, COUNT(v.viewID) AS 'viewCount'
FROM " + dbl.tblProduct + @" p
LEFT JOIN " + dbl.tblView + @" v ON v.code=p.Code
GROUP BY p.productCode, p.productName ";
        return dbl.executeCommand(sqlCommandQuery, false);
    }
}