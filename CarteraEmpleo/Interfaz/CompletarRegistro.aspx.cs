using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using CarteraEmpleo.Clases;


namespace CarteraEmpleo.Interfaz
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        cGeneralMetodos insMetodos = new cGeneralMetodos();
        cInterfaz insInterfaz = new cInterfaz();

        protected void Page_Load(object sender, EventArgs e)
        {
            String accion = Request.QueryString["T"];
            String usuario = Request.QueryString["U"];
            if (accion.Equals("7"))
            {
                int x = insMetodos.BuscarUsuario();
                if (x == 2)
                {
                    Response.Redirect("~/Interfaz/BusquedaPersona.aspx");
                }
                else if (x == 3)
                {
                    Response.Redirect("~/Interfaz/BusquedaEmpresa.aspx");
                }
                // llamar buscar candidato o empresa dependiendo de quien este logueado
            }
            else {
                lblMensaje.Text = insMetodos.Registrar(usuario, Convert.ToInt32(accion));
            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            Response.Redirect("~/Interfaz/Default.aspx");
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            //Label Label1;
            //Label1 = new Label();
            //Label1.CssClass = "lbl";
            //Label1.Text = "funciona";
            //pnl.Controls.Add(Label1);

            // <a href="javascript:QuitarIdioma(idioma' + i + ')"><img src="/Images/eliminar.png" width="20" height="20" /></a>

            for (int i = 0; i < 3; i++) 
            {
                System.Web.UI.WebControls.Button a = insInterfaz.CrearBoton("btn" + i.ToString(), "btn", "hola");
                a.Click += new EventHandler(btn_click);

                System.Web.UI.WebControls.ImageButton boton = insInterfaz.CrearImagen(i.ToString(), "btn", "/Images/eliminar.png");
                boton.Click += new ImageClickEventHandler(btn_click);
                
                pnl.Controls.Add(a);
                pnl.Controls.Add(boton);
            }
        }

        public void btn_click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
            btnAceptar.Text = "funciona";
        }
    }
}