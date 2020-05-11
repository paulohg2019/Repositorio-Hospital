using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class exames
    {
        [Key]
        public int ExameID { get; set; }

        [Display(Name = "Nome do Paciente:")]
        public string NomePaciente { get; set; }

        [Display(Name = "Nome do Exame:")]
        public string ExameName { get; set; }

        [Display(Name = "Nome do Medico:")]
        public string NomeMedico { get; set; }
      
        [Display(Name = "Data da consulta:")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Hora da consulta:")]
        public int Hora { get; set; }
    }
}
