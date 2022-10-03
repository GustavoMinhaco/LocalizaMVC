using LocalizaMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Entidades
{
    public sealed class Modelo : Entity
    {
        public string Descricao { get; private set; }

        public Modelo(string descricao)
        {
            ValidationDomain(descricao);
        }

        public Modelo(int id, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "Campo obrigatório Id inválido!");
            Id = id;
            ValidationDomain(descricao);
        }

        public void Update(string descricao)
        {
            ValidationDomain(descricao);
        }

        public void ValidationDomain(string descricao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Campo obrigatório descricao inválido!");
            DomainExceptionValidation.When(descricao.Length < 2, "Campo obrigatório descricao inválido, muito curto, mínimo 2 characters");

            Descricao = descricao;
        }


        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
