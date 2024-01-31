<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/Admin_Master.master" AutoEventWireup="true" CodeFile="Cars.aspx.cs" Inherits="View_Admin_Cars" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <br />


    <div class="row">
        <div class="col-md-4 ps-5">


            <div class="row">
                <div class="col">
                    <h1 class="text-center pb-3">MANAGE CARS</h1>
                    <div class="text-center">
                        <img src="../../Assets/Img/car-4-removebg-1.png" height="120" width="350" />
                    </div>

                </div>
            </div>



            <asp:textbox id="Registration_Box" ontextchanged="Registration_Box_TextChanged" cssclass="form-control" placeholder="ENTER CAR REGISTRATION NUMBER  " runat="server" AutoPostBack="true"></asp:textbox>

            <asp:requiredfieldvalidator id="RequiredFieldValidator1" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Registration_Box" forecolor="Red" display="Dynamic" errormessage="Car Registration Number is Required"></asp:requiredfieldvalidator>
            <asp:regularexpressionvalidator runat="server" validationgroup="Add_Btn" errormessage="Please Enter Valid Car Plate Number EX : MP09HK1234" controltovalidate="Registration_Box" display="Dynamic" forecolor="Red" setfocusonerror="True" validationexpression="[a-zA-Z]{2}[0-9]{2}[a-zA-Z]{2}[0-9]{4}"></asp:regularexpressionvalidator>
            <br />
            <asp:textbox id="Brand_Box" cssclass="form-control " placeholder="ENTER BRAND" runat="server"></asp:textbox>

            <asp:requiredfieldvalidator id="RequiredFieldValidator2" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Brand_Box" forecolor="Red" display="Dynamic" errormessage="Car Brand is Required"></asp:requiredfieldvalidator>


            <br />
            <asp:textbox id="Model_Box" cssclass="form-control" placeholder="ENTER CAR MODEL" runat="server"></asp:textbox>

            <asp:requiredfieldvalidator id="RequiredFieldValidator3" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Model_Box" forecolor="Red" display="Dynamic" errormessage="Car Model is Required"></asp:requiredfieldvalidator>

            <br />
            <asp:textbox id="Price_Box" cssclass="form-control" placeholder="ENTER CAR PRICE" runat="server"></asp:textbox>

            <asp:requiredfieldvalidator id="RequiredFieldValidator4" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Price_Box" forecolor="Red" display="Dynamic" errormessage="Car Price is Required"></asp:requiredfieldvalidator>

            <br />
            <asp:textbox id="Color_Box" cssclass="form-control" placeholder="ENTER CAR COLOR" runat="server"></asp:textbox>

            <asp:requiredfieldvalidator id="RequiredFieldValidator5" validationgroup="Add_Btn" setfocusonerror="true" runat="server" controltovalidate="Color_Box" forecolor="Red" display="Dynamic" errormessage="Car Color is Required"></asp:requiredfieldvalidator>

            <br />
            <asp:dropdownlist id="Status_List" cssclass="form-control" runat="server">
                <asp:ListItem>-- Select Available or Booked --</asp:ListItem>
                <asp:ListItem>Available</asp:ListItem>
                <asp:ListItem>Booked</asp:ListItem>
            </asp:dropdownlist>

            <asp:requiredfieldvalidator id="RequiredFieldValidator6" validationgroup="Add_Btn" setfocusonerror="true" initialvalue="-- Select Available or Booked --" runat="server" controltovalidate="Status_List" forecolor="Red" display="Dynamic" errormessage="Car Status is Required"></asp:requiredfieldvalidator>


            <br />
             <asp:button id="Reset_Button" OnClick="Reset_Button_Click"  cssclass="btn btn-danger float-end mb-4 me-3" runat="server" text="Reset " />

            <br />
            <div class="col-md-12 d-flex justify-content-around pb-4">
                <asp:button id="Update_Button" OnClick="Update_Button_Click" cssclass="btn btn-outline-primary " runat="server" text="Update Data" />
                <asp:button id="Add_Button" validationgroup="Add_Btn" onclick="Add_Button_Click" cssclass="btn btn-outline-success " runat="server" text="Add data" />
                <asp:button id="Delete_Button" OnClick="Delete_Button_Click" cssclass="btn btn-outline-danger" runat="server" text="Delete Data" />
               
            </div>
        </div>
        <div class="col-md-7 mx-auto">
            <h1 class="text-center">CAR LIST</h1><br />
            <asp:gridview id="Cars_GridView" class="table table-striped table-responsive table-hover table-bordered table-dark"  runat="server" autogeneratecolumns="False" OnSelectedIndexChanged="Cars_GridView_SelectedIndexChanged">
              
            <Columns>

                <asp:TemplateField HeaderText="SELECT ROW" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="Select_Rows" CssClass="btn btn-success" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR PLATE NUMBER">
                    <ItemTemplate>
                            <asp:Label ID="Label_Id" runat="server" Text='<%# Bind("Registration_no") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR BRAND" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Brand" runat="server" Text='<%# Bind("Brand") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR MODEL" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Model" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR PRICE" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Price" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR COLOR" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Color" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>

                <asp:TemplateField HeaderText="CAR STATUS" >
                    <ItemTemplate>
                            <asp:Label ID="Label_Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>




            </Columns>

            </asp:gridview>
        </div>
        </div>
</asp:Content>

