using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarteraEmpleo.Clases;
using System.Windows.Forms;
using System.Data;

namespace CarteraEmpleo.Clases
{
    public class cEmpleosDatos
    {
        Service1 webService = new Service1();

        /**
         * inserta puestos
         */
        public Boolean insertar(string p_NumJornada, string p_Horario, string p_Conocimientos, string p_Salario)
        {
            string _Correo = Site.USUARIO;
            if(_Correo != ""){
                if ( p_NumJornada != "" && p_Horario != "" && p_Conocimientos != "" && p_Salario != "")
                {
                    if (Numero(p_NumJornada) && Numero(p_Salario))
                    {
                        int _iNumJornada = Convert.ToInt32(p_NumJornada);
                        int _iSalario = Convert.ToInt32(p_Salario);
                        try
                        {
                            webService.Insert_Publicacion(_Correo, _iNumJornada, p_Horario, p_Conocimientos, _iSalario);
                            MessageBox.Show("Puesto Insertado con Exito", "Inserción de Publicaciones", MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                    else {
                        MessageBox.Show("En el campo 'Número de Jornada' o 'Salario' no se escribió un valor numérico", "Inserción de Publicaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }else {
                    MessageBox.Show("Existen Campos sin Completar", "Inserción de Publicaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else {
                    MessageBox.Show("Debe iniciar Sesión", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
        }

        /**
         * Modificar Puesto
         */
        public void modificar(string p_IdPuesto,string p_Descripcion,string p_IdCatEmpleo) {
            if (p_IdPuesto != "" && p_Descripcion != "" && p_IdCatEmpleo != "")
            {
                if (Numero(p_IdPuesto) && Numero(p_IdCatEmpleo)) {
                    int _iIdPuesto = Convert.ToInt32(p_IdPuesto);
                    int _iIdCatEmpleo = Convert.ToInt32(p_IdCatEmpleo);
                    try
                    {
                        webService.Update_Puesto(_iIdPuesto, p_Descripcion, _iIdCatEmpleo);
                    }
                    catch (Exception e){ }
                }
            }
        }

        /**
         * eliminar puesto
         */
        public void eliminar(int p_IdPuesto) {
            try
            {
                if(MessageBox.Show("Desea Eliminar la Publicación?","Eliminar Publicación",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK ){
                    webService.Delete_Publicacion(p_IdPuesto);
                }
            }
            catch (Exception e)
            {
                //e.Message;
            }
        }

        /**
         * valida si el parametro es un numero
         */
        public Boolean Numero(String p_numero)
        {
            int _iNumero = 0;
            return (int.TryParse(p_numero, out _iNumero));
        }

        /**
         * 
         */
        public DataTable selectPublicaciones() {
            Service1 webservice = new Service1();
            DataTable dbResultado = new DataTable();
           // string _usuario = "empresa@gmail.com";
            string _usuario = Site.USUARIO;
            if (_usuario == "")
            {
                MessageBox.Show("Debe iniciar sesión","Login",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return dbResultado;
            }
            else {
                try
                {
                    dbResultado = webservice.Select_Publicacion(_usuario);
                    return dbResultado;
                }
                catch (Exception ex)
                {
                    return dbResultado;
                }
            }
            
        }
    }
}