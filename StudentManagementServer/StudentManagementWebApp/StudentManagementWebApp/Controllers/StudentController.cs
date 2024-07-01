using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWebApp.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementWebApp.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]

    //Enable CORS for this controller
    [EnableCors("AllowAllOrigins")] 
    public class StudentController : ControllerBase
    {

        public static List<Student> students = new List<Student>();
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student s)
        {
            if (s == null)
            {
                return BadRequest("Student data is null");
            }

            s.Name = s.Name.ToUpper();
            students.Add(s);
            return Ok(students);
        }

        [HttpGet("getStudent/{g}")]
       public IActionResult getStudent(string g)
      {
          var studentsInDept = students.Select(s => s.getDept==g);
           if(studentsInDept!=null && studentsInDept.Count()>0)
          {
               return Ok(studentsInDept);
          }
        
          return NotFound();
       }


        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
