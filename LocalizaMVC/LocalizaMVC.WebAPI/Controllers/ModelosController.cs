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
    public class ModelosController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        public ModelosController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloDTO>>> Get()
        {
            var modelos = await _modeloService.GetModelos();
            if (modelos == null)
                return NotFound("Modelos não encontrados!");

            return Ok(modelos);
        }


        [HttpGet("{id:int}", Name = "GetModelo")]

        public async Task<ActionResult<ModeloDTO>> GetById(int id)
        {
            var modelo = await _modeloService.GetById(id);
            if (modelo == null)
                return NotFound("Modelo não encontrado!");

            return Ok(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ModeloDTO modeloDto)
        {
            if (modeloDto == null)
                return BadRequest("Dados inválidos");

            await _modeloService.Add(modeloDto);
            return new CreatedAtRouteResult("GetModelo", new { id = modeloDto.Id },
                modeloDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ModeloDTO modeloDto)
        {
            if (id != modeloDto.Id)
                return BadRequest();

            if (modeloDto == null)
                return BadRequest();

            await _modeloService.Update(modeloDto);

            return Ok(modeloDto);
        }
    }
}
