using LocalizaMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Entidades
{
    public sealed class Operador : Entity
    {
        public string Matricula { get; private set; }
        public string Nome { get; private set; }

        public Operador(string matricula, string nome)
        {
            ValidationDomain(matricula, nome);
        }

        public void Update(string matricula, string nome)
        {
            ValidationDomain(matricula, nome);
        }

        private void ValidationDomain(string matricula, string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(matricula), "Campo obrigatório Matricula inválido");
            DomainExceptionValidation.When(matricula.Length < 3, "Campo obrigatório Matricula inválido, muito curto, minimo 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Campo obrigatório Nome inválido");
            DomainExceptionValidation.When(nome.Length < 3, "Campo obrigatório Nome inválido, muito curto, minimo 3 characters");

            Matricula = matricula;
            Nome = nome;
        }

        public ICollection<Locacao> Locacoes { get; set; }
    }
}
