using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Cpf é requerido!")]
        [MinLength(11)]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Aniversário é requerido!")]
        [MinLength(5)]
        [MaxLength(10)]
        public string Aniversario { get; set; }

        [Required(ErrorMessage = "O Cep é requerido!")]
        [MinLength(8)]
        [MaxLength(9)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Logradouro é requerido!")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Numero é requerido!")]
        [Range(1, int.MaxValue)]
        public int Numero { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O Cidade é requerido!")]
        [MinLength(3)]
        [MaxLength(120)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é requerido!")]
        [MinLength(2)]
        [MaxLength(120)]
        public string Estado { get; set; }
    }
}
