using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Login é requerido!")]
        [MinLength(3)]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é requerida!")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Senha { get; set; }
    }
}
