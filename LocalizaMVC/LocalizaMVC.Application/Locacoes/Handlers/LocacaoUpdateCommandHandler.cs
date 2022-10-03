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
    public class LocacaoUpdateCommandHandler : IRequestHandler<LocacaoUpdateCommand, Locacao>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoUpdateCommandHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<Locacao> Handle(LocacaoUpdateCommand request, CancellationToken cancellationToken)
        {
            var locacao = await _locacaoRepository.GetByIdAsync(request.Id);

            if (locacao == null)
            {
                throw new ApplicationException("Erro ao localizar entidade");
            }
            else
            {
                locacao.Update(request.TotalHoras, request.VeiculoId, request.ClienteId, request.OperadorId);
                return await _locacaoRepository.UpdateAsync(locacao);
            }
        }
    }
}
