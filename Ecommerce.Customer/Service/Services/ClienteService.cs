using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Service.Interfaces;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public ClienteVM Created(Cliente cliente, string senha ) 
        {

            try
            {
                if (cliente == null)
                    throw new Exception("");

                var validarUsuario = _clienteRepository.CustomerExist(cliente.Cpf, cliente.Email);
                if (validarUsuario)
                     throw new Exception("Usuario já cadastrado");


                if (!ValidacaodeSenha(cliente.Senha, senha))
                    throw new Exception("Senha invalida");

                if (!validaEmail(cliente.Email))
                    throw new Exception("Email Invalido");


                _clienteRepository.Create(cliente);
                SendEmail.Send(cliente.Email); // enviar email para usuario dando boas vindas
                _clienteRepository.CommitTransaction();


                var clienteVM = _mapper.Map<ClienteVM>(cliente);
                return clienteVM;
               
            }
            catch (Exception)
            {
                _clienteRepository.RollbackTransaction();
                throw;
            }

        }

        public bool ValidacaodeSenha(string senhaCliente, string senhaValidacao) 
        {
            if (senhaCliente != senhaValidacao)
                return false;

            if (senhaCliente.Length < 8)
                return false;

            //verifica se existe pelo menos um número
            if (!senhaCliente.Any(c => char.IsDigit(c)))
                return false;

            //verifica se existe alguma letra maiuscula
            if (!senhaCliente.Any(c => char.IsUpper(c)))
                return false;

            //verifica se existe alguma letra minuscula
            if (!senhaCliente.Any(c => char.IsLower(c)))
                return false;

            //verifica se existe algum caracter especial q nao seja letras(maiúscula ou minúscula) e numeros
            if (Regex.IsMatch(senhaCliente, (@"[^a-zA-Z0-9]")))
                return false;
          

            return true;
            //verificar se senha contem 8 caracters se tem caracter especial
            //(^(?=.*[A-Z])(?=.*[!#@$%&])(?=.*[0-9])(?=.*[a-z]).{8,15}$)

        }

        public bool validaEmail(string email) 
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, strModelo))
                return false;

            return true;
      
        }



    }
}
