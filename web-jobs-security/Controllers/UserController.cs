using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_jobs_security.Models;
using web_jobs_security.Services;

namespace web_jobs_security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userService.getAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _userService.getUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return Ok(await _userService.save(user));
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id, User user)
        // {

        // }

    }
}