using StudentCRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRUDAPI.StudentData
{
    public class SQLStudentData : IStudentData
    {
        private StudentContext _studentContext;

        public SQLStudentData(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public Student AddStudent(Student student)
        {
            student.StudentID = Guid.NewGuid();
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
            return student;
        }

        public void DeleteStudent(Student student)
        {
            _studentContext.Students.Remove(student);
            _studentContext.SaveChanges();
        }

        public Student EditStudent(Student student)
        {
            var existingStudent = _studentContext.Students.Find(student.StudentID);
            if(student != null)
            {
                existingStudent.RollNo = student.RollNo;
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                _studentContext.Students.Update(existingStudent);
                _studentContext.SaveChanges();
            }
            return student;
        }

        public Student GetStudent(Guid StudentID)
        {
            var student = _studentContext.Students.Find(StudentID);
            return student;
        }

        public List<Student> GetStudents()
        {
            return _studentContext.Students.ToList();
        }
    }
}
