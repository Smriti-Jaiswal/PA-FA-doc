using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSMailBody
{
    public class blmailbody
    {
        private static string _content,_headercontent,_footercontent;
        private static string header_content()
        {
            _headercontent = null;
            _headercontent += "<body>";
            _headercontent += "DISCLAIMER: PLEASE DO NOT REPLY TO THIS MAIL. REPLIES TO THIS MAIL IS ROUTED TO AN UNMONITORED MAILBOX.";
            _headercontent += "<hr />";
            return _headercontent;
        }
        private static string footer_content()
        {
            _footercontent = null;
            _footercontent += "<div style='text-align:center;'>";
            _footercontent += "<hr />";
            _footercontent += "<b>© LUC, Malaysia 2017-18, All Rights Reserved.</b>";
            _footercontent += "<br />";
            _footercontent += "<div>";
            _footercontent += "<div style='color:#F00'><b>";
            _footercontent += "Lincoln University College, Malaysia</b></div>";
            _footercontent += "</div>";
            _footercontent += "<br />";
            _footercontent += "<b>";
            _footercontent += "Wisma Lincoln, No. 12-18, Jalan SS 6/12, 47301 Petaling Jaya, Selangor Darul Ehsan, Malaysia <br />";
            _footercontent += "(Near Kelana Jaya Giant and opposite Paradigm Mall, Kelana Jaya)<br />";
            _footercontent += "Ph: 1300 880 111 (Malaysia); + 603 - 7806 3478 (International)<br /> Email: info@lincoln.edu.my</b><br />";
            _footercontent += "Please do not reply directly to this email. It was sent from an unattended mailbox.<br />";
            _footercontent += "For correspondence, please use the below mail:<br /> info@lincoln.edu.my</div>";
            _footercontent += "</body>";

            return _footercontent;
        }

        public static string admissionmail(string applid, string name, string crs, string appldt, string stage, string process)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Prospective Applicant,</b></div><br />";
            _content += "<div>We have received the application to enrol in our program with the following details.</div><br /><br />";

            _content += "<table style='border:1px black solid;'>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Name: </td><td style='border:1px black solid;'>" + name + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Program: </td><td style='border:1px black solid;'>" + crs + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Date of Application <br /> (DD/MM/YYYY):</td><td style='border:1px black solid;'> " + appldt + "</td></tr>";
            _content += "</table>";

            _content += "</b><br />Your application is right now under the following status.<br /><br />";

            _content += "<b><table style='border:1px black solid;'>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Application ID: </td><td style='border:1px black solid;'>" + applid + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Current Stage: </td><td style='border:1px black solid;'>" + stage + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Application In Process For: </td><td style='border:1px black solid;'>" + process + "</td></tr>";
            _content += "</table></b>";

            _content += "<br /><br />";

            _content += "You will be notified immediately after any changes occur to your status through your registered mail." +
            " We request you to check your mail regularly so that you do not miss any updates. We also have the facility for you to check the status" +
            " manually by the following process.";

            _content += "<br /><br /></div>";

            _content += "To check the status of your application, please visit : https://phdresearch.lincolnedu.education/guest/frmapplication.aspx";
            _content += " and choose 'Application Status' from Application Area. You will be asked for your admission id, and on providing those credentials, you can check the status.";
            _content += " For any other assistance, please mail us at: <i>phd_cpgs@lincoln.edu.my</i><br /><br />";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }
        
        public static string sprvsrapplmail(string applid, string name, string appldt,string org_name, string stage, string process)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir,</b></div><br />";
            _content += "<div>We have received the application to enroll as supervisor with the following details</div><br /><br />";

            _content += "<table style='border:1px black solid;'>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Name : </td><td style='border:1px black solid;'>" + name + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Date of Application (DD/MM/YYYY) :</td><td style='border:1px black solid;'> " + appldt + "</td></tr>";
            _content += "</table>";

            _content += "</b><br />Your application is right now under the following status<br /><br />";

            _content += "<b><table style='border:1px black solid;'>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Application ID : </td><td style='border:1px black solid;'>" + applid + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Present Institution/Organization Name: </td><td style='border:1px black solid;'>" + org_name + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Current Stage : </td><td style='border:1px black solid;'>" + stage + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Application in Process For : </td><td style='border:1px black solid;'>" + process + "</td></tr>";
            _content += "</table></b>";

            _content += "<br /><br />";

            _content += "You will be notified immediately after any changes of your status through your registered mail." +
                " We request you to check your mail on regular basis so that you don't miss any updates.";

            _content += "<br /><br /></div>";
            
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br />";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string spvrapplcommentmail(string transid, string name, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir/Madam,</b></div><br />";
            _content += "<div>You have received a comment for your Ph.D supervisor application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : <a href='http://phdresearch.lincolnedu.education/guest/frmspvrapplcomments.aspx?id=" + transid + "'>Click Me</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string spvrapplluccommentmail(string transid, string name, string applid, string rid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>You have received a comment for one Ph.D supervisor application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : <a href='http://phdresearch.lincolnedu.education/guest/frmapplcomments.aspx?id=" + transid + "&rid=" + rid + "'>Click Me</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string spvrdeancommentmail(string transid, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir,</b></div><br />";
            _content += "<div>You have received a comment for the Ph.D supervisor application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : http://phdresearch.lincolnedu.education/guest/frmspvrappldeancomments.aspx?id=" + transid;
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string applcommentmail(string transid, string name, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>You have received a comment for your Ph.D application number: " + applid + "</div><br /><br />";

            _content += "<div>To check the details. <br /><br />please click: <a href='http://phdresearch.lincolnedu.education/guest/frmapplcomments.aspx?id=" + transid + "'>Click Me</a>";
            _content += " <br /><br />And read through from the application area. You can reply to this from the comments section.<br />";
            _content += " For any further assistance, please mail us at: <br /><i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string applluccommentmail(string transid, string name, string applid,string rid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>You have received a comment for one Ph.D application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : <a href='http://phdresearch.lincolnedu.education/guest/frmapplluccomments.aspx?id=" + transid+"&rid="+rid+"'>Click Me</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string applconofferltrmail(string transid, string name, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>CONGRATULATIONS! <br />You have received the conditional offer letter for your Ph.D application number : " + applid + " in the attachment of this mail.";
            _content += "<br />You need to fill up and sign the acknowledgement letter, scholarship form and pay the registration fees to the given bank account for further process. After you pay the fees; please upload the receipt, the original color scan copy of signed acknowledge letter and scholarship form by clicking <a href='http://phdresearch.lincolnedu.education/guest/frmpayment.aspx?id=" + transid + "'>Click Me!!!</a></div><br /><br />";

            _content += "<div>To check any further details <br /><br />please click : <a href='http://phdresearch.lincolnedu.education/guest/frmapplcomments.aspx?id=" + transid+ "'>Click Me!!!</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string applconofferltrorgmail(string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Partner,</b></div><br />";
            _content += "<div>CONGRATULATIONS! <br />The conditional offer letter for your Ph.D applicant number : " + applid + " in the attachment of this mail.";
            _content += "<br />The applicant need to sign the acknowledgement letter and pay the registration fees to the given bank account and upload both receipt and the original color scan copy of signed acknowledge letter in the link given in their mail for further process.</div><br /><br />";

            _content += "<div>For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string applcommentloginmail(string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir/Madam,</b></div><br />";
            _content += "<div>You have received a comment for the Ph.D application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details by login into your account";
            _content += " and read through from application area. You can also reply from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string applpaymentverifymail(string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir/Madam,</b></div><br />";
            _content += "<div>You have received a payment notification for the Ph.D application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details by login into your account";
            _content += " and read through from application area. You can also reply from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string stdregmail(string name,string stdid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>You are now registered as a Ph.D scholar under Lincoln University College, Malaysia.</div><br />";
            _content += "An account has been created for you in our system by your student id. <br />";
            _content += "To check the details you need to login into your account with the credentials given below</div><br />";
            _content += "<b>URL : <a href='https://phdresearch.lincolnedu.education/student/stdlogin.aspx' target='_blank'>https://phdresearch.lincolnedu.education/student/stdlogin.aspx<a> </b><br />";
            _content += "<b>Username : " + stdid + "</b><br />";
            _content += "<b>Password : 9876543210</b><br /><br />";
            _content += "<div><a href='https://phdresearch.lincolnedu.education/PhD%20Candidate%20Portal.mp4'>Please click here to download the presentation on how you can access LLS student portal.</ a><br/>";
            _content += "<div>For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string deancommentmail(string transid, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir,</b></div><br />";
            _content += "<div>You have received a comment for the Ph.D application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : http://phdresearch.lincolnedu.education/guest/frmappldeancomments.aspx?id=" + transid;
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string deanapprovalmail(string transid, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Sir,</b></div><br />";
            _content += "<div>We have received a application for Ph.D [Application number : " + applid + "] under your faculty. Please provide your decision towards the admission of this applicant under LUC.</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : http://phdresearch.lincolnedu.education/guest/frmappldeancomments.aspx?id=" + transid;
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string demomail(string msg)
        {
            _content = null;
            _content += header_content();

            _content += msg;
            _content += "<br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LEPL Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }
        public static string passwordreset(string name, string lid,string hashid,string uid)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Dear "+ name + ",</b></div><br /><br />";
            _content += "<div>As per your request the password reset link has been sent in this E-Mail. Please click on the link to reset your password.</div><br /><br />";
            //_content += "URL : <a href='https://phdresearch.lincolnedu.education/guest/passwordreset.aspx?lid="+lid+ "&hashid=" + hashid + "&uid="+uid+"'><u>***Click Me***</u></a><br /><br />";
            _content += "URL : <a href='https://phdresearch.lincolnedu.education'><u>***Click Me***</u></a><br /><br />";
            _content += "Password : 9876543210";
            _content += "<br /><br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>LUC Online Mail Service</b>";
            _content += footer_content();
            return _content;
        }
        public static string passwordreset_student(string name, string lid, string hashid, string uid)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Dear " + name + ",</b></div><br /><br />";
            _content += "<div>As per your request the password reset link has been sent in this E-Mail. Please click on the link to reset your password.</div><br /><br />";
            _content += "<div>User Name :" + uid + "</div><br />";
            _content += "<div>Password : 9876543210</div><br /><br />";
            //_content += "URL : <a href='https://phdresearch.lincolnedu.education/guest/passwordreset.aspx?lid="+lid+ "&hashid=" + hashid + "&uid="+uid+"'><u>***Click Me***</u></a><br /><br />";
            _content += "URL : <a href='https://phdresearch.lincolnedu.education/student/stdlogin.aspx'><u>***Click Me***</u></a><br /><br />";
            _content += "<br /><br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>LUC Online Mail Service</b>";
            _content += footer_content();
            return _content;
        }
        public static string empleavestsmail(string empame, string id, string deptname, string designame, string leavetype, string leavedts, string reason, string doa, string sts)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Dear Sir,</b></div><br /><br />";
            _content += "<div>The following employee has requested for a leave as per the following details please check;</div><br /><br />";
            _content += "Name : " + empame + "<br />";
            _content += "ID : " + id + "<br />";
            _content += "Department : " + deptname + "<br />";
            _content += "Designation : " + designame + "<br />";
            _content += "Leave Type : " + leavetype + "<br />";
            _content += "Leave Dates : " + leavedts + "<br />";
            _content += "Reason : " + reason + "<br />";
            _content += "Date of Apply : " + doa + "<br /><br />";

            _content += " The Leave Status is : <b>" + sts + "</b>";
            
            _content += "<br /><br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>Lepl Online Mail Service</b>";
            _content += footer_content();
            return _content;
        }
        public static string empleavestsmailtoemp(string empame, string id, string deptname, string designame, string leavetype, string leavedts, string reason, string doa, string sts)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Dear "+ empame + ",</b></div><br /><br />";
            _content += "<div>Your requested leave as per the following details is <b>"+sts+"</b> ; Please check.</div><br /><br />";
            _content += "Name : " + empame + "<br />";
            _content += "ID : " + id + "<br />";
            _content += "Department : " + deptname + "<br />";
            _content += "Designation : " + designame + "<br />";
            _content += "Leave Type : " + leavetype + "<br />";
            _content += "Leave Dates : " + leavedts + "<br />";
            _content += "Reason : " + reason + "<br />";
            _content += "Date of Apply : " + doa + "<br /><br />";

            _content += " Your Leave Status is : <b>" + sts + "</b>";

            _content += "<br /><br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>Lepl Online Mail Service</b>";
            _content += footer_content();
            return _content;
        }

        public static string sendusernameandpass(string username, string password, string url)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Supervisor,</b></div><br />";
            _content += "<div>With due esteem we are pleased to inform you that you have been selected for the post of Supervisor. Please go through the login credentials to access your account:</div><br /><br />";
            _content += " <a href=" + url + ">Click here</a> to login<br /><br />";
            _content += "<table style='border:1px black solid;'>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>User Name :</td><td style='border:1px black solid;'> " + username + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Password :</td><td style='border:1px black solid;'> " + password + "</td></tr>";
            _content += "</table>";
            _content += "<br /><br /></div>";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br />";
            _content += " Wish you ALL THE BEST.<br/>";
            _content += " We look forward to welcome you aboard.<br/><br/>";
            _content += " Thanks & Regards,";
            _content += "<b><br /> LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string resendusernameandpass(string username, string password, string url)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Supervisor,</b></div><br />";
            _content += "<div><b> Greetings from Lincoln University College, Malaysia (A Five Star Rating University & holding THE World University Ranking 401+ & 80th (Quality Education 2020)) </b></div><br /><br />";
            _content += "<div>With due esteem, we are pleased to inform you that you have been approved as the Supervisor of the Lincoln University College. </div><br />";
            _content += "<div> Please visit the mentioned URLs and use the provided username and password to access your resources and your student data and their research progress.</div><br />";
            
            _content += "<table style='border:1px black solid;'>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>URL :</td><td style='border:1px black solid;'> https://phdresearch.lincolnedu.education/ </td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>User Name :</td><td style='border:1px black solid;'> " + username + "</td></tr>";
            _content += "<tr style='border:1px black solid;'><td style='border:1px black solid;'>Password :</td><td style='border:1px black solid;'> " + password + "</td></tr>";
            _content += "</table>";
            _content += " <a href=" + url + ">Click here</a> to login<br /><br />";
            _content += "<br /><br /></div>";
            _content += " For any other assistance please mail us at <i>postgraduate@lincoln.edu.my </i><br /><br />";
            _content += " Wish you ALL THE BEST.<br/>";
            _content += " We look forward to welcome you aboard.<br/><br/>";
            _content += " Thanks & Regards,";
            _content += "<b><br /> LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string appoinmentltrmail(string type,string name, string stdname, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "We are pleased to offer you the appointment letter as "+type+" for the student named "+stdname+" at the Lincoln University College, Malaysia.<br />";
            _content += "Find attached herewith the appointment letter for your kind perusal.<br />";
            _content += "We wish you all the very best in your career with our organization. <br /><br />";
            _content += "For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string coursework_completion_ltter(string name)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Dear " + name + ",</b></div><br /><br />";
            _content += "<div>This is your Course work completion letter";


            _content += "<br /><br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>Lepl Online Mail Service</b>";
            _content += footer_content();
            return _content;
        }

        public static string emailchangeconfirmmail_admin(string Name, string stdid)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Dear Sir/Madam,</b></div><br /><br />";
            _content += "<div>We are pleased to inform you that the applicant<br /><br />";
            _content += "Applicant Name :" + Name + "<br />";
            _content += "Student ID :" + stdid + "<br /><br />";
            _content += "has been registered as student today. Thus, we request you kindly create the e-mail ID for this registered Ph.D. scholar & update in the Student portal.<br />";
            _content += "To check the details please click: <a href='https://phdresearch.lincolnedu.education/redirect/frmemaildtls.aspx?stdid=" + stdid + "'>Click Here</a>";
            _content += "<br /><br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>Lepl Online Mail Service</b>";
            _content += footer_content();
            return _content;
        }

        public static string emailchangeconfirmmail_admin_user(string Name, string stdid, string email, string password, string passwordnum)
        {
            _content = null;

            _content += header_content();

            _content += "<img src=" + "http://phdresearch.lincolnedu.education/uploadedfiles/studymaterials/LincolnLogo.jpg" + " alt=" + "LUC Logo" + " width=" + "170" + " height=" + "60" + "/><br /><br/>";
            _content += "<div><b>Dear " + Name + "</b>,<br/><b>Student ID: " + stdid + "</b></div><br/>";
            _content += "<div><p>Greetings from Lincoln University College, Malaysia (A <b>Five Star</b> Rating University, 351 in QS Asia University Rankings 2021 & holding<b> THE World University Rankings 35<sup>th</sup></b> on (Quality Education 2021))</b></p></div>";
            _content += "<div><p>Thank you for choosing our prestigious Lincoln University College (LUC) for pursuing your Ph.D. As you are now a registered student of LUC, being a privileged PhD scholar, you are entitled with the below student portal for continuing your research and all other coursework assessment. Please follow the below credentials to access your student portal.</p>";
            _content += "</div>";
            _content += "<div>Please visit under mentioned URL and use the provided user name and password to access your resources.</div>";
            _content += "<div>URL : <a href='https://phdresearch.lincolnedu.education/student/stdlogin.aspx'>https://phdresearch.lincolnedu.education/student/stdlogin.aspx</a>";
            _content += "<br />Username : " + stdid + "<br />";
            _content += "Password : " + passwordnum + "<br /><br /></div>";

            _content += "<div><p>Please download the syllabus, study materials of Compulsory Coursework, download the sample RD Forms, Academic & Research Schedule plan which are uploaded in the student online portal. Please read Academic & Research Schedule plan carefully & other links in " + "<b>Quick Reference</b>" + " section & upload the necessary RD forms in student portal after filling up with your sign as per the schedule. Please upload the documents of Compulsory Course completion letter, International Conference Attend & Article Publications etc. time to time. </p></div><br/>";
            _content += "<div><p>We also pleased to inform you that being a PhD scholar, you are eligible to hold a mail id under University domain throughout your PhD research with us. Below mentioned details you can use for accessing your Lincoln University mail account.</p></div>";
            _content += "<div>URL : <a href='https://login.microsoftonline.com'>https://login.microsoftonline.com</a>";
            _content += "<br /> E-Mail ID : " + email + "<br />";
            _content += "Password : " + password + "</div><br />";

            _content += "<div><font color=" + "Red" + ">Note</font>: All publications and conference attending work you should do from now onwards by using your Lincoln University e-mail id. Please be reminded that any publications without using Lincoln mail will not be accepted by our Senet body for inclusion towards your PhD research.</div><br/>";
            _content += "<div><p>Last but not the least, we would like to provide you a guideline presentation for convenient using of our student portal. Don’t forget to go through it in details so that you will have a complete idea of uploading necessary information/documents and as well as communicating with related officials whenever required.</p></div><br/>";
            _content += "<div><a href='https://phdresearch.lincolnedu.education/PhD%20Candidate%20Portal.mp4'>Please click here to download the presentation on how you can access LLS student portal.</ a><br/>";

            _content += "<br/>For any further assistance for academic guide kindly e - mail at phd_cpgs@lincoln.edu.my</div>";

            _content += "<br /><b>Thanks and Regards,</b>";
            _content += "<br/>Centre of Postgraduate Studies";
            _content += "<br/>Lincoln University College, Malaysia";
            _content += "<br/>Email : phd_cpgs@lincoln.edu.my";
            _content += footer_content();
            return _content;
        }

        public static string emailforthesis(string spvrname, string name, string stdid)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Respected " + spvrname + ",</b></div><br /><br />";
            _content += "<div>We are pleased to inform you that your student<br /><br />";
            _content += "<br />Name : " + name + "<br />";
            _content += "<br /> Student  ID : " + stdid + "<br />";
            _content += "<div>has uploaded the Thesis in the student portal.Please check and do the needful.</div>";
            _content += "<div><a href='https://phdresearch.lincolnedu.education/redirect/docsubmission_spvr.aspx?id=" + stdid + "'>click here</a></div><br /><br />";
            _content += "<br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>Lincoln Unversity college, Malaysia</b>";
            _content += footer_content();
            return _content;
        }

        public static string emailforresdoc(string cpgs, string name, string stdid)
        {
            _content = null;

            _content += header_content();

            _content += "<div><b>Respected " + cpgs + ",</b></div><br /><br />";
            _content += "<div>We are pleased to inform you that your student<br /><br />";
            _content += "<br />Name : " + name + "<br />";
            _content += "<br /> Student  ID : " + stdid + "<br />";
            _content += "<div>has uploaded the Research Document in the student portal.Please check and do the needful.</div>";
            _content += "<div><a href='https://phdresearch.lincolnedu.education/redirect/docsubmission_cpgs.aspx?id=" + stdid + "'>click here</a></div><br /><br />";
            _content += "<br /><b>Thanks and Regards,</b>";
            _content += "<br /><b>Lincoln Unversity college, Malaysia</b>";
            _content += footer_content();
            return _content;
        }

        public static string stdsrvcommentmail(string stdid, string applname, string srvcsubject)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear,</b><br/>" + applname + "<br/> Student ID :" + stdid + "</div><br />";
            _content += "<div>You have received a comment for your service request of : " + srvcsubject + "</div><br /><br />";
            _content += "<div>To check the details <br /><br />please click : <a href='http://phdresearch.lincolnedu.education/student/ServiceRequest.aspx?id=" + stdid + "'>Click Me</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }

        public static string stdsrvcommentmail_partner(string lblpartid, string lblheadname, string srvcsubject)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear,</b>" + lblheadname + "<br/></div><br />";
            _content += "<div><b>Partner ID,</b>" + lblpartid + "<br/></div><br />";
            _content += "<div>You have received a comment for your service request of : " + srvcsubject + "</div><br /><br />";
            _content += "<div>To check the details <br /><br />please click : <a href='https://phdresearch.lincolnedu.education/'>Click Me</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }

        public static string srvcommentmail(string name, string applid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>You have received a comment for service request of  your Ph.D applicant of application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : <a href='http://phdresearch.lincolnedu.education/login.aspx'>Click Me</a>";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }

        public static string srvcluccommentmail_partner(string name, string applid, string rid, string hfvappltransid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear," + name + ",</b></div><br />";
            _content += "<div>You have received a comment for service request of your Collaborative Partner of application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : <a href='https://phdresearch.lincolnedu.education/redirect/mycommunicationdtls_partner.aspx?id=" + hfvappltransid + "'>click here</a></div><br /><br />";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }
        public static string srvcluccommentmail(string name, string applid, string rid,string hfvappltransid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + name + ",</b></div><br />";
            _content += "<div>You have received a comment for service request of  your Ph.D applicant of application number : " + applid + "</div><br /><br />";

            _content += "<div>To check the details <br /><br />please click : <a href='https://phdresearch.lincolnedu.education/cpgs/mycommunicationdtls_cpgs.aspx?id=" + hfvappltransid + "'>click here</a></div><br /><br />";
            _content += " <br /><br />and read through from application area. You can reply to this from comments section.<br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }
        public static string topicemail(string name, string stdid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Name " + name + ",</b></div><br />";
            _content += "<b>Student Id : " + stdid + "</b><br />";
            _content += "<div>For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";

            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";

            _content += footer_content();
            return _content;
        }
        public static string stdsrvmail(string spvrname, string stdid, string applid, string stdname, string body)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + spvrname + ",</b><br />"; ;
            _content += "<div>You have received a new service request of : </div><br />";
            _content += "<b>Student Name : " + stdname + "</b><br />";
            _content += "<b>Student ID : " + stdid + "</b><br />";
            _content += "<b>" + body + "</b><br />";
            _content += "<div>To reply of this communication please <a href='https://phdresearch.lincolnedu.education/supervisor/mycommunicationdtls_spvr.aspx?id=" + applid + "'>click here</a></div><br /><br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }
        public static string stdsrvmailcpgs(string stdid, string applid, string stdname,string body)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Post Graduate, </b><br/><br />";
            _content += "<div>You have received a new service request of : </div><br />";
            _content += "<b>Student Name : " + stdname + "</b><br />";
            _content += "<b>Student ID : " + stdid + "</b><br />";
            _content += "<b>" + body + "</b><br />";
            _content += "<div>To reply of this communication please <a href='https://phdresearch.lincolnedu.education/cpgs/mycommunicationdtls_cpgs.aspx?id=" + applid + "'>click here</a></div><br /><br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }

        public static string stdpartmailcpgs(string partnerid, string applid, string insname, string inshname, string body)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Post Graduate, </b><br/><br />";
            _content += "<div>You have received a new service request from Collaborative Partner: </div><br />";
            _content += "<b>Name Of The Institution : " + insname + "</b><br />";
            _content += "<b>Partner ID : " + partnerid + "</b><br />";
            _content += "<b>Institute Head Name : " + inshname + "</b><br />";
            _content += "<b>" + body + "</b><br />";
            _content += "<div>To reply of this communication please <a href='https://phdresearch.lincolnedu.education/redirect/mycommunicationdtls_partner.aspx?id=" + applid + "'>click here</a></div><br /><br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }

        public static string stdmailforpartbycpgs(string partnerid, string body)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear "+ partnerid + ", </b><br/><br />";
            _content += "<div>You have received a new service request from Post Graduate Department: </div><br />";
            _content += "<b>" + body + "</b><br />";
            _content += "<div>To reply of this communication please login your portal <a href='https://phdresearch.lincolnedu.education'>click here</a></div><br /><br />";
            _content += "For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }
        public static string spvrpaymtdtls(string spvrname, string stdname, string stdid, string stdsem)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear " + spvrname + "</b><br/><br />";
            _content += "<div>We are pleased to inform you that your supervisor remuneration has been paid by the University for the below mentioned student : </div><br /><br />";
            _content += "<b>Student Name : " + stdname + "</b><br />";
            _content += "<b>Student ID : " + stdid + "</b><br />";
            _content += "<b>Semester : " + stdsem + "</b><br />";
            _content += "<div>The payment slip has already been uploaded in your supervisor portal. You can check annd confirm.</div><br /><br />";
            _content += " For any other assistance please mail us at <i>phd_cpgs@lincoln.edu.my</i><br /><br /></div>";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }
        public static string stdmailforreuploaddoc(string applicationid)
        {
            _content = null;
            _content += header_content();
            _content += "<div><b>Dear Post Graduate Department, </b><br/><br />";
            _content += "<div>You have received re-uploaded documents from "+ applicationid + "</div><br />";
            _content += "Thanks & Regards,";
            _content += "<b><br />LUC Online Mail Service</b><br />";
            _content += footer_content();
            return _content;
        }
    }
}
