using AutoMapper;
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

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClienteVM> GetAll()
        {
            var cliente = _clienteRepository.GetAll();
            var clienteVM = _mapper.Map<IEnumerable<ClienteVM>>(cliente);
            return clienteVM;
        }
    }
}
