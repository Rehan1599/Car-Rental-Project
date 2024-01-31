using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Admin_Cars : System.Web.UI.Page
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

        Registration_Box.Text = "";
        Brand_Box.Text = "";
        Model_Box.Text = "";
        Price_Box.Text = "";
        Color_Box.Text = "";
        Status_List.ClearSelection();

    }

    void Bind_Gridview()
    {
        SqlConnection con = new SqlConnection(cs);
        string query = "select * from Cars_tbl";
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable data = new DataTable();
        sda.Fill(data);
        Cars_GridView.DataSource = data;
        Cars_GridView.DataBind();
    }
    protected void Add_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);
       
        try
        {
            string Query = "insert into Cars_tbl values(@Reg_No , @Brand ,@Model ,  @Price ,  @Color ,  @Status)";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Reg_No", Registration_Box.Text.ToUpper());
            cmd.Parameters.AddWithValue("@Brand", Brand_Box.Text);
            cmd.Parameters.AddWithValue("@Model", Model_Box.Text);
            cmd.Parameters.AddWithValue("@Price", Price_Box.Text);
            cmd.Parameters.AddWithValue("@Color", Color_Box.Text);
            cmd.Parameters.AddWithValue("@Status", Status_List.SelectedItem.ToString());


            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                //Response.Write("<script>alert('Student SignUp Successfully')</script>");

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Car " +Registration_Box.Text.ToUpper()+ " Detailes Add Succesfully','success')", true);
                Clear_Box();
            }
            else
            {
                //Response.Write("<script>alert('Student SignUp Failed')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Registration Failed','error')", true);
            }

        }
        catch (SqlException ex)
        {
            if(ex.Message.Contains("PRIMARY KEY constraint"))
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Registration Failed... " + Registration_Box.Text.ToUpper() + "Car Number Already Registered. (Please Add another Car Detailes)','error')", true);
                Bind_Gridview();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Registration Failed...','error')", true);
            }


        }
        finally
        {
            con.Close();
        }
        Bind_Gridview();
    }

    protected void Registration_Box_TextChanged(object sender, EventArgs e)
    {

      
            string up;
            up = (Registration_Box.Text).ToUpper();

        Registration_Box.Text = up;

    }

    protected void Cars_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = Cars_GridView.SelectedRow;

        Label Reg_no_lbl = (Label)row.FindControl("Label_Id");
        Label Brand_lbl = (Label)row.FindControl("Label_Brand");
        Label Model_Box_lbl = (Label)row.FindControl("Label_Model");
        Label Price_Box_lbl = (Label)row.FindControl("Label_Price");
        Label Color_Box_lbl = (Label)row.FindControl("Label_Color");
        Label Status_List_lbl = (Label)row.FindControl("Label_Status");

        Registration_Box.Text = Reg_no_lbl.Text;
        Brand_Box.Text = Brand_lbl.Text;
        Model_Box.Text = Model_Box_lbl.Text;
        Price_Box.Text = Price_Box_lbl.Text;
        Color_Box.Text = Color_Box_lbl.Text;
        Status_List.SelectedItem.Text = Status_List_lbl.Text;

    }

   

    protected void Update_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);

       
            string Query = "update Cars_tbl set  Brand = @Brand , Model = @Model , Price = @Price , Color = @Color , Status = @Status where Registration_No = @Reg_No";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Reg_No", Registration_Box.Text.ToUpper());
            cmd.Parameters.AddWithValue("@Brand", Brand_Box.Text);
            cmd.Parameters.AddWithValue("@Model", Model_Box.Text);
            cmd.Parameters.AddWithValue("@Price", Price_Box.Text);
            cmd.Parameters.AddWithValue("@Color", Color_Box.Text);
            cmd.Parameters.AddWithValue("@Status", Status_List.SelectedItem.ToString());


            con.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                //Response.Write("<script>alert('Student SignUp Successfully')</script>");

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Car Plate Number " + Registration_Box.Text.ToUpper() + " Data Update Succesfully','success')", true);
                Clear_Box();
            }
            else
            {
                //Response.Write("<script>alert('Student SignUp Failed')</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Updation Failed Car Plate Number " + Registration_Box.Text.ToUpper() + " Not Exist in Your DataBase','error')", true);
            }

        
       
            con.Close();
       
        Bind_Gridview();
    }

    protected void Delete_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);


        string Query = "delete from Cars_tbl where Registration_No = @Reg_No";
        SqlCommand cmd = new SqlCommand(Query, con);

        cmd.Parameters.AddWithValue("@Reg_No", Registration_Box.Text.ToUpper());
        //cmd.Parameters.AddWithValue("@Brand", Brand_Box.Text);
        //cmd.Parameters.AddWithValue("@Model", Model_Box.Text);
        //cmd.Parameters.AddWithValue("@Price", Price_Box.Text);
        //cmd.Parameters.AddWithValue("@Color", Color_Box.Text);
        //cmd.Parameters.AddWithValue("@Status", Status_List.SelectedItem.ToString());


        con.Open();

        int a = cmd.ExecuteNonQuery();
        if (a > 0)
        {
           

            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Car Plate Number " + Registration_Box.Text.ToUpper() + " Record Deleted Succesfully','success')", true);
            Clear_Box();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Record Deletation Failed Car Plate Number " + Registration_Box.Text.ToUpper() + " Not Exist in Your DataBase','error')", true);
        }



        con.Close();

        Bind_Gridview();
    }

    protected void Reset_Button_Click(object sender, EventArgs e)
    {

        Registration_Box.Text = "";
        Brand_Box.Text = "";
        Model_Box.Text = "";
        Price_Box.Text = "";
        Color_Box.Text = "";
        Status_List.ClearSelection();
    }
}