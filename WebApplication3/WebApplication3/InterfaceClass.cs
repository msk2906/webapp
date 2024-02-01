using WebApplication3.Model;
using Microsoft.AspNetCore.Mvc; 
namespace WebApplication3
{
    public interface Istudent
    {
        public IEnumerable<student> GetAllStudents();
        public student GetStudentById(int id);
        public int AddStudent(student stud);
        public int UpdateStudent(student stud);
        public int DeleteStudent(int id);
    }
}