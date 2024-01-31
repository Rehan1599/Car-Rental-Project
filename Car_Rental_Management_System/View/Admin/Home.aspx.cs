using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Admin_Home : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            Response.Redirect("http://localhost:53602/View/Login_Page.aspx");
        }
        if (!IsPostBack)
        {
            Admin_Name.Text = Session["User_Name"].ToString();
        }
    }
}