using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Dtos;

namespace backend.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartController : ControllerBase
    { 
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var parts = _partService.GetAll();
            return Ok(parts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var part = _partService.GetById(id);
            return part == null ? NotFound() : Ok(part);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var part = _partService.GetByName(name);
            return part == null ? NotFound() : Ok(part);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PartCreateDto partDto)
        {
            // The part name is required.
            if (string.IsNullOrWhiteSpace(partDto.Name))
            {
                return BadRequest("Part name is required.");
            }

            var newPart = new Part(partDto.Name);

            _partService.Create(newPart);

            return CreatedAtAction(nameof(GetById), new { id = newPart.Id }, newPart);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Part part)
        {
            // The route ID does not match the request body ID.
            if (id != part.Id)
            {
                return BadRequest("Route ID does not match request body ID.");
            }

            _partService.Update(part);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _partService.Delete(id);

            return NoContent();
        }
    }
}