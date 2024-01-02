using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.OleDb;
using NSDataAccess;

namespace NSFinance
{
    public class blunitmast
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _unit_name;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string unit_name
        {
            set { _unit_name = value; }
            get { return _unit_name; }
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
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public DataTable vw_unitall()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from finance.tblunitmast order by unit_name";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }

    public class blcrsfeesconfig
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _crsid;
        private string _feesversion;
        private string _semester;
        private string _fees_name;
        private decimal _amount;
        private string _currency;
        private Int32 _slno;
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
        public string feesversion
        {
            set { _feesversion = value; }
            get { return _feesversion; }
        }
        public string semester
        {
            set { _semester = value; }
            get { return _semester; }
        }
        public string fees_name
        {
            set { _fees_name = value; }
            get { return _fees_name; }
        }
        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        public Int32 slno
        {
            set { _slno = value; }
            get { return _slno; }
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

        public void inscrsfeesconfig()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[finance].[spinscrsfeesconfig]";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new OleDbParameter("@feesversion", OleDbType.VarChar, 50);
            param.Value = feesversion;
            li_param.Add(param);

            param = new OleDbParameter("@semester", OleDbType.VarChar, 50);
            param.Value = semester;
            li_param.Add(param);

            param = new OleDbParameter("@fees_name", OleDbType.VarChar, 50);
            param.Value = fees_name;
            li_param.Add(param);

            param = new OleDbParameter("@amount", OleDbType.Decimal, 10);
            param.Value = amount;
            li_param.Add(param);

            param = new OleDbParameter("@currency", OleDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new OleDbParameter("@slno", OleDbType.Integer, 5);
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
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }
        public void updtcrsfeesconfig()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[finance].[spupdtcrsfeesconfig]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new OleDbParameter("@feesversion", OleDbType.VarChar, 50);
            param.Value = feesversion;
            li_param.Add(param);

            param = new OleDbParameter("@semester", OleDbType.VarChar, 50);
            param.Value = semester;
            li_param.Add(param);

            param = new OleDbParameter("@fees_name", OleDbType.VarChar, 50);
            param.Value = fees_name;
            li_param.Add(param);

            param = new OleDbParameter("@amount", OleDbType.Decimal, 10);
            param.Value = amount;
            li_param.Add(param);

            param = new OleDbParameter("@currency", OleDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new OleDbParameter("@slno", OleDbType.Integer, 5);
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
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }
        public void delcrsfeesconfig()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[finance].[spdelcrsfeesconfig]";

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
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }
        public DataTable vw_crsfeesconfig_all()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select coalesce(tblcoursesemconfig.semester,'Not Applicable') sem, tblfeestypemast.feestype_name fees, config.* from finance.tblcrsfeesconfig config";
            dal.sqlcmdstr += " inner join master.tblcoursemast on config.crsid = tblcoursemast.transid and tblcoursemast.del_sts = 0";
            dal.sqlcmdstr += " left outer join master.tblcoursesemconfig on config.semester = tblcoursesemconfig.transid and tblcoursesemconfig.del_sts = 0";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on config.fees_name = tblfeestypemast.transid and tblfeestypemast.del_sts = 0";
            dal.sqlcmdstr += " where config.del_sts = 0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = mdt.Rows.Count;
            return mdt;
        }
        public DataTable vw_distinct_crsname_crsfeesconfig()
        {
            mdt = new DataTable();
            dal = new DataAccess();

            dal.sqlcmdstr = "select distinct config.crsid,coursename from finance.tblcrsfeesconfig config";
            dal.sqlcmdstr += " inner join master.tblcoursemast on config.crsid = tblcoursemast.transid and tblcoursemast.del_sts = 0";
            dal.sqlcmdstr += " left outer join master.tblcoursesemconfig on config.semester = tblcoursesemconfig.transid and tblcoursesemconfig.del_sts = 0";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on config.fees_name = tblfeestypemast.transid and tblfeestypemast.del_sts = 0";
            dal.sqlcmdstr += " where config.del_sts = 0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = mdt.Rows.Count;
            return mdt;
        }
        public DataTable vw_distinct_feesversion_crsfeesconfig(string crsid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select distinct config.feesversion from finance.tblcrsfeesconfig config";
            dal.sqlcmdstr += " inner join master.tblcoursemast on config.crsid = tblcoursemast.transid and tblcoursemast.del_sts = 0";
            dal.sqlcmdstr += " left outer join master.tblcoursesemconfig on config.semester = tblcoursesemconfig.transid and tblcoursesemconfig.del_sts = 0";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on config.fees_name = tblfeestypemast.transid and tblfeestypemast.del_sts = 0";
            dal.sqlcmdstr += " where config.del_sts = 0 and config.crsid=?";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = mdt.Rows.Count;
            return mdt;
        }
        public DataTable vw_crsfeesconfig_bycrs_feesver(string crsid, string feesversion)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select coalesce(tblcoursesemconfig.semester,'Not Applicable') sem, tblfeestypemast.feestype_name fees, config.* from finance.tblcrsfeesconfig config";
            dal.sqlcmdstr += " inner join master.tblcoursemast on config.crsid = tblcoursemast.transid and tblcoursemast.del_sts = 0";
            dal.sqlcmdstr += " left outer join master.tblcoursesemconfig on config.semester = tblcoursesemconfig.transid and tblcoursesemconfig.del_sts = 0";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on config.fees_name = tblfeestypemast.transid and tblfeestypemast.del_sts = 0";
            dal.sqlcmdstr += " where config.del_sts = 0 and config.crsid=? and feesversion=? order by config.slno";

            param = new OleDbParameter("@crsid", OleDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new OleDbParameter("@feesversion", OleDbType.VarChar, 50);
            param.Value = feesversion;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = mdt.Rows.Count;
            return mdt;
        }
    }
}