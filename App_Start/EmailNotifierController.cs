using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization.iCalendar.Serializers;
using Ical.Net.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebAPIDemo.App_Start
{
    public class EmailNotifierController : ApiController
    {
        CommonMethods cs = new CommonMethods();

        //// Send Email 
        //[HttpGet]
        //public string SendEmail()
        //{
        //    bool result = cs.IcalEmailsWithICSFile();
        //    if (result)
        //        return "Email Message Sent with event";
        //    else
        //        return "Can not send email";
        //}

        // Send Email 
        [HttpGet]
        public string SendEmailWithParams([FromUri]string toUsers, [FromUri]string ccUsers, [FromUri]string bccUsers, [FromUri]string emailSubject, [FromUri]string emailBody, [FromUri]string eventName, [FromUri]DateTime startTime, [FromUri]DateTime endTime, [FromUri]string eventDescription, [FromUri]string location)
        {
            bool result = cs.IcalEmailsWithParams(toUsers, ccUsers, bccUsers, emailSubject, emailBody, eventName, startTime, endTime, eventDescription, location);
            if (result)
                return "Email Message Sent with event";
            else
                return "Can not send email";
        }

        //// Send Email 
        //[HttpPost]
        //public string SendEmailWithObject([FromBody]emailMessageObject emailMessageDetails, [FromBody]eventDetailsObject eventDetails)
        //{
        //    bool result = cs.IcalEmailWithObjects(emailMessageDetails, eventDetails);
        //    if (result)
        //        return "Email Message Sent with event";
        //    else
        //        return "Can not send Email";
        //}

        // Send Email 
        [HttpPost]
        public string SendEmailWithObject(JObject jsonData)
        {
            //PostCombineResponse response = cs.PostAlbum(request);

            dynamic json = jsonData;
            JObject jEmail = json.emailMessageObject;
            JObject jEvent = json.eventDetailsObject;

            var emailMessageDetails = jEmail.ToObject<emailMessageObject>();
            var eventDetails = jEvent.ToObject<eventDetailsObject>();

            bool result = cs.IcalEmailWithObjects(emailMessageDetails, eventDetails);
            if (result)
                return "Email Message Sent with event";
            else
                return "Can not send Email";

        }
    }
}
