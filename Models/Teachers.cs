using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class Teachers
    {
        public int TeacherId { get; set; }
        public string TeachFirstName { get; set; }
        public string TeachLastname { get; set; }
        public string TeachStreetAddress { get; set; }
        public string TeachCity { get; set; }
        public string TeachState { get; set; }
        public string TeachZipCode { get; set; }
        public string TeachAreaCode { get; set; }
        public string TeachPhoneNumber { get; set; }
        public int AccountId { get; set; }
    }
}
