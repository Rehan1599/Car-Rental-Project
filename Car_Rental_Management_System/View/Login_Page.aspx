<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_Page.aspx.cs" Inherits="View_Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link href="../Assets/Sweet_Alert/sweetalert2.min.css" rel="stylesheet" />
    <link href="../Assets/Libraries/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Assets/CSS/Style.css" rel="stylesheet" />
    <script src="../Assets/Sweet_Alert/sweetalert2.min.js"></script>
    <script src="../Assets/Libraries/bootstrap/js/bootstrap.min.js"></script>
</head>
<body id="page">
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center mt-5">CAR RENTAL MANAGEMENT SYSTEM </h1>
            <h1 class="text-center">LOGIN</h1>
            <br />
            
            <div class="text-center">
                <%--<img src="../Assets/Img/car-2-removebg.png" width="300" height="190"/>--%>

                <img src="../Assets/Img/car-4-removebg-1.png" width="300" height="120"/>
            </div>
            <div class="row">
                <div class="col-md-6 mx-auto">

                    <asp:Label ID="User_Label" runat="server" Text="UserId Or Email"></asp:Label>
                    <asp:TextBox ID="User_Box" CssClass="form-control" placeholder="Enter UserId Or Email" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Pass_Label" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Pass_Box" CssClass="form-control" placeholder="Enter Password" runat="server"></asp:TextBox>

                    <asp:RadioButton ID="Cust_Radio" Checked="true" GroupName="Login_Radio" runat="server" />CUSTOMER&nbsp;<asp:RadioButton ID="Admin_Radio" GroupName="Login_Radio" runat="server" />ADMIN
                    <br />
                    <div class="col-md-10 d-grid mx-auto pt-3">
                        <asp:Button ID="Login_Button" CssClass="btn btn-outline-light" OnClick="Login_Button_Click" runat="server" Text="Login" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
