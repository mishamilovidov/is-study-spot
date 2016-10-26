using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public string StudFirstName { get; set; }
        public string StudLastName { get; set; }
        public string StudStreetAddress { get; set; }
        public string StudCity { get; set; }
        public string StudState { get; set; }
        public string StudZipCode { get; set; }
        public string StudAreaCode { get; set; }
        public string StudPhoneNumber { get; set; }
        public DateTime? StudBirthDate { get; set; }
        public string StudGender { get; set; }
        public string StudMaritalStatus { get; set; }
        public int AccountId { get; set; }
    }
}
