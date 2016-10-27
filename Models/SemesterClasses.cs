using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISStudySpot.Models
{
    public partial class SemesterClasses
    {
        [Key]
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime? SemesterStartDate { get; set; }
        public DateTime? SemesterEndDate { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public int TeacherId { get; set; }
        public string TeachFirstName { get; set; }
        public string TeachLastname { get; set; }
    }
}
