using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;
 
 namespace CarteraEmpleo
 {
     public partial class RegistroEmpresa : System.Web.UI.Page
     {
         cGeneralMetodos insMetodos = new cGeneralMetodos();
         cEmpresaDatos insEmpresa = new cEmpresaDatos();
         cCorreoComunicacion insCorreo = new cCorreoComunicacion();

         protected void Page_Load(object sender, EventArgs e)
         {
            ClientScriptManager cs = Page.ClientScript;
            String[] usuario = insMetodos.UsuarioLogin();
            
                //ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario[0] + "','0')", true);
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            String _sCedula = txtCedula1.Text + "-" + txtCedula2.Text + "-" + txtCedula3.Text;
            msgError.Text = insEmpresa.insertar(txtNombre.Text, txtContrasena.Text, txtContrasena.Text, _sCedula, txtCorreo.Text, txtWeb.Text);
            if (msgError.Text.Equals(""))
            {
                insMetodos.ModificarEstado(txtCorreo.Text, 'I');
                String asunto = "Solicitud de registro en Cartera de Empleo Turísmo";
                String mensaje = "<p>Cartera de Empleos de Turísmo </p>" +
                                 "<p>La empresa <b>" + txtNombre.Text + "</b> desea registrarse en el sitio web, a continuación aparece la información de la empresa: </p>" +
                                 "<br>" +
                                 "<table>" +
                                    "<tr>" +
                                        "<td>" +
                                            "<b>Nombre:</b>" +
                                        "</td>" +
                                        "<td>" +
                                            txtNombre.Text +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td>" +
                                            "<b>Correo Electrónico:</b>" +
                                        "</td>" +
                                        "<td>" +
                                            txtCorreo.Text +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td>" +
                                            "<b>Cédula Jurídica:</b>" +
                                        "</td>" +
                                        "<td>" +
                                            txtCedula1.Text + "-" + txtCedula2.Text + "-" + txtCedula3.Text +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td>" +
                                            "<b>Sitio Web:</b>" +
                                        "</td>" +
                                        "<td>" +
                                            txtWeb.Text +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td>" +
                                            "<b>Descripción:</b>" +
                                        "</td>" +
                                        "<td>" +
                                            txtDescripcion.Text +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td>" +
                                            "<b>Dirección:</b>" +
                                        "</td>" +
                                        "<td>" +
                                            txtDireccion.Text +
                                        "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<td>" +
                                        "</td>" +
                                        "<td>" +
                                            "<input type=" +
                                                    (char)34 + "button" + (char)34 +
                                                " value=" +
                                                    (char)34 + "Aprobar" + (char)34 +
                                                " onclick=" +
                                                    (char)34 + "window.open(" +
                                                                    //(char)34 + "http://localhost:49367/Interfaz/CompletarRegistro.aspx?U=" + txtCorreo.Text + "&T=5" + (char)34 +
                                                                    (char)34 + "http://google.co.cr" + (char)34 +
                                                               ")" +
                                                    (char)34 +
                                            " />&nbsp;" +
                                            "<input type=" +
                                                    (char)34 + "button" + (char)34 +
                                                " value=" +
                                                    (char)34 + "Rechazar" + (char)34 +
                                                " onclick=" +
                                                    (char)34 + "window.open(" +
                                                                    (char)34 + "http://localhost:49367/Interfaz/CompletarRegistro.aspx?U=" + txtCorreo.Text + "&T=6" + (char)34 +
                                                               ")" + 
                                                    (char)34 +
                                            " />" +
                                        "</td>" +
                                    "</tr>" +
                                 "</table>";
                Boolean respuesta = insCorreo.Correo("turismo.empleos@gmail.com", "Cartera de Empleo de Turísmo", txtCorreo.Text,
                                                     asunto, mensaje, txtContrasena.Text, null);
                Limpiar();
                Response.Redirect("~/Interfaz/CompletarRegistro.aspx?T=4");
            }
            else
            {
                imgError.Visible = true;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Response.Redirect("~/Default.aspx");
        }

        protected void Limpiar() {
            txtNombre.Text = "";
            txtCedula1.Text = "";
            txtCedula2.Text = "";
            txtCedula3.Text = "";
            txtCorreo.Text = "";
            txtWeb.Text = "";
            txtContrasena.Text = "";
            txtDireccion.Text = "";
            txtDescripcion.Text = "";
        }
    }
}