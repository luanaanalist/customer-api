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
       User ValidaCliente(string email, string senha);

       bool CustomerExist(string cpf, string email);

       void EnviarEmail(Cliente cliente);

       Cliente BuscarClienteESeusRelacionamentos(int idCliente);

        void Alterar(Cliente cliente);
        Task<bool> SaveAllAsync();
    }
}
