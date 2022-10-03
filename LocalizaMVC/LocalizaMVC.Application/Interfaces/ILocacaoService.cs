using LocalizaMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Interfaces
{
    public  interface ILocacaoService
    {
        Task<IEnumerable<LocacaoDTO>> GetLocacoes();
        Task<LocacaoDTO> GetById(int? id);
        //Task<LocacaoDTO> GetAll(int? id);

        Task Add(LocacaoDTO locacaoDto);
        Task Update(LocacaoDTO locacaoDto);
    }
}
