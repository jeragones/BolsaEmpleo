using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarteraEmpleo.Interfaz
{
    public partial class BusquedaPersona : System.Web.UI.Page
    {
        cEmpresaDatos insEmpresa = new cEmpresaDatos();
        cPersonaDatos insPersona = new cPersonaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<string[]> lista = insPersona.buscarPersona(txtIdioma.Text, cmbCondicion.Text, txtDireccion.Text, txtResumen.Text);
        }
    }
}