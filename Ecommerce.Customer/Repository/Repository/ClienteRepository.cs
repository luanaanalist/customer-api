using Domain.DTO;
using Domain.Entities;
using Domain.Repository;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public User ValidaCliente(string email, string senha) 
        {

            var user = _context.Cliente.Where(c => c.Email == email && c.Senha == senha)
                .Select(user => new User() { Email = user.Email, Senha = user.Senha }).SingleOrDefault();

            return user;

        }
    }
}
