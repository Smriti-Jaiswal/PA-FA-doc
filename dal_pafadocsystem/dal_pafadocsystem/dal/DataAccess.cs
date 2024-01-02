using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace NSDataAccess
{
    public class DataAccess
    {
        private OleDbConnection _oledbcon;
        private OleDbDataAdapter _oledbdadapter;
        private OleDbCommand _oledbcmd;
        private OleDbTransaction _oledbtrans;

        public List<OleDbParameter> lparam = new List<OleDbParameter>();
        public List<OleDbParameter> oparam = new List<OleDbParameter>();

        private DataSet _ds;
        private DataTable _dt;

        private string _dbconstr, _sqlcmdstr, _oledbconerrmsg;
        private Int32 _ctr, _recordsaffected;
        private bool _erroroccur;
        public string sqlcmdstr
        {
            set { _sqlcmdstr = value; }
            get { return _sqlcmdstr; }
        }
        public string oledbconerrmsg
        {
            set { _oledbconerrmsg = value; }
            get { return _oledbconerrmsg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public bool erroroccur
        {
            set { _erroroccur = value; }
            get { return _erroroccur; }
        }
        public DataTable dt
        {
            set { _dt = value; }
            get { return _dt; }
        }
        public void insertbysp(string dbconn)
        {
            _dbconstr = getdbconn(dbconn);
            _oledbcon = new OleDbConnection(_dbconstr);
            _oledbcmd = new OleDbCommand();

            _oledbcmd.CommandText = sqlcmdstr;
            _oledbcmd.CommandType = CommandType.StoredProcedure;

            for (_ctr = 0; _ctr < lparam.Count; _ctr++)
            {
                _oledbcmd.Parameters.Add(lparam[_ctr]);
                if (lparam[_ctr].Direction == ParameterDirection.Output)
                    oparam.Add(lparam[_ctr]);
            }

            try
            {
                _oledbcon.Open();
                _oledbtrans = _oledbcon.BeginTransaction(IsolationLevel.Serializable);
                _oledbcmd.Connection = _oledbcon;
                _oledbcmd.Transaction = _oledbtrans;

                _recordsaffected = _oledbcmd.ExecuteNonQuery();

                _oledbtrans.Commit();

                _oledbcon.Close();

                for (_ctr = 0; _ctr < oparam.Count; _ctr++)
                    oparam[_ctr].Value = _oledbcmd.Parameters[oparam[_ctr].ParameterName.ToString()].Value;

            }

            catch (Exception ex)
            {
                _oledbconerrmsg = ex.Message;
                _oledbtrans.Rollback();
                if (_oledbcon.State != ConnectionState.Closed)
                    _oledbcon.Close();
                _oledbconerrmsg = ex.Message;

            }

            finally
            {
                if (_oledbcon.State != ConnectionState.Closed)
                    _oledbcon.Close();
            }
        }
        public void insert(string dbconn)
        {
            _dbconstr = getdbconn(dbconn);
            _oledbcon = new OleDbConnection(_dbconstr);
            //_oledbtrans = new oledbTransaction();
            _oledbcmd = new OleDbCommand();

            _oledbcmd.Connection = _oledbcon;
            _oledbcmd.CommandText = sqlcmdstr;
            _oledbcmd.CommandType = CommandType.Text;


            for (_ctr = 0; _ctr < lparam.Count; _ctr++)
                _oledbcmd.Parameters.Add(lparam[_ctr]);

            try
            {
                _oledbcon.Open();
                _oledbtrans = _oledbcon.BeginTransaction(IsolationLevel.Serializable);
                _oledbcmd.Transaction = _oledbtrans;
                _recordsaffected = _oledbcmd.ExecuteNonQuery();
                _oledbtrans.Commit();
                _oledbcon.Close();
            }

            catch (Exception ex)
            {
                _oledbtrans.Rollback();
                if (_oledbcon.State != ConnectionState.Closed)
                    _oledbcon.Close();
                _oledbconerrmsg = ex.Message;
            }

            finally
            {
                if (_oledbcon.State != ConnectionState.Closed)
                    _oledbcon.Close();
            }
        }
        public DataTable view(string dbconn)
        {
            _dbconstr = getdbconn(dbconn);
            _ds = new DataSet();
            _dt = new DataTable();
            _oledbcon = new OleDbConnection(_dbconstr);
            _oledbcmd = new OleDbCommand();
            _oledbcmd.Connection = _oledbcon;
            _oledbcmd.CommandText = sqlcmdstr;
            _oledbcmd.CommandType = CommandType.Text;
            

            for (_ctr = 0; _ctr < lparam.Count; _ctr++)
                _oledbcmd.Parameters.Add(lparam[_ctr]);

            _oledbdadapter = new OleDbDataAdapter(_oledbcmd);
            

            try
            {
                _oledbcon.Open();
                _oledbdadapter.Fill(_ds);
                _oledbcon.Close();
                _dt = _ds.Tables[0];
                _recordsaffected = _dt.Rows.Count;

            }
            catch (Exception ex)
            {
                if (_oledbcon.State != ConnectionState.Closed)
                    _oledbcon.Close();

                _oledbconerrmsg = ex.Message;
            }
            finally
            {
                if (_oledbcon.State != ConnectionState.Closed)
                    _oledbcon.Close();
            }
            return _dt;
        }
        private string db_mqa = @"Provider=System.Data.SqlClient;Data Source=LAPTOP-SE78HLRP\SQLEXPRESS;User ID=sa;Initial Catalog=db_mqa;Password=password@123";
        private string dbcnn_master = @"Provider=SQLNCLI11;Data Source=APPDATA;User ID=sa;Initial Catalog=dblucpgonline;Password=Linc0ln@LUC#2020$";
        private string dbcnn_offshore = @"Provider=SQLNCLI11;Data Source=APPDATA;User ID=sa;Initial Catalog=db_lincoln_offshore;Password=Linc0ln@LUC#2020$";
        //private string dbstd = @"Provider=SQLNCLI11;Data Source=61.12.70.125\PRODUCTION;User ID=vw_user;Initial Catalog=dbstd;Password=IT#support@2017";
        //private string dbsec = @"Provider=SQLNCLI11;Data Source=61.12.70.125\PRODUCTION;User ID=vw_user;Initial Catalog=dbsec;Password=IT#support@2017";
        //private string dbhrm = @"Provider=SQLNCLI11;Data Source=61.12.70.125\PRODUCTION;User ID=vw_user;Initial Catalog=dbhrm;Password=IT#support@2017";

        private string dbstd = @"Provider=SQLNCLI11;Data Source=APPDATA;User ID=sa;Initial Catalog=dblucpgonline;Password=Linc0ln@LUC#2020$";
        //private string dbstd = @"Provider=SQLNCLI11;Data Source=210.19.220.181\PRO,7468;User ID=luccollaborative;Initial Catalog=dbstd;Password=LUCoffshore@vw19";
        private string dbsec = @"Provider=SQLNCLI11;Data Source=210.19.220.181\PRO,7468;User ID=luccollaborative;Initial Catalog=dbsec;Password=LUCoffshore@vw19";
        private string dbhrm = @"Provider=SQLNCLI11;Data Source=210.19.220.181\PRO,7468;User ID=luccollaborative;Initial Catalog=dbhrm;Password=LUCoffshore@vw19";
        private string getdbconn(string dbconn)
        {
            switch (dbconn)
            {
                case "dbcnn_master":
                    return dbcnn_master;
                case "dbcnn_offshore":
                    return dbcnn_offshore;
                case "dbstd":
                    return dbstd;
                case "dbsec":
                    return dbsec;
                case "dbhrm":
                    return dbhrm;
                case "db_mqa":
                    return db_mqa;
                default:
                    return "";
            }
        }
    }

    public class DataAccess_sql
    {
        private SqlConnection _sqlcon;
        private SqlDataAdapter _sqldadapter;
        private SqlCommand _sqlcmd;
        private SqlTransaction _sqltrans;

        public List<SqlParameter> lparam = new List<SqlParameter>();
        public List<SqlParameter> oparam = new List<SqlParameter>();

        private DataSet _ds;
        private DataTable _dt;

        private string _dbconstr, _sqlcmdstr, _sqlconerrmsg;
        private Int32 _ctr, _recordsaffected;
        private bool _erroroccur;
        public string sqlcmdstr
        {
            set { _sqlcmdstr = value; }
            get { return _sqlcmdstr; }
        }
        public string sqlconerrmsg
        {
            set { _sqlconerrmsg = value; }
            get { return _sqlconerrmsg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }
        public bool erroroccur
        {
            set { _erroroccur = value; }
            get { return _erroroccur; }
        }
        public DataTable dt
        {
            set { _dt = value; }
            get { return _dt; }
        }

        public void insertbysp(string dbconn)
        {
            _dbconstr = getdbconn(dbconn);
            _sqlcon = new SqlConnection(_dbconstr);
            _sqlcmd = new SqlCommand();

            _sqlcmd.CommandText = sqlcmdstr;
            _sqlcmd.CommandType = CommandType.StoredProcedure;

            for (_ctr = 0; _ctr < lparam.Count; _ctr++)
            {
                _sqlcmd.Parameters.Add(lparam[_ctr]);
                if (lparam[_ctr].Direction == ParameterDirection.Output)
                    oparam.Add(lparam[_ctr]);
            }

            try
            {
                _sqlcon.Open();
                _sqltrans = _sqlcon.BeginTransaction(IsolationLevel.Serializable);
                _sqlcmd.Connection = _sqlcon;
                _sqlcmd.Transaction = _sqltrans;

                _recordsaffected = _sqlcmd.ExecuteNonQuery();

                _sqltrans.Commit();

                _sqlcon.Close();

                for (_ctr = 0; _ctr < oparam.Count; _ctr++)
                    oparam[_ctr].Value = _sqlcmd.Parameters[oparam[_ctr].ParameterName.ToString()].Value;

            }

            catch (Exception ex)
            {
                _sqlconerrmsg = ex.Message;
                _sqltrans.Rollback();
                if (_sqlcon.State != ConnectionState.Closed)
                    _sqlcon.Close();
                _sqlconerrmsg = ex.Message;

            }

            finally
            {
                if (_sqlcon.State != ConnectionState.Closed)
                    _sqlcon.Close();
            }
        }

        public void insert(string dbconn)
        {
            _dbconstr = getdbconn(dbconn);
            _sqlcon = new SqlConnection(_dbconstr);
            //_sqltrans = new SqlTransaction();
            _sqlcmd = new SqlCommand();

            _sqlcmd.Connection = _sqlcon;
            _sqlcmd.CommandText = sqlcmdstr;
            _sqlcmd.CommandType = CommandType.Text;


            for (_ctr = 0; _ctr < lparam.Count; _ctr++)
                _sqlcmd.Parameters.Add(lparam[_ctr]);

            try
            {
                _sqlcon.Open();
                _sqltrans = _sqlcon.BeginTransaction(IsolationLevel.Serializable);
                _sqlcmd.Transaction = _sqltrans;
                _recordsaffected = _sqlcmd.ExecuteNonQuery();
                _sqltrans.Commit();
                _sqlcon.Close();
            }

            catch (Exception ex)
            {
                _sqltrans.Rollback();
                if (_sqlcon.State != ConnectionState.Closed)
                    _sqlcon.Close();
                _sqlconerrmsg = ex.Message;
            }

            finally
            {
                if (_sqlcon.State != ConnectionState.Closed)
                    _sqlcon.Close();
            }
        }

        public DataTable view(string dbconn)
        {
            _dbconstr = getdbconn(dbconn);
            _ds = new DataSet();
            _dt = new DataTable();
            _sqlcon = new SqlConnection(_dbconstr);
            _sqlcmd = new SqlCommand();
            _sqlcmd.Connection = _sqlcon;
            _sqlcmd.CommandText = sqlcmdstr;
            _sqlcmd.CommandType = CommandType.Text;


            for (_ctr = 0; _ctr < lparam.Count; _ctr++)
                _sqlcmd.Parameters.Add(lparam[_ctr]);

            _sqldadapter = new SqlDataAdapter(_sqlcmd);


            try
            {
                _sqlcon.Open();
                _sqldadapter.Fill(_ds);
                _sqlcon.Close();
                _dt = _ds.Tables[0];
                _recordsaffected = _dt.Rows.Count;

            }
            catch (Exception ex)
            {
                if (_sqlcon.State != ConnectionState.Closed)
                    _sqlcon.Close();

                _sqlconerrmsg = ex.Message;
            }
            finally
            {
                if (_sqlcon.State != ConnectionState.Closed)
                    _sqlcon.Close();
            }
            return _dt;
        }
        private string db_mqa = @"Data Source=LAPTOP-SE78HLRP\SQLEXPRESS;User ID=sa;Initial Catalog=db_mqa;Password=password@123";
        private string dbcnn_master = @"Data Source=APPDATA;User ID=sa;Initial Catalog=dblucpgonline;Password=Linc0ln@LUC#2020$";
        private string dbcnn_offshore= @"Data Source=APPDATA;User ID=sa;Initial Catalog=db_lincoln_offshore;Password=Linc0ln@LUC#2020$";
        //private string dbstd = @"Data Source=61.12.70.125\PRODUCTION;User ID=vw_user;Initial Catalog=dbstd;Password=IT#support@2017";
        //private string dbsec = @"Data Source=61.12.70.125\PRODUCTION;User ID=vw_user;Initial Catalog=dbsec;Password=IT#support@2017";
        //private string dbhrm = @"Data Source=61.12.70.125\PRODUCTION;User ID=vw_user;Initial Catalog=dbhrm;Password=IT#support@2017";

        private string dbstd = @"Data Source=APPDATA;User ID=sa;Initial Catalog=dblucpgonline;Password=Linc0ln@LUC#2020$";
        // private string dbstd = @"Data Source=210.19.220.181\PRO,7468;User ID=luccollaborative;Initial Catalog=dbstd;Password=LUCoffshore@vw19";
        private string dbsec = @"Data Source=210.19.220.181\PRO,7468;User ID=luccollaborative;Initial Catalog=dbsec;Password=LUCoffshore@vw19";
        private string dbhrm = @"Data Source=210.19.220.181\PRO,7468;User ID=luccollaborative;Initial Catalog=dbhrm;Password=LUCoffshore@vw19";
        private string getdbconn(string dbconn)
        {
            switch (dbconn)
            {
                case "dbcnn_master":
                    return dbcnn_master;
                case "dbcnn_offshore":
                    return dbcnn_offshore;
                case "dbstd":
                    return dbstd;
                case "dbsec":
                    return dbsec;
                case "dbhrm":
                    return dbhrm;
                case "db_mqa":
                    return db_mqa;
                default:
                    return "";
            }
        }
    }
}