using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new List<User>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Users);
        }
        [HttpGet("{Name}")]
        public IActionResult GetById(string Name)
        {
            try
            {
                var user = Users.SingleOrDefault(u => u.Name == Name);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(User User)
        {
            var user = new User
            {
                Name = User.Name,
                Password = User.Password,
                Email = User.Email,
                Age = User.Age,
                PhoneNumber = User.PhoneNumber,
            };
            Users.Add(user);
            return Ok();
        }
        [HttpPut("{name}")]
        public IActionResult Edit(string name, User UserEdit)
        {
            try
            {
                var user = Users.SingleOrDefault(u => u.Name == name);
                if (user == null)
                {
                    return NotFound();
                }
                if (name != user.Name)
                {
                    return BadRequest();
                }
                user.Name = UserEdit.Name;
                user.Password = UserEdit.Password;
                user.Email = UserEdit.Email;
                user.Age = UserEdit.Age;
                user.PhoneNumber = UserEdit.PhoneNumber;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{name}")]
        public IActionResult Remove(string name)
        {
            try
            {
                var user = Users.SingleOrDefault(u => u.Name == name);
                if (user == null)
                {
                    return NotFound();
                }
                Users.Remove(user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

