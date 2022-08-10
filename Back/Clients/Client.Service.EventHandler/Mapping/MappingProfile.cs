using AutoMapper;
using Client.Domain;
using Client.Service.EventHandler.Command;
using Client.Service.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service.EventHandler.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientTbl, ClientDto>().ReverseMap();
            CreateMap<ClientTbl, ClientCreateCommand>().ReverseMap();
            CreateMap<ClientTbl, ClientUpdateCommand>().ReverseMap();
        }
    }
}
