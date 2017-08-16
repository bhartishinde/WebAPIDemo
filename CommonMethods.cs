using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace WebAPIDemo
{
    public class CommonMethods
    {
        public bool IcalEmailsWithICSFile()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new System.Net.NetworkCredential("bhartishinde01@gmail.com", "");
                client.Credentials = cred;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                MailMessage message = new MailMessage();
                message.To.Add("shrikant.mane@eternussolutions.com");
                message.CC.Add("bharati.shinde@eternussolutions.com");
                message.From = new MailAddress("bhartishinde01@gmail.com", "ESPL, Inc");
                message.Subject = "ICS File for event";
                message.Body = "Hello,<br/>Sending you the ICS file to be added into your calendar";
                message.IsBodyHtml = true;

                StringBuilder sb = new StringBuilder();
                string DateFormat = "yyyyMMddTHHmmssZ";
                string now = DateTime.Now.ToUniversalTime().ToString(DateFormat);
                sb.AppendLine("BEGIN:VCALENDAR");
                sb.AppendLine("PRODID:-//Compnay Inc//Product Application//EN");
                sb.AppendLine("VERSION:2.0");
                sb.AppendLine("METHOD:PUBLISH");

                //foreach (var res in reg.Reservations)
                //{
                DateTime dtStart = new DateTime(2017, 8, 15);
                DateTime dtEnd = new DateTime(2017, 8, 15);
                sb.AppendLine("BEGIN:VEVENT");
                sb.AppendLine("DTSTART:" + dtStart.ToUniversalTime().ToString(DateFormat));
                sb.AppendLine("DTEND:" + dtEnd.ToUniversalTime().ToString(DateFormat));
                sb.AppendLine("DTSTAMP:" + now);
                sb.AppendLine("UID:" + Guid.NewGuid());
                sb.AppendLine("CREATED:" + now);
                sb.AppendLine("X-ALT-DESC;FMTTYPE=text/html:" + "Description");
                //sb.AppendLine("DESCRIPTION:" + res.Details);
                sb.AppendLine("LAST-MODIFIED:" + now);
                sb.AppendLine("LOCATION:" + "Pune");
                sb.AppendLine("SEQUENCE:0");
                sb.AppendLine("STATUS:CONFIRMED");
                sb.AppendLine("SUMMARY:" + "Independance Day");
                sb.AppendLine("TRANSP:OPAQUE");
                sb.AppendLine("END:VEVENT");
                //}

                sb.AppendLine("END:VCALENDAR");
                var calendarBytes = Encoding.UTF8.GetBytes(sb.ToString());
                MemoryStream ms = new MemoryStream(calendarBytes);
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, "test.ics", "text/calendar");
                message.Attachments.Add(attachment);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IcalEmailsWithParams(string toUsers, string ccUsers, string bccUsers, string emailSubject, string emailBody, string eventName, DateTime startTime, DateTime endTime, string eventDescription, string location)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new System.Net.NetworkCredential("bhartishinde01@gmail.com", "");
                client.Credentials = cred;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                MailMessage message = new MailMessage();
                message.To.Add(toUsers);
                message.CC.Add(ccUsers);
                message.From = new MailAddress("bhartishinde01@gmail.com", "ESPL, Inc");

                message.Subject = emailSubject;
                message.Body = emailBody;
                message.IsBodyHtml = true;

                StringBuilder sb = new StringBuilder();
                string DateFormat = "yyyyMMddTHHmmssZ";
                string now = DateTime.Now.ToUniversalTime().ToString(DateFormat);
                sb.AppendLine("BEGIN:VCALENDAR");
                sb.AppendLine("PRODID:-//Compnay Inc//Product Application//EN");
                sb.AppendLine("VERSION:2.0");
                sb.AppendLine("METHOD:PUBLISH");

                //foreach (var res in reg.Reservations)
                //{
                //DateTime dtStart = new DateTime(2017, 8, 15);
                //DateTime dtEnd = new DateTime(2017, 8, 15);
                sb.AppendLine("BEGIN:VEVENT");
                sb.AppendLine("DTSTART:" + startTime.ToUniversalTime().ToString(DateFormat));
                sb.AppendLine("DTEND:" + endTime.ToUniversalTime().ToString(DateFormat));
                sb.AppendLine("DTSTAMP:" + now);
                sb.AppendLine("UID:" + Guid.NewGuid());
                sb.AppendLine("CREATED:" + now);
                sb.AppendLine("X-ALT-DESC;FMTTYPE=text/html:" + eventDescription);
                //sb.AppendLine("DESCRIPTION:" + res.Details);
                sb.AppendLine("LAST-MODIFIED:" + now);
                sb.AppendLine("LOCATION:" + location);
                sb.AppendLine("SEQUENCE:0");
                sb.AppendLine("STATUS:CONFIRMED");
                sb.AppendLine("SUMMARY:" + eventName);
                sb.AppendLine("TRANSP:OPAQUE");
                sb.AppendLine("END:VEVENT");
                //}

                sb.AppendLine("END:VCALENDAR");
                var calendarBytes = Encoding.UTF8.GetBytes(sb.ToString());
                MemoryStream ms = new MemoryStream(calendarBytes);
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, "test.ics", "text/calendar");
                message.Attachments.Add(attachment);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IcalEmailWithObjects(emailMessageObject emailMessageDetails, eventDetailsObject eventDetails)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                NetworkCredential cred = new System.Net.NetworkCredential("bhartishinde01@gmail.com", "");
                client.Credentials = cred;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                MailMessage message = new MailMessage();
                message.To.Add(emailMessageDetails.toUsers);
                message.CC.Add(emailMessageDetails.ccUsers);
                message.From = new MailAddress("bhartishinde01@gmail.com", "ESPL, Inc");

                message.Subject = emailMessageDetails.emailSubject;
                message.Body = emailMessageDetails.emailBody;
                message.IsBodyHtml = true;

                StringBuilder sb = new StringBuilder();
                string DateFormat = "yyyyMMddTHHmmssZ";
                string now = DateTime.Now.ToUniversalTime().ToString(DateFormat);
                sb.AppendLine("BEGIN:VCALENDAR");
                sb.AppendLine("PRODID:-//Compnay Inc//Product Application//EN");
                sb.AppendLine("VERSION:2.0");
                sb.AppendLine("METHOD:PUBLISH");

                //foreach (var res in reg.Reservations)
                //{
                //DateTime dtStart = new DateTime(2017, 8, 15);
                //DateTime dtEnd = new DateTime(2017, 8, 15);
                sb.AppendLine("BEGIN:VEVENT");
                sb.AppendLine("DTSTART:" + eventDetails.startTime.ToUniversalTime().ToString(DateFormat));
                sb.AppendLine("DTEND:" + eventDetails.endTime.ToUniversalTime().ToString(DateFormat));
                sb.AppendLine("DTSTAMP:" + now);
                sb.AppendLine("UID:" + Guid.NewGuid());
                sb.AppendLine("CREATED:" + now);
                sb.AppendLine("X-ALT-DESC;FMTTYPE=text/html:" + eventDetails.eventDescription);
                //sb.AppendLine("DESCRIPTION:" + res.Details);
                sb.AppendLine("LAST-MODIFIED:" + now);
                sb.AppendLine("LOCATION:" + eventDetails.location);
                sb.AppendLine("SEQUENCE:0");
                sb.AppendLine("STATUS:CONFIRMED");
                sb.AppendLine("SUMMARY:" + eventDetails.eventName);
                sb.AppendLine("TRANSP:OPAQUE");
                sb.AppendLine("END:VEVENT");
                //}

                sb.AppendLine("END:VCALENDAR");
                var calendarBytes = Encoding.UTF8.GetBytes(sb.ToString());
                MemoryStream ms = new MemoryStream(calendarBytes);
                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, "test.ics", "text/calendar");
                message.Attachments.Add(attachment);
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public PostCombineResponse PostAlbum(PostCombineRequest request)
        //{
        //    var emailD = request.emailDetails;
        //    var eventD = request.eventDetails;

        //    return new PostCombineResponse()
        //    {
        //        IsSuccess = true,
        //        Result = String.Format("{0} {1:d} {2}", emailD, emailD.emailSubject, eventD)
        //    };
        //}

    }
}