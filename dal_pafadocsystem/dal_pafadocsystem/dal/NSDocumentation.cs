using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using NSDataAccess;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSDocumentation
{
   public class blprogram
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        public Guid _transid;
        public string _programname;
        public string _mqacode;
        public Int32 _duration;
        public Int32 _shortsem;
        public Int32 _longsem;
        public string _rco;
        public DateTime _rcm;
        public char _delsts;
        public string _luo;
        public DateTime _lcm;
        private string _msg;

        public string programname
        {
            set { _programname = value; }
            get { return _programname; }
        }
        public string mqacode
        {
            set { _mqacode = value; }
            get { return _mqacode; }
        }

        public int duration
        {
            set { _duration = value; }
            get { return _duration; }
        }
        public int shortsem
        {
            set { _shortsem = value; }
            get { return _shortsem; }
        }
        public int longsem
        {
            set { _longsem = value; }
            get { return _longsem; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void insert()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academics].[sp_insprogramdtls]";

            param = new SqlParameter("@programname", SqlDbType.VarChar, 50);
            param.Value = programname;
            li_param.Add(param);

            param = new SqlParameter("@mqacode", SqlDbType.VarChar, 50);
            param.Value = mqacode;
            li_param.Add(param);

            param = new SqlParameter("@duration", SqlDbType.Int, 1000);
            param.Value = duration;
            li_param.Add(param);

            param = new SqlParameter("@shortsem", SqlDbType.Int, 1000);
            param.Value = shortsem;
            li_param.Add(param);

            param = new SqlParameter("@longsem", SqlDbType.Int, 1000);
            param.Value = longsem;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.db_mqa.ToString());
            msg = dal.oparam[0].Value.ToString();

        }
 
    public DataTable grid_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select transid, programname, mqacode, duration, shortsem, longsem from [academics].[tblprogdtls] where delsts = '0' order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }

    }
    public class blupdateprogram
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        public Guid _transid;
        public string _programname;
        public string _mqacode;
        public Int32 _duration;
        public Int32 _shortsem;
        public Int32 _longsem;
        public string _rco;
        public DateTime _rcm;
        public char _delsts;
        public string _luo;
        public DateTime _lcm;
        private string _msg;

        public Guid transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string programname
        {
            set { _programname = value; }
            get { return _programname; }
        }
        public string mqacode
        {
            set { _mqacode = value; }
            get { return _mqacode; }
        }

        public int duration
        {
            set { _duration = value; }
            get { return _duration; }
        }
        public int shortsem
        {
            set { _shortsem = value; }
            get { return _shortsem; }
        }
        public int longsem
        {
            set { _longsem = value; }
            get { return _longsem; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void update()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academics].[sp_updtprogramdtls]";

            param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 1000);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@programname", SqlDbType.VarChar, 50);
            param.Value = programname;
            li_param.Add(param);

            param = new SqlParameter("@mqacode", SqlDbType.VarChar, 50);
            param.Value = mqacode;
            li_param.Add(param);

            param = new SqlParameter("@duration", SqlDbType.Int, 1000);
            param.Value = duration;
            li_param.Add(param);

            param = new SqlParameter("@shortsem", SqlDbType.Int, 1000);
            param.Value = shortsem;
            li_param.Add(param);

            param = new SqlParameter("@longsem", SqlDbType.Int, 1000);
            param.Value = longsem;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.db_mqa.ToString());
            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable grid_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select transid, programname, mqacode, duration, shortsem, longsem from [academics].[tblprogdtls] where delsts = '0' order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }
       

    }

    public class bldeleteprogram
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        public Guid _transid;
        public string _programname;
        public string _mqacode;
        public Int32 _duration;
        public Int32 _shortsem;
        public Int32 _longsem;
        public string _rco;
        public DateTime _rcm;
        public char _delsts;
        public string _luo;
        public DateTime _lcm;
        private string _msg;

        public Guid transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void delete()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academics].[sp_deleteprogramdtls]";

            param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 1000);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.db_mqa.ToString());
            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable grid_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select transid, programname, mqacode, duration, shortsem, longsem from [academics].[tblprogdtls] where delsts = '0' order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }

    }

    public class blmqapadocs
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        public Guid _transid;
        public Guid _programid;
        public Guid _docid;
        public string _conditions;
        public string _remarks;
        public string _aqdinitial;
        public string _rco;
        public DateTime _rcm;
        public char _del_sts;
        public string _luo;
        public DateTime _lum;
        private string _msg;
        static DataTable dt;
        static DataRow dr;
        static Int32 _ctr;

        public Guid programid
        {
            set { _programid = value; }
            get { return _programid; }
        }
        public Guid docid
        {
            set { _docid = value; }
            get { return _docid; }
        }

        public string conditions
        {
            set { _conditions = value; }
            get { return _conditions; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        public string aqdinitial
        {
            set { _aqdinitial = value; }
            get { return _aqdinitial; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void insertmqapa()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academics].[sp_insmqapadocs]";

            param = new SqlParameter("@programid", SqlDbType.UniqueIdentifier, 1000);
            param.Value = programid;
            li_param.Add(param);

            param = new SqlParameter("@docid", SqlDbType.UniqueIdentifier, 1000);
            param.Value = docid;
            li_param.Add(param);

            param = new SqlParameter("@conditions", SqlDbType.VarChar, 1000);
            param.Value = conditions;
            li_param.Add(param);

            param = new SqlParameter("@remarks", SqlDbType.VarChar, 1000);
            param.Value = remarks;
            li_param.Add(param);

            param = new SqlParameter("@aqdinitial", SqlDbType.VarChar, 1000);
            param.Value = aqdinitial;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 1000);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.db_mqa.ToString());
            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable mqapa_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [master].[tbldoctypemast] where del_sts = '0' and docgroup ='MQA PA' order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }
        public DataTable repeater_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [master].[tbldoctypemast] where del_sts ='0' and docgroup ='MQA-PA' order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }
        public DataTable rectification_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [master].[tbldoctypemast] where del_sts ='0' or(docgroup = 'MQA PA' and docgroup ='MQA-PA') order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
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
    }

    public class blupdatemqapadocs
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        public Guid _transid;
        public Guid _programid;
        public Guid _docid;
        public string _conditions;
        public string _remarks;
        public string _aqdinitial;
        public string _rco;
        public DateTime _rcm;
        public char _del_sts;
        public string _luo;
        public DateTime _lum;
        private string _msg;

        public Guid transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public Guid programid
        {
            set { _programid = value; }
            get { return _programid; }
        }
        public Guid docid
        {
            set { _docid = value; }
            get { return _docid; }
        }

        public string conditions
        {
            set { _conditions = value; }
            get { return _conditions; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        public string aqdinitial
        {
            set { _aqdinitial = value; }
            get { return _aqdinitial; }
        }
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }
        public string luo
        {
            set { _luo = value; }
            get { return _luo; }
        }
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        public void updatemqapa()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[academics].[sp_updtmqapadocs]";

            param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 1000);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@programid", SqlDbType.UniqueIdentifier, 50);
            param.Value = programid;
            li_param.Add(param);

            param = new SqlParameter("@docid", SqlDbType.UniqueIdentifier, 50);
            param.Value = docid;
            li_param.Add(param);

            param = new SqlParameter("@conditions", SqlDbType.VarChar, 1000);
            param.Value = conditions;
            li_param.Add(param);

            param = new SqlParameter("@remarks", SqlDbType.VarChar, 1000);
            param.Value = remarks;
            li_param.Add(param);

            param = new SqlParameter("@aqdinitial", SqlDbType.VarChar, 1000);
            param.Value = aqdinitial;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.db_mqa.ToString());
            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable mqapadocs_vw()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [academics].[tblmqapadocsubmission] where del_sts = '0' order by rcm";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }
        public DataTable vwbyprogid(Guid programid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [academics].[tblmqapadocsubmission] where programid = @programid  and del_sts = '0' order by rcm";

            param = new SqlParameter("@programid", SqlDbType.UniqueIdentifier, 50);
            param.Value = programid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

            return mdt;
        }
        public class bldeletemqapadocs
        {
            public DataAccess_sql dal;
            public SqlParameter param;
            public List<SqlParameter> li_param;
            public DataTable mdt, mdt1;
            public Guid _transid;
            public Guid _programid;
            public Guid _docid;
            public string _conditions;
            public string _remarks;
            public string _aqdinitial;
            public string _rco;
            public DateTime _rcm;
            public char _del_sts;
            public string _luo;
            public DateTime _lum;
            private string _msg;

            public Guid transid
            {
                set { _transid = value; }
                get { return _transid; }
            }
            public string luo
            {
                set { _luo = value; }
                get { return _luo; }
            }
            public string msg
            {
                set { _msg = value; }
                get { return _msg; }
            }

            public void deletemqapa()
            {
                dal = new DataAccess_sql();
                li_param = new List<SqlParameter>();

                dal.sqlcmdstr = "[academics].[sp_deletemqapadocs]";

                param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 1000);
                param.Value = transid;
                li_param.Add(param);

                param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
                param.Value = luo;
                li_param.Add(param);

                param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
                param.Direction = ParameterDirection.Output;
                li_param.Add(param);


                dal.lparam = li_param;
                dal.insertbysp(Clsutility.dbcon.db_mqa.ToString());
                msg = dal.oparam[0].Value.ToString();

            }
            public DataTable grid_vw()
            {
                dal = new DataAccess_sql();
                li_param = new List<SqlParameter>();
                mdt = new DataTable();

                dal.sqlcmdstr = "select transid, programname, mqacode, duration, shortsem, longsem from [academics].[tblprogdtls] where delsts = '0' order by rcm";

                dal.lparam = li_param;
                mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

                return mdt;
            }
            public DataTable mqapadocs_vw()
            {
                dal = new DataAccess_sql();
                li_param = new List<SqlParameter>();
                mdt = new DataTable();

                dal.sqlcmdstr = "select * from [academics].[tblmqapadocsubmission] where del_sts = '0' order by rcm";

                dal.lparam = li_param;
                mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

                return mdt;
            }
            public DataTable vwbytransid(Guid programid)
            {
                dal = new DataAccess_sql();
                li_param = new List<SqlParameter>();
                mdt = new DataTable();

                dal.sqlcmdstr = "select  mqa.transid, doc.doctype, mqa.conditions, mqa.remarks, mqa.aqdinitial from [master].[tbldoctypemast] doc inner join [academics].[tblmqapadocsubmission] mqa on doc.transid = mqa.docid where mqa.programid=@programid and mqa.del_sts= '0' order by doc.rcm";

                param = new SqlParameter("@programid", SqlDbType.UniqueIdentifier, 50);
                param.Value = programid;
                li_param.Add(param);

                dal.lparam = li_param;
                mdt = dal.view(Clsutility.dbcon.db_mqa.ToString());

                return mdt;
            }

        }
    }
}

