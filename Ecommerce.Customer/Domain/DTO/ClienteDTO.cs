using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
//teste

    public struct ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Ativo { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
