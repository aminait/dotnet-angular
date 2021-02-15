using System.Linq;
using AutoMapper;
using ForHire.API.DTOs;
using ForHire.API.Models;

namespace ForHire.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // CreateMap<User, UserProfileDto>()
            //     .ForMember(dest => dest.Age, opt =>
            //         opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<UserProfileDto, User>().ForAllMembers(
            opt => opt.Condition((src, dest, sourceMember) => sourceMember != null)
            );

            CreateMap<User, UserProfileDto>();
            CreateMap<UserListDto, User>();
            CreateMap<User, UserListDto>();
            CreateMap<JobPreviewDto, JobListing>();
            CreateMap<JobListing, JobPreviewDto>()
                .ForMember(
                    dest => dest.CompanyName, opt =>
                    opt.MapFrom(src => src.Company.CompanyName)
                )
                .ForMember(
                    dest => dest.TimePosted, opt =>
                    opt.MapFrom(src => src.DatePosted.CalculateTimeElapsed())
                );
            CreateMap<JobListing, JobDetailsDto>()
                .ForMember(
                    dest => dest.CompanySize, opt =>
                    opt.MapFrom(src => src.Company.CompanySize.CalculateSizeRange())
                )
                .ForMember(
                    dest => dest.CompanyName, opt =>
                    opt.MapFrom(src => src.Company.CompanyName)
                )
                .ForMember(
                    dest => dest.TimePosted, opt =>
                    opt.MapFrom(src => src.DatePosted.CalculateTimeElapsed())
                );
            CreateMap<JobDetailsDto, JobListing>();
            CreateMap<CompanyDetailsDto, Company>();
            CreateMap<Company, CompanyDetailsDto>()
                .ForMember(
                        dest => dest.CompanySize, opt =>
                        opt.MapFrom(src => src.CompanySize.CalculateSizeRange())
                    );

            CreateMap<SocialProfilesDto, SocialProfile>();
            CreateMap<SocialProfile, SocialProfilesDto>();


            // CreateMap<Photo, PhotosForDetailedDto>();
            // CreateMap<UserForUpdateDto, User>();
            // CreateMap<Photo, PhotoForReturnDto>();
            // CreateMap<PhotoForCreationDto, Photo>();
        }
    }
}