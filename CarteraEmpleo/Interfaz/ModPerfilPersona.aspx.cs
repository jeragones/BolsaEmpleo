using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class ModificarPersona : System.Web.UI.Page
    {
        
        cPersonaDatos insPersona = new cPersonaDatos();
        cGeneralMetodos insMetodos = new cGeneralMetodos();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            CargarDatos();
            //ClientScript.RegisterStartupScript(GetType(), "Idioma", "Idiomas('Ingles')", false);
            //ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + cPersonaDatos.NOMBRE + "','3')", true);
            //ClientScript.RegisterStartupScript(GetType(), "Variable", "", true);
            //String idioma = "Turco,Romano,Haitiano,Español";
            //String telefono = "1234-1236,1278-5691";
        }

        protected void CargarDatos() 
        {
            //String script1 = "InicioSesion";
            //String script2 = "ImpIdiomas";
            //String script3 = "ImpTelefonos";
            //Type sTipo = this.GetType();
            //ClientScriptManager cs = Page.ClientScript;
            
            String idioma = "";
            String telefono = "";

            //String usuario = Request.QueryString["U"];
            //String contrasena = Request.QueryString["P"];
            //insMetodos.IniciarSesion(usuario, contrasena);
            if (lblNombre.Text.Equals("Nombre")) 
            {
                lblNombre.Text = cPersonaDatos.NOMBRE;
                txtNombre.Text = lblNombre.Text;
                lblDireccion.Text = cPersonaDatos.DIRECCION;
                txtDireccion.Text = lblDireccion.Text;
                lblExperiencia.Text = cPersonaDatos.EXPERIENCIA;
                txtExperiencia.Text = lblExperiencia.Text;

                if (cPersonaDatos.CONDICION == 'D')
                {
                    lblCondicion.Text = "Desempleado";
                }
                else
                {
                    lblCondicion.Text = "Empleado";
                }
                cmbCondicion.Text = lblCondicion.Text;
            }
            
            /*if (cPersonaDatos.IDIOMA != null) 
            {
                for (int i = 0; i < cPersonaDatos.IDIOMA.Length; i++)
                {
                    idioma += cPersonaDatos.IDIOMA[i] + ",";
                }
                if (!cs.IsStartupScriptRegistered(sTipo, script2))
                {
                    cs.RegisterStartupScript(sTipo, script2, "Idiomas('" + idioma + "')", true);
                }
            }
            if (cPersonaDatos.TELEFONO != null)
            {
                for (int i = 0; i < cPersonaDatos.TELEFONO.Length; i++)
                {
                    telefono += cPersonaDatos.TELEFONO[i] + ",";
                }
                if (!cs.IsStartupScriptRegistered(sTipo, script3))
                {
                    cs.RegisterStartupScript(sTipo, script3, "Telefonos('" + idioma + "')", true);
                }
            }*/
            //if (!cs.IsStartupScriptRegistered(sTipo, script1))
            //{
            //    cs.RegisterStartupScript(sTipo, script1, "Sesion('" + cPersonaDatos.NOMBRE + "', '3')", true);
            //}
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarIdioma();
            DesactivarCondicion();
            DesactivarContrasena();
            DesactivarDireccion();
            DesactivarExperiencia();

            msgError.Text = insPersona.Modificar(lblNombre.Text, cmbCondicion.Text, txtContrasena1.Text,
                                                 txtContrasena2.Text, txtContrasena3.Text, txtDireccion.Text,
                                                 txtExperiencia.Text);
            if (msgError.Text.Equals(""))
            {
                imgError.Visible = false;
            }
            else
            {
                imgError.Visible = true;
            }

            //ScriptManager.RegisterStartupScript(btnGuardar, GetType(), "Idioma", "Idiomas('" + tmp + "')", true);
        }

        protected void hplNombre_Click(object sender, EventArgs e)
        {
            lblNombre.Visible = false;
            txtNombre.Visible = true;
            txtNombre.Text = lblNombre.Text;
            hplNombre.Visible = false;
            DesactivarTelefono();
            DesactivarIdioma();
            DesactivarCondicion();
            DesactivarContrasena();
            DesactivarDireccion();
            DesactivarExperiencia();
        }

        protected void hplTelefono_Click(object sender, EventArgs e)
        {
            txtTelefono.Visible = true;
            txtTelefono.Text = "";
            btnAgregarTelefono.Visible = true;
            hplTelefono.Visible = false;
            DesactivarNombre();
            DesactivarIdioma();
            DesactivarCondicion();
            DesactivarContrasena();
            DesactivarDireccion();
            DesactivarExperiencia();
        }

        protected void hplIdioma_Click(object sender, EventArgs e)
        {
            cmbIdioma.Visible = true;
            hplIdioma.Visible = false;
            btnAgregarIdioma.Visible = true;
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarCondicion();
            DesactivarContrasena();
            DesactivarDireccion();
            DesactivarExperiencia();
        }

        protected void hplCondicion_Click(object sender, EventArgs e)
        {
            lblCondicion.Visible = false;
            cmbCondicion.Visible = true;
            cmbCondicion.Text = lblCondicion.Text;
            hplCondicion.Visible = false;
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarIdioma();
            DesactivarContrasena();
            DesactivarDireccion();
            DesactivarExperiencia();
        }

        protected void hplContrasena_Click(object sender, EventArgs e)
        {
            lblContrasena1.Text = "Contraseña actual:";
            lblContrasena.Visible = false;
            txtContrasena1.Visible = true;
            lblContrasena2.Visible = true;
            txtContrasena2.Visible = true;
            lblContrasena3.Visible = true;
            txtContrasena3.Visible = true;
            hplContrasena.Visible = false;
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarIdioma();
            DesactivarCondicion();
            DesactivarDireccion();
            DesactivarExperiencia();
        }

        protected void hplDireccion_Click(object sender, EventArgs e)
        {
            lblDireccion.Visible = false;
            txtDireccion.Visible = true;
            txtDireccion.Text = lblDireccion.Text;
            hplDireccion.Visible = false;
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarIdioma();
            DesactivarCondicion();
            DesactivarContrasena();
            DesactivarExperiencia();
        }

        protected void hplExperiencia_Click(object sender, EventArgs e)
        {
            lblExperiencia.Visible = false;
            txtExperiencia.Visible = true;
            txtExperiencia.Text = lblExperiencia.Text;
            hplExperiencia.Visible = false;
            DesactivarDireccion();
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarIdioma();
            DesactivarCondicion();
            DesactivarContrasena();
        }

        protected void DesactivarNombre()
        {
            lblNombre.Visible = true;
            txtNombre.Visible = false;
            lblNombre.Text = txtNombre.Text;
            hplNombre.Visible = true;
        }

        protected void DesactivarTelefono()
        {
            txtTelefono.Visible = false;
            btnAgregarTelefono.Visible = false;
            hplTelefono.Visible = true;
        }

        protected void DesactivarIdioma()
        {
            cmbIdioma.Visible = false;
            btnAgregarIdioma.Visible = false;
            hplIdioma.Visible = true;
        }

        protected void DesactivarCondicion()
        {
            lblCondicion.Visible = true;
            cmbCondicion.Visible = false;
            lblCondicion.Text = cmbCondicion.Text;
            hplCondicion.Visible = true;
        }

        protected void DesactivarContrasena()
        {
            lblContrasena1.Text = "Contraseña:";
            lblContrasena.Visible = true;
            txtContrasena1.Visible = false;
            lblContrasena2.Visible = false;
            txtContrasena2.Visible = false;
            lblContrasena3.Visible = false;
            txtContrasena3.Visible = false;
            hplContrasena.Visible = true;
        }

        protected void DesactivarDireccion()
        {
            lblDireccion.Visible = true;
            txtDireccion.Visible = false;
            lblDireccion.Text = txtDireccion.Text;
            hplDireccion.Visible = true;
        }

        protected void DesactivarExperiencia()
        {
            lblExperiencia.Visible = true;
            txtExperiencia.Visible = false;
            lblExperiencia.Text = txtExperiencia.Text;
            hplExperiencia.Visible = true;
        }

        protected void btnQuitarIdioma_Click(object sender, EventArgs e)
        {
            //DesactivarNombre();
            //DesactivarTelefono();
            //DesactivarIdioma();
            //DesactivarCondicion();
            //DesactivarContrasena();
            //DesactivarDireccion();
            Response.Redirect("~/Interfaz/Default.aspx");
        }

        protected void AgregarTelefono_Click(object sender, EventArgs e)
        {

        }

        protected void AgregarIdioma_Click(object sender, EventArgs e)
        {

        }

        
    public static void ClosePage()
    {

    }
    }
}