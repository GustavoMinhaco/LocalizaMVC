using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Interfaces
{
    public interface ILocacaoRepository
    {
        Task<IEnumerable<Locacao>> GetLocacoesAsync();
        Task<Locacao> GetByIdAsync(int? id);
        //Task<Locacao> GetAllAsync(int? id);

        Task<Locacao> CreateAsync(Locacao locacao);
        Task<Locacao> UpdateAsync(Locacao locacao);
    }
}
