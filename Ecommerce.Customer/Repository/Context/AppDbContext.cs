using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {

        }
        public virtual DbSet<Domain.Entities.Cliente> Cliente { get; set; }
        public virtual DbSet<Domain.Entities.Endereco> Endereco { get; set; }
    }
}
