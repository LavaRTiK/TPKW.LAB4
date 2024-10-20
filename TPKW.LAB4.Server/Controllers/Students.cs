﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPKW.LAB4.Server.Models;

namespace TPKW.LAB4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        public static List<Student> list = new List<Student>();
        private static int id = 0;
        // GET: api/<Students>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return list.ToArray();
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
            list.Add(student1);
            return Ok(student1);
        }

        // PUT api/<Students>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentDto student)
        {
            var temp = list.FirstOrDefault(x => x.Id == id);
            temp.firstName = student.firstName;
            temp.lastName = student.lastName;
        }

        // DELETE api/<Students>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            list.Remove(list.FirstOrDefault(x => x.Id == id));
        }
    }
}
