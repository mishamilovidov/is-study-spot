using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class ClassNoteComments
    {
        public int ClassNoteCommentId { get; set; }
        public string ClassNoteCommentTitle { get; set; }
        public DateTime? ClassNoteCommentCreateDate { get; set; }
        public byte[] ClassNoteCommentUpdateDate { get; set; }
        public int ClassNoteId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
