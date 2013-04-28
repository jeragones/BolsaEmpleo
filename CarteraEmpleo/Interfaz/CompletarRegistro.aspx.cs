using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        cGeneralMetodos insMetodos = new cGeneralMetodos();

        protected void Page_Load(object sender, EventArgs e)
        {
            String accion = Request.QueryString["T"];
            String usuario = Request.QueryString["U"];
            lblMensaje.Text = Registrar(usuario, Convert.ToInt32(accion));
            

        }

        private string Registrar(string usuario, int p)
        {
            return "";
            //throw new NotImplementedException();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            Response.Redirect("~/Interfaz/Default.aspx");
        }
    }
}