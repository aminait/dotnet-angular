// using System.Linq;
// using AutoMapper;
// using ForHire.API.DTOs;
// using ForHire.API.Models;

// namespace ForHire.API.Helpers
// {
//     public class AutoMapperProfiles : Profile
//     {
//         public AutoMapperProfiles()
//         {
//             CreateMap<User, UserProfileDto>()
//                 .ForMember(dest => dest.Age, opt =>
//                     opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
//             CreateMap<JobListing, JobListingsDto>();
//             CreateMap<Photo, PhotosForDetailedDto>();
//             CreateMap<UserForUpdateDto, User>();
//             CreateMap<Photo, PhotoForReturnDto>();
//             CreateMap<PhotoForCreationDto, Photo>();
//         }
//     }
// }