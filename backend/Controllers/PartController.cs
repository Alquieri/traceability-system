using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Dtos;

namespace backend.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PartController : ControllerBase
    { 
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        /// <summary>
        /// Busca todas as peças cadastradas.
        /// </summary>
        /// <returns>Uma lista de peças.</returns>
        /// <response code="200">Retorna a lista de peças.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Part>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var parts = _partService.GetAll();
            return Ok(parts);
        }

        /// <summary>
        /// Busca uma peça específica pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da peça (GUID).</param>
        /// <returns>Os dados da peça encontrada.</returns>
        /// <response code="200">Retorna a peça encontrada.</response>
        /// <response code="404">Se a peça não for encontrada.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Part), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var part = _partService.GetById(id);
            return part == null ? NotFound() : Ok(part);
        }

        /// <summary>
        /// Busca uma peça específica pelo seu nome.
        /// </summary>
        /// <param name="name">O nome da peça.</param>
        /// <returns>Os dados da peça encontrada.</returns>
        /// <response code="200">Retorna a peça encontrada.</response>
        /// <response code="404">Se a peça não for encontrada.</response>
        [HttpGet("name/{name}")]
        [ProducesResponseType(typeof(Part), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByName(string name)
        {
            var part = _partService.GetByName(name);
            return part == null ? NotFound() : Ok(part);
        }

        /// <summary>
        /// Cadastra uma nova peça no sistema.
        /// </summary>
        /// <param name="partDto">Objeto com o nome da nova peça.</param>
        /// <returns>A peça recém-criada.</returns>
        /// <response code="201">Retorna a peça recém-criada.</response>
        /// <response code="400">Se o nome da peça for nulo ou vazio.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Part), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] PartCreateDto partDto)
        {
            if (string.IsNullOrWhiteSpace(partDto.Name))
            {
                return BadRequest("O nome da peça é obrigatório.");
            }
            var newPart = new Part(partDto.Name);
            _partService.Create(newPart);
            return CreatedAtAction(nameof(GetById), new { id = newPart.Id }, newPart);
        }

        /// <summary>
        /// Atualiza os dados de uma peça existente.
        /// </summary>
        /// <param name="id">O ID da peça a ser atualizada.</param>
        /// <param name="part">O objeto da peça com os dados atualizados.</param>
        /// <response code="204">Se a peça foi atualizada com sucesso.</response>
        /// <response code="400">Se o ID da rota não corresponder ao ID do corpo da requisição.</response>
        /// <response code="404">Se a peça a ser atualizada não for encontrada.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, [FromBody] Part part)
        {
            if (id != part.Id)
            {
                return BadRequest("O ID da rota não corresponde ao ID do corpo da requisição.");
            }
            
            if (_partService.GetById(id) == null)
            {
                return NotFound();
            }

            _partService.Update(part);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma peça pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da peça a ser excluída.</param>
        /// <response code="204">Se a peça foi excluída com sucesso.</response>
        /// <response code="404">Se a peça a ser excluída não for encontrada.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            if (_partService.GetById(id) == null)
            {
                return NotFound();
            }

            _partService.Delete(id);
            return NoContent();
        }
    }
}