using Microsoft.AspNetCore.Mvc;
using Repositories.Entities;
using Services.DTOs;
using Services.Implementation;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpPost("/create-student")]
        public async Task<IActionResult> Create(StudentCreateDTO student)
        {
            return Ok(await _service.AddStudent(student));
        }

        [HttpGet("/students")]
        public IActionResult GetAll()
        {
            return Ok(_service.Students());
        }
    }
}
