using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Admin_Customers : System.Web.UI.Page
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
    public void Clear_Box()
    {
        Id_Box.Value = "";
        Name_Box.Text = "";
        Contact_Box.Text = "";
        Address_Box.Text = "";
        Password_Box.Text = "";
        
    }


    void Bind_Gridview()
    {
        SqlConnection con = new SqlConnection(cs);
        string query = "select * from Customers_tbl";
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable data = new DataTable();
        sda.Fill(data);
        Customers_GridView.DataSource = data;
        Customers_GridView.DataBind();
    }

    protected void Add_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);

        try
        {
            string Query = "insert into Customers_tbl values(@Name , @Number ,@Address ,  @Password )";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Name", Name_Box.Text);
            cmd.Parameters.AddWithValue("@Number", Contact_Box.Text);
            cmd.Parameters.AddWithValue("@Address", Address_Box.Text);
            cmd.Parameters.AddWithValue("@Password", Password_Box.Text);
           


            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                //Response.Write("<script>alert('Student SignUp Successfully')</script>");

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Customer " + Name_Box.Text.ToUpper() + " Detailes Added Succesfully','success')", true);
                Clear_Box();
            }
            else
            {
                //Response.Write("<script>alert('Student SignUp Failed')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Registration Failed','error')", true);
            }

        }
        catch (Exception ex)
        {


            Response.Write("<script>alert('"+ex.Message+ "')</script>");
           


        }
        finally
        {
            con.Close();
        }
        Bind_Gridview();
    }

    protected void Customers_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = Customers_GridView.SelectedRow;

        Label Id_lbl = (Label)row.FindControl("Label_Id");
        Label Name_lbl = (Label)row.FindControl("Label_Name");
        Label Number_lbl = (Label)row.FindControl("Label_Contact");
        Label Address_lbl = (Label)row.FindControl("Label_Address");
        Label Password_lbl = (Label)row.FindControl("Label_Password");

        Id_Box.Value = Id_lbl.Text;
        Name_Box.Text = Name_lbl.Text;
        Contact_Box.Text = Number_lbl.Text;
        Address_Box.Text = Address_lbl.Text;
        Password_Box.Text = Password_lbl.Text;

    }

    protected void Update_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);

        
        string Query = "update Customers_tbl set  Name = @Name , Contact_Number = @Number , Address = @Address , Password = @Password  where Id = @Id";
        SqlCommand cmd = new SqlCommand(Query, con);

        cmd.Parameters.AddWithValue("@Id", Id_Box.Value.ToString());
        cmd.Parameters.AddWithValue("@Name", Name_Box.Text);
        cmd.Parameters.AddWithValue("@Number", Contact_Box.Text);
        cmd.Parameters.AddWithValue("@Address", Address_Box.Text);
        cmd.Parameters.AddWithValue("@Password", Password_Box.Text);
        


        con.Open();

        int a = cmd.ExecuteNonQuery();
        if (a > 0)
        {
            

            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Customer " + Name_Box.Text.ToUpper() + " Data Update Succesfully','success')", true);
            Clear_Box();
        }
        else
        {
            
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Updation Failed Customer Id" + Id_Box.Value.ToUpper() + " Not Exist in Your DataBase','error')", true);
        }



        con.Close();

        Bind_Gridview();
    }



    protected void Delete_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);


        string Query = "delete from Customers_tbl where Id = @Id";
        SqlCommand cmd = new SqlCommand(Query, con);

        cmd.Parameters.AddWithValue("@Id", Id_Box.Value.ToString());
        


        con.Open();

        int a = cmd.ExecuteNonQuery();
        if (a > 0)
        {


            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','User  " + Name_Box.Text.ToUpper() + " Record Deleted Succesfully','success')", true);
            Clear_Box();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Record Deletation Failed Userid " + Id_Box.Value + " Not Exist in Your DataBase','error')", true);
        }



        con.Close();

        Bind_Gridview();
    }

    protected void Reset_Button_Click(object sender, EventArgs e)
    {
        Id_Box.Value = "";
        Name_Box.Text = "";
        Contact_Box.Text = "";
        Address_Box.Text = "";
        Password_Box.Text = "";

    }
}