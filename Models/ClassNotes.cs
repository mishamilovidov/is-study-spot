using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class ClassNotes
    {
        public int ClassNoteId { get; set; }
        public string ClassNoteTitle { get; set; }
        public DateTime? ClassNoteCreateDate { get; set; }
        public byte[] ClassNoteUpdateDate { get; set; }
        public string ClassNoteText { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ClassNoteSectionId { get; set; }
    }
}
