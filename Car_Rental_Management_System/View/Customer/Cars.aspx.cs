using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class View_Customer_Cars : System.Web.UI.Page
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
            Cust_Name.Text = Session["User_Name"].ToString();
        }

    }
    //--------------------Bind_Gridview  Function Codes-----------------------------
    void Bind_Gridview()
    {
        SqlConnection con = new SqlConnection(cs);
        string query = "select * from Cars_tbl";
        SqlDataAdapter sda = new SqlDataAdapter(query, con);
        DataTable data = new DataTable();
        sda.Fill(data);
        Cars_GridView.DataSource = data;
        Cars_GridView.DataBind();
        
        Status_lbl.Text = "Select Cars Status";
    }

    //--------------------For Customer , Admin Login  Radio Button  Function Codes-----------------------------
    protected void Status_List_SelectedIndexChanged(object sender, EventArgs e)
    {
        string status_1 = "Available";
        string status_2 = "Booked";
        string status_3 = "All";
        if (Status_List.SelectedItem.Text == status_1)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Cars_tbl where Status = '"+ status_1 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            Cars_GridView.DataSource = data;
            Cars_GridView.DataBind();
            Status_lbl.CssClass = "text-success";
            Status_lbl.Text = "Available Cars";
        }
        else if (Status_List.SelectedItem.Text == status_2)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Cars_tbl where Status = '" + status_2 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            Cars_GridView.DataSource = data;
            Cars_GridView.DataBind();
            Status_lbl.CssClass = "text-danger";
            Status_lbl.Text = "Booked Cars";
        }
        else if (Status_List.SelectedItem.Text == status_3)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Cars_tbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            Cars_GridView.DataSource = data;
            Cars_GridView.DataBind();
            Status_lbl.CssClass = "text-light";
            Status_lbl.Text = "Select Cars Status";
        }
    }

    //--------------------clear_text Function Codes-----------------------------
    public void clear_text()
    {
        Fees = 0;
        DPrice = 0;
        Customer = 0;
        RentDate = "";
        RetDate = "";
        PNumber = "";
        Date_Box.Text = "";
        Book_lbl.Text = "";
        Book_lbl_2.Text = "";
        Book_lbl_3.Text = "";
    }

    //--------------------Car_Status_Update Function Codes-----------------------------
    public void Car_Status_Update()
    {
        SqlConnection con = new SqlConnection(cs);
        string Status = "Booked";
        try
        {
            string Query = "update Cars_tbl set  Status = @Status where Registration_No = @Reg_No";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Reg_No", PNumber);
         
            con.Open();

            int a = cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            Book_lbl.Text = ex.Message;
        }
        finally
        {
            con.Close();
        }
    }

    int Fees = 0, DPrice, Customer;
    
    string RentDate, RetDate , PNumber, Status;

    //--------------------Cars_GridView_SelectedIndexChanged Event Codes-----------------------------
    protected void Cars_GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        TimeSpan DDays;
        DateTime selectedDate;

        if (DateTime.TryParse(Date_Box.Text, out selectedDate))
        {
            DDays = selectedDate.Date - DateTime.Today;
        }
        else
        {
            // Handle the case where the user input is not a valid date
            Book_lbl.Text = "Please enter a valid date in the format dd/MM/yyyy.";
            return;
        }

        if (Cars_GridView.SelectedRow != null)
        {
            GridViewRow row = Cars_GridView.SelectedRow;
            Label Reg_no_lbl = (Label)row.FindControl("Label_Id");
            Label Price_Box_lbl = (Label)row.FindControl("Label_Price");
            Label Brand_lbl = (Label)row.FindControl("Label_Brand");
            Label Model_Box_lbl = (Label)row.FindControl("Label_Model");
            Label Color_Box_lbl = (Label)row.FindControl("Label_Color");
            Label Status_lbl = (Label)row.FindControl("Label_Status");
            if (Reg_no_lbl != null && Price_Box_lbl != null )
            {
                PNumber = Reg_no_lbl.Text;
                DPrice = Convert.ToInt32(Price_Box_lbl.Text);

                RentDate = DateTime.Today.Date.ToString("dd-MM-yyyy");
                RetDate = selectedDate.ToString("dd-MM-yyyy");
                Status = Status_lbl.Text;

                int Days = DDays.Days;
                DPrice = Convert.ToInt32(Price_Box_lbl.Text);
                Fees = DPrice * Days;

                if (Status == "Booked")
                {
                    Book_lbl.Text = "Error: Car Already Booked";
                    Book_lbl.CssClass = "text-danger";
                    Book_lbl_2.Text = "";
                    Book_lbl_3.Text = "";
                    Date_Box.Text = "";
                    return;
                }
                else
                {
                    if (Fees < 0)
                    {
                        Book_lbl.Text = "Error: Negative amount detected.";
                        Book_lbl.CssClass = "text-danger";
                        Book_lbl_2.Text = "";
                        Book_lbl_3.Text = "";
                        Date_Box.Text = "";
                        return;
                    }
                    else
                    {
                        Book_lbl.Text = "You're Selected Car Number '" + PNumber + "' Brand '" + Brand_lbl.Text + "' Model '" + Model_Box_lbl.Text + "' Color '" + Color_Box_lbl.Text + "'. ";
                        Book_lbl.CssClass = "text-success";
                        Book_lbl_2.Text = "Booking Date From '" + RentDate + "' To '" + RetDate + "'";
                        Book_lbl_2.CssClass = "text-success";
                        Book_lbl_3.Text = "Your Total Amout Is = '" + Fees + "'";
                    }

                }
            }
            else
            {
                // Handle the case where the labels are not found
                Book_lbl.Text = "Labels not found in the GridView row.";
            }
        }
        else
        {
            // Handle the case where no row is selected in the GridView
            Book_lbl.Text = "No row selected in the Car Table.";
        }
    }

    //--------------------Date_Box_TextChanged Event Codes-----------------------------
    protected void Date_Box_TextChanged(object sender, EventArgs e)
    {
            TimeSpan DDays;
            DateTime selectedDate;
       
        if (Cars_GridView.SelectedRow == null)
        {
            Book_lbl.Text = "Please Select Car Details.";
            Book_lbl.CssClass = "text-danger";

        }
     
        if (DateTime.TryParse(Date_Box.Text, out selectedDate))
            {
                DDays = selectedDate.Date - DateTime.Today;
            }
            else
            {
                // Handle the case where the user input is not a valid date
                Book_lbl.Text = "Please enter a valid date in the format dd/MM/yyyy.";
                Book_lbl.CssClass = "text-danger";

                return;
            }

            if (Cars_GridView.SelectedRow != null)
            {
                GridViewRow row = Cars_GridView.SelectedRow;
                Label Reg_no_lbl = (Label)row.FindControl("Label_Id");
                Label Price_Box_lbl = (Label)row.FindControl("Label_Price");
                Label Brand_lbl = (Label)row.FindControl("Label_Brand");
                Label Model_Box_lbl = (Label)row.FindControl("Label_Model");
                Label Color_Box_lbl = (Label)row.FindControl("Label_Color");
                Label Status_lbl = (Label)row.FindControl("Label_Status");
                if (Reg_no_lbl != null && Price_Box_lbl != null)
                {
                    PNumber = Reg_no_lbl.Text;
                    DPrice = Convert.ToInt32(Price_Box_lbl.Text);
                    Status = Status_lbl.Text;
                    //RentDate = System.DateTime.Today.Date.ToString();
                    //RetDate = Date_Box.Text;
                    RentDate = DateTime.Today.Date.ToString("dd-MM-yyyy");
                    RetDate = selectedDate.ToString("dd-MM-yyyy");

                    int Days = DDays.Days;
                    DPrice = Convert.ToInt32(Price_Box_lbl.Text);
                    Fees = DPrice * Days;
                    if (Status == "Booked")
                    {
                        Book_lbl.Text = "Error: Car Already Booked";
                        Book_lbl.CssClass = "text-danger";
                        Book_lbl_2.Text = "";
                        Book_lbl_3.Text = "";
                        Date_Box.Text = "";
                        return;
                    }
                    else
                    {
                        if (Fees < 0)
                        {
                            Book_lbl.Text = "Error: Negative amount detected.";
                            Book_lbl.CssClass = "text-danger";
                            Book_lbl_2.Text = "";
                            Book_lbl_3.Text = "";
                            Date_Box.Text = "";
                            return;
                        }
                        else
                        {
                            Book_lbl.Text = "You're Selected Car Number '" + PNumber + "' Brand '" + Brand_lbl.Text + "' Model '" + Model_Box_lbl.Text + "' Color '" + Color_Box_lbl.Text + "'. ";
                            Book_lbl.CssClass = "text-success";
                            Book_lbl_2.Text = "Booking Date From '" + RentDate + "' To '" + RetDate + "'";
                            Book_lbl_2.CssClass = "text-success";
                            Book_lbl_3.Text = "Your Total Amout Is = '" + Fees + "'";
                        }
                    }

                }
                else
                {
                    // Handle the case where the labels are not found
                    Book_lbl.Text = "Labels not found in the GridView row.";
                }
            }
            else
            {
                // Handle the case where no row is selected in the GridView
                Book_lbl.Text = "Cars Details Not selected.";
            }
        }
        
    protected void Book_Button_Click(object sender, EventArgs e)
    {
        try
        {
            TimeSpan DDays;
            DateTime selectedDate;

            if (DateTime.TryParse(Date_Box.Text, out selectedDate))
            {
                DDays = selectedDate.Date - DateTime.Today;
            }
            else
            {
                // Handle the case where the user input is not a valid date
                Book_lbl.Text = "Please enter a valid date in the format dd/MM/yyyy.";
                return;
            }
            
            int Days = DDays.Days;

            GridViewRow row = Cars_GridView.SelectedRow;
            Label Reg_no_lbl = (Label)row.FindControl("Label_Id");
            Label Price_Box_lbl = (Label)row.FindControl("Label_Price");
            Label Status_lbl = (Label)row.FindControl("Label_Status");
            PNumber = Reg_no_lbl.Text;
            Status = Status_lbl.Text;
            DPrice = Convert.ToInt32(Price_Box_lbl.Text);

            Fees = DPrice * Days;

            RentDate = DateTime.Today.Date.ToString("MM/dd/yyyy");
            RetDate = selectedDate.ToString("MM/dd/yyyy");
         

            Customer = Convert.ToInt32(Session["User"]);

            if(Status == "Booked")
            {
                Book_lbl.Text = "Error: Car Already Booked";
                Book_lbl.CssClass = "text-danger";
                Book_lbl_2.Text = "";
                Book_lbl_3.Text = "";
                Date_Box.Text = "";
                return;
            }
            else
            {
                if (Fees < 0)
                {
                    Book_lbl.Text = "Error: Negative amount detected.";
                    Book_lbl.CssClass = "text-danger";
                    Book_lbl_2.Text = "";
                    Book_lbl_3.Text = "";
                    Date_Box.Text = "";
                    return;
                }
                else
                {

                    if (PNumber != "")
                    {
                        using (SqlConnection con = new SqlConnection(cs))

                        {
                            string query = "INSERT INTO Rent_tbl VALUES (@PNumber, @Customer, @RentDate, @RetDate, @Fees)";
                            Console.WriteLine("Query: " + query); // Print the query for debugging

                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@PNumber", PNumber);
                            cmd.Parameters.AddWithValue("@Customer", Customer);
                            cmd.Parameters.AddWithValue("@RentDate", RentDate);
                            cmd.Parameters.AddWithValue("@RetDate", RetDate);
                            cmd.Parameters.AddWithValue("@Fees", Fees);
                            Console.WriteLine($"PNumber: {PNumber}, Customer: {Customer}, RentDate: {RentDate}, RetDate: {RetDate}, Fees: {Fees}");

                            con.Open();
                            int affectedRows = cmd.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('success','Car Number " + PNumber + " Booked Successfully','success')", true);
                                Car_Status_Update();
                                clear_text();
                                Bind_Gridview();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Swal.fire('Failure','Missing Information','error')", true);
                            }
                            con.Close();
                        }
                    }
                    else
                    {
                        Book_lbl.Text = "Please Select car Details";
                    }
                }
            }
        }
           
        catch (Exception ex)
        {
            Book_lbl.Text = "An error occurred: " + ex.Message;
        }
      
    }
//Clear Text Boxes 
    protected void Rest_Button_Click(object sender, EventArgs e)
    {
        Fees = 0;
        DPrice = 0;
        Customer = 0;
        RentDate = "";
        RetDate = "";
        PNumber = "";
        Date_Box.Text = "";
        Book_lbl.Text = "";
        Book_lbl_2.Text = "";
        Book_lbl_3.Text = "";
    }

}
