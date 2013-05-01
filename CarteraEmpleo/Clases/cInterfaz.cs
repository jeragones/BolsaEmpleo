using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CarteraEmpleo.Clases
{
    public class cInterfaz
    {
        public Button CrearBoton(String id, String cls, String txt) {
            Button boton = new Button();
            boton.ID = id;
            boton.CssClass = cls;
            boton.Text = txt;
            //boton.Click = new EventHandler();
            
            return boton;
        }

        public Label CrearEtiqueta(String id, String cls, String txt) 
        {
            Label etiqueta = new Label();
            etiqueta.ID = id;
            etiqueta.CssClass = cls;
            etiqueta.Text = txt;
            etiqueta.Style.Add("position", "static");
            
            return etiqueta;
        }

        public ImageButton CrearImagen(String id, String cls, String url) 
        {
            ImageButton imagen = new ImageButton();
            imagen.ID = id;
            imagen.CssClass = cls;
            imagen.ImageUrl = url;
            //imagen.Attributes.Add("runat", "server");
            return imagen;
        }

        public LinkButton BotonLink(String id, String cls, String txt)
        {
            LinkButton boton = new LinkButton();
            boton.ID = id;
            boton.CssClass = cls;
            boton.Text = txt;
            return boton;
        }
    }
}