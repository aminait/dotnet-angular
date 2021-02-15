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
    [Route("api/jobs")]
    [ApiController]
    public class JobListingsController : ControllerBase
    {
        private IJobListingsRepository _repo;
        private IMapper _mapper;

        public JobListingsController(IJobListingsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        // GET http://localhost:5000/api/jobs/

        [HttpGet]
        public async Task<IActionResult> GetJobPreviews()
        {
            var listings = await _repo.GetJobListings();
            var jobsPreviewDto = _mapper.Map<IEnumerable<JobPreviewDto>>(listings);
            return Ok(jobsPreviewDto);
        }

        // GET http://localhost:5000/api/jobs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobPreview(int id)
        {
            var listing = await _repo.GetJobListing(id);
            var jobPreviewDto = _mapper.Map<JobPreviewDto>(listing);
            return Ok(jobPreviewDto);
        }

        // GET http://localhost:5000/api/jobs/{id}/details 
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _repo.GetJobListing(id);
            var jobDetailsDto = _mapper.Map<JobDetailsDto>(job);
            return Ok(jobDetailsDto);
        }

        // GET http://localhost:5000/api/jobs/{id}/tags
        [HttpGet("{id}/tags")]
        public async Task<IActionResult> GetJobTags(int id)
        {
            var tagsFromRepo = await _repo.GetJobListingTags(id);
            var tags = new List<string>();
            foreach (var tag in tagsFromRepo)
            {
                tags.Add(tag.TagName);
            }

            return Ok(tags);
        }

        // GET http://localhost:5000/api/jobs/{id}/company
        [HttpGet("{id}/company")]
        public async Task<IActionResult> GetCompanyByJobId(int id)
        {
            var job = await _repo.GetJobListing(id);
            var company = await _repo.GetCompany(job.CompanyId);
            var companyDetailsDto = _mapper.Map<CompanyDetailsDto>(company);
            return Ok(companyDetailsDto);
        }

        // PUT http://localhost:5000/api/jobs/{id}/save
        [HttpPut("{id}/save")]
        public async Task<IActionResult> ToggleSavedJobListing(int id)
        {
            var job = await _repo.GetJobListing(id);
            job.IsSaved = !job.IsSaved;
            await _repo.SaveAll();
            var jobDetailsDto = _mapper.Map<JobDetailsDto>(job);
            return Ok(jobDetailsDto);
        }

        // GE http://localhost:5000/api/jobs/saved
        [HttpGet("saved")]
        public async Task<IActionResult> GetSavedJobListings()
        {
            var savedJobListings = await _repo.GetSavedJobListings();
            var savedJobListingsDto = _mapper.Map<IEnumerable<JobPreviewDto>>(savedJobListings);
            return Ok(savedJobListingsDto);
        }

        // POST http://localhost:5000/api/jobs/{id}/apply
    }

}