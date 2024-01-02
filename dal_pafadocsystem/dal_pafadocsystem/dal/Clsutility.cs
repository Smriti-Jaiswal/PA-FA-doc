using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Sql;

/// <summary>
/// Summary description for Clsutility
/// </summary>
public static class Clsutility
{
    static DataTable dt;
    static DataRow dr;
    static Int32 _ctr;
    public enum dbcon
    {
        dbcnn_master,
        dbcnn_offshore,
        dbstd,
        dbsec,
        dbhrm,
        db_mqa
    }

    public static DataTable dummydt(Int32 row_num)
    {
        dt = new DataTable();
        dt.Columns.Add("slno");

        
        for (_ctr = 1; _ctr <= row_num; _ctr++)
        {
            dr = dt.NewRow();
            dr["slno"] = _ctr;
            dt.Rows.Add(dr);
        }
        dt.Columns.Add("slnolen", typeof(int), "len(slno)");
        dt.DefaultView.Sort = "slnolen,slno";
        return dt;
    }

    public static DataTable dummydt(Int32 start,Int32 end)
    {
        dt = new DataTable();
        dt.Columns.Add("slno");


        for (_ctr = start; _ctr <= end; _ctr++)
        {
            dr = dt.NewRow();
            dr["slno"] = _ctr;
            dt.Rows.Add(dr);
        }
        dt.Columns.Add("slnolen", typeof(int), "len(slno)");
        dt.DefaultView.Sort = "slnolen,slno";
        return dt;
    }

    public static DataTable vw_year(Int32 year_span)
    {
        dt = new DataTable();
        dt.Columns.Add("year");


        for (_ctr = 0; _ctr <= year_span; _ctr++)
        {
            dr = dt.NewRow();
            dr["year"] = (DateTime.Today.Year - _ctr).ToString();
            dt.Rows.Add(dr);
        }
        return dt;
    }
}