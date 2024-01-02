using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.IO;

using NSDataAccess;

namespace nsusrmanagement
{
    public static class usr
    {
        static DataAccess dal;
        static DataTable mdt;
        static List<string> li_roles;
        static OleDbParameter param;
        static List<OleDbParameter> li_param;
        static List<string> id;
        public static string spinsuser(string userid,string passwd,string rco)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[spinstbluser]";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 50);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwd", OleDbType.VarChar, -1);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());
            
            return dal.oparam[0].Value.ToString();
            
        }

        public static string spinslogincredtls(string userid, string passwd, string rco)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[spinsuserlogincredtls]";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 50);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwdnum", OleDbType.VarChar, -1);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            return dal.oparam[0].Value.ToString();
        }
        public static string spusermodify(string userid, string passwd, string luo)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[sp_user_resetpasswd]";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwd", OleDbType.VarChar, -1);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            return dal.oparam[0].Value.ToString();

        }


        public static string spusermodify(string transid, string userid, string passwd, string luo)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[sp_user_modify]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwd", OleDbType.VarChar, -1);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            return dal.oparam[0].Value.ToString();

        }

        public static string spdeluser(string transid, string luo)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[spdeltbluser]";

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

            return dal.oparam[0].Value.ToString();
        }
        public static string spblockuser(string transid, string luo)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[spblocktbluser]";

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

          
            return dal.oparam[0].Value.ToString();
            

        }

        public static string spins_role(string roleid, string roledesc, string rco)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[spinsrole]";

            param = new OleDbParameter("@roleid", OleDbType.VarChar, 50);
            param.Value = roleid;
            li_param.Add(param);

            param = new OleDbParameter("@roledesc", OleDbType.VarChar, -1);
            param.Value = roledesc;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            return  dal.oparam[0].Value.ToString();


        }
        public static string spupdt_role(string transid, string roleid, string roledesc, string luo)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[spupdtrole]";

            param = new OleDbParameter("@transid", OleDbType.VarChar, 50);
            param.Value = transid;
            li_param.Add(param);

            param = new OleDbParameter("@roleid", OleDbType.VarChar, 50);
            param.Value = roleid;
            li_param.Add(param);

            param = new OleDbParameter("@roledesc", OleDbType.VarChar, -1);
            param.Value = roledesc;
            li_param.Add(param);

            param = new OleDbParameter("@luo", OleDbType.VarChar, 50);
            param.Value = luo;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            return dal.oparam[0].Value.ToString();


        }
        public static string sp_delrole(string transid, string luo)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[sp_delrole]";

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
            
            return dal.oparam[0].Value.ToString();
        }
        public static string sp_config_role(string userid, string roleid, char apply, string rco)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "[system].[sp_configrole]";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 50);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@roleid", OleDbType.VarChar, 50);
            param.Value = roleid;
            li_param.Add(param);

            param = new OleDbParameter("@apply", OleDbType.Char, 1);
            param.Value = apply;
            li_param.Add(param);

            param = new OleDbParameter("@rco", OleDbType.VarChar, 50);
            param.Value = rco;
            li_param.Add(param);

            param = new OleDbParameter("@msg", OleDbType.VarChar, 1000);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;
            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            return dal.oparam[0].Value.ToString();
        }

        public static DataTable vw_tblrole()
        {
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from system.tblrole where tblrole.del_sts=0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }

        public static DataTable vw_getdtdpass(string userid)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "Select * from system.userlogincredtls where del_sts='0' and userid=?";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());
            return mdt;
        }
        public static List<string> getusrvalidation(string userid, string passwd)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            id = new List<string>();
            dal.sqlcmdstr = "system.sp_usrvalidation";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwd", OleDbType.VarChar, 500);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@sessionid", OleDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new OleDbParameter("@uid", OleDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;

            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            id.Insert(0, dal.oparam[0].Value.ToString());
            id.Insert(1, dal.oparam[1].Value.ToString());

            return id;
        }

        public static List<string> getusrvalidationall(string userid, string passwd)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            id = new List<string>();
            dal.sqlcmdstr = "system.sp_usrvalidationall";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwd", OleDbType.VarChar, 500);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@sessionid", OleDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new OleDbParameter("@uid", OleDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;

            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            id.Insert(0, dal.oparam[0].Value.ToString());
            id.Insert(1, dal.oparam[1].Value.ToString());

            return id;
        }
        public static List<string> getagentvalidation(string userid, string passwd)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            id = new List<string>();
            dal.sqlcmdstr = "system.sp_agentvalidation";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@passwd", OleDbType.VarChar, 500);
            param.Value = passwd;
            li_param.Add(param);

            param = new OleDbParameter("@sessionid", OleDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            param = new OleDbParameter("@uid", OleDbType.VarChar, 50);
            param.Direction = ParameterDirection.Output;
            li_param.Add(param);

            dal.lparam = li_param;

            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            id.Insert(0, dal.oparam[0].Value.ToString());
            id.Insert(1, dal.oparam[1].Value.ToString());

            return id;
        }
        public static bool userlogout(string sessionid)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();

            dal.sqlcmdstr = "system.sp_usrlogout";

            param = new OleDbParameter("@sessionid", OleDbType.VarChar, 50);
            param.Value = sessionid;
            li_param.Add(param);

            dal.lparam = li_param;

            dal.insertbysp(Clsutility.dbcon.dbcnn_master.ToString());

            if (dal.recordsaffected > 0)
                return true;
            else
                return false;
        }
        public static DataTable getusrlist()
        {
            dal = new DataAccess();

            dal.sqlcmdstr = "select * from system.tbluser where tbluser.del_sts=0";

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
        public static DataTable getusrdata(string userid)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            dal.sqlcmdstr = "select * from system.tbluser where userid=? and tbluser.del_sts=0";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;
        }
        public static List<string> getusroles(string userid)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            li_roles = new List<string>();
            
            dal.sqlcmdstr = " select tbluser.userid 'user',tblrole.roleid role_name,system.tblusroleconfig.* from system.tblusroleconfig";
            dal.sqlcmdstr += " inner join system.tbluser on tbluser.transid=tblusroleconfig.userid and tbluser.del_sts=0";
            dal.sqlcmdstr += " inner join system.tblrole on tblrole.transid=tblusroleconfig.roleid and tblrole.del_sts=0";
            dal.sqlcmdstr += " where tbluser.userid=? and tblusroleconfig.del_sts=0";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            foreach (DataRow dr in mdt.Rows)
            {
                li_roles.Add(dr["roleid"].ToString());
            }

            return li_roles;
           
        }
        public static DataTable vw_menu(string frmmodtransid, List<string> role)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            Int32 _ctr;

            if (role.Count < 2)
            {
                dal.sqlcmdstr = "select tbl1.*, ";
                dal.sqlcmdstr += " (select convert(varchar(4),count(tbl2.transid)) from master.tblmenu_items tbl2 where tbl2.frmmodtransid=convert(varchar(50),tbl1.transid)) num";
                dal.sqlcmdstr += " from master.tblmenu_items tbl1 where tbl1.frmmodtransid=? and tbl1.role = ? order by len(tbl1.sl_no),tbl1.sl_no";

                param = new OleDbParameter("@frmmodtransid", OleDbType.VarChar, 500);
                param.Value = frmmodtransid;
                li_param.Add(param);

                param = new OleDbParameter("@role", OleDbType.VarChar, 1000);
                param.Value = role[role.Count - 1].ToString();
                li_param.Add(param);

                dal.lparam = li_param;
            }
            else
            {
                dal.sqlcmdstr = "select * from (";
                for (_ctr = 0; _ctr < role.Count - 1; _ctr++)
                {
                    dal.sqlcmdstr += "select tbl1.*, ";
                    dal.sqlcmdstr += " (select convert(varchar(4),count(tbl2.transid)) from master.tblmenu_items tbl2 where tbl2.frmmodtransid=convert(varchar(50),tbl1.transid)) num";
                    dal.sqlcmdstr += " from master.tblmenu_items tbl1 where tbl1.frmmodtransid=? and tbl1.role = ?";
                    dal.sqlcmdstr += " union all ";

                    param = new OleDbParameter("@frmmodtransid", OleDbType.VarChar, 500);
                    param.Value = frmmodtransid;
                    li_param.Add(param);

                    param = new OleDbParameter("@role", OleDbType.VarChar, 1000);
                    param.Value = role[_ctr].ToString();
                    li_param.Add(param);
                }

                dal.sqlcmdstr += " select tbl1.*, ";
                dal.sqlcmdstr += " (select convert(varchar(4),count(tbl2.transid)) from master.tblmenu_items tbl2 where tbl2.frmmodtransid=convert(varchar(50),tbl1.transid)) num";
                dal.sqlcmdstr += " from master.tblmenu_items tbl1 where tbl1.frmmodtransid=? and tbl1.role = ?";
                dal.sqlcmdstr += "  ) tbl3 order by len(tbl3.sl_no),tbl3.sl_no";

                param = new OleDbParameter("@frmmodtransid", OleDbType.VarChar, 500);
                param.Value = frmmodtransid;
                li_param.Add(param);

                param = new OleDbParameter("@role", OleDbType.VarChar, 1000);
                param.Value = role[role.Count - 1].ToString();
                li_param.Add(param);

                dal.lparam = li_param;
            }

            

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            return mdt;

        }
        public static bool get_page_auth(string userid,string pageurl)
        {
            dal = new DataAccess();
            li_param = new List<OleDbParameter>();
            
            dal.sqlcmdstr = "select * from master.tblmenu_items";
            dal.sqlcmdstr += " inner join system.tblrole on tblmenu_items.role=tblrole.transid";
            dal.sqlcmdstr += " inner join system.tblusroleconfig on tblrole.transid=tblusroleconfig.roleid";
            dal.sqlcmdstr += " inner join system.tbluser on tblusroleconfig.userid=tbluser.transid";
            dal.sqlcmdstr += " where tbluser.userid=? and right(href,len(href)-2)=right(?,len(?)-1)";

            param = new OleDbParameter("@userid", OleDbType.VarChar, 500);
            param.Value = userid;
            li_param.Add(param);

            param = new OleDbParameter("@href", OleDbType.VarChar, 500);
            param.Value = pageurl;
            li_param.Add(param);

            param = new OleDbParameter("@href", OleDbType.VarChar, 500);
            param.Value = pageurl;
            li_param.Add(param);

            dal.lparam = li_param;

            mdt = dal.view(Clsutility.dbcon.dbcnn_master.ToString());

            if (dal.recordsaffected > 0)
                return true;
            else
                return false;
        }
    }

    public class encryption
    {
        public string encrypt(string clearText)
        {
            string EncryptionKey = "KTESANSDKF#$#@DFFDSn89345DFSf56";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string decrypt(string cipherText)
        {
            string EncryptionKey = "KTESANSDKF#$#@DFFDSn89345DFSf56";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
