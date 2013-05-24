using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class BusquedaEmpresa : System.Web.UI.Page
    {
        cEmpresaDatos insEmpresa = new cEmpresaDatos();
        cInterfaz insInterfaz = new cInterfaz();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<string[]> lista = insEmpresa.buscarEmpresa(txbNombre.Text, txbUbicación.Text, txbPuesto.Text, txbSalarioMin.Text, txbSalarioMax.Text);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    msgResultado.Visible = false;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        Button boton = insInterfaz.CrearBoton(lista.ElementAt(i)[0], "btnResultado", lista.ElementAt(i)[1]);
                        boton.Click += new EventHandler(btnEventoPerfil_Click);
                        panel.Controls.Add(boton);
                    }
                }
                else {
                    msgResultado.Visible = true;
                }
                
                msgError.Visible = false;
            }
            else
            {
                msgError.Text = "Existen campos con valores incorrectos.";
                msgError.Visible = true;
            }
        }

        protected void btnEventoPerfil_Click(object sender, EventArgs e)
        {
            ImageButton boton = (ImageButton)sender;
            Response.Redirect("~/Interfaz/PerfilEmpresa.aspx?U=" + boton.ID);
        }
    }
}