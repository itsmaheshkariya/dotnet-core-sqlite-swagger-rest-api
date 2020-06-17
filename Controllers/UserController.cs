using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;
        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet("")]
        public ActionResult<List<User>> Getstrings()
        {
            return _userContext.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetstringById(int id)
        {
            return _userContext.Users.FirstOrDefault(user => user.Id == id);
        }

        [HttpPost("")]
        public User Poststring(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return user;
        }

        [HttpPut("{id}")]
        public ActionResult<User> Putstring(int id, User user)
        {
            var oldUser = _userContext.Users.FirstOrDefault(user => user.Id == id);
            oldUser.Name = user.Name;
            oldUser.Email = user.Email;
            oldUser.Password = user.Password;
            _userContext.SaveChanges();
            return oldUser;
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeletestringById(int id)
        {
            _userContext.Users.Remove(_userContext.Users.FirstOrDefault(User=> User.Id ==id));
            _userContext.SaveChanges();
            return id;
        }
    }
}
