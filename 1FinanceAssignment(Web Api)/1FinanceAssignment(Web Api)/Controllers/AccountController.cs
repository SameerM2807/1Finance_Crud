using _1FinanceAssignment_Web_Api_.AccountDto;
using _1FinanceAssignment_Web_Api_.ContextLayered;
using _1FinanceAssignment_Web_Api_.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1FinanceAssignment_Web_Api_.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly ProductDbContext _context;
        readonly IMapper _mapper;
        public AccountController(ProductDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        [Route("api/Register")]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterDto users)
        {
            User user=_mapper.Map<User>(users);
            var error = await _context.user.AddAsync(user);
           int result=await _context.SaveChangesAsync();
            if (result<=0)
            {


                return BadRequest(error);
            }
            return Ok();
        }

        [Route("api/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
           User? user=await _context.user.FirstOrDefaultAsync(u=>u.Email==loginDto.Email);
            if (user!=null)
            {
                if(user.Password==loginDto.Password)
                {
                    return Ok(true);
                }
            }
            return BadRequest(false);
        }
    }
}
