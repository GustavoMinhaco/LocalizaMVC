using AutoMapper;
using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Application.Interfaces;
using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Services
{
    public class ModeloService : IModeloService
    {

        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;

        public ModeloService(IModeloRepository modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ModeloDTO>> GetModelos()
        {
            var modelosEntity = await _modeloRepository.GetModelosAsync();
            return _mapper.Map<IEnumerable<ModeloDTO>>(modelosEntity);
        }

        public async Task<ModeloDTO> GetById(int? id)
        {
            var modeloEntity = await _modeloRepository.GetByIdAsync(id);
            return _mapper.Map<ModeloDTO>(modeloEntity);
        }

        public async Task Add(ModeloDTO modeloDto)
        {
            var modeloEntity = _mapper.Map<Modelo>(modeloDto);
            await _modeloRepository.CreateAsync(modeloEntity);
        }

        public async Task Update(ModeloDTO modeloDto)
        {
            var modeloEntity = _mapper.Map<Modelo>(modeloDto);
            await _modeloRepository.UpdateAsync(modeloEntity);
        }
    }
}
