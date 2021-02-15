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

namespace ForHire.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IJobListingsRepository _repo;
        private IMapper _mapper;

        public CompanyController(IJobListingsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET http://localhost:5000/api/companies/
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _repo.GetCompanies();
            return Ok(companies);
        }

        // GET http://localhost:5000/api/companies/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyDetails(int id)
        {
            var company = await _repo.GetCompany(id);
            var companyDetailsDto = _mapper.Map<CompanyDetailsDto>(company);
            return Ok(companyDetailsDto);
        }

        // GET http://localhost:5000/api/companies/{id}/social
        [HttpGet("{id}/social")]
        public async Task<IActionResult> GetCompanySocialProfiles(int id)
        {
            var profilesFromRepo = await _repo.GetCompanySocialProfiles(id);
            List<SocialMediaProfile> profiles = new List<SocialMediaProfile>();
            foreach (var profile in profilesFromRepo)
            {
                profiles.Add(
                    new SocialMediaProfile()
                    {
                        Type = profile.Type,
                        Link = profile.Link
                    }
                );
            }

            return Ok(profiles);
        }

        // should have:
        // getCompaniesByRegion or Location
        // getCompaniesByIndustry
        // so in general get Companies by attribute --> filter

        public class SocialMediaProfile
        {
            public string Type { get; set; }
            public string Link { get; set; }
        }
    }
}