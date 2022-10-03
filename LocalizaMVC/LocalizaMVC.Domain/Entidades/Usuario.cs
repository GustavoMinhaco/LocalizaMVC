using LocalizaMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Entidades
{
    public sealed class Usuario: Entity
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }


        public Usuario(string login, string senha)
        {
            ValidationDomain(login, senha);
        }

        public Usuario(int id, string login, string senha)
        {
            DomainExceptionValidation.When(id < 0, "Campo obrigatório Id inválido!");
            Id = id;
            ValidationDomain(login, senha);
        }

        public void Update(string login, string senha)
        {
            ValidationDomain(login, senha);
        }

        public void ValidationDomain(string login, string senha)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(login), "Campo obrigatório Login inválido!");
            DomainExceptionValidation.When(login.Length < 3, "Campo obrigatório Login inválido, muito curto, mínimo 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "Campo obrigatório Senha inválido!");
            DomainExceptionValidation.When(senha.Length < 4, "Campo obrigatório Senha inválido, muito curto, mínimo 4 characters");

            Login = login;
            Senha = Validacao.CalculaHash(senha);
        }
    }
}
