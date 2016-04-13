using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace film.Models
{
    public class email
    {
        private static List<string> get_all_emails_subscribed()
        {
            List<string> emails = new List<string>();
            db db = new db();
            db.connect();
            SqlDataReader reader = db.query_db("EXEC get_all_emails_subscribed");
            while (reader.Read())
            {
                emails.Add(reader["email"].ToString());
            }
            reader.Close();
            db.disconnect();
            return emails;
        }    

        public static void send_email_notifications()
        {
            send_email_notifications_thread();
            /*
            ThreadStart email_thread_start = new ThreadStart(send_email_notifications);
            Thread email_thread = new Thread(email_thread_start);
            email_thread.Start();
            */
        }

        private static void send_email_notifications_thread()
        {
            try {
                SmtpClient smtp_client = new SmtpClient("mail.boxofficetournament.com", 587);
                smtp_client.Credentials = new NetworkCredential("notifications", "notifications!", "mail.boxofficetournament.com");
                //smtp_client.UseDefaultCredentials = true;
                smtp_client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp_client.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("notifications@boxofficetournament.com", "Box Office Tournament Notifiations");
                mail.To.Add(new MailAddress("notifications@boxofficetournament.com"));
                mail.Body = "test";

                smtp_client.Send(mail);
            }
            catch (SmtpException se)
            {
                string m = se.Message;
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
        }
    }
}