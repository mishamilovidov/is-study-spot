using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISStudySpot.Models;
using Microsoft.EntityFrameworkCore;

namespace ISStudySpot.Controllers
{
    public class StudyController : Controller
    {
        private ISStudySpotContext _context;

    	public StudyController(ISStudySpotContext context)
    	{
        	_context = context;
    	}

        public IActionResult Index()
        {
            IEnumerable<Semesters> semesters = _context.Semesters.FromSql(
                "SELECT * FROM Semesters"
                );

            return View(semesters);
        }

        public IActionResult Semesters(int? id)
        {
            IEnumerable<SemesterClasses> classes = _context.SemesterClasses.FromSql(
            "SELECT Classes.ClassID, Classes.SubjectID, Classes.SemesterID, Semesters.SemesterName, SemesterStartDate, SemesterEndDate, SubjectCode, SubjectName, SubjectDescription, Teachers.TeacherID, TeachFirstName, TeachLastname " +
            "FROM Classes " +
            "INNER JOIN Semesters ON Semesters.SemesterID = Classes.SemesterID " +
            "INNER JOIN Subjects ON Subjects.SubjectID = Classes.SubjectID " +
            "INNER JOIN Teachers ON Teachers.TeacherID = Classes.TeacherID " +
            "WHERE Classes.SemesterID = " + id
            );

            return View(classes);
        }
    }
}
