<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.User.Login" %>

<!DOCTYPE html>
<html>
<head>
    <%--<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">--%>
    <title>Madhuram Industries</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="../../Content/AdminPanel/assets/plugins/fontawesome-free/css/all.min.css">
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <link rel="stylesheet" href="../../Content/AdminPanel/assets/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <link rel="stylesheet" href="../../Content/AdminPanel/assets/dist/css/adminlte.min.css">
    <link href="../../AdminPanel/assets/dist/css/alert_css.css" rel="stylesheet" type="text/css">
    <link href="../../AdminPanel/assets/dist/css/alert_css_2.css" rel="stylesheet" type="text/css">

     <%--login password check pop-up--%>
    <script>
        function fun_login_check() {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'UserID And Password Are Wrong...!',
            })
        }
    </script>
</head>

<body class="hold-transition login-page">
    <form runat="server">
        
    <%--<div class="login-box container-fluid" style="zoom:150%;">--%>
        <div class="login-box container-fluid">
        <div class="login-logo">
            <%--<a href="#"><b>Madhuram Industries</b></a>--%>
            <a href="#"><asp:Image runat="server" ImageUrl="~/Content/AdminPanel/assets/logo/Madhuram.png" Width="300px"/></a>
        </div>
        <div class="card">
            <div class="card-body login-card-body">
                <p class="login-box-msg text">SIGN IN TO START YOU SESSION</p>

                <asp:Label runat="server" ID="lblUserName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                <div class="input-group form-group">
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="User Name" AutoCompleteType="Disabled"/>
                    <div class="input-group-append">
                        <div class="input-group-text">
                            <span class="fas fa-user"></span>
                        </div>
                    </div>
                </div>

                <asp:Label runat="server" ID="lblUserPassword" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label> 
                <div class="input-group form-group">
                    <asp:TextBox runat="server" ID="txtUserPassword" TextMode="Password" CssClass="form-control" placeholder="Password" CausesValidation="false" AutoPostBack="false"/>
                    <div class="input-group-append">
                        <div class="input-group-text">
                            <span class="fas fa-lock"></span>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12 form-group text-center">
                        <asp:Label runat="server" ID="lblPasswordIncorrect" Visible="false" ForeColor="Red" Font-Bold="true" Text="Invalid Sign-In Credentials"></asp:Label>    
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <asp:Button runat="server" ID="btnSignIn" CssClass="btn btn-primary btn-block" Text="Sign In" OnClick="btnSignIn_Click" CausesValidation="false"/>
                    </div>
                </div>

            </div>
        </div>
    </div>


    </form>
    <script src="../../Content/AdminPanel/assets/plugins/jquery/jquery.min.js"></script>
    <script src="../../Content/AdminPanel/assets/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="../../Content/AdminPanel/assets/dist/js/adminlte.min.js"></script>
    <script src="../../AdminPanel/assets/dist/js/alert.js" type="text/javascript"></script>
    <script src="../../AdminPanel/assets/dist/js/aler2.js" type="text/javascript"></script>
    
</body>
</html>