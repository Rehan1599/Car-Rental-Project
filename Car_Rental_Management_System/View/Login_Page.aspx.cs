using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Login_Page : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);
        if (Cust_Radio.Checked )
        {


            string Query = "select Id,Name,Password from Customers_tbl where Name = @Id and Password =  @Password";
            //SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            //cmd.Parameters.AddWithValue("@Id", User_Box.Text);
            //cmd.Parameters.AddWithValue("@Password", Pass_Box.Text);

            sda.SelectCommand.Parameters.AddWithValue("@Id", User_Box.Text);
            sda.SelectCommand.Parameters.AddWithValue("@Password", Pass_Box.Text);

            //con.Open();


            //SqlDataReader dr = cmd.ExecuteReader();
            DataTable data = new DataTable();
            sda.Fill(data);



            if (data.Rows.Count > 0)

            {

                Session["User"] = data.Rows[0]["Id"].ToString();
                Session["User_Name"] = User_Box.Text;
                Response.Redirect("Customer/Cars.aspx");
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Login Failed Incorrect UserId or Password','error')", true);
            }
           
        }
        else if (Admin_Radio.Checked)
        {


            string Query = "select * from Admin_tbl where UserId = @Id and Password =  @Password";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Id", User_Box.Text);
            cmd.Parameters.AddWithValue("@Password", Pass_Box.Text);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                
                Session["User_Name"] = User_Box.Text;
                Response.Redirect("Admin/Home.aspx");
            }
            else
            {
                //Response.Write("<script>alert('Student SignUp Failed')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Login Failed Incorrect UserId or Password','error')", true);
            }
            con.Close();
        }

    }
}