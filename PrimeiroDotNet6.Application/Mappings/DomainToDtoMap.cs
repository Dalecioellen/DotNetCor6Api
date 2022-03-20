using AutoMapper;
using PrimeiroDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Application.Mappings
{
    public class DomainToDtoMap : Profile
    {
        public DomainToDtoMap()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}
