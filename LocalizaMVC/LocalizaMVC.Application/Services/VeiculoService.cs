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
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoDTO>> GetVeiculos()
        {
            var veiculosEntity = await _veiculoRepository.GetVeiculosAsync();
            return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculosEntity);
        }

        public async Task<VeiculoDTO> GetById(int? id)
        {
            var veiculoEntity = await _veiculoRepository.GetByIdAsync(id);
            return _mapper.Map<VeiculoDTO>(veiculoEntity);
        }

        //public async Task<VeiculoDTO> GetVeiculoModeloMarca(int? id)
        //{
        //    var veiculoEntity = await _veiculoRepository.GetVeiculoModeloMarcaAsync(id);
        //    return _mapper.Map<VeiculoDTO>(veiculoEntity);
        //}

        public async Task Add(VeiculoDTO veiculoDto)
        {
            var veiculoEntity = _mapper.Map<Veiculo>(veiculoDto);
            await _veiculoRepository.CreateAsync(veiculoEntity);
        }

        public async Task Update(VeiculoDTO veiculoDto)
        {
            var veiculoEntity = _mapper.Map<Veiculo>(veiculoDto);
            await _veiculoRepository.UpdateAsync(veiculoEntity);
        }
    }
}
