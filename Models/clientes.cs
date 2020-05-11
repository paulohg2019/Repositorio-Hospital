using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class clientes
    {
        [Key]
        public int  ClienteID { get; set; }

        [Display(Name = "Nome:")]
        public string UserName { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Telefone:")]
        public long PhoneNumber { get; set; }

        [Display(Name = "CPF:")]
        public long CPF { get; set; }

        [Display(Name = "Data de nascimento:")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Convênios:")]
        public string Convenio { get; set; }

        [Display(Name = "Comentario sobre o cliente:")]
        public string Coment { get; set; }
    }
}
