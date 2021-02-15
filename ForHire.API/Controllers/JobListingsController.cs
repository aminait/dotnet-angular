using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ForHire.API.Data;
using ForHire.API.DTOs;

namespace ForHire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingsController : ControllerBase
    {
        private IDataRepository _repo;
        private IMapper _mapper;

        public JobListingsController(IDataRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetUsers()
        // {
        //     var users = await _repo.GetUsers();
        //     var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
        //     return Ok(usersToReturn);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetUser(int id)
        // {
        //     var user = await _repo.GetUser(id);
        //     var userToReturn = _mapper.Map<UserProfileDto>(user);
        //     return Ok(userToReturn);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateUser(int id, UserUpdateProfileDto userUpdateProfile)
        // {
        //     if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //     {
        //         return Unauthorized();
        //     }
        //     var userFromRepo = await _repo.GetUser(id);
        //     _mapper.Map(userUpdateProfile, userFromRepo);
        //     if (await _repo.SaveAll())
        //     {
        //         return NoContent();
        //     }
        //     throw new Exception($"Updating user {id} failed on save");
        // }
    }

}