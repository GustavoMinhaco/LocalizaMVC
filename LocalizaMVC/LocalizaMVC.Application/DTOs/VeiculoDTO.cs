using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Enums;
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
    public class VeiculoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Placa é requerida!")]
        [MinLength(7)]
        [MaxLength(7)]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O Ano é requerido!")]
        [Range(1700, 9999)]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O ValorHora é requerido!")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor Hora")]
        public decimal ValorHora { get; set; }

        [Required(ErrorMessage = "O Combustível é requerido!")]
        public Combustivel Combustivel { get; set; }

        [Required(ErrorMessage = "O Combustível é requerido!")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O LimitePortaMalas é requerido!")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Limite Porta Malas")]
        public decimal LimitePortaMalas { get; set; }

        [DisplayName("Marcas")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }

        [DisplayName("Modelos")]
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
    }
}
