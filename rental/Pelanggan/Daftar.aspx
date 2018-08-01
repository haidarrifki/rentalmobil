<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Daftar.aspx.vb" Inherits="rental.Daftar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Pendaftaran Pelanggan</title>
    <link rel="stylesheet" href="~/assets/css/bootstrap.min.css" />
    <link href="~/assets/img/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style>
        body {
            margin-top: 40px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
              <div class="container">
		        <div class="col-md-2"></div>
		        <div class="col-md-8">
			        <div class="page-header">
                        <h2>Form Pendaftaran</h2>
                    </div>
			        <form id="fdaftarpelanggan" runat="server">
				        <div class="form-group">
					        <label for="nama">Nama</label>
					        <asp:TextBox CssClass="form-control" ID="nama" runat="server"></asp:TextBox>
				        </div>
				        <div class="form-group">
					        <label for="no_ktp">No KTP</label>
					        <asp:TextBox CssClass="form-control" ID="ktp" runat="server"></asp:TextBox>
				        </div>
				        <div class="form-group">
					        <label for="no_telp">No Telp</label>
                            <asp:TextBox CssClass="form-control" ID="telp" TextMode="Phone" runat="server"></asp:TextBox>
				        </div>
				        <div class="form-group">
					        <label for="alamat">Alamat</label>
                            <asp:TextBox CssClass="form-control" ID="alamat" runat="server"></asp:TextBox>
				        </div>
				        <div class="form-group">
					        <label for="email">email</label>
					        <asp:TextBox CssClass="form-control" ID="email" TextMode="Email" runat="server"></asp:TextBox>
				        </div>
				        <div class="form-group">
					        <label for="username">Username</label>
					        <asp:TextBox CssClass="form-control" ID="username" runat="server"></asp:TextBox>
				        </div>
				        <div class="form-group">
					        <label for="password">Password</label>
					        <asp:TextBox CssClass="form-control" ID="password" TextMode="Password" runat="server"></asp:TextBox>
				        </div>
                            <asp:Button ID="btnSimpan" runat="server" Text="Simpan" CssClass="btn btn-primary btn-block" />
						</form>
                    </div>
		            <div class="col-md-2"></div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
