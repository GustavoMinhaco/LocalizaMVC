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
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDTO>>> Get()
        {
            var marcas = await _marcaService.GetMarcas();
            if (marcas == null)
                return NotFound("Marcas não encontradas!");

            return Ok(marcas);
        }


        [HttpGet("{id:int}", Name = "GetMarca")]

        public async Task<ActionResult<MarcaDTO>> GetById(int id)
        {
            var marca = await _marcaService.GetById(id);
            if (marca == null)
                return NotFound("Marca não encontrada!");

            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MarcaDTO marcaDto)
        {
            if (marcaDto == null)
                return BadRequest("Dados inválidos");

            await _marcaService.Add(marcaDto);
            return new CreatedAtRouteResult("GetMarca", new { id = marcaDto.Id },
                marcaDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] MarcaDTO marcaDto)
        {
            if (id != marcaDto.Id)
                return BadRequest();

            if (marcaDto == null)
                return BadRequest();

            await _marcaService.Update(marcaDto);

            return Ok(marcaDto);
        }
    }
}
