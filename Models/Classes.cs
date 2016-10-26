using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class Classes
    {
        public int ClassId { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int SemesterId { get; set; }
        public int TeacherId { get; set; }
    }
}
