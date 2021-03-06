﻿/////////////////////////////////////////////////////////////////////////////
// Instituto Tecnológico de Costa Rica
// Proyecto: Framework Bolsa de empleo de la carrera de turismo
// Descripción: Clase de acceso a datos para tabla 'CEPERSONAS'
// Generado por ITCR Gen v1.0.0.0 
// Fecha: Miercoles, 20 de Marzo de 2013, 3:40:00 p.m.
////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CarteraEmpleo.Clases;

namespace CarteraEmpleo
{
    public class cPersonaDatos
    {
        cCorreoComunicacion insCorreo = new cCorreoComunicacion();
        cGeneralMetodos insMetodos = new cGeneralMetodos();
        Service1 webservice = new Service1();

        public static String CORREO;
        public static String CONTRASEÑA;
        public static String NOMBRE;
        public static String[] TELEFONO;
        public static String[] IDIOMA;
        public static char CONDICION;
        public static String DIRECCION;
        public static String EXPERIENCIA;

        public String Insertar(String p_nombre, String p_correo,
                               String p_condicion, String p_contrasena1, String p_contrasena2,
                               String p_direccion)
        {
            if (p_nombre.Equals("") | p_correo.Equals("") |
                p_contrasena1.Equals("") | p_contrasena2.Equals(""))
            {
                return ("Existen campos vacíos que son requeridos.");
            }
            String[] _sFracmentar;

            if (insMetodos.ValidarCorreo(p_correo)) { 
                return("Correo inválido.");
            }

            if(insMetodos.ValidarContrasena(p_contrasena1, p_contrasena2))
            {
                return ("Contraseña inválida.");
            }
            
            char _cCondicion = ' ';
            if (p_condicion.Equals("Desempleado"))
            {
                _cCondicion = 'D';
            }
            else
            {
                _cCondicion = 'E';
            }
            String[] _sNombre = new String[3];
            char[] _cSeparadorNombre = { ' ' };
            _sFracmentar = insMetodos.Fragmentar(p_nombre, _cSeparadorNombre);
            if (_sFracmentar.Length <= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < _sFracmentar.Length)
                    {
                        _sNombre[i] = _sFracmentar[i];
                    }
                    else
                    {
                        _sNombre[i] = " ";
                    }
                }
            }
            try
            {
                webservice.Insert_Persona(p_correo, p_contrasena1, " ", p_direccion,
                                            _sNombre[0], _sNombre[1], _sNombre[2],
                                            _cCondicion, " ");
                return ("");
            }
            catch (Exception e)
            {
                return ("Error Inserción de datos.");
            }
        }

        public String Modificar(String p_nombre,
                                String p_condicion, String p_contrasena1, String p_contrasena2,
                                String p_contrasena3, String p_direccion, String p_conocimientos)
        {
            if (p_nombre.Equals(""))
            {
                return ("Existen campos vacíos que son requeridos.");
            }

            if (!p_contrasena2.Equals("")) 
            {
                if (insMetodos.ValidarContrasena(p_contrasena1, p_contrasena2, p_contrasena3))
                {
                    return ("Contraseña inválida.");
                }
                else {
                    Site.CONTRASENA = p_contrasena2;
                }
            }
            
            char _cCondicion = ' ';
            if (p_condicion.Equals("Desempleado"))
            {
                _cCondicion = 'D';
            }
            else
            {
                _cCondicion = 'E';
            }
            String[] _sNombre = new String[3];
            char[] _cSeparadorNombre = { ' ' };
            String[] _sFracmentar = insMetodos.Fragmentar(p_nombre, _cSeparadorNombre);
            if (_sFracmentar.Length <= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < _sFracmentar.Length)
                    {
                        _sNombre[i] = _sFracmentar[i];
                    }
                    else
                    {
                        _sNombre[i] = " ";
                    }
                }
            }
            try
            {
                webservice.Update_Persona(CORREO, CONTRASEÑA, " ", p_direccion,
                                            _sNombre[0], _sNombre[1], _sNombre[2],
                                            _cCondicion, p_conocimientos);
                return ("");
            }
            catch (Exception e)
            {
                return ("Error Modificación de datos.");
            }
        }

        public void eliminarIdioma(string id, string correo) {
            char[] separador = { 'B' };
            string[] nombre = insMetodos.Fragmentar(id, separador);

            try {
                //webservice.Delete_Persona_Idioma(correo, 1);
            } catch (Exception e) { }
        }

        public void eliminarTelefono(string id, string correo)
        {
            char[] separador = { 'B' };
            string[] nombre = insMetodos.Fragmentar(id, separador);

            try
            {
                //webservice.Delete_Telefono(1,correo);
            }
            catch (Exception e) { }
        }

        public String[] PerfilPersona(String user)
        {
            String[] result = new String[6];
            //result[0] = "jeragones@gmail.com";
            //result[1] = "Jorge Rojas Aragonés";
            //result[2] = "D";
            //result[3] = "25 años coordinador";
            //result[4] = "Sucre, San Carlos";
            //result[5] = "12345678";

            DataTable usuario = webservice.Select_Usuario(user);
            if (usuario.Columns.Count > 2)
            {
                foreach (DataRow row in usuario.Rows)
                {
                    result[0] = row["ID_CORREO"].ToString();
                    result[1] = row["TXT_NOMBRE"].ToString() + " " +
                                row["TXT_APELLIDO1"].ToString() + " " +
                                row["TXT_APELLIDO2"].ToString();
                    result[2] = row["TXT_COND_LABORAL"].ToString();
                    result[3] = row["TXT_CONOCIMIENTOS"].ToString();
                    result[4] = row["DIR_DIRECCION"].ToString();
                    result[5] = row["TXT_CONTRASEÑA"].ToString();
                }
            }
            return result;
        }

        public void consultaDatos(string correo)
        {
            string[] persona = PerfilPersona(correo);
            CORREO = persona[0];
            NOMBRE = persona[1];
            CONDICION = char.Parse(persona[2]);
            EXPERIENCIA = persona[3];
            DIRECCION = persona[4];
            CONTRASEÑA = persona[5];
            //IDIOMA = insMetodos.ConsultaIdiomas(correo);
            //TELEFONO = insMetodos.ConsultaTelefonos(correo);
        }

        public List<string[]> buscarPersona(string idioma, string condicion, string direccion, string conocimientos) {
            string[] persona = new string[2];
            //string[] persona1 = new string[2]; 
            List<string[]> lista = new List<string[]>();
            char tmp;
            if (condicion.Equals("Desempleado"))
                tmp = 'D';
            else
                tmp = 'E';

            DataTable candidatos = webservice.Buscar_Personas(idioma, tmp, direccion, conocimientos/*,0,""*/);
            foreach (DataRow row in candidatos.Rows)
            {
                persona[0] = row["ID_CORREO"].ToString();
                persona[1] = row["TXT_NOMBRE"].ToString() + " " +
                             row["TXT_APELLIDO1"].ToString() + " " +
                             row["TXT_APELLIDO2"].ToString();
                lista.Add(persona);
            }

            //persona[0] = "jeragones@gmail.com";
            //persona[1] = "Jorge Rojas Aragonés";
            //lista.Add(persona);
            //persona1[0] = "osa@gmail.com";
            //persona1[1] = "Daniel Murillo";
            //lista.Add(persona1);

            return lista;
        }
    }
}