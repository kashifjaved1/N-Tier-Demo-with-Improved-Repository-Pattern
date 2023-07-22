using Microsoft.AspNetCore.Mvc;
using Repositories.Entities;
using Services.DTOs;
using Services.Implementation;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly ClassroomService _service;

        public ClassroomController(ClassroomService service)
        {
            _service = service;
        }

        [HttpPost("/create-classroom")]
        public async Task<IActionResult> Create(ClassroomCreateDTO classroom)
        {
            return Ok(await _service.AddClassroom(classroom));
        }

        [HttpGet("/classrooms")]
        public IActionResult GetAll()
        {
            return Ok(_service.Classrooms());
        }
    }
}
