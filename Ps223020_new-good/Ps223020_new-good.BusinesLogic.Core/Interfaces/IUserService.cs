using Ps223020_new_good.BusinesLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ps223020_new_good.BusinesLogic.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserInformationBlo> RegisterWithPhone(string numberPrefix, string number, string password);
        Task<UserInformationBlo> AutWithPhone(string numberPrefix, string number, string password);
        Task<UserInformationBlo> AutWithEmail(string email, string password);
        Task<UserInformationBlo> AutWithLogin(string login, string password);
        Task<UserInformationBlo> Get(int userId);
        Task<UserInformationBlo> Update(string numberPrefix, string number, string password, UserUpdateBlo userUpdateBlo);
        Task<bool> DoesExist();
    }
}
