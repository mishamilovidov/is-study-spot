using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class Accounts
    {
        public int AccountId { get; set; }
        public string AccountUserName { get; set; }
        public bool? AccountEmailVerified { get; set; }
        public string AccountPassword { get; set; }
        public string AccountPasswordTmp { get; set; }
        public DateTime? AccountCreateDate { get; set; }
        public DateTime? AccountUpdateDate { get; set; }
        public byte[] AccountLastLogin { get; set; }
    }
}
