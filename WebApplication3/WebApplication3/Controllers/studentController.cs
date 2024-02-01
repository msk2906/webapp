using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication3.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        CrudClass crudclass = new CrudClass();

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<student>> Getall()
        {
            try
            {
                IEnumerable<student> studentlist = crudclass.GetAllStudents();
                return Ok(studentlist);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<student> Getbyid(int id)
        {
            try
            {
                student studentbyid = crudclass.GetStudentById(id);
                if (studentbyid != null)
                {
                    return Ok(studentbyid);
                }
                else { return NotFound(); }
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult<string> Create([FromBody] student student)
        {
            try
            {
                int StudentCreated = crudclass.AddStudent(student);
                if (StudentCreated > 0)
                {
                    return Ok("Student added Successfully");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult<string> Update([FromBody] student student)
        {
            try
            {
                int StudentUpdate = crudclass.UpdateStudent(student);
                if (StudentUpdate > 0)
                {
                    return Ok("Student Updated Successfully");
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
            
        }

        [HttpDelete]
        [Route("Delete")]

        public ActionResult<int> delete(int id)
        {
            try
            {
                int StudentDelete = crudclass.DeleteStudent(id);
                if (StudentDelete > 0)
                {
                    return Ok("Student Deleted Successfully");
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
            
        }
    }
}
 
