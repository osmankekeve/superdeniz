using System;
using System.Data;
using System.Configuration;
using System.Resources;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Script.Serialization;

public class CorrectLibrary
{
    public CorrectLibrary()
    {

    }


    #region JSON

    public string getJSON(object _object)
    {
        return json().Serialize(_object);
    }

    public JavaScriptSerializer json()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        return serializer;
    }

    #endregion

    #region DataTable

    public bool isExistInDataTable(DataTable _dt, string _keyFieldName, string _keyFieldValue)
    {
        foreach (DataRow dr in _dt.Rows)
        {
            if (dr[_keyFieldName].ToString() == _keyFieldValue)
            {
                return true;
            }
        }
        return false;
    }

    public DataTable convertToDataTable(Hashtable _ht, string _keyField, string _valueField)
    {
        DataTable dt = new DataTable();
        foreach (DictionaryEntry de in _ht)
        {
            dt.Columns.Add(_keyField, de.Key.GetType());
            dt.Columns.Add(_valueField, de.Key.GetType());
            break;
        }
        foreach (DictionaryEntry de in _ht)
        {
            DataRow dr = dt.NewRow();
            dr[_keyField] = de.Key;
            dr[_valueField] = de.Value;
            dt.Rows.Add(dr);
        }
        return dt;
    }

    #endregion

    #region ArrayList

    public bool addToArrayList(ArrayList _al, object _value)
    {
        if (_al.Contains(_value) == false)
        {
            _al.Add(_value);
            return true;
        }
        return false;
    }

    public ArrayList convertToArrayList(DataTable _dt, string _valueField)
    {
        ArrayList al = new ArrayList();
        foreach (DataRow dr in _dt.Rows)
        {
            addToArrayList(al, dr[_valueField].ToString());
        }
        return al;
    }

    public ArrayList convertToArrayList(Hashtable _ht, bool _isValue)
    {
        ArrayList al = new ArrayList();
        foreach (String key in _ht.Keys)
        {
            if (_isValue)
            {
                addToArrayList(al, _ht[key].ToString());
            }
            else
            {
                addToArrayList(al, key);
            }
        }
        return al;
    }

    #endregion

    #region Hashtable

    public bool addToHashTable(Hashtable _ht, object _key, object _value)
    {
        if (_ht.ContainsKey(_key) == false)
        {
            _ht.Add(_key, _value);
            return true;
        }
        return false;
    }

    public bool addToHashTable(Hashtable _ht, object _key, object _value, bool _isForceToAdd)
    {
        if (_ht.ContainsKey(_key) == false)
        {
            _ht.Add(_key, _value);
            return true;
        }
        else if (_isForceToAdd)
        {
            string newKey = _key.ToString();
            int i = 1;
            while (_ht.ContainsKey(newKey))
            {
                newKey = _key.ToString() + i;
                i++;
            }
            _ht.Add(newKey, _value);
            return true;
        }
        else
        {
            _ht[_key] = _value;
        }
        return false;
    }

    public Hashtable convertToHashTable(DataTable _dt, string _keyField, string _valueField)
    {
        Hashtable ht = new Hashtable();
        foreach (DataRow dr in _dt.Rows)
        {
            addToHashTable(ht, dr[_keyField].ToString(), dr[_valueField].ToString());
        }
        return ht;
    }

    #endregion

    #region Datetime

    public DateTime getDateTimeNow()
    {
        return DateTime.Now;
    }

    public string getDateTimeNowMachineStr()
    {
        return String.Format("{0:yyyyMMddHHmmssfff}", getDateTimeNow());
    }

    public string getDateNowMachineStr()
    {
        return String.Format("{0:yyyyMMdd}", getDateTimeNow());
    }

    public DateTime getDateTime(string _datetime)
    {
        try
        {
            return Convert.ToDateTime(_datetime);
        }
        catch
        {
            return Convert.ToDateTime("01.01.1900");
        }
    }

    #endregion
    
    public int getInteger(object _number)
    {
        try
        {
            return Convert.ToInt32(_number.ToString());
        }
        catch
        {
            return 0;
        }
    }

    public int getInteger(object _number, int _default)
    {
        try
        {
            return Convert.ToInt32(_number.ToString());
        }
        catch
        {
            return _default;
        }
    }

    public int getInteger(Double _number)
    {
        try
        {
            return Convert.ToInt32(_number);
        }
        catch
        {
            return 0;
        }
    }

    public int getInteger(Double _number, int _default)
    {
        try
        {
            return Convert.ToInt32(_number);
        }
        catch
        {
            return _default;
        }
    }

    public double getDoubleOrZero(object _number)
    {
        try
        {
            Double d = Convert.ToDouble(_number);
            if (Double.IsNaN(d) || Double.IsInfinity(d))
            {
                return 0.0;
            }
            return d;
        }
        catch
        {
            return 0.0;
        }
    }

    public double getDoubleOrZero(object _number, bool _isCorrect)
    {
        try
        {
            if (_isCorrect)
            {
                return getDoubleOrZero(_number.ToString().Replace(".", ","));
            }
            return getDoubleOrZero(_number);
        }
        catch
        {
            return 0.0;
        }
    }

    public string getString(object _string)
    {
        try
        {
            return _string.ToString();
        }
        catch
        {
            return "";
        }
    }

    public bool isNullOrEmpty(string _string)
    {
        return String.IsNullOrEmpty(_string);
    }

    public bool isNotNullOrEmpty(string _string)
    {
        return !String.IsNullOrEmpty(_string);
    }
}