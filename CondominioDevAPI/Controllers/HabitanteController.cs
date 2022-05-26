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
        public IActionResult CadastrarHabitante(HabitantePostDTO habitante)
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
    }
}
