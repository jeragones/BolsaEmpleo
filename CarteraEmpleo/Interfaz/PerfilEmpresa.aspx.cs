﻿using System;
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
        cEmpleosDatos insEmpleos = new cEmpleosDatos();
        cEmpresaDatos insEmpresa = new cEmpresaDatos();

         protected void Page_Load(object sender, EventArgs e)
         {
             //ClientScriptManager cs = Page.ClientScript;
             //String[] usuario = insMetodos.UsuarioLogin();
             //ClientScript.RegisterStartupScript(GetType(), "UsuarioActual", "Sesion('" + usuario[0] + "','" + usuario[1] + "')", true);
             String usuario = Request.QueryString["U"];
             
             String[] empresa = insEmpresa.PerfilEmpresa(usuario);

             lblCorreo.Text = empresa[0];
             lblCedula.Text = empresa[1];
             lblNombre.Text = empresa[2];
             lblPagina.Text = empresa[3];
             lblDescripcion.Text = empresa[4];
             lblDireccion.Text = empresa[5];

             try
             {
                 cargarGV1();
             }
             catch (Exception ex)
             {
                 //return ex.Message;
             }
         }

         protected void cargarGV1()
         {
             DataTable dbResultado = insEmpleos.selectPublicaciones(lblCorreo.Text);
             GridView1.DataSource = dbResultado;
             GridView1.DataBind();
         }

         protected void btnCorreo_Click(object sender, EventArgs e)
         {
             cCorreoComunicacion.DESTINATARIO = lblCorreo.Text;
             cCorreoComunicacion.TIPO = 2;
             Response.Redirect("~/Interfaz/Correo.aspx");
         }
    }
}