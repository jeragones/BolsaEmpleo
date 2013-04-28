<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Persona.aspx.cs" Inherits="CarteraEmpleo.Interfaz.Persona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="3" class="borderPerfilEmpresaPersona">
        <div class="titulo">Candidato</div>
        <br/>
        <div class="titulosDatosBasicos">Nombre:</div>
        <asp:Button ID="Button1" runat="server" CssClass="btmodificarEmprPers" Text="Enviar Mensaje" />    
        <br/>
        <asp:Label runat="server" ID="lbl_NombreEmpresa" >Nombre del Candidato</asp:Label>
        <br/>
        <br/>
        <table class="datosBasicosPersona" >
            <tr>
                <td>
                    <h4>Datos Básicos</h4>
                    <hr/>
                    <div class="titulosDatosBasicos">Cedúla: </div> 
                    <asp:Label runat="server" ID="CedulaPersona">Cedúla Persona</asp:Label>
                    <br/><br />
                    <div class="titulosDatosBasicos">Teléfonos:</div> 
                    <asp:Label runat="server" ID="Telefonos1">telefonos de contacto</asp:Label>
                    <br /><br />
                    <div class="titulosDatosBasicos">Idiomas:</div> 
                    <asp:Label runat="server" ID="Idiomas1">Español-Ingles-Frances</asp:Label>
                    <br /><br />
                    <div class="titulosDatosBasicos">Dirección: </div> 
                    <asp:Label runat="server" ID="Direccion1">Ubicación de la empresa</asp:Label>
                </td>
                <td class="infoLaboralPersona" >
                    <h4>Información Laboral</h4>
                    <hr/>
                    <div class="titulosDatosBasicos"> Condición Laboral: </div> 
                    <asp:Label runat="server" ID="PaginaWeb1">Empleado-Desempleado</asp:Label>
                    <br /><br />
                    <div class="titulosDatosBasicos"> Resumen Laboral: </div> 
                    <asp:Label runat="server" ID="Descripcion1">Descripción de trabajos realizados</asp:Label>
                </td>
             </tr>
        </table>
    </div> 
</asp:Content>
