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
using static NSDocumentation.blprogram;

public partial class Program : System.Web.UI.Page
{
    public object MessageBox { get; private set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null)
        //{

        //    Response.Redirect("~/Index.aspx");
        //}
        //else
        //{

        //    Response.Redirect("~/Program.aspx");
        //}

    }
    protected void btn_Save(object sender, EventArgs e)
    {
        blprogram obj = new blprogram();
        obj.programname = txtproname.Text;
        obj.mqacode = txtmqacode.Text;
        obj.duration = Convert.ToInt32(txtduration.Text);
        obj.shortsem = Convert.ToInt32(txtshortsem.Text);
        obj.longsem = Convert.ToInt32(txtlongsem.Text);
        obj.rco = Session["user"].ToString();
        obj.insert();
        gc_app.message(this, obj.msg);
        Repeater1.DataBind();
        Repeater2.DataBind();
        Repeater3.DataBind();
        clear();
        hfTab.Value = "add";
    }
    public void clear()
    {
        txtproname.Text = "";
        txtmqacode.Text = "";
        txtduration.Text = "";
        txtshortsem.Text = "";
        txtlongsem.Text = "";

    }
    protected void btnup_Click(object sender, EventArgs e)
    {
        blupdateprogram obj = new blupdateprogram();
            obj.transid = Guid.Parse(hfield.Value);
            obj.programname = txtpname.Text;
            obj.mqacode = txtcode.Text;
            obj.duration = Convert.ToInt32(txtdura.Text);
            obj.shortsem = Convert.ToInt32(txtss.Text);
            obj.longsem = Convert.ToInt32(txtls.Text);
            obj.rco = Session["user"].ToString(); 
            obj.luo = Session["user"].ToString(); 
            obj.update();
             gc_app.message(this, obj.msg);
            Repeater1.DataBind();
            Repeater2.DataBind();
            Repeater3.DataBind();
            Panel1.Visible = false;
            hfTab.Value = "edit";
    }
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        hfield.Value = ((HiddenField)e.Item.FindControl("hfuptransid")).Value;
        txtpname.Text = ((Label)e.Item.FindControl("lblpronm")).Text;
        txtcode.Text = ((Label)e.Item.FindControl("lblmcd")).Text;
        txtdura.Text = ((Label)e.Item.FindControl("lbldrtn")).Text;
        txtss.Text = ((Label)e.Item.FindControl("lblssem")).Text;
        txtls.Text = ((Label)e.Item.FindControl("lbllsem")).Text;
        foreach (RepeaterItem items in Repeater2.Items)
            ((HtmlTableRow)items.FindControl("tr1")).Attributes.Remove("style");

        ((HtmlTableRow)e.Item.FindControl("tr1")).Attributes.Add("style", "background-color: rgb(58, 60, 62); color: rgb(178, 172, 157);");

        Panel1.Visible = true;
        hfTab.Value = "edit";
    }
    protected void btndlt_Click(object sender, EventArgs e)
    {
        bldeleteprogram obj = new bldeleteprogram();
        foreach (RepeaterItem r  in Repeater3.Items)
        {
            CheckBox c = r.FindControl("chbx") as CheckBox;
            HiddenField hf = r.FindControl("hfdtransid") as HiddenField;
            if (c.Checked == true)
            {
        obj.transid = Guid.Parse(hf.Value);
        obj.luo = Session["user"].ToString();
                obj.delete();           
            }         
        }
        gc_app.message(this, obj.msg);
        Repeater1.DataBind();
        Repeater2.DataBind();
        Repeater3.DataBind();
        hfTab.Value = "remove";
    }  
}

