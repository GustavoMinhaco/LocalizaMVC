using AutoMapper;
using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Application.Locacoes.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<LocacaoDTO, LocacaoCreateCommand>();
            CreateMap<LocacaoDTO, LocacaoUpdateCommand>();
        }
    }
}
