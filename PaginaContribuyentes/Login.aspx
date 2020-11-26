<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PaginaContribuyentes.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link href="CSS/Login.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div class="login-wrap">
	<div class="login-html">

		<input id="tab-1" type="radio" name="tab" class="sign-in" ><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up" checked><label for="tab-2" class="tab">Sign Up</label>
		<div class="login-form">
			<div class="sign-in-htm">
				<br /><br />
				<div class="group">
					
					<asp:label ID="lblLMail" runat="server" CssClass="label" Text="Correo" />
					<asp:TextBox ID="txtLMail" runat="server" class="input" TextMode="Email" />
				</div>
				<div class="group">
					<asp:label ID="lblLPass" runat="server" CssClass="label" Text="Contraseña" />
					<asp:TextBox ID="txtLPass" runat="server" type="password" CssClass="input" />
				</div>
				
				<div class="group">
					<asp:Button ID="btnLogin" runat="server" CssClass="button" Text="Login" Onclick="btnLogin_Click" />

				</div>
				<div class="group">
					<asp:Label ID="lblMessage" runat="server" CssClass="label" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
				</div>
				
			</div>
			<%--Comienza Registro--%>
			<div class="sign-up-htm">
				<div class="group">					
					<asp:Label ID="lblnombre" runat="server" CssClass="label" Text="Nombre" />
					<asp:Textbox ID="txtNombre" runat="server" type="text" CssClass="input"/>
				</div>
				<div class="group">
					<asp:Label ID ="lblMail" runat="server" CssClass="label" Text="Correo" />
                    <asp:TextBox ID="txtMail" runat="server" CssClass="input" />				
				</div>
				<div class="group">
					<asp:label ID="lblPass" runat="server" CssClass="label" Text="Contraseña" />
					<asp:Textbox ID="txtpass" runat="server" type="password" CssClass="input" />
				</div>
				<div class="group">
					<asp:label ID="lblRFC" runat="server" CssClass="label" Text="RFC" />
					<asp:TextBox ID="txtRFC" runat="server" CssClass="input"  />
				</div>
				
				<div class="group">
                    <asp:Button ID="btnCrear" runat="server" CssClass="button" Text="Crear Cuenta" OnClick="btnCrear_Click"/>
				</div>
				<div class="group">
					<asp:Label ID="lblMessage1" runat="server" CssClass="label" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
				</div>
				<div class="group">
					<asp:Label ID="lblsuccess" runat="server" CssClass="label" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>					
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<label for="tab-1">¿Ya eres miembro?</a>
						
				</div>
			</div>
			<%--Termina Registro--%>
		</div>
	</div>
</div>
    </form>
</body>
</html>
