using System;
using Albina.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albina.BuisnessLogic.Core.Models;
using Albina.DataAccessCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Albina.BuisnessLogic.Core.Interfaces;
using AutoMapper;

namespace Albinaserv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("/auth")]
        public async Task<ActionResult<UserInformationDto>> Auth([FromBody] UserIdentityDto userIndentityDto)
        {
            UserIndentityBlo userIndentityBlo = _mapper.Map<UserIndentityBlo>(userIndentityDto);
            UserInformationBlo userInformationBlo = await _userService.Auth(userIndentityBlo);
            UserInformationDto userInformationDto = _mapper.Map<UserInformationDto>(userInformationBlo);
            return userInformationDto;
        }
        [HttpPost("/Register")]
        public async Task<ActionResult<UserInformationDto>> Register([FromBody]UserIdentityDto userIdentityDto)
        {
            UserInformationBlo userIndentityBlo = _mapper.Map<UserIdentityDto>(userIndentityDto);
            UserInformationBlo userInformationBlo = await _userService.Register(userIndentityBlo);
            UserInformationDto userInformationDto = _mapper.Map<UserInformationDto>(userInformationBlo);
            return userInformationDto;
        }
        [HttpPost("/Update")]
        public async Task<ActionResult<UserInformationDto>> Update([FromBody] UserIdentityDto userIdentityDto)
        {
            UserInformationBlo userIndentityBlo = _mapper.Map<UserIdentityDto>(userIdentityDto);
            UserInformationBlo userInformationBlo = await _userService.Update(userIndentityBlo);
            UserInformationDto userInformationDto = _mapper.Map<UserInformationDto>(userInformationBlo);
            return userInformationDto;

            Task<UserInformationBlo> Update(UserIndentityBlo userIndentityBlo, UserUpdateBlo userUpdateBlo);
        }
    }
}
