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

        public IActionResult Class(int? id)
        {
            IEnumerable<ClassInformation> classinformation = _context.ClassInformation.FromSql(
            "SELECT Classes.ClassID, Subjects.SubjectCode, Subjects.SubjectName, Subjects.SubjectDescription, " +
            "Class_Note_Sections.ClassNoteSectionID,Class_Note_Sections.ClassNoteSectionTitle, Class_Note_Sections.ClassNoteSectionCreateDate, " +
            "Class_Note_Sections.ClassNoteSectionUpdateDate, Class_Note_Section_Types.ClassNoteSectionTypeID, " +
            "Class_Note_Section_Types.ClassNoteSectionTypeDescription, Class_Notes.ClassNoteID, Class_Notes.ClassNoteCreateDate, " +
            "Class_Notes.ClassNoteUpdateDate, Class_Notes.ClassNoteTitle, Class_Notes.ClassNoteText, " +
            "Class_Note_Comments.ClassNoteCommentCreateDate, Class_Note_Comments.ClassNoteCommentUpdateDate, " +
            "Class_Note_Comments.ClassNoteCommentTitle, Class_Note_Comments.ClassNoteCommentText, Students.StudFirstName, Students.StudLastName, " +
            "Teachers.TeachFirstName, Teachers.TeachLastname " +
            "FROM Classes " +
            "INNER JOIN Subjects ON Subjects.SubjectID = Classes.SubjectID " +
            "INNER JOIN Class_Note_Sections ON Class_Note_Sections.ClassID = Classes.ClassID " +
            "INNER JOIN Class_Note_Section_Types ON Class_Note_Section_Types.ClassNoteSectionTypeID = Class_Note_Sections.ClassNoteSectionTypeID " +
            "INNER JOIN Class_Notes ON Class_Notes.ClassNoteSectionID = Class_Note_Sections.ClassNoteSectionID " +
            "INNER JOIN Class_Note_Comments ON Class_Note_Comments.ClassNoteID = Class_Notes.ClassNoteID " +
            "INNER JOIN Teachers ON Teachers.TeacherID = Class_Notes.TeacherID " +
            "INNER JOIN Students ON Students.StudentID = Class_Notes.StudentID " +
            "WHERE Classes.ClassID = " + id
            );

            return View(classinformation);
        }
    }
}
