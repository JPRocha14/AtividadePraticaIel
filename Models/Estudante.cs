using System;
using System.ComponentModel.DataAnnotations;

namespace IELStudentManager.Models
{
    public class Estudante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inválido. O CPF deve conter apenas números.")]
        public string CPF { get; set; }

        [MaxLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A data de conclusão é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataConclusao { get; set; }
    }
}
