using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}