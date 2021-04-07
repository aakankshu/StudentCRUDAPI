using Microsoft.AspNetCore.Mvc;
using StudentCRUDAPI.Models;
using StudentCRUDAPI.StudentData;
using System;

namespace StudentCRUDAPI.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private IStudentData _studentData;

        public StudentsController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetStudents()
        {
            return Ok(_studentData.GetStudents());
        }

        [HttpGet]
        [Route("api/[controller]/{StudentID}")]
        public IActionResult GetStudent(Guid StudentID)
        {
            var student = _studentData.GetStudent(StudentID);
            if(student != null)
            {
                return Ok(student);
            }
            return NotFound($"Student with StudentID:{StudentID} does not exist.");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddStudent(Student student)
        {
            _studentData.AddStudent(student);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + student.StudentID, student);
        }

        [HttpDelete]
        [Route("api/[controller]/{StudentID}")]
        public IActionResult DeleteStudent(Guid StudentID)
        {
            var student = _studentData.GetStudent(StudentID);
            if (student != null)
            {
                _studentData.DeleteStudent(student);
                return Ok($"Student with StudentID:{StudentID} is deleted!");
            }
            return NotFound($"Student with StudentID:{StudentID} does not exist!");
        }

        [HttpPatch]
        [Route("api/[controller]/{StudentID}")]
        public IActionResult EditStudent(Guid StudentID, Student student)
        {
            var existingStudent = _studentData.GetStudent(StudentID);
            if (existingStudent != null)
            {
                student.StudentID = existingStudent.StudentID;
                _studentData.EditStudent(student);
            }
            return Ok($"Student details with StudentID:{StudentID} have been changed.");
        }



    }
}
