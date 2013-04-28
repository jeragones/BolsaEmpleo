using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CarteraEmpleo.Clases;
using System.Windows.Forms;
using CarteraEmpleo;
 
 namespace CarteraEmpleo.Interfaz
 {
     public partial class PerfilEmpresa : System.Web.UI.Page
     {
        cGeneralMetodos insMetodos = new cGeneralMetodos();

         protected void Page_Load(object sender, EventArgs e)
         {
             ClientScriptManager cs = Page.ClientScript;
             String[] usuario = insMetodos.UsuarioLogin();
             ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario[0] + "','" + usuario[1] + "')", true);
             try {
                 cargarGV1();
             }
             catch(Exception ex){
                 //return ex.Message;
             }
        }

         /**
          * Carga la tabla de las publicaciones de las empresas
          */
        protected void cargarGV1() {
            cEmpleosDatos instancia = new cEmpleosDatos();
            DataTable dbResultado = instancia.selectPublicaciones();
            GridView1.DataSource = dbResultado;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btEliminarOfertasEmpleo_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                Clases.cEmpleosDatos ins = new Clases.cEmpleosDatos();
                string _sIndice = Convert.ToString(GridView1.SelectedDataKey.Value);
                if (ins.Numero(_sIndice))
                {
                    int _iNUM_PUBLIACIONES = Convert.ToInt32(_sIndice);
                    ins.eliminar(_iNUM_PUBLIACIONES);
                    cargarGV1();
                }
            }
            catch(Exception ex) { }
        }

        protected void InsertarPublicacion_Click(object sender, EventArgs e)
        {
            Clases.cEmpleosDatos ins = new Clases.cEmpleosDatos();
            if (ins.insertar(NumJornada.Text, Horario.Text, Conocimientos.Text, Salario.Text))
            { 
                limpiarTextBoxIP();
                cargarGV1();
            }
        }

         /**
          * Limpia los campos donde se ingresan los datos de la publicación
          */
        public void limpiarTextBoxIP()
        {
            NumJornada.Text = "";
            Horario.Text = "";
            Conocimientos.Text = "";
            Salario.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}