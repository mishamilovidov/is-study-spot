using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class Semesters
    {
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime? SemesterStartDate { get; set; }
        public DateTime? SemesterEndDate { get; set; }
    }
}
