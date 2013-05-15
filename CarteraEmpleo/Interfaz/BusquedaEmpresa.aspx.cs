using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarteraEmpleo.Interfaz
{
    public partial class BusquedaEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!txbNombre.Text.Equals("")) {
            }
            if (!txbUbicación.Text.Equals("")) {
            }
            if (!txbSalarioMin.Text.Equals("") && !txbSalarioMax.Text.Equals("")) {
            }
            if (!txbPuesto.Text.Equals("")) {
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}