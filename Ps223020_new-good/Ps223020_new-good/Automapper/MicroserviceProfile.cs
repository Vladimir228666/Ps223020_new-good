using AutoMapper;
using Ps223020_new_good.BusinesLogic.Core.Models;
using Ps223020_new_good.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ps223020_new_good.Automapper
{
    public class MicroserviceProfile : Profile
    {
        public MicroserviceProfile()
        {
            CreateMap<UserInformationBlo, UserInformationDto>();
            CreateMap<UserUpdateBlo, UserUpdateDto>();
        }
    }
}
