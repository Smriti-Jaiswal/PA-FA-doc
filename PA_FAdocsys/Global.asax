<%@ Application Language="C#" %>
<%@ Import Namespace="PA_FAdocsys" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
    void Session_Start(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {

            Response.Redirect("~/Index.aspx");
        }
        else
        {

            Response.Redirect("~/Account/Login.aspx");
        }

    }
    //void Session_End(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Account/Login.aspx");
    //}

</script>
