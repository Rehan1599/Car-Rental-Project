using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Customer_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            Session.Abandon();
            Response.Redirect("http://localhost:53602/View/Login_Page.aspx");
        }
        else
        {

            Session.Abandon();
            Response.Redirect("http://localhost:53602/View/Login_Page.aspx");
        }
    }
}