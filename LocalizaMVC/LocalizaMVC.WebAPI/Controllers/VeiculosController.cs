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
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get()
        {
            var veiculos = await _veiculoService.GetVeiculos();
            if (veiculos == null)
                return NotFound("Veiculos não encontrados!");

            return Ok(veiculos);
        }


        [HttpGet("{id:int}", Name = "GetVeiculo")]

        public async Task<ActionResult<VeiculoDTO>> GetById(int id)
        {
            var veiculo = await _veiculoService.GetById(id);
            if (veiculo == null)
                return NotFound("Veiculo não encontrado!");

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VeiculoDTO veiculoDto)
        {
            if (veiculoDto == null)
                return BadRequest("Dados inválidos");

            await _veiculoService.Add(veiculoDto);
            return new CreatedAtRouteResult("GetVeiculo", new { id = veiculoDto.Id },
                veiculoDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] VeiculoDTO veiculoDto)
        {
            if (id != veiculoDto.Id)
                return BadRequest();

            if (veiculoDto == null)
                return BadRequest();

            await _veiculoService.Update(veiculoDto);

            return Ok(veiculoDto);
        }
    }
}
