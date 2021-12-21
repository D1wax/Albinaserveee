using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albina.BuisnessLogic.Core.Models;
using Albina.DataAccessCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albinaserv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IContext _context;

        public UserController(IContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<UserInformationBlo>> Auth()
        {

        }
    }
}
