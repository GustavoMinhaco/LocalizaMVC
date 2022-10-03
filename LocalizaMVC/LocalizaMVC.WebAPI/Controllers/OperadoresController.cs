using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizaMVC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadoresController : ControllerBase
    {
        private readonly IOperadorService _operadorService;
        public OperadoresController(IOperadorService operadorService)
        {
            _operadorService = operadorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperadorDTO>>> Get()
        {
            var operadores = await _operadorService.GetOperadores();
            if (operadores == null)
                return NotFound("Operadores não encontrados!");

            return Ok(operadores);
        }


        [HttpGet("{id:int}", Name = "GetOperador")]

        public async Task<ActionResult<OperadorDTO>> GetById(int id)
        {
            var operador = await _operadorService.GetById(id);
            if (operador == null)
                return NotFound("Operador não encontrado!");

            return Ok(operador);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OperadorDTO operadorDto)
        {
            if (operadorDto == null)
                return BadRequest("Dados inválidos");

            await _operadorService.Add(operadorDto);
            return new CreatedAtRouteResult("GetOperador", new { id = operadorDto.Id },
                operadorDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] OperadorDTO operadorDto)
        {
            if (id != operadorDto.Id)
                return BadRequest();

            if (operadorDto == null)
                return BadRequest();

            await _operadorService.Update(operadorDto);

            return Ok(operadorDto);
        }
    }
}
