using CondominioDevAPI.DTOs;
using CondominioDevAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CondominioDevAPI.Controllers
{
    [ApiController]
    [Route("api/habitantes")]
    public class HabitanteController : ControllerBase
    {
        private readonly HabitanteAppService _habitanteAppService;

        public HabitanteController(HabitanteAppService habitanteAppService)
        {
            _habitanteAppService = habitanteAppService;
        }

        /// <summary>
        /// Cadastra um novo habitante
        /// </summary>
        /// <returns>Cadastra um novo habitante</returns>
        /// <response code="201">Habitante criado</response>
        /// <response code="400">Já há um habitante com este CPF</response>
        /// <param name="habitante"></param>
        /// <returns></returns>
        [HttpPost("cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHabitante([FromBody] HabitantePostDTO habitante)
        {
            var created = _habitanteAppService.Add(habitante);
            if (created) return StatusCode(201, habitante);
            else return StatusCode(400, "Já há um habitante com este CPF");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var habitantes = _habitanteAppService.GetAll();
            return Ok(habitantes);
        }

        /// <summary>
        /// Retorna uma lista de habitantes que contenham o nome informado, se não, retorna o status code 404
        /// </summary>
        /// 
        /// <param name="nome"></param>
        /// <returns>Retorna uma lista de habitantes que contenham o nome informado</returns>
        /// <response code="200">Retorna a lista de habitantes filtrados pelo nome</response>
        /// <response code="404">Não encontrou resultado</response>
        [HttpGet]
        [Route("buscar/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByName([FromRoute] string nome)
        {
            var habitantes = _habitanteAppService.GetByName(nome);
            if (habitantes == null || habitantes.Count() == 0) return NotFound();
            return Ok(habitantes);
        }

        [HttpGet]
        [Route("buscar/mes/{mes}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByMonth([FromRoute] int mes)
        {
            var habitantes = _habitanteAppService.GetByMonth(mes);
            if (habitantes == null || habitantes.Count() == 0) return NotFound();
            return Ok(habitantes);
        }

        [HttpGet]
        [Route("buscar/idade/{idade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByAgeBiggerThan([FromRoute] int idade)
        {
            var habitantes = _habitanteAppService.GetByAgeBiggerThan(idade);
            if (habitantes == null || habitantes.Count() == 0) return NotFound();
            return Ok(habitantes);
        }

        [HttpGet]
        [Route("detalhes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDetailsById([FromRoute] int id)
        {
            var habitante = _habitanteAppService.GetDetailsById(id);
            if (habitante == null) return NotFound();
            return Ok(habitante);
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var deleted = _habitanteAppService.Delete(id);
            if (deleted) return Ok();
            else return NotFound();
        }
    }
}
