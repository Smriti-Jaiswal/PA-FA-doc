using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using NSDataAccess;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSStudent
{
    public class blstudent
    {

        public DataAccess_sql dal;
        public SqlParameter param;
        public List<SqlParameter> li_param;
        public DataTable mdt, mdt1;
        private string _transid;
        private string _frmmodtransid;
        private string _stdid;
        private string _stage;
        private string _process;
        private string _std_sal;
        private string _std_fname;
        private string _std_mname;
        private string _std_lname;
        private string _std_course;
        private string _std_intake;
        private string _std_area_of_study;
        private string _std_study_type;
        private string _std_discipline;
        private string _std_martialsts;
        private string _std_gender;
        private DateTime _std_dateofbirth;
        private string _std_highestquaily;
        private string _std_nationality;
        private string _std_personalcontact;
        private string _std_alt_personalcontact;
        private string _std_email;
        private string _std_alt_email;
        private string _std_citizenshipno;
        private string _std_passport;

        private string _std_permanentaddress;
        private string _std_ppincode;
        private string _std_pstate;
        private string _std_pcountry;
        private string _std_corrospondanceaddress;
        private string _std_cpincode;
        private string _std_cstate;
        private string _std_ccountry;

        private string _std_fathersal;
        private string _std_fathername;
        private string _std_fathercontactno;
        private string _std_mothersal;
        private string _std_mothername;
        private string _std_mothercontactno;
        private string _std_gurdainsal;
        private string _std_gurdainname;
        private string _std_gurdaincontactno;
        private string _std_docid;
        private string _std_fileupload;
        private DataTable _identification_doc_upload;
        private DataTable _education_dtls_upload;
        private DataTable _job_dtls_upload;
        private DataTable _publication_dtls_upload;
        private DataTable _reserach_fund_upload;
        private string _std_fundingsrc;
        private string _std_research_statement;
        private string _std_research_requirements;
        private string _std_addi_enclosures;
        private string _rco;
        private DateTime _rcm;
        private char _del_sts;
        private string _luo;
        private DateTime _lum;
        private Int32 _recordsaffected;
        private string _msg;
        private string _std_cat;

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
        public string stdid
        {
            set { _stdid = value; }
            get { return _stdid; }
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
        public string std_sal
        {
            set { _std_sal = value; }
            get { return _std_sal; }
        }
        public string std_fname
        {
            set { _std_fname = value; }
            get { return _std_fname; }
        }
        public string std_mname
        {
            set { _std_mname = value; }
            get { return _std_mname; }
        }
        public string std_lname
        {
            set { _std_lname = value; }
            get { return _std_lname; }
        }
        public string std_course
        {
            set { _std_course = value; }
            get { return _std_course; }
        }
        public string std_intake
        {
            set { _std_intake = value; }
            get { return _std_intake; }
        }
        public string std_area_of_study
        {
            set { _std_area_of_study = value; }
            get { return _std_area_of_study; }
        }
        public string std_study_type
        {
            set { _std_study_type = value; }
            get { return _std_study_type; }
        }
        public string std_discipline
        {
            set { _std_discipline = value; }
            get { return _std_discipline; }
        }
        public string std_martialsts
        {
            set { _std_martialsts = value; }
            get { return _std_martialsts; }
        }
        public string std_gender
        {
            set { _std_gender = value; }
            get { return _std_gender; }
        }
        public DateTime std_dateofbirth
        {
            set { _std_dateofbirth = value; }
            get { return _std_dateofbirth; }
        }
        public string std_highestquaily
        {
            set { _std_highestquaily = value; }
            get { return _std_highestquaily; }
        }
        public string std_nationality
        {
            set { _std_nationality = value; }
            get { return _std_nationality; }
        }
        public string std_personalcontact
        {
            set { _std_personalcontact = value; }
            get { return _std_personalcontact; }
        }
        public string std_alt_personalcontact
        {
            set { _std_alt_personalcontact = value; }
            get { return _std_alt_personalcontact; }
        }
        public string std_email
        {
            set { _std_email = value; }
            get { return _std_email; }
        }
        public string std_alt_email
        {
            set { _std_alt_email = value; }
            get { return _std_alt_email; }
        }
        public string std_citizenshipno
        {
            set { _std_citizenshipno = value; }
            get { return _std_citizenshipno; }
        }
        public string std_passport
        {
            set { _std_passport = value; }
            get { return _std_passport; }
        }
        public string std_permanentaddress
        {
            set { _std_permanentaddress = value; }
            get { return _std_permanentaddress; }
        }
        public string std_ppincode
        {
            set { _std_ppincode = value; }
            get { return _std_ppincode; }
        }
        public string std_pstate
        {
            set { _std_pstate = value; }
            get { return _std_pstate; }
        }
        public string std_pcountry
        {
            set { _std_pcountry = value; }
            get { return _std_pcountry; }
        }
        public string std_corrospondanceaddress
        {
            set { _std_corrospondanceaddress = value; }
            get { return _std_corrospondanceaddress; }
        }
        public string std_cpincode
        {
            set { _std_cpincode = value; }
            get { return _std_cpincode; }
        }
        public string std_cstate
        {
            set { _std_cstate = value; }
            get { return _std_cstate; }
        }
        public string std_ccountry
        {
            set { _std_ccountry = value; }
            get { return _std_ccountry; }
        }
        public string std_fathersal
        {
            set { _std_fathersal = value; }
            get { return _std_fathersal; }
        }
        public string std_fathername
        {
            set { _std_fathername = value; }
            get { return _std_fathername; }
        }
        public string std_fathercontactno
        {
            set { _std_fathercontactno = value; }
            get { return _std_fathercontactno; }
        }
        public string std_mothersal
        {
            set { _std_mothersal = value; }
            get { return _std_mothersal; }
        }
        public string std_mothername
        {
            set { _std_mothername = value; }
            get { return _std_mothername; }
        }
        public string std_mothercontactno
        {
            set { _std_mothercontactno = value; }
            get { return _std_mothercontactno; }
        }
        public string std_gurdainsal
        {
            set { _std_gurdainsal = value; }
            get { return _std_gurdainsal; }
        }
        public string std_gurdainname
        {
            set { _std_gurdainname = value; }
            get { return _std_gurdainname; }
        }
        public string std_gurdaincontactno
        {
            set { _std_gurdaincontactno = value; }
            get { return _std_gurdaincontactno; }
        }
        public string std_docid
        {
            set { _std_docid = value; }
            get { return _std_docid; }
        }
        public string std_fileupload
        {
            set { _std_fileupload = value; }
            get { return _std_fileupload; }
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
        public string std_fundingsrc
        {
            get { return _std_fundingsrc; }
            set { _std_fundingsrc = value; }
        }
        public string std_research_statement
        {
            get { return _std_research_statement; }
            set { _std_research_statement = value; }
        }
        public string std_research_requirements
        {
            get { return _std_research_requirements; }
            set { _std_research_requirements = value; }
        }
        public string std_addi_enclosures
        {
            get { return _std_addi_enclosures; }
            set { _std_addi_enclosures = value; }
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
        public string std_cat
        {
            set { _std_cat = value; }
            get { return _std_cat; }
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
        private string _hashid;
        private DataTable _type_tblfeesdlts;
        private string _currency;
        private string _bankslip_url;
        private char _verified_sts;
        private string _receipt_url;
        private string _remarks;
        private string _bnk;

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

        public void updt_stdcommdetails()
        {
            dal = new DataAccess_sql();
            li_param = new List<SqlParameter>();

            dal.sqlcmdstr = "[student].[spupdtcommdtls]";

            param = new SqlParameter("@stdid", SqlDbType.VarChar, 50);
            param.Value = stdid;
            li_param.Add(param);
            
            param = new SqlParameter("@email", SqlDbType.VarChar, 1000);
            param.Value = std_email;
            li_param.Add(param);

            param = new SqlParameter("@contact", SqlDbType.VarChar, 20);
            param.Value = std_personalcontact;
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
        
    }
    
}