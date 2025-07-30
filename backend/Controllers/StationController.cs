using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Repository;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/station")]
    [Produces("application/json")]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;
        public StationController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Busca todas as estações de processo cadastradas.
        /// </summary>
        /// <returns>Uma lista de estações.</returns>
        /// <response code="200">Retorna a lista de estações.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Station>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Station>> GetAll()
        {
            var stations = _stationRepository.GetAll();
            return Ok(stations);
        }

        /// <summary>
        /// Busca uma estação específica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da estação (GUID).</param>
        /// <returns>Os dados da estação encontrada.</returns>
        /// <response code="200">Retorna a estação encontrada.</response>
        /// <response code="404">Se a estação não for encontrada.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Station), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public ActionResult<Station> GetById(Guid id)
        {
            try
            {
                var station = _stationRepository.GetById(id);
                return Ok(station);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cadastra uma nova estação de processo.
        /// </summary>
        /// <param name="station">Objeto com os dados da nova estação.</param>
        /// <returns>A estação recém-criada.</returns>
        /// <response code="201">Retorna a estação recém-criada.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Station), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] Station station)
        {
        
            if (station == null || string.IsNullOrWhiteSpace(station.Name))
            {
                return BadRequest("Os dados da estação são inválidos.");
            }
            _stationRepository.Add(station);
            return CreatedAtAction(nameof(GetById), new { id = station.Id }, station);
        }

        /// <summary>
        /// Atualiza os dados de uma estação existente.
        /// </summary>
        /// <param name="id">O ID da estação a ser atualizada.</param>
        /// <param name="station">O objeto da estação com os dados atualizados.</param>
        /// <response code="204">Se a estação foi atualizada com sucesso.</response>
        /// <response code="400">Se o ID da rota não corresponder ao ID do corpo da requisição.</response>
        /// <response code="404">Se a estação a ser atualizada não for encontrada.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, [FromBody] Station station)
        {
            if (id != station.Id)
                return BadRequest(new { message = "O ID da URL é diferente do corpo da requisição." });

 
            try
            {
                _stationRepository.GetById(id); 
            }
            catch (Exception)
            {
                return NotFound();
            }

            _stationRepository.Update(station);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma estação pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da estação a ser excluída.</param>
        /// <response code="204">Se a estação foi excluída com sucesso.</response>
        /// <response code="404">Se a estação a ser excluída não for encontrada.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _stationRepository.Delete(id); 
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}