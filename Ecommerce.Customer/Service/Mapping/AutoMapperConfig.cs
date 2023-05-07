using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<ClienteDTO, ClienteVM>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<ClienteVM, Cliente>().ReverseMap();
            //CreateMap<ClienteVM, ClienteDTO>().ReverseMap();

        }
    }
}
