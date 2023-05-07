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
    public class ClienteRepository : BaseRepositoryy<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
