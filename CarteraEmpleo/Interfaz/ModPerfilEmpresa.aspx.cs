using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class ModificarEmpresa : System.Web.UI.Page
    {
        
        cEmpresaDatos insEmpresa = new cEmpresaDatos();
        cGeneralMetodos insMetodos = new cGeneralMetodos();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + cEmpresaDatos.NOMBRE + "','2')", true);
            CargarDatos();
        }

        protected void CargarDatos()
        {
            //String script1 = "InicioSesion";
            //String script3 = "ImpTelefonos";
            //Type sTipo = this.GetType();
            //ClientScriptManager cs = Page.ClientScript;

            String telefono = "";
            char[] tmp = { '-' };
            String[] cedula = insMetodos.Fragmentar(cEmpresaDatos.CEDJURIDICA, tmp);

            //String usuario = Request.QueryString["U"];
            //String contrasena = Request.QueryString["P"];
            //insMetodos.IniciarSesion(usuario, contrasena);

            if (lblNombre.Text.Equals("Nombre"))
            {
                lblNombre.Text = cEmpresaDatos.NOMBRE;
                txtNombre.Text = lblNombre.Text;
                lblDireccion.Text = cEmpresaDatos.DIRECCION;
                txtDireccion.Text = lblDireccion.Text;
                lblCedula.Text = cEmpresaDatos.CEDJURIDICA;
                txtCedula1.Text = cedula[0];
                txtCedula2.Text = cedula[1];
                txtCedula3.Text = cedula[2];
                lblCorreo.Text = cEmpresaDatos.CORREO;
                lblSitio.Text = cEmpresaDatos.PAGINA;
                txtSitio.Text = lblSitio.Text;
                lblDescripcion.Text = cEmpresaDatos.DESCRIPCION;
                txtDescripcion.Text = lblDescripcion.Text;
            }

            if (cEmpresaDatos.TELEFONO != null)
            {
                for (int i = 0; i < cEmpresaDatos.TELEFONO.Length; i++)
                {
                    telefono += cEmpresaDatos.TELEFONO[i] + ",";
                }
                //if (!cs.IsStartupScriptRegistered(sTipo, script3))
                //{
                //    cs.RegisterStartupScript(sTipo, script3, "Telefonos('" + idioma + "')", true);
                //}
            }

            /*if (!cs.IsStartupScriptRegistered(sTipo, script1))
            {
                cs.RegisterStartupScript(sTipo, script1, "Sesion('" + cPersonaDatos.NOMBRE + "', '3')", true);
            }*/
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            DesactivarNombre();
            DesactivarCedula();
            DesactivarTelefono();
            DesactivarSitio();
            DesactivarContrasena();
            DesactivarDescripcion();
            DesactivarDireccion();

            msgError.Text = insEmpresa.Modificar(lblNombre.Text, lblCedula.Text, lblSitio.Text,
                                                 txtContrasena1.Text, txtContrasena2.Text, txtContrasena3.Text,
                                                 lblDescripcion.Text, lblDireccion.Text);
            if (msgError.Text.Equals(""))
            {
                imgError.Visible = false;
            }
            else
            {
                imgError.Visible = true;
            }
        }

        protected void hplNombre_Click(object sender, EventArgs e)
        {
            lblNombre.Visible = false;
            txtNombre.Visible = true;
            txtNombre.Text = lblNombre.Text;
            hplNombre.Visible = false;
            DesactivarCedula();
            DesactivarTelefono();
            DesactivarSitio();
            DesactivarContrasena();
            DesactivarDescripcion();
            DesactivarDireccion();
        }

        protected void hplCedula_Click(object sender, EventArgs e)
        {
            lblCedula.Visible = false;
            txtCedula1.Visible = true;
            txtCedula2.Visible = true;
            txtCedula3.Visible = true;

            char[] _cSeparador = { '-' };
            String[] _sCedula = insMetodos.Fragmentar(lblCedula.Text, _cSeparador);

            txtCedula1.Text = _sCedula[0];
            txtCedula2.Text = _sCedula[1];
            txtCedula3.Text = _sCedula[2];
            hplCedula.Visible = false;
            DesactivarNombre();
            DesactivarTelefono();
            DesactivarSitio();
            DesactivarContrasena();
            DesactivarDescripcion();
            DesactivarDireccion();
        }

        protected void hplTelefono_Click(object sender, EventArgs e)
        {
            lblTelefono.Visible = false;
            txtTelefono.Visible = true;
            txtTelefono.Text = lblTelefono.Text;
            hplTelefono.Visible = false;
            DesactivarNombre();
            DesactivarCedula();
            DesactivarSitio();
            DesactivarContrasena();
            DesactivarDescripcion();
            DesactivarDireccion();
        }

        protected void hplSitio_Click(object sender, EventArgs e)
        {
            lblSitio.Visible = false;
            txtSitio.Visible = true;
            txtSitio.Text = lblSitio.Text;
            hplSitio.Visible = false;
            DesactivarNombre();
            DesactivarCedula();
            DesactivarTelefono();
            DesactivarContrasena();
            DesactivarDescripcion();
            DesactivarDireccion();
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
            DesactivarCedula();
            DesactivarTelefono();
            DesactivarSitio();
            DesactivarDescripcion();
            DesactivarDireccion();
        }

        protected void hplDescripcion_Click(object sender, EventArgs e)
        {
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = true;
            txtDescripcion.Text = lblDescripcion.Text;
            hplDescripcion.Visible = false;
            DesactivarNombre();
            DesactivarCedula();
            DesactivarTelefono();
            DesactivarSitio();
            DesactivarContrasena();
            DesactivarDireccion();
        }

        protected void hplDireccion_Click(object sender, EventArgs e)
        {
            lblDireccion.Visible = false;
            txtDireccion.Visible = true;
            txtDireccion.Text = lblDireccion.Text;
            hplDireccion.Visible = false;
            DesactivarNombre();
            DesactivarCedula();
            DesactivarTelefono();
            DesactivarSitio();
            DesactivarContrasena();
            DesactivarDescripcion();
        }

        protected void DesactivarNombre()
        {
            lblNombre.Visible = true;
            txtNombre.Visible = false;
            lblNombre.Text = txtNombre.Text;
            hplNombre.Visible = true;
        }

        protected void DesactivarCedula()
        {
            lblCedula.Visible = true;
            lblCedula.Text = txtCedula1.Text + "-" + txtCedula2.Text + "-" + txtCedula3.Text;
            txtCedula1.Visible = false;
            txtCedula2.Visible = false;
            txtCedula3.Visible = false;
            hplCedula.Visible = true;
        }

        protected void DesactivarTelefono()
        {
            lblTelefono.Visible = true;
            txtTelefono.Visible = false;
            lblTelefono.Text = txtTelefono.Text;
            hplTelefono.Visible = true;
        }

        protected void DesactivarSitio()
        {
            lblSitio.Visible = true;
            txtSitio.Visible = false;
            lblSitio.Text = txtSitio.Text;
            hplSitio.Visible = true;
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

        protected void DesactivarDescripcion()
        {
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = false;
            lblDescripcion.Text = txtDescripcion.Text;
            hplDescripcion.Visible = true;
        }

        protected void DesactivarDireccion()
        {
            lblDireccion.Visible = true;
            txtDireccion.Visible = false;
            lblDireccion.Text = txtDireccion.Text;
            hplDireccion.Visible = true;
        }
    }
}