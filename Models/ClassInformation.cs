using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISStudySpot.Models
{
    public partial class ClassInformation
    {
        [Key]
        public Guid ColId { get; set; }
        public int ClassNoteSectionId { get; set; }
        public int ClassId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public string ClassNoteSectionTitle { get; set; }
        public DateTime? ClassNoteSectionCreateDate { get; set; }
        public byte[] ClassNoteSectionUpdateDate { get; set; }
        public int ClassNoteSectionTypeId { get; set; }
        public string ClassNoteSectionTypeDescription { get; set; }
        public int ClassNoteId { get; set; }
        public DateTime? ClassNoteCreateDate { get; set; }
        public byte[] ClassNoteUpdateDate { get; set; }
        public string ClassNoteTitle { get; set; }
        public string ClassNoteText { get; set; }
        public string StudFirstName { get; set; }
        public string StudLastName { get; set; }
        public string TeachFirstName { get; set; }
        public string TeachLastname { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime? SemesterStartDate { get; set; }
        public DateTime? SemesterEndDate { get; set; }
    }
}
