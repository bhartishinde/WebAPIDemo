using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo
{
    public class CommonEntities
    {
    }

    public class emailMessageObject
    {
        public string toUsers { get; set; }
        public string ccUsers { get; set; }
        public string bccUsers { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
    }

    public class eventDetailsObject
    {
        public string eventName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string eventDescription { get; set; }
        public string location { get; set; }
    }

    //public class PostCombineRequest
    //{
    //    public emailMessageObject emailDetails { get; set; }
    //    public eventDetailsObject eventDetails { get; set; }
    //}

    //public class PostCombineResponse
    //{
    //    public string Result { get; set; }
    //    public bool IsSuccess { get; set; }
    //    public string ErrorMessage { get; set; }
    //}
}