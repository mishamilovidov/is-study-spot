using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class LoginAttempts
    {
        public int LoginAttemptId { get; set; }
        public string LoginAttemptEmail { get; set; }
        public string LoginAttemptHttpClientIp { get; set; }
        public string LoginAttemptHttpXforwardedFor { get; set; }
        public string LoginAttemptHttpUserAgent { get; set; }
        public string LoginAttemptRemoteAddr { get; set; }
        public byte[] LoginAttemptTimestamp { get; set; }
    }
}
