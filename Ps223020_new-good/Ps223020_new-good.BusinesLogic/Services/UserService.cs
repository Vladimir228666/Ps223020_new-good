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
        private readonly IRubicContext _context;
        public UserService(IMapper mapper, IRubicContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<UserInformationBlo> AuthWithEmail(string email, string password)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
            
            if (user == null)
                throw new NotFoundException($"Пользователь с почтой {email} не найден");


            return await ConverToUserInformationAsync(user);
        }
        public async Task<UserInformationBlo> AuthWithLogin(string login, string password)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);

            if (user == null)
                throw new NotFoundException($"Пользователь с логином {login} не найден");

            return await ConverToUserInformationAsync(user);
        }
        public async Task<UserInformationBlo> AutWithPhone(string numberPrefix, string number, string password)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(p => p.PhoneNumberPrefix == numberPrefix && p.Password == password);
            if (user == null)
                throw new NotFoundException($"Пользователь с телефоном {numberPrefix} не найден");
            return await ConverToUserInformationAsync(user);
        }

        public async Task<bool> DoesExist(string numberPrefix, string number)
        {
            bool result = await _context.Users.AnyAsync(y => y.PhoneNumber == number && y.PhoneNumberPrefix == numberPrefix);
            return result;
        }

        public Task<bool> DoesExist()
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> DoesExists(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInformationBlo> Get(int userId)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null) throw new NotFoundException("Пользователь не найден");
            return await ConverToUserInformationAsync(user);
        }

        public async Task<UserInformationBlo> RegisterWithPhone(string numberPrefix, string number, string password)
        {
            bool result = await _context.Users.AnyAsync(y => y.PhoneNumber == number && y.PhoneNumberPrefix == numberPrefix);
            if (result == true) throw new BadRequestException("Такой пользователь уже есть.");
            
            UserRto user = new UserRto()
            {
                Password = password,
                PhoneNumber = number,
                PhoneNumberPrefix = numberPrefix
            };

            _context.Users.Add(user);

            await _context.SaveChangeAsync();

            var userInfoBlo = await ConverToUserInformationAsync(user);
            return userInfoBlo;
        }
        public async Task<UserInformationBlo> Update(string numberPrefix, string number, string password, UserUpdateBlo userUpdateBlo)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(y => y.PhoneNumber == number && y.PhoneNumberPrefix == numberPrefix && y.Password == password);
            if (user == null) throw new NotFoundException("Такого пользователя нет");

            user.Password = userUpdateBlo.Password;
            user.Email = userUpdateBlo.Email;
            user.Login = userUpdateBlo.Login;
            user.IsBoy = userUpdateBlo.IsBoy;
            user.PhoneNumberPrefix = userUpdateBlo.PhoneNumberPrefix;
            user.PhoneNumber = userUpdateBlo.PhoneNumber;
            user.FirstName = userUpdateBlo.FirstName;
            user.LastName = userUpdateBlo.LastName;
            user.Patronymic = userUpdateBlo.Patronymic;
            user.Birthday = userUpdateBlo.Birthday;
            user.AvatarUrl = userUpdateBlo.AvatarUrl;

            UserInformationBlo userInfoBlo = await ConverToUserInformationAsync(user);
            return userInfoBlo;
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

        private async Task<UserInformationBlo> ConverToUserInformationAsync(UserRto userRto)
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

