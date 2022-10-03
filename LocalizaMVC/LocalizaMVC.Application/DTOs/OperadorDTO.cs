using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.DTOs
{
    public class OperadorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Matricula é requerida!")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O Nome é requerido!")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Nome { get; set; }
    }
}
