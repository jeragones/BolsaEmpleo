<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="BusquedaPersona.aspx.cs" Inherits="CarteraEmpleo.Interfaz.BusquedaPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="Div1" class="registrar" runat="server">
        <div class="titulo">Busqueda Candidato</div>
        <br/>
        <table>
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
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Idioma:" />
                </td>
                <td>
                    <asp:TextBox ID="txtIdioma" Class="txt" runat="server"  Height="20px" Width="200px" />
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="Resumen Laboral:" />
                </td>
                <td>
                    <asp:TextBox ID="txtResumen" class="txta" runat="server" TextMode="MultiLine" Width="200px" />
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
                    <asp:Button class="btn" runat="server" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" />
                </td>
                <td>
                    <br/>
                    <asp:Button class="btn" runat="server" Text="Cancelar" ID="btnCancelar" NavigateUrl="~/Default.aspx" OnClick="btnCancelar_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Resultados:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="msgResultado" class="lblRegistrar" runat="server" Text="No se encontraron resultados." Visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="panel" runat="server" CssClass="pnl"></asp:Panel>
                </td>
            </tr>
            <!--<tr>
                <td class="tdleft" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" DataKeyNames="#">
                        <Columns>
                            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>-->
        </table>
    </div>
</asp:Content>