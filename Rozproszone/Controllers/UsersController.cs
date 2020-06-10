using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rozproszone.Models;

namespace Rozproszone.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Id = 1, Username = "test", Password = "test" });
                _context.SaveChanges();
            }
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public ActionResult<User> SignUpUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}