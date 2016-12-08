using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISStudySpot.Models
{
    public partial class CommentView
    {
        public int ClassNoteCommentId { get; set; }
        public DateTime? ClassNoteCommentCreateDate { get; set; }
        public byte[] ClassNoteCommentUpdateDate { get; set; }
        public int ClassNoteId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "A comment is required.")]
        public string ClassNoteCommentText { get; set; }
    }
}
