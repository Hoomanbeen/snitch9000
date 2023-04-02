using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using snitch_9000.Models;
using snitch_9000.Data;
using snitch_9000.DTOs;

namespace snitch_9000.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ISnitchRepo _repository;

        public UserController(ISnitchRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(UserDTO userDTO)
        {
            try{
                // Check user doesn't already exist
                // Create user
                User u = _repository.GetUserByEmail(userDTO.email);
                if (u != null)
                {
                    return BadRequest("User already exists");
                }

                User user = new User();
                user.email = userDTO.email;
                MD5 md5 = MD5.Create();
                user.password = Encoding.ASCII.GetString(md5.ComputeHash(Encoding.ASCII.GetBytes(userDTO.password)));
                _repository.CreateUser(user);

                if(_repository.SaveChanges())
                {
                    string joined_values = user.email + ':' + user.password;
                    string user_token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(joined_values));
                    HttpContext.Response.Cookies.Append("user_token", user_token);
                    return Ok();
                }

                return StatusCode(500);

            } 
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser(UserDTO userDTO)
        {
            try 
            {
                MD5 md5 = MD5.Create();
                string hashed_password = Encoding.ASCII.GetString(md5.ComputeHash(Encoding.ASCII.GetBytes(userDTO.password)));
                User user = _repository.GetUserByEmail(userDTO.email);
                if(user == null) return BadRequest("Email or password is incorrect.");
                if (!(user.email == userDTO.email && user.password == hashed_password)) return BadRequest("Email or password is incorrect.");

                string joined_values = user.email + ':' + user.password;
                string user_token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(joined_values));
                HttpContext.Response.Cookies.Append("user_token", user_token);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }
    }
}