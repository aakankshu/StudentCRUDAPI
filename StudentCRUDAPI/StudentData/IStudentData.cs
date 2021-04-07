using StudentCRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCRUDAPI.StudentData
{
    public interface IStudentData
    {
        List<Student> GetStudents();

        Student GetStudent(Guid StudentID);

        Student AddStudent(Student student);

        void DeleteStudent(Student student);

        Student EditStudent(Student student);
    }
}
