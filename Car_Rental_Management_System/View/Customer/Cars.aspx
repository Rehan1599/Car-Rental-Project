<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/Customer_Master.master" AutoEventWireup="true" CodeFile="Cars.aspx.cs" Inherits="View_Customer_Cars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
    <br />
    <h5 style="color: darkseagreen;">WELCOME TO DASHBOARD</> <asp:Label ID="Cust_Name" runat="server" Text="Label"></asp:Label></h5>
    <div class="row ">
        <div class="col-md-4 mx-auto">
            <img src="../../Assets/Img/car-4-removebg-1.png" width="425" height="170" />
        </div>
    </div>
    <br />
   
 
   


    <div class="row">
        <div class="col-md-10 mx-auto">
             <div class="row ">
            
         

            <div class="col-md-4 mx-auto">
                  <h2>  
                      <asp:Label ID="Status_lbl"  runat="server" Text=""></asp:Label>
                   </h2>

                <asp:DropDownList ID="Status_List" CssClass="form-control" runat="server" OnSelectedIndexChanged="Status_List_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>Available</asp:ListItem>
                    <asp:ListItem>Booked</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div><br />



            <asp:GridView ID="Cars_GridView" class="table table-striped table-responsive table-hover table-bordered table-dark" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Cars_GridView_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="SELECT ROW" ShowHeader="False" >
                        <ItemTemplate>
                            <asp:LinkButton ID="Select_Rows" CssClass="btn btn-success" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CAR PLATE NUMBER">
                        <ItemTemplate>
                            <asp:Label ID="Label_Id" runat="server" Text='<%# Bind("Registration_no") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CAR BRAND">
                        <ItemTemplate>
                            <asp:Label ID="Label_Brand" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CAR MODEL">
                        <ItemTemplate>
                            <asp:Label ID="Label_Model" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CAR PRICE">
                        <ItemTemplate>
                            <asp:Label ID="Label_Price" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CAR COLOR">
                        <ItemTemplate>
                            <asp:Label ID="Label_Color" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CAR STATUS">
                        <ItemTemplate>
                            <asp:Label ID="Label_Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>




                </Columns>

            </asp:GridView><br />
            <div class="row">
            <div class="col-md-5">
                 <asp:TextBox ID="Date_Box" AutoPostBack="true" type="date" CssClass="form-control" runat="server" OnTextChanged="Date_Box_TextChanged"></asp:TextBox>
               
                </div>
            <div class="col-md-5 d-grid">
                
                <asp:Button ID="Book_Button"  runat="server" CssClass="btn btn-outline-success" Text="Book" OnClick="Book_Button_Click" />
               <h5 style="color: firebrick;"><asp:Label ID="Book_lbl" runat="server" Text=""></asp:Label></h5>
               <h5 style="color: firebrick;"><asp:Label ID="Book_lbl_2" runat="server" Text=""></asp:Label></h5>
               <h5 style="color: firebrick;"><asp:Label ID="Book_lbl_3" runat="server" Text=""></asp:Label></h5>
            </div> 
                  <div class="col-md-2 ">
                
                <asp:Button ID="Rest_Button"  runat="server" CssClass="btn btn-danger " Text="Rest" OnClick="Rest_Button_Click" />
              
            </div> 
            </div> 
        </div>
       </div>
   
    <br />

</asp:Content>

