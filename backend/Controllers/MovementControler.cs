
using backend.Models;
using backend.Repository;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;
        private readonly IStationRepository _stationRepository;
        public MovementController(IMovementService movementService, IStationRepository stationRepository)
        {
            _movementService = movementService;
            _stationRepository = stationRepository;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Movement>> GetAll()
        {
            return Ok(_movementService.GetAll());
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

        [HttpGet("part/{partId}")]
        public IActionResult GetByPartId(Guid partId)
        {
            var movements = _movementService.GetByPartId(partId);
            
            var stations = _stationRepository.GetAll().ToDictionary(s => s.Id);

 
            var historyResponse = movements.Select(m => new {
                m.Timestamp,
                OriginStationName = m.OriginStationId.HasValue ? stations[m.OriginStationId.Value].Name : null,
                DestinationStationName = stations.ContainsKey(m.DestinationStationId) ? stations[m.DestinationStationId].Name : "Estação Desconhecida",
                m.Responsible
            }).OrderBy(m => m.Timestamp);

            return Ok(historyResponse);
        }





    }
}