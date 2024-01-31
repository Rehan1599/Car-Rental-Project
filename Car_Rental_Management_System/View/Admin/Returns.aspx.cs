using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Admin_Return : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            Response.Redirect("http://localhost:53602/View/Login_Page.aspx");
        }

        if (!IsPostBack)
        {
            Bind_Gridview();
        }
    }


    void Bind_Gridview()
    {
       
        SqlConnection con = new SqlConnection(cs);
        string query = "select * from Return_tbl ";
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable data = new DataTable();
        sda.Fill(data);
        Return_GridView.DataSource = data;
        Return_GridView.DataBind();
    }
}