using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISStudySpot.Models
{
    public partial class PostInformation
    {
        [Key]
        public Guid ColId { get; set; }
        public int ClassNoteId { get; set; }
        public string ClassNoteTitle { get; set; }
        public DateTime? ClassNoteCreateDate { get; set; }
        public byte[] ClassNoteUpdateDate { get; set; }
        public string ClassNoteText { get; set; }
        public string ClassNoteSectionTypeDescription { get; set; }
        public int ClassNoteCommentId { get; set; }
        public DateTime? ClassNoteCommentCreateDate { get; set; }
        public string ClassNoteCommentText { get; set; }
        public string StudFirstName { get; set; }
        public string StudLastName { get; set; }
        public string CommentorFName { get; set; }
        public string CommentorLName { get; set; }
        public string SemesterName { get; set; }
        public string SubjectCode { get; set; }
        public int ClassId { get; set; }
        public int SemesterId { get; set; }
    }
}
