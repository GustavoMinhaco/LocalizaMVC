using LocalizaMVC.Application.Locacoes.Queries;
using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Locacoes.Handlers
{
    public class GetLocacoesQueryHandler : IRequestHandler<GetLocacoesQuery, IEnumerable<Locacao>>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public GetLocacoesQueryHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<IEnumerable<Locacao>> Handle(GetLocacoesQuery request, CancellationToken cancellationToken)
        {
            return await _locacaoRepository.GetLocacoesAsync();
        }
    }
}
