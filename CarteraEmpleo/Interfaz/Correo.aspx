<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Correo.aspx.cs" Inherits="CarteraEmpleo.Interfaz.Correo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div id="Div1" class="registrar" runat="server">
        <div class="titulo">Enviar Correo</div>
        <br/>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="De:" />
                </td>
                <td>
                    <asp:Label ID="txtDe" class="txt" runat="server" Height="20px" Text="" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Para:" />
                </td>
                <td>
                    <asp:Label ID="txtPara" Class="txt" runat="server" Text="" Height="20px" Width="200px" />
                </td>
            </tr>   
           <tr>
                <td>
                    <asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Asunto:" />
                </td>
                <td>
                    <asp:TextBox ID="txtAsunto" Class="txt" runat="server" Text="" Height="20px" Width="202px" />
                </td>
            </tr>          
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtDireccion" class="txta" runat="server" TextMode="MultiLine" Width="365px" Height="196px" />
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
                    <asp:Button class="btn" runat="server" Text="Enviar" ID="btnEnviar"/>
                </td>
                <td>
                    <br/>
                    <asp:Button class="btn" runat="server" Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" NavigateUrl="~/Default.aspx" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>