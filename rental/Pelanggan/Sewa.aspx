<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sewa.aspx.vb" Inherits="rental.Sewa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
	<link rel="icon" type="image/png" href="~/assets/img/favicon.ico" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

	<title>Sewa Mobil</title>

	<meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <meta name="viewport" content="width=device-width" />


    <!-- Bootstrap core CSS     -->
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Animation library for notifications   -->
    <link href="~/assets/css/animate.min.css" rel="stylesheet"/>

    <!--  Light Bootstrap Table core CSS    -->
    <link href="~/assets/css/light-bootstrap-dashboard.css" rel="stylesheet"/>


    <!--  CSS for Demo Purpose, don't include it in your project     -->
    <link href="~/assets/css/demo.css" rel="stylesheet" />


    <!--     Fonts and icons     -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,700,300' rel='stylesheet' type='text/css' />
    <link href="~/assets/css/pe-icon-7-stroke.css" rel="stylesheet" />
</head>
<body>
<div class="wrapper">
    <div class="sidebar" data-color="purple" data-image="../assets/img/sidebar-5.jpg">

    <!--   you can change the color of the sidebar using: data-color="blue | azure | green | orange | red | purple" -->


    	<div class="sidebar-wrapper">
            <div class="logo">
                <a href="http://www.creative-tim.com" class="simple-text">
                    Pelanggan Area
                </a>
            </div>

            <ul class="nav">
                <li class="active">
                    <a href="Mobil.aspx">
                        <i class="pe-7s-car"></i>
                        <p>Mobil</p>
                    </a>
                </li>
                <li>
                    <a href="Riwayat.aspx">
                        <i class="pe-7s-graph"></i>
                        <p>Riwayat</p>
                    </a>
                </li>
            </ul>
    	</div>
    </div>

    <div class="main-panel">
		<nav class="navbar navbar-default navbar-fixed">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navigation-example-2">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="#">Data Mobil</a>
                </div>
                <div class="collapse navbar-collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                              <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <p>
										Account
										<b class="caret"></b>
									</p>

                              </a>
                              <ul class="dropdown-menu">
                                <li><a href="../Logout.aspx">Logout</a></li>
                              </ul>
                        </li>
						<li class="separator hidden-lg hidden-md"></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="header">
                                <h4 class="title">Sewa Mobil</h4>
                            </div>
                            <div class="content">
                                <form id="faddmobil" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Lama Sewa</label>
                                                <asp:DropDownList ID="lama" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1" Text="1 Hari"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2 Hari"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="3 Hari"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="4 Hari"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="5 Hari"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="6 Hari"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="7 Hari"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Tanggal Ambil</label>
                                                <asp:DropDownList ID="tahun" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="" Text="-- Tahun --"></asp:ListItem>
                                                    <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                                    <asp:ListItem Value="2018" Text="2019"></asp:ListItem>
                                                    <asp:ListItem Value="2018" Text="2020"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>&nbsp;</label>
                                                <asp:DropDownList ID="bulan" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="" Text="-- Bulan --"></asp:ListItem>
                                                    <asp:ListItem Value="01" Text="1"></asp:ListItem>
                                                    <asp:ListItem Value="02" Text="2"></asp:ListItem>
                                                    <asp:ListItem Value="03" Text="3"></asp:ListItem>
                                                    <asp:ListItem Value="04" Text="4"></asp:ListItem>
                                                    <asp:ListItem Value="05" Text="5"></asp:ListItem>
                                                    <asp:ListItem Value="06" Text="6"></asp:ListItem>
                                                    <asp:ListItem Value="07" Text="7"></asp:ListItem>
                                                    <asp:ListItem Value="08" Text="8"></asp:ListItem>
                                                    <asp:ListItem Value="09" Text="9"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>&nbsp;</label>
                                                <asp:DropDownList ID="tanggal" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="" Text="-- Tanggal--"></asp:ListItem>
                                                    <asp:ListItem Value="01" Text="1"></asp:ListItem>
                                                    <asp:ListItem Value="02" Text="2"></asp:ListItem>
                                                    <asp:ListItem Value="03" Text="3"></asp:ListItem>
                                                    <asp:ListItem Value="04" Text="4"></asp:ListItem>
                                                    <asp:ListItem Value="05" Text="5"></asp:ListItem>
                                                    <asp:ListItem Value="06" Text="6"></asp:ListItem>
                                                    <asp:ListItem Value="07" Text="7"></asp:ListItem>
                                                    <asp:ListItem Value="08" Text="8"></asp:ListItem>
                                                    <asp:ListItem Value="09" Text="9"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                    <asp:ListItem Value="13" Text="13"></asp:ListItem>
                                                    <asp:ListItem Value="14" Text="14"></asp:ListItem>
                                                    <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                                    <asp:ListItem Value="16" Text="16"></asp:ListItem>
                                                    <asp:ListItem Value="17" Text="17"></asp:ListItem>
                                                    <asp:ListItem Value="18" Text="18"></asp:ListItem>
                                                    <asp:ListItem Value="19" Text="19"></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                    <asp:ListItem Value="21" Text="21"></asp:ListItem>
                                                    <asp:ListItem Value="22" Text="22"></asp:ListItem>
                                                    <asp:ListItem Value="23" Text="23"></asp:ListItem>
                                                    <asp:ListItem Value="24" Text="24"></asp:ListItem>
                                                    <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                                    <asp:ListItem Value="26" Text="26"></asp:ListItem>
                                                    <asp:ListItem Value="27" Text="27"></asp:ListItem>
                                                    <asp:ListItem Value="28" Text="28"></asp:ListItem>
                                                    <asp:ListItem Value="29" Text="29"></asp:ListItem>
                                                    <asp:ListItem Value="30" Text="30"></asp:ListItem>
                                                    <asp:ListItem Value="31" Text="31"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Pakai Supir?</label>
                                                <asp:DropDownList ID="supir" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="Ya" Text="Ya"></asp:ListItem>
                                                    <asp:ListItem Value="Tidak" Text="Tidak"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Jaminan</label>
                                                <asp:DropDownList ID="jaminan" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="stnk" Text="STNK"></asp:ListItem>
                                                    <asp:ListItem Value="sertifikat rumah" Text="Sertifikat Rumah"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnSimpan" runat="server" Text="Selanjutnya" CssClass="btn btn-success btn-fill pull-right" />
                                    <div class="clearfix"></div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <footer class="footer">
            <div class="container-fluid">
            </div>
        </footer>
    </div>
</div>
</body>
    <!--   Core JS Files   -->
    <script src="../assets/js/jquery-1.10.2.js" type="text/javascript"></script>
	<script src="../assets/js/bootstrap.min.js" type="text/javascript"></script>

	<!--  Checkbox, Radio & Switch Plugins -->
	<script src="../assets/js/bootstrap-checkbox-radio-switch.js"></script>

	<!--  Charts Plugin -->
	<script src="../assets/js/chartist.min.js"></script>

    <!--  Notifications Plugin    -->
    <script src="../assets/js/bootstrap-notify.js"></script>

    <!--  Google Maps Plugin    -->
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>

    <!-- Light Bootstrap Table Core javascript and methods for Demo purpose -->
	<script src="../assets/js/light-bootstrap-dashboard.js"></script>

	<!-- Light Bootstrap Table DEMO methods, don't include it in your project! -->
	<script src="../assets/js/demo.js"></script>
</html>
