<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>FARMACIAS TOP | Iniciar Sesión</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css">

    <link rel="stylesheet" href="css/login.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login-logo">
                <b>FARMACIAS TOP</b>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Ingresa tus datos para iniciar sesión</p>
                <div class="form-group has-feedback">
                    <label>Usuario</label>
                    <asp:TextBox ID="tbUsuario" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group has-feedback">
                    <label>Contraseña</label>
                    <asp:TextBox ID="tbContrasena" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="row text-center">
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" class="btn btn-lg btn-success" OnClick="btnLogin_Click" />

                </div>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                <!-- /.login-box-body -->
            </div>
        </div>
        <!-- /.login-box -->
    </form>
    <!-- jQuery 3 -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
</body>
</html>
