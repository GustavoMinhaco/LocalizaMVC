using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.DTOs
{
    public class LocacaoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O TotalHoras é requerido!")]
        [Range(0, int.MaxValue)]
        public int TotalHoras { get; set; }

        [Required(ErrorMessage = "O ValorTotal é requerido!")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 9999999999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }


        [DisplayName("Veiculos")]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        [DisplayName("Clientes")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [DisplayName("Operadores")]
        public int OperadorId { get; set; }
        public Operador Operador { get; set; }

    }
}
