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
    public class GetLocacaoByIdQueryHandler : IRequestHandler<GetLocacaoByIdQuery, Locacao>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public GetLocacaoByIdQueryHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<Locacao> Handle(GetLocacaoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _locacaoRepository.GetByIdAsync(request.Id);
        }
    }
}
