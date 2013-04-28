<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Empresa.aspx.cs" Inherits="CarteraEmpleo.Interfaz.Empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jQueryDefault.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="borderPerfilEmpresaPersona" >
        <div id="Div1" class="titulo" runat="server">Empresa</div>
        <br/>
        <div class="titulosDatosBasicos">Nombre:</div>
        <asp:Button ID="Button1" runat="server" CssClass="btmodificarEmprPers"  Text="Enviar Mensaje" />
        <br/>
        <asp:Label runat="server" ID="lbl_NombreEmpresa">Nombre de la empresa</asp:Label>
        <br/>
        <br/> 
        <div id="DatosBasicosEmpresa1" class="datosBasicosEmpresa" >
        <h4>Datos Básicos</h4>
        <hr/>
        
        <table>
            <tr>
                <td>
                    <div class="titulosDatosBasicos">Cedúla Jurídica: </div> <asp:Label runat="server" ID="CedulaJuridica1">Cedúla Jurídica</asp:Label>
                    <br/>
                    <br/>
                    <div class="titulosDatosBasicos">Correo Electronico: </div> <asp:Label runat="server" ID="Mail1">ContactoEmpresa@mail.com</asp:Label>
                    <br/>
                    <br/>
                    <div class="titulosDatosBasicos">Teléfonos: </div> <asp:Label runat="server" ID="Telefonos1">telefonos</asp:Label>
                    <br/>
                    <br/>
                    <div class="titulosDatosBasicos">Fax: </div> <asp:Label runat="server" ID="fax1">Número Fax</asp:Label>
                    <br/>
                    <br/>
                    <div class="titulosDatosBasicos">Ubicación: </div> <asp:Label runat="server" ID="Ubicación1">Ubicación de la empresa</asp:Label>
                </td>
                <td class="infoLaboralPersona" >
                    <div class="titulosDatosBasicos">Pagina Web: </div> <asp:Label runat="server" ID="PaginaWeb1">Empresa.com</asp:Label>
                    <br/>
                    <br/>
                    <div class="titulosDatosBasicos">Descripción: </div> <asp:Label runat="server" ID="Descripcion1">Descripción general de la empresa</asp:Label>
                </td>
                </tr>
        </table>
        </div>
        <br/>
        <div id="PuestosLaborales1" class="puestosLaboralesEmpresa" >
            <h4>Puestos Laborales en Oferta</h4>
            <hr/>
            <asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem>Guía Turistico</asp:ListItem>
                <asp:ListItem>Chofer</asp:ListItem>
                <asp:ListItem>Servicio General</asp:ListItem>
            </asp:ListBox>        
        </div>
    </div>
</asp:Content>