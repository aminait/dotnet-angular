using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ForHire.API.Data;
using ForHire.API.DTOs;
using ForHire.API.Models;
using ForHire.API.Helpers;
using Microsoft.Extensions.Options;

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
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public UsersController(IDataRepository repo, IMapper mapper,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
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

        [HttpGet("{id}/resume", Name = "GetResume")]
        public async Task<IActionResult> GetResume(int id)
        {
            var resumeFromRepo = await _repo.GetResume(id);

            // var resume = _mapper.Map<Resume>(resumeFromRepo);

            return Ok(resumeFromRepo);
        }

        [HttpPost("{userId}/add-resume")]
        public async Task<IActionResult> AddResumeForUser(int userId, [FromForm] ResumeUploadDto resumeUploadDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await _repo.GetUser(userId);
            var file = resumeUploadDto.File;

            var uploadResult = new RawUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new RawUploadParams
                    {
                        File = new FileDescription(file.Name, stream),
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            resumeUploadDto.Url = uploadResult.Url.ToString();
            resumeUploadDto.PublicId = uploadResult.PublicId;

            var resume = _mapper.Map<Resume>(resumeUploadDto);
            resume.UserId = userId;
            _repo.Add(resume);

            if (await _repo.SaveAll())
            {
                var resumeToReturn = _mapper.Map<ResumeUploadDto>(resume);
                return CreatedAtRoute("GetResume", new { userId = userId, id = resume.Id }, resumeToReturn);
            };

            return BadRequest("Could not add the resume");
        }

        //     [HttpDelete("{id}")]
        //     public async Task<IActionResult> DeletePhoto(int userId, int id)
        //     {
        //         if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
        //             return Unauthorized();

        //         var user = await _repo.GetUser(userId);

        //         if (!user.Photos.Any(p => p.Id == id))
        //             return Unauthorized();

        //         var photoFromRepo = await _repo.GetPhoto(id);

        //         if (photoFromRepo.IsMain)
        //             return BadRequest("You cannot delete your main photo");


        //         if (photoFromRepo.PublicId != null)
        //         {
        //             var deleteParams = new DeletionParams(photoFromRepo.PublicId);
        //             var result = _cloudinary.Destroy(deleteParams);

        //             if (result.Result == "ok")
        //             {
        //                 _repo.Delete(photoFromRepo);
        //             }
        //         }

        //         if (photoFromRepo.PublicId == null)
        //         {
        //             _repo.Delete(photoFromRepo);
        //         }

        //         if (await _repo.SaveAll())
        //             return Ok();

        //         return BadRequest("Failed to delete photo");
        //     }
        // }


        // Get http://localhost:5000/api/users/{id}/applications
        // get all applications by user

        // get application by id

        // 

    }
}
