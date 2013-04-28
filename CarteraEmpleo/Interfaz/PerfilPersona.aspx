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
        <asp:Label runat="server" ID="lblNombre" Text="Nombre del Candidato"/>
        <br/>
        <br/>           
        <table class="datosBasicosPersona">
            <tr>
                <th class="tdborderbot"colspan="2">
                    Datos Básicos
                </th>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label runat="server" Text="Correo:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo"/>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="Label1" runat="server" Text="Telefonos:"/>
                </td>
                <td class="tdleft">
                    <div id="Telefonos" class="titulosDatosBasicos"><br/></div>
                    <asp:Panel ID="pnl" runat="server"></asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label runat="server" Text="Idiomas:"/>
                </td>
                <td class="tdleft">
                    <div id="Idiomas" class="titulosDatosBasicos"><br/></div>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label runat="server" Text="Dirección:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección de la persona" />
                </td>
            </tr> 
            <tr><td></td><td></td></tr>
            <tr>
                <th class="tdborderbot"colspan="2">
                Información Laboral
                </th> 
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label runat="server" Text="Condición Laboral:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="lblCondicion" runat="server" Text="Condición de la persona" />
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label runat="server" Text="Resumen Laboral:"/>
                </td>
                <td class="tdleft">
                    <asp:Label ID="lblExperiencia" runat="server" Text="Experiencia" />
                </td>
            </tr>
        </table>
    </div>  
</asp:Content>
