using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Admin_Rentals : System.Web.UI.Page
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
        string query = "select * from Rent_tbl ";
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable data = new DataTable();
        sda.Fill(data);
        Rents_GridView.DataSource = data;
        Rents_GridView.DataBind();
    }




    public void Rental_Delete()
    {

        SqlConnection con = new SqlConnection(cs);

        GridViewRow row = Rents_GridView.SelectedRow;
        
        Label Cust_lbl = (Label)row.FindControl("Label_Id");
  
        Cust = Convert.ToInt32(Cust_lbl.Text);

        string Query = "delete from Rent_tbl where Rent_Id = @Id";
        SqlCommand cmd = new SqlCommand(Query, con);

        cmd.Parameters.AddWithValue("@Id", Cust);
       


        con.Open();

        int a = cmd.ExecuteNonQuery();
        if (a > 0)
        {

            Msg_lbl.Text = "Car Number '" + PNumber + "' Return SuccessFully ";
            Msg_lbl.CssClass = "text-success";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Car Return Failed Car Number " + PNumber + " ','error')", true);
        }



        con.Close();

        Bind_Gridview();
    }
    public void Car_Status_Update()
    {
        SqlConnection con = new SqlConnection(cs);

        GridViewRow row = Rents_GridView.SelectedRow;

        Label Car_lbl = (Label)row.FindControl("Label_Car");

        PNumber = Car_lbl.Text;
        string Status = "Available";
        try
        {


            string Query = "update Cars_tbl set  Status = @Status where Registration_No = @Reg_No";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Reg_No", PNumber);

            con.Open();

            int a = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Msg_lbl.Text = ex.Message;
        }
        finally
        {
            con.Close();
        }
    }

 
    string PNumber , date;
    int Cust;
    protected void Rents_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = Rents_GridView.SelectedRow;

        Label Car_lbl = (Label)row.FindControl("Label_Car");
        PNumber = Car_lbl.Text;
        if (PNumber == null)
        {
            Msg_lbl.Text = "Please Select Car Row";
            Msg_lbl.CssClass = "text-danger";
        }
        else
        {
            Msg_lbl.Text = "You,re Selected Car Number '" + PNumber + "' For Return";
        }
       
    }

    protected void Return_Button_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);

        GridViewRow row = Rents_GridView.SelectedRow;
        if (row != null)
        {
            Label Car_lbl = (Label)row.FindControl("Label_Car");
            Label Cust_lbl = (Label)row.FindControl("Label_Cust");

            PNumber = Car_lbl.Text;
            Cust = Convert.ToInt32(Cust_lbl.Text);
            date = System.DateTime.Today.ToString("MM/dd/yyyy");
        }
        else
        {
            Msg_lbl.Text = "Please Select Car Row";
            Msg_lbl.CssClass = "text-danger";
        }
           
     

       if(Cust == 0 || PNumber == null)
        {
            Msg_lbl.Text = "Please Select Car Row";
            Msg_lbl.CssClass = "text-danger";
        }
        else
        {
            try
            {
                string Query = "insert into Return_tbl values(@Car , @Cust ,@Date ,  @Delay ,  @Fine)";
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Car", PNumber);
                cmd.Parameters.AddWithValue("@Cust", Cust);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Delay", Delay_Box.Text);
                cmd.Parameters.AddWithValue("@Fine", Fine_Box.Text);



                con.Open();

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //Response.Write("<script>alert('Student SignUp Successfully')</script>");

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Success','Car Number " + PNumber + " Returned Succesfully','success')", true);
                    Car_Status_Update();
                    Rental_Delete();
                    Bind_Gridview();
                }
                else
                {
                    //Response.Write("<script>alert('Student SignUp Failed')</script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Return Failed','error')", true);
                }

            }
            catch (Exception ex)
            {

                Msg_lbl.Text = ex.Message;

            }
            finally
            {
                con.Close();
            }
            Bind_Gridview();
        }

       
    }
}