using Domain.Entities;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<ClienteVM> GetAll();
        String ValidaUsuario(string email, string senha);
    }
        
}
