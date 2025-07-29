using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;
        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Movement>> GetAll()
        {
            return Ok(_movementService.GetAll());
        }

        [HttpGet("part/{partId}")]
        public ActionResult<IEnumerable<Movement>> GetByPartId(Guid partId)
        {
            return Ok(_movementService.GetByPartId(partId));
        }


        [HttpPost]

        public IActionResult Create([FromBody] Movement movement)
        {
            try
            {
                _movementService.Create(movement);
                return CreatedAtAction(nameof(GetAll), new { }, movement);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }





    }
}