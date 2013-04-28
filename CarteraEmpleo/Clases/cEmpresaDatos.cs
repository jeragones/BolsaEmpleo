/////////////////////////////////////////////////////////////////////////////
// Instituto Tecnológico de Costa Rica
// Proyecto: Framework Bolsa de empleo de la carrera de turismo
// Descripción: Clase de acceso a datos para tabla 'CEEMPRESAS'
// Generado por ITCR Gen v1.0.0.0 
// Fecha: Miercoles, 20 de Marzo de 2013, 3:30:00 p.m.
////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo
{
    public class cEmpresaDatos
    {
        Service1 webservice = new Service1();
        cGeneralMetodos insMetodos = new cGeneralMetodos();

        public static String CORREO;
        public static String NOMBRE;
        public static String CEDJURIDICA;
        public static String PAGINA;
        public static String DESCRIPCION;
        public static String[] TELEFONO;
        public static String DIRECCION;
        // telefono
        public String insertar(String p_nombre, String p_contrasena1, String p_contrasena2,  String p_cedula, 
                               String p_correo, String p_sitio)
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
                webservice.Insert_Empresa(p_correo, p_contrasena1, "", "", p_nombre, p_cedula, p_sitio/*, "false"*/);
            }
            catch (Exception e) { 
                return("Error en el registro.");
            }
            return ("");
        }

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
                    Site.CONTRASENA = p_contrasena2;
                }
            }

            try
            {
                webservice.Update_Empresa(Site.USUARIO, Site.CONTRASENA, p_descripcion, p_direccion, 
                                          p_nombre, p_cedula, p_sitio /*, "True"*/);
                return("");
            } 
            catch(Exception e) {
                return("Error al modificar los datos.");
            }
        }

        public void eliminar()
        {
        }
    }
}