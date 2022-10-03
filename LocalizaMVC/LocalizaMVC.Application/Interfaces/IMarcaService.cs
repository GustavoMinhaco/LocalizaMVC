using LocalizaMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDTO>> GetMarcas();
        Task<MarcaDTO> GetById(int? id);

        Task Add(MarcaDTO marcaDTO);
        Task Update(MarcaDTO marcaDTO);
    }
}
