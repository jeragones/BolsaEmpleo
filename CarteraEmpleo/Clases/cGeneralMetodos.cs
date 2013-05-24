using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CarteraEmpleo.Clases
{
    public class cGeneralMetodos
    {
        /*
         * Instancias de otras clases
         */
        Service1 webservice = new Service1();
        cCorreoComunicacion insCorreo = new cCorreoComunicacion();

        /*
         * Metodo que inicia sesion, inicializa las propiedades del usuario que inicio sesion
         */
        public String IniciarSesion(String p_usuario, String p_contrasena)
        {
            //string error = "";
            //cPersonaDatos.NOMBRE = "Jorge Rojas Aragonés";
            //cPersonaDatos.CORREO = "jeragones@gmail.com";
            //cPersonaDatos.CONDICION = 'D';
            //cPersonaDatos.EXPERIENCIA = "25 años coordinador";
            //cPersonaDatos.DIRECCION = "Sucre, San Carlos";
            //String[] s1 = { "Inglés", "Español" };
            //cPersonaDatos.IDIOMA = s1;
            //String[] s2 = { "8914-2348", "2460-1913" };
            //cPersonaDatos.TELEFONO = s2;
            //Site.USUARIO = "jeragones@gmail.com";
            //Site.CONTRASENA = "12345678";
            //Site.TIPO = 3;


            DataTable usuario = webservice.Select_Usuario(p_usuario); //webservice.EndSelect_Usuario(p_usuario);        //.Select_Persona("leock123@gmail.com", "123456789");
            string error = "";
            if (usuario.Columns.Count > 2)
            {
                foreach (DataRow row in usuario.Rows)
                {
                    if (row["TXT_ESTADO"].ToString().Equals("A"))
                    {
                        if (p_contrasena.Equals(row["TXT_CONTRASEÑA"].ToString()))
                        {
                            Site.USUARIO = row["ID_CORREO"].ToString();
                            Site.CONTRASENA = row["TXT_CONTRASEÑA"].ToString();

                            if (usuario.Columns.Contains("TXT_CED_JURIDICA"))
                            {
                                cEmpresaDatos.CEDJURIDICA = row["TXT_CED_JURIDICA"].ToString();
                                cEmpresaDatos.CORREO = row["ID_CORREO"].ToString(); //Site.USUARIO;
                                cEmpresaDatos.CONTRASEÑA = row["TXT_CONTRASEÑA"].ToString();
                                cEmpresaDatos.NOMBRE = row["TXT_NOMBRE"].ToString();
                                cEmpresaDatos.PAGINA = row["TXT_PAG_WEB"].ToString();
                                cEmpresaDatos.DESCRIPCION = row["TXT_DESC"].ToString();
                                cEmpresaDatos.DIRECCION = row["DIR_DIRECCION"].ToString();
                                cEmpresaDatos.TELEFONO = ConsultaTelefonos(p_usuario);
                                Site.TIPO = 2;
                            }
                            else if (usuario.Columns.Contains("TXT_APELLIDO1"))
                            {
                                cPersonaDatos.NOMBRE = row["TXT_NOMBRE"].ToString() + " " +
                                                       row["TXT_APELLIDO1"].ToString() + " " +
                                                       row["TXT_APELLIDO2"].ToString();
                                cPersonaDatos.CORREO = row["ID_CORREO"].ToString();  //Site.USUARIO;
                                cPersonaDatos.CONTRASEÑA = row["TXT_CONTRASEÑA"].ToString();
                                cPersonaDatos.CONDICION = char.Parse(row["TXT_COND_LABORAL"].ToString());
                                cPersonaDatos.EXPERIENCIA = row["TXT_CONOCIMIENTOS"].ToString();
                                cPersonaDatos.DIRECCION = row["DIR_DIRECCION"].ToString();
                                cPersonaDatos.IDIOMA = ConsultaIdiomas(p_usuario);
                                cPersonaDatos.TELEFONO = ConsultaTelefonos(p_usuario);
                                Site.TIPO = 3;
                            }
                            //else {
                            //    Site.TIPO = 1;
                            //}
                        }
                        else
                        {
                            error = "Contraseña incorrecta.";
                        }
                    }
                    else
                    {
                        error = "No sea ha compleatado el registro.";
                    }
                }
            }
            else
            {
                error = "El nombre de usuario no existe.";
            }
            return error;
        }

        /*
         * Metodo que identifica de que tipo de usuario es el que inicio sesion
         */
        public String[] UsuarioLogin()
        {
            String[] usuario = {"",""};
            switch (Site.TIPO) 
            {
                case 1:
                    usuario[0] = "Administrador";
                    usuario[1] = "1";
                    break;
                case 2:
                    usuario[0] = cEmpresaDatos.NOMBRE;
                    usuario[1] = "2";
                    break;
                case 3:
                    usuario[0] = cPersonaDatos.NOMBRE;
                    usuario[1] = "3";
                    break;
            }
            return usuario;
        }

        /*
         * Metodo para insertar un nuevo idioma a una persona
         */
        public String InsertarIdioma(int idioma)
        {
            try
            {
                webservice.Insert_Persona_Idioma(Site.USUARIO, idioma);
                return ("");
            }
            catch (Exception e)
            {
                return ("Error al añadir un nuevo idioma.");
            }
        }

        /*
         * Metodo que inserta un nuevo telefono a un usuario
         */
        public String InsertarTelefono(String telefono) {
            String msg = "";
            if (ValidarTelefono(telefono)) {
                try {
                    webservice.Insert_Telefono(Site.USUARIO, telefono);
                } catch (Exception e) {
                    msg = "Error al añadir un nuevo teléfono.";
                }
            } else {
                msg = "Telefono incorrecto.";
            }
            return msg;
        }

        /*
         * Metodo para consultar los idiomas asociados a una persona
         */
        public String[] ConsultaIdiomas(String p_usuario) {
            DataTable idiomas = webservice.Select_Persona_Idioma(p_usuario);
            string temp = "";
            foreach (DataRow row in idiomas.Rows)
            {
                temp += row["TXT_IDIOMA"].ToString() + ",";
            }
            char[] separador = {','};
            return Fragmentar(temp,separador);
        }

        /*
         * Metodo para consultar los telefonos asociados a un usuairo
         */
        public String[] ConsultaTelefonos(String p_usuario)
        {
            DataTable telefonos = webservice.Select_Telefono(p_usuario);
            string temp = "";
            foreach (DataRow row in telefonos.Rows)
            {
                temp += row["TXT_TELEFONO"].ToString() + ",";
            }
            char[] separador = { ',' };
            return Fragmentar(temp, separador);
        }

        /*
         * Metodo para modificar el estado de un usuario
         */
        public void ModificarEstado(String usuario, char estado) 
        {
            try 
            {
                webservice.Update_Estado_Usuario(usuario, estado);
            }
            catch (Exception e) { }
        }

        /*
         * Metodo para validar que el formato de un telefono este bien escrito
         */
        public Boolean ValidarTelefono(String telefono) 
        {
            String[] _sFracmentar;
            char[] separador = { '-' };
            _sFracmentar = Fragmentar(telefono, separador);
            if (telefono.Length != 9 |
                _sFracmentar.Length != 2 |
                !Numero(_sFracmentar[0]) |
                !Numero(_sFracmentar[1]) |
                _sFracmentar[0].Length != _sFracmentar[1].Length)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        /*
         * Metodo que valida que la contraseña sea correcta
         */
        public Boolean ValidarContrasena(String pass1, String pass2) {
            if (pass1.Length >= 8)
            {
                if (!pass1.Equals(pass2))
                {
                    return true; // ("Las contraseñas no coinciden.");
                } else {
                    return false; // ("");
                }
            }
            else
            {
                return true; // ("Contraseña inválida.");
            }
        }

        /*
         * Metodo para validar que una contraseña sea correcta
         */
        public Boolean ValidarContrasena(String pass1, String pass2, String pass3)
        {
            if (!pass1.Equals(Site.CONTRASENA))
            {
                return true;
            }
            return ValidarContrasena(pass2, pass3);    
        }

        /*
         * Metodo para validar que le formato del correo este bien escrito
         */
        public Boolean ValidarCorreo(String correo) {
            String[] _sFracmentar;
            char[] _cSepCorreo1 = { ' ',',','!','#','$','%','^','&','*','(',
                                            ')','+','/',';',':','"','/' };
            char[] _cSepCorreo2 = { '@' }; // arreglar lo del punto del correo
            _sFracmentar = Fragmentar(correo, _cSepCorreo1);
            if (_sFracmentar.Length > 1)
            {
                return(true);
            }
            _sFracmentar = Fragmentar(correo, _cSepCorreo2);
            if (_sFracmentar.Length != 2)
            {
                return(true);
            }
            if (_sFracmentar[0].Equals("") | _sFracmentar[1].Equals(""))
            {
                return (true);
            }
            return (false);
        }

        /*
         * Metodo para mostrar los mensajes luego de que un usuario se registra
         */
        public String Registrar(String usuario, int accion) {
            String asunto, mensaje;
            Boolean respuesta;
            switch (accion) {
                case 1:
                    ModificarEstado(usuario, 'A');
                    return "Gracias por registrarse en nuestra Cartera de Empleos.";

                case 2:
                    return "Se ha enviado un mensaje a su correo para confirmar su registro.";
                case 4:
                    return "Gracias por registrarse en nuestra Cartera de Empleos, espere hasta que el administrador active su cuenta.";
                case 5:
                    // modificar el estado del usuario a activo(A)
                    asunto = "Registro de Cartera de Empleo";
                    mensaje = "<p>Buenos días</p>" +
                              "<p>Gracias por su registro de usuario en la Cartera de Empleos de Turísmo, su cuenta se encuentra lista para usarse.</p>" +
                              "<p>http://localhost:49367/Interfaz/Default.aspx</p>"; 
                    respuesta = insCorreo.Correo(usuario, "Administrador", "correo del administrador",
                                                 asunto, mensaje, "Turismo.123", null);
                    break;
                case 6:
                   // modificar el estado del usuario a activo(I)
                    asunto = "Registro de Cartera de Empleo";
                    mensaje = "<p>Buenos días</p>" +
                              "<p>Lamentablemente su registro de usuario en la Cartera de Empleos de Turísmo no se pudo completar, le solicitamos que lo intente de nuevo en el enlace que aparece a continuación:</p>" +
                              "<p>http://localhost:49367/Interfaz/Default.aspx</p>"; 
                    respuesta = insCorreo.Correo(usuario, "Administrador", "correo del administrador",
                                                 asunto, mensaje, "Turismo.123", null);
                    break;
            }
            return "";
        }

        public int BuscarUsuario() {
            return Site.TIPO;
        }

        /*
         * Metodo para fragmentar cadenas de caracteres
         */
        public String[] Fragmentar(String p_cadena, char[] p_separador)
        {
            String[] vector = p_cadena.Split(p_separador);
            return vector;
        }

        /*
         * Metodo para validar si el valor de la variable es de tipo entero
         */
        public Boolean Numero(String p_numero)
        {
            int _iNumero = 0;
            return (int.TryParse(p_numero, out _iNumero));
        }
    }
}