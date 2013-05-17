using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class BusquedaPersona : System.Web.UI.Page
    {
        cEmpresaDatos insEmpresa = new cEmpresaDatos();
        cPersonaDatos insPersona = new cPersonaDatos();
        cInterfaz insInterfaz = new cInterfaz();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<string[]> lista = insPersona.buscarPersona(txtIdioma.Text, cmbCondicion.Text, txtDireccion.Text, txtResumen.Text);
            if (lista != null)
            {
                msgResultado.Visible = false;
                for (int i = 0; i < lista.Count; i++)
                {
                    Button boton = insInterfaz.CrearBoton(lista.ElementAt(i)[0], "btnResultado", lista.ElementAt(i)[1]);
                    panel.Controls.Add(boton);
                }
            }
            else {
                msgResultado.Visible = true;
            }
        }
    }
}