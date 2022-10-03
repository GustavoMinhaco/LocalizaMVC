using LocalizaMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Interfaces
{
    public interface IOperadorService
    {
        Task<IEnumerable<OperadorDTO>> GetOperadores();
        Task<OperadorDTO> GetById(int? id);

        Task Add(OperadorDTO operadorDto);
        Task Update(OperadorDTO operadorDto);
    }
}
