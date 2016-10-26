using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class ForgotPasswords
    {
        public int ForgotPasswordId { get; set; }
        public string ForgotPasswordEmail { get; set; }
        public string ForgotPasswordTmp { get; set; }
        public byte[] ForgotPasswordTimestamp { get; set; }
    }
}
