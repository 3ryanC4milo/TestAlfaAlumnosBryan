using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAlumnos.Models;

namespace WebAPIAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudents _student;
        private readonly IStudentSchoolShipRequest _request;

        public StudentsController(IStudents student, IStudentSchoolShipRequest request)
        {
            _student = student;
            _request = request;
        }

        //Get All students
        [HttpGet]
        [Route("getAllStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var lista = await _student.GetAll();
            return Ok(lista);
        }
        //Get student by id
        [HttpGet("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(200, Type = typeof(Domain.Model.StudentDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var obj = await _student.GetById(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        //Add Student
        [HttpPost]
        [Route("insertRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] StudentSchRequestVM student)
        {
            if (student == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var studentObj = new Domain.Model.StudentDTO
            {
                Name = student.Name,
                Gender = student.Gender,
                Age = student.Age
            };

            var newStudent = await _student.AddStudent(studentObj);

            if (newStudent.Equals("Success"))
            {
                var newRequest = await _request.AddRequest(new Domain.Model.StudentScholShipRequestDTO
                {
                    StudentID = studentObj.StudentID,
                    Request = student.Request,
                    Culture = student.Culture,
                    Educational = student.Educational,
                    Sports = student.Sports,
                    ScholarShipID = student.ScholarShipID,
                });
                if (newStudent.Equals("Success"))                
                    return CreatedAtRoute("GetStudentById", new { id = student.StudentID }, studentObj);
            }
            return BadRequest();
        }
        //Update Student
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(202)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] StudentSchRequestVM student)
        {
            //This code block would be in business section or layer (Depending of architecture)
            if (id != student.StudentID)
            {
                return BadRequest(ModelState);
            }

            //This code block would be in repository section or layer (Depending of architecture)
            var studentObj = new Domain.Model.StudentDTO
            {
                StudentID = id,
                Name = student.Name,
                Gender = student.Gender,
                Age = student.Age
            };
            var update = await _student.UpdateStudent(studentObj);
            if (update.Equals("Updated")) 
                return CreatedAtRoute("GetStudentById", new { id = student.StudentID }, studentObj);

            return BadRequest();
        }

        //Remove Student
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var msgDelete = await _student.RemoveStudent(id);
            if (msgDelete.Equals("Removed"))
            {
                var requestDeletes = await _request.RemoveRequestbyStudent(id);
                if (requestDeletes.Equals("Removed"))
                {
                    return Ok(requestDeletes);
                }
            }
            return BadRequest();
        }

        //Get Report 
        [HttpGet]
        [Route("getReportStudents")]
        public async Task<IActionResult> GetReportStudents([FromQuery] int idSchoolship = 0)
        {


            var lista = await _student.GetAll();
            var solicitudes = await _request.GetAll();

            var resultado = new List<StudentReports>();



            foreach(var alumno in lista)
            {
                var reporte = new StudentReports();
                if(solicitudes.Where(x=> x.StudentID == alumno.StudentID).Any())
                {
                    foreach (var p in solicitudes.Where(x => x.StudentID == alumno.StudentID))
                    {
                        reporte.Culture = p.Culture == true ? true : false;
                        reporte.Sports = p.Sports == true ? true : false;
                        reporte.Educational = p.Educational == true ? true : false;
                    }
                    reporte.StudentID = alumno.StudentID;
                    reporte.Name = alumno.Name;
                    reporte.Gender = alumno.Gender == true ? "H" : "M";
                    reporte.Age = alumno.Age;

                    resultado.Add(reporte);
                }                
            }
            
            return Ok(resultado);
        }
    }
}
