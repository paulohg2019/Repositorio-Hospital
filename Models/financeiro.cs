using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class financeiro
    {
        [Key]
        public int FinancID { get; set; }

        [Display(Name = "Nome do paciente:")]
        public string UserName { get; set; }

        [Display(Name = "Nome do médico:")]
        public string Medico { get; set; }

        [Display(Name = "Valor da consulta:")]
        public double valor { get; set; }

        [Display(Name = "Data da consulta:")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Convênios:")]
        public string Convenio { get; set; }

        [Display(Name = "Desconto:")]
        public int Desconto { get; set; }
    }
}
