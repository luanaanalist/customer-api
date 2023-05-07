using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Service.Interfaces;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly  ITokenService _tokenService;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, ITokenService tokenService)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public IEnumerable<ClienteVM> GetAll()
        {
            var cliente = _clienteRepository.GetAll();
            var clienteVM = _mapper.Map<IEnumerable<ClienteVM>>(cliente);
            return clienteVM;
        }

        public string ValidaUsuario(string email, string senha)
        {
            string token = null;
            var user = _clienteRepository.ValidaCliente(email, senha);
            if (user.Email != null) 
            {
                token = _tokenService.CreateToken(user);

            }

            return token;
        }
    }
}
