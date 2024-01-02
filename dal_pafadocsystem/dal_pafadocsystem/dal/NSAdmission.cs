using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using NSDataAccess;

namespace NSAdmission
{
    public class blintake
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _crsid;
        private string _crsversion;
        private string _month;
        private string _intake_name;
        private DateTime _reg_start_dt;
        private DateTime _reg_end_dt;
        private DateTime _intk_start_dt;
        private DateTime _intk_end_dt;
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
        public string month
        {
            set { _month = value; }
            get { return _month; }
        }
        public string intake_name
        {
            set { _intake_name = value; }
            get { return _intake_name; }
        }
        public DateTime reg_start_dt
        {
            set { _reg_start_dt = value; }
            get { return _reg_start_dt; }
        }
        public DateTime reg_end_dt
        {
            set { _reg_end_dt = value; }
            get { return _reg_end_dt; }
        }
        public DateTime intk_start_dt
        {
            set { _intk_start_dt = value; }
            get { return _intk_start_dt; }
        }
        public DateTime intk_end_dt
        {
            set { _intk_end_dt = value; }
            get { return _intk_end_dt; }
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
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public void ins_intake()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[admission].[spinsintake]";


            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new SqlParameter("@crsversion", SqlDbType.VarChar, 50);
            param.Value = crsversion;
            li_param.Add(param);

            param = new SqlParameter("@month", SqlDbType.VarChar, 1000);
            param.Value = month;
            li_param.Add(param);

            param = new SqlParameter("@reg_start_dt", SqlDbType.Date, 10);
            param.Value = reg_start_dt;
            li_param.Add(param);

            param = new SqlParameter("@reg_end_dt", SqlDbType.Date, 10);
            param.Value = reg_end_dt;
            li_param.Add(param);

            param = new SqlParameter("@intk_start_dt", SqlDbType.Date, 10);
            param.Value = intk_start_dt;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
                transid = dal.oparam[1].Value.ToString();
            }

        }
        public void ins_intksemconfig()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[admission].[spintksemconfig]";


            param = new SqlParameter("@type_tblintksemconfig", SqlDbType.Structured, -1);
            param.Value = mdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
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
        public DataTable vw_sem_config(string crsid,DateTime intk_start_dt)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select config.semester, dateadd(DAY,(select coalesce(sum(tbl.duration_days) + 1, 0) from master.tblcoursesemconfig tbl";
            dal.sqlcmdstr += " where tbl.crsid = @crsid and tbl.slno < config.slno),@intk_start_dt) start_dt,";
            dal.sqlcmdstr += " dateadd(DAY, (select sum(tbl.duration_days) from master.tblcoursesemconfig tbl where tbl.crsid = @crsid and tbl.slno <= config.slno),@intk_start_dt) end_dt";
            dal.sqlcmdstr += " from master.tblcoursesemconfig config where config.crsid = @crsid order by len(config.semester),config.semester";

            param = new SqlParameter("@crsid", SqlDbType.VarChar, 50);
            param.Value = crsid;
            li_param.Add(param);

            param = new SqlParameter("@intk_start_dt", SqlDbType.Date, 10);
            param.Value = intk_start_dt;
            li_param.Add(param);

           

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

    }
}
