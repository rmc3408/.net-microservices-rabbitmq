using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.Models
{
    [Table("client")]
    public class ClientModel
    {
        [Display(Name = "Client ID")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Required Please")]
        [DataType(DataType.Text, ErrorMessage = "Campo vazio")]
        public string? Name { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Please required")]
        [DataType(DataType.Text, ErrorMessage = "Campo vazio")]
        public string? Sin { get; set; }

        [Display(Name = "idade")]
        public int Age { get; set; }

        public ClientModel() 
        { 
            Id = 0;
        }

    }
}
