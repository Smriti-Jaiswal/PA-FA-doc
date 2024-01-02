using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using NSDataAccess;


namespace NSAcademic
{
    public class blsubassdet
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _crsid;
        private string _crsversion;
        private string _assessment;
        private decimal _marks;
        private string _subjectid;
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
        public string assessment
        {
            set { _assessment = value; }
            get { return _assessment; }
        }
        public decimal marks
        {
            set { _marks = value; }
            get { return _marks; }
        }
        public string subjectid
        {
            set { _subjectid = value; }
            get { return _subjectid; }
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
        public void ins_subassdet()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academic].[spinssubassdet]";

            param = new SqlParameter("@type_tblsubassdet", SqlDbType.Structured, -1);
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
        public void updt_subassdet()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[master].[spupdtsubassdet]";

            param = new SqlParameter("@@type_tblsubassdet", SqlDbType.Structured, -1);
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
        public void del_subassdet()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academic].[spdelsubassdet]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();


        }
        public DataTable vw_assessment_bysubject(string subjectid, string crsversion)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select assement_name,tblsubassdet.* from academic.tblsubassdet";
            dal.sqlcmdstr += " inner join master.tblassessmentmast on tblassessmentmast.transid = tblsubassdet.assessment";
            dal.sqlcmdstr += " where subjectid =@subjectid and crsversion=@crsversion and tblsubassdet.del_sts=0 and tblassessmentmast.del_sts=0 order by marks";

            param = new SqlParameter("@subjectid", SqlDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            param = new SqlParameter("@crsversion", SqlDbType.VarChar, 50);
            param.Value = crsversion;
            li_param.Add(param);

            dal.lparam = li_param;

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
        public DataTable vw_gradescheme_bycrsid(string crsid, string crsversion)
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
    public class blsubtopic
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _subject;
        private decimal _weeknum;
        private string _topic_name;
        private string _topic_desc;
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
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        public decimal weeknum
        {
            set { _weeknum = value; }
            get { return _weeknum; }
        }
        public string topic_name
        {
            set { _topic_name = value; }
            get { return _topic_name; }
        }
        public string topic_desc
        {
            set { _topic_desc = value; }
            get { return _topic_desc; }
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
        public void ins_subtopic()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[academic].[spinssubtopic]";

            param = new OleDbParameter("@subject", OleDbType.VarChar, 1000);
            param.Value = subject;
            li_param.Add(param);

            param = new OleDbParameter("@weeknum", OleDbType.Decimal, 5);
            param.Value = weeknum;
            li_param.Add(param);

            param = new OleDbParameter("@topic_name", OleDbType.VarChar, 50);
            param.Value = topic_name;
            li_param.Add(param);

            param = new OleDbParameter("@topic_desc", OleDbType.VarChar, 50);
            param.Value = topic_desc;
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
        public void updt_subtopic()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[academic].[spupdtsubtopic]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@subject", OleDbType.VarChar, 1000);
            param.Value = subject;
            li_param.Add(param);

            param = new OleDbParameter("@weeknum", OleDbType.Decimal, 5);
            param.Value = weeknum;
            li_param.Add(param);

            param = new OleDbParameter("@topic_name", OleDbType.VarChar, 50);
            param.Value = topic_name;
            li_param.Add(param);

            param = new OleDbParameter("@topic_desc", OleDbType.VarChar, 50);
            param.Value = topic_desc;
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
        public void del_subtopic()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[academic].[spdelsubtopic]";

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


        public DataTable vw_subtopic_by_subjectid(string subjectid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from [academic].[tblsubtopic] where subject=? and del_sts=0 order by weeknum ";

            param = new OleDbParameter("@subjectid", OleDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_subtopic_by_subjectid_rept(string subjectid)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select * from (select * from[academic].[tblsubtopic]";
            dal.sqlcmdstr += " where subject = ? and del_sts = 0";
            dal.sqlcmdstr += " union all";
            dal.sqlcmdstr += " select newid(),?,1,'','','',getdate(),0,null,null) tbl order by weeknum,topic_name";

            param = new OleDbParameter("@subjectid", OleDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            param = new OleDbParameter("@subjectid", OleDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    public class bllectdtls
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private DateTime _lecture_dt;
        private TimeSpan _lecture_frmtime;
        private TimeSpan _lecture_totime;
        private string _topic;
        private string _topic_desc;
        private string _material_type;
        private string _fileupload;
        private DataTable _type_tbltopicobjective;
        private DataTable _type_tbllecttopic;
        private DataTable _type_tbllectmaterials;
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
        public DateTime lecture_dt
        {
            set { _lecture_dt = value; }
            get { return _lecture_dt; }
        }
        public TimeSpan lecture_frmtime
        {
            set { _lecture_frmtime = value; }
            get { return _lecture_frmtime; }
        }
        public TimeSpan lecture_totime
        {
            set { _lecture_totime = value; }
            get { return _lecture_totime; }
        }
        public string topic
        {
            set { _topic = value; }
            get { return _topic; }
        }
        public string topic_desc
        {
            set { _topic_desc = value; }
            get { return _topic_desc; }
        }
        public string material_type
        {
            set { _material_type = value; }
            get { return _material_type; }
        }
        public string fileupload
        {
            set { _fileupload = value; }
            get { return _fileupload; }
        }
        public DataTable type_tbltopicobjective
        {
            set { _type_tbltopicobjective = value; }
            get { return _type_tbltopicobjective; }
        }
        public DataTable type_tbllecttopic
        {
            set { _type_tbllecttopic = value; }
            get { return _type_tbllecttopic; }
        }
        public DataTable type_tbllectmaterials
        {
            set { _type_tbllectmaterials = value; }
            get { return _type_tbllectmaterials; }
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
        public void ins_lectdtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academic].[spinslectdtls]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@lecture_dt", SqlDbType.Date,10);
            param.Value = lecture_dt;
            li_param.Add(param);

            param = new SqlParameter("@lecture_frmtime", SqlDbType.Time, 5);
            param.Value = lecture_frmtime;
            li_param.Add(param);

            param = new SqlParameter("@lecture_totime", SqlDbType.Time, 5);
            param.Value = lecture_totime;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@type_tbltopicobjective", SqlDbType.Structured, -1);
            param.Value = type_tbltopicobjective;
            li_param.Add(param);

            param = new SqlParameter("@type_tbllecttopic", SqlDbType.Structured, -1);
            param.Value = type_tbllecttopic;
            li_param.Add(param);

            param = new SqlParameter("@type_tbllectmaterials", SqlDbType.Structured, -1);
            param.Value = type_tbllectmaterials;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }
    }
}
