<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="Returns.aspx.cs" Inherits="View_Admin_Return" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
<div class="row">

     <div class="col-md-10 mx-auto">
            <h1 class="text-center">RETURN RENTAL CARS LIST</h1><br />

           <asp:gridview id="Return_GridView" class="table table-striped table-responsive table-hover table-bordered table-dark"  runat="server" autogeneratecolumns="False" >
              
            <Columns>

              

              <asp:TemplateField HeaderText="Return ID">
                    <ItemTemplate>
                            <asp:Label ID="Label_Id" runat="server" Text='<%# Bind("Return_Id") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>


                 <asp:TemplateField HeaderText="CAR NUMBER" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Car" runat="server" Text='<%# Bind("Car") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

               
             <asp:TemplateField HeaderText="CUSTOMER ID" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Cust" runat="server" Text='<%# Bind("Customer") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

               <asp:TemplateField HeaderText="RETURN DATE" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Return" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText="DELAY" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Delay" runat="server" Text='<%# Bind("Delay") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                    
                   <asp:TemplateField HeaderText="FINE" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Fine" runat="server" Text='<%# Bind("Fine") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
              


            </Columns>

            </asp:gridview>











    </div>
    </div>
</asp:Content>

