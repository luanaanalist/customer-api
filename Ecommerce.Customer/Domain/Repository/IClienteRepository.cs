using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IClienteRepository: ICommonRepository<Cliente>
    {
        public User ValidaCliente(string email, string senha);

        public bool CustomerExist(string cpf, string email);
    }
}
