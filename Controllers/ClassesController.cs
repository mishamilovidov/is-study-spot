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
            "WHERE Classes.ClassID = " + id
            );

            return View(classinformation);
        }
    }
}
