using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> GetVeiculosAsync();
        Task<Veiculo> GetByIdAsync(int? id);

        //Task<Veiculo> GetVeiculoModeloMarcaAsync(int? id);

        Task<Veiculo> CreateAsync(Veiculo veiculo);
        Task<Veiculo> UpdateAsync(Veiculo veiculo);
    }
}
