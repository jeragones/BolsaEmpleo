using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarteraEmpleo.Interfaz
{
    public partial class Persona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScriptManager cs = Page.ClientScript;
        }

        protected void QuitarIdioma(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Quitaridiomas", "QuitarIdioma('idioma1')", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String tmp = "Ingles  ,Aleman  ,Ruso  ,Ucraniano  ,Velvet  ";
            ClientScript.RegisterStartupScript(GetType(), "AgregarIdiomas", "Idiomas('" + tmp + "')", true);
        }
    }
}