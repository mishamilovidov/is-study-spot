using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISStudySpot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace ISStudySpot.Controllers
{
    public class ClassesController : Controller
    {
        private ISStudySpotContext _context;

    	public ClassesController(ISStudySpotContext context)
    	{
        	_context = context;
    	}

        // Displays list of all classes in the database
        public IActionResult Index()
        {
            IEnumerable<SemesterClasses> classes = _context.SemesterClasses.FromSql(
            "SELECT Classes.ClassID, Classes.SubjectID, Classes.SemesterID, Semesters.SemesterName, SemesterStartDate, SemesterEndDate, SubjectCode, SubjectName, SubjectDescription, Teachers.TeacherID, TeachFirstName, TeachLastname " +
            "FROM Classes " +
            "INNER JOIN Semesters ON Semesters.SemesterID = Classes.SemesterID " +
            "INNER JOIN Subjects ON Subjects.SubjectID = Classes.SubjectID " +
            "INNER JOIN Teachers ON Teachers.TeacherID = Classes.TeacherID " +
            "ORDER BY SemesterStartDate DESC"
            );

            return View(classes);
        }

        // Displays a summary of the most recent notes separated by note type
        public IActionResult studyresources(int? id, string name)
        {
            IEnumerable<ClassInformation> classinformation = _context.ClassInformation.FromSql(
            "SELECT newId() AS ColId, Classes.ClassID, Class_Note_Sections.ClassNoteSectionID, Class_Note_Sections.ClassNoteSectionTitle, Class_Note_Sections.ClassNoteSectionCreateDate, Class_Note_Sections.ClassNoteSectionUpdateDate, Class_Note_Section_Types.ClassNoteSectionTypeID, Class_Note_Section_Types.ClassNoteSectionTypeDescription, Class_Notes.ClassNoteID, Class_Notes.ClassNoteCreateDate, Class_Notes.ClassNoteUpdateDate, Class_Notes.ClassNoteTitle, Class_Notes.ClassNoteText, Students.StudFirstName, Students.StudLastName, Teachers.TeachFirstName, Teachers.TeachLastname, Subjects.SubjectCode, Subjects.SubjectName, Subjects.SubjectDescription, Semesters.SemesterID, Semesters.SemesterName, Semesters.SemesterStartDate, Semesters.SemesterEndDate " +
            "FROM Subjects " +
            "INNER JOIN Classes ON Subjects.SubjectID = Classes.SubjectID " +
            "INNER JOIN Class_Note_Sections ON Class_Note_Sections.ClassID = Classes.ClassID " +
            "INNER JOIN Class_Note_Section_Types ON Class_Note_Section_Types.ClassNoteSectionTypeID = Class_Note_Sections.ClassNoteSectionTypeID " +
            "INNER JOIN Class_Notes ON Class_Notes.ClassNoteSectionID = Class_Note_Sections.ClassNoteSectionID " +
            "INNER JOIN Teachers ON Teachers.TeacherID = Class_Notes.TeacherID " +
            "INNER JOIN Students ON Students.StudentID = Class_Notes.StudentID " +
            "INNER JOIN Semesters ON Semesters.SemesterID = Classes.SemesterID " +
            "WHERE Classes.ClassID = " + id +
            " ORDER BY ClassNoteCreateDate DESC;"
            );

            if (name == "class-route")
            {
                ViewBag.Breadcrumbs = "classes";
            }
            if (name == "semester-route")
            {
                ViewBag.Breadcrumbs = "semesters";
            }

            return View(classinformation);
        }

        [HttpGet]
        [Authorize]
        // Displays information associated with any particular thread
        public IActionResult post(int? id, string name)
        {
            IEnumerable<PostInformation> postinformation = _context.PostInformation.FromSql(
            "SELECT newId() AS ColId, Class_Notes.ClassNoteID, Class_Notes.ClassNoteTitle, Class_Notes.ClassNoteCreateDate, Class_Notes.ClassNoteUpdateDate, Class_Notes.ClassNoteText, Class_Note_Section_Types.ClassNoteSectionTypeDescription, (CASE WHEN Class_Note_Comments.ClassNoteCommentID IS NULL THEN 0 ELSE Class_Note_Comments.ClassNoteCommentID END) AS ClassNoteCommentID, (CASE WHEN Class_Note_Comments.ClassNoteCommentCreateDate IS NULL THEN 0 ELSE Class_Note_Comments.ClassNoteCommentCreateDate END) AS ClassNoteCommentCreateDate, (CASE WHEN Class_Note_Comments.ClassNoteCommentText IS NULL THEN 'NA' ELSE Class_Note_Comments.ClassNoteCommentText END) AS ClassNoteCommentText, Students.StudFirstName, Students.StudLastName, (CASE WHEN s2.StudFirstName IS NULL THEN 'NA' ELSE s2.StudFirstName END) AS CommentorFName, (CASE WHEN s2.StudLastName IS NULL THEN 'NA' ELSE s2.StudLastName END) AS CommentorLName, Semesters.SemesterName, Subjects.SubjectCode, Classes.ClassID, Semesters.SemesterID " +
            "FROM Class_Notes " +
            "INNER JOIN Class_Note_Sections ON Class_Note_Sections.ClassNoteSectionID = Class_Notes.ClassNoteSectionID " +
            "INNER JOIN Class_Note_Section_Types ON Class_Note_Section_Types.ClassNoteSectionTypeID = Class_Note_Sections.ClassNoteSectionTypeID " +
            "LEFT JOIN Class_Note_Comments ON Class_Note_Comments.ClassNoteID = Class_Notes.ClassNoteID " +
            "INNER JOIN Students ON Class_Notes.StudentID = Students.StudentID " +
            "LEFT JOIN Students s2 ON Class_Note_Comments.StudentID = s2.StudentID " +
            "INNER JOIN Classes ON Classes.ClassID = Class_Note_Sections.ClassID " +
            "INNER JOIN Subjects ON Subjects.SubjectID = Classes.SubjectID " +
            "INNER JOIN Semesters ON Semesters.SemesterID = Classes.SemesterID " +
            "WHERE Class_Notes.ClassNoteID = " + id +
            " ORDER BY Class_Note_Comments.ClassNoteCommentCreateDate DESC"
            );

            if (name == "class-route")
            {
                ViewBag.Breadcrumbs = "classes";
            }
            if (name == "semester-route")
            {
                ViewBag.Breadcrumbs = "semesters";
            }

            return View(postinformation);
        }

        public IActionResult postComment(int id, string title, string fname, string lname, string cdate, string text)
        {
            ViewBag.ClassNoteId = id;
            ViewBag.ClassNoteTitle = title;
            ViewBag.StudFirstName = fname;
            ViewBag.StudLastName = lname;
            ViewBag.ClassNoteCreateDate = cdate;
            ViewBag.ClassNoteText = text;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> postComment(int id, string username, string fname, string lname, IFormCollection data)
        {
            if (ModelState.IsValid) 
            {
                foreach (string description in data.Keys)
                {
                    if (description.Equals("ClassNoteCommentText"))
                    {
                        var commentText = data[description];

                        try
                        {
                            Random rnd = new Random();
                            int newID = rnd.Next(1000);
                            int newStudentID = rnd.Next(1000);

                            DateTime now = DateTime.Now;

                            _context.Database.ExecuteSqlCommand(
                                "INSERT INTO Accounts (AccountID,AccountUserName) " +
                                "VALUES ('" + newID + "','" + username + "')");

                            _context.Database.ExecuteSqlCommand(
                                "INSERT INTO Students (StudentID,StudFirstName,StudLastName,AccountID) " +
                                "VALUES ('" + newStudentID + "','" + fname + "','" + lname + "','" + newID + "')");

                            _context.Database.ExecuteSqlCommand(
                                "INSERT INTO Class_Note_Comments (ClassNoteCommentCreateDate,ClassNoteID,StudentID,TeacherID,ClassNoteCommentText) " +
                                "VALUES ('" + now + "','" + id + "', '" + newStudentID + "','" + 2 + "','" + commentText + "')");

                            return RedirectToAction("post", new RouteValueDictionary(
                                new { controller = "Classes", action = "post", id = id })
                            );
                        }
                        catch (DbUpdateException /* ex */)
                        {
                            //Log the error (uncomment ex variable name and write a log.)
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }

            return RedirectToAction("Index", "Home");

        }

    }
}
