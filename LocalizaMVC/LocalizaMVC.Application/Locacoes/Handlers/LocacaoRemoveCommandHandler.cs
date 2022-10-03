using LocalizaMVC.Application.Locacoes.Commands;
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
    public class LocacaoRemoveCommandHandler : IRequestHandler<LocacaoRemoveCommand, Locacao>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoRemoveCommandHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public Task<Locacao> Handle(LocacaoRemoveCommand request, CancellationToken cancellationToken)
        {
            var locacao = _locacaoRepository.GetByIdAsync(request.Id);

            if (locacao == null)
            {
                throw new ApplicationException("Erro ao localizar entidade");
            }
            else
            {
                var result = locacao; //await _locacaoRepository.RemoveAsync(locacao);
                return result;
            }
        }
    }
}
