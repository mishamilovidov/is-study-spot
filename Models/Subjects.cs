using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class Subjects
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
    }
}
