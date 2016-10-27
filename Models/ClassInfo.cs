using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISStudySpot.Models
{
    public partial class ClassInfo
    {
        [Key]
        public int ClassId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public int ClassNoteSectionId { get; set; }
        public string ClassNoteSectionTitle { get; set; }
        public DateTime? ClassNoteSectionCreateDate { get; set; }
        public DateTime? ClassNoteSectionUpdateDate { get; set; }
        public int ClassNoteSectionTypeId { get; set; }
        public int ClassNoteSectionTypeDescription { get; set; }
        public int ClassNoteId { get; set; }
        public DateTime? ClassNoteCreateDate { get; set; }
        public DateTime? ClassNoteUpdateDate { get; set; }
        public string ClassNoteTitle { get; set; }
        public string ClassNoteText { get; set; }
        public DateTime? ClassNoteCommentCreateDate { get; set; }
        public DateTime? ClassNoteCommentUpdateDate { get; set; }
        public string ClassNoteCommentTitle { get; set; }
        public string ClassNoteCommentText { get; set; }
        public string StudFirstName { get; set; }
        public string StudLastName { get; set; }
        public string TeachFirstName { get; set; }
        public string TeachLastname { get; set; }
    }
}
