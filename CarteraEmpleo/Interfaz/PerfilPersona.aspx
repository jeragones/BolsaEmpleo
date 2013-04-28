<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="PerfilPersona.aspx.cs" Inherits="CarteraEmpleo.Interfaz.PerfilPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jQueryPersona.js"></script>
    <script type="text/javascript" src="../Scripts/jQueryDefault.js"></script>
    <style type="text/css">
        .auto-style1 {
            margin-left: 10px;
            text-align: left;
            vertical-align: text-top;
            height: 48px;
        }
        .auto-style2 {
            margin-left: 10px;
            text-align: left;
            vertical-align: text-top;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="3" class="borderPerfilEmpresaPersona" >
        <div class="titulo">Candidato</div>
        <asp:Button ID="btnCorreo" runat="server" Class="btmodificarEmprPers" Text="Enviar Correo" />
        <div class="titulosDatosBasicos">Nombre:</div>
        <asp:Label runat="server" ID="lbl_NombreEmpresa" Text="Nombre del Candidato"/>
        <br/>
        <br/>           
        <table class="datosBasicosPersona">
            <tr>
                <th class="tdborderbot"colspan="2">
                    Datos Básicos
                </th>
            </tr>
            <tr>
                <td class="tdleft"><asp:Label ID="Label4" runat="server" Text="Cedúla:"/></td>
                <td class="tdleft"><asp:Label ID="Label8" runat="server" Text="Cedúla Persona"/></td>
            </tr>
            <tr>
                <td class="tdleft"><asp:Label ID="Label5" runat="server" Text="Teléfonos:"/></td>
                <td class="tdleft"><div class="titulosDatosBasicos"><asp:Label  ID="Label6" runat="server" Text="telefonos de contacto" /></div></td>
            </tr>
            <tr>
                <td class="tdleft"><asp:Label ID="Label9" runat="server" Text="Idiomas:"/></td>
                <td class="tdleft"><div id="Idiomas" class="titulosDatosBasicos"><br/></div></td>
            </tr>
            <tr>
                <td class="tdleft"><asp:Label ID="Label13" runat="server" Text="Dirección:"/></td>
                <td class="tdleft"><asp:Label ID="Label14" runat="server" Text="Dirección de la persona" /></td>
            </tr> 
            <tr><td></td><td></td></tr>
            <tr>
                <th class="tdborderbot"colspan="2">
                Información Laboral
                </th> 
            </tr>
            <tr>
                <td class="tdleft"><asp:Label ID="Label15" runat="server" Text="Condición Laboral:"/></td>
                <td class="tdleft"><asp:Label ID="Label16" runat="server" Text="Empleado-Desempleado"/></td>
            </tr>
            <tr>
                <td class="tdleft"><asp:Label ID="Label11" runat="server" Text="Resumen Laboral:" /></td>
                <td class="tdleft"><asp:Label ID="Label12" runat="server" Text="Descripción de trabajos realizados"/></td>
            </tr>
        </table>
    </div>  
</asp:Content>
