using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class funcionarios
    {
        [Key]
        public int FuncID { get; set; }

        [Display(Name = "Nome:")]
        public string UserName { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "CPF:")]
        public long CPF { get; set; }

        [Display(Name = "Data de admissão:")]
        [DataType(DataType.Date)]
        public DateTime Entrada { get; set; }

        [Display(Name = "Função:")]
        public string Funcao { get; set; }

        [Display(Name = "Turno:")]
        public string Turno { get; set; }

        [Display(Name = "Salário:")]
        public double Salario { get; set; }
    }
}
