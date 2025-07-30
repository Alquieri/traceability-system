using backend.Models;
using backend.Repository;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MovementController : ControllerBase
    {
        private readonly IMovementService _movementService;
        private readonly IStationRepository _stationRepository;
        public MovementController(IMovementService movementService, IStationRepository stationRepository)
        {
            _movementService = movementService;
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Busca todos os registros de movimentação do sistema.
        /// </summary>
        /// <returns>Uma lista de todas as movimentações.</returns>
        /// <response code="200">Retorna a lista de movimentações.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movement>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Movement>> GetAll()
        {
            return Ok(_movementService.GetAll());
        }

        /// <summary>
        /// Registra uma nova movimentação de peça para uma estação.
        /// </summary>
        /// <param name="movement">Objeto com os dados da movimentação (PartId, DestinationStationId, Responsible).</param>
        /// <returns>O registro da movimentação criada.</returns>
        /// <response code="201">Retorna a movimentação recém-criada.</response>
        /// <response code="400">Se a movimentação for inválida (ex: fora de ordem, peça finalizada).</response>
        [HttpPost]
        [ProducesResponseType(typeof(Movement), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Busca o histórico completo de movimentações para uma peça específica.
        /// </summary>
        /// <param name="partId">O ID da peça (GUID).</param>
        /// <returns>Uma lista ordenada do histórico de movimentações da peça.</returns>
        /// <response code="200">Retorna o histórico da peça.</response>
        [HttpGet("part/{partId}")]
        [ProducesResponseType(typeof(IEnumerable<object>), StatusCodes.Status200OK)]
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