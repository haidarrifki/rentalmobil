<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginPelanggan.aspx.vb" Inherits="rental.LoginPelanggan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login Page</title>
    <link rel="stylesheet" href="~/assets/css/bootstrap.min.css" />
    <link href="~/assets/img/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
        body {
            margin-top: 150px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <div class="panel panel-info">
                    <div class="panel-heading"><h3 class="text-center">LOGIN PELANGGAN</h3></div>
                    <div class="panel-body">
                        <asp:Label ID="pesan" runat="server"></asp:Label>
                        <form id="flogin" runat="server">
                            <div class="form-group">
                                <label for="username">Username</label>
                                <asp:TextBox CssClass="form-control" ID="username" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password">Password</label>
                                <asp:TextBox CssClass="form-control" ID="password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-info btn-block" />
                        </form>
                    </div>
                    <div class="panel-footer">
                      Belum punya akun? <a href="Pelanggan/Daftar.aspx">daftar sekarang.</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>
    </div>
</body>
</html>
