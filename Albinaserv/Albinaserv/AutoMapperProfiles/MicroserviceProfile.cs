using Albina.BuisnessLogic.Core.Models;
using Albina.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albinaserv.AutoMapperProfiles
{
    public class MicroserviceProfile : Profile 
    {
        public  MicroserviceProfile()
        {
            CreateMap<UserInformationBlo, UserInformationBlo>();
            CreateMap<UserIdentityDto, UserIdentityDto>();
            CreateMap<UserIdentityDto, UserIndentityBlo>();
            CreateMap<UserUpdateDto, UserUpdateBlo>();
            CreateMap<UserUpdateBlo, UserUpdateDto>();
        }
    }
}
