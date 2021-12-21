using Albina.BuisnessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albina.BuisnessLogic.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserInformationBlo> Register(UserIndentityBlo userIndentityBlo);
        Task<UserInformationBlo> Auth(UserIndentityBlo userIndentityBlo);
        Task<UserInformationBlo> Update(UserIndentityBlo userIndentityBlo, UserUpdateBlo userUpdateBlo);
        Task<UserInformationBlo> Get(int userId);
        Task<bool> DoesExist(int numberPrefix,int number);
        Task<UserInformationBlo> Auth(UserInformationBlo userInformationBlo);
    }
}
