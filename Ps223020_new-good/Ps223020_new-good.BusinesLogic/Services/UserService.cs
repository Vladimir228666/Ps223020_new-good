using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ps223020_new_good.BusinesLogic.Core.Interfaces;
using Ps223020_new_good.BusinesLogic.Core.Models;
using Ps223020_new_good.DataAcess.Core.Interfaces.DbContext;
using Ps223020_new_good.DataAcess.Core.Models;
using Share.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps223020_new_good.BusinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly RubicContext _context;
        public UserService(IMapper mapper, RubicContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserInformationBlo> AuthWithEmail(string email, string password)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
            
            if (user == null)
                throw new NotFoundException($"Пользователь с почтой {email} не найден");


            return await ConverToUserInformation(user);
        }

        public Task<UserInformationBlo> AutWithEmail(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> AutWithLogin(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> AutWithPhone(string numberPrefix, string number, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesExist()
        {
            throw new NotImplementedException();
        }

        public async Task<UserInformationBlo> Get(int userId)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new NotFoundException("Пользователь не найден");
            UserInformationBlo userInfoBlo = await ConverToUserInformation(user);
        }

        public Task<UserInformationBlo> RegisterWithPhone(string numberPrefix, string number, string password)
        {
            throw new NotImplementedException();
        }
        public Task<UserInformationBlo> Update(string numberPrefix, string number, string password, UserUpdateBlo userUpdateBlo)
        {
            throw new NotImplementedException();
        }

        Task<UserInformationBlo> IUserService.AutWithEmail(string email, string password)
        {
            throw new NotImplementedException();
        }

        Task<UserInformationBlo> IUserService.AutWithLogin(string login, string password)
        {
            throw new NotImplementedException();
        }

        Task<UserInformationBlo> IUserService.AutWithPhone(string numberPrefix, string number, string password)
        {
            throw new NotImplementedException();
        }

        private async Task<UserInformationBlo> ConverToUserInformation(UserRto userRto)
        {
            if (userRto == null) throw new ArgumentNullException(nameof(userRto));

            var userInformationBlo = _mapper.Map<UserInformationBlo>(userRto);

            return userInformationBlo;
        }

        Task<UserInformationBlo> IUserService.Get(int userId)
        {
            throw new NotImplementedException();
        }

        Task<UserInformationBlo> IUserService.RegisterWithPhone(string numberPrefix, string number, string password)
        {
            throw new NotImplementedException();
        }
    }
}

