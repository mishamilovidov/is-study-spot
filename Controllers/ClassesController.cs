using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISStudySpot.Models;
using Microsoft.EntityFrameworkCore;

namespace ISStudySpot.Controllers
{
    public class ClassesController : Controller
    {
        private ISStudySpotContext _context;

    	public ClassesController(ISStudySpotContext context)
    	{
        	_context = context;
    	}

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult studyresources(int? id)
        {
            IEnumerable<ClassInformation> classinformation = _context.ClassInformation.FromSql(
            "SELECT newId() AS ColId, Classes.ClassID, Class_Note_Sections.ClassNoteSectionID, Class_Note_Sections.ClassNoteSectionTitle, Class_Note_Sections.ClassNoteSectionCreateDate, Class_Note_Sections.ClassNoteSectionUpdateDate, Class_Note_Section_Types.ClassNoteSectionTypeID, Class_Note_Section_Types.ClassNoteSectionTypeDescription, Class_Notes.ClassNoteID, Class_Notes.ClassNoteCreateDate, Class_Notes.ClassNoteUpdateDate, Class_Notes.ClassNoteTitle, Class_Notes.ClassNoteText, Students.StudFirstName, Students.StudLastName, Teachers.TeachFirstName, Teachers.TeachLastname, Subjects.SubjectCode, Subjects.SubjectName, Subjects.SubjectDescription, Semesters.SemesterName, Semesters.SemesterStartDate, Semesters.SemesterEndDate " +
            "FROM Subjects " +
            "INNER JOIN Classes ON Subjects.SubjectID = Classes.SubjectID " +
            "INNER JOIN Class_Note_Sections ON Class_Note_Sections.ClassID = Classes.ClassID " +
            "INNER JOIN Class_Note_Section_Types ON Class_Note_Section_Types.ClassNoteSectionTypeID = Class_Note_Sections.ClassNoteSectionTypeID " +
            "INNER JOIN Class_Notes ON Class_Notes.ClassNoteSectionID = Class_Note_Sections.ClassNoteSectionID " +
            "INNER JOIN Teachers ON Teachers.TeacherID = Class_Notes.TeacherID " +
            "INNER JOIN Students ON Students.StudentID = Class_Notes.StudentID " +
            "INNER JOIN Semesters ON Semesters.SemesterID = Classes.SemesterID " +
            "WHERE Classes.ClassID = " + id +
            " ORDER BY ClassNoteCreateDate DESC"
            );

            return View(classinformation);
        }

        public IActionResult post(int? id)
        {
            IEnumerable<PostInformation> postinformation = _context.PostInformation.FromSql(
            "SELECT newId() AS ColId, Class_Notes.ClassNoteID, Class_Notes.ClassNoteTitle, Class_Notes.ClassNoteCreateDate, Class_Notes.ClassNoteUpdateDate, Class_Notes.ClassNoteText, Class_Note_Section_Types.ClassNoteSectionTypeDescription, Class_Note_Comments.ClassNoteCommentID, Class_Note_Comments.ClassNoteCommentCreateDate, Class_Note_Comments.ClassNoteCommentText, Students.StudFirstName, Students.StudLastName, s2.StudFirstName as CommentorFName, s2.StudLastName as CommentorLName " +
            "FROM Class_Notes " +
            "INNER JOIN Class_Note_Sections ON Class_Note_Sections.ClassNoteSectionID = Class_Notes.ClassNoteSectionID " +
            "INNER JOIN Class_Note_Section_Types ON Class_Note_Section_Types.ClassNoteSectionTypeID = Class_Note_Sections.ClassNoteSectionTypeID " +
            "LEFT JOIN Class_Note_Comments ON Class_Note_Comments.ClassNoteID = Class_Notes.ClassNoteID " +
            "INNER JOIN Students ON Class_Notes.StudentID = Students.StudentID " +
            "LEFT JOIN Students s2 ON Class_Note_Comments.StudentID = s2.StudentID " +
            "WHERE Class_Notes.ClassNoteID = " + id +
            "ORDER BY Class_Note_Comments.ClassNoteCommentCreateDate DESC"
            );

            return View(postinformation);
        }
    }
}
