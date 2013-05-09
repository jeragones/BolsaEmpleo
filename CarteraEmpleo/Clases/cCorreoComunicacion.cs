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
        public static String DESTINATARIO = "";
        public static int TIPO = 0;

        public Boolean CorreoRegistro(String to, String from, String pass)
        {
            String asunto = "";
            String mensaje = "";
            return Correo(to, "Administrador", from, asunto, mensaje, pass, null);
        }

        public Boolean Correo(String to, String sender, String from, String subject, String body, String pass, Attachment archivo)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from, sender);
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            
            if (archivo != null)
            {
                msg.Attachments.Add(archivo);
            }
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.mail.yahoo.com"; // yahoo
            //smtp.Host = "smtp.live.com"; // hotmail
            //smtp.Host = "localhost"; // servidor local
            smtp.Host = "smtp.gmail.com"; // gmail
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential(from, pass);
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