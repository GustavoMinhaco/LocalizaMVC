using AutoMapper;
using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Locacao, LocacaoDTO>().ReverseMap();
            
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Modelo, ModeloDTO>().ReverseMap();
            
            CreateMap<Operador, OperadorDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
        }
    }
}
