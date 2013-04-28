using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace CarteraEmpleo.Clases
{
    public class cCorreoComunicacion
    {
        String CORREO = "turismo.empleos@gmail.com";
        String CONTRASENA = "Turismo.123";

        public Boolean CorreoRegistro(String to, String from, String pass)
        {
            String asunto = "";
            String mensaje = "";
            return Correo(to, "Administrador", from, asunto, mensaje, pass, "");
        }

        public Boolean Correo(String to, String sender, String from, String subject, String body, String pass, String archivo)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(CORREO, sender);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            /*
            if (archivo.HasFile)
            {
                msg.Attachments.Add(new Attachment(archivo));
                //archivo.PostedFile.InputStream, archivo.Filename
            }*/
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.mail.yahoo.com"; // yahoo
            //smtp.Host = "smtp.live.com"; // hotmail
            //smtp.Host = "localhost"; // servidor local
            smtp.Host = "smtp.gmail.com"; // gmail
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential(CORREO, CONTRASENA);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}