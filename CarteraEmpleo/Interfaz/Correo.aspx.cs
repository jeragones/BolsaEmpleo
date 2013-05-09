using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo.Interfaz
{
    public partial class Correo : System.Web.UI.Page
    {

        cCorreoComunicacion insCorreo = new cCorreoComunicacion();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Attachment archivo = new Attachment(fluArchivo.PostedFile.InputStream, fluArchivo.FileName);
            if(cCorreoComunicacion.TIPO == 1)
                insCorreo.Correo(cCorreoComunicacion.DESTINATARIO, cEmpresaDatos.NOMBRE, cEmpresaDatos.CORREO, txtAsunto.Text, txtMensaje.Text, cEmpresaDatos.CONTRASEÑA, archivo);
            else
                insCorreo.Correo(cCorreoComunicacion.DESTINATARIO, cPersonaDatos.NOMBRE, cPersonaDatos.CORREO, txtAsunto.Text, txtMensaje.Text, cPersonaDatos.CONTRASEÑA, archivo);

            txtAsunto.Text = "";
            txtMensaje.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}