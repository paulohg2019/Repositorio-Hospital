using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class convenios
    {
        [Key]
       public int ConvID { get; set; }

        [Display(Name = "Empresa:")]
        public string Empresa { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Telefone:")]
        public long PhoneNumber { get; set; }

        [Display(Name = "CNPJ:")]
        public long CNPJ { get; set; }

        [Display(Name = "Valor de desconto:")]
        public int desconto { get; set; }
    }
}
