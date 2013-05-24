<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="BusquedaEmpresa.aspx.cs" Inherits="CarteraEmpleo.Interfaz.BusquedaEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="Div1" class="registrar" runat="server">
        <div class="titulo">Busqueda de Empresa</div>
        <br/>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" class="lblRegistrar" runat="server" Text="Nombre:" />
                </td>
                <td>
                     <asp:TextBox ID="txbNombre" Class="txt" runat="server"  Height="20px" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Ubicación:" />
                </td>
                <td>
                    <asp:TextBox ID="txbUbicación" Class="txt" runat="server"  Height="20px" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label class="lblRegistrar" runat="server" Text="Salario Mínimo:" />
                </td>
                <td>
                   <asp:TextBox ID="txbSalarioMin" Class="txt" runat="server" Height="20px" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label class="lblRegistrar" runat="server" Text="Salario Máximo:" />
                </td>
                <td>
                   <asp:TextBox ID="txbSalarioMax" Class="txt" runat="server" Height="20px" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Puesto" class="lblRegistrar" runat="server" Text="Puesto:" />
                <td>
                      <asp:TextBox ID="txbPuesto" Class="txt" runat="server"  Height="20px" Width="200px" />
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
                </td>
                <td>
                    <asp:Button class="btn" runat="server" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" />
                    <br/>
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