<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="ModPerfilPersona.aspx.cs" Inherits="CarteraEmpleo.Interfaz.ModificarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/jQueryDefault.js"></script>
    <script type="text/javascript" src="../Scripts/jQueryPersona.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="4" class="borderPerfilEmpresaPersona" >
        <div class="titulo">Perfil de Candidato</div>
        <asp:Button ID="btnGuardar" runat="server" Class="btmodificarEmprPers" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
        <br/>
        <div><asp:Label class="lblRegistrar" runat="server" Text="Nombre Completo:" /></div>
        <div><asp:TextBox ID="txtNombre" class="txt" runat="server" Text="<?php echo htmlentities($Usuario); ?>"  Visible="False" Height="20px" Width="160px" />
             <asp:Label ID="lblNombre" name="txtNombre" class="lblRegistrar" runat="server" Text="Nombre" />
             <asp:LinkButton class="Link" runat="server" ID="hplNombre" text="Editar" OnClick="hplNombre_Click" />
        </div> 
        <asp:Image ID="imgError" Visible="false" class="imgError" runat="server" Width="12px" Height="12px" ImageUrl="/Images/error1.png" />
                               &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" /> 
        <br/><br/>
        <table class="datosBasicosPersona">
            <tr>
                <th class="tdborderbot"colspan="3">
                    Datos Básicos
                </th>
            </tr>
            <!--<tr>   
                <td class="tdleft">
                    <asp:Label class="lblRegistrar" runat="server" Text="Cédula:" />
                </td>
                <td class="tdleft">
                    <asp:TextBox class="txt" runat="server" placeholder="0-0000-0000" ID="txtCedula"  Visible="False" Height="20px" />
                    <asp:Label ID="lblCedula" class="lblRegistrar" runat="server" Text="Cedúla Persona" />
                </td>
                <td class="tdleft">
                    <asp:LinkButton runat="server" ID="hplCedula" text="Editar" />
                </td>
            </tr>-->
            <tr>
                <td class="tdleft">
                    <asp:Label class="lblRegistrar" runat="server" Text="Teléfono:" />
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtTelefono" class="txt" runat="server" placeholder="0000-0000"  Visible="False" Height="20px" Width="160px" />&nbsp;
                    <asp:Button ID="btnAgregarTelefono" CssClass="btnAgregar"  runat="server" onclick="AgregarTelefono_Click" Visible="false"/>
                    <div id="Telefonos" class="telefonos"></div> <!--mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm-->
                </td>
                <td>
                    <asp:LinkButton class="Link" runat="server" ID="hplTelefono" text="Agregar" OnClick="hplTelefono_Click" />
                </td>
                <td class="tdleft">
                    
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label class="lblRegistrar" runat="server" Text="Idioma(s):" />
                </td>
                <td class="tdleft">
                    <asp:DropDownList ID="cmbIdioma" class="txt" runat="server"  Visible="False" Height="20px" Width="166px"/>&nbsp;
                    <asp:Button ID="btnAgregarIdioma" CssClass="btnAgregar"  runat="server" onclick="AgregarIdioma_Click" Visible="false"/>
                    <div id="Idiomas" class="idiomas"></div> <!--mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm-->
                </td>
                <td>
                    <asp:LinkButton class="Link" runat="server" ID="hplIdioma" text="Agregar" OnClick="hplIdioma_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label class="lblRegistrar" runat="server" Text="Dirección:" />
                </td>
                <td class="tdleft">
                    <asp:TextBox class="txta" runat="server" TextMode="MultiLine" ID="txtDireccion" Visible="False" Width="160px" />
                    <asp:Label ID="lblDireccion" class="lblRegistrar" runat="server" Text="Nombre" />
                </td>
                <td class="tdleft">
                    <asp:LinkButton class="Link" runat="server" ID="hplDireccion" text="Editar" OnClick="hplDireccion_Click" />
                </td>
           </tr>
           <tr>
                <th class="tdborderbot"colspan="3">
                    <br/><br/>
                    Infirmación Laboral
                </th> 
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label class="lblRegistrar" runat="server" Text="Condicion Laboral:" />
                </td>
                <td class="tdleft">
                    <asp:DropDownList ID="cmbCondicion" class="txt" runat="server" Visible="False" Height="20px" Width="166px">
                    <asp:ListItem Selected="True" Text="Desempleado" />
                    <asp:ListItem Text="Empleado" />
                    </asp:DropDownList> 
                    <asp:Label ID="lblCondicion" class="lblRegistrar" runat="server" Text="Empleado-Desempleado" />
                </td>
                <td class="tdleft">
                    <asp:LinkButton class="Link" runat="server" ID="hplCondicion" text="Editar" OnClick="hplCondicion_Click" />
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label class="lblRegistrar" runat="server" Text="Información Adicional:" />
                </td>
                <td class="tdleft">
                    <asp:TextBox Class="txta" runat="server" TextMode="MultiLine" ID="txtExperiencia"  Visible="False" />
                    <asp:Label ID="lblExperiencia" class="lblRegistrar" runat="server" Text="Nombre" />
                </td>
                <td class="tdleft">
                    <asp:LinkButton class="Link" runat="server" ID="hplExperiencia" text="Editar" OnClick="hplExperiencia_Click" />
                </td>
            </tr>
            <tr> 
                <th class="tdborderbot"colspan="3">
                    <br/><br/>
                    Configuracion
                </th>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="lblContrasena1" class="lblRegistrar" runat="server" Text="Contraseña:" />
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtContrasena1" class="txt" runat="server"  TextMode="Password" Visible="False" Height="20px" Width="144px" />
                    <asp:Label ID="lblContrasena" class="lblRegistrar" runat="server" Text="&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;&#8226;" />
                </td>
                <td class="tdleft">
                    <asp:LinkButton ID="hplContrasena" class="Link" runat="server"  text="Editar" OnClick="hplContrasena_Click" />
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="lblContrasena2" class="lblRegistrar" runat="server" Text="Nueva contraseña:" visible="false" />
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtContrasena2" class="txt" runat="server"  TextMode="Password" Visible="False" Height="20px" Width="144px" />
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    <asp:Label ID="lblContrasena3" class="lblRegistrar" runat="server" Text="Confirmar contraseña:" visible="false" />
                </td>
                <td class="tdleft">
                    <asp:TextBox ID="txtContrasena3" class="txt" runat="server"  TextMode="Password" Visible="False" Height="20px" Width="144px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>