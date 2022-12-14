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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            var usuariosEntity = await _usuarioRepository.GetUsuariosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuariosEntity);
        }

        public async Task<UsuarioDTO> GetById(int? id)
        {
            var usuarioEntity = await _usuarioRepository.GetByIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task Add(UsuarioDTO usuarioDto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.CreateAsync(usuarioEntity);
        }

        public async Task Update(UsuarioDTO usuarioDto)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.UpdateAsync(usuarioEntity);
        }

        public async Task Remove(int? id)
        {
            var usuarioEntity = _usuarioRepository.GetByIdAsync(id).Result;
            await _usuarioRepository.RemoveAsync(usuarioEntity);
        }
    }
}
