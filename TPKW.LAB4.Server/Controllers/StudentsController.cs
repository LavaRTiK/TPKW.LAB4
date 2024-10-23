using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPKW.LAB4.Server.Data;
using TPKW.LAB4.Server.Models;

namespace TPKW.LAB4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private MyDbContext db = new MyDbContext();
        private static int id = 0;
        // GET: api/<Students>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return db.Students.ToArray();
        }

        // GET api/<Students>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Students>
        [HttpPost]
        public IActionResult Post([FromBody] StudentDto student)
        {
            Student student1 = new Student(firstName: student.firstName, lastName: student.lastName);
            //list.Add(student1);
            db.Add(student1);
            db.SaveChanges();
            return Ok(student1);
        }

        // PUT api/<Students>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentDto student)
        {
            var temp = db.Students.FirstOrDefault(x => x.Id == id);
            temp.firstName = student.firstName;
            temp.lastName = student.lastName;
            db.SaveChanges();
            return Ok();
        }

        // DELETE api/<Students>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //list.Remove(list.FirstOrDefault(x => x.Id == id));
            db.Remove(db.Students.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return Ok();
        }
    }
}
