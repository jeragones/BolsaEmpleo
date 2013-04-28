using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class PerfilPersona : System.Web.UI.Page
    {
        cGeneralMetodos insMetodos = new cGeneralMetodos();
        cPersonaDatos insPersona = new cPersonaDatos();

         protected void Page_Load(object sender, EventArgs e)
         {

             ClientScriptManager cs = Page.ClientScript;
             String[] usuario = insMetodos.UsuarioLogin();
             ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario[0] + "','" + usuario[1] + "')", true); 

             String[] persona = insPersona.PerfilPersona("jeragones@gmail.com");

             lblCorreo.Text = persona[0];
             lblNombre.Text = persona[1];
             
             if (persona[2].Equals("D"))
             {
                 lblCondicion.Text = "Desempleado";
             }
             else
             {
                 lblCondicion.Text = "Empleado";
             }

             lblExperiencia.Text = persona[3];
             lblDireccion.Text = persona[4];
        }

        protected void QuitarIdioma(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Quitaridiomas", "QuitarIdioma('idioma1')", true);
        }
    }
}