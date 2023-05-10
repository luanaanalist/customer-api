using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string CreateToken2(User user);

        String Sign(string email, string senha);
    }
}
