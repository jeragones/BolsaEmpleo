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
        cInterfaz insInterfaz = new cInterfaz();

        protected void Page_Load(object sender, EventArgs e)
        {
            //String[] usuario = insMetodos.UsuarioLogin();
            //ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario[0] + "','" + usuario[1] + "')", true);
            CargarDatos();
        }

        protected void CargarDatos() 
        {
            if (lblNombre.Text.Equals("Nombre")) 
            {
                insPersona.consultaDatos(cPersonaDatos.CORREO);
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
            for (int i = 0; i < cPersonaDatos.TELEFONO.Length; i++)
            {
                if (!cPersonaDatos.TELEFONO[i].Equals(""))
                {
                    Label etiqueta = insInterfaz.CrearEtiqueta(cPersonaDatos.TELEFONO[i] + "L", "lblRegistrar", cPersonaDatos.TELEFONO[i]);
                    ImageButton boton = insInterfaz.CrearImagen(cPersonaDatos.TELEFONO[i] + "B", "btnEliminar", "../Images/eliminar.png");
                    boton.Click += new ImageClickEventHandler(btnQuitarTelefono_Click);
                    pnlTelefono.Controls.Add(etiqueta);
                    pnlTelefono.Controls.Add(boton);
                }
            }

            for (int i = 0; i < cPersonaDatos.IDIOMA.Length; i++)
            {
                if (!cPersonaDatos.IDIOMA[i].Equals(""))
                {
                    Label etiqueta = insInterfaz.CrearEtiqueta(cPersonaDatos.IDIOMA[i] + "L", "lblRegistrar", cPersonaDatos.IDIOMA[i]);
                    ImageButton boton = insInterfaz.CrearImagen(cPersonaDatos.IDIOMA[i] + "B", "btnEliminar", "../Images/eliminar.png");
                    boton.Click += new ImageClickEventHandler(btnQuitarIdioma_Click);
                    pnlIdioma.Controls.Add(etiqueta);
                    pnlIdioma.Controls.Add(boton);
                }
            }
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
            AgregarIdioma.Visible = true;
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
            AgregarIdioma.Visible = false;
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

        protected void btnQuitarTelefono_Click(object sender, EventArgs e)
        {
            ImageButton boton = (ImageButton)sender;
            int index = pnlTelefono.Controls.IndexOf(boton);
            insPersona.eliminarTelefono(boton.ID, cPersonaDatos.CORREO);
            pnlTelefono.Controls.Remove(boton);
            pnlTelefono.Controls.RemoveAt(index - 1);
        }

        protected void btnQuitarIdioma_Click(object sender, EventArgs e)
        {
            ImageButton boton = (ImageButton)sender;
            int index = pnlIdioma.Controls.IndexOf(boton);
            insPersona.eliminarIdioma(boton.ID, cPersonaDatos.CORREO);
            pnlIdioma.Controls.Remove(boton);
            pnlIdioma.Controls.RemoveAt(index-1);
        }

        protected void AgregarTelefono_Click(object sender, EventArgs e)
        {
            msgError.Text = insMetodos.InsertarTelefono(txtTelefono.Text);
            if (msgError.Text.Equals(""))
            {
                imgError.Visible = false;
            }
            else
            {
                imgError.Visible = true;
            }
            txtTelefono.Text = "";
            pnlTelefono.Controls.Clear();
            pnlIdioma.Controls.Clear();
            CargarDatos();
        }

        protected void AgregarIdioma_Click(object sender, EventArgs e)
        {
            msgError.Text = insMetodos.InsertarIdioma(cmbIdioma.SelectedIndex + 1);
            if (msgError.Text.Equals(""))
            {
                imgError.Visible = false;
            }
            else
            {
                imgError.Visible = true;
            }
            cmbIdioma.Text = "Alemán";
            pnlIdioma.Controls.Clear();
            pnlTelefono.Controls.Clear();
            CargarDatos();
        }

        
        public static void ClosePage()
        {

        }
    }
}