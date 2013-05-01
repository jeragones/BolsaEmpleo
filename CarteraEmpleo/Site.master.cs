using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;
using CarteraEmpleo.Clases;
using CarteraEmpleo.Interfaz;

namespace CarteraEmpleo
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static string USUARIO = "";
        public static string CONTRASENA = "";
        public static int TIPO = 0;

        Service1 webservice = new Service1();
        _Default insDefault = new _Default();
        cPersonaDatos insPersona = new cPersonaDatos();
        cEmpresaDatos insEmpresa = new cEmpresaDatos();
        cGeneralMetodos insMetodos = new cGeneralMetodos();
        cInterfaz insInterfaz = new cInterfaz();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Usuario())
            {
                txtCorreo.Visible = false;
                txtContrasena.Visible = false;
                btnIniciarSesion.Visible = false;
                lnkCerrarSesion.Visible = true;
                lnkNombre.Visible = true;
                lnkNombre.Text = cPersonaDatos.NOMBRE;
            }
            else
            {
                /* tiene que mostrar un mensaje de error indicando que el usuario es invalido*/
                // mensaje error, no existe el usuario
                txtCorreo.Visible = true;
                txtContrasena.Visible = true;
                btnIniciarSesion.Visible = true;
                lnkCerrarSesion.Visible = false;
                lnkNombre.Visible = false;
                txtCorreo.Text = "";
                //txtContrasena.Text = "";
            }
        }

        protected void UsuarioLogin_Click(object sender, EventArgs e) 
        {
            switch (TIPO)
            {
                case 1:
                    break;
                case 2:
                    Response.Redirect("~/Interfaz/ModPerfilEmpresa.aspx");
                    break;
                case 3:
                    Response.Redirect("~/Interfaz/ModPerfilPersona.aspx");
                    break;
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            txtCorreo.Visible = true;
            txtContrasena.Visible = true;
            btnIniciarSesion.Visible = true;
            lnkCerrarSesion.Visible = false;
            lnkNombre.Visible = false;
            USUARIO = "";
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            String usuario = "";
            usuario = insMetodos.IniciarSesion(txtCorreo.Text, txtContrasena.Text);
            
            if (Usuario())
            {
                txtCorreo.Visible = false;
                txtContrasena.Visible = false;
                btnIniciarSesion.Visible = false;
                lnkCerrarSesion.Visible = true;
                lnkNombre.Visible = true;
                lnkNombre.Text = cPersonaDatos.NOMBRE;
            }
            else
            {
                /* tiene que mostrar un mensaje de error indicando que el usuario es invalido*/
                // mensaje error, no existe el usuario
                txtCorreo.Text = "";
                txtContrasena.Text = "";

                //LinkButton linkUsuario = insInterfaz.BotonLink("nomUsuario", "UsuarioLink", USUARIO);
                //linkUsuario.Click += new EventHandler(UsuarioLogin_Click);
                //pnlLogin.Controls.Add(linkUsuario);
                //insDefault.Login(usuario);*/
                //ScriptManager.RegisterStartupScript(btnIniciarSesion, GetType(), "UsuarioActual", "Sesion('" + USUARIO + "','"+ TIPO +"')", true);
                
                //ScriptManager.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario + "')", true);
            }
        }

        public Boolean Usuario()
        {
            if (USUARIO.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
