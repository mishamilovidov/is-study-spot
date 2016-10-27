using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class ClassNoteSections
    {
        public int ClassNoteSectionId { get; set; }
        public string ClassNoteSectionTitle { get; set; }
        public DateTime? ClassNoteSectionCreateDate { get; set; }
        public byte[] ClassNoteSectionUpdateDate { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ClassNoteSectionTypeId { get; set; }

        public virtual ClassNoteSectionTypes ClassNoteSectionType { get; set; }
    }
}
