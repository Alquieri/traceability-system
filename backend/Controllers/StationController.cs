using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Repository;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/station")]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _stationRepository;
        public StationController(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        [HttpGet("{id}")]
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

        [HttpPost]
        public IActionResult Add([FromBody] Station station)
        {
            _stationRepository.Add(station);
            return CreatedAtAction(nameof(GetById), new { id = station.Id }, station);
        }

        // PUT: /api/station/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Station station)
        {
            if (id != station.Id)
                return BadRequest(new { message = "O ID da URL é diferente do corpo da requisição." });

            _stationRepository.Update(station);
            return NoContent();
        }

        [HttpDelete("{id}")]
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
