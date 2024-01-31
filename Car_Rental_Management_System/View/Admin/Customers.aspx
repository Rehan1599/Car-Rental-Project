<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="View_Admin_Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
     <br />


    <div class="row">
        <div class="col-md-4 ps-5">

           
            <div class="row">
                <div class="col">
                    
                     <h1 class="text-center">MANAGE CUSTOMERS</h1><br />
                   <img src="../../Assets/Img/Customers.png" height="120" width="390" class="align-content-center" /><br />
                </div>
            </div>
            <asp:HiddenField ID="Id_Box"  runat="server" />
            <asp:TextBox ID="Name_Box" CssClass="form-control" placeholder="ENTER CUSTOMER NAME" runat="server"></asp:TextBox>
            
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Name_Box" forecolor="Red" display="Dynamic" errormessage="Customer Name is Required"></asp:requiredfieldvalidator>
            <br />

            <asp:TextBox ID="Contact_Box" CssClass="form-control " placeholder="ENTER CONTACT NUMBER" runat="server"></asp:TextBox>
           
            <asp:regularexpressionvalidator runat="server" validationgroup="Add_Btn" errormessage="Please Enter Valid 10 Digit Contact Number Starting With : 6 ,7 , 8, 9" controltovalidate="Contact_Box" display="Dynamic" forecolor="Red" setfocusonerror="True" validationexpression="[6-9]{1}[0-9]{9}"></asp:regularexpressionvalidator>
            
            <asp:requiredfieldvalidator id="RequiredFieldValidator2" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Contact_Box" forecolor="Red" display="Dynamic" errormessage="Customer Contact Number is Required"></asp:requiredfieldvalidator>
            <br />

            <asp:TextBox ID="Address_Box" CssClass="form-control" placeholder="ENTER CUSTOMER ADDRESS" runat="server"></asp:TextBox>
            
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Address_Box" forecolor="Red" display="Dynamic" errormessage="Customer Address is Required"></asp:requiredfieldvalidator>
            
            <br />

            <asp:TextBox ID="Password_Box" TextMode="Password" CssClass="form-control" placeholder="ENTER CUSTOMER PASSWORD" runat="server"></asp:TextBox>
            
            <asp:regularexpressionvalidator runat="server" validationgroup="Add_Btn" errormessage="Please Enter 6 Digit Strong Password" controltovalidate="Password_Box" display="Dynamic" forecolor="Red" setfocusonerror="True" validationexpression="((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20})"></asp:regularexpressionvalidator>

            <asp:requiredfieldvalidator id="RequiredFieldValidator4" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Password_Box" forecolor="Red" display="Dynamic" errormessage="Customer Password is Required"></asp:requiredfieldvalidator>
            
            <br />
           
             <asp:button id="Reset_Button" OnClick="Reset_Button_Click"  cssclass="btn btn-danger float-end mb-4 me-3" runat="server" text="Reset " />

            <br />
           
            <div class="col-md-12 d-flex justify-content-around pb-4">

                <asp:Button ID="Update_Button" OnClick="Update_Button_Click" CssClass="btn btn-outline-primary " runat="server" Text="Update Data" />
                <asp:Button ID="Add_Button" CssClass="btn btn-outline-success" OnClick="Add_Button_Click" validationgroup="Add_Btn" runat="server" Text="Add data" />
                <asp:Button ID="Delete_Button" OnClick="Delete_Button_Click" CssClass="btn btn-outline-danger " runat="server" Text="Delete Data" />
            </div>

        </div>


          <div class="col-md-7 mx-auto">
            <h1 class="text-center">CUSTOMERS LIST</h1><br />
            <asp:gridview id="Customers_GridView" class="table table-striped table-responsive table-hover table-bordered table-dark"  runat="server" autogeneratecolumns="False" OnSelectedIndexChanged="Customers_GridView_SelectedIndexChanged">
              
            <Columns>

                <asp:TemplateField HeaderText="SELECT ROW" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="Select_Rows" CssClass="btn btn-success" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CUSTOMER ID">
                    <ItemTemplate>
                            <asp:Label ID="Label_Id" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="NAME" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="NUMBER" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Contact" runat="server" Text='<%# Bind("Contact_Number") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="ADDRESS" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Address" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="Password" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Password" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

              


            </Columns>

            </asp:gridview>
        </div>
    </div>
</asp:Content>

