using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Endereco")]
    public class Endereco: BaseEntity 
    {
        [Key]
        public override int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Rua { get; set; }

        [Required]
        [MaxLength(20)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(200)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(200)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(100)]
        public string Uf { get; set; }

        [Required]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome_Endereco { get; set; }
       
        public int Id_Cliente { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }
     

    }
    
}
