using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw_3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw_3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]

        public string GetStudent()
        {
            return "kamikaze";
        }

        [HttpGet("{id}")]

        public IActionResult GetStudents(int id)
    {
            if (id == 1)
                return Ok("kowalski");
            else if (id == 2)
                return Ok("malczewski");
            return NotFound("missing student");
        
    }
        [HttpPost]

        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 1000)}";
            return Ok(student);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteStudent(int id)
        {
            return Ok($"Student with {id} index has been removed");
        }

        [HttpPut("{id}")]

        public IActionResult InserStudent(int id)
        {
            return Ok($"Student with {id} idenx has been added");
        }

    }
}