using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

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
        public IActionResult Create([FromBody] Part part)
        {
            try
            {
                _partService.Create(part);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Part part)
        {
            _partService.Update(part);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _partService.Delete(id);
            return Ok();
        }
    


    }
}