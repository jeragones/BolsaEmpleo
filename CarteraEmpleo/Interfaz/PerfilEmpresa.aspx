<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="PerfilEmpresa.aspx.cs" Inherits="CarteraEmpleo.Interfaz.PerfilEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jQueryDefault.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="3" class="borderPerfilEmpresaPersona" >
        <div class="titulo">Perfil Empresa</div>
        <asp:Button ID="btnCorreo" runat="server" Class="btmodificarEmprPers" Text="Enviar Correo" />
        <br/>
        <div class="titulosDatosBasicos">Nombre:</div>
        <asp:Label runat="server" ID="lbl_NombreEmpresa" Text="Nombre de la empresa"/>
        <br/><br/>   
        <table class="datosBasicosPersona">
            <tr>
                <th class="tdborderbot"colspan="2">Datos Básicos</th>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label4" runat="server" Text="Cedúla Jurídica:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="Label1" runat="server" Text="Cedúla Jurídica"/>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label5" runat="server" Text="Correo Electronico"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="Label6" runat="server" Text="ContactoEmpresa@mail.com"/>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label2" runat="server" Text="Teléfonos:"/>
                </td>
                <td class="tdleft">
                    <div class="titulosDatosBasicos">
                        <asp:Label  ID="Label3" runat="server" Text="telefonos de contacto" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label7" runat="server" Text="Fax:"/>
                </td>
                <td class="tdleft">
                    <div class="titulosDatosBasicos">
                        <asp:Label  ID="Label8" runat="server" Text="faxes de contacto" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label13" runat="server" Text="Dirección:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="Label14" runat="server" Text="Dirección de la empresa"/>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label9" runat="server" Text="Pagina Web"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="Label10" runat="server" Text="Empresa.com"/>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label17" runat="server" Text="Descripción:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="Label18" runat="server" Text="Descripción de la empresa"/>
                </td>
            </tr>
        </table>
        <table class="datosBasicosPersona">
		<tr>
            <th class="tdborderbot"colspan="2">Puestos Laborales en Oferta</th>
		</tr>
        <tr>
            <td class="tdleft">
                <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1"  DataKeyNames="#">
                    <Columns>
                        <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <asp:Button ID="btEliminarOfertasEmpleo" runat="server" CssClass="btmodificarEmprPers" Text="Eliminar" OnClick="btEliminarOfertasEmpleo_Click" />
            </td>
        </tr>
        <tr>
            <td class="tdleft">
                <Table>
                    <tr>
                        <td>
                            <asp:TextBox ID="NumJornada" runat="server" placeholder="Numero de Jornada"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Horario" runat="server" placeholder="Horario"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Conocimientos" runat="server" placeholder="Conocimientos"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Salario" runat="server" placeholder="Salario"></asp:TextBox>
                        </td>    
                    </tr>
                </Table>
            </td>
            <td><asp:Button ID="InsertarPublicacion" runat="server" Text="Agregar" CssClass="btmodificarEmprPers" OnClick="InsertarPublicacion_Click"/></td> 
        </tr>
    </table>
    </div>
</asp:Content>
