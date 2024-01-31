<%@ Page Title="" Language="C#" MasterPageFile="~/View/Customer/Customer_Master.master" AutoEventWireup="true" CodeFile="Pending_Rents.aspx.cs" Inherits="View_Customer_Pending_Rents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <br />
    <br />
    <div class="row">
        <div class="col-md-10 mx-auto">
            <h1 class="text-center">YOUR PENDING RENTALS</h1>
            <br />
            <asp:gridview id="Rents_GridView" class="table table-striped table-responsive table-hover table-bordered table-dark" runat="server" autogeneratecolumns="False">
              
            <Columns>

               

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
        </div>
    </div>
</asp:Content>

