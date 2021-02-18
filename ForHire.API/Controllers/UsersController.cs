using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ForHire.API.Data;
using ForHire.API.DTOs;
using ForHire.API.Models;
using ForHire.API.Helpers;

namespace ForHire.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IDataRepository _repo;
        private IMapper _mapper;

        public UsersController(IDataRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET http://localhost:5000/api/users/

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserListDto>>(users);
            return Ok(usersToReturn);
        }

        // GET http://localhost:5000/api/users/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserProfileDto>(user);
            return Ok(userToReturn);
        }

        // PUT http://localhost:5000/api/users/{id}/profile

        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _repo.GetUser(id);
            var profile = _mapper.Map<UserProfileDto>(user);
            return Ok(profile);
        }

        // PUT http://localhost:5000/api/users/{id}/

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserProfileDto userProfileUpdate)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            var userFromRepo = await _repo.GetUser(id);
            _mapper.Map(userProfileUpdate, userFromRepo);
            if (await _repo.SaveAll())
            {
                return NoContent();
            }
            throw new Exception($"Updating user {id} failed on save");

        }

        // Get http://localhost:5000/api/users/{id}/applications
        // get all applications by user

        // get application by id

        // 

    }
}
