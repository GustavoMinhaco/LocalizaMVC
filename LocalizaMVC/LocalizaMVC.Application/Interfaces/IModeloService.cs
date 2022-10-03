using LocalizaMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<ModeloDTO>> GetModelos();
        Task<ModeloDTO> GetById(int? id);

        Task Add(ModeloDTO modeloDto);
        Task Update(ModeloDTO modeloDto);
    }
}
