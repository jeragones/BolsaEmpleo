/////////////////////////////////////////////////////////////////////////////
// Instituto Tecnológico de Costa Rica
// Proyecto: Framework Bolsa de empleo de la carrera de turismo
// Descripción: Clase de acceso a datos para tabla 'CEEMPRESAS'
// Generado por ITCR Gen v1.0.0.0 
// Fecha: Miercoles, 20 de Marzo de 2013, 3:30:00 p.m.
////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo
{
    public class cEmpresaDatos
    {
        Service1 webservice = new Service1();
        cGeneralMetodos insMetodos = new cGeneralMetodos();

        /*
         * Propiedades de la clase
         */
        public static String CORREO;
        public static String CONTRASEÑA;
        public static String NOMBRE;
        public static String CEDJURIDICA;
        public static String PAGINA;
        public static String DESCRIPCION;
        public static String[] TELEFONO;
        public static String DIRECCION;

        /*
         * Metodo para insertar una nueva empresa a la BD
         */
        public String insertar(String p_nombre, String p_contrasena1, String p_contrasena2,  String p_cedula, 
                               String p_correo, String p_sitio, string p_descripcion, string p_direccion)
        {
            String[] _sFracmentar;
            char[] _cSeparadorCedula = { '-' };
            _sFracmentar = insMetodos.Fragmentar(p_cedula, _cSeparadorCedula);
            if (p_nombre.Equals("") | p_correo.Equals("") | _sFracmentar[0].Equals("") | 
                _sFracmentar[1].Equals("") | _sFracmentar[2].Equals(""))
            {
                return ("Existen campos vacíos que son requeridos.");
            }

            if (_sFracmentar.Length != 3 | !insMetodos.Numero(_sFracmentar[0]) | !insMetodos.Numero(_sFracmentar[1]) |
               !insMetodos.Numero(_sFracmentar[2]) | p_cedula.Length != 12) 
            {
                return ("Cedula jurídica inválida.");
            }

            if (insMetodos.ValidarCorreo(p_correo)) {
                return ("Correo inválido.");
            }

            if (insMetodos.ValidarContrasena(p_contrasena1, p_contrasena2))
            {
                return ("Las contraseñas no coinciden.");
            }

            try
            {
                webservice.Insert_Empresa(p_correo, p_contrasena1, p_descripcion, p_direccion, p_nombre, p_cedula, p_sitio);
            }
            catch (Exception e) { 
                return("Error en el registro.");
            }
            return ("");
        }

        /*
         * Metodo para modificar la empresa que se encuentra logueada
         */
        public String Modificar(String p_nombre, String p_cedula, String p_sitio, 
                             String p_contrasena1, String p_contrasena2, String p_contrasena3,
                             String p_descripcion, String p_direccion)
        {
            String result;
            String[] _sFracmentar;
            char[] _cSeparadorCedula = { '-' };

            _sFracmentar = insMetodos.Fragmentar(p_cedula, _cSeparadorCedula);

            if (p_nombre.Equals("") | _sFracmentar[0].Equals("") |
                _sFracmentar[1].Equals("") | _sFracmentar[2].Equals(""))
            {
                return ("Existen campos vacíos que son requeridos.");
            }

            if (_sFracmentar.Length != 3 | !insMetodos.Numero(_sFracmentar[0]) | !insMetodos.Numero(_sFracmentar[1]) |
               !insMetodos.Numero(_sFracmentar[2]) | p_cedula.Length != 12)
            {
                return ("Cedula jurídica inválida.");
            }

            if (!p_contrasena2.Equals(""))
            {
                if (insMetodos.ValidarContrasena(p_contrasena1, p_contrasena2, p_contrasena3))
                {
                    return ("Contraseña inválida.");
                }
                else
                {
                    //Site.CONTRASENA = p_contrasena2;
                    CONTRASEÑA = p_contrasena2;
                }
            }

            try
            {
                webservice.Update_Empresa(CORREO, CONTRASEÑA, p_descripcion, p_direccion, 
                                          p_nombre, p_cedula, p_sitio /*, "True"*/);
                return("");
            } 
            catch(Exception e) {
                return("Error al modificar los datos.");
            }
        }

        /*
         * Metodo para cargar la informacion de la empresa actual de la BD
         */
        public String[] PerfilEmpresa(String user)
        {
            String[] result = new String[7];
            DataTable usuario = webservice.Select_Usuario(user);
            if (usuario.Columns.Count > 2)
            {
                foreach (DataRow row in usuario.Rows)
                {
                    result[0] = row["ID_CORREO"].ToString();
                    result[1] = row["TXT_CED_JURIDICA"].ToString();
                    result[2] = row["TXT_NOMBRE"].ToString();
                    result[3] = row["TXT_PAG_WEB"].ToString();
                    result[4] = row["TXT_DESC"].ToString();
                    result[5] = row["DIR_DIRECCION"].ToString();
                    result[6] = row["TXT_CONTRASEÑA"].ToString();
                }
            }
            return result;
        }

        /*
         * Metodo que setea los valores de las propiedades de la clase
         */
        public void consultaDatos(string correo)
        {
            string[] empresa = PerfilEmpresa(correo);
            CORREO = empresa[0];
            CEDJURIDICA = empresa[1];
            NOMBRE = empresa[2];
            PAGINA = empresa[3];
            DESCRIPCION = empresa[4];
            DIRECCION = empresa[5];
            CONTRASEÑA = empresa[6];
            TELEFONO = insMetodos.ConsultaTelefonos(correo);
        }
    }
}