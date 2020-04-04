﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cw_3.Model;
using System.Text;

namespace cw_3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]

        public string GetStudent()
        {
            List<Student> students = new List<Student>();

            using (var client = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=s16578;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = client;
                com.CommandText = "SELECT s.FirstName AS FirstName, s.LastName AS LastName, s.BirthDate AS BirthDate, st.Name AS Name, e.Semester AS Semester"+
                                  " FROM Enrollment AS e"+
                                  " INNER JOIN Student AS s"+
                                  " ON e.IdEnrollment = s.IdEnrollment"+
                                  " INNER JOIN Studies st"+
                                  " ON e.IdStudy = st.IdStudy";

                client.Open();
                var dataRead = com.ExecuteReader();
                //ArrayList<Student> students = new ArrayList<Student>();

                while (dataRead.Read())
                {
                    var student = new Student();
                    student.FirstName = dataRead["FirstName"].ToString();
                    student.LasteName = dataRead["LastName"].ToString();
                    student.BirthDate = dataRead["BirthDate"].ToString();
                    student.StudyName = dataRead["Name"].ToString();
                    student.Semester = Convert.ToInt32(dataRead["Semester"].ToString());

                    students.Add(student);
                }

                StringBuilder sb = new StringBuilder();
                
                foreach(Student s in students)
                {
                    sb.Append("name:"+s.FirstName +
                              " last name:" + s.LasteName +
                              " birth date: " + s.BirthDate +
                              " study name:" + s.StudyName +
                              " semester:" + s.Semester);
                    sb.AppendLine();
                }
                
                return sb.ToString();

            }

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
         // student.IndexNumber = $"s{new Random().Next(1, 1000)}";
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