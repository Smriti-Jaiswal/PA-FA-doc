using globalcontrols;
using NSDocumentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static NSDocumentation.blmqapadocs;
using static NSDocumentation.blupdatemqapadocs;
public partial class mqadocumentationlist : System.Web.UI.Page
{
    private HiddenField hfield;
    private HiddenField hdntrans;
    private HiddenField hdfield;
    private HiddenField hdnid;
    private HiddenField htransidfield;
    private TextBox conditions;
    private TextBox remarks;
    private TextBox initials;
    private Label con;
    private Label re;
    private Label init;
    public object MessageBox { get; private set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataBind();
            updaterepeater.DataBind();
            deletemqarepeater.DataBind();
        }
    }
    protected void ddlprogram_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel3.Visible = true;
    }
    protected void btn_mqapasave_Click(object sender, EventArgs e)
    {
        blmqapadocs obj = new blmqapadocs();
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            Repeater Repeater2 = (Repeater)(Repeater1.Items[i].FindControl("Repeater2"));
            Repeater parepeater = (Repeater)(Repeater1.Items[i].FindControl("parepeater"));
            for (int J = 0; J < parepeater.Items.Count; J++)
            {

                obj.programid = Guid.Parse(ddlprogram.SelectedValue);
                obj.docid = Guid.Parse(((HiddenField)parepeater.Items[J].FindControl("hfpatransid")).Value);
                obj.conditions = ((TextBox)parepeater.Items[J].FindControl("txtconditions")).Text;
                obj.remarks = ((TextBox)parepeater.Items[J].FindControl("txtremarks")).Text;
                obj.aqdinitial = ((TextBox)parepeater.Items[J].FindControl("txtaqdinitial")).Text;
                obj.rco = Session["user"].ToString();
                if (obj.remarks != "" && obj.aqdinitial != "" && obj.conditions != "")
                {
                    obj.insertmqapa();
                }

            }
            //Repeater parepeater = (Repeater)(Repeater1.Items[i].FindControl("parepeater"));
            //for (int k = 0; k < parepeater.Items.Count; k++)
            //{
            //    obj.programid = Guid.Parse(ddlprogram.SelectedValue);
            //    obj.docid = Guid.Parse(((HiddenField)parepeater.Items[k].FindControl("hfpatransid")).Value);
            //    obj.conditions = ((TextBox)parepeater.Items[k].FindControl("txtconditions")).Text;
            //    obj.remarks = ((TextBox)parepeater.Items[k].FindControl("txtremarks")).Text;
            //    obj.aqdinitial = ((TextBox)parepeater.Items[k].FindControl("txtaqdinitial")).Text;
            //    obj.rco = Session["user"].ToString();
            //    obj.insertmqapa();
            //}

            //if (i == 12) { 
                for (int j = 0; j < Repeater2.Items.Count; j++)
                {
                    TextBox txt= ((TextBox)Repeater2.Items[j].FindControl("TextBox1"));
                    TextBox txt1=((TextBox)Repeater2.Items[j].FindControl("TextBox2"));
                    TextBox txt2= ((TextBox)Repeater2.Items[j].FindControl("TextBox3"));
                  RadioButtonList rvp=((RadioButtonList)Repeater2.Items[j].FindControl("RadioButtonList1"));

                    obj.programid = Guid.Parse(ddlprogram.SelectedValue);
                    obj.docid = Guid.Parse(((HiddenField)Repeater2.Items[j].FindControl("hftransid")).Value);
                    // obj.conditions = ((RadioButtonList)Repeater2.Items[j].FindControl("RadioButtonList1")).Text;
                    obj.remarks = "";
                    obj.aqdinitial = "";
                    if (txt.Visible)
                    {
                        obj.conditions = txt.Text;
                    }
                    else if (txt1.Visible)
                    {
                        obj.conditions = txt1.Text;
                    }
                    else if (txt2.Visible)
                    {
                        obj.conditions = txt2.Text;
                    }
                    else if (rvp.Visible)
                    {
                        obj.conditions = rvp.SelectedValue;
                    }

                    //obj.conditions = ((TextBox)Repeater2.Items[j].FindControl("TextBox1")).Text;
                    //obj.conditions = ((TextBox)Repeater2.Items[j].FindControl("TextBox2")).Text;
                    //obj.conditions = ((TextBox)Repeater2.Items[j].FindControl("TextBox3")).Text;
                    obj.rco = Session["user"].ToString();

                    if (txt.Text.Length>0 || txt1.Text.Length > 0 || txt2.Text.Length > 0 || rvp.SelectedValue !="")
                    {
                        obj.insertmqapa();
                    }
               
            }
          //  }
            //if (obj.remarks != "" && obj.aqdinitial != "" && obj.conditions != "")
            //{

            //}

            gc_app.message(this, obj.msg);
            Repeater1.DataBind();
            ddlprogram.SelectedValue = "";
            hfTab.Value = "insertmqapa";
        }
    }
    protected void mqapa_Click(object sender, EventArgs e)
    {
        papanel.Visible = true;
    }
    protected void ddlselectpro_SelectedIndexChanged(object sender, EventArgs e)
    {
        updaterepeater.DataBind();
        blupdatemqapadocs objvwbyprogid = new blupdatemqapadocs();
        DataTable dtbl = new DataTable();
        dtbl = objvwbyprogid.vwbyprogid(Guid.Parse(ddlselectpro.SelectedValue));
        hfield = new HiddenField();
        conditions = new TextBox();
        remarks = new TextBox();
        initials = new TextBox();

        //for (int i = 0, j = 0; i < updaterepeater.Items.Count && j < dtbl.Rows.Count; i++, j++)
        for (int i = 0; i < updaterepeater.Items.Count; i++)
        {
            for (int j = 0; j < dtbl.Rows.Count; j++)
            {

                HiddenField hdn = ((HiddenField)updaterepeater.Items[i].FindControl("hfuptransid"));
                hfield.Value = dtbl.Rows[j]["docid"].ToString();
                if (hdn.Value == hfield.Value)
                {
                    HiddenField hdntrans = ((HiddenField)updaterepeater.Items[i].FindControl("HiddenField1"));
                    conditions = ((TextBox)updaterepeater.Items[i].FindControl("txtcon"));
                    remarks = ((TextBox)updaterepeater.Items[i].FindControl("txtre"));
                    initials = ((TextBox)updaterepeater.Items[i].FindControl("txtaqdinit"));
                    conditions.Text = dtbl.Rows[j]["conditions"].ToString();
                    remarks.Text = dtbl.Rows[j]["remarks"].ToString();
                    initials.Text = dtbl.Rows[j]["aqdinitial"].ToString();
                    hdntrans.Value = dtbl.Rows[j]["transid"].ToString();
                    hfTab.Value = "updatemqapa";
                }
            }
        }
        Panel2.Visible = true;
    }
    protected void btnupmqapa_Click(object sender, EventArgs e)
    {
         blupdatemqapadocs obj = new blupdatemqapadocs();

        htransidfield = new HiddenField();
        for (int i = 0; i < updaterepeater.Items.Count; i++)
        {
            string hdntrans = ((HiddenField)updaterepeater.Items[i].FindControl("HiddenField1")).Value.ToString();
            HiddenField hdn = ((HiddenField)updaterepeater.Items[i].FindControl("hfuptransid"));
            if (hdntrans == "")
            {
                obj.transid = System.Guid.NewGuid();
            }
            else
            {
                obj.transid = Guid.Parse(hdntrans);
            }
            obj.programid = Guid.Parse(ddlselectpro.SelectedValue);
            obj.docid = Guid.Parse(hdn.Value);
            obj.conditions = ((TextBox)updaterepeater.Items[i].FindControl("txtcon")).Text;
            obj.remarks = ((TextBox)updaterepeater.Items[i].FindControl("txtre")).Text;
            obj.aqdinitial = ((TextBox)updaterepeater.Items[i].FindControl("txtaqdinit")).Text;
            obj.rco = Session["user"].ToString();
            obj.luo = Session["user"].ToString();
            if (obj.remarks != "" && obj.aqdinitial != "" && obj.conditions != "")
            {
                obj.updatemqapa();
            }       
        }
        gc_app.message(this, obj.msg);
        updaterepeater.DataBind();
        ddlselectpro.SelectedValue = "";
        hfTab.Value = "updatemqapa";
    }
    protected void ddldeleteprogram_SelectedIndexChanged(object sender, EventArgs e)
    {
        bldeletemqapadocs objvwbytransid = new bldeletemqapadocs();
        DataTable dtbl = new DataTable();
        dtbl = objvwbytransid.vwbytransid(Guid.Parse(ddldprogram.SelectedValue));
        deletemqarepeater.DataSource = objvwbytransid.vwbytransid(Guid.Parse(ddldprogram.SelectedValue));
        deletemqarepeater.DataBind();
        Panel1.Visible = true;
        btndeletemqa.Visible = true;
        }
    protected void btndeletemqa_Click(object sender, EventArgs e)
    {
        bldeletemqapadocs obj = new bldeletemqapadocs();
        foreach (RepeaterItem r in deletemqarepeater.Items)
        {
            CheckBox c = r.FindControl("chkdelete") as CheckBox;
            HiddenField hf = r.FindControl("hfdeltransid") as HiddenField;
            if (c.Checked == true)
            {
                obj.transid = Guid.Parse(hf.Value);
                obj.luo = Session["user"].ToString();
                obj.deletemqapa();
            }
        }
        gc_app.message(this, obj.msg);
        //parepeater.DataBind();
        updaterepeater.DataBind();
        deletemqarepeater.DataBind();
        ddldprogram.SelectedValue = "";
        btndeletemqa.Visible = false;
        hfTab.Value = "deletemqapa"; 
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        blmqapadocs mqa = new blmqapadocs();
        DataTable mdt1 = new DataTable();
        mdt1 = mqa.repeater_vw();
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //HiddenField7.Value = ((HiddenField)e.Item.FindControl("HiddenField2")).Value;
                // Repeater rpt_intakeac = new Repeater();
                Repeater rpt_intakeac = (Repeater)e.Item.FindControl("Repeater2");
                rpt_intakeac.DataSource = mdt1;
                rpt_intakeac.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}


