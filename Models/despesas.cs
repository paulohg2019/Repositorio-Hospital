using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class despesas
    {

        [Key]
        public int DespID { get; set; }

        [Display(Name = "Funcionario:")]
        public string UserName { get; set; }

        [Display(Name = "Aluguel:")]
        public double Aluguel { get; set; }

        [Display(Name = "Água:")]
        public double Agua { get; set; }

        [Display(Name = "Luz:")]
        public double Luz { get; set; }

        [Display(Name = "Telefone:")]
        public double Telefone { get; set; }

        [Display(Name = "Internet:")]
        public double Internet { get; set; }

        [Display(Name = "Pagamentos:")]
        public double Pagamentos { get; set; }

        [Display(Name = "Materiais:")]
        public double Materiais { get; set; }

        [Display(Name = "Data:")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
