using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.DTOs
{
    public class MarcaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Descricao é requerido!")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
