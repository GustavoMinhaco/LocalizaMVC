using LocalizaMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoDTO>> GetVeiculos();
        Task<VeiculoDTO> GetById(int? id);

        //Task<VeiculoDTO> GetVeiculoModeloMarca(int? id);

        Task Add(VeiculoDTO veiculoDto);
        Task Update(VeiculoDTO veiculoDto);
    }
}
