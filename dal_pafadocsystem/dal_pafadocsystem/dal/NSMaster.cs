using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using NSDataAccess;

namespace NSMaster
{
    //General Module Start
    public class blcountrymast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _country_name;
        private string _currency;
        private string _nationality;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string country_name
        {
            set { _country_name = value; }
            get { return _country_name; }
        }
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        public string nationality
        {
            set { _nationality = value; }
            get { return _nationality; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public DataTable vw_countryall()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from [master].[tblcountrymast] where del_sts=0 order by country_name";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        public DataTable vw_countryallbypartnerid(string partnerid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            if (partnerid.ToString().ToUpper() == "LCS0009")
            {
                dal.sqlcmdstr = "select * from [master].[tblcountrymast] where transid not in ('4A6EA5AB-D5B2-4E88-A6DD-C22DC76352D5') and del_sts=0 order by country_name";
                mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            }
            else if(partnerid.ToString().ToUpper() == "LC000111")
            {
                dal.sqlcmdstr = "select * from [master].[tblcountrymast] where transid not in ('4A6EA5AB-D5B2-4E88-A6DD-C22DC76352D5') and del_sts=0 order by country_name";
                mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            }
            else
            {
                dal.sqlcmdstr = "select * from [master].[tblcountrymast] where del_sts=0 order by country_name";
                mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            }

            return mdt;
        }

        public DataTable vw_country(string countryid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>(1);

            dal.sqlcmdstr = "select * from [master].[tblcountrymast] where del_sts=0 and transid=?";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = countryid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        public DataTable vw_currencyall()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select distinct currency from [master].[tblcountrymast] where del_sts=0";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
    }
    public class blreligionmast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _religionname;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string religionname
        {
            set { _religionname = value; }
            get { return _religionname; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public DataTable vw_religionnall()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from [master].[tblreligionmast] where del_sts=0 order by religionname";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
    }
    public class blsalmast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _salname;
        private string _saldescription;
        private Int32 _serial;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string salname
        {
            set { _salname = value; }
            get { return _salname; }
        }
        public string saldescription
        {
            set { _saldescription = value; }
            get { return _saldescription; }
        }
        public Int32 serial
        {
            set { _serial = value; }
            get { return _serial; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public DataTable vw_salall()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from [master].[tblsalmast] where del_sts=0 order by serial";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
    }
    public class blremarks
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _remarks;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        public DataTable vw_remarks()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from [master].[tblremarks] order by remarks";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
    }
    public class blacaqualification
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _qualiname;
        private string _type;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string qualiname
        {
            set { _qualiname = value; }
            get { return _qualiname; }
        }
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public DataTable vw_acaqualification_aca()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select* from master.tblacaqualification where type in ('All','Aca') order by qualiname";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
        public DataTable vw_acaqualification_tech()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select* from master.tblacaqualification where type in ('All','Tech') order by qualiname";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
    }
    //General Module End

    //Academic Module Start
    public class bldeptmast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _hod_mailid;
        private string _dept_code;
        private string _dept_name;
        private string _dept_shrt_name;
        private string _dept_desc;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string hod_mailid
        {
            set { _hod_mailid = value; }
            get { return _hod_mailid; }
        }
        public string dept_code
        {
            set { _dept_code = value; }
            get { return _dept_code; }
        }
        public string dept_name
        {
            set { _dept_name = value; }
            get { return _dept_name; }
        }
        public string dept_shrt_name
        {
            set { _dept_shrt_name = value; }
            get { return _dept_shrt_name; }
        }
        public string dept_desc
        {
            set { _dept_desc = value; }
            get { return _dept_desc; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void ins_deptmast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinsdeptmast]";

           
            param = new OleDbParameter("@dept_name", OleDbType.VarChar, 50);
            param.Value = dept_name;
            li_param.Add(param);

            param = new OleDbParameter("@dept_shrt_name", OleDbType.VarChar, 50);
            param.Value = dept_shrt_name;
            li_param.Add(param);

            param = new OleDbParameter("@dept_desc", OleDbType.VarChar, 1000);
            param.Value = dept_desc;
            li_param.Add(param);

            param = new OleDbParameter("@hod_mailid", OleDbType.VarChar, 100);
            param.Value = hod_mailid;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void updt_deptmast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtdeptmast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@dept_name", OleDbType.VarChar, 50);
            param.Value = dept_name;
            li_param.Add(param);

            param = new OleDbParameter("@dept_shrt_name", OleDbType.VarChar, 50);
            param.Value = dept_shrt_name;
            li_param.Add(param);

            param = new OleDbParameter("@dept_desc", OleDbType.VarChar, 1000);
            param.Value = dept_desc;
            li_param.Add(param);

            param = new OleDbParameter("@hod_mailid", OleDbType.VarChar, 100);
            param.Value = hod_mailid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_deptmast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdeldeptmast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public DataTable vw_deptmastall()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select dept_name+' ('+dept_code+')' dept_cname,tbldeptmast.* ";
            dal.sqlcmdstr += " from [master].[tbldeptmast]";
            dal.sqlcmdstr += " where tbldeptmast.del_sts=0 order by dept_name";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_deptmast_bytransid(string transid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select dept_name+' ('+dept_code+')' dept_cname,tbldeptmast.* ";
            dal.sqlcmdstr += " from [master].[tbldeptmast]";
            dal.sqlcmdstr += " where tbldeptmast.del_sts=0 and transid=? order by dept_name";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    public class blcoursemast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _deptid;
        private string _coursename;
        private string _approval_number;
        private decimal _sem_number;
        private string _crs_lvl;
        private decimal _coursedurationmonthmin;
        private decimal _coursedurationmonthmax;
        private decimal _fees_intl;
        private decimal _fees_dom;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string deptid
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        public string coursename
        {
            set { _coursename = value; }
            get { return _coursename; }
        }
        public string approval_number
        {
            set { _approval_number = value; }
            get { return _approval_number; }
        }
        public decimal sem_number
        {
            set { _sem_number = value; }
            get { return _sem_number; }
        }
        public string crs_lvl
        {
            set { _crs_lvl = value; }
            get { return _crs_lvl; }
        }
        public decimal coursedurationmonthmin
        {
            set { _coursedurationmonthmin = value; }
            get { return _coursedurationmonthmin; }
        }
        public decimal coursedurationmonthmax
        {
            set { _coursedurationmonthmax = value; }
            get { return _coursedurationmonthmax; }
        }
        public decimal fees_intl
        {
            set { _fees_intl = value; }
            get { return _fees_intl; }
        }
        public decimal fees_dom
        {
            set { _fees_dom = value; }
            get { return _fees_dom; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void ins_coursemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinscoursemast]";

            param = new OleDbParameter("@deptid", OleDbType.VarChar, 50);
            param.Value = deptid;
            li_param.Add(param);

            param = new OleDbParameter("@coursename", OleDbType.VarChar, 1000);
            param.Value = coursename;
            li_param.Add(param);

            param = new OleDbParameter("@approval_number", OleDbType.VarChar, 100);
            param.Value = approval_number;
            li_param.Add(param);

            param = new OleDbParameter("@sem_number", OleDbType.Decimal, 10);
            param.Value = sem_number;
            li_param.Add(param);

            param = new OleDbParameter("@crs_lvl", OleDbType.VarChar, 50);
            param.Value = crs_lvl;
            li_param.Add(param);

            param = new OleDbParameter("@coursedurationmonthmin", OleDbType.Decimal, 10);
            param.Value = coursedurationmonthmin;
            li_param.Add(param);

            param = new OleDbParameter("@coursedurationmonthmax", OleDbType.Decimal, 10);
            param.Value = coursedurationmonthmax;
            li_param.Add(param);

            param = new OleDbParameter("@fees_intl", OleDbType.Decimal, 10);
            param.Value = fees_intl;
            li_param.Add(param);

            param = new OleDbParameter("@fees_dom", OleDbType.Decimal, 10);
            param.Value = fees_dom;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();
           

        }
        public void updt_coursemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtcoursemast]";

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@deptid", OleDbType.VarChar, 50);
            param.Value = deptid;
            li_param.Add(param);

            param = new OleDbParameter("@coursename", OleDbType.VarChar, 1000);
            param.Value = coursename;
            li_param.Add(param);

            param = new OleDbParameter("@approval_number", OleDbType.VarChar, 100);
            param.Value = approval_number;
            li_param.Add(param);

            param = new OleDbParameter("@sem_number", OleDbType.Decimal, 10);
            param.Value = sem_number;
            li_param.Add(param);

            param = new OleDbParameter("@crs_lvl", OleDbType.VarChar, 50);
            param.Value = crs_lvl;
            li_param.Add(param);

            param = new OleDbParameter("@coursedurationmonthmin", OleDbType.Decimal, 10);
            param.Value = coursedurationmonthmin;
            li_param.Add(param);

            param = new OleDbParameter("@coursedurationmonthmax", OleDbType.Decimal, 10);
            param.Value = coursedurationmonthmax;
            li_param.Add(param);

            param = new OleDbParameter("@fees_intl", OleDbType.Decimal, 10);
            param.Value = fees_intl;
            li_param.Add(param);

            param = new OleDbParameter("@fees_dom", OleDbType.Decimal, 10);
            param.Value = fees_dom;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_coursemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdelcoursemast]";

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public DataTable vw_coursemastall()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select dept_name+' ('+dept_code+')' dept_cname,acalvl.level_name,course.* from master.tblcoursemast course";
            dal.sqlcmdstr += " inner join master.tbldeptmast dept on dept.transid = course.deptid";
            dal.sqlcmdstr += " inner join master.tblacademiclevelmast acalvl on acalvl.transid = course.crs_lvl";
            dal.sqlcmdstr += "  where course.del_sts = 0 and dept.del_sts = 0 and acalvl.del_sts=0 order by lvl_num,dept_name,coursename";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_coursemast_bytransid(string transid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select dept_name+' ('+dept_code+')' dept_cname,acalvl.level_name,course.* from master.tblcoursemast course";
            dal.sqlcmdstr += " inner join master.tbldeptmast dept on dept.transid = course.deptid";
            dal.sqlcmdstr += " inner join master.tblacademiclevelmast acalvl on acalvl.transid = course.crs_lvl";
            dal.sqlcmdstr += "  where course.del_sts = 0 and dept.del_sts = 0 and acalvl.del_sts=0 and course.transid=?";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_coursemastallluc(string crstype)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select tblcoursemast.* from tblcoursemast where crstype = ? and status = 1";

            param = new OleDbParameter("@crstype", OleDbType.VarChar, 50);
            param.Value = crstype;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbstd.ToString());
            return mdt;
        }

        public DataTable vw_coursemastbytransiduc(string courseid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from tblcoursemast where courseid=?";

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = courseid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbstd.ToString());
            return mdt;
        }
    }
    public class blacademiclevelmast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _level_name;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        private Int32 _lvl_num;
        

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string level_name
        {
            set { _level_name = value; }
            get { return _level_name; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public Int32 lvl_num
        {
            set { _lvl_num = value; }
            get { return _lvl_num; }
        }

        public void ins_academiclevelmast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinsacademiclevelmast]";

            param = new OleDbParameter("@level_name", OleDbType.VarChar, 50);
            param.Value = level_name;
            li_param.Add(param);

            param = new OleDbParameter("@lvl_num", OleDbType.Integer, 4);
            param.Value = lvl_num;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void updt_academiclevelmast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtacademiclevelmast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@level_name", OleDbType.VarChar, 50);
            param.Value = level_name;
            li_param.Add(param);

            param = new OleDbParameter("@lvl_num", OleDbType.Integer, 4);
            param.Value = lvl_num;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_academiclevelmast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdelacademiclevelmast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public DataTable vw_academiclevelmastall()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select * from [master].[tblacademiclevelmast] where del_sts=0 order by lvl_num";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_academiclevelmastall_spvr()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select * from [master].[tblacademiclevelmast] where del_sts=0 and spvraca=0 order by lvl_num";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_academiclevelmast_bytransid(string transid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from master.tblacademiclevelmast where tblacademiclevelmast.del_sts=0 and tblacademiclevelmast.transid=?";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    public class blgradeschememast
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _crsid;
        private string _crsversion;
        private decimal _frmpercent;
        private decimal _topercent;
        private decimal _gradepoint;
        private string _grade_symbol;
        private string _remarks;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string crsid
        {
            set { _crsid = value; }
            get { return _crsid; }
        }
        public string crsversion
        {
            set { _crsversion = value; }
            get { return _crsversion; }
        }
        public decimal frmpercent
        {
            set { _frmpercent = value; }
            get { return _frmpercent; }
        }
        public decimal topercent
        {
            set { _topercent = value; }
            get { return _topercent; }
        }
        public decimal gradepoint
        {
            set { _gradepoint = value; }
            get { return _gradepoint; }
        }
        public string grade_symbol
        {
            set { _grade_symbol = value; }
            get { return _grade_symbol; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public void ins_gradescheme()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spinsgradeschememast]";

            param = new SqlParameter("@type_tblgradescheme",SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
           

        }
        public void updt_gradescheme()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spupdtgradeschememast]";

            param = new SqlParameter("@type_tblgradescheme_all", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();


        }
        public void del_gradescheme()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spdelgradeschememast]";

            param = new SqlParameter("@type_tblgradescheme_crsid_crsversion_luo", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();


        }
        public DataTable vw_gradescheme_all()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();

            dal.sqlcmdstr = "select coursename,tblremarks.remarks,tblgradescheme.* from  master.tblgradescheme";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblgradescheme.crsid";
            dal.sqlcmdstr += " inner join master.tblremarks on tblremarks.transid = tblgradescheme.remarks";
            dal.sqlcmdstr += " where tblgradescheme.del_sts=0 and tblcoursemast.del_sts=0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_distinct_crsname_gradescheme_all()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();

            dal.sqlcmdstr = "select distinct coursename,tblcoursemast.transid from  master.tblgradescheme";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblgradescheme.crsid";
            dal.sqlcmdstr += " inner join master.tblremarks on tblremarks.transid = tblgradescheme.remarks";
            dal.sqlcmdstr += " where tblgradescheme.del_sts=0 and tblcoursemast.del_sts=0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_distinct_crsversion_gradescheme_bycrsid(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select distinct crsversion from  master.tblgradescheme";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblgradescheme.crsid";
            dal.sqlcmdstr += " inner join master.tblremarks on tblremarks.transid = tblgradescheme.remarks";
            dal.sqlcmdstr += " where crsid =@crsid and tblgradescheme.del_sts=0 and tblcoursemast.del_sts=0";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_gradescheme_bycrsid(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select coursename,tblremarks.remarks,tblgradescheme.* from  master.tblgradescheme";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblgradescheme.crsid";
            dal.sqlcmdstr += " inner join master.tblremarks on tblremarks.transid = tblgradescheme.remarks";
            dal.sqlcmdstr += " where crsid =@crsid and tblgradescheme.del_sts=0 and tblcoursemast.del_sts=0";
            dal.sqlcmdstr += " order by crsversion,frmpercent";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_gradescheme_bycrsid(string crsid,string crsversion)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select coursename,tblremarks.remarks,tblgradescheme.* from  master.tblgradescheme";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblgradescheme.crsid";
            dal.sqlcmdstr += " inner join master.tblremarks on tblremarks.transid = tblgradescheme.remarks";
            dal.sqlcmdstr += " where crsid =@crsid and crsversion=@crsversion and tblgradescheme.del_sts=0 and tblcoursemast.del_sts=0";
            dal.sqlcmdstr += " order by frmpercent";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new SqlParameter("@crsversion", SqlDbType.VarChar, 50);
            param.Value = crsversion;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    public class blcoursesemconfig
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _crsid;
        private string _semester;
        private decimal _duration_days;
        public Int32 _aca_year;
        private string _rco;
        private DateTime _rcm;
        private Char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string crsid
        {
            set { _crsid = value; }
            get { return _crsid; }
        }
        public string semester
        {
            set { _semester = value; }
            get { return _semester; }
        }
        public decimal duration_days
        {
            set { _duration_days = value; }
            get { return _duration_days; }
        }
        public Int32 aca_year
        {
            set { _aca_year = value; }
            get { return _aca_year; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public Char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void ins_coursesemconfig()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spinscoursesemconfig]";

            param = new SqlParameter("@type_tblcoursesemconfig", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();


        }
        public void updt_coursesemconfig()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spupdtcoursesemconfig]";

            param = new SqlParameter("@type_tblcoursesemconfig_all", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable vw_crssemconfig_distinct_crsname()
        {
            dal = new DataAccess_sql();
            
            dal.sqlcmdstr = "select distinct coursename,crsid from master.tblcoursesemconfig";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblcoursesemconfig.crsid";
            dal.sqlcmdstr += " where tblcoursemast.del_sts = 0 and tblcoursesemconfig.del_sts = 0";
           
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;
            return mdt;
        }
        public DataTable vw_crssemconfig_bycrsid(string crsid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select coursename,tblcoursesemconfig.* from master.tblcoursesemconfig";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblcoursesemconfig.crsid";
            dal.sqlcmdstr += " where tblcoursemast.del_sts = 0 and tblcoursesemconfig.del_sts = 0 and crsid=@crsid order by len(semester),semester";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;
            return mdt;
        }
    }
    public class blcrsintkmnthconfig
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _crsid;
        private string _crsversion;
        private string _monthid;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string crsid
        {
            set { _crsid = value; }
            get { return _crsid; }
        }
        public string crsversion
        {
            set { _crsversion = value; }
            get { return _crsversion; }
        }
        public string monthid
        {
            set { _monthid = value; }
            get { return _monthid; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public void ins_crsintkmnthconfig()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spinscrsintkmnthconfig]";

            param = new SqlParameter("@type_tblcrsintkmnthconfig", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();


        }

        public void del_crsintkmnthconfig()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spdelcrsintkmnthconfig]";

            param = new SqlParameter("@type_tblcrsintkmnthconfig_crsid_crsversion_luo", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            
        }
        public DataTable vw_distinct_crsname_crsintkmnthconfig_all()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();

            dal.sqlcmdstr = "select distinct coursename,tblcoursemast.transid from  master.tblcrsintkmnthconfig";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblcrsintkmnthconfig.crsid";
            dal.sqlcmdstr += " where tblcrsintkmnthconfig.del_sts = 0 and tblcoursemast.del_sts = 0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_distinct_crsversionname_crsintkmnthconfig_bycrsid(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select distinct crsversionid from  master.tblcrsintkmnthconfig";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblcrsintkmnthconfig.crsid";
            dal.sqlcmdstr += " where tblcrsintkmnthconfig.del_sts = 0 and tblcoursemast.del_sts = 0 and crsid =@crsid";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_distinct_mnthname_crsintkmnthconfig_bycrsid_crsversion(string crsid,string crsversion)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select monthname,monthid from  master.tblcrsintkmnthconfig";
            dal.sqlcmdstr += " inner join master.tblcoursemast on tblcoursemast.transid = tblcrsintkmnthconfig.crsid";
            dal.sqlcmdstr += " inner join general.tblmonth on tblmonth.transid=monthid";
            dal.sqlcmdstr += " where tblcrsintkmnthconfig.del_sts = 0 and tblcoursemast.del_sts = 0 ";
            dal.sqlcmdstr += " and crsid =@crsid and crsversionid=@crsvresion order by [tblmonth].[order]";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new SqlParameter("@crsvresion", SqlDbType.VarChar, 50);
            param.Value = crsversion;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    public class blassessment
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _courseid;
        private string _assement_name;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string courseid
        {
            set { _courseid = value; }
            get { return _courseid; }
        }
        public string assement_name
        {
            set { _assement_name = value; }
            get { return _assement_name; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void ins_assessment()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinsassessmentmast]";

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = courseid;
            li_param.Add(param);

            param = new OleDbParameter("@assement_name", OleDbType.VarChar, 1000);
            param.Value = assement_name;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            

        }
        public void updt_assessment()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtassessmentmast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@assement_name", OleDbType.VarChar, 1000);
            param.Value = assement_name;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_assessment()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdelassessmentmast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public DataTable vw_assessment()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select tblassessmentmast.* from [master].[tblassessmentmast] ";
            dal.sqlcmdstr += " inner join [master].[tblcoursemast] on tblcoursemast.transid = tblassessmentmast.courseid ";
            dal.sqlcmdstr += " where tblassessmentmast.del_sts=0 and tblcoursemast.del_sts=0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_assessment_distinct_crsname()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select distinct coursename,courseid from [master].[tblassessmentmast] ";
            dal.sqlcmdstr += " inner join [master].[tblcoursemast] on tblcoursemast.transid = tblassessmentmast.courseid ";
            dal.sqlcmdstr += " where tblassessmentmast.del_sts=0 and tblcoursemast.del_sts=0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_assessment_bycourseid(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select tblassessmentmast.* from [master].[tblassessmentmast] ";
            dal.sqlcmdstr += " inner join [master].[tblcoursemast] on tblcoursemast.transid = tblassessmentmast.courseid ";
            dal.sqlcmdstr += " where tblassessmentmast.del_sts=0 and tblcoursemast.del_sts=0 and courseid=?";

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

    }
    public class blsubjectlist
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _courseid;
        private string _courseversion;
        private string _semester;
        private string _subjectname;
        private string _subjectcode;
        private string _type;
        private decimal _credit;
        private decimal _weeknum;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string courseid
        {
            set { _courseid = value; }
            get { return _courseid; }
        }
        public string courseversion
        {
            set { _courseversion = value; }
            get { return _courseversion; }
        }
        public string semester
        {
            set { _semester = value; }
            get { return _semester; }
        }
        public string subjectname
        {
            set { _subjectname = value; }
            get { return _subjectname; }
        }
        public string subjectcode
        {
            set { _subjectcode = value; }
            get { return _subjectcode; }
        }
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        public decimal credit
        {
            set { _credit = value; }
            get { return _credit; }
        }
        public decimal weeknum
        {
            set { _weeknum = value; }
            get { return _weeknum; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public void ins_subjectlist()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinssubjectlist]";

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = courseid;
            li_param.Add(param);

            param = new OleDbParameter("@courseversion", OleDbType.VarChar, 50);
            param.Value = courseversion;
            li_param.Add(param);

            param = new OleDbParameter("@semester", OleDbType.VarChar, 50);
            param.Value = semester;
            li_param.Add(param);

            param = new OleDbParameter("@subjectname", OleDbType.VarChar, 1000);
            param.Value = subjectname;
            li_param.Add(param);

            param = new OleDbParameter("@subjectcode", OleDbType.VarChar, 10);
            param.Value = subjectcode;
            li_param.Add(param);

            param = new OleDbParameter("@type", OleDbType.VarChar, 10);
            param.Value = type;
            li_param.Add(param);

            param = new OleDbParameter("@credit", OleDbType.Decimal, 5);
            param.Value = credit;
            li_param.Add(param);

            param = new OleDbParameter("@weekname", OleDbType.Decimal, 5);
            param.Value = weeknum;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            

        }
        public void updt_subjectlist()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtsubjectlist]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@courseid", OleDbType.VarChar, 50);
            param.Value = courseid;
            li_param.Add(param);

            param = new OleDbParameter("@courseversion", OleDbType.VarChar, 50);
            param.Value = courseversion;
            li_param.Add(param);

            param = new OleDbParameter("@semester", OleDbType.VarChar, 50);
            param.Value = semester;
            li_param.Add(param);

            param = new OleDbParameter("@subjectname", OleDbType.VarChar, 1000);
            param.Value = subjectname;
            li_param.Add(param);

            param = new OleDbParameter("@subjectcode", OleDbType.VarChar, 10);
            param.Value = subjectcode;
            li_param.Add(param);

            param = new OleDbParameter("@type", OleDbType.VarChar, 100);
            param.Value = type;
            li_param.Add(param);

            param = new OleDbParameter("@credit", OleDbType.Decimal, 5);
            param.Value = credit;
            li_param.Add(param);

            param = new OleDbParameter("@weekname", OleDbType.Decimal, 5);
            param.Value = weeknum;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_subjectlist()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdelsubjectlist]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public DataTable vw_subjectlistall()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select tblsubjectlist.*,config.semester,coursename,";
            dal.sqlcmdstr += " subjectname+' ['+subjectcode+']['+config.semester+']['+coursename+']' subjectwcodesemcrs from [master].[tblsubjectlist]";
            dal.sqlcmdstr += " inner join[master].[tblcoursemast]";
            dal.sqlcmdstr += " on tblcoursemast.transid = tblsubjectlist.courseid";
            dal.sqlcmdstr += " inner join[master].[tblcoursesemconfig] config on config.transid= tblsubjectlist.semester";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblcoursemast.del_sts= 0 and config.del_sts= 0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_subjectlist_bysubid(string subjectid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from [master].[tblsubjectlist]";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblsubjectlist.transid=?";

            param = new OleDbParameter("@subjectid", OleDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_distinct_crsname()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select distinct coursename,tblcoursemast.transid from[master].[tblsubjectlist]";
            dal.sqlcmdstr += " inner join[master].[tblcoursemast]";
            dal.sqlcmdstr += " on tblcoursemast.transid = tblsubjectlist.courseid";
            dal.sqlcmdstr += " inner join[master].[tblcoursesemconfig] config on config.transid= tblsubjectlist.semester";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblcoursemast.del_sts= 0 and config.del_sts= 0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_subjectlist_bycrsid(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select tblsubjectlist.*,config.semester,coursename from[master].[tblsubjectlist]";
            dal.sqlcmdstr += " inner join[master].[tblcoursemast]";
            dal.sqlcmdstr += " on tblcoursemast.transid = tblsubjectlist.courseid";
            dal.sqlcmdstr += " inner join[master].[tblcoursesemconfig] config on config.transid= tblsubjectlist.semester";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblcoursemast.del_sts= 0 and config.del_sts= 0 and tblcoursemast.transid=?";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_syllabusversion_bycrsid(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select distinct courseversion from[master].[tblsubjectlist]";
            dal.sqlcmdstr += " inner join[master].[tblcoursemast]";
            dal.sqlcmdstr += " on tblcoursemast.transid = tblsubjectlist.courseid";
            dal.sqlcmdstr += " inner join[master].[tblcoursesemconfig] config on config.transid= tblsubjectlist.semester";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblcoursemast.del_sts= 0 and config.del_sts= 0 and tblcoursemast.transid=?";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_subjectlist_bycrsid_syllabusversion(string crsid,string crsversion)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select tblsubjectlist.*,config.semester as sem,coursename from[master].[tblsubjectlist]";
            dal.sqlcmdstr += " inner join[master].[tblcoursemast]";
            dal.sqlcmdstr += " on tblcoursemast.transid = tblsubjectlist.courseid";
            dal.sqlcmdstr += " inner join[master].[tblcoursesemconfig] config on config.transid= tblsubjectlist.semester";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblcoursemast.del_sts= 0 and ";
            dal.sqlcmdstr += " config.del_sts= 0 and tblcoursemast.transid=? and tblsubjectlist.courseversion=? order by config.semester,subjectname";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new OleDbParameter("@courseversion", OleDbType.VarChar, 50);
            param.Value = crsversion;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_subjectlist_bycrsid_syllabusversion_sem(string crsid, string crsversion,String sem)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select tblsubjectlist.*,config.semester as sem,coursename from[master].[tblsubjectlist]";
            dal.sqlcmdstr += " inner join[master].[tblcoursemast]";
            dal.sqlcmdstr += " on tblcoursemast.transid = tblsubjectlist.courseid";
            dal.sqlcmdstr += " inner join[master].[tblcoursesemconfig] config on config.transid= tblsubjectlist.semester";
            dal.sqlcmdstr += " where tblsubjectlist.del_sts= 0 and tblcoursemast.del_sts= 0 and ";
            dal.sqlcmdstr += " config.del_sts= 0 and tblcoursemast.transid=? and tblsubjectlist.courseversion=? and config.transid=?";
            dal.sqlcmdstr += " order by config.semester,subjectname";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new OleDbParameter("@courseversion", OleDbType.VarChar, 50);
            param.Value = crsversion;
            li_param.Add(param);

            param = new OleDbParameter("@sem", OleDbType.VarChar, 50);
            param.Value = sem;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

    }
    public class bllearningtypemast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;

        private string _transid;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public DataTable vw_learningtypemast_all()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select * from [master].[tbllearningtypemast] order by learningtype";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

    }
    public class bldoctypemast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _doctype;
        private string _docdesc;
        private Char _req_hcsubmission;
        private Char _mandatory;
        private string _doc_grup;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        private string _security_lvl;
        private Int32 _slno;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string doctype
        {
            set { _doctype = value; }
            get { return _doctype; }
        }
        public string docdesc
        {
            set { _docdesc = value; }
            get { return _docdesc; }
        }
        public Char req_hcsubmission
        {
            set { _req_hcsubmission = value; }
            get { return _req_hcsubmission; }
        }
        public Char mandatory
        {
            set { _mandatory = value; }
            get { return _mandatory; }
        }
        public string doc_grup
        {
            set { _doc_grup = value; }
            get { return _doc_grup; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public string security_lvl
        {
            set { _security_lvl = value; }
            get { return _security_lvl; }
        }
        public Int32 slno
        {
            set { _slno = value; }
            get { return _slno; }
        }
        public void ins_doctypemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinsdoctypemast]";

            param = new OleDbParameter("@doctype", OleDbType.VarChar, -1);
            param.Value = doctype;
            li_param.Add(param);

            param = new OleDbParameter("@docdesc", OleDbType.VarChar, -1);
            param.Value = docdesc;
            li_param.Add(param);

            param = new OleDbParameter("@req_hcsubmission", OleDbType.Char, 1);
            param.Value = req_hcsubmission;
            li_param.Add(param);

            param = new OleDbParameter("@mandatory", OleDbType.Char, 1);
            param.Value = mandatory;
            li_param.Add(param);

            param = new OleDbParameter("@doc_grup", OleDbType.VarChar, 100);
            param.Value = doc_grup;
            li_param.Add(param);

            param = new OleDbParameter("@security_lvl", OleDbType.VarChar, 10);
            param.Value = security_lvl;
            li_param.Add(param);

            param = new OleDbParameter("@slno", OleDbType.Integer, 2);
            param.Value = slno;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void updt_doctypemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtdoctypemast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@doctype", OleDbType.VarChar, -1);
            param.Value = doctype;
            li_param.Add(param);

            param = new OleDbParameter("@docdesc", OleDbType.VarChar, -1);
            param.Value = docdesc;
            li_param.Add(param);

            param = new OleDbParameter("@req_hcsubmission", OleDbType.Char, 1);
            param.Value = req_hcsubmission;
            li_param.Add(param);

            param = new OleDbParameter("@mandatory", OleDbType.Char, 1);
            param.Value = mandatory;
            li_param.Add(param);

            param = new OleDbParameter("@doc_grup", OleDbType.VarChar, 100);
            param.Value = doc_grup;
            li_param.Add(param);

            param = new OleDbParameter("@security_lvl", OleDbType.VarChar, 10);
            param.Value = security_lvl;
            li_param.Add(param);

            param = new OleDbParameter("@slno", OleDbType.Integer, 2);
            param.Value = slno;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_breaktypemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdeldoctypemast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public DataTable vw_doctypemast()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from master.tbldoctypemast where tbldoctypemast.del_sts=0 and security_lvl=0 order by slno";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_doctypemast(string doc_grup, List<string> security_lvl)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from master.tbldoctypemast where del_sts=0 and doc_grup=? and security_lvl in (0,";
            foreach (string security in security_lvl)
                dal.sqlcmdstr += security + ",";
            dal.sqlcmdstr = dal.sqlcmdstr.Substring(0, dal.sqlcmdstr.Length - 1);
            dal.sqlcmdstr += ") order by slno";

            param = new OleDbParameter("@doc_grup", OleDbType.VarChar, 100);
            param.Value = doc_grup;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_doctypemastbymarianclg(List<string> security_lvl)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from master.tbldoctypemast where del_sts=0 and doc_grup in ('adm','entrtest') and security_lvl in (0,";
            foreach (string security in security_lvl)
                dal.sqlcmdstr += security + ",";
            dal.sqlcmdstr = dal.sqlcmdstr.Substring(0, dal.sqlcmdstr.Length - 1);
            dal.sqlcmdstr += ") order by slno";

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_doctypemast(List<string> ids)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from master.tbldoctypemast where del_sts=0 and transid in (";
            foreach (string id in ids)
                dal.sqlcmdstr += id+",";
            dal.sqlcmdstr = dal.sqlcmdstr.Substring(0, dal.sqlcmdstr.Length - 1);
            dal.sqlcmdstr += ") order by slno";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        //new method added
        public DataTable vw_sgdmast()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "SELECT transid,id, CONCAT(id,'.',goal, '( ',description,')') AS sgd FROM [master].[tblsgd]";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        private string _applicationid;        public string applicationid        {            set { _applicationid = value; }            get { return _applicationid; }        }        public DataTable vw_reuploadoc(string applicationid)        {            mdt = new DataTable();            dal = new DataAccess();            li_param = new List<OleDbParameter>();            dal.sqlcmdstr = "select * from master.tbldoctypemast where del_sts = 0 and doc_grup = 'aca' and security_lvl in (0) and";            dal.sqlcmdstr += " transid not in(select appl_docid from appl.tblappldocumentsupload inner join";            dal.sqlcmdstr += " appl.vw_appl on tblappldocumentsupload.frmmodtransid = vw_appl.transid where applicationid =?";            dal.sqlcmdstr += " and appl_stage = '57470DF6-0F58-4F6C-B902-8721B3D342A4')";            param = new OleDbParameter("@applicationid", OleDbType.VarChar, 100);            param.Value = applicationid;            li_param.Add(param);            dal.lparam = li_param;            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());            return mdt;        }        public DataTable vw_edudtlsreupload(string applicationid)        {            mdt = new DataTable();            dal = new DataAccess();            li_param = new List<OleDbParameter>();            dal.sqlcmdstr = "Select * from master.tblacademiclevelmast where transid not in(";            dal.sqlcmdstr += " Select aca.transid  from appl.vw_appl appl inner join";            dal.sqlcmdstr += " appl.tblappleducationdtls edudtls on appl.transid=edudtls.frmmodtransid";            dal.sqlcmdstr += " inner join master.tblacademiclevelmast aca on edudtls.studylvl=aca.transid";            dal.sqlcmdstr += " where appl.appl_stage='57470DF6-0F58-4F6C-B902-8721B3D342A4' and applicationid=?)";            param = new OleDbParameter("@applicationid", OleDbType.VarChar, 100);            param.Value = applicationid;            li_param.Add(param);            dal.lparam = li_param;            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());            return mdt;        }
    }
    //Academic Module End

    //Finance Module Start
    public class blfeestypemast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _feestype_name;
        private string _feestype_desc;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string feestype_name
        {
            set { _feestype_name = value; }
            get { return _feestype_name; }
        }
        public string feestype_desc
        {
            set { _feestype_desc = value; }
            get { return _feestype_desc; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public DateTime rcm
        {
            set { _rcm = value; }
            get { return _rcm; }
        }
        public char del_sts
        {
            set { _del_sts = value; }
            get { return _del_sts; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public DateTime lum
        {
            set { _lum = value; }
            get { return _lum; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public void ins_feestypemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spinsfeestypemast]";


            param = new OleDbParameter("@feestype_name", OleDbType.VarChar, 500);
            param.Value = feestype_name;
            li_param.Add(param);

            param = new OleDbParameter("@feestype_desc", OleDbType.VarChar, -1);
            param.Value = feestype_desc;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }
        public void updt_feestypemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spupdtfeestypemast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@feestype_name", OleDbType.VarChar, 500);
            param.Value = feestype_name;
            li_param.Add(param);

            param = new OleDbParameter("@feestype_desc", OleDbType.VarChar, -1);
            param.Value = feestype_desc;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }

        }
        public void del_feestypemast()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[master].[spdelfeestypemast]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }
        public DataTable vw_feestypemastall()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            dal.sqlcmdstr = "select * from master.tblfeestypemast where del_sts=0 order by slno";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_feestypemast_bytransid(string transid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from master.tblfeestypemast where del_sts=0 and transid=?";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    //Finance Module End
}

