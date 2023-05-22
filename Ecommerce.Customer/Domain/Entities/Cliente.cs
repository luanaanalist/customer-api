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
    [Table("Cliente")] 
    public class Cliente: BaseEntity
    {
        [Key]
        [Column("Id")]
        public override int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        public DateTime Data_Nascimento { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }


        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }


        [Required]
        [MaxLength(50)]
        public string Ativo { get; set; }   

        public virtual ICollection<Endereco> Enderecos { get; set; }


    }
}
