<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="Rentals.aspx.cs" Inherits="View_Admin_Rentals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br />
     <br />




<div class="row">

     <div class="col-md-10 mx-auto">
            <h1 class="text-center">CUSTOMERS PENDING RENTALS</h1><br />
            
           <h5 class="float-end text-danger"> <asp:label id="Msg_lbl" runat="server" text=""></asp:label></h5>
            <asp:gridview id="Rents_GridView" class="table table-striped table-responsive table-hover table-bordered table-dark"  runat="server" autogeneratecolumns="False" OnSelectedIndexChanged="Rents_GridView_SelectedIndexChanged" >
              
            <Columns>

               
                  <asp:TemplateField HeaderText="SELECT ROW" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="Select_Rows" CssClass="btn btn-success" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RENT ID">
                    <ItemTemplate>
                            <asp:Label ID="Label_Id" runat="server" Text='<%# Bind("Rent_Id") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                   <asp:TemplateField HeaderText="CUSTOMER ID" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Cust" runat="server" Text='<%# Bind("Customer") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR NUMBER" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Car" runat="server" Text='<%# Bind("Car") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

             

                <asp:TemplateField HeaderText="RENT DATE" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Rent" runat="server" Text='<%# Bind("Rent_Date") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="RETURN DATE" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Return" runat="server" Text='<%# Bind("Return_Date") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="FEES" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Fees" runat="server" Text='<%# Bind("Fees") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>




            </Columns>

            </asp:gridview>
      
         <br />
         <div class="row">
            

             <div class="col-md-4 mx-auto d-grid">
                 <asp:textbox id="Delay_Box" class="form-control" placeholder="Enter Delay" runat="server"></asp:textbox>

            <asp:requiredfieldvalidator id="RequiredFieldValidator1"  setfocusonerror="true" runat="server" controltovalidate="Delay_Box" forecolor="Red" display="Dynamic" errormessage="Please Fill Delay TextBox"></asp:requiredfieldvalidator>

             </div>
              <div class="col-md-4 mx-auto d-grid">
                 <asp:textbox id="Fine_Box" class="form-control" placeholder="Enter Fine" runat="server" TextMode="Number"></asp:textbox>
             
            <asp:requiredfieldvalidator id="RequiredFieldValidator2"  setfocusonerror="true" runat="server" controltovalidate="Fine_Box" forecolor="Red" display="Dynamic" errormessage="Please Fill Fine TextBox"></asp:requiredfieldvalidator>
              
              </div>

              <div class="col-md-4 mx-auto d-grid">
                 <asp:button id="Return_Button" runat="server" text="Return" class="btn btn-danger" OnClick="Return_Button_Click" />
                 
             </div>

         </div>
       
        </div>
    </div>
</asp:Content>

