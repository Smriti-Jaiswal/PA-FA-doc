using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using NSDataAccess;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSApplication
{
    public class bluniapplication
    {
        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _userid;
        private string _hashid;

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
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        public string hashid
        {
            set { _hashid = value; }
            get { return _hashid; }
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

        public void passchgehash()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[system].[sppasschgehash]";

            param = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            param.Value = userid;
            li_param.Add(param);

            param = new SqlParameter("@hashid", SqlDbType.VarChar, 50);
            param.Value = hashid;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

        }

        public void checkpasschgehash()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[system].[spchkpasschgehash]";

            param = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            param.Value = userid;
            li_param.Add(param);

            param = new SqlParameter("@hashid", SqlDbType.VarChar, 50);
            param.Value = hashid;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 10);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable vwbyapprovalsts(string sts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from ";
            dal.sqlcmdstr += "(select row_number() over(partition by Email_ID order by rcm) as row_numbers, * from tblSCDetailsofInstitution) tbl";
            dal.sqlcmdstr += " where tbl.row_numbers = 1 and approved = @sts";

            param = new SqlParameter("@sts", SqlDbType.VarChar, 1);
            param.Value = sts;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapprovalbyid(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from tblSCDetailsofInstitution where transid=@transid";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapprovalbylocat(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tbllocatmast.*,countryname,salname+' '+tbllocatmast.contactpersonname as name,tbllocatmast.locatid as locationid from tbllocatmast inner join dbhrm..tblcountrymast on countryid=Country inner join salmast on tbllocatmast.contactpersonnamesalid=salmast.salid where transid=@transid";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapprovalbyemailid(string emailid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from tblSCDetailsofInstitution where Email_ID=@emailid";

            param = new SqlParameter("@emailid", SqlDbType.VarChar, 50);
            param.Value = emailid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplspvremailid(string emailid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [appl].[tblsupervisorappl] where email=@emailid and del_sts='0'";

            param = new SqlParameter("@emailid", SqlDbType.VarChar, 50);
            param.Value = emailid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapprovalbylocatid(string locationid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (locationid.Substring(0, 6).ToString().ToUpper() == "LUCSAC")
            {

                dal.sqlcmdstr = "select tblSCDetailsofInstitution.*,countryname from tblSCDetailsofInstitution inner join dbhrm..tblcountrymast on countryid=Country where locationid=@locationid";

                param = new SqlParameter("@locationid", SqlDbType.VarChar, 50);
                param.Value = locationid;
                li_param.Add(param);
                dal.lparam = li_param;
            }
            else
            {
                //  dal.sqlcmdstr = "select tbllocatmast.*,countryname,salname+' '+tbllocatmast.contactpersonname as name,tbllocatmast.locatid as locationid from tbllocatmast inner join dbhrm..tblcountrymast on countryid=Country inner join salmast on tbllocatmast.contactpersonnamesalid=salmast.salid where locatid=@locationid";
                dal.sqlcmdstr = "select tbllocatmast.*,countryname,salname+' '+tbllocatmast.contactpersonname as 'Institute_Head_Name',tbllocatmast.officename as 'Name_of_the_Institution',tbllocatmast.E_MAILID as 'Email_ID',tbllocatmast.TelNo as 'Mobile_Number',tbllocatmast.locatid as locationid,tbllocatmast.paddress as 'Head_Regd_Address',tbllocatmast.pstate as 'pCity',tbllocatmast.ppin as 'pPostCode',tbllocatmast.pstate as 'pState',countryname as 'pCountry'  from tbllocatmast inner join dbhrm..tblcountrymast on countryid=Country inner join salmast on tbllocatmast.contactpersonnamesalid=salmast.salid where locatid=@locationid";


                param = new SqlParameter("@locationid", SqlDbType.VarChar, 50);
                param.Value = locationid;
                li_param.Add(param);
                dal.lparam = li_param;
            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_locationid()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            dal.sqlcmdstr = "select transid, locationid as locationid from [db_lincoln_offshore]..tblSCDetailsofInstitution union";
            dal.sqlcmdstr += " select transid,locatid as locationid from[db_lincoln_offshore]..tbllocatmast";

            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            return mdt;
        }

        public DataTable vwbyapprovalbypartnerid(string locationid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (locationid.Substring(0, 6).ToString().ToUpper() == "LUCSAC")
            {

                dal.sqlcmdstr = "select tblSCDetailsofInstitution.*,countryname from tblSCDetailsofInstitution inner join dbhrm..tblcountrymast on countryid=Country where locationid=@locationid";

                param = new SqlParameter("@locationid", SqlDbType.VarChar, 50);
                param.Value = locationid;
                li_param.Add(param);
                dal.lparam = li_param;
            }
            else
            {
                dal.sqlcmdstr = "select tbllocatmast.officename as 'Name_of_the_Institution',tbllocatmast.ppin as 'pPostCode',tbllocatmast.pstate as 'pState',tbllocatmast.TelNo as 'Mobile_Number', tbllocatmast.WebsiteAdd as 'Website_Address',tbllocatmast.E_MAILID as 'Email_ID',countryname,salname+' '+tbllocatmast.contactpersonname as 'Institute_Head_Name',tbllocatmast.locatid as locationid from db_lincoln_offshore..tbllocatmast inner join dbhrm..tblcountrymast on countryid=Country inner join db_lincoln_offshore..salmast on tbllocatmast.contactpersonnamesalid=salmast.salid where locatid=@locationid";

                param = new SqlParameter("@locationid", SqlDbType.VarChar, 50);
                param.Value = locationid;
                li_param.Add(param);
                dal.lparam = li_param;
            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwagentsbylocatid(string urm)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tbleducationalconsultant.*,countryname from tbleducationalconsultant inner join tblcountrymast on countryid=country where eccode=@urm";

            param = new SqlParameter("@urm", SqlDbType.VarChar, 50);
            param.Value = urm;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbhrm.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstaffbyid(string employeeid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from vw_employee where employeeid=@employeeid";

            param = new SqlParameter("@employeeid", SqlDbType.VarChar, 50);
            param.Value = employeeid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbhrm.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwsSCAssociatInstitutionDetailsbyid(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from tblSCAssociatInstitutionDetails where frmmodtransid=@frmmodtransid order by Programmes_Being_Offered";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_offshore.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_asct_dtls()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            dal.sqlcmdstr = "select * from appl.vw_asctdtls";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        // Mou Upload

        private string _locationid;
        private string _moufileupld;

        public string locationid
        {
            set { _locationid = value; }
            get { return _locationid; }
        }
        public string moufileupld
        {
            set { _moufileupld = value; }
            get { return _moufileupld; }
        }
        private string _name;

        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public void insassomouupld()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_insassomouupld";

            param = new SqlParameter("@locationid", SqlDbType.VarChar, 50);
            param.Value = locationid;
            li_param.Add(param);

            param = new SqlParameter("@moufileupld", SqlDbType.VarChar, 500);
            param.Value = moufileupld;
            li_param.Add(param);

            param = new SqlParameter("@name", SqlDbType.VarChar, 500);
            param.Value = name;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }

        public DataTable vw_assomoudtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select assodtls.*,assomoupld.moufileupld from appl.vw_asctdtls assodtls inner join appl.tblassomoupld assomoupld on assodtls.locationid COLLATE DATABASE_DEFAULT=assomoupld.locationid COLLATE DATABASE_DEFAULT where assomoupld.locationid like 'LUCSAC%' or assomoupld.locationid like 'LC%' ";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_assoagentmoudtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from appl.tblassomoupld where locationid like 'URM%' ";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vw_allotment()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            dal.sqlcmdstr = "select * from appl.vwappallow";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

    }
    public class blapplication
    {

        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        private string _transid;
        private string _frmmodtransid;
        private string _applid;
        private string _stage;
        private string _process;
        private string _appl_sal;
        private string _appl_fname;
        private string _appl_mname;
        private string _appl_lname;
        private string _appl_course;
        private string _appl_specialization;
        private string _appl_intake;
        private string _appl_area_of_study;
        private string _appl_study_type;
        private string _appl_discipline;
        private string _appl_martialsts;
        private string _appl_gender;
        private DateTime _appl_dateofbirth;
        private string _appl_highestquaily;
        private string _appl_nationality;
        private string _appl_personalcontact;
        private string _appl_alt_personalcontact;
        private string _appl_email;
        private string _appl_alt_email;
        private string _appl_citizenshipno;
        private string _appl_passport;

        private string _appl_permanentaddress;
        private string _appl_ppincode;
        private string _appl_pstate;
        private string _appl_pcountry;
        private string _appl_corrospondanceaddress;
        private string _appl_cpincode;
        private string _appl_cstate;
        private string _appl_ccountry;

        private string _appl_fathersal;
        private string _appl_fathername;
        private string _appl_fathercontactno;
        private string _appl_mothersal;
        private string _appl_mothername;
        private string _appl_mothercontactno;
        private string _appl_gurdainsal;
        private string _appl_gurdainname;
        private string _appl_gurdaincontactno;
        private string _appl_docid;
        private string _appl_fileupload;
        private DataTable _identification_doc_upload;
        private DataTable _education_dtls_upload;
        private DataTable _job_dtls_upload;
        private DataTable _publication_dtls_upload;
        private DataTable _reserach_fund_upload;
        //added
        private DataTable _achivement_dtls;
        private string _facebook;
        private string _twitter;
        private string _linkedin;
        private string _youtube;
        //added
        private string _appl_fundingsrc;
        private string _appl_research_statement;
        private string _appl_research_requirements;
        private string _appl_addi_enclosures;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        private string _appl_cat;

        private string _comments;
        private string _fileattachid;
        private Int32 _security_lvl;
        private DataTable _type_tblfileattach;

        

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string frmmodtransid
        {
            set { _frmmodtransid = value; }
            get { return _frmmodtransid; }
        }
        public string applid
        {
            set { _applid = value; }
            get { return _applid; }
        }
        public string stage
        {
            set { _stage = value; }
            get { return _stage; }
        }
        public string process
        {
            set { _process = value; }
            get { return _process; }
        }
        public string appl_sal
        {
            set { _appl_sal = value; }
            get { return _appl_sal; }
        }
        public string appl_fname
        {
            set { _appl_fname = value; }
            get { return _appl_fname; }
        }
        public string appl_mname
        {
            set { _appl_mname = value; }
            get { return _appl_mname; }
        }
        public string appl_lname
        {
            set { _appl_lname = value; }
            get { return _appl_lname; }
        }
        public string appl_course
        {
            set { _appl_course = value; }
            get { return _appl_course; }
        }

        public string appl_specialization
        {
            set { _appl_specialization = value; }
            get { return _appl_specialization; }
        }
        public string appl_intake
        {
            set { _appl_intake = value; }
            get { return _appl_intake; }
        }
        public string appl_area_of_study
        {
            set { _appl_area_of_study = value; }
            get { return _appl_area_of_study; }
        }
        public string appl_study_type
        {
            set { _appl_study_type = value; }
            get { return _appl_study_type; }
        }
        public string appl_discipline
        {
            set { _appl_discipline = value; }
            get { return _appl_discipline; }
        }
        public string appl_martialsts
        {
            set { _appl_martialsts = value; }
            get { return _appl_martialsts; }
        }
        public string appl_gender
        {
            set { _appl_gender = value; }
            get { return _appl_gender; }
        }
        public DateTime appl_dateofbirth
        {
            set { _appl_dateofbirth = value; }
            get { return _appl_dateofbirth; }
        }
        public string appl_highestquaily
        {
            set { _appl_highestquaily = value; }
            get { return _appl_highestquaily; }
        }
        public string appl_nationality
        {
            set { _appl_nationality = value; }
            get { return _appl_nationality; }
        }
        public string appl_personalcontact
        {
            set { _appl_personalcontact = value; }
            get { return _appl_personalcontact; }
        }
        public string appl_alt_personalcontact
        {
            set { _appl_alt_personalcontact = value; }
            get { return _appl_alt_personalcontact; }
        }
        public string appl_email
        {
            set { _appl_email = value; }
            get { return _appl_email; }
        }
        public string appl_alt_email
        {
            set { _appl_alt_email = value; }
            get { return _appl_alt_email; }
        }
        public string appl_citizenshipno
        {
            set { _appl_citizenshipno = value; }
            get { return _appl_citizenshipno; }
        }
        public string appl_passport
        {
            set { _appl_passport = value; }
            get { return _appl_passport; }
        }
        public string appl_permanentaddress
        {
            set { _appl_permanentaddress = value; }
            get { return _appl_permanentaddress; }
        }
        public string appl_ppincode
        {
            set { _appl_ppincode = value; }
            get { return _appl_ppincode; }
        }
        public string appl_pstate
        {
            set { _appl_pstate = value; }
            get { return _appl_pstate; }
        }
        public string appl_pcountry
        {
            set { _appl_pcountry = value; }
            get { return _appl_pcountry; }
        }
        public string appl_corrospondanceaddress
        {
            set { _appl_corrospondanceaddress = value; }
            get { return _appl_corrospondanceaddress; }
        }
        public string appl_cpincode
        {
            set { _appl_cpincode = value; }
            get { return _appl_cpincode; }
        }
        public string appl_cstate
        {
            set { _appl_cstate = value; }
            get { return _appl_cstate; }
        }
        public string appl_ccountry
        {
            set { _appl_ccountry = value; }
            get { return _appl_ccountry; }
        }
        public string appl_fathersal
        {
            set { _appl_fathersal = value; }
            get { return _appl_fathersal; }
        }
        public string appl_fathername
        {
            set { _appl_fathername = value; }
            get { return _appl_fathername; }
        }
        public string appl_fathercontactno
        {
            set { _appl_fathercontactno = value; }
            get { return _appl_fathercontactno; }
        }
        public string appl_mothersal
        {
            set { _appl_mothersal = value; }
            get { return _appl_mothersal; }
        }
        public string appl_mothername
        {
            set { _appl_mothername = value; }
            get { return _appl_mothername; }
        }
        public string appl_mothercontactno
        {
            set { _appl_mothercontactno = value; }
            get { return _appl_mothercontactno; }
        }
        public string appl_gurdainsal
        {
            set { _appl_gurdainsal = value; }
            get { return _appl_gurdainsal; }
        }
        public string appl_gurdainname
        {
            set { _appl_gurdainname = value; }
            get { return _appl_gurdainname; }
        }
        public string appl_gurdaincontactno
        {
            set { _appl_gurdaincontactno = value; }
            get { return _appl_gurdaincontactno; }
        }
        public string appl_docid
        {
            set { _appl_docid = value; }
            get { return _appl_docid; }
        }
        public string appl_fileupload
        {
            set { _appl_fileupload = value; }
            get { return _appl_fileupload; }
        }
        public DataTable identification_doc_upload
        {
            set { _identification_doc_upload = value; }
            get { return _identification_doc_upload; }
        }
        public DataTable education_dtls_upload
        {
            set { _education_dtls_upload = value; }
            get { return _education_dtls_upload; }
        }
        public DataTable job_dtls_upload
        {
            set { _job_dtls_upload = value; }
            get { return _job_dtls_upload; }
        }
        public DataTable publication_dtls_upload
        {
            set { _publication_dtls_upload = value; }
            get { return _publication_dtls_upload; }
        }
        public DataTable reserach_fund_upload
        {
            set { _reserach_fund_upload = value; }
            get { return _reserach_fund_upload; }
        }
        //added
        public DataTable achivement_dtls
        {
            set { _achivement_dtls = value; }
            get { return _achivement_dtls; }
        }
        public string facebook
        {
            set { _facebook = value; }
            get { return _facebook; }
        }
        public string twitter
        {
            set { _twitter = value; }
            get { return _twitter; }
        }
        public string linkedin
        {
            set { _linkedin = value; }
            get { return _linkedin; }
        }
        public string youtube
        {
            set { _youtube = value; }
            get { return _youtube; }
        }
        //added
        public string appl_fundingsrc
        {
            get { return _appl_fundingsrc; }
            set { _appl_fundingsrc = value; }
        }
        public string appl_research_statement
        {
            get { return _appl_research_statement; }
            set { _appl_research_statement = value; }
        }
        public string appl_research_requirements
        {
            get { return _appl_research_requirements; }
            set { _appl_research_requirements = value; }
        }
        public string appl_addi_enclosures
        {
            get { return _appl_addi_enclosures; }
            set { _appl_addi_enclosures = value; }
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
        public string appl_cat
        {
            set { _appl_cat = value; }
            get { return _appl_cat; }
        }

        private decimal _totalfees;
        private decimal _scholarshipfees;
        private DateTime _offerltrgendt;
        private string _deptsname;
        private string _offerltrnum;
        private DateTime _regdate;
        private string _reserach_field;
        private string _thesissbmtminperiod;
        private string _thesissbmtmaxperiod;
        private string _stdid;
        private string _hashid;
        private DataTable _type_tblfeesdlts;
        private string _currency;
        private string _bankslip_url;
        private char _verified_sts;
        private string _receipt_url;
        private string _remarks;
        private string _bnk;
        private string _min_duration;
        private string _max_duration;

        private decimal _amnt;
        private DateTime _paydt;
        private string _commdesc;
        private string _pay_doc;
        private string _spvrid;
        private string _spvrtype;
        private DateTime _allotdate;

        private string _form;
        private string _url;
        private DataTable _article_dtls;

        private DataTable _stdcnf_dtls;

        public decimal _agt_commission;
        public string _agt_commission_currency;

        public decimal agt_commission
        {
            set { _agt_commission = value; }
            get { return _agt_commission; }
        }
        public string agt_commission_currency
        {
            set { _agt_commission_currency = value; }
            get { return _agt_commission_currency; }
        }

        public DataTable stdcnf_dtls
        {
            set { _stdcnf_dtls = value; }
            get { return _stdcnf_dtls; }
        }
        public DataTable article_dtls
        {
            set { _article_dtls = value; }
            get { return _article_dtls; }
        }
        public string form
        {
            set { _form = value; }
            get { return _form; }
        }
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        public decimal amnt
        {
            set { _amnt = value; }
            get { return _amnt; }
        }
        public DateTime paydt
        {
            set { _paydt = value; }
            get { return _paydt; }
        }
        public string commdesc
        {
            set { _commdesc = value; }
            get { return _commdesc; }
        }
        public string pay_doc
        {
            set { _pay_doc = value; }
            get { return _pay_doc; }
        }

        public decimal totalfees
        {
            set { _totalfees = value; }
            get { return _totalfees; }
        }
        public decimal scholarshipfees
        {
            set { _scholarshipfees = value; }
            get { return _scholarshipfees; }
        }
        public DateTime offerltrgendt
        {
            set { _offerltrgendt = value; }
            get { return _offerltrgendt; }
        }
        public string deptsname
        {
            set { _deptsname = value; }
            get { return _deptsname; }
        }
        public string offerltrnum
        {
            set { _offerltrnum = value; }
            get { return _offerltrnum; }
        }
        public DateTime regdate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        public string reserach_field
        {
            set { _reserach_field = value; }
            get { return _reserach_field; }
        }
        public string thesissbmtminperiod
        {
            set { _thesissbmtminperiod = value; }
            get { return _thesissbmtminperiod; }
        }
        public string thesissbmtmaxperiod
        {
            set { _thesissbmtmaxperiod = value; }
            get { return _thesissbmtmaxperiod; }
        }

        public string stdid
        {
            set { _stdid = value; }
            get { return _stdid; }
        }
        public string comments
        {
            set { _comments = value; }
            get { return _comments; }
        }

        public string fileattachid
        {
            set { _fileattachid = value; }
            get { return _fileattachid; }
        }
        public string hashid
        {
            set { _hashid = value; }
            get { return _hashid; }
        }
        public string bankslip_url
        {
            set { _bankslip_url = value; }
            get { return _bankslip_url; }
        }
        public char verified_sts
        {
            set { _verified_sts = value; }
            get { return _verified_sts; }
        }
        public string receipt_url
        {
            set { _receipt_url = value; }
            get { return _receipt_url; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }

        public string min_duration
        {
            set { _min_duration = value; }
            get { return _min_duration; }
        }

        public string max_duration
        {
            set { _max_duration = value; }
            get { return _max_duration; }
        }

        public string spvrid
        {
            set { _spvrid = value; }
            get { return _spvrid; }
        }

        public string spvrtype
        {
            set { _spvrtype = value; }
            get { return _spvrtype; }
        }
        public DateTime allotdate
        {
            set { _allotdate = value; }
            get { return _allotdate; }
        }
        public Int32 security_lvl
        {
            set { _security_lvl = value; }
            get { return _security_lvl; }
        }

        public DataTable type_tblfileattach
        {
            set { _type_tblfileattach = value; }
            get { return _type_tblfileattach; }
        }

        public DataTable type_tblfeesdlts
        {
            set { _type_tblfeesdlts = value; }
            get { return _type_tblfeesdlts; }
        }
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        public string bnk
        {
            set { _bnk = value; }
            get { return _bnk; }
        }
        //new method added
        public void ins_honappldetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinshonappldetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@appl_sal", SqlDbType.VarChar, 50);
            param.Value = appl_sal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fname", SqlDbType.VarChar, 1000);
            param.Value = appl_fname;
            li_param.Add(param);

            param = new SqlParameter("@appl_mname", SqlDbType.VarChar, 1000);
            param.Value = appl_mname;
            li_param.Add(param);

            param = new SqlParameter("@appl_lname", SqlDbType.VarChar, 1000);
            param.Value = appl_lname;
            li_param.Add(param);

            param = new SqlParameter("@appl_course", SqlDbType.VarChar, 50);
            param.Value = appl_course;
            li_param.Add(param);

            param = new SqlParameter("@appl_specialization", SqlDbType.VarChar, 500);
            param.Value = appl_specialization;
            li_param.Add(param);

            param = new SqlParameter("@appl_area_of_study", SqlDbType.VarChar, 500);
            param.Value = appl_area_of_study;
            li_param.Add(param);

            param = new SqlParameter("@appl_study_type", SqlDbType.VarChar, 100);
            param.Value = appl_study_type;
            li_param.Add(param);

            param = new SqlParameter("@appl_discipline", SqlDbType.VarChar, 100);
            param.Value = appl_discipline;
            li_param.Add(param);

            param = new SqlParameter("@appl_martialsts", SqlDbType.VarChar, 20);
            param.Value = appl_martialsts;
            li_param.Add(param);

            param = new SqlParameter("@appl_gender", SqlDbType.VarChar, 20);
            param.Value = appl_gender;
            li_param.Add(param);

            param = new SqlParameter("@appl_dateofbirth", SqlDbType.Date, 10);
            param.Value = appl_dateofbirth;
            li_param.Add(param);

            param = new SqlParameter("@appl_highestquaily", SqlDbType.VarChar, 50);
            param.Value = appl_highestquaily;
            li_param.Add(param);

            param = new SqlParameter("@appl_nationality", SqlDbType.VarChar, 50);
            param.Value = appl_nationality;
            li_param.Add(param);

            param = new SqlParameter("@appl_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_alt_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_email", SqlDbType.VarChar, 100);
            param.Value = appl_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_email", SqlDbType.VarChar, 100);
            param.Value = appl_alt_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_citizenshipno", SqlDbType.VarChar, 100);
            param.Value = appl_citizenshipno;
            li_param.Add(param);

            param = new SqlParameter("@appl_passport", SqlDbType.VarChar, 100);
            param.Value = appl_passport;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@appl_permanentaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_permanentaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_ppincode", SqlDbType.VarChar, 50);
            param.Value = appl_ppincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_pstate", SqlDbType.VarChar, 500);
            param.Value = appl_pstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_pcountry", SqlDbType.VarChar, 50);
            param.Value = appl_pcountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_corrospondanceaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_corrospondanceaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_cpincode", SqlDbType.VarChar, 50);
            param.Value = appl_cpincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_cstate", SqlDbType.VarChar, 500);
            param.Value = appl_cstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_ccountry", SqlDbType.VarChar, 50);
            param.Value = appl_ccountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathersal", SqlDbType.VarChar, 50);
            param.Value = appl_fathersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathername", SqlDbType.VarChar, 1000);
            param.Value = appl_fathername;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_fathercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothersal", SqlDbType.VarChar, 50);
            param.Value = appl_mothersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothername", SqlDbType.VarChar, 1000);
            param.Value = appl_mothername;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_mothercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainsal", SqlDbType.VarChar, 50);
            param.Value = appl_gurdainsal;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainname", SqlDbType.VarChar, 1000);
            param.Value = appl_gurdainname;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdaincontactno", SqlDbType.VarChar, 20);
            param.Value = appl_gurdaincontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_fundingsrc", SqlDbType.VarChar, 500);
            param.Value = appl_fundingsrc;
            li_param.Add(param);

            param = new SqlParameter("@appl_research_statement", SqlDbType.VarChar, -1);
            param.Value = appl_research_statement;
            li_param.Add(param);

            param = new SqlParameter("@appl_research_requirements", SqlDbType.VarChar, -1);
            param.Value = appl_research_requirements;
            li_param.Add(param);

            param = new SqlParameter("@appl_addi_enclosures", SqlDbType.VarChar, -1);
            param.Value = appl_addi_enclosures;
            li_param.Add(param);

            param = new SqlParameter("@type_tblappldocumentsupload", SqlDbType.Structured, -1);
            param.Value = identification_doc_upload;
            li_param.Add(param);

            param = new SqlParameter("@education_dtls_upload", SqlDbType.Structured, -1);
            param.Value = education_dtls_upload;
            li_param.Add(param);

            param = new SqlParameter("@type_job_dtls_upload", SqlDbType.Structured, -1);
            param.Value = job_dtls_upload;
            li_param.Add(param);
                     
            param = new SqlParameter("@type_achivement_dtls", SqlDbType.Structured, -1);
            param.Value = achivement_dtls;
            li_param.Add(param);

           
            param = new SqlParameter("@facebook", SqlDbType.VarChar, 1000);
            param.Value = facebook;
            li_param.Add(param);

           
            param = new SqlParameter("@twitter", SqlDbType.VarChar, 1000);
            param.Value = twitter;
            li_param.Add(param);

            
            param = new SqlParameter("@linkedin", SqlDbType.VarChar, 1000);
            param.Value = linkedin;
            li_param.Add(param);

            
            param = new SqlParameter("@youtube", SqlDbType.VarChar, 50000);
            param.Value = youtube;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@stage", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@process", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            applid = dal.oparam[1].Value.ToString();
            stage = dal.oparam[2].Value.ToString();
            process = dal.oparam[3].Value.ToString();

        }
        public void ins_appldetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsappldetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@appl_sal", SqlDbType.VarChar, 50);
            param.Value = appl_sal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fname", SqlDbType.VarChar, 1000);
            param.Value = appl_fname;
            li_param.Add(param);

            param = new SqlParameter("@appl_mname", SqlDbType.VarChar, 1000);
            param.Value = appl_mname;
            li_param.Add(param);

            param = new SqlParameter("@appl_lname", SqlDbType.VarChar, 1000);
            param.Value = appl_lname;
            li_param.Add(param);

            param = new SqlParameter("@appl_course", SqlDbType.VarChar, 50);
            param.Value = appl_course;
            li_param.Add(param);

            param = new SqlParameter("@appl_specialization", SqlDbType.VarChar, 500);
            param.Value = appl_specialization;
            li_param.Add(param);

            param = new SqlParameter("@appl_area_of_study", SqlDbType.VarChar, 500);
            param.Value = appl_area_of_study;
            li_param.Add(param);

            param = new SqlParameter("@appl_study_type", SqlDbType.VarChar, 100);
            param.Value = appl_study_type;
            li_param.Add(param);

            param = new SqlParameter("@appl_discipline", SqlDbType.VarChar, 100);
            param.Value = appl_discipline;
            li_param.Add(param);

            param = new SqlParameter("@appl_martialsts", SqlDbType.VarChar, 20);
            param.Value = appl_martialsts;
            li_param.Add(param);

            param = new SqlParameter("@appl_gender", SqlDbType.VarChar, 20);
            param.Value = appl_gender;
            li_param.Add(param);

            param = new SqlParameter("@appl_dateofbirth", SqlDbType.Date, 10);
            param.Value = appl_dateofbirth;
            li_param.Add(param);

            param = new SqlParameter("@appl_highestquaily", SqlDbType.VarChar, 50);
            param.Value = appl_highestquaily;
            li_param.Add(param);

            param = new SqlParameter("@appl_nationality", SqlDbType.VarChar, 50);
            param.Value = appl_nationality;
            li_param.Add(param);

            param = new SqlParameter("@appl_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_alt_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_email", SqlDbType.VarChar, 100);
            param.Value = appl_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_email", SqlDbType.VarChar, 100);
            param.Value = appl_alt_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_citizenshipno", SqlDbType.VarChar, 100);
            param.Value = appl_citizenshipno;
            li_param.Add(param);

            param = new SqlParameter("@appl_passport", SqlDbType.VarChar, 100);
            param.Value = appl_passport;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@appl_permanentaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_permanentaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_ppincode", SqlDbType.VarChar, 50);
            param.Value = appl_ppincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_pstate", SqlDbType.VarChar, 500);
            param.Value = appl_pstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_pcountry", SqlDbType.VarChar, 50);
            param.Value = appl_pcountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_corrospondanceaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_corrospondanceaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_cpincode", SqlDbType.VarChar, 50);
            param.Value = appl_cpincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_cstate", SqlDbType.VarChar, 500);
            param.Value = appl_cstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_ccountry", SqlDbType.VarChar, 50);
            param.Value = appl_ccountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathersal", SqlDbType.VarChar, 50);
            param.Value = appl_fathersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathername", SqlDbType.VarChar, 1000);
            param.Value = appl_fathername;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_fathercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothersal", SqlDbType.VarChar, 50);
            param.Value = appl_mothersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothername", SqlDbType.VarChar, 1000);
            param.Value = appl_mothername;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_mothercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainsal", SqlDbType.VarChar, 50);
            param.Value = appl_gurdainsal;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainname", SqlDbType.VarChar, 1000);
            param.Value = appl_gurdainname;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdaincontactno", SqlDbType.VarChar, 20);
            param.Value = appl_gurdaincontactno;
            li_param.Add(param);
            
            param = new SqlParameter("@appl_fundingsrc", SqlDbType.VarChar, 500);
            param.Value = appl_fundingsrc;
            li_param.Add(param);

            param = new SqlParameter("@appl_research_statement", SqlDbType.VarChar, -1);
            param.Value = appl_research_statement;
            li_param.Add(param);

            param = new SqlParameter("@appl_research_requirements", SqlDbType.VarChar, -1);
            param.Value = appl_research_requirements;
            li_param.Add(param);

            param = new SqlParameter("@appl_addi_enclosures", SqlDbType.VarChar, -1);
            param.Value = appl_addi_enclosures;
            li_param.Add(param);

            param = new SqlParameter("@type_tblappldocumentsupload", SqlDbType.Structured, -1);
            param.Value = identification_doc_upload;
            li_param.Add(param);

            param = new SqlParameter("@education_dtls_upload", SqlDbType.Structured, -1);
            param.Value = education_dtls_upload;
            li_param.Add(param);

            //param = new SqlParameter("@type_job_dtls_upload", SqlDbType.Structured, -1);
            //param.Value = job_dtls_upload;
            //li_param.Add(param);

            //param = new SqlParameter("@publication_dtls_upload", SqlDbType.Structured, -1);
            //param.Value = publication_dtls_upload;
            //li_param.Add(param);

            //param = new SqlParameter("@reserach_fund_upload", SqlDbType.Structured, -1);
            //param.Value = reserach_fund_upload;
            //li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@stage", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@process", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            applid = dal.oparam[1].Value.ToString();
            stage = dal.oparam[2].Value.ToString();
            process = dal.oparam[3].Value.ToString();

        }
        public void reuploaddoc()        {            dal = new DataAccess_sql();            li_param = new List<SqlParameter>();            dal.sqlcmdstr = "appl.sp_insreupload";            param = new SqlParameter("@type_tblappldocumentsupload", SqlDbType.Structured, -1);            param.Value = identification_doc_upload;            li_param.Add(param);            param = new SqlParameter("@education_dtls_upload", SqlDbType.Structured, -1);            param.Value = education_dtls_upload;            li_param.Add(param);            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);            param.Direction = ParameterDirection.Output;            li_param.Add(param);            dal.lparam = li_param;            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());            recordsaffected = dal.recordsaffected;            msg = dal.oparam[0].Value.ToString();        }
        public void ins_oldappldetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsoldappldetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@appl_sal", SqlDbType.VarChar, 50);
            param.Value = appl_sal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fname", SqlDbType.VarChar, 1000);
            param.Value = appl_fname;
            li_param.Add(param);

            param = new SqlParameter("@appl_mname", SqlDbType.VarChar, 1000);
            param.Value = appl_mname;
            li_param.Add(param);

            param = new SqlParameter("@appl_lname", SqlDbType.VarChar, 1000);
            param.Value = appl_lname;
            li_param.Add(param);

            param = new SqlParameter("@appl_course", SqlDbType.VarChar, 50);
            param.Value = appl_course;
            li_param.Add(param);

            param = new SqlParameter("@appl_specialization", SqlDbType.VarChar, 500);
            param.Value = appl_specialization;
            li_param.Add(param);

            param = new SqlParameter("@appl_area_of_study", SqlDbType.VarChar, 500);
            param.Value = appl_area_of_study;
            li_param.Add(param);

            param = new SqlParameter("@appl_study_type", SqlDbType.VarChar, 100);
            param.Value = appl_study_type;
            li_param.Add(param);

            param = new SqlParameter("@appl_discipline", SqlDbType.VarChar, 100);
            param.Value = appl_discipline;
            li_param.Add(param);

            param = new SqlParameter("@appl_martialsts", SqlDbType.VarChar, 20);
            param.Value = appl_martialsts;
            li_param.Add(param);

            param = new SqlParameter("@appl_gender", SqlDbType.VarChar, 20);
            param.Value = appl_gender;
            li_param.Add(param);

            param = new SqlParameter("@appl_dateofbirth", SqlDbType.Date, 10);
            param.Value = appl_dateofbirth;
            li_param.Add(param);

            param = new SqlParameter("@appl_highestquaily", SqlDbType.VarChar, 50);
            param.Value = appl_highestquaily;
            li_param.Add(param);

            param = new SqlParameter("@appl_nationality", SqlDbType.VarChar, 50);
            param.Value = appl_nationality;
            li_param.Add(param);

            param = new SqlParameter("@appl_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_alt_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_email", SqlDbType.VarChar, 100);
            param.Value = appl_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_email", SqlDbType.VarChar, 100);
            param.Value = appl_alt_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_citizenshipno", SqlDbType.VarChar, 100);
            param.Value = appl_citizenshipno;
            li_param.Add(param);

            param = new SqlParameter("@appl_passport", SqlDbType.VarChar, 100);
            param.Value = appl_passport;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@rcm", SqlDbType.DateTime, 50);
            param.Value = rcm;
            li_param.Add(param);

            param = new SqlParameter("@appl_permanentaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_permanentaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_ppincode", SqlDbType.VarChar, 50);
            param.Value = appl_ppincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_pstate", SqlDbType.VarChar, 500);
            param.Value = appl_pstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_pcountry", SqlDbType.VarChar, 50);
            param.Value = appl_pcountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_corrospondanceaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_corrospondanceaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_cpincode", SqlDbType.VarChar, 50);
            param.Value = appl_cpincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_cstate", SqlDbType.VarChar, 500);
            param.Value = appl_cstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_ccountry", SqlDbType.VarChar, 50);
            param.Value = appl_ccountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathersal", SqlDbType.VarChar, 50);
            param.Value = appl_fathersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathername", SqlDbType.VarChar, 1000);
            param.Value = appl_fathername;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_fathercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothersal", SqlDbType.VarChar, 50);
            param.Value = appl_mothersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothername", SqlDbType.VarChar, 1000);
            param.Value = appl_mothername;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_mothercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainsal", SqlDbType.VarChar, 50);
            param.Value = appl_gurdainsal;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainname", SqlDbType.VarChar, 1000);
            param.Value = appl_gurdainname;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdaincontactno", SqlDbType.VarChar, 20);
            param.Value = appl_gurdaincontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_fundingsrc", SqlDbType.VarChar, 500);
            param.Value = appl_fundingsrc;
            li_param.Add(param);

            param = new SqlParameter("@appl_research_statement", SqlDbType.VarChar, -1);
            param.Value = appl_research_statement;
            li_param.Add(param);

            param = new SqlParameter("@appl_research_requirements", SqlDbType.VarChar, -1);
            param.Value = appl_research_requirements;
            li_param.Add(param);

            param = new SqlParameter("@appl_addi_enclosures", SqlDbType.VarChar, -1);
            param.Value = appl_addi_enclosures;
            li_param.Add(param);

            param = new SqlParameter("@type_tblappldocumentsupload", SqlDbType.Structured, -1);
            param.Value = identification_doc_upload;
            li_param.Add(param);

            param = new SqlParameter("@education_dtls_upload", SqlDbType.Structured, -1);
            param.Value = education_dtls_upload;
            li_param.Add(param);

            //param = new SqlParameter("@type_job_dtls_upload", SqlDbType.Structured, -1);
            //param.Value = job_dtls_upload;
            //li_param.Add(param);

            //param = new SqlParameter("@publication_dtls_upload", SqlDbType.Structured, -1);
            //param.Value = publication_dtls_upload;
            //li_param.Add(param);

            //param = new SqlParameter("@reserach_fund_upload", SqlDbType.Structured, -1);
            //param.Value = reserach_fund_upload;
            //li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            //param = new SqlParameter("@applicationid", SqlDbType.VarChar, 1000);
            //param.Direction = ParameterDirection.Output;
            //li_param.Add(param);

            param = new SqlParameter("@stage", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@process", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            // applid = dal.oparam[1].Value.ToString();
            stage = dal.oparam[1].Value.ToString();
            process = dal.oparam[2].Value.ToString();

        }
        public void updt_applperdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtapplperdetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@appl_sal", SqlDbType.VarChar, 50);
            param.Value = appl_sal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fname", SqlDbType.VarChar, 1000);
            param.Value = appl_fname;
            li_param.Add(param);

            param = new SqlParameter("@appl_mname", SqlDbType.VarChar, 1000);
            param.Value = appl_mname;
            li_param.Add(param);

            param = new SqlParameter("@appl_lname", SqlDbType.VarChar, 1000);
            param.Value = appl_lname;
            li_param.Add(param);

            param = new SqlParameter("@appl_course", SqlDbType.VarChar, 50);
            param.Value = appl_course;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 1000);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@appl_specialization", SqlDbType.VarChar, 500);
            param.Value = appl_specialization;
            li_param.Add(param);

            param = new SqlParameter("@appl_area_of_study", SqlDbType.VarChar, 500);
            param.Value = appl_area_of_study;
            li_param.Add(param);

            param = new SqlParameter("@appl_study_type", SqlDbType.VarChar, 100);
            param.Value = appl_study_type;
            li_param.Add(param);

            param = new SqlParameter("@appl_discipline", SqlDbType.VarChar, 100);
            param.Value = appl_discipline;
            li_param.Add(param);

            param = new SqlParameter("@appl_martialsts", SqlDbType.VarChar, 20);
            param.Value = appl_martialsts;
            li_param.Add(param);

            param = new SqlParameter("@appl_gender", SqlDbType.VarChar, 20);
            param.Value = appl_gender;
            li_param.Add(param);

            param = new SqlParameter("@appl_dateofbirth", SqlDbType.Date, 10);
            param.Value = appl_dateofbirth;
            li_param.Add(param);

            param = new SqlParameter("@appl_highestquaily", SqlDbType.VarChar, 50);
            param.Value = appl_highestquaily;
            li_param.Add(param);

            param = new SqlParameter("@appl_nationality", SqlDbType.VarChar, 50);
            param.Value = appl_nationality;
            li_param.Add(param);

            param = new SqlParameter("@appl_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_personalcontact", SqlDbType.VarChar, 20);
            param.Value = appl_alt_personalcontact;
            li_param.Add(param);

            param = new SqlParameter("@appl_email", SqlDbType.VarChar, 100);
            param.Value = appl_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_alt_email", SqlDbType.VarChar, 100);
            param.Value = appl_alt_email;
            li_param.Add(param);

            param = new SqlParameter("@appl_citizenshipno", SqlDbType.VarChar, 100);
            param.Value = appl_citizenshipno;
            li_param.Add(param);

            param = new SqlParameter("@appl_passport", SqlDbType.VarChar, 100);
            param.Value = appl_passport;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);
            
            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void uploadprofilepicture()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_uploadprofilepicture";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@appl_fileupload", SqlDbType.VarChar, 500);
            param.Value = appl_fileupload;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

        }

        public DataTable vwprofilepicbystdid(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select doc. * from appl.tblappldocumentsupload doc inner join appl.vw_appl appl on doc.frmmodtransid=appl.transid where doc.appl_docid='020A2B70-BED2-4645-B43F-4B6CA3D7F160' and appl.stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 100);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public void updt_applcommdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtapplcommdetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);
            
            param = new SqlParameter("@appl_permanentaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_permanentaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_ppincode", SqlDbType.VarChar, 50);
            param.Value = appl_ppincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_pstate", SqlDbType.VarChar, 500);
            param.Value = appl_pstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_pcountry", SqlDbType.VarChar, 50);
            param.Value = appl_pcountry;
            li_param.Add(param);

            param = new SqlParameter("@appl_corrospondanceaddress", SqlDbType.VarChar, 1000);
            param.Value = appl_corrospondanceaddress;
            li_param.Add(param);

            param = new SqlParameter("@appl_cpincode", SqlDbType.VarChar, 50);
            param.Value = appl_cpincode;
            li_param.Add(param);

            param = new SqlParameter("@appl_cstate", SqlDbType.VarChar, 500);
            param.Value = appl_cstate;
            li_param.Add(param);

            param = new SqlParameter("@appl_ccountry", SqlDbType.VarChar, 50);
            param.Value = appl_ccountry;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

           
            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void updt_applfamilydetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtapplfamilydetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathersal", SqlDbType.VarChar, 50);
            param.Value = appl_fathersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathername", SqlDbType.VarChar, 1000);
            param.Value = appl_fathername;
            li_param.Add(param);

            param = new SqlParameter("@appl_fathercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_fathercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothersal", SqlDbType.VarChar, 50);
            param.Value = appl_mothersal;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothername", SqlDbType.VarChar, 1000);
            param.Value = appl_mothername;
            li_param.Add(param);

            param = new SqlParameter("@appl_mothercontactno", SqlDbType.VarChar, 20);
            param.Value = appl_mothercontactno;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainsal", SqlDbType.VarChar, 50);
            param.Value = appl_gurdainsal;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdainname", SqlDbType.VarChar, 1000);
            param.Value = appl_gurdainname;
            li_param.Add(param);

            param = new SqlParameter("@appl_gurdaincontactno", SqlDbType.VarChar, 20);
            param.Value = appl_gurdaincontactno;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);
            
            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void updt_docsbmtdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[sp_updtappldocs]";

            param = new SqlParameter("@type_tblappldocumentsupload", SqlDbType.Structured, -1);
            param.Value = identification_doc_upload;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void updt_educationdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[sp_updtappledudocs]";

            param = new SqlParameter("@education_dtls_upload", SqlDbType.Structured, -1);
            param.Value = education_dtls_upload;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void ins_applcomments()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinscomments]";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@comments", SqlDbType.VarChar, -1);
            param.Value = comments;
            li_param.Add(param);

            param = new SqlParameter("@fileattachid", SqlDbType.VarChar, 50);
            param.Value = fileattachid;
            li_param.Add(param);

            param = new SqlParameter("@security_lvl", SqlDbType.Int, 4);
            param.Value = security_lvl;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);
            
            param = new SqlParameter("@type_tblfileattach", SqlDbType.Structured, -1);
            param.Value = type_tblfileattach;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void deldocument()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spdeldoc]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

      
        public void deledudtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spdeledu]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void insdocument()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsdoc]";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@appl_docid", SqlDbType.VarChar, 50);
            param.Value = appl_docid;
            li_param.Add(param);

            param = new SqlParameter("@appl_fileupload", SqlDbType.VarChar, 100);
            param.Value = appl_fileupload;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void densapproval()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spdensapproval]";

            param = new SqlParameter("@appl_cat", SqlDbType.VarChar, 10);
            param.Value = appl_cat;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@applstage", SqlDbType.VarChar, 50);
            param.Value = stage;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void insappllog()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsappllog]";

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@applstage", SqlDbType.VarChar, 50);
            param.Value = stage;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;



        }

        public void insofferletter()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spofferletter]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@min_crsduration", SqlDbType.VarChar, 50);
            param.Value = min_duration;
            li_param.Add(param);

            param = new SqlParameter("@max_crsduration", SqlDbType.VarChar, 50);
            param.Value = max_duration;
            li_param.Add(param);

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 10);
            param.Value = appl_intake;
            li_param.Add(param);

            param = new SqlParameter("@deptsname", SqlDbType.VarChar, 50);
            param.Value = deptsname;
            li_param.Add(param);

            param = new SqlParameter("@totalfees", SqlDbType.Money, 50);
            param.Value = totalfees;
            li_param.Add(param);

            param = new SqlParameter("@scholarshipfees", SqlDbType.Money, 50);
            param.Value = scholarshipfees;
            li_param.Add(param);

            param = new SqlParameter("@offerltrgendt", SqlDbType.Date, 10);
            param.Value = offerltrgendt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@bnk", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@type_tblfeesconfig", SqlDbType.Structured, -1);
            param.Value = type_tblfeesdlts;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@offerltrnum", SqlDbType.VarChar, 100);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            offerltrnum= dal.oparam[1].Value.ToString();

        }

        public void insfeesupdate()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtfeesgen]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@min_crsduration", SqlDbType.VarChar, 50);
            param.Value = min_duration;
            li_param.Add(param);

            param = new SqlParameter("@max_crsduration", SqlDbType.VarChar, 50);
            param.Value = max_duration;
            li_param.Add(param);

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 10);
            param.Value = appl_intake;
            li_param.Add(param);

            param = new SqlParameter("@totalfees", SqlDbType.Money, 50);
            param.Value = totalfees;
            li_param.Add(param);

            param = new SqlParameter("@scholarshipfees", SqlDbType.Money, 50);
            param.Value = scholarshipfees;
            li_param.Add(param);

            param = new SqlParameter("@offerltrgendt", SqlDbType.Date, 10);
            param.Value = offerltrgendt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@bnk", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@type_tblfeesconfig", SqlDbType.Structured, -1);
            param.Value = type_tblfeesdlts;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            //  offerltrnum = dal.oparam[1].Value.ToString();

        }

        public void insfeesupdate_collaborative()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtfeesgen_collaboration]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@min_crsduration", SqlDbType.VarChar, 50);
            param.Value = min_duration;
            li_param.Add(param);

            param = new SqlParameter("@max_crsduration", SqlDbType.VarChar, 50);
            param.Value = max_duration;
            li_param.Add(param);

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 10);
            param.Value = appl_intake;
            li_param.Add(param);

            param = new SqlParameter("@totalfees", SqlDbType.Money, 50);
            param.Value = totalfees;
            li_param.Add(param);

            param = new SqlParameter("@scholarshipfees", SqlDbType.Money, 50);
            param.Value = scholarshipfees;
            li_param.Add(param);

            param = new SqlParameter("@offerltrgendt", SqlDbType.Date, 10);
            param.Value = offerltrgendt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@bnk", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@type_tblfeesconfig", SqlDbType.Structured, -1);
            param.Value = type_tblfeesdlts;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            // offerltrnum = dal.oparam[1].Value.ToString();

        }

        public void insfeesupdate_agent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtfeesgen_agent]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@min_crsduration", SqlDbType.VarChar, 50);
            param.Value = min_duration;
            li_param.Add(param);

            param = new SqlParameter("@max_crsduration", SqlDbType.VarChar, 50);
            param.Value = max_duration;
            li_param.Add(param);

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 10);
            param.Value = appl_intake;
            li_param.Add(param);

            param = new SqlParameter("@totalfees", SqlDbType.Money, 50);
            param.Value = totalfees;
            li_param.Add(param);

            param = new SqlParameter("@scholarshipfees", SqlDbType.Money, 50);
            param.Value = scholarshipfees;
            li_param.Add(param);

            param = new SqlParameter("@offerltrgendt", SqlDbType.Date, 10);
            param.Value = offerltrgendt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@bnk", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@type_tblfeesconfig", SqlDbType.Structured, -1);
            param.Value = type_tblfeesdlts;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            //  offerltrnum = dal.oparam[1].Value.ToString();

        }
        public void insofferletter_collaboration()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spofferletter_collaboration]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@min_crsduration", SqlDbType.VarChar, 50);
            param.Value = min_duration;
            li_param.Add(param);

            param = new SqlParameter("@max_crsduration", SqlDbType.VarChar, 50);
            param.Value = max_duration;
            li_param.Add(param);

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 10);
            param.Value = appl_intake;
            li_param.Add(param);

            param = new SqlParameter("@deptsname", SqlDbType.VarChar, 50);
            param.Value = deptsname;
            li_param.Add(param);

            param = new SqlParameter("@totalfees", SqlDbType.Money, 50);
            param.Value = totalfees;
            li_param.Add(param);

            param = new SqlParameter("@scholarshipfees", SqlDbType.Money, 50);
            param.Value = scholarshipfees;
            li_param.Add(param);

            param = new SqlParameter("@offerltrgendt", SqlDbType.Date, 10);
            param.Value = offerltrgendt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@bnk", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@type_tblfeesconfig", SqlDbType.Structured, -1);
            param.Value = type_tblfeesdlts;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@offerltrnum", SqlDbType.VarChar, 100);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            offerltrnum = dal.oparam[1].Value.ToString();

        }

        public void insofferletter_agent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spofferletter_agent]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@min_crsduration", SqlDbType.VarChar, 50);
            param.Value = min_duration;
            li_param.Add(param);

            param = new SqlParameter("@max_crsduration", SqlDbType.VarChar, 50);
            param.Value = max_duration;
            li_param.Add(param);

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 10);
            param.Value = appl_intake;
            li_param.Add(param);

            param = new SqlParameter("@deptsname", SqlDbType.VarChar, 50);
            param.Value = deptsname;
            li_param.Add(param);

            param = new SqlParameter("@totalfees", SqlDbType.Money, 50);
            param.Value = totalfees;
            li_param.Add(param);

            param = new SqlParameter("@scholarshipfees", SqlDbType.Money, 50);
            param.Value = scholarshipfees;
            li_param.Add(param);

            param = new SqlParameter("@offerltrgendt", SqlDbType.Date, 10);
            param.Value = offerltrgendt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@bnk", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@type_tblfeesconfig", SqlDbType.Structured, -1);
            param.Value = type_tblfeesdlts;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@offerltrnum", SqlDbType.VarChar, 100);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            offerltrnum = dal.oparam[1].Value.ToString();

        }

        private decimal _amount;
        private string _type;
        public decimal amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        public void updatefeesdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spupdtfeesamt";

            param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 50);
            param.Value = id;
            li_param.Add(param);

            param = new SqlParameter("@amount", SqlDbType.Money, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param.Value = type;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        private Guid _invoiceid;
        private string _invoicenum;
        public Guid invoiceid
        {
            set { _invoiceid = value; }
            get { return _invoiceid; }
        }
        public string invoicenum
        {
            set { _invoicenum = value; }
            get { return _invoicenum; }
        }


        public void ins_collaborativepartnerinvoice()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.tblcollaborativepartnerinvoice";

            param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 50);
            param.Value = invoiceid;
            li_param.Add(param);

            param = new SqlParameter("@invoicenum", SqlDbType.VarChar, 50);
            param.Value = invoicenum;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@rcm", SqlDbType.DateTime, 50);
            param.Value = rcm;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            // msg = dal.oparam[0].Value.ToString();
            //  offerltrnum = dal.oparam[1].Value.ToString();

        }
        
        public DataTable vwbankdtls()
        {
            dal = new DataAccess_sql();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from [appl].[tblbankdetails] where del_sts='0'";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        public DataTable vwbankname()
        {
            dal = new DataAccess_sql();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select transid,bankname+' '+accnum  as 'bankname',depositacc from [appl].[tblbankdetails] where del_sts='0'";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        public DataTable vwbankdtls(string depositacc)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr += "Select * from [appl].[tblbankdetails] where del_sts='0' and depositacc= @depositacc";


            param = new SqlParameter("@depositacc", SqlDbType.VarChar, 100);
            param.Value = depositacc;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_feesdtlsbyrco(string rco, string currency)
        {
            dal = new DataAccess_sql();
            mdt = new DataTable();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select appl.transid,appl.applicationid,appl.appl_name,fees.feestype,fees.amount,fees.verified_sts,fees.transid as 'feesid',";
            dal.sqlcmdstr += " countrys.currency as 'currency_name',feestype.feestype_name,course.coursename,appl.appl_intake,";
            dal.sqlcmdstr += " fees.amount,fees.del_sts,Convert(int,1) as 'unit',convert(varchar(20),(fees.amount*1)) as total from appl.vw_appl appl";
            dal.sqlcmdstr += " inner join [appl].[tblfeesconfig_collaboration] fees on appl.transid=fees.applid";
            dal.sqlcmdstr += " inner join master.tblcountrymast countrys on fees.Currency=countrys.transid";
            dal.sqlcmdstr += " inner join [master].[tblfeestypemast] feestype on fees.feestype=feestype.transid";
            dal.sqlcmdstr += " inner join [dbo].[tblcoursemast] course on appl.appl_course=course.courseid ";
            dal.sqlcmdstr += " where appl.rco=@rco and countrys.currency=@currency and (fees.verified_sts is null or fees.verified_sts='3')";
            dal.sqlcmdstr += " and fees.del_sts=0 order by appl.appl_name asc";


            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        public DataTable vw_feesdtlsbyrco(List<string> feesid)
        {
            dal = new DataAccess_sql();
            mdt = new DataTable();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = " select appl.transid,appl.applicationid,appl.appl_name,fees.feestype,fees.amount,fees.verified_sts,fees.transid as 'feesid',";
            dal.sqlcmdstr += " countrys.currency as 'currency_name',feestype.feestype_name,course.coursename,appl.appl_intake,";
            dal.sqlcmdstr += " fees.amount,fees.del_sts,Convert(int,1) as 'unit',convert(varchar(20),(fees.amount*1)) as total from appl.vw_appl appl";
            dal.sqlcmdstr += " inner join [appl].[tblfeesconfig_collaboration] fees on appl.transid=fees.applid";
            dal.sqlcmdstr += " inner join master.tblcountrymast countrys on fees.Currency=countrys.transid";
            dal.sqlcmdstr += " inner join [master].[tblfeestypemast] feestype on fees.feestype=feestype.transid";
            dal.sqlcmdstr += " inner join [dbo].[tblcoursemast] course on appl.appl_course=course.courseid ";
            dal.sqlcmdstr += " where fees.transid in (";
            foreach (var id in feesid)
                dal.sqlcmdstr += "'" + id + "'" + ",";
            dal.sqlcmdstr = dal.sqlcmdstr.Substring(0, dal.sqlcmdstr.Length - 1);

            dal.sqlcmdstr += ")";
            dal.sqlcmdstr += " and fees.del_sts=0 order by appl.appl_name asc";


            //int index = 0;
            //foreach (var id in feesid)
            //{

            // var paramname = "@feesid" + index;
            //param = new SqlParameter(paramname, SqlDbType.VarChar, 50);
            //param.Value = id;
            //li_param.Add(param);
            // index++;
            //}


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
        public DataTable vw_currencybyrco(string rco)
        {
            dal = new DataAccess_sql();
            mdt = new DataTable();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select appl.rco,count(fees.applid) as Students,country.currency from appl.vw_appl appl ";
            dal.sqlcmdstr += " inner join appl.tblfeesconfig_collaboration fees on appl.transid=fees.applid";
            dal.sqlcmdstr += " inner join master.tblcountrymast country on fees.Currency=country.transid";
            dal.sqlcmdstr += " where appl.rco=@rco and (fees.verified_sts is null or fees.verified_sts='3') group by country.currency,appl.rco";

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);



            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        private string _locationid;
        private string _tax_no;
        private string _invoice_no;
        private DateTime _invoice_gendt;
        private string _ref_no;
        public string locationid
        {
            set { _locationid = value; }
            get { return _locationid; }
        }
        public string tax_no
        {
            set { _tax_no = value; }
            get { return _tax_no; }
        }
        public string invoice_no
        {
            set { _invoice_no = value; }
            get { return _invoice_no; }
        }
        public DateTime invoice_gendt
        {
            set { _invoice_gendt = value; }
            get { return _invoice_gendt; }
        }
        public string ref_no
        {
            set { _ref_no = value; }
            get { return _ref_no; }
        }
        public void insinvoice()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_inspartnerinvoice";

            param = new SqlParameter("@locationid", SqlDbType.VarChar, 100);
            param.Value = locationid;
            li_param.Add(param);

            param = new SqlParameter("@tax_no", SqlDbType.VarChar, 100);
            param.Value = tax_no;
            li_param.Add(param);

            param = new SqlParameter("@ref_no", SqlDbType.VarChar, 100);
            param.Value = ref_no;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 100);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@vw_invoice", SqlDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            invoice_no = dal.oparam[1].Value.ToString();

        }


        public string _tabletype;

        public string tabletype
        {
            set { _tabletype = value; }
            get { return _tabletype; }
        }

        public void ins_stdreg()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spstdreg]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@bankname", SqlDbType.VarChar, 50);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@amount", SqlDbType.Decimal, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);
            param = new SqlParameter("@regdate", SqlDbType.Date, 10);
            param.Value = regdate;
            li_param.Add(param);

            param = new SqlParameter("@reserach_field", SqlDbType.VarChar, 1000);
            param.Value = reserach_field;
            li_param.Add(param);

            param = new SqlParameter("@thesissbmtminperiod", SqlDbType.VarChar, 50);
            param.Value = thesissbmtminperiod;
            li_param.Add(param);

            param = new SqlParameter("@thesissbmtmaxperiod", SqlDbType.VarChar, 50);
            param.Value = thesissbmtmaxperiod;
            li_param.Add(param);

            param = new SqlParameter("@type_tblappldocumentsupload", SqlDbType.Structured, -1);
            param.Value = identification_doc_upload;
            li_param.Add(param);

            param = new SqlParameter("@tabletype", SqlDbType.VarChar, 100);
            param.Value = tabletype;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);
            
            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
            stdid= dal.oparam[1].Value.ToString();

        }

        public void ins_spconfadmltr()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spconfadmltr]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@regdate", SqlDbType.Date, 10);
            param.Value = regdate;
            li_param.Add(param);

            param = new SqlParameter("@reserach_field", SqlDbType.VarChar, 1000);
            param.Value = reserach_field;
            li_param.Add(param);

            param = new SqlParameter("@thesissbmtminperiod", SqlDbType.VarChar, 50);
            param.Value = thesissbmtminperiod;
            li_param.Add(param);

            param = new SqlParameter("@thesissbmtmaxperiod", SqlDbType.VarChar, 50);
            param.Value = thesissbmtmaxperiod;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;


        }

        public void bankslipupld()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spbankslipupld]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@bankslip_url", SqlDbType.VarChar, 1000);
            param.Value = bankslip_url;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();
        }

        public void bankslipupld_agent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spbankslipupld_agent";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@bankslip_url", SqlDbType.VarChar, 1000);
            param.Value = bankslip_url;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();
        }

        public void bankslipupld_partner()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spbankslipupld_partner";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@bankslip_url", SqlDbType.VarChar, 1000);
            param.Value = bankslip_url;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();
        }
        public void bankslipverify()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spbankslipverify]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@feestype", SqlDbType.VarChar, 50);
            param.Value = feestype;
            li_param.Add(param);

            param = new SqlParameter("@bankname", SqlDbType.VarChar, 100);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@amount", SqlDbType.Decimal, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);

            param = new SqlParameter("@receipt_url", SqlDbType.VarChar, 1000);
            param.Value = receipt_url;
            li_param.Add(param);

            param = new SqlParameter("@remarks", SqlDbType.VarChar, 1000);
            param.Value = remarks;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }

        public void bankslipverify_agent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spbankslipverify_agent";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@feestype", SqlDbType.VarChar, 50);
            param.Value = feestype;
            li_param.Add(param);

            param = new SqlParameter("@bankname", SqlDbType.VarChar, 100);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@amount", SqlDbType.Decimal, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);

            param = new SqlParameter("@receipt_url", SqlDbType.VarChar, 1000);
            param.Value = receipt_url;
            li_param.Add(param);

            param = new SqlParameter("@remarks", SqlDbType.VarChar, 1000);
            param.Value = remarks;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }

        public void bankslipverify_partner()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spbankslipverify_partner";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@feestype", SqlDbType.VarChar, 50);
            param.Value = feestype;
            li_param.Add(param);

            param = new SqlParameter("@bankname", SqlDbType.VarChar, 100);
            param.Value = bnk;
            li_param.Add(param);

            param = new SqlParameter("@amount", SqlDbType.Decimal, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);

            param = new SqlParameter("@receipt_url", SqlDbType.VarChar, 1000);
            param.Value = receipt_url;
            li_param.Add(param);

            param = new SqlParameter("@remarks", SqlDbType.VarChar, 1000);
            param.Value = remarks;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }
        public void passchgehash()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[system].[sppasschgehash]";

            param = new SqlParameter("@userid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@hashid", SqlDbType.VarChar, 50);
            param.Value = hashid;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

        }

        public void insagtcommision()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsagtcommision]";

            param = new SqlParameter("@appl_id", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@amnt", SqlDbType.Money, 10);
            param.Value = amnt;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@paydt", SqlDbType.Date, 10);
            param.Value = paydt;
            li_param.Add(param);

            param = new SqlParameter("@commdesc", SqlDbType.VarChar, 1000);
            param.Value = commdesc;
            li_param.Add(param);

            param = new SqlParameter("@pay_doc", SqlDbType.VarChar, 1000);
            param.Value = pay_doc;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;


        }

        public void delagtcommision()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spdelagtcommision]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);
            
            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
        }

        public void ins_agtcommesionamnt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_insagentcommesion";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@agt_commission", SqlDbType.Decimal, 50);
            param.Value = agt_commission;
            li_param.Add(param);

            param = new SqlParameter("@agt_commission_currency", SqlDbType.VarChar, 50);
            param.Value = agt_commission_currency;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);


            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }

        public DataTable vwstdpayment_collaborative(string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr += "Select appl.*,currency.currency as 'currency_name',fees.* from appl.vw_appl appl inner join appl.tblfeesconfig_collaboration fees on appl.transid = fees.applid inner join [master].[tblcountrymast] currency on currency.transid=fees.Currency where fees.verified_sts is null and appl.rco = @rco order by duedt desc ";

            dal.sqlcmdstr += "Select appl.*,currency.currency as 'currency_name',fees.*,feesmast.feestype_name from appl.vw_appl appl inner join";
            dal.sqlcmdstr += " appl.tblfeesconfig_collaboration fees on appl.transid = fees.applid inner join";
            dal.sqlcmdstr += " [master].[tblfeestypemast] feesmast on feesmast.transid=fees.feestype inner join";
            dal.sqlcmdstr += " [master].[tblcountrymast] currency on currency.transid=fees.Currency where fees.verified_sts is null";
            dal.sqlcmdstr += " and appl.rco = @rco and fees.duedt <= Getdate()-7 ";


            param = new SqlParameter("@rco", SqlDbType.VarChar, 100);
            param.Value = rco;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public void spvrallocation()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsspvrallocation]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);

            param = new SqlParameter("@spvrtype", SqlDbType.VarChar, 50);
            param.Value = spvrtype;
            li_param.Add(param);

            param = new SqlParameter("@comments", SqlDbType.VarChar, 50);
            param.Value = comments;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            //param = new SqlParameter("@spvrfees", SqlDbType.Structured, -1);
            //param.Value = mdt;
            //li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@deptsname", SqlDbType.VarChar, 50);
            param.Value = deptsname;
            li_param.Add(param);

            param = new SqlParameter("@offerltrnum", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@allot_date", SqlDbType.Date);
            param.Value = allotdate;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            offerltrnum = dal.oparam[1].Value.ToString();
            recordsaffected = dal.recordsaffected;


        }


        public void spvrpayment()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spinspvrtotalpayment";


            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);

            param = new SqlParameter("@totalpayment", SqlDbType.Money, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;
        }

        private string _paymentslip;
        public string paymentslip
        {
            set { _paymentslip = value; }
            get { return _paymentslip; }
        }

        public void spvrpaymentslip()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.insspvrpaymentslip";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@paymentslip", SqlDbType.VarChar, 50);
            param.Value = paymentslip;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
        }
        public void spvrsplitpayment()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spinspvrpayment";


            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@totalpayment", SqlDbType.Money, 50);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@currency", SqlDbType.VarChar, 50);
            param.Value = currency;
            li_param.Add(param);

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;
        }

        public void spvrdeallocation()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtspvrdeallocation]";


            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;


        }

        public void spvrfeesdtlsupload()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinsspvrfeesdtls]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@pay_comment", SqlDbType.VarChar, 5000);
            param.Value = comments;
            li_param.Add(param);

            param = new SqlParameter("@pay_rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@pay_url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);
            
            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
            
        }

        public void spinsrdformsbmt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spstdrdformsbmt]";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            
        }

        private string _spvrsts;
        private string _spvrfeed;
        private string _spvrfeedurl;
        private string _spvrrco;
        public string spvrsts
        {
            set { _spvrsts = value; }
            get { return _spvrsts; }
        }
        public string spvrfeed
        {
            set { _spvrfeed = value; }
            get { return _spvrfeed; }
        }
        public string spvrfeedurl
        {
            set { _spvrfeedurl = value; }
            get { return _spvrfeedurl; }
        }
        public string spvrrco
        {
            set { _spvrrco = value; }
            get { return _spvrrco; }
        }



        public void spspvrrdformfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spspvrrdformfdbck]";
            
            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@spvrsts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@spvrrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        public void spcpgsrdformfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spcpgsrdformfdbck]";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@spvrsts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@spvrrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        private string _subject;
        private string _body;
         private string _queryto;

        private string _partnerid;

        public string partnerid
        {
            set { _partnerid = value; }
            get { return _partnerid; }
        }
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        public string body
        {
            set { _body = value; }
            get { return _body; }
        }

        public string queryto
        {
            set { _queryto = value; }
            get { return _queryto; }
        }

        public void spinsservlog()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sptblstdsrvreq";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@subject", SqlDbType.VarChar, 1000);
            param.Value = subject;
            li_param.Add(param);

            param = new SqlParameter("@body", SqlDbType.VarChar, 1000);
            param.Value = body;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@queryto", SqlDbType.VarChar, 1000);
            param.Value = queryto;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
        }

        public void spinsservlog_partner()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sptblstdsrvreq_partner";

            param = new SqlParameter("@partnerid", SqlDbType.VarChar, 50);
            param.Value = partnerid;
            li_param.Add(param);

            param = new SqlParameter("@subject", SqlDbType.VarChar, 1000);
            param.Value = subject;
            li_param.Add(param);

            param = new SqlParameter("@body", SqlDbType.VarChar, 1000);
            param.Value = body;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@queryto", SqlDbType.VarChar, 1000);
            param.Value = queryto;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
        }
        public void spinssercommentvlog()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "sp_inscommentlog";

            param = new SqlParameter("@subjectid", SqlDbType.UniqueIdentifier, 50);
            param.Value = frmmodtrans_id;
            li_param.Add(param);

            param = new SqlParameter("@body", SqlDbType.VarChar, 1000);
            param.Value = body;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@securitylvl", SqlDbType.Int);
            param.Value = security_lvl;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
        }

        public void spinssercommentvlog_partner()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "sp_inscommentlog_partner";

            param = new SqlParameter("@subjectid", SqlDbType.UniqueIdentifier, 50);
            param.Value = frmmodtrans_id;
            li_param.Add(param);

            param = new SqlParameter("@body", SqlDbType.VarChar, 1000);
            param.Value = body;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@securitylvl", SqlDbType.Int);
            param.Value = security_lvl;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;
        }
        public DataTable vwsrvcbyid(string id)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select * from [appl].[tblstdsrvreq] where stdid = @id order by rcm desc";
            dal.sqlcmdstr += "select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-block btn-default'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-block btn-success'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-block btn-danger'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-block btn-warning'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [appl].[tblstdsrvreq] where";
            dal.sqlcmdstr += " stdid=@id";
            dal.sqlcmdstr += " order by rcm desc";


            param = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param.Value = id;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwsrvcbyid(string id, string queryto)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select * from [appl].[tblstdsrvreq] where stdid = @id order by rcm desc";
            dal.sqlcmdstr += "select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-block btn-default'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-block btn-success'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-block btn-danger'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-block btn-warning'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [appl].[tblstdsrvreq] where";
            dal.sqlcmdstr += " queryto=@queryto and stdid=@id";
            dal.sqlcmdstr += " order by rcm desc";


            param = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param.Value = id;
            li_param.Add(param);

            param = new SqlParameter("@queryto", SqlDbType.VarChar, 50);
            param.Value = queryto;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwsrvcbyid_partner(string id)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            
            dal.sqlcmdstr += "select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-block btn-default'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-block btn-success'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-block btn-danger'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-block btn-warning'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [appl].[tblstdsrvreq_partner] where";
            dal.sqlcmdstr += " partnerid=@id";
            dal.sqlcmdstr += " order by rcm desc";


            param = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param.Value = id;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

     
        public string resolve_notresoved(string transid, int sts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select * from [appl].[tblstdsrvreq] where stdid = @id order by rcm desc";
            dal.sqlcmdstr = "update [appl].[tblstdsrvreq] set sts=@sts where transid=@transid";



            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@sts", SqlDbType.Int);
            param.Value = security_lvl;
            li_param.Add(param);



            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
                return "Your Service Request status has been changed";
            else
                return "There have some issue we can't proceed with your request";

        }

        public string resolve_notresoved_partner(string transid, int sts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select * from [appl].[tblstdsrvreq] where stdid = @id order by rcm desc";
            dal.sqlcmdstr = "update [appl].[tblstdsrvreq_partner] set sts=@sts where transid=@transid";



            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@sts", SqlDbType.Int);
            param.Value = security_lvl;
            li_param.Add(param);



            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            if (recordsaffected > 0)
                return "Your Service Request status has been changed";
            else
                return "There have some issue we can't proceed with your request";

        }
        public DataTable vwsrvcdtls(string id)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            dal.sqlcmdstr = "select * from [appl].[tblstdsrvreq] where transid = @id order by rcm desc";
            param = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param.Value = id;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwsrvcdtls_partner(string id)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            dal.sqlcmdstr = "select * from [appl].[tblstdsrvreq_partner] where transid = @id order by rcm desc";
            param = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param.Value = id;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable servicedtls(string subjectid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog] where subjectid = @subject";

            param = new SqlParameter("@subject", SqlDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable servicedtls_partner(string subjectid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog_partner] where subjectid = @subject";

            param = new SqlParameter("@subject", SqlDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwsrvcdtlslog(string subjectid, Int32 security_lvl)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (security_lvl == 0)
            {
                // dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog] where subjectid = @subject and security_lvl = @security_lvl order by rcm desc";
                dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog] where subjectid = @subject order by rcm desc";
            }
            else
            {
                dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog] where subjectid = @subject order by rcm desc";
            }
            param = new SqlParameter("@subject", SqlDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            param = new SqlParameter("@security_lvl", SqlDbType.Int, 4);
            param.Value = security_lvl;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwsrvcdtlslog_partner(string subjectid, Int32 security_lvl)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (security_lvl == 0)
            {
                // dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog] where subjectid = @subject and security_lvl = @security_lvl order by rcm desc";
                dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog_partner] where subjectid = @subject order by rcm desc";
            }
            else
            {
                dal.sqlcmdstr = "select * from [appl].[tblstdsrvlog_partner] where subjectid = @subject order by rcm desc";
            }
            param = new SqlParameter("@subject", SqlDbType.VarChar, 50);
            param.Value = subjectid;
            li_param.Add(param);

            param = new SqlParameter("@security_lvl", SqlDbType.Int, 4);
            param.Value = security_lvl;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public void inst_stdarticleupld()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "student.sp_instblstdarticleupld";
            
            param = new SqlParameter("@tblarticle", SqlDbType.Structured, -1);
            param.Value = article_dtls;
            li_param.Add(param);
            
            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();
        }

        public void del_stdarticle()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            dal.sqlcmdstr = "appl.sp_delarticles";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 100);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 100);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;


            msg = dal.oparam[0].Value.ToString();

        }
        public void del_conferenceupload()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            dal.sqlcmdstr = "appl.sp_delstdconferenceupload";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 100);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 100);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;


            msg = dal.oparam[0].Value.ToString();

        }
        public void ins_stdconferenceupld()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[student].[sp_instblstdconferenceupld]";
            
            param = new SqlParameter("@tblconf", SqlDbType.Structured, -1);
            param.Value = stdcnf_dtls;
            li_param.Add(param);
            
            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
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

        public DataTable vwstdconferencelog(string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select mast.*,cmast.country_name from student.tblstdconferenceupld mast left outer join master.tblcountrymast cmast on mast.country =  convert(nvarchar(50),cmast.transid) where mast.rco=@rco and mast.del_sts='0' order by mast.rcm desc";
            
            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwarticleformslog(string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from student.tblstdarticleupld where rco=@rco and del_sts='0' order by rcm desc";

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwspvrallotstd(string applid, string spvrtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select top 1 vw_supervisor.*,spvr.* from appl.tblspvrallocation spvr inner join appl.vw_supervisor vw_supervisor on spvr.spvrid=vw_supervisor.transid and spvr.spvrtype=@spvrtype and spvr.applid=@applid and spvr.del_sts is null";

            param = new SqlParameter("@spvrtype", SqlDbType.VarChar, 50);
            param.Value = spvrtype;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwspvrallotlist(string spvrid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select appl.*,spvr.* from appl.vw_appl appl inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid) order by spvr.rcm";
            //Shubankar 29/05/2020
            dal.sqlcmdstr = "select appl.*,spvr.*,course.coursename from appl.vw_appl appl inner join tblcoursemast course on appl.appl_course=course.courseid inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where (spvr.del_sts is null or spvr.del_sts=0)";
            dal.sqlcmdstr += " and (convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid)) order by spvr.rcm";

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);
            
            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwcountspvrallotlist(string spvrid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select appl.*,spvr.* from appl.vw_appl appl inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid) order by spvr.rcm";
            //Shubankar 29/05/2020
            dal.sqlcmdstr = "select appl.*,spvr.*,course.coursename from appl.vw_appl appl inner join tblcoursemast course on appl.appl_course=course.courseid inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where (spvr.del_sts is null or spvr.del_sts=0) and spvr.spvrtype='main'";
            dal.sqlcmdstr += " and (convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid)) order by spvr.rcm";

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwcospvrallotlist(string spvrid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select appl.*,spvr.* from appl.vw_appl appl inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid) order by spvr.rcm";
            //Shubankar 29/05/2020
            dal.sqlcmdstr = "select appl.*,spvr.*,course.coursename from appl.vw_appl appl inner join tblcoursemast course on appl.appl_course=course.courseid inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where (spvr.del_sts is null or spvr.del_sts=0) and spvr.spvrtype='co'";
            dal.sqlcmdstr += " and (convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid)) order by spvr.rcm";

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwspvrallo(string spvrid, string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //dal.sqlcmdstr = "select appl.*,spvr.* from appl.vw_appl appl inner join appl.tblspvrallocation spvr on appl.transid=spvr.applid where convert(varchar(50),spvr.spvrid)=@spvrid or spvr.spvrid=(select top 1 transid from appl.vw_supervisor where applicationid=@spvrid) order by spvr.rcm";

            //dal.sqlcmdstr = "Select spvrall.transid as 'alloid' from appl.tblspvrallocation spvrall inner join appl.tblsupervisorappl spvr on spvrall.spvrid=spvr.transid where spvr.applicationid=@spvrid";

            dal.sqlcmdstr = "Select spvrall.transid as 'alloid',spvrfees.*,cun.currency as 'currency_name' from appl.tblspvrallocation spvrall inner join appl.tblsupervisorappl spvr on spvrall.spvrid=spvr.transid ";
            dal.sqlcmdstr += " inner join [appl].[tblspvrfees] spvrfees on spvrfees.frmmodtransid=spvrall.transid";
            dal.sqlcmdstr += " inner join [appl].[tblappldetails] appldtls on appldtls.transid=spvrall.applid";
            dal.sqlcmdstr += " inner join [master].[tblcountrymast] cun on cun.transid=spvrfees.currency";
            dal.sqlcmdstr += " where spvr.applicationid=@spvrid and spvrall.applid=@applid";

            param = new SqlParameter("@spvrid", SqlDbType.VarChar, 50);
            param.Value = spvrid;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwagtcommission(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblcountrymast.currency currencyname,tblagtcommission.* from appl.tblagtcommission inner join master.tblcountrymast on tblagtcommission.currency=tblcountrymast.transid where appl_id=@appl_id and tblagtcommission.del_sts='0' order by tblagtcommission.rcm desc";

            param = new SqlParameter("@appl_id", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vw_agentcommission(string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select appl.appl_name,appl.applicationid,fees.amount,appl.currencyname as currency,";
            dal.sqlcmdstr += " fees.verified_rcm, (fees.amount * 70/100) as 'lucshare', (fees.amount * 30 /100) as 'partnershare' from appl.vw_appl appl inner join";
            dal.sqlcmdstr += " appl.tblfeesconfig_collaboration fees on appl.transid=fees.applid where appl.rco=@rco and fees.verified_sts=1";


            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_agentcommission(string rco, Decimal lucshare, Decimal partnershare)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select appl.appl_name,appl.applicationid,fees.amount,appl.currencyname as currency,";
            dal.sqlcmdstr += " fees.verified_rcm, (fees.amount * @lucshare/100) as 'lucshare', (fees.amount * @partnershare /100) as 'partnershare' from appl.vw_appl appl inner join";
            dal.sqlcmdstr += " appl.tblfeesconfig_collaboration fees on appl.transid=fees.applid where appl.rco=@rco and fees.verified_sts=1";


            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);



            param = new SqlParameter("@partnershare", SqlDbType.Decimal);
            param.Value = partnershare;
            li_param.Add(param);

            param = new SqlParameter("@lucshare", SqlDbType.Decimal);
            param.Value = lucshare;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwcomments(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblcomments.*,";
            dal.sqlcmdstr += " coalesce(Name_of_the_Institution COLLATE DATABASE_DEFAULT,case tblcomments.rco when 'cpgs' then 'Center of Post Graduate Studies LUC' when 'DA' then appl_name else coalesce(tblrecipients.name,tblcomments.rco) end) name";
            dal.sqlcmdstr += " from appl.tblcomments";
            dal.sqlcmdstr += " left outer join db_lincoln_offshore..tblSCDetailsofInstitution on tblcomments.rco COLLATE DATABASE_DEFAULT = tblSCDetailsofInstitution.locationid COLLATE DATABASE_DEFAULT";
            dal.sqlcmdstr += " left outer join appl.vw_appl on tblcomments.frmmoctransid = vw_appl.transid";
            dal.sqlcmdstr += " left outer join appl.tblrecipients on convert(varchar(50),tblrecipients.transid)=tblcomments.rco";
            dal.sqlcmdstr += " where tblcomments.frmmoctransid=@frmmodtransid order by rcm desc";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwcomments(string frmmodtransid, List<string> security_lvl)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblcomments.*,";
            dal.sqlcmdstr += " coalesce(Name_of_the_Institution COLLATE DATABASE_DEFAULT,case tblcomments.rco when 'cpgs' then 'Center of Post Graduate Studies LUC' when 'DA' then appl_name else coalesce(tblrecipients.name,tblcomments.rco) end) name";
            dal.sqlcmdstr += " from appl.tblcomments";
            dal.sqlcmdstr += " left outer join db_lincoln_offshore..tblSCDetailsofInstitution on tblcomments.rco COLLATE DATABASE_DEFAULT = tblSCDetailsofInstitution.locationid COLLATE DATABASE_DEFAULT";
            dal.sqlcmdstr += " left outer join appl.vw_appl on tblcomments.frmmoctransid = vw_appl.transid ";
            dal.sqlcmdstr += " left outer join appl.tblrecipients on convert(varchar(50),tblrecipients.transid)=tblcomments.rco";
            dal.sqlcmdstr += " where tblcomments.frmmoctransid=@frmmodtransid and security_lvl in (0,";
            foreach (string security in security_lvl)
                dal.sqlcmdstr += security;
            dal.sqlcmdstr += ") order by tblcomments.rcm desc";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwcommentattach(string fileattachid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.tblfileattach where frmmoctransid=@fileattachid order by rcm";

            param = new SqlParameter("@fileattachid", SqlDbType.VarChar, 50);
            param.Value = fileattachid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwall()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select distinct * from appl.vw_appl order by rcm desc";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }


        public DataTable vwallstd()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from appl.vw_appl where del_sts='0'";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable applcountmonthwise(string locatid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select month(rcm),DATENAME(MONTH,rcm)+' ('+DATENAME(YEAR,rcm)+')' month,count(rcm) applnum,count(regdate) stdnum from appl.tblappldetails where rco=@locatid group by DATENAME(MONTH,rcm),DATENAME(YEAR,rcm),month(rcm) order by month(rcm)";

            param = new SqlParameter("@locatid", SqlDbType.VarChar, 50);
            param.Value = locatid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwallcountrywisepercent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "declare @allcnt money";
            dal.sqlcmdstr += " set @allcnt = (select count(transid) from[appl].[vw_appl] where del_sts = 0)";
            dal.sqlcmdstr += " select pcountry_name, count(transid)count, convert(varchar(20), (convert(money, count(transid)) / @allcnt) * 100) + '%'[percent] from[appl].[vw_appl] group by pcountry_name";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwallstagewisepercent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "declare @allcnt money";
            dal.sqlcmdstr += " set @allcnt = (select count(transid) from[appl].[vw_appl] where del_sts = 0)";
            dal.sqlcmdstr += " select stagename,stage_num,count(transid) count,convert(varchar(20),(convert(money,count(transid))/@allcnt)*100)+'%' [percent] from [appl].[vw_appl] group by stagename,stage_num order by stage_num ";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwallcoursewisepercent()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            dal.sqlcmdstr = "declare @allcnt money";
            dal.sqlcmdstr += " set @allcnt=(select count(transid) from [appl].[vw_appl] where del_sts=0)";
            dal.sqlcmdstr += " select appl_course,'' course_name,count(transid) count,convert(varchar(20),(convert(money,count(transid))/@allcnt)*100)+'%' [percent] from [appl].[vw_appl] group by appl_course";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            mdt1 = new DataTable();
            dal.sqlcmdstr = "select courseid,coursename from tblcoursemast";
            mdt1 = dal.view(Clsutility.dbcon.dbstd.ToString());

            for(int i =0;i<mdt.Rows.Count;i++)
            {
                for (int j = 0; j < mdt1.Rows.Count; j++)
                {
                    if (mdt.Rows[i]["appl_course"].ToString() == mdt1.Rows[j]["courseid"].ToString())
                        mdt.Rows[i]["course_name"] = mdt1.Rows[j]["coursename"].ToString();
                }
            }

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwall(string stage)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where stage_num<=@stage_num order by rcm desc";

            param = new SqlParameter("@stage_num", SqlDbType.VarChar, 50);
            param.Value = stage;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwall(string stage,string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where stage_num<=@stage_num and rco=@rco order by rcm desc";

            param = new SqlParameter("@stage_num", SqlDbType.VarChar, 50);
            param.Value = stage;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_docs(string doc_grup, List<string> security_lvl,string frmmodtransid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select tblappldocumentsupload.*,tbldoctypemast.doctype,docdesc from appl.tblappldocumentsupload inner join master.tbldoctypemast on appl_docid=tbldoctypemast.transid where tblappldocumentsupload.del_sts=0 and tblappldocumentsupload.frmmodtransid=@frmmodtransid and doc_grup=@doc_grup and security_lvl in (0,";
            foreach (string security in security_lvl)
                dal.sqlcmdstr += security;
            dal.sqlcmdstr += ") order by slno";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@doc_grup", SqlDbType.VarChar, 100);
            param.Value = doc_grup;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_docs_marianclg(List<string> security_lvl, string frmmodtransid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select tblappldocumentsupload.*,tbldoctypemast.doctype,docdesc from appl.tblappldocumentsupload inner join master.tbldoctypemast on appl_docid=tbldoctypemast.transid where tblappldocumentsupload.del_sts=0 and tblappldocumentsupload.frmmodtransid=@frmmodtransid and doc_grup in('adm','entrtest') and security_lvl in (0,";
            foreach (string security in security_lvl)
                dal.sqlcmdstr += security;
            dal.sqlcmdstr += ") order by slno";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_docs(string doc_grup, string frmmodtransid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select tblappldocumentsupload.*,tbldoctypemast.doctype,docdesc from appl.tblappldocumentsupload inner join master.tbldoctypemast on appl_docid=tbldoctypemast.transid where tblappldocumentsupload.del_sts=0 and tblappldocumentsupload.frmmodtransid=@frmmodtransid and doc_grup=@doc_grup order by slno";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@doc_grup", SqlDbType.VarChar, 100);
            param.Value = doc_grup;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_docs(string frmmodtransid)
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "Select * from [appl].[tblappldocumentsupload] where frmmodtransid=@frmmodtransid and appl_docid='020A2B70-BED2-4645-B43F-4B6CA3D7F160' and del_sts='0'";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_education(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select dtls.*,level.level_name from appl.tblappleducationdtls dtls inner join master.tblacademiclevelmast level on level.transid=dtls.studylvl where frmmodtransid=@frmmodtransid and dtls.del_sts=0 order by lvl_num";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbystage(string stage)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where appl_stage = @stage order by rcm desc";

            param = new SqlParameter("@stage", SqlDbType.VarChar, 50);
            param.Value = stage;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbystage(string stage,string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where appl_stage = @stage and rco=@rco order by rcm desc";

            param = new SqlParameter("@stage", SqlDbType.VarChar, 50);
            param.Value = stage;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapplid(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where applicationid = @applid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbystdid(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where stdid = @stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 100);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbystdemail(string appl_email)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where appl_email = @appl_email";

            param = new SqlParameter("@appl_email", SqlDbType.VarChar, 100);
            param.Value = appl_email;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        // Search intake wise Start-->

        public DataTable vwbyintk(string appl_intake)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where appl_intake = @appl_intake";

            param = new SqlParameter("@appl_intake", SqlDbType.VarChar, 100);
            param.Value = appl_intake;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // Search intake wise End-->

        public DataTable vwstsbystdid(string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_stdsts(@stdid,@stdtype)";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 100);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@stdtype", SqlDbType.VarChar, 100);
            param.Value = stdtype;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstsbystdidspvr(string stdid,string feestype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr = "select * from appl.vw_stdstsbyspvr(@stdid,@feestype)";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 100);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@feestype", SqlDbType.VarChar, 100);
            param.Value = feestype;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;


            return mdt;
        }
        public DataTable vwbystdfees(char verified_sts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where transid in ";
            dal.sqlcmdstr += " (select applid from appl.tblfeesconfig where del_sts = 0 and verified_sts = @verified_sts)";

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbystdfees_agent(char verified_sts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where transid in ";
            dal.sqlcmdstr += " (select applid from [appl].[tblfeesconfig_agent] where del_sts = 0 and verified_sts = @verified_sts)";

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbystdfees_partner(char verified_sts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where transid in ";
            dal.sqlcmdstr += " (select applid from [appl].[tblfeesconfig_collaboration] where del_sts = 0 and verified_sts = @verified_sts)";

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapplbyemail(string emailid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where appl_email = @emailid";

            param = new SqlParameter("@emailid", SqlDbType.VarChar, 100);
            param.Value = emailid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbytransid(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where transid = @transid";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 100);
            param.Value = transid;
            li_param.Add(param);
            
            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapplfeesbyid(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select config.*,country.currency currencyname,currency.currency agtcurrency,tblfeestypemast.feestype_name from appl.tblfeesconfig config";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on tblfeestypemast.transid = config.feestype";
            dal.sqlcmdstr += " left outer join master.tblcountrymast currency on currency.transid = config.agt_commission_currency";
            dal.sqlcmdstr += " inner join master.tblcountrymast country on country.transid = config.Currency where config.applid = @applid and config.del_sts=0";
            
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplfeesbyid_agent(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select config.*,country.currency currencyname,currency.currency agtcurrency,tblfeestypemast.feestype_name from [appl].[tblfeesconfig_agent] config";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on tblfeestypemast.transid = config.feestype";
            dal.sqlcmdstr += " left outer join master.tblcountrymast currency on currency.transid = config.agt_commission_currency";
            dal.sqlcmdstr += " inner join master.tblcountrymast country on country.transid = config.Currency where config.applid = @applid and config.del_sts=0";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplfeesbyid_agent_commssion(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select config.*,country.currency currencyname,currency.currency agtcurrency,tblfeestypemast.feestype_name from appl.tblfeesconfig_agent config";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on tblfeestypemast.transid = config.feestype";
            dal.sqlcmdstr += " left outer join master.tblcountrymast currency on currency.transid = config.agt_commission_currency";
            dal.sqlcmdstr += " inner join master.tblcountrymast country on country.transid = config.Currency where config.transid = @applid and config.del_sts=0";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplfeesbyid_collaboration(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "select config.*,country.currency currencyname,currency.currency agtcurrency,tblfeestypemast.feestype_name from appl.tblfeesconfig_collaboration config";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on tblfeestypemast.transid = config.feestype";
            dal.sqlcmdstr += " left outer join master.tblcountrymast currency on currency.transid = config.agt_commission_currency";
            dal.sqlcmdstr += " inner join master.tblcountrymast country on country.transid = config.Currency where config.applid = @applid and config.del_sts=0";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
    
        public DataTable vwbyfeestransid(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblfeesconfig.*,tblcountrymast.currency currencyname from appl.tblfeesconfig left outer join dbhrm..tblcountrymast on convert(uniqueidentifier,countryid)=convert(uniqueidentifier,agt_commission_currency) where tblfeesconfig.transid =@transid";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 100);
            param.Value = transid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplda(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "Select * from appl.vw_appl where rco='DA' and del_sts='0' and stdid=@stdid";
            
                param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
                param.Value = stdid;
                li_param.Add(param);


                dal.lparam = li_param;
                mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

                recordsaffected = dal.recordsaffected;
            
            return mdt;
        }

        public DataTable vwbyapplagent(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            //  dal.sqlcmdstr = "Select * from appl.vw_appl where rco like'URM%' and del_sts='0' and rco not in ('URM04130') and stdid=@stdid";

            dal.sqlcmdstr = "Select agent.* from appl.tblfeesconfig_agent agent inner join appl.vw_appl appl on agent.applid=appl.transid where appl.pcountry_name not in ('China') and appl.rco not in ('URM04130') and agent.del_sts='0' and stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplsplpartner(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "Select * from appl.vw_appl where rco ='LUCSAC00016' and del_sts='0' and stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapplpartner(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "Select * from appl.vw_appl where del_sts='0' and stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplcollaborativepartner(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "Select * from appl.vw_appl where rco not in('LUCSAC00016') and rco like'LUCSAC%'  or rco like 'LC%' and del_sts='0' and stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapplfeesduebyid(string applid,string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = " select sum(amount) from appl.tblfeesconfig where ";
            dal.sqlcmdstr += " applid = @applid and del_sts=0 and (verified_sts!=1 or verified_sts is null) and transid != @transid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplfeesduebyid_agent(string applid, string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = " select sum(amount) from [appl].[tblfeesconfig_agent] where ";
            dal.sqlcmdstr += " applid = @applid and del_sts=0 and (verified_sts!=1 or verified_sts is null) and transid != @transid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplfeesduebyid_partner(string applid, string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = " select sum(amount) from [appl].[tblfeesconfig_collaboration] where ";
            dal.sqlcmdstr += " applid = @applid and del_sts=0 and (verified_sts!=1 or verified_sts is null) and transid != @transid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwbyapplpaidfeesbyid(string transid, string feestype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select config.*,country.currency currencyname,tblfeestypemast.feestype_name from appl.tblfeesconfig config";
            dal.sqlcmdstr += " inner join master.tblfeestypemast on tblfeestypemast.transid = config.feestype";
            dal.sqlcmdstr += " inner join master.tblcountrymast country on country.transid = config.Currency where config.applid = @applid and config.del_sts=0";
            dal.sqlcmdstr += " and receipt_url is not null and feestype=@feestype";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@feestype", SqlDbType.VarChar, 50);
            param.Value = feestype;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyapplpendingfeesbydays(Int32 days)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.vw_appl where transid in (select applid from appl.tblfeesconfig where DATEDIFF(day,convert(date,getdate()),duedt)<=@days)";

            param = new SqlParameter("@days", SqlDbType.Int, 4);
            param.Value = days;
            li_param.Add(param);
            
            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vw_appl_log(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblapplicationlog.*,stagename,processing from appl.tblapplicationlog";
            dal.sqlcmdstr += " inner join master.tblapplstagemast on tblapplstagemast.transid = tblapplicationlog.stage";
            dal.sqlcmdstr += " where applid = @applid order by tblapplicationlog.rcm";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwallstages()
        {
            dal = new DataAccess_sql();
            mdt = new DataTable();

            dal.sqlcmdstr = "select appl_stage,stagename,stage_num,stagename+' ('+Convert(varchar(5),count(transid))+')' ctr from appl.vw_appl group by appl_stage,stagename,stage_num order by stage_num";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwallstages(string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select appl_stage,stagename,stage_num,stagename+' ('+Convert(varchar(5),count(transid))+')' ctr from appl.vw_appl where rco = @rco group by appl_stage,stagename,stage_num order by stage_num";

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwbyspvrallotsts(string spvrallotsts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select appl_name+' ('+stdid+')' name,* from [appl].[vw_appl] where spvrallotsts=@spvrallotsts and stdid is not null";

            param = new SqlParameter("@spvrallotsts", SqlDbType.VarChar, 1);
            param.Value = spvrallotsts;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdspvrbyapplid(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //  dal.sqlcmdstr = "select tblsupervisorappl.*,tblspvrallocation.transid as allotid,spvrtype,tblspvrallocation.rcm as 'allotrcm',tblspvrallocation.rco 'allotrco' from appl.tblspvrallocation";
            //  dal.sqlcmdstr += " inner join appl.tblsupervisorappl on spvrid = tblsupervisorappl.transid where  tblspvrallocation.del_sts ='0' or tblspvrallocation.del_sts is null  and applid = @applid ";

            dal.sqlcmdstr = "select tblsupervisorappl.*,tblspvrallocation.transid as allotid,spvrtype,tblspvrallocation.rcm as 'allotrcm', spvrpayment.totalpayment,spvrpayment.transid as 'spvrpaymentid',spvrpayment.applid,spvrpayment.spvrid,spvrpayment.currency as 'currencyid',country.currency,";
            dal.sqlcmdstr += " tblspvrallocation.rco 'allotrco' from appl.tblspvrallocation inner join appl.tblsupervisorappl on spvrid = tblsupervisorappl.transid";
            dal.sqlcmdstr += " left outer join appl.spvrpayment on spvrpayment.frmmodtransid=tblspvrallocation.transid left outer join [master].[tblcountrymast] country on country.transid=spvrpayment.currency";
            dal.sqlcmdstr += " where tblspvrallocation.del_sts ='0' or tblspvrallocation.del_sts is null and tblspvrallocation.applid = @applid";


            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwspvrpayment(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select spvrpay.*,country.currency,doc.doctype from appl.spvrpayment spvrpay";
            dal.sqlcmdstr += " inner join [master].[tblcountrymast] country on spvrpay.currency=country.transid";
            dal.sqlcmdstr += " inner join master.tbldoctypemast doc on doc.transid=spvrpay.form where spvrpay.applid=@applid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwspvrfees(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

           dal.sqlcmdstr = "select tblspvrfees.*,tblcountrymast.currency currency_name from appl.tblspvrfees inner join master.tblcountrymast on tblcountrymast.transid=tblspvrfees.currency where frmmodtransid = @frmmodtransid";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwspvrsemdtls(string frmmodtransid, string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblspvrfees.*,tblcountrymast.currency currency_name from appl.tblspvrfees inner join master.tblcountrymast on tblcountrymast.transid=tblspvrfees.currency where tblspvrfees.frmmodtransid = @frmmodtransid and tblspvrfees.transid=@transid";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public void stdload(MasterPage page, string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            NSMaster.blcoursemast objcrs = new NSMaster.blcoursemast();

            dal.sqlcmdstr = "select appl.sem(stdid) semester,appl_fileupload,* from appl.vw_appl left outer join appl.tblappldocumentsupload on frmmodtransid=vw_appl.transid and appl_docid = '020A2B70-BED2-4645-B43F-4B6CA3D7F160' where stdid = @stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 100);
            param.Value = stdid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            ((Label)page.FindControl("lblstdname")).Text = mdt.Rows[0]["appl_name"].ToString();
            ((Label)page.FindControl("lblstdid")).Text = mdt.Rows[0]["stdid"].ToString();
            ((Label)page.FindControl("lblcrs")).Text = objcrs.vw_coursemastbytransiduc(mdt.Rows[0]["appl_course"].ToString()).Rows[0]["coursename"].ToString();
            ((Label)page.FindControl("lblintake")).Text = mdt.Rows[0]["appl_intake"].ToString();
            ((Label)page.FindControl("lbluserid")).Text= mdt.Rows[0]["stdid"].ToString();
            ((Label)page.FindControl("lblsem")).Text = mdt.Rows[0]["semester"].ToString();
            ((HiddenField)page.FindControl("hfvtransid")).Value = mdt.Rows[0]["transid"].ToString();
            ((Image)page.FindControl("stdimg")).ImageUrl = mdt.Rows[0]["appl_fileupload"].ToString();
            ((Label)page.FindControl("lblmobile")).Text = mdt.Rows[0]["appl_personalcontact"].ToString();
            ((Label)page.FindControl("lblemail")).Text = mdt.Rows[0]["appl_email"].ToString();
            
        }

        public DataTable vwstdforms(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (stdtype == "DA")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in ('sem1','sem2','sem3res-1st','sem4res-2nd','sem5res-3rd','sem6res-4th','sem6rd5','sem6rd6','sem6rd7') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "PARTNER")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig_collaboration where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in ('sem1','sem2','sem3res-1st','sem4res-2nd','sem5res-3rd','sem6res-4th','sem6rd5','sem6rd6','sem6rd7') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "AGENT")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig_agent where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in ('sem1','sem2','sem3res-1st','sem4res-2nd','sem5res-3rd','sem6res-4th','sem6rd5','sem6rd6','sem6rd7') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // For Sem-1
        public DataTable vwstdformssem1(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            if (stdtype == "DA")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem1' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "PARTNER")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem1' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "AGENT")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem1' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }


            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        // For Sem-2
        public DataTable vwstdformssem2(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (stdtype == "DA")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem2' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "PARTNER")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem2' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "AGENT")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem2' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        // For Sem-3
        public DataTable vwstdformssem3(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (stdtype == "DA")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem3res-1st' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "PARTNER")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem3res-1st' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "AGENT")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem3res-1st' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdresandlabsem3(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in ('recdocsem3','labdocsem3') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        // For Sem-4
        public DataTable vwstdformssem4(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (stdtype == "DA")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem4res-2nd' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "PARTNER")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem4res-2nd' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "AGENT")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem4res-2nd' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdresandlabsem4(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in ('recdocsem4','labdocsem4') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
           
            return mdt;
        }

        // For Sem-5
        public DataTable vwstdformssem5(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (stdtype == "DA")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem5res-3rd' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "PARTNER")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem5res-3rd' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            else if (stdtype == "AGENT")
            {
                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup = 'sem5res-3rd' and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%')  order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdresandlabsem5(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in ('recdocsem5','labdocsem5') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // For Sem-6
        public DataTable vwstdformssem6(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (stdtype == "DA")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6res-4th') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "PARTNER")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6res-4th') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "AGENT")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6res-4th') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdformssem6res(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in('sem6') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwstdresandlabsem6(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (stdtype == "DA")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd5') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "PARTNER")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd5') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "AGENT")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd5') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdrptsem6rd6(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (stdtype == "DA")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd6') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "PARTNER")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd6') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "AGENT")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd6') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwstdsem6draft(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in ('draftthesis') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwstdupdtdraftthesissem6(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in ('sem6updtdrafthesis','sem6plarpt') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdrptsem6rd7(string applid, string stdid, string stdtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (stdtype == "DA")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.tblfeesconfig where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd7') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "PARTNER")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_collaboration] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd7') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            else if (stdtype == "AGENT")
            {

                dal.sqlcmdstr = "DECLARE @Names VARCHAR(8000) ";
                dal.sqlcmdstr += " set @Names = (SELECT forms + ', ' AS 'data()' FROM appl.[tblfeesconfig_agent] where verified_sts = 1 and applid = @applid FOR XML PATH(''))";
                dal.sqlcmdstr += " select *,";
                dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
                dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
                dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
                dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
                dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
                dal.sqlcmdstr += " end cssclass";
                dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
                dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
                dal.sqlcmdstr += " where doc_grup in('sem6rd7') and(@Names like '%'+left(doctype,4)+'%' or @Names like '%'+left(doctype,5)+'%') order by slno";
            }
            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwthesis(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            //  dal.sqlcmdstr += " where doc_grup in ('resdoc','draftthesis','sem6updtdrafthesis','sem6plarpt') order by slno";
            dal.sqlcmdstr += " where doc_grup in ('finalthesis','resdoc') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwstdformslog(string stdid, string form)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = " select * from appl.tblstdrdformssbmtlog where stdid=@stdid and form=@form order by rcm desc";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdcrsworklog(string stdid, string form)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = " select * from appl.tblstdrdformssbmtlog where stdid=@stdid and form=@form and sts=1 order by rcm desc";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwstdcrsvwworklog(string stdid, string form)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = " select * from appl.tblstdrdformssbmtlog where stdid=@stdid and form=@form and sts=1 and refnum is not null";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        // For student res and lab file upload
        public void spinsreslabdocsbmt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spstdresandlabdocsbmt";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();

        }
        //Changes for hold/reject 31-12-2019
        //start

        private Guid _frmmodtrans_id;
        private string _follow_dec;
        private DateTime _next_followupdate;
        private string _appl_sts;
        private Guid _appl_stage;
        public Guid frmmodtrans_id
        {
            set { _frmmodtrans_id = value; }
            get { return _frmmodtrans_id; }
        }
        public Guid appl_stage
        {
            set { _appl_stage = value; }
            get { return _appl_stage; }
        }
        public string followup_dec
        {
            set { _follow_dec = value; }
            get { return _follow_dec; }
        }

        public DateTime next_followupdate
        {
            set { _next_followupdate = value; }
            get { return _next_followupdate; }
        }
        public string appl_sts
        {
            set { _appl_sts = value; }
            get { return _appl_sts; }
        }

        public void approval_insert()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "sp_instblfollowup";


            param = new SqlParameter("@frmmodtransid", SqlDbType.UniqueIdentifier, 100);
            param.Value = frmmodtrans_id;
            li_param.Add(param);

            param = new SqlParameter("@followup_dec", SqlDbType.VarChar, 500);
            param.Value = followup_dec;
            li_param.Add(param);

            param = new SqlParameter("@next_followupdate", SqlDbType.Date, 100);
            param.Value = next_followupdate;
            li_param.Add(param);

            param = new SqlParameter("@appl_stage", SqlDbType.UniqueIdentifier, 100);
            param.Value = appl_stage;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 200);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@appl_sts", SqlDbType.VarChar, 100);
            param.Value = appl_sts;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
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

        private string _topic_sub;
        private string _form_id;
        private DateTime _lettissdt;

        public DateTime lettissdt
        {
            set { _lettissdt = value; }
            get { return _lettissdt; }
        }
        public string topic_sub
        {
            set { _topic_sub = value; }
            get { return _topic_sub; }
        }
        public string form_id
        {
            set { _form_id = value; }
            get { return _form_id; }
        }

        public void ins_tblrdfrmrschtopic()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "sp_tblrdfrmrschtopic";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 100);
            param.Value = form_id;
            li_param.Add(param);

            param = new SqlParameter("@deptsname", SqlDbType.VarChar, 50);
            param.Value = deptsname;
            li_param.Add(param);

            param = new SqlParameter("@offerltrnum", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@topic_sub", SqlDbType.VarChar, 500);
            param.Value = topic_sub;
            li_param.Add(param);

            param = new SqlParameter("@lettissdt", SqlDbType.DateTime, 500);
            param.Value = lettissdt;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 1000);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            if (recordsaffected > 0)
            {
                recordsaffected = dal.recordsaffected;
                offerltrnum = dal.oparam[0].Value.ToString();
            }
        }

        public void updt_tblrdfrmrschtopic()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "sp_updtrdfrmrschtopic";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 500);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@topic_sub", SqlDbType.VarChar, 500);
            param.Value = topic_sub;
            li_param.Add(param);

            param = new SqlParameter("@lettissdt", SqlDbType.DateTime, 500);
            param.Value = lettissdt;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
        }

        public DataTable vw_bystdid(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.tblrdfrmrschtopic where stdid =@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 100);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vwholdrejectlog(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.tblfollowup where frmmodtransid=@frmmodtransid order by rcm desc";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);
            
            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // Research Methology view Assisments Submission Start

        public DataTable vwdocpostass(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-primary mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup = 'rmassgn' order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        // Research Methology view Assisments Submission End


        // Computer Application view  Assisment Submission Start

        public DataTable vwdoccomppostass(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-primary mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup = 'comassgn' order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // Computer Application view Assisments Submission End



        // Assisments Submission Start


        public void spstdassistformsbmt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spstdassistformsbmt";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();

        }

        // Assisments Submission End

        private Guid _id;
        public Guid id
        {
            set { _id = value; }
            get { return _id; }
        }

        public void spstdassistdelformsbmt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spstdassistdelformsbmt";

            param = new SqlParameter("@transid", SqlDbType.UniqueIdentifier, 50);
            param.Value = id;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();

        }

        // Assignment CPGS FeedBack Start

        private decimal _marks;
        public decimal marks
        {
            set { _marks = value; }
            get { return _marks; }
        }
        public void spcpgsassistformfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spcpgsassistformfdbck";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@spvrsts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@marks", SqlDbType.Decimal, 1000);
            param.Value = marks;
            li_param.Add(param);

            param = new SqlParameter("@spvrrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        // Assignment CPGS FeedBack End.

            //Marks Section 
        private decimal _marksobtained;
        private string _grade;

        public decimal marksobtained
        {
            set { _marksobtained = value; }
            get { return _marksobtained; }
        }

        public string grade
        {
            set { _grade = value; }
            get { return _grade; }
        }

        public void spinsmarks()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spinsmarks";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@subjectid", SqlDbType.VarChar, 50);
            param.Value = subject;
            li_param.Add(param);

            param = new SqlParameter("@marksobtained", SqlDbType.Money, 1000);
            param.Value = marksobtained;
            li_param.Add(param);

            param = new SqlParameter("@grade", SqlDbType.VarChar, 50);
            param.Value = grade;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        public DataTable vwresworkmarks(string stdid, string form)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            if (form == "6695E951-E2C0-4642-BD2A-E7A706A0F42B")
            {
                dal.sqlcmdstr += "Select 'Total_Marks'= sum(marks) from appl.tblstdrdformssbmt where form in('EE1CD59C-9D21-4D83-98B9-818650A867DF','785AF950-A5BA-4CEE-A4B8-783FEF2D0DC5','23F0CC0A-3993-4574-BA02-51A6E94E6821','6695E951-E2C0-4642-BD2A-E7A706A0F42B') and stdid=@stdid";
            }
            else if (form == "7663F85B-6A9C-47C9-BC17-70E2D73B394E")
            {
                dal.sqlcmdstr += "Select 'Total_Marks'= sum(marks) from appl.tblstdrdformssbmt where form in('056BF8A9-90DF-4D96-BF5D-57B5658F17D7','C3D5C70D-F145-4F38-8A6D-08AAB196446F','5E25619C-B26C-47B2-99C9-E7FDF008F5C2','7663F85B-6A9C-47C9-BC17-70E2D73B394E') and stdid=@stdid";
            }
            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwmarks(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr += "select marks.*,doc.doctype,doc.doc_code from appl.tblmarks marks inner join master.tbldoctypemast doc on doc.transid=marks.subjectid where marks.stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwcertdtls(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr += "Select * from appl.tblcertdtls where stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable viewcrsworkdtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr += "Select * from master.tbldoctypemast where transid in('37FE5954-BE91-44FF-993C-E7DDAC6502DA','C3A1DA1A-6F9E-43EF-AF04-037219D89939')";

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        private DataTable _marksdtls;
        public DataTable marksdtls
        {
            set { _marksdtls = value; }
            get { return _marksdtls; }
        }

        public void spinscrsworkmarks()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_crsworkinsmarks";

            param = new SqlParameter("@marksdtls", SqlDbType.Structured, -1);
            param.Value = marksdtls;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }


        private DateTime _assltterdt;
        public DateTime assltterdt
        {
            set { _assltterdt = value; }
            get { return _assltterdt; }
        }

        public void spcpgsupdtassltterdt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();


            dal.sqlcmdstr = "appl.sp_updtassltterdt";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@assltterdt", SqlDbType.DateTime, 50);
            param.Value = assltterdt;
            li_param.Add(param);

            param = new SqlParameter("@deptsname", SqlDbType.VarChar, 50);
            param.Value = deptsname;
            li_param.Add(param);

            param = new SqlParameter("@offerltrnum", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            if (recordsaffected > 0)
            {
                recordsaffected = dal.recordsaffected;
                offerltrnum = dal.oparam[0].Value.ToString();
            }
        }
        public DataTable vwalctstd(string transid, string spvrallotsts)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            
            dal.sqlcmdstr = "select * from [appl].[vw_appl] where spvrallotsts=@spvrallotsts and transid=@transid";
            
            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@spvrallotsts", SqlDbType.VarChar, 1);
            param.Value = spvrallotsts;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        //End
        public DataTable vwcrsworkdoc(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup in ('recdocsem3','recdocsem4','recdocsem5','sem6') order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }


        // Coursework Documents Start-->

        public void stdinscrsworksbmt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spstdcrsworksbmt";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();

        }

        //   Coursework Documents End-->

         

        //Research doc upload 

        public DataTable vwresdoc(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();


            dal.sqlcmdstr += " select *,";
            dal.sqlcmdstr += " case when sts is null then 'btn btn-sm btn-default mt-10'";
            dal.sqlcmdstr += " when sts = 1 then 'btn btn-sm btn-success mt-10'";
            dal.sqlcmdstr += " when sts = 2 then 'btn btn-sm btn-danger mt-10'";
            dal.sqlcmdstr += " when sts = 3 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " when sts = 4 then 'btn btn-sm btn-info mt-10'";
            dal.sqlcmdstr += " when sts = 5 then 'btn btn-sm btn-warning mt-10'";
            dal.sqlcmdstr += " end cssclass";
            dal.sqlcmdstr += " from [master].[tbldoctypemast] mast";
            dal.sqlcmdstr += " left outer join appl.tblstdrdformssbmt on mast.transid=form and stdid=@stdid";
            dal.sqlcmdstr += " where doc_grup = 'resdoc' order by slno";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        //for student portal
        public void spinsthesisdsbmt()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spstdthesissbmt";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@form", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@url", SqlDbType.VarChar, 1000);
            param.Value = url;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();

        }

        // for cpgs portal//

        public void spcpgsthesisfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spcpgsthesisfdbck";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@sts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@cpgsfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@cpgsfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@cpgsrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        public void spcpgsresfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spcpgsresfdbck";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@sts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@cpgsfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@cpgsfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@cpgsrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        //for supervisor portal//
        public void spspvrthesisfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spspvrthesisfdbck";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@sts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@spvrrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }

        public void spspvrresfdbck()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spspvrresfdbck";

            param = new SqlParameter("@formid", SqlDbType.VarChar, 50);
            param.Value = form;
            li_param.Add(param);

            param = new SqlParameter("@sts", SqlDbType.VarChar, 50);
            param.Value = spvrsts;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeed", SqlDbType.VarChar, 50);
            param.Value = spvrfeed;
            li_param.Add(param);

            param = new SqlParameter("@spvrfeedurl", SqlDbType.VarChar, 1000);
            param.Value = spvrfeedurl;
            li_param.Add(param);

            param = new SqlParameter("@spvrrco", SqlDbType.VarChar, 50);
            param.Value = spvrrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            msg = dal.oparam[0].Value.ToString();
            recordsaffected = dal.recordsaffected;

        }
        public void updt_applemaildetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtapplemaildetails]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@appl_email", SqlDbType.VarChar, 100);
            param.Value = appl_email;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public DataTable vw_spvrbyemail(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select spvrallo.*,svprdtls.* from appl.tblsupervisorappl svprdtls inner join appl.tblspvrallocation spvrallo on spvrallo.spvrid=svprdtls.transid where spvrallo.applid=@applid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_spvrbyapplicationid(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from appl.vw_supervisor where applicationid=@applid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_spvrtype(string applid, string spvrtype)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select spvrallo.*,svprdtls.* from appl.tblsupervisorappl svprdtls inner join appl.tblspvrallocation spvrallo on spvrallo.spvrid=svprdtls.transid where spvrallo.spvrtype=@spvrtype and spvrallo.del_sts is null and spvrallo.applid=@applid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@spvrtype", SqlDbType.VarChar, 100);
            param.Value = spvrtype;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // Certficate & Transcript Section

        private DateTime _certissuedt;
        private DateTime _transissuedt;
        private string _restitle;
        public DateTime transissuedt
        {
            set { _transissuedt = value; }
            get { return _transissuedt; }
        }

        public DateTime certissuedt
        {
            set { _certissuedt = value; }
            get { return _certissuedt; }
        }
        private DataTable _typetranscriptdtls;

        public DataTable typetranscriptdtls
        {
            set { _typetranscriptdtls = value; }
            get { return _typetranscriptdtls; }
        }
        public string restitle
        {
            set { _restitle = value; }
            get { return _restitle; }
        }
        public void instransdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spinstranscript";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@restitle", SqlDbType.VarChar, 500);
            param.Value = restitle;
            li_param.Add(param);

            param = new SqlParameter("@fieldofres", SqlDbType.VarChar, 500);
            param.Value = reserach_field;
            li_param.Add(param);

            param = new SqlParameter("@transissuedt", SqlDbType.DateTime, 50);
            param.Value = transissuedt;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 100);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@typetranscriptdtls", SqlDbType.Structured, -1);
            param.Value = typetranscriptdtls;
            li_param.Add(param);


            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        private string _stdname;
        public string stdname
        {
            set { _stdname = value; }
            get { return _stdname; }
        }

        public void inscertdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spinscertdtls";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            param = new SqlParameter("@stdname", SqlDbType.VarChar, 50);
            param.Value = stdname;
            li_param.Add(param);

            param = new SqlParameter("@certissuedt", SqlDbType.DateTime, 100);
            param.Value = certissuedt;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 100);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public DataTable vw_transcript()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "  select appldtls.appl_name,appldtls.appl_email,applcert.* from appl.vw_appl appldtls inner join appl.tblcertdtls applcert on appldtls.stdid=applcert.stdid";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_transcript(string stdid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr += "Select * from [appl].[tbltranscriptdtls] where stdid=@stdid";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_certificate()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "  select appldtls.appl_name,appldtls.appl_email,applcert.* from appl.vw_appl appldtls inner join appl.tblcertdtls applcert on appldtls.stdid=applcert.stdid where certid is not null";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_certificate(string certid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from [appl].[tblcertdtls] where certid=@certid";

            param = new SqlParameter("@certid", SqlDbType.VarChar, 100);
            param.Value = certid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        // Application Transfer

        private string _appltransreason;
        private string _appltransrco;
        public string appltransreason
        {
            set { _appltransreason = value; }
            get { return _appltransreason; }
        }
        public string appltransrco
        {
            set { _appltransrco = value; }
            get { return _appltransrco; }
        }

        public void insappltransfer()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_insappltranfer";

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 50);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@appltransreason", SqlDbType.VarChar, 1000);
            param.Value = appltransreason;
            li_param.Add(param);

            param = new SqlParameter("@appltransrco", SqlDbType.VarChar, 50);
            param.Value = appltransrco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public DataTable vw_applfeesconfig(string applicationid, string type)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();
            if (type == "agent")
                dal.sqlcmdstr = "select a.*,b.rco from [appl].[tblfeesconfig_agent] a inner join appl.tblappldetails b on b.transid=a.applid where b.applicationid=@applicationid and a.del_sts=0";
            else if (type == "collaboration")
                dal.sqlcmdstr = "select a.*,b.rco from [appl].[tblfeesconfig_collaboration] a inner join appl.tblappldetails b on b.transid=a.applid where b.applicationid=@applicationid and a.del_sts='0'";
            else
                dal.sqlcmdstr = "select a.*,b.rco from [appl].[tblfeesconfig] a inner join appl.tblappldetails b on b.transid=a.applid where b.applicationid=@applicationid and a.del_sts='0'";

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 100);
            param.Value = applicationid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public string _feestype;
        public string _Currency;
        public DateTime _duedt;
        public string _verified_rco;
        public DateTime _verified_rcm;
        public string _forms;
        public decimal _bankcharges;
        public decimal _totalamt;
        public string _currentrco;

        public string feestype
        {
            set { _feestype = value; }
            get { return _feestype; }
        }
        public string Currency
        {
            set { _Currency = value; }
            get { return _Currency; }
        }
        public DateTime duedt
        {
            set { _duedt = value; }
            get { return _duedt; }
        }
        public string verified_rco
        {
            set { _verified_rco = value; }
            get { return _verified_rco; }
        }
        public DateTime verified_rcm
        {
            set { _verified_rcm = value; }
            get { return _verified_rcm; }
        }
        public string forms
        {
            set { _forms = value; }
            get { return _forms; }
        }
        public decimal bankcharges
        {
            set { _bankcharges = value; }
            get { return _bankcharges; }
        }
        public decimal totalamt
        {
            set { _totalamt = value; }
            get { return _totalamt; }

        }
        public string currentrco
        {
            set { _currentrco = value; }
            get { return _currentrco; }
        }

        public void insapplfeesconfig()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            dal.sqlcmdstr = "appl.sp_insfeesconfig";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 1000);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@applid", SqlDbType.VarChar, 1000);
            param.Value = applid;
            li_param.Add(param);

            param = new SqlParameter("@feestype", SqlDbType.VarChar, 1000);
            param.Value = feestype;
            li_param.Add(param);

            param = new SqlParameter("@amount", SqlDbType.Decimal, 1000);
            param.Value = amount;
            li_param.Add(param);

            param = new SqlParameter("@Currency", SqlDbType.VarChar, 1000);
            param.Value = Currency;
            li_param.Add(param);

            param = new SqlParameter("@duedt", SqlDbType.DateTime);
            param.Value = duedt;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 1000);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@rcm", SqlDbType.DateTime);
            param.Value = rcm;
            li_param.Add(param);

            param = new SqlParameter("@del_sts", SqlDbType.Char, 1);
            param.Value = del_sts;
            li_param.Add(param);

            param = new SqlParameter("@luo", SqlDbType.VarChar, 1000);
            param.Value = luo;
            li_param.Add(param);

            param = new SqlParameter("@lum", SqlDbType.DateTime);
            param.Value = lum;
            li_param.Add(param);

            param = new SqlParameter("@verified_sts", SqlDbType.Char, 1);
            param.Value = verified_sts;
            li_param.Add(param);

            param = new SqlParameter("@verified_rco", SqlDbType.VarChar, 1000);
            param.Value = verified_rco;
            li_param.Add(param);

            param = new SqlParameter("@verified_rcm", SqlDbType.DateTime);
            param.Value = verified_rcm;
            li_param.Add(param);

            param = new SqlParameter("@bankslip_url", SqlDbType.VarChar, 1000);
            param.Value = bankslip_url;
            li_param.Add(param);

            param = new SqlParameter("@receipt_url", SqlDbType.VarChar, 1000);
            param.Value = receipt_url;
            li_param.Add(param);

            param = new SqlParameter("@remarks", SqlDbType.VarChar, 1000);
            param.Value = remarks;
            li_param.Add(param);

            param = new SqlParameter("@forms", SqlDbType.VarChar, 1000);
            param.Value = forms;
            li_param.Add(param);

            param = new SqlParameter("@agt_commission", SqlDbType.Decimal, 50);
            param.Value = agt_commission;
            li_param.Add(param);

            param = new SqlParameter("@agt_commission_currency", SqlDbType.VarChar, 1000);
            param.Value = agt_commission_currency;
            li_param.Add(param);

            param = new SqlParameter("@bankcharges", SqlDbType.Decimal, 1000);
            param.Value = bankcharges;
            li_param.Add(param);

            param = new SqlParameter("@totalamt", SqlDbType.Decimal, 1000);
            param.Value = totalamt;
            li_param.Add(param);

            param = new SqlParameter("@currentrco", SqlDbType.VarChar, 1000);
            param.Value = currentrco;
            li_param.Add(param);


            param = new SqlParameter("@tabletype", SqlDbType.VarChar, 1000);
            param.Value = tabletype;
            li_param.Add(param);

            dal.lparam = li_param;

            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            //msg = dal.oparam[0].Value.ToString();
        }

        public DataTable vw_appltransferdtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from appl.tblappldetails where appltransreason is not null";

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
    }
    public class blsupervisorappl
    {
        public DataAccess_sql dal;
        public DataAccess dal2;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _stage;
        private string _process;
        private string _applicationid;
        private string _spvr_sal;
        private string _spvr_fname;
        private string _spvr_mname;
        private string _spvr_lname;
        private string _name;
        private string _designation;
        private string _passportic;
        private string _email;
        private string _altemail;
        private string _phone_number;
        private string _alt_phone_number;
        private string _dept;
        private string _resrch_insterest;
        private string _org_name;

        private DateTime _assistantproffrom;
        private DateTime _assistantprofto;

        private DateTime _associateproffrom;
        private DateTime _associateprofto;

        private DateTime _professorfrom;
        private DateTime _professorto;

        private int _totalteach;
        private DateTime _indusexfrom;
        private DateTime _indusexpto;

        private DateTime _researchexpfrom;
        private DateTime _researchexpTo;

        private string _membership;
        private string _recognisedsprvsr;
        private string _sopnserdresearchproj;

        private int _mphilthesisguide;
        private int _phdthesisguidenum;
        //
        private string _phdthesistitle;

        private string _phdfaculty;
        private string _phdspecialization;
        private string _recognitionForluc;
        private string _otherrelvntinfo;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;

        private DataTable _supervisoredudtls;
        private DataTable _supervisorpublish;
        private DataTable _spvrresinterest;
        private DataTable _spvrintreharea;

        private string _approval_comment;

        private string _cv;
        private string _pic;

        public string cv
        {
            set { _cv = value; }
            get { return _cv; }
        }

        public string pic
        {
            set { _pic = value; }
            get { return _pic; }
        }

        public string approval_comment
        {
            set { _approval_comment = value; }
            get { return _approval_comment; }
        }
        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string applicationid
        {
            set { _applicationid = value; }
            get { return _applicationid; }
        }
        public string stage
        {
            set { _stage = value; }
            get { return _stage; }
        }
        public string process
        {
            set { _process = value; }
            get { return _process; }
        }

        public string spvr_sal
        {
            set { _spvr_sal = value; }
            get { return _spvr_sal; }
        }
        public string spvr_fname
        {
            set { _spvr_fname = value; }
            get { return _spvr_fname; }
        }
        public string spvr_mname
        {
            set { _spvr_mname = value; }
            get { return _spvr_mname; }
        }
        public string spvr_lname
        {
            set { _spvr_lname = value; }
            get { return _spvr_lname; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string designation
        {
            set { _designation = value; }
            get { return _designation; }
        }
        public string passportic
        {
            set { _passportic = value; }
            get { return _passportic; }
        }
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        public string altemail
        {
            set { _altemail = value; }
            get { return _altemail; }
        }
        public string phone_number
        {
            set { _phone_number = value; }
            get { return _phone_number; }
        }
        public string alt_phone_number
        {
            set { _alt_phone_number = value; }
            get { return _alt_phone_number; }
        }
        public string dept
        {
            set { _dept = value; }
            get { return _dept; }
        }

        public string resrch_insterest
        {
            set { _resrch_insterest = value; }
            get { return _resrch_insterest; }
        }
        public string org_name
        {
            set { _org_name = value; }
            get { return _org_name; }
        }

        public DateTime assistantproffrom
        {
            set { _assistantproffrom = value; }
            get { return _assistantproffrom; }
        }
        public DateTime assistantprofto
        {
            set { _assistantprofto = value; }
            get { return _assistantprofto; }
        }

        public DateTime associateproffrom
        {
            set { _associateproffrom = value; }
            get { return _associateproffrom; }
        }
        public DateTime associateprofto
        {
            set { _associateprofto = value; }
            get { return _associateprofto; }
        }

        public DateTime professorfrom
        {
            set { _professorfrom = value; }
            get { return _professorfrom; }
        }
        public DateTime professorto
        {
            set { _professorto = value; }
            get { return _professorto; }
        }

        public int totalteach
        {
            set { _totalteach = value; }
            get { return _totalteach; }
        }
        public DateTime indusexfrom
        {
            set { _indusexfrom = value; }
            get { return _indusexfrom; }
        }

        public DateTime indusexpto
        {
            set { _indusexpto = value; }
            get { return _indusexpto; }
        }
        public DateTime researchexpfrom
        {
            set { _researchexpfrom = value; }
            get { return _researchexpfrom; }
        }

        public DateTime researchexpTo
        {
            set { _researchexpTo = value; }
            get { return _researchexpTo; }
        }

        public string membership
        {
            set { _membership = value; }
            get { return _membership; }
        }
        public string recognisedsprvsr
        {
            set { _recognisedsprvsr = value; }
            get { return _recognisedsprvsr; }
        }
        public string sopnserdresearchproj
        {
            set { _sopnserdresearchproj = value; }
            get { return _sopnserdresearchproj; }
        }
        public int mphilthesisguide
        {
            set { _mphilthesisguide = value; }
            get { return _mphilthesisguide; }
        }
        public int phdthesisguidenum
        {
            set { _phdthesisguidenum = value; }
            get { return _phdthesisguidenum; }
        }
        public string phdthesistitle
        {
            set { _phdthesistitle = value; }
            get { return _phdthesistitle; }
        }
        public string phdfaculty
        {
            set { _phdfaculty = value; }
            get { return _phdfaculty; }
        }
        public string phdspecialization
        {
            set { _phdspecialization = value; }
            get { return _phdspecialization; }
        }
        public string recognitionForluc
        {
            set { _recognitionForluc = value; }
            get { return _recognitionForluc; }
        }
        public string otherrelvntinfo
        {
            set { _otherrelvntinfo = value; }
            get { return _otherrelvntinfo; }
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

        public DataTable supervisoredudtls
        {
            set { _supervisoredudtls = value; }
            get { return _supervisoredudtls; }
        }
        public DataTable supervisorpublish
        {
            set { _supervisorpublish = value; }
            get { return _supervisorpublish; }
        }

        public DataTable spvrresinterest
        {
            set { _spvrresinterest = value; }
            get { return _spvrresinterest; }
        }

        public DataTable spvrintreharea
        {
            set { _spvrintreharea = value; }
            get { return _spvrintreharea; }
        }

        private string _googlescholar;
        public string googlescholar
        {
            set { _googlescholar = value; }
            get { return _googlescholar; }
        }
        private string _othscopusid;
        public string othscopusid
        {
            set { _othscopusid = value; }
            get { return _othscopusid; }
        }


        public void insSupervisorAppl()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.[spinssupervisorAppl]";

            param = new SqlParameter("@spvr_sal", SqlDbType.VarChar, 50);
            param.Value = spvr_sal;
            li_param.Add(param);

            param = new SqlParameter("@spvr_fname", SqlDbType.VarChar, 50);
            param.Value = spvr_fname;
            li_param.Add(param);

            param = new SqlParameter("@spvr_mname", SqlDbType.VarChar, 50);
            param.Value = spvr_mname;
            li_param.Add(param);

            param = new SqlParameter("@spvr_lname", SqlDbType.VarChar, 50);
            param.Value = spvr_lname;
            li_param.Add(param);

            param = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param.Value = name;
            li_param.Add(param);

            param = new SqlParameter("@designation", SqlDbType.VarChar, 200);
            param.Value = designation;
            li_param.Add(param);

            param = new SqlParameter("@passportic", SqlDbType.VarChar);
            param.Value = passportic;
            li_param.Add(param);

            param = new SqlParameter("@email", SqlDbType.VarChar, 50);
            param.Value = email;
            li_param.Add(param);

            param = new SqlParameter("@altemail", SqlDbType.VarChar, 50);
            param.Value = altemail;
            li_param.Add(param);

            param = new SqlParameter("@phone_number", SqlDbType.VarChar, 50);
            param.Value = phone_number;
            li_param.Add(param);

            param = new SqlParameter("@alt_phone_number", SqlDbType.VarChar, 50);
            param.Value = alt_phone_number;
            li_param.Add(param);


            param = new SqlParameter("@dept", SqlDbType.VarChar, 50);
            param.Value = dept;
            li_param.Add(param);

            param = new SqlParameter("@resrch_insterest", SqlDbType.VarChar, 200);
            param.Value = resrch_insterest;
            li_param.Add(param);

            param = new SqlParameter("@org_name", SqlDbType.VarChar, 100);
            param.Value = org_name;
            li_param.Add(param);

            //assistant
            param = new SqlParameter("@assistantproffrom", SqlDbType.Date, 50);
            param.Value = assistantproffrom;
            li_param.Add(param);

            param = new SqlParameter("@assistantprofto", SqlDbType.Date, 50);
            param.Value = assistantprofto;
            li_param.Add(param);
            //associate
            param = new SqlParameter("@associateproffrom", SqlDbType.Date, 50);
            param.Value = associateproffrom;
            li_param.Add(param);

            param = new SqlParameter("@associateprofto", SqlDbType.Date, 50);
            param.Value = associateprofto;
            li_param.Add(param);
            //professor
            param = new SqlParameter("@professorfrom", SqlDbType.Date, 50);
            param.Value = professorfrom;
            li_param.Add(param);

            param = new SqlParameter("@professorto", SqlDbType.Date, 50);
            param.Value = professorto;
            li_param.Add(param);

            param = new SqlParameter("@totalteach", SqlDbType.Int, 50);
            param.Value = totalteach;
            li_param.Add(param);

            param = new SqlParameter("@indusexfrom", SqlDbType.Date, 50);
            param.Value = indusexfrom;
            li_param.Add(param);

            param = new SqlParameter("@indusexpto", SqlDbType.Date, 50);
            param.Value = indusexpto;
            li_param.Add(param);

            param = new SqlParameter("@researchexpfrom", SqlDbType.Date, 50);
            param.Value = researchexpfrom;
            li_param.Add(param);

            param = new SqlParameter("@researchexpTo", SqlDbType.Date, 50);
            param.Value = researchexpTo;
            li_param.Add(param);

            param = new SqlParameter("@membership", SqlDbType.VarChar, 500);
            param.Value = membership;
            li_param.Add(param);

            param = new SqlParameter("@recognisedsprvsr", SqlDbType.VarChar, 500);
            param.Value = recognisedsprvsr;
            li_param.Add(param);

            param = new SqlParameter("@sopnserdresearchproj", SqlDbType.VarChar, 500);
            param.Value = sopnserdresearchproj;
            li_param.Add(param);

            param = new SqlParameter("@mphilthesisguide", SqlDbType.Int, 50);
            param.Value = mphilthesisguide;
            li_param.Add(param);

            param = new SqlParameter("@phdthesisguidenum", SqlDbType.Int, 50);
            param.Value = phdthesisguidenum;
            li_param.Add(param);

            param = new SqlParameter("@phdthesistitle", SqlDbType.VarChar, 200);
            param.Value = phdthesistitle;
            li_param.Add(param);

            param = new SqlParameter("@phdfaculty", SqlDbType.VarChar, 200);
            param.Value = phdfaculty;
            li_param.Add(param);

            param = new SqlParameter("@phdspecialization", SqlDbType.VarChar, 200);
            param.Value = phdspecialization;
            li_param.Add(param);

            param = new SqlParameter("@recognitionForluc", SqlDbType.VarChar, 200);
            param.Value = recognitionForluc;
            li_param.Add(param);

            param = new SqlParameter("@otherrelvntinfo", SqlDbType.VarChar, 200);
            param.Value = otherrelvntinfo;
            li_param.Add(param);


            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@cv", SqlDbType.VarChar, 1000);
            param.Value = cv;
            li_param.Add(param);

            param = new SqlParameter("@pic", SqlDbType.VarChar, 1000);
            param.Value = pic;
            li_param.Add(param);

            param = new SqlParameter("@type_tblsupervisoreduDetails", SqlDbType.Structured, -1);
            param.Value = supervisoredudtls;
            li_param.Add(param);

            param = new SqlParameter("@orcid", SqlDbType.VarChar, 1000);
            param.Value = orcid;
            li_param.Add(param);

            param = new SqlParameter("@scopusid", SqlDbType.VarChar, 1000);
            param.Value = scopusid;
            li_param.Add(param);

            param = new SqlParameter("@googlescholar", SqlDbType.VarChar, 1000);
            param.Value = googlescholar;
            li_param.Add(param);

            param = new SqlParameter("@othscopusid", SqlDbType.VarChar, 1000);
            param.Value = othscopusid;
            li_param.Add(param);

            param = new SqlParameter("@type_tblsupervisorpublish", SqlDbType.Structured, -1);
            param.Value = supervisorpublish;
            li_param.Add(param);

            param = new SqlParameter("@type_tblspvrresinterest", SqlDbType.Structured, -1);
            param.Value = spvrresinterest;
            li_param.Add(param);

            param = new SqlParameter("@type_tblspvrintreharea", SqlDbType.Structured, -1);
            param.Value = spvrintreharea;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 100);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@stage", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@process", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();
            applicationid= dal.oparam[1].Value.ToString();
            stage = dal.oparam[2].Value.ToString();
            process = dal.oparam[3].Value.ToString();

        }

        public void insCoSupervisorAppl()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spinscosupervisorappl]";

            param = new SqlParameter("@spvr_sal", SqlDbType.VarChar, 50);
            param.Value = spvr_sal;
            li_param.Add(param);

            param = new SqlParameter("@spvr_fname", SqlDbType.VarChar, 50);
            param.Value = spvr_fname;
            li_param.Add(param);

            param = new SqlParameter("@spvr_mname", SqlDbType.VarChar, 50);
            param.Value = spvr_mname;
            li_param.Add(param);

            param = new SqlParameter("@spvr_lname", SqlDbType.VarChar, 50);
            param.Value = spvr_lname;
            li_param.Add(param);

            param = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param.Value = name;
            li_param.Add(param);

            param = new SqlParameter("@designation", SqlDbType.VarChar, 200);
            param.Value = designation;
            li_param.Add(param);

            param = new SqlParameter("@passportic", SqlDbType.VarChar);
            param.Value = passportic;
            li_param.Add(param);

            param = new SqlParameter("@email", SqlDbType.VarChar, 50);
            param.Value = email;
            li_param.Add(param);

            param = new SqlParameter("@altemail", SqlDbType.VarChar, 50);
            param.Value = altemail;
            li_param.Add(param);

            param = new SqlParameter("@phone_number", SqlDbType.VarChar, 50);
            param.Value = phone_number;
            li_param.Add(param);

            param = new SqlParameter("@alt_phone_number", SqlDbType.VarChar, 50);
            param.Value = alt_phone_number;
            li_param.Add(param);


            param = new SqlParameter("@dept", SqlDbType.VarChar, 50);
            param.Value = dept;
            li_param.Add(param);

            param = new SqlParameter("@resrch_insterest", SqlDbType.VarChar, 200);
            param.Value = resrch_insterest;
            li_param.Add(param);

            param = new SqlParameter("@org_name", SqlDbType.VarChar, 100);
            param.Value = org_name;
            li_param.Add(param);

            //assistant
            param = new SqlParameter("@assistantproffrom", SqlDbType.Date, 50);
            param.Value = assistantproffrom;
            li_param.Add(param);

            param = new SqlParameter("@assistantprofto", SqlDbType.Date, 50);
            param.Value = assistantprofto;
            li_param.Add(param);

            //associate
            param = new SqlParameter("@associateproffrom", SqlDbType.Date, 50);
            param.Value = associateproffrom;
            li_param.Add(param);

            param = new SqlParameter("@associateprofto", SqlDbType.Date, 50);
            param.Value = associateprofto;
            li_param.Add(param);

            //professor
            param = new SqlParameter("@professorfrom", SqlDbType.Date, 50);
            param.Value = professorfrom;
            li_param.Add(param);

            param = new SqlParameter("@professorto", SqlDbType.Date, 50);
            param.Value = professorto;
            li_param.Add(param);

            param = new SqlParameter("@totalteach", SqlDbType.Int, 50);
            param.Value = totalteach;
            li_param.Add(param);

            param = new SqlParameter("@indusexfrom", SqlDbType.Date, 50);
            param.Value = indusexfrom;
            li_param.Add(param);

            param = new SqlParameter("@indusexpto", SqlDbType.Date, 50);
            param.Value = indusexpto;
            li_param.Add(param);

            param = new SqlParameter("@researchexpfrom", SqlDbType.Date, 50);
            param.Value = researchexpfrom;
            li_param.Add(param);

            param = new SqlParameter("@researchexpTo", SqlDbType.Date, 50);
            param.Value = researchexpTo;
            li_param.Add(param);

            param = new SqlParameter("@membership", SqlDbType.VarChar, 500);
            param.Value = membership;
            li_param.Add(param);

            param = new SqlParameter("@recognisedsprvsr", SqlDbType.VarChar, 500);
            param.Value = recognisedsprvsr;
            li_param.Add(param);

            param = new SqlParameter("@sopnserdresearchproj", SqlDbType.VarChar, 500);
            param.Value = sopnserdresearchproj;
            li_param.Add(param);

            param = new SqlParameter("@mphilthesisguide", SqlDbType.Int, 50);
            param.Value = mphilthesisguide;
            li_param.Add(param);

            param = new SqlParameter("@phdthesisguidenum", SqlDbType.Int, 50);
            param.Value = phdthesisguidenum;
            li_param.Add(param);

            param = new SqlParameter("@phdthesistitle", SqlDbType.VarChar, 200);
            param.Value = phdthesistitle;
            li_param.Add(param);

            param = new SqlParameter("@phdfaculty", SqlDbType.VarChar, 200);
            param.Value = phdfaculty;
            li_param.Add(param);

            param = new SqlParameter("@phdspecialization", SqlDbType.VarChar, 200);
            param.Value = phdspecialization;
            li_param.Add(param);

            param = new SqlParameter("@recognitionForluc", SqlDbType.VarChar, 200);
            param.Value = recognitionForluc;
            li_param.Add(param);

            param = new SqlParameter("@otherrelvntinfo", SqlDbType.VarChar, 200);
            param.Value = otherrelvntinfo;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@cv", SqlDbType.VarChar, 1000);
            param.Value = cv;
            li_param.Add(param);

            param = new SqlParameter("@pic", SqlDbType.VarChar, 1000);
            param.Value = pic;
            li_param.Add(param);

            param = new SqlParameter("@type_tblsupervisoreduDetails", SqlDbType.Structured, -1);
            param.Value = supervisoredudtls;
            li_param.Add(param);

            param = new SqlParameter("@orcid", SqlDbType.VarChar, 1000);
            param.Value = orcid;
            li_param.Add(param);

            param = new SqlParameter("@scopusid", SqlDbType.VarChar, 1000);
            param.Value = scopusid;
            li_param.Add(param);

            param = new SqlParameter("@googlescholar", SqlDbType.VarChar, 1000);
            param.Value = googlescholar;
            li_param.Add(param);

            param = new SqlParameter("@othscopusid", SqlDbType.VarChar, 1000);
            param.Value = othscopusid;
            li_param.Add(param);

            param = new SqlParameter("@type_tblsupervisorpublish", SqlDbType.Structured, -1);
            param.Value = supervisorpublish;
            li_param.Add(param);

            param = new SqlParameter("@type_tblspvrresinterest", SqlDbType.Structured, -1);
            param.Value = spvrresinterest;
            li_param.Add(param);

            param = new SqlParameter("@type_tblspvrintreharea", SqlDbType.Structured, -1);
            param.Value = spvrintreharea;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@applicationid", SqlDbType.VarChar, 100);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@stage", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new SqlParameter("@process", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);


            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();
            applicationid = dal.oparam[1].Value.ToString();
            stage = dal.oparam[2].Value.ToString();
            process = dal.oparam[3].Value.ToString();
        }
        public void updtSupervisorAppl()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spupdtsupervisorappl]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param.Value = name;
            li_param.Add(param);

            param = new SqlParameter("@designation", SqlDbType.VarChar, 200);
            param.Value = designation;
            li_param.Add(param);

            param = new SqlParameter("@passportic", SqlDbType.VarChar);
            param.Value = passportic;
            li_param.Add(param);

            param = new SqlParameter("@email", SqlDbType.VarChar, 50);
            param.Value = email;
            li_param.Add(param);

            param = new SqlParameter("@altemail", SqlDbType.VarChar, 50);
            param.Value = altemail;
            li_param.Add(param);

            param = new SqlParameter("@phone_number", SqlDbType.VarChar, 50);
            param.Value = phone_number;
            li_param.Add(param);

            param = new SqlParameter("@alt_phone_number", SqlDbType.VarChar, 50);
            param.Value = alt_phone_number;
            li_param.Add(param);


            param = new SqlParameter("@dept", SqlDbType.VarChar, 50);
            param.Value = dept;
            li_param.Add(param);

            param = new SqlParameter("@resrch_insterest", SqlDbType.VarChar, 200);
            param.Value = resrch_insterest;
            li_param.Add(param);

            //assistant
            param = new SqlParameter("@assistantproffrom", SqlDbType.Date, 50);
            param.Value = assistantproffrom;
            li_param.Add(param);

            param = new SqlParameter("@assistantprofto", SqlDbType.Date, 50);
            param.Value = assistantprofto;
            li_param.Add(param);
            //associate
            param = new SqlParameter("@associateproffrom", SqlDbType.Date, 50);
            param.Value = associateproffrom;
            li_param.Add(param);

            param = new SqlParameter("@associateprofto", SqlDbType.Date, 50);
            param.Value = associateprofto;
            li_param.Add(param);
            //professor
            param = new SqlParameter("@professorfrom", SqlDbType.Date, 50);
            param.Value = professorfrom;
            li_param.Add(param);

            param = new SqlParameter("@professorto", SqlDbType.Date, 50);
            param.Value = professorto;
            li_param.Add(param);

            param = new SqlParameter("@totalteach", SqlDbType.Int, 50);
            param.Value = totalteach;
            li_param.Add(param);

            param = new SqlParameter("@indusexfrom", SqlDbType.Date, 50);
            param.Value = indusexfrom;
            li_param.Add(param);

            param = new SqlParameter("@indusexpto", SqlDbType.Date, 50);
            param.Value = indusexpto;
            li_param.Add(param);

            param = new SqlParameter("@researchexpfrom", SqlDbType.Date, 50);
            param.Value = researchexpfrom;
            li_param.Add(param);

            param = new SqlParameter("@researchexpTo", SqlDbType.Date, 50);
            param.Value = researchexpTo;
            li_param.Add(param);

            param = new SqlParameter("@membership", SqlDbType.VarChar, 500);
            param.Value = membership;
            li_param.Add(param);

            param = new SqlParameter("@recognisedsprvsr", SqlDbType.VarChar, 500);
            param.Value = recognisedsprvsr;
            li_param.Add(param);

            param = new SqlParameter("@sopnserdresearchproj", SqlDbType.VarChar, 500);
            param.Value = sopnserdresearchproj;
            li_param.Add(param);

            param = new SqlParameter("@mphilthesisguide", SqlDbType.Int, 50);
            param.Value = mphilthesisguide;
            li_param.Add(param);

            param = new SqlParameter("@phdthesisguidenum", SqlDbType.Int, 50);
            param.Value = phdthesisguidenum;
            li_param.Add(param);

            param = new SqlParameter("@phdthesistitle", SqlDbType.VarChar, 200);
            param.Value = phdthesistitle;
            li_param.Add(param);

            param = new SqlParameter("@phdfaculty", SqlDbType.VarChar, 200);
            param.Value = phdfaculty;
            li_param.Add(param);

            param = new SqlParameter("@phdspecialization", SqlDbType.VarChar, 200);
            param.Value = phdspecialization;
            li_param.Add(param);

            param = new SqlParameter("@recognitionForluc", SqlDbType.VarChar, 200);
            param.Value = recognitionForluc;
            li_param.Add(param);

            param = new SqlParameter("@otherrelvntinfo", SqlDbType.VarChar, 200);
            param.Value = otherrelvntinfo;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            //param = new SqlParameter("@cv", SqlDbType.VarChar, 1000);
            //param.Value = cv;
            //li_param.Add(param);

            //param = new SqlParameter("@pic", SqlDbType.VarChar, 1000);
            //param.Value = pic;
            //li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();

        }

        public void updt_publicationdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_updtsupervisorpublicationdtls";

            param = new SqlParameter("@publication_dtls_upload", SqlDbType.Structured, -1);
            param.Value = supervisorpublish;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void updt_educationdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.sp_updtsupervisoredudtls";

            param = new SqlParameter("@education_dtls_upload", SqlDbType.Structured, -1);
            param.Value = supervisoredudtls;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public void insSpvrapproval()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spspvrapproval]";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@approve_sts", SqlDbType.Char, 1);
            param.Value = del_sts;
            li_param.Add(param);
            
            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@approval_comment", SqlDbType.VarChar, 200);
            param.Value = approval_comment;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 500);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
            msg = dal.oparam[0].Value.ToString();

        }

        public DataTable vw_supervisor_report()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            dal.sqlcmdstr = " Select spvr.applicationid,spvr.name,spvr.dept,spvr.phdfaculty,spvr.phdspecialization, count(allo.applid) as 'no_of_std' from appl.tblsupervisorappl spvr inner join appl.tblspvrallocation allo on";
            dal.sqlcmdstr += " spvr.transid = allo.spvrid where allo.del_sts is null group by spvr.applicationid,spvr.name,spvr.dept,spvr.phdfaculty,spvr.phdspecialization";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_supervisor_dtls()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            dal.sqlcmdstr = " Select spvr.applicationid,spvr.name,spvr.dept,spvr.phdfaculty,spvr.phdspecialization, count(allo.applid) as 'no_of_std' from appl.tblsupervisorappl spvr inner join appl.tblspvrallocation allo on";
            dal.sqlcmdstr += " spvr.transid = allo.spvrid where allo.del_sts is null group by spvr.applicationid,spvr.name,spvr.dept,spvr.phdfaculty,spvr.phdspecialization";
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vw_nameall()
        {
            mdt = new DataTable();
            dal2 = new DataAccess();

            dal2.sqlcmdstr = "select * from [appl].[tblsupervisorappl] where del_sts=0 order by name";
            mdt = dal2.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }

        public DataTable vw_suprusercredentials()
        {
            mdt = new DataTable();
            dal2 = new DataAccess();

            dal2.sqlcmdstr = "Select usr.userid,usr.passwd,spvr.applicationid,spvr.name,spvr.email from system.tbluser usr";
            dal2.sqlcmdstr += " inner join appl.tblsupervisorappl spvr on usr.userid=spvr.applicationid where usr.del_sts='0'";
            mdt = dal2.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }


        public DataTable vwbytransid(string transid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from [appl].[vw_supervisor] where transid = @transid";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 100);
            param.Value = transid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vwallbyapproval(string approval)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.tblsupervisorappl where approved_sts=@sts";

            param = new SqlParameter("@sts", SqlDbType.VarChar, 100);
            param.Value = approval;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vwallbyapproval(string approval, string rco)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.tblsupervisorappl where approved_sts=@sts and rco=@rco";

            param = new SqlParameter("@sts", SqlDbType.VarChar, 100);
            param.Value = approval;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 100);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public DataTable vwbyapplid(string applid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select * from appl.tblsupervisorappl where applicationid = @applid";

            param = new SqlParameter("@applid", SqlDbType.VarChar, 100);
            param.Value = applid;
            li_param.Add(param);


            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }
        public DataTable vw_educationdtls(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select tblsupervisorappl.transid as supervisorapplid,tblsupervisoredudetails.* from [appl].[tblsupervisoredudetails] inner join [appl].[tblsupervisorappl]  on tblsupervisoredudetails.frmmodtransid=tblsupervisorappl.transid where tblsupervisorappl.del_sts='0' and tblsupervisoredudetails.del_sts='0'";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_frmsupervisordtlsall()
        {
            mdt = new DataTable();
            dal = new DataAccess_sql();

            dal.sqlcmdstr = " select * from [appl].[tblsupervisorappl] e";
            dal.sqlcmdstr += " inner join [appl].[tblsupervisorpublish] eph on eph.frmmodtransid=e.transid";
            dal.sqlcmdstr += " inner join [appl].[tblsupervisoredudetails] d on d.frmmodtransid=e.transid";


            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public void deledudtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spsupervisordeledu]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        public DataTable vw_education(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //    dal.sqlcmdstr = "select tblsupervisorappl.transid as supervisorapplid,tblsupervisoredudetails.* from [appl].[tblsupervisoredudetails] inner join [appl].[tblsupervisorappl]  on tblsupervisoredudetails.frmmodtransid=tblsupervisorappl.transid where tblsupervisorappl.del_sts='0' and tblsupervisoredudetails.del_sts='0'";
            dal.sqlcmdstr = "select dtls.*,level.level_name from [appl].[tblsupervisoredudetails] dtls inner join master.tblacademiclevelmast level on level.transid=dtls.level where frmmodtransid=@frmmodtransid and dtls.del_sts=0 order by lvl_num";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public void delpubdtls()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[appl].[spsupervisordelpublidtls]";

            param = new SqlParameter("@transid", SqlDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }

        private Guid _frmmodtransid;
        private string _hindex;
        private string _citation;
        private string _orcid;
        private string _scopusid;
        private string _researchid;
        private string _resurl;

        public Guid frmmodtransid
        {
            set { _frmmodtransid = value; }
            get { return _frmmodtransid; }
        }
        public string hindex
        {
            set { _hindex = value; }
            get { return _hindex; }
        }
        public string citation
        {
            set { _citation = value; }
            get { return _citation; }
        }
        public string orcid
        {
            set { _orcid = value; }
            get { return _orcid; }
        }
        public string scopusid
        {
            set { _scopusid = value; }
            get { return _scopusid; }
        }

        public string researchid
        {
            set { _researchid = value; }
            get { return _researchid; }
        }
        public string resurl
        {
            set { _resurl = value; }
            get { return _resurl; }
        }
        public void insspvrresearch()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "appl.spinsspvrresearch";

            param = new SqlParameter("@frmmodtransid", SqlDbType.UniqueIdentifier, 25);
            param.Value = frmmodtransid;
            li_param.Add(param);

            param = new SqlParameter("@hindex", SqlDbType.VarChar, 500);
            param.Value = hindex;
            li_param.Add(param);

            param = new SqlParameter("@citation", SqlDbType.VarChar, 500);
            param.Value = citation;
            li_param.Add(param);

            param = new SqlParameter("@orcid", SqlDbType.VarChar, 500);
            param.Value = orcid;
            li_param.Add(param);

            param = new SqlParameter("@scopusid", SqlDbType.VarChar, 500);
            param.Value = scopusid;
            li_param.Add(param);

            param = new SqlParameter("@researchid", SqlDbType.VarChar, 500);
            param.Value = researchid;
            li_param.Add(param);

            param = new SqlParameter("@resurl", SqlDbType.VarChar, 500);
            param.Value = resurl;
            li_param.Add(param);

            param = new SqlParameter("@rco", SqlDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            msg = dal.oparam[0].Value.ToString();

        }
        public DataTable vw_spvrresearch(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "Select * from appl.tblspvrresearch where frmmodtransid=@frmmodtransid and del_sts='0'";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_publication(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            //  dal.sqlcmdstr = "select tblsupervisorappl.transid as supervisorapplid,tblsupervisoredudetails.* from [appl].[tblsupervisoredudetails] inner join [appl].[tblsupervisorappl]  on tblsupervisoredudetails.frmmodtransid=tblsupervisorappl.transid where tblsupervisorappl.del_sts='0' and tblsupervisoredudetails.del_sts='0'";
            dal.sqlcmdstr = "select dtls.* from appl.tblsupervisorpublish dtls inner join appl.tblsupervisorappl sup on sup.transid=dtls.frmmodtransid where dtls.frmmodtransid=@frmmodtransid and dtls.del_sts=0";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_areaofinterest(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = "select dtls.* from [appl].[tblspvrresinterest] dtls inner join appl.tblsupervisorappl sup on sup.transid=dtls.frmmodtransid where dtls.frmmodtransid=@frmmodtransid and dtls.del_sts=0";


            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;

            return mdt;
        }

        public DataTable vw_currentareaofinterest(string frmmodtransid)
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();
            mdt = new DataTable();

            dal.sqlcmdstr = @"select dtls.* from appl.tblspvrintreharea dtls inner join appl.tblsupervisorappl sup on sup.transid=dtls.frmmodtransid where dtls.frmmodtransid=@frmmodtransid and dtls.del_sts='0'";

            param = new SqlParameter("@frmmodtransid", SqlDbType.VarChar, 50);
            param.Value = frmmodtransid;
            li_param.Add(param);
            
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            recordsaffected = dal.recordsaffected;
            return mdt;
        }
    }

    public class bldualdegree
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _programname;
        private string _acalvl;
        private DateTime _durstdt;
        private DateTime _durenddt;
        private string _affuniversity;
        private DateTime _affidt;
        private int _stdno;
        private Int32 _yr1;
        private Int32 _yr2;
        private Int32 _yr3;
        private Int32 _yr4;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;


        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string programname
        {
            set { _programname = value; }
            get { return _programname; }
        }
        public string acalvl
        {
            set { _acalvl = value; }
            get { return _acalvl; }
        }
        public DateTime durstdt
        {
            set { _durstdt = value; }
            get { return _durstdt; }
        }
        public DateTime durenddt
        {
            set { _durenddt = value; }
            get { return _durenddt; }
        }
        public string affuniversity
        {
            set { _affuniversity = value; }
            get { return _affuniversity; }
        }
        public DateTime affidt
        {
            set { _affidt = value; }
            get { return _affidt; }
        }
        public int stdno
        {
            set { _stdno = value; }
            get { return _stdno; }
        }
        public Int32 yr1
        {
            set { _yr1 = value; }
            get { return _yr1; }
        }
        public Int32 yr2
        {
            set { _yr2 = value; }
            get { return _yr2; }
        }
        public Int32 yr3
        {
            set { _yr3 = value; }
            get { return _yr3; }
        }
        public Int32 yr4
        {
            set { _yr4 = value; }
            get { return _yr4; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }


        public void ins_dualdegree()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[appl].[spinsdualdegree]";


            param = new OleDbParameter("@programname", OleDbType.VarChar, 500);
            param.Value = programname;
            li_param.Add(param);

            param = new OleDbParameter("@acalvl", OleDbType.VarChar, 50);
            param.Value = @acalvl;
            li_param.Add(param);

            param = new OleDbParameter("@durstdt", OleDbType.Date, 50);
            param.Value = durstdt;
            li_param.Add(param);

            param = new OleDbParameter("@durenddt", OleDbType.Date, 50);
            param.Value = durenddt;
            li_param.Add(param);

            param = new OleDbParameter("@affuniversity", OleDbType.VarChar, 500);
            param.Value = affuniversity;
            li_param.Add(param);

            param = new OleDbParameter("@affidt", OleDbType.Date, 50);
            param.Value = affidt;
            li_param.Add(param);

            param = new OleDbParameter("@stdno", OleDbType.Integer, 8);
            param.Value = stdno;
            li_param.Add(param);

            param = new OleDbParameter("@yr1", OleDbType.Integer, 8);
            param.Value = yr1;
            li_param.Add(param);

            param = new OleDbParameter("@yr2", OleDbType.Integer, 8);
            param.Value = yr2;
            li_param.Add(param);


            param = new OleDbParameter("@yr3", OleDbType.Integer, 8);
            param.Value = yr3;
            li_param.Add(param);

            param = new OleDbParameter("@yr4", OleDbType.Integer, 8);
            param.Value = yr4;
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
            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }

        public DataTable vw_deptdegreeall(string rco)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "select level_name,tbldualdegree.* from [appl].[tbldualdegree] ";
            dal.sqlcmdstr += "inner join master.tblacademiclevelmast on tblacademiclevelmast.transid = acalvl ";
            dal.sqlcmdstr += "where tbldualdegree.rco = ? order by programname";

            param = new OleDbParameter("@rco", OleDbType.VarChar, 100);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
    }
    public class blconference
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _title;
        private DateTime _constdt;
        private DateTime _conenddt;
        private string _clgcoordinatorname;
        private string _concoordinatorname;
        private string _email;
        private string _number;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;


        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        public DateTime constdt
        {
            set { _constdt = value; }
            get { return _constdt; }
        }
        public DateTime conenddt
        {
            set { _conenddt = value; }
            get { return _conenddt; }
        }
        public string clgcoordinatorname
        {
            set { _clgcoordinatorname = value; }
            get { return _clgcoordinatorname; }
        }
        public string concoordinatorname
        {
            set { _concoordinatorname = value; }
            get { return _concoordinatorname; }
        }
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }

        public string number
        {
            set { _number = value; }
            get { return _number; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }


        public void ins_conference()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[appl].[spinsconference]";



            param = new OleDbParameter("@title", OleDbType.VarChar, 500);
            param.Value = title;
            li_param.Add(param);

            param = new OleDbParameter("@constdt", OleDbType.Date, 50);
            param.Value = constdt;
            li_param.Add(param);

            param = new OleDbParameter("@conenddt", OleDbType.Date, 50);
            param.Value = conenddt;
            li_param.Add(param);

            param = new OleDbParameter("@clgcoordinatorname", OleDbType.VarChar, 50);
            param.Value = clgcoordinatorname;
            li_param.Add(param);

            param = new OleDbParameter("@concoordinatorname", OleDbType.VarChar, 50);
            param.Value = concoordinatorname;
            li_param.Add(param);

            param = new OleDbParameter("@email", OleDbType.VarChar, 50);
            param.Value = email;
            li_param.Add(param);

            param = new OleDbParameter("@number", OleDbType.VarChar, 50);
            param.Value = number;
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
            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }
    }
    public class blimmersionprog
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private DateTime _arrdt;
        private DateTime _depdt;
        private int _stdno;
        private string _stdlvl;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;


        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public DateTime arrdt
        {
            set { _arrdt = value; }
            get { return _arrdt; }
        }
        public DateTime depdt
        {
            set { _depdt = value; }
            get { return _depdt; }
        }
        public int stdno
        {
            set { _stdno = value; }
            get { return _stdno; }
        }

        public string stdlvl
        {
            set { _stdlvl = value; }
            get { return _stdlvl; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }

        public void ins_immerprog()
        {

            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[appl].[spinsimmersionprog]";


            param = new OleDbParameter("@arrdt", OleDbType.Date, 50);
            param.Value = arrdt;
            li_param.Add(param);

            param = new OleDbParameter("@depdt", OleDbType.Date, 50);
            param.Value = depdt;
            li_param.Add(param);

            param = new OleDbParameter("@stdno", OleDbType.Integer, 8);
            param.Value = stdno;
            li_param.Add(param);

            param = new OleDbParameter("@stdlvl", OleDbType.VarChar, 100);
            param.Value = stdlvl;
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
            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }

    }
    public class blcertprog
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _progname;
        private DateTime _prostdt;
        private DateTime _proenddt;
        private int _candno;
        private string _venue;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;


        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string progname
        {
            set { _progname = value; }
            get { return _progname; }
        }

        public DateTime prostdt
        {
            set { _prostdt = value; }
            get { return _prostdt; }
        }
        public DateTime proenddt
        {
            set { _proenddt = value; }
            get { return _proenddt; }
        }
        public int candno
        {
            set { _candno = value; }
            get { return _candno; }
        }

        public string venue
        {
            set { _venue = value; }
            get { return _venue; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }

        public void ins_certprog()
        {

            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[appl].[spinscertprog]";


            param = new OleDbParameter("@progname", OleDbType.VarChar, 500);
            param.Value = progname;
            li_param.Add(param);



            param = new OleDbParameter("@prostdt", OleDbType.Date, 50);
            param.Value = prostdt;
            li_param.Add(param);

            param = new OleDbParameter("@proenddt", OleDbType.Date, 50);
            param.Value = proenddt;
            li_param.Add(param);

            param = new OleDbParameter("@candno", OleDbType.Integer, 50);
            param.Value = candno;
            li_param.Add(param);

            param = new OleDbParameter("@venue", OleDbType.VarChar, -1);
            param.Value = venue;
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
            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }


    }

    public class bltechtransfer
    {

        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _techdetails;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;



        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }

        public string techdetails
        {
            set { _techdetails = value; }
            get { return _techdetails; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }

        public void ins_techtrans()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[appl].[spinstechtransfer]";

            param = new OleDbParameter("@techproposaldtls", OleDbType.VarChar, 500);
            param.Value = techdetails;
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
            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }

    }

    public class blresearch
    {

        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _resdetls;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;



        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }

        public string resdetls
        {
            set { _resdetls = value; }
            get { return _resdetls; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }

        public void ins_research()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[appl].[spinsresearch]";

            param = new OleDbParameter("@respropdtls", OleDbType.VarChar, 500);
            param.Value = resdetls;
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
            if (recordsaffected > 0)
            {
                msg = dal.oparam[0].Value.ToString();
            }
        }

    }


    public class blstdannouncement
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        private string _transid;
        private string _announcementType;
        private string _announcementTo;
        private string _announcementsubject;
        private string _announcementbody;
        private string _attachmentURL;
        private char _sts;
        private string _rco;
        private DateTime _rcm;
        private Int32 _recordsaffected;
        private string _msg;

        public string transid
        {
            set { _transid = value; }
            get { return _transid; }
        }

        public string announcementType
        {
            set { _announcementType = value; }
            get { return _announcementType; }
        }
        public string announcementTo
        {
            set { _announcementTo = value; }
            get { return _announcementTo; }
        }

        public string announcementsubject
        {
            set { _announcementsubject = value; }
            get { return _announcementsubject; }
        }
        public string announcementbody
        {
            set { _announcementbody = value; }
            get { return _announcementbody; }
        }
        public string attachmentURL
        {
            set { _attachmentURL = value; }
            get { return _attachmentURL; }
        }

        public char sts
        {
            set { _sts = value; }
            get { return _sts; }
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
        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public DataTable vw_intkload()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "SELECT DISTINCT appl_intake FROM appl.tblappldetails where appl_intake IS NOT NULL";
            
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public void ins_stdannouncement()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "spinststdannouncement";

            param = new OleDbParameter("@announcementType", OleDbType.VarChar, 100);
            param.Value = announcementType;
            li_param.Add(param);

            param = new OleDbParameter("@announcementTo", OleDbType.VarChar, 50);
            param.Value = announcementTo;
            li_param.Add(param);


            param = new OleDbParameter("@announcementsubject", OleDbType.VarChar, 1000);
            param.Value = announcementsubject;
            li_param.Add(param);

            param = new OleDbParameter("@announcementbody", OleDbType.VarChar, 100000);
            param.Value = announcementbody;
            li_param.Add(param);

            param = new OleDbParameter("@attachmentURL", OleDbType.VarChar, 1000);
            param.Value = attachmentURL;
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

        public void updt_stdannouncement()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "spupdtstdannouncement";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@announcementType", OleDbType.VarChar, 100);
            param.Value = announcementType;
            li_param.Add(param);


            param = new OleDbParameter("@announcementTo", OleDbType.VarChar, 100);
            param.Value = announcementTo;
            li_param.Add(param);

            param = new OleDbParameter("@announcementsubject", OleDbType.VarChar, 50000);
            param.Value = announcementsubject;
            li_param.Add(param);

            param = new OleDbParameter("@announcementbody", OleDbType.VarChar, 50000);
            param.Value = announcementbody;
            li_param.Add(param);

            param = new OleDbParameter("@attachmentURL", OleDbType.VarChar, 10000);
            param.Value = attachmentURL;
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

        public void del_stdannouncement()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "spdltstdannouncement";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
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

        public DataTable vw_stdannouncement()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "select * from appl.tblstdannouncement where sts='1'";
            
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_stdannouncement_std(string intk)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "select * from appl.tblstdannouncement where announcementTo in ('All','" + intk + "') and announcementType='Student' and sts = '1'";
           
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_supannouncement()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "select * from appl.tblstdannouncement where sts='1' and announcementType = 'supervisor'";
            
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        
        public DataTable vw_stdannouncement_imp()
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "select * from appl.tblstdannouncement where sts='1' and announcementType = 'important'";
            
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }



    }

    public class blnotifications
    {
        public DataAccess dal;
        public OleDbParameter param;
        public List<OleDbParameter> li_param;
        public DataTable mdt;
        public Guid _transid;
        public string _notifisub;
        public string _notifimsg;
        //public char _sts;
        public string _rco;
        //private DateTime _rcm;
        private Int32 _recordsaffected;
        //private string _msg;

        public Guid transid
        {
            set { _transid = value; }
            get { return _transid; }
        }
        public string notifisub
        {
            set { _notifisub = value; }
            get { return _notifisub; }
        }
        public string notifimsg
        {
            set { _notifimsg = value; }
            get { return _notifimsg; }
        }
        //public char sts
        //{
        //    set { _sts = value; }
        //    get { return _sts; }
        //}
        public string rco
        {
            set { _rco = value; }
            get { return _rco; }
        }

        public Int32 recordsaffected
        {
            set { _recordsaffected = value; }
            get { return _recordsaffected; }
        }

        public void ins_notifications()
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "appl.spinsnotification";

            param = new OleDbParameter("@transid", OleDbType.Guid);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@notifisub", OleDbType.VarChar, 1000);
            param.Value = notifisub;
            li_param.Add(param);

            param = new OleDbParameter("@notifimsg", OleDbType.VarChar, 1000);
            param.Value = notifimsg;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            recordsaffected = dal.recordsaffected;
        }

        public DataTable vw_notifications_all(string user)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            if (user == "cpgs")
            {
                dal.sqlcmdstr = "Select * from appl.vw_notification_cpgs where cpgssts in ('0','1') order by rcm desc;";

            }
            else
            {
                dal.sqlcmdstr = "select * from appl.vw_notification  where spvrsts in ('0','1') and applicationid = '" + user + "'  order by rcm desc";

            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_unrdnotifications_count(string ntfcfor)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            if (ntfcfor == "cpgs")
            {
                dal.sqlcmdstr = "select * from appl.vw_notification_cpgs where cpgssts = '0' and sts='0' ";
            }
            else
            {
                dal.sqlcmdstr = "Select * from appl.vw_notification where applicationid = '" + ntfcfor + "' and ";
                dal.sqlcmdstr += " spvrsts = '0' and sts='0'";
                dal.sqlcmdstr += " order by rcm desc";
            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_notifications_modal(string id, string sts)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            if (sts == "cpgs")
            {
                dal.sqlcmdstr = "select * from appl.vw_notification_cpgs where transid='" + id + "'";
            }
            else
            {
                dal.sqlcmdstr = "select * from appl.vw_notification where transid='" + id + "'";
            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_notifications_markasread(Guid transid, string sts)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            if (sts == "cpgs")
            {
                dal.sqlcmdstr = "update appl.vw_notification_cpgs set cpgssts='1' where transid='" + transid + "'";
            }
            else
            {
                dal.sqlcmdstr = "update appl.vw_notification set spvrsts='1' where transid='" + transid + "'";
            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public DataTable vw_clear_rdntfcn(string sts)
        {
            mdt = new DataTable();
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            if (sts == "cpgs")
            {
                dal.sqlcmdstr = "update appl.vw_notification_cpgs set cpgssts='2' where cpgssts='1'";
            }
            else
            {
                dal.sqlcmdstr = "update appl.vw_notification set spvrsts='2' where spvrsts='1' and applicationid ='" + sts + "'";
            }
            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

    }

}