using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Customer_Pending_Rents : System.Web.UI.Page
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
        string Id = Session["User"].ToString();
        SqlConnection con = new SqlConnection(cs);
        string query = "select * from Rent_tbl where Customer = '"+Id+"'";
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable data = new DataTable();
        sda.Fill(data);
        Rents_GridView.DataSource = data;
        Rents_GridView.DataBind();
    }
}