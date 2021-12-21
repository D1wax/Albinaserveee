using Albina.BuisnessLogic.Core.Interfaces;
using Albina.BuisnessLogic.Core.Models;
using Albina.DataAccessCore.Interfaces;
using Albina.DataAccessCore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shareds.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albina.BuisnessLogic.Core.Servives
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IContext _context;

        public UserService(IMapper mapper, IContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserInformationBlo> Auth(UserIndentityBlo userIndentityBlo)
        {
           UserRto user = await _context.Users.FirstOrDefaultAsync(g => g.Password == userIndentityBlo.Password && g.PhoneNumber == userIndentityBlo.Number);
            if (user == null)
                throw new NotFoundExceptions("Неверный номер телефона или пароль");
            return await ConvertToUserInformation(user);
        }

        public Task<bool> DoesExist(int numberPrefix, int number)
        {
            bool result = await _context.Users.AnyAsync (x => x.PhoneNumberPrefix == numberPrefix && x.PhoneNumber == number)
        }

        public async Task<UserInformationBlo> Get(int userId)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(h => h.Id == userId);
            if (user == null) throw new NotFoundExceptions($"Пользователь с id{userId} не найден");
            UserInformationBlo userInformationBlo = await ConvertToUserInformation(user);
            return userInformationBlo;
        }

        public async Task<UserInformationBlo> Register(UserIndentityBlo userIndentityBlo)
        {
            UserRto newUser = new UserRto()
            {
                PhoneNumberPrefix = userIndentityBlo.NumberPrefix,
                PhoneNumber = userIndentityBlo.Number,
                Password = userIndentityBlo.Password
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
             return await ConvertToUserInformation(newUser);
            
        }

        public async Task<UserInformationBlo> Update(UserIndentityBlo userIndentityBlo, UserUpdateBlo userUpdateBlo)
        {
           UserRto user = await _context.Users.FirstOrDefaultAsync(f => f.PhoneNumber == userIndentityBlo.Number
             && f.PhoneNumberPrefix == userIndentityBlo.NumberPrefix);
            if (user == null) throw new NotFoundExceptions("Такой пользователь не найден");
            user.Name = userUpdateBlo.Name;
            user.Surname = userUpdateBlo.Surname;
            user.ImageUrl = userUpdateBlo.ImageUrl;
            user.Password = userUpdateBlo.Password;
            await _context.SaveChangesAsync();
            return await ConvertToUserInformation(user);


        }

        private async Task<UserInformationBlo> ConvertToUserInformation(UserRto userRto)
        {
            if (userRto == null) throw new ArgumentException(nameof(userRto));

            UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(userRto);
            return userInformationBlo;
        }
    }
}
