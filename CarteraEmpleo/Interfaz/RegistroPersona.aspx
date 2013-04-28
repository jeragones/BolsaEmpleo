<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="RegistroPersona.aspx.cs" Inherits="CarteraEmpleo.RegistroPersona" %>
<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="Body" runat="server">
    <div class="registrar" runat="server">
        <div class="titulo">Registrar Usuario</div>
        <br/>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="Nombre Completo:" />
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" class="txt" runat="server" Height="20px" Width="200px" />
                </td>
                <td>
                    <div class="asterisco"> *</div>
                </td>
            </tr>
            <!--<tr>
                <td><asp:Label runat="server" Text="Cédula:" /></td>
                <td><asp:TextBox class="txt" runat="server" placeholder="1-1111-1111" ID="txtCedula" /></td>
            </tr>-->
            <tr>
                <td>
                    <asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Correo electrónico:" />
                </td>
                <td>
                    <asp:TextBox ID="txtCorreo" Class="txt" runat="server" placeholder="example@mail.com" Height="20px" Width="200px" />
                </td>
                <td>
                    <div class="asterisco"> *</div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Teléfono:" />
                </td>
                <td>
                    <asp:TextBox ID="txtTelefono" class="txt" runat="server" placeholder="0000-0000" Height="20px" Width="200px" />
                </td>
                <td>
                    <div class="asterisco"> *</div>
                </td>
            </tr>
            <!--<tr>
                <td><asp:Label class="lblRegistrar" runat="server" Text="Idioma(s):" /></td>
                <td><asp:DropDownList ID="cmbIdioma" class="txt" runat="server" /></td>
            </tr>-->
            <tr>
                <td>
                    <asp:Label ID="Label4" class="lblRegistrar" runat="server" Text="Condicion Laboral:" />
                </td>
                <td>
                    <asp:DropDownList ID="cmbCondicion" class="txt" runat="server" Height="20px" Width="200px" >
                        <asp:ListItem Selected="True" Text="Desempleado" />
                        <asp:ListItem Text="Empleado" />
                    </asp:DropDownList>
                </td>
                <!--<td>
                    <asp:RadioButton runat="server" Text="Empleado" GroupName="rbtCondicionLaboral" ID="rbEmpleado" />
                    <asp:RadioButton runat="server" Text="Desempleado" GroupName="rbtCondicionLaboral" ID="rbDesempleado" />
                </td>-->
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" class="lblRegistrar" runat="server" Text="Contraseña:" />
                </td>
                <td>
                    <asp:TextBox class="txt" runat="server" ID="txtContrasena" TextMode="Password" ToolTip="La contraseña debe tiener un mínimo de 9 caracteres." Height="20px" Width="200px" />
                </td>
                <td>
                    <div class="asterisco"> *</div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" class="lblRegistrar" runat="server" Text="Confirmar contraseña:" />
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmarContrasena" class="txt" runat="server" TextMode="Password" Height="20px" Width="200px" />
                </td>
                <td>
                    <div class="asterisco"> *</div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" class="lblRegistrar" runat="server" Text="Dirección:" />
                </td>
                <td>
                    <asp:TextBox ID="txtDireccion" class="txta" runat="server" TextMode="MultiLine" Width="200px" />
                </td>
            </tr>
            <!--<tr>
                <td><asp:Label class="lblRegistrar" runat="server" Text="Experiencia Laboral:" /></td>
                <td><asp:TextBox Class="txta" runat="server" TextMode="MultiLine" ID="txtExperiencia" /></td>
            </tr>-->
            <tr>
                <td></td>
                <td>
                    <asp:Image ID="imgError" Visible="false" class="imgError" runat="server" Width="12" Height="12" ImageUrl="/Images/error1.png" />
                               &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td>
                    <br/>
                    <asp:Button class="btn" runat="server" Text="Registrarse" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                </td>
                <td>
                    <br/>
                    <asp:Button class="btn" runat="server" Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" NavigateUrl="~/Default.aspx" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>