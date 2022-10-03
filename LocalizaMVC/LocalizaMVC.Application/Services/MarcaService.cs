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
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMapper _mapper;

        public MarcaService(IMarcaRepository marcaRepository, IMapper mapper)
        {
            _marcaRepository = marcaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MarcaDTO>> GetMarcas()
        {
            var marcasEntity = await _marcaRepository.GetMarcasAsync();
            return _mapper.Map<IEnumerable<MarcaDTO>>(marcasEntity);
        }

        public async Task<MarcaDTO> GetById(int? id)
        {
            var marcaEntity = await _marcaRepository.GetByIdAsync(id);
            return _mapper.Map<MarcaDTO>(marcaEntity);
        }

        public async Task Add(MarcaDTO marcaDTO)
        {
            var marcaEntity = _mapper.Map<Marca>(marcaDTO);
            await _marcaRepository.CreateAsync(marcaEntity);
        }

        public async Task Update(MarcaDTO marcaDTO)
        {
            var marcaEntity = _mapper.Map<Marca>(marcaDTO);
            await _marcaRepository.UpdateAsync(marcaEntity);
        }
    }
}
