using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;
 
 
 namespace CarteraEmpleo
 {
     public partial class RegistroPersona : System.Web.UI.Page
     {
        cGeneralMetodos insMetodos = new cGeneralMetodos();
        cCorreoComunicacion insCorreo = new cCorreoComunicacion();
        cPersonaDatos insPersona = new cPersonaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScriptManager cs = Page.ClientScript;
            String[] usuario = insMetodos.UsuarioLogin();
 
            ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario[0] + "','0')", true);
            
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            msgError.Text = insPersona.Insertar(txtNombre.Text, txtCorreo.Text, cmbCondicion.Text, 
                                             txtContrasena.Text, txtConfirmarContrasena.Text, txtDireccion.Text);
            if (msgError.Text.Equals(""))
            {
                String asunto = "Registro de Cartera de Empleo";
                String mensaje = "Buenos días "+ txtNombre.Text +
                                 "<br />" + "Gracias por su registro de usuario en la Cartera de Empleos de Turísmo, para completar su registro ingrese al enlace que aparece a continuación: " +
                                 "<br />" + "http://localhost:49367/Interfaz/CompletarRegistro.aspx?U=" + txtCorreo.Text + ",T=1"; 
                Boolean respuesta = insCorreo.Correo(txtCorreo.Text, "Administrador", "correo del administrador", 
                                                     asunto, mensaje, "Contrasena", "archivo");
                Limpiar();
                Response.Redirect("~/Interfaz/CompletarRegistro.aspx?T=2");
            }
            else 
            {
                imgError.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaz/Default.aspx");
            Limpiar();
        }

        protected void Limpiar()
        {
            imgError.Visible = false;
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtContrasena.Text = "";
            txtConfirmarContrasena.Text = "";
            cmbCondicion.SelectedIndex = 0;
            txtDireccion.Text = "";
            msgError.Text = "";
        }
    }
}