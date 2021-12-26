using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ps223020_new_good.DataAcess.Core.Interfaces.DbContext;
using Ps223020_new_good.Core.Models;
using Ps223020_new_good.BusinesLogic.Core.Interfaces;
using Ps223020_new_good.BusinesLogic.Core.Models;
using AutoMapper;

namespace Ps223020_new_good.Controllers
{
    [Route("/api[controller]")]
    [Controller]
    public class UserControler
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserControler(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("registration")]
        public async Task<ActionResult<UserInformationDto>> Register(UserIdentityDto userIdentityDto)
        {
            UserInformationBlo userInformationBlo = await _userService.RegisterWithPhone(userIdentityDto.NumberPrefix, userIdentityDto.Number, userIdentityDto.Password);
            return await ConverToUserInformationAsync(userInformationBlo);
        }
        private async Task<UserInformationDto> ConverToUserInformationAsync(UserInformationBlo userInformationBlo)
        {
            if (userInformationBlo == null) throw new ArgumentNullException(nameof(userInformationBlo));

            UserInformationDto userInformationDto = _mapper.Map<UserInformationDto>(userInformationBlo);

            return userInformationDto;
        }
    }
}
